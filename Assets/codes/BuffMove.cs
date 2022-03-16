using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffMove : MonoBehaviour
{
    [SerializeField] GameObject buff;
    [SerializeField] float speed;
    void Update()
    {
        buff.transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
