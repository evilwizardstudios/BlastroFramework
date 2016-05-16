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

            if (Mathf.Abs(Controller.SlipAngle) > Controller.Properties.SlipThreshold)
            {
                Transition(new SlippingState(Controller));
            }

        }

        public override void A()
        {
            Transition(new JumpingState(Controller, Controller.Properties.Multijump));
        }

        public override void B()
        {
            Transition(Controller.MovementSkill());
        }

        public override void LT()
        {
            if (Controller.Gun.GProperties.CanAim)
                Transition(new AimingState(Controller));
            else 
                Transition(new StrafingState(Controller));
        }
    }
}
