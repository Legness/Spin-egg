using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vilka : MonoBehaviour
{

    private float RandX;
    public Transform hh;




    void FixedUpdate()
    {

        transform.Rotate(0, 0, 120 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeadZone")
        {
            transform.position = hh.position;

        }
        if (other.gameObject.tag == "opasno")
        {
            Destroy(other.gameObject);
        }


    }
}
