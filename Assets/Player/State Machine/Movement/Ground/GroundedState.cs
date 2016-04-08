using UnityEngine;

namespace Blastro.Movement
{
    public abstract class GroundedState : PlayerState
    {
        protected GroundedState(PlayerController playerController) : base(playerController) { }

        public override void Update()
        {
            if (Input.GetButtonDown("X"))
            {
                Transition(new RunningState(Controller));
            }

            if (Input.GetButtonDown("A"))
            {
                Transition(new JumpingState(Controller, Controller.Multijump));
            }

            if (Controller.IsWallgrabbed)
            {
                Transition(new WallgrabState(Controller));
            }

            if (Mathf.Abs(Controller.SlipAngle) > Controller.SlipThreshold)
            {
                Transition(new SlippingState(Controller));
            }

        }

    }
}
