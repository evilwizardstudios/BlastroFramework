using System;
using UnityEngine;

namespace Blastro.Movement
{
    public class FallingState : AirborneState
    {
        public FallingState(PlayerController playerController, int jumps) : base(playerController, jumps)
        {
        }

        public override void Update()
        {
            base.Update();

            // If we're just falling and doing nothing, carry on...
            if (!Controller.IsGrounded) return;

            // ...otherwise we're on the ground:
            Controller.ParticleProvider.Land();

            // If we're moving, walk.
            if (Mathf.Abs(Input.GetAxis("L-Stick Horizontal")) > float.Epsilon)
            {
                Transition(new WalkingState(Controller));
                return;
            }

            // If we're reading no movement input, go to idle
            Transition(new IdleState(Controller));
        }

    }
}
