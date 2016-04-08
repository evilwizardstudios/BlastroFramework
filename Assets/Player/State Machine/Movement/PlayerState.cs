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
        }

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