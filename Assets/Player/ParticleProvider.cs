using UnityEngine;
using System.Collections;

public class ParticleProvider : MonoBehaviour
{
    private ParticleSystem[] effects;
    private Rigidbody2D RB;

    void Start()
    {
        effects = GetComponentsInChildren<ParticleSystem>();
        RB = GetComponentInParent<Rigidbody2D>();
    }

    public void Land()
    {
        effects[0].Emit(4);
    }

    public void Jump()
    {
        effects[1].Emit(6);
    }

    public void StartDustTrail()
    {
        Debug.Log("started trail");
        effects[2].Play();
    }

    public void EndDustTrail()
    {
        effects[2].Stop();
    }

}
