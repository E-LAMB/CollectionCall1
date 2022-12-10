using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KneesMoving : MonoBehaviour
{

    public Transform my_location;
    public Vector3 wanting_location;
    public Transform lower_leg;
    public Vector3 offset;
    public Transform pilot_knee;

    public float acceptable_distance = 1f;
    public float actual_distance;

    public float speed = 1f;

    public bool should_be_active = false;

    public float grace = 1f;

    public void set_state(bool state_set)
    {
        should_be_active = state_set;
    }

    public bool request_state()
    {
        return should_be_active;
    }

    // Start is called before the first frame update
    void Start()
    {
        my_location = GetComponent<Transform>();
        my_location.position = lower_leg.position; 
    }

    // Update is called once per frame
    void Update()
    {

        if (grace > -1f)
        {
            grace -= Time.deltaTime;

            wanting_location = lower_leg.position + pilot_knee.position;
            wanting_location = wanting_location / 2;   
            wanting_location += offset;
            my_location.position = Vector3.MoveTowards(my_location.position, wanting_location, 2000f);
        }

        actual_distance = Vector3.Distance(my_location.position, lower_leg.position);

        if (actual_distance > acceptable_distance)
        {
            wanting_location = lower_leg.position + pilot_knee.position;
            wanting_location = wanting_location / 2;   
            wanting_location += offset;
        }

        if (should_be_active)
        {
            my_location.position = Vector3.MoveTowards(my_location.position, wanting_location, speed);
        }
    }
}
