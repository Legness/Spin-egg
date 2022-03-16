using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vvilka : MonoBehaviour
{
    public Transform vilkaa;
    private float RandX;
    public GameObject oopasno;
    void Start()
    {

        //Vector3 SpawnerPosition = new Vector3(transform.position.x + 1.5f, transform.position.y - 15, 0);
        // Instantiate(oopasno, SpawnerPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        vilkaa.transform.Translate(0, -4 * Time.deltaTime, 0);
        if (transform.position.y < -10)
        {
            Destroy(transform.gameObject);
        }
    }
   
}
