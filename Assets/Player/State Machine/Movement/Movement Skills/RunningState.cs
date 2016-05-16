using UnityEngine;

namespace Blastro.Movement
{
    public class RunningState : GroundedState, IMovementSkill
    {
        public RunningState(PlayerController playerController, PlayerState previousState) : base(playerController)
        {
            if (!(previousState is WalkingState))
            {
                Transition(new IdleState(Controller));
                return;
            }

           Controller.ParticleProvider.StartDustTrail();
        }

        public override void Update()
        {
            base.Update();

            if (Input.GetButtonUp("X"))
            {
                Controller.ParticleProvider.EndDustTrail();
                Transition(new WalkingState(Controller));
            }

            if (Input.GetButtonDown("A"))
            {
                Controller.ParticleProvider.EndDustTrail();
                Transition(new JumpingState(Controller, Controller.Properties.Multijump));
            }

            if (Mathf.Abs(Input.GetAxis("L-Stick Horizontal")) < 0.4f)
            {
                Controller.ParticleProvider.EndDustTrail();
                Transition(new WalkingState(Controller));
            }

            if (Mathf.Abs(RB.velocity.x) < 0.1f)
            {
                Controller.ParticleProvider.EndDustTrail();
                Transition(new FallingState(Controller, Controller.Properties.Multijump));
            }

            if (!Controller.IsGrounded)
            {
                Controller.ParticleProvider.EndDustTrail();
                Transition(new FallingState(Controller, Controller.Properties.Multijump));
            }
        }

        public override void PhysicsUpdate()
        {
            MoveHorizontal(Controller.Properties.RunSpeed);
        }

        public PlayerState GetNew()
        {
            return new RunningState(Controller, Controller.State);
        }

    }
}