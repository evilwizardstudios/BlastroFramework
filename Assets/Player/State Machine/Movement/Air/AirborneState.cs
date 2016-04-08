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

            // If we're falling and hugging the wall, transition to wallgrab
            if (Controller.IsWallgrabbed)
            {
                Transition(new WallgrabState(Controller));
                return;
            }

            //if we're ever in the air, we can always check to see if we can jump
            if (Input.GetButtonDown("A") && RemainingJumps > 0)
            {
                Controller.ParticleProvider.Jump();
                Transition(new JumpingState(Controller, RemainingJumps - 1));
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            MoveHorizontal(Controller.WalkSpeed);
        }

    }
}
