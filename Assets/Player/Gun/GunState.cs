using System.Collections;
using UnityEngine;

namespace Blastro.Shooting
{
    public abstract class GunState
    {
        protected GunController Controller;

        public int RemainingAmmo;

        protected GunState(GunController controller, int remainingAmmo)
        {
            Controller = controller;
        }

        public virtual void Update()
        {
                
        }

        public virtual void PhysicsUpdate() { }

        public void Transition(GunState state)
        {
            Controller.State = state;
        }

    }

    public class GunIdleState : GunState
    {
        public GunIdleState(GunController controller, int remainingAmmo) : base(controller, remainingAmmo)
        {
            RemainingAmmo = remainingAmmo;
        }

        public override void Update()
        {
            base.Update();

            if (Input.GetButtonDown("X"))
            {
                Transition(new GunFireState(Controller, RemainingAmmo));
            }
        }
    }

    public class GunFireState : GunState
    {
        public GunFireState(GunController controller, int remainingAmmo) : base(controller, remainingAmmo)
        {
            RemainingAmmo = remainingAmmo;
        }

        public override void Update()
        {
            base.Update();

            if (RemainingAmmo < 1)
            {
                Transition(new GunReloadState(Controller, 0));
            }

            if (Input.GetButtonUp("X"))
            {
                Transition(new GunIdleState(Controller, RemainingAmmo));
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (Controller.IsFireLocked) return;

            Debug.Log("bang!");
            Controller.Fire();
            RemainingAmmo --;

            Controller.FireDelay();
        }
    }

    public class GunReloadState : GunState
    {
        public GunReloadState(GunController controller, int remainingAmmo) : base(controller, remainingAmmo)
        {
            Reload();
        }

        private void Reload()
        {
            Controller.Reload();
        }

        public override void Update()
        {
            if (Controller.IsReloading) return;

            base.Update();

            if (Input.GetButton("X"))
            {
                Transition(new GunFireState(Controller, Controller.MaxAmmo));
            }
            else
            {
                Transition(new GunIdleState(Controller, Controller.MaxAmmo));
            }
        }
    }
}