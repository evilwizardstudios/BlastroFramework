using UnityEngine;
using System.Collections;
using System;

public class DebugLaser : MonoBehaviour {

    private Vector2 firingVector;

    bool registerFire;

    void Update()
    {
        if (Input.GetButtonDown("X"))
        {
            DrawRay(firingVector);
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        SetFiringVector();
	}

    private void DrawRay(Vector2 v)
    {
        Debug.DrawRay(transform.position, Vector3.Normalize(v) * 5, Color.green, 0.1f);
    }

    private void SetFiringVector()
    {
        var x = Input.GetAxis("L-Stick Horizontal");
        var y = Input.GetAxis("L-Stick Vertical");

        if (Mathf.Abs(x+y) > float.Epsilon)
        {
            firingVector = new Vector2(x, y);
        }
        else
        {
            firingVector = new Vector2(transform.parent.GetComponent<SpriteRenderer>().flipX? -1 : 1, 0);
        }

    }
}
