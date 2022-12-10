using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineMoving : MonoBehaviour
{

    public Transform leg_1;
    public Transform leg_2;
    public Transform leg_3;
    public Transform leg_4;
    
    public Vector3 average;
    public Vector3 zero;

    public Transform self;
    public Transform front;
    public Vector3 looking_location;
    public Vector3 ideal_location;

    public float speed;
    public float vertical_offset;
    public float sine_offset;

    public float time_since_start;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time_since_start += Time.deltaTime;
        sine_offset = Mathf.Sin(time_since_start);

        looking_location = front.position;
        looking_location.y = self.position.y;

        looking_location.y -= vertical_offset;
        
        average = zero;
        average += leg_1.position;
        average += leg_2.position;
        average += leg_3.position;
        average += leg_4.position;
        average = average / 4;
        ideal_location = average;
        ideal_location.y += sine_offset / 8;

        self.position = Vector3.MoveTowards(self.position, ideal_location, speed);

        transform.LookAt(looking_location);

    }
}
