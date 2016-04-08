using UnityEngine;

namespace Blastro.Movement
{
    public class IdleState : GroundedState
    {
        public IdleState(PlayerController playerController) : base(playerController)
        {

        }

        public override void Update()
        {
            base.Update();

            // If we receive movement input, go to walk state
            if (Mathf.Abs(Input.GetAxis("L-Stick Horizontal")) > 0.1f)
            {
                Transition(new WalkingState(Controller));
                return;
            }

            // If we slip/fall/lose a platform, fall
            if (!Controller.IsGrounded)
            {
                Transition(new FallingState(Controller, Controller.Multijump));
                return;
            }
        }

        public override void PhysicsUpdate()
        {
            if (Mathf.Abs(RB.velocity.x) > float.Epsilon)
            {
                RB.velocity = RB.velocity*Controller.MovementDecayRate*Time.deltaTime;
            }
        }
    }
}
