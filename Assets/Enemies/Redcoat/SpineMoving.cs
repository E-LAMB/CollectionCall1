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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        average = zero;
        average += leg_1.position;
        average += leg_2.position;
        average += leg_3.position;
        average += leg_4.position;
        average = average / 4;
        self.position = average;

    }
}
