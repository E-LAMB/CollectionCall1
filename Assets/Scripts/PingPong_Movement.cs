using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong_Movement : MonoBehaviour
{

    public Vector3 start_location;
    public Vector3 end_location;
    public Vector3 target;
    public bool moving_StoE;

    public float speed; 
    public Transform self;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (moving_StoE)
        {
            target = end_location;
        }   else
        {
            target = start_location;
        }
        
        distance = Vector3.Distance(transform.position, target);
        self.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (distance < 1f)
        {
            moving_StoE = !moving_StoE;
        }

    }
}
