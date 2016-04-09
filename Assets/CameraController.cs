using UnityEngine;
using System.Collections;
using Blastro.Movement;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    public float CameraXSpeed;
    public float CameraYSpeed;

    public float CameraYaxisOffset;

    private int dir = 1;

    private Rigidbody2D rb;
    private PlayerController controller;

    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
        controller = Player.GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) > 0.1) dir = rb.velocity.x > 0 ? 1 : -1;
    }

    void Update()
    {
        //TODO: look offset can be extended w/ aim, sniper zoom etc
        var lookOffset = dir * controller.CameraOffset;

        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, Player.transform.position.x + lookOffset, CameraXSpeed *  Mathf.Abs(rb.velocity.x/2) * Time.deltaTime), 
            Player.transform.position.y + CameraYaxisOffset, /*Mathf.Lerp(transform.position.y, Player.transform.position.y + CameraYaxisOffset, CameraYSpeed * Time.deltaTime),*/
            -30);           
    }

}
