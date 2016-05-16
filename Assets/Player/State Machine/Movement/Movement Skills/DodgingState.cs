using UnityEngine;

namespace Blastro.Movement
{
    public class DodgingState : PlayerState, IMovementSkill
    {
        public DodgingState(PlayerController playerController) : base(playerController)
        {
            Dodge();
        }

        public override void Update()
        {
            if (Controller.IsGrounded && Mathf.Abs(Controller.RB.velocity.x) < 0.1f)
                Transition(new IdleState(Controller));
        }

        private void Dodge()
        {
            //apply invincibility/passthrough

            if (Controller.IsGrounded)
                Controller.RB.velocity = ((Controller.FacingRight ? Vector2.right : Vector2.left) * 5);
            else
            {
                Controller.RB.velocity = ((Controller.FacingRight ? Vector2.right : Vector2.left) * 3);
            }
        }

        public PlayerState GetNew()
        {
            return new DodgingState(Controller);
        }
        
    }
}