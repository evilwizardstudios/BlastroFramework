using System.Collections;
using Blastro.Movement;
using Blastro.UI.Hud;
using UnityEngine;

namespace Blastro.Shooting
{
    public class GunController : MonoBehaviour
    {
        public GameObject Player;
        public GameObject Reticle;
        private ReticleController rController;

        public GunState State;

        public Bullet Bullet;
        public GunProperties GProperties;
        public ProjectileProperties PProperties;
        public GameObject DamageText;

        private PlayerController playerController;

        private SpriteRenderer sRenderer;

        public bool IsReloading { get; private set; }

        public bool IsFireLocked { get; private set; }

        public float IdlePositionX;
        

        private void Start()
        {
            playerController = Player.GetComponent<PlayerController>();
            sRenderer = GetComponent<SpriteRenderer>();
            rController = Reticle.GetComponent<ReticleController>();

            GearCheck();

            State = new GunIdleState(this, GProperties.ClipSize);

            IdlePositionX = transform.position.x;

            Bullet.Init(PProperties);

            playerController.HUD.SetGunAmmo(GProperties.ClipSize);
        }

        public void ReticleLock(bool b)
        {
            rController.Lock(b);
        }

        public void GearCheck()
        {
            //TEST METHOD
            PProperties = new ProjectileProperties { LaunchSpeed = 10, Owner = playerController, HitDamageMinimum = 0.5f, HitDamageMaximum = 1.2f, Gun = this, CritChance = 0.1f, CritDamageModifier = 1.8f };
            GProperties = new GunProperties { Spread = 2.5f, AmmoPerShot = 1, ClipSize = 15, RateOfFire = 0.2f, ReloadTime = 1, AimSpeed = 5, FocusSpeed = 0.2f };
        }

        private void Update()
        {
            AimGunSprite();

            State.Update();
        }

        void FixedUpdate()
        {
            State.PhysicsUpdate();
        }

        void AimGunSprite()
        {
            sRenderer.flipY = Reticle.transform.position.x < transform.position.x;

            Vector3 dir = Reticle.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


        public void Reload()
        {
            IsReloading = true;
            StartCoroutine(ReloadTimer(GProperties.ReloadTime));
        }

        IEnumerator ReloadTimer(float seconds)
        {
            Debug.Log("Reloading...");
            yield return new WaitForSeconds(seconds);
            Debug.Log("finished reloading!");
            IsReloading = false;
            playerController.HUD.ReloadAmmo();
        }

        public void FireDelay()
        {
            IsFireLocked = true;
            StartCoroutine(Delay(GProperties.RateOfFire));
        }

        IEnumerator Delay(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            IsFireLocked = false;
        }

        public void Fire()
        {
            Bullet.Fire(GProperties, rController);
            rController.ResetReticle();
            playerController.HUD.MarkUsedAmmo(GProperties.AmmoPerShot);
        }


    }
}
