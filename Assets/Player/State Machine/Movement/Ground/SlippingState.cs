using UnityEngine;

namespace Blastro.Movement
{
    public class SlippingState : PlayerState
    {
        public SlippingState(PlayerController playerController) : base(playerController)
        {
            Controller.ParticleProvider.StartDustTrail();
        }

        public override void Update()
        {
            if (Input.GetButtonDown("A"))
            {
                Controller.ParticleProvider.EndDustTrail();
                Transition(new JumpingState(Controller, Controller.Properties.Multijump));
            }

            if (!Controller.IsGrounded)
            {
                Controller.ParticleProvider.EndDustTrail();
                Transition(new FallingState(Controller, Controller.Properties.Multijump));
            }
            
            //TODO: bugs out at the end of slides, but is important. Maybe short slide w/ movement lock?
            /*
            if (Controller.SlideAngle < 40)
            {
                Controller.ParticleProvider.EndDustTrail();
                Transition(new IdleState(Controller));
            }
            */
        }

        public override void PhysicsUpdate()
        {
            Vector3 dir = Quaternion.AngleAxis(Controller.SlipAngle, -Vector3.forward)*Vector3.left;

            RB.AddForce(dir * (-Controller.SlipAngle / Controller.Properties.SlipSpeedModifier));
        }
    }
}