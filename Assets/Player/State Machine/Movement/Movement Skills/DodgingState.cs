namespace Blastro.Movement
{
    public class DodgingState : PlayerState, IMovementSkill
    {
        public DodgingState(PlayerController playerController) : base(playerController)
        {
            Dodge();
        }

        public override void Update()
        {
            // if control is returned
            
            // if on ground
            // idle state

            // if in air
            // keep control locked until we hit the ground
        }

        private void Dodge()
        {
            //lock all input
            //add forward 
        }


    }
}