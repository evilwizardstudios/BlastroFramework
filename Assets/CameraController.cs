using UnityEngine;
using System.Collections;
using Blastro.Movement;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Reticle;

    public Transform LerpTarget;

    public float CameraXSpeed;
    public float CameraYSpeed;

    public float CameraYaxisOffset;

    private Rigidbody2D rb;
    private PlayerController controller;

    private float lookOffset;

    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
        controller = Player.GetComponent<PlayerController>();

        LerpTarget = Player.transform;
    }

    void Update()
    {
        if (controller.State is AimingState) AimMode();
        else StandardMode();       
    }

    /// <summary>
    /// Allows the camera to lerp further from the player position when aiming. Used esp. in sniper weapons.
    /// </summary>
    private void AimMode()
    {
        LerpTarget = Reticle.transform;
        lookOffset = 0;

        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, LerpTarget.position.x + lookOffset, CameraXSpeed * Time.deltaTime),
            Mathf.Lerp(transform.position.y, LerpTarget.position.y, CameraYSpeed * Time.deltaTime),
            -30);

    }

    /// <summary>
    /// Lerps the camera towards the player position, with a small offset (controller.CameraOffset) for facing.
    /// </summary>
    private void StandardMode()
    {
        LerpTarget = Player.transform;
        lookOffset = controller.FacingRight ? controller.Properties.CameraOffset : -controller.Properties.CameraOffset;

        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, LerpTarget.position.x + lookOffset, CameraXSpeed*Time.deltaTime),
            Mathf.Lerp(transform.position.y, LerpTarget.position.y, CameraYSpeed * Time.deltaTime),
            -30);
    }

}
