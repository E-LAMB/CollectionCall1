using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsMoving : MonoBehaviour
{

    public Transform my_location;
    public Transform target_location;

    public float acceptable_distance = 1f;
    public float actual_distance;

    // Start is called before the first frame update
    void Start()
    {
        my_location = GetComponent<Transform>();
        my_location.position = target_location.position;   
    }

    // Update is called once per frame
    void Update()
    {
        actual_distance = Vector3.Distance(my_location.position, target_location.position);
        if (actual_distance > acceptable_distance)
        {
            my_location.position = target_location.position;   
        }
    }
}
