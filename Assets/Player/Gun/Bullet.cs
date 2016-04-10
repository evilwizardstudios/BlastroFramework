using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Blastro.Shooting
{
    public class Bullet : PooledObject
    {
        public Rigidbody2D RB { get; private set; }
        public float Velocity;

        void Awake()
        {
            RB = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(RB.velocity.y, RB.velocity.x)*Mathf.Rad2Deg,
                Vector3.forward);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log(col.gameObject.layer);

            if (col.gameObject.layer == 8) return;

            Destroy(gameObject);
        }
    }
}
