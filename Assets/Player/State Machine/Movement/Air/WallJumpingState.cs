using UnityEngine;

namespace Blastro.Movement
{
    public class WallJumpingState : AirborneState
    {
        public WallJumpingState(PlayerController playerController, int jumps) : base(playerController, jumps)
        {
            RB.AddForce(Vector2.Lerp(Vector2.up, Controller.FacingRight? Vector2.left:Vector2.right, 0.3f) * Controller.JumpPower * Controller.JumpBonus);
            Controller.LockMovement(0.2f);
            Controller.LockState(0.2f);
        }
    }
}