using System;
using UnityEngine;
using System.Collections;

namespace Blastro.Movement
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerState State;
        public IMovementSkill MovementSkill;

        [HideInInspector] public ParticleProvider ParticleProvider;
        [HideInInspector] public bool IsGrounded;
        [HideInInspector] public bool IsWallgrabbed;

        [SerializeField] private Vector2 RaycastDistance;
        [SerializeField] private LayerMask ColliderRaycastLayerMask;

        [SerializeField] public float MovementDecayRate;
        [SerializeField] public float WallDecayRate;

        public int Multijump;

        public float JumpBonus;

        public float RunSpeed;
        public float WalkSpeed;
        public float JumpPower;

        public float SlipThreshold;
        public float SlipSpeedModifier;
        public float SlipAngle { get; private set; }


        [HideInInspector]
        public bool FacingRight
        {
            get { return !sr.flipX; }
        }

        [HideInInspector] public Rigidbody2D RB;
        private Animator anim;
        private SpriteRenderer sr;
        private BoxCollider2D footCollider;

        public bool MovementLocked { get; private set; }
        public bool StateLocked { get; private set; }

        private void Start()
        {

            RB = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();
            footCollider = GetComponent<BoxCollider2D>();

            ParticleProvider = GetComponentInChildren<ParticleProvider>();

            State = new IdleState(this);
        }

        private void Update()
        {
            Raycast();
            if (!StateLocked) State.Update();
        }

        private void FixedUpdate()
        {
            State.PhysicsUpdate();

            anim.SetFloat("XInput", Mathf.Abs(Input.GetAxis("L-Stick Horizontal")));
            anim.SetFloat("XVelocity", Mathf.Abs(RB.velocity.y));
            anim.SetFloat("YVelocity", RB.velocity.y);
            anim.SetBool("IsGrounded", IsGrounded);
            anim.SetBool("IsWallgrabbed", IsWallgrabbed);
            anim.SetBool("IsSlippingState", State is SlippingState);

            if (RB.velocity.x < -0.1f)
            {
                sr.flipX = true;
            }
            else if (RB.velocity.x > 0.1f)
            {
                sr.flipX = false;
            }

        }

        private void Raycast()
        {
            IsGrounded = footCollider.IsTouchingLayers(~9);

            SlipAngle = 0;
            if (IsGrounded)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, Mathf.Infinity,
                    ColliderRaycastLayerMask);
                if (hit) SlipAngle = Mathf.Atan2(hit.normal.x, hit.normal.y)*Mathf.Rad2Deg;
            }

            var sideHit = Physics2D.Linecast(
                new Vector2(transform.position.x - RaycastDistance.x, transform.position.y),
                new Vector2(transform.position.x + RaycastDistance.x, transform.position.y), ColliderRaycastLayerMask);

            float wallAngle = 0;
            if (sideHit.collider != null)
            {
                sr.flipX = sideHit.point.x < transform.position.x;
                wallAngle = Mathf.Atan2(sideHit.normal.x, sideHit.normal.y) * Mathf.Rad2Deg;
            }

            IsWallgrabbed = !IsGrounded && sideHit.collider != null && Math.Abs(wallAngle + 90) < float.Epsilon;
        }

        public void LockMovement(float seconds)
        {
            StartCoroutine(MoveLock(seconds));
        }

        private IEnumerator MoveLock(float seconds)
        {
            MovementLocked = true;
            yield return new WaitForSeconds(seconds);
            MovementLocked = false;
        }

        public void LockState(float seconds)
        {
            StartCoroutine(StateLock(seconds));
        }

        private IEnumerator StateLock(float seconds)
        {
            StateLocked = true;
            yield return new WaitForSeconds(seconds);
            StateLocked = false;
        }
    }
}