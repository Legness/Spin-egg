using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotetion : MonoBehaviour
{ 
   
        [SerializeField] GameObject Ball;
        bool direction = false;
        void FixedUpdate()
    {
        if (direction == false)
            Ball.transform.Rotate(0, 0, 100 * Time.deltaTime);
        else
            Ball.transform.Rotate(0, 0, -100 * Time.deltaTime);
    }
    public void ChangeDirection()
    {
        direction = !direction;
    }
    
}
