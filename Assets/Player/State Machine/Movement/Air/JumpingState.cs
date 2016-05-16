using UnityEngine;

namespace Blastro.Movement
{
    public class JumpingState : AirborneState
    {
        
        public JumpingState(PlayerController playerController, int jumps) : base(playerController, jumps)
        {
            MoveVertical(Controller.Properties.JumpPower, Controller.Properties.JumpBonus);
        }

        public override void Update()
        {
            base.Update();      

            if (RB.velocity.y < 0)
            {
                Transition(new FallingState(Controller, RemainingJumps));
            }          
        }

    }
}