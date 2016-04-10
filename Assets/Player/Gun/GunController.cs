using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blastro.Movement;
using UnityEngine;

namespace Blastro.Shooting
{
    public class GunController : MonoBehaviour
    {
        public GameObject Player;

        public GunState State;

        public Bullet Bullet;

        private PlayerController playerController;
        private Rigidbody2D playerRB;

        public float AimSpeed;
        public int MaxAmmo;

        public bool IsReloading { get; private set; }
        public float ReloadTime;

        public bool IsFireLocked { get; private set; }
        public float RateOfFire;

        public float IdlePositionX;


        private void Start()
        {
            playerController = Player.GetComponent<PlayerController>();
            playerRB = Player.GetComponent<Rigidbody2D>();

            State = new GunIdleState(this, MaxAmmo);

            IdlePositionX = transform.position.x;
        }

        private void Update()
        {
            var lerpTarget = GetTarget();

            transform.position = Vector3.Lerp(transform.position, 
                lerpTarget,
                Time.deltaTime*AimSpeed);

            State.Update();
        }

        Vector3 GetTarget()
        {
            var facing = playerController.FacingRight ? 1 : -1;

            return new Vector3(Player.transform.position.x + (IdlePositionX*facing), Player.transform.position.y, 0) +
                   GetAimOffset();
        }

        void FixedUpdate()
        {
            State.PhysicsUpdate();
        }

        private Vector3 GetAimOffset()
        {
            // limit shooting at the ground while moving
            if (!(playerController.State is AimingState) && Mathf.Abs(playerRB.velocity.x) > 0.1f && Input.GetAxis("L-Stick Vertical") < -0.1f)
                return new Vector3(Input.GetAxis("L-Stick Horizontal"), 0, 0);

            return new Vector3(Input.GetAxis("L-Stick Horizontal"), Input.GetAxis("L-Stick Vertical"), 0);
        }

        public void Reload()
        {
            IsReloading = true;
            StartCoroutine(ReloadTimer(ReloadTime));
        }

        IEnumerator ReloadTimer(float seconds)
        {
            Debug.Log("Reloading...");
            yield return new WaitForSeconds(seconds);
            Debug.Log("finished reloading!");
            IsReloading = false;
        }

        public void FireDelay()
        {
            IsFireLocked = true;
            StartCoroutine(Delay(RateOfFire));
        }

        IEnumerator Delay(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            IsFireLocked = false;
        }

        public void Fire()
        {
            var bulletGO = Bullet.GetPooledInstance<Bullet>();
            var firingVector = (transform.position - Player.transform.position).normalized;

            bulletGO.transform.localPosition = Player.transform.position;
            bulletGO.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(firingVector.y, firingVector.x) * Mathf.Rad2Deg,Vector3.forward);
            bulletGO.RB.velocity = firingVector * bulletGO.Velocity;
        }


    }
}
