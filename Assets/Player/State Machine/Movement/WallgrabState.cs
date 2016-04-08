using UnityEngine;

namespace Blastro.Movement
{
    public class WallgrabState : PlayerState
    {
        public WallgrabState(PlayerController playerController) : base(playerController)
        {
            Controller.ParticleProvider.StartDustTrail();
        }

        public override void Update()
        {
            // Angled jump off the wall
            if (Input.GetButtonDown("A"))
            {
                Controller.ParticleProvider.EndDustTrail();
                Transition(new WallJumpingState(Controller, Controller.Multijump));
            }

            //if we hit the ground or lose the wall, go back to idle (let it handle falling etc)
            if (!Controller.IsWallgrabbed)
            {
                Controller.ParticleProvider.EndDustTrail();
                Transition(new IdleState(Controller));
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            WallVerticalDecay();
        }

        private void WallVerticalDecay()
        {
            RB.velocity = RB.velocity * Controller.WallDecayRate * Time.deltaTime;
        }
    }
}