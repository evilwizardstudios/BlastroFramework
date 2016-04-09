using UnityEngine;

namespace Blastro.Movement
{
    public abstract class GroundedState : PlayerState
    {
        protected GroundedState(PlayerController playerController) : base(playerController) { }

        public override void Update()
        {
            base.Update();
            
            if (Controller.IsWallgrabbed)
            {
                Transition(new WallgrabState(Controller));
            }

            if (Mathf.Abs(Controller.SlipAngle) > Controller.SlipThreshold)
            {
                Transition(new SlippingState(Controller));
            }

        }

        public override void A()
        {
            Transition(new JumpingState(Controller, Controller.Multijump));
        }

        public override void B()
        {
            Debug.Log("b pressed");
            Transition(new RunningState(Controller, this));
        }

        public override void X()
        {
            Debug.Log("x pressed");
        }
    }
}
