using System;
using UnityEngine;

namespace Blastro.Movement
{
    public abstract class PlayerState
    {
        protected PlayerController Controller;
        protected Rigidbody2D RB;

        protected PlayerState(PlayerController playerController)
        {
            Controller = playerController;
            RB = playerController.RB;
        }

        public virtual void Update()
        {
            // collect movement button presses:

            if (Input.GetButtonDown("A"))
            {
                A();
            }

            if (Input.GetButtonDown("X"))
            {
                X();
            }

            if (Input.GetButtonDown("B"))
            {
                B();
            }

            if (Input.GetAxis("Left Trigger") > 0.4f)
            {
                LT();
            }

            if (Input.GetButtonDown("Left Bumper"))
            {
                LB();
            }
        }

        // jump
        public virtual void A() { }

        // dodge skill
        public virtual void B() { }

        // shoot/attack
        public virtual void X() { }

        // aim
        public virtual void LT() { }

        // reload
        public virtual void LB() { }

        public virtual void PhysicsUpdate() {}

        protected void Transition(PlayerState nextState)
        {
            Controller.State = nextState;
        }

        protected void MoveHorizontal(float multiplier)
        {
            if (Controller.MovementLocked) return;

            var moveAxis = Input.GetAxis("L-Stick Horizontal");

            if (Mathf.Abs(moveAxis) > 0.1f)
            {
                RB.velocity = new Vector2( moveAxis * multiplier, RB.velocity.y);
            }
        }

        protected void MoveVertical(float jumpPower, float multiplier)
        {
            RB.velocity = new Vector2(RB.velocity.x, jumpPower * multiplier);
        }
       
    }
}