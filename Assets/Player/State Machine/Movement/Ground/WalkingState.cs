using UnityEngine;

namespace Blastro.Movement
{
    public class WalkingState : GroundedState
    {
        public WalkingState(PlayerController playerController) : base(playerController) { }

        public override void Update()
        {
            base.Update();
            
            //If we don't detect any movement input, return to idle.
            if (Mathf.Abs(Input.GetAxis("L-Stick Horizontal")) <= 0.1f)
            {
                Transition(new IdleState(Controller));
            }

        }

        public override void PhysicsUpdate()
        {
            MoveHorizontal(Controller.WalkSpeed);
        }
    }
}