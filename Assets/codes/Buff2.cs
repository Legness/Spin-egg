using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff2 : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bonus")
        {
            Destroy(other.gameObject);
        }
    }
}
