using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blastro.Movement;
using UnityEngine;

namespace Blastro.Shooting
{
    public class GunController : MonoBehaviour
    {
        public GameObject Player;

        private PlayerController playerController;
        private Rigidbody2D playerRB;

        public float AimSpeed;

        void Start()
        {
            playerController = Player.GetComponent<PlayerController>();
            playerRB = Player.GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, Player.transform.position + GetAimOffset(),
                Time.deltaTime * AimSpeed);
        }

        Vector3 GetAimOffset()
        {
            return new Vector3(Input.GetAxis("L-Stick Horizontal"), Input.GetAxis("L-Stick Vertical"), 0);
        }


    }
}
