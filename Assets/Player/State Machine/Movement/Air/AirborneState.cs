using UnityEngine;

namespace Blastro.Movement
{
    public abstract class AirborneState : PlayerState
    {
        protected readonly int RemainingJumps;

        protected AirborneState(PlayerController playerController, int jumps) : base(playerController)
        {
            RemainingJumps = jumps;
        }

        public override void Update()
        {
            base.Update();

            // If we're airborne and hugging the wall, transition to wallgrab
            if (Controller.IsWallgrabbed)
            {
                Transition(new WallgrabState(Controller));
                return;
            }
        }

        public override void A()
        {
            if (RemainingJumps <= 0) return;

            Transition(new JumpingState(Controller, RemainingJumps - 1));
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            MoveHorizontal(Controller.WalkSpeed);
        }

    }
}
