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

        public override void LT()
        {
            Transition(new AimingState(Controller));
        }
    }

    public class AimingState : GroundedState
    {
        public AimingState(PlayerController playerController) : base(playerController) {}

        public override void Update()
        {
            if (Input.GetAxis("Left Trigger") < 0.4f)
            {
                Transition(new IdleState(Controller));
            }
        }

        public override void PhysicsUpdate() { }
    }
}
