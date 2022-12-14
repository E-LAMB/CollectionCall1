using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsMoving : MonoBehaviour
{

    public Transform my_location;
    public Vector3 wanting_location;
    public Transform target_location;

    public float acceptable_distance = 1f;
    public float actual_distance;

    public float speed = 0.1f;

    public bool should_be_active = false;
    public GameObject my_parent; 

    public float grace = 1f;

    // Start is called before the first frame update
    void Start()
    {
        my_location = GetComponent<Transform>();
        my_location.position = target_location.position;   
    }

    // Update is called once per frame
    void Update()
    {

        if (grace > -1f)
        {
            grace -= Time.deltaTime;

            wanting_location = target_location.position;
            my_location.position = Vector3.MoveTowards(my_location.position, wanting_location, 2000f);
        }

        should_be_active = my_parent.GetComponent<KneesMoving>().request_state();

        actual_distance = Vector3.Distance(my_location.position, target_location.position);

        if (actual_distance > acceptable_distance)
        {
            wanting_location = target_location.position;   
        }

        if (should_be_active)
        {
            my_location.position = Vector3.MoveTowards(my_location.position, wanting_location, speed);
        }
    }
}
