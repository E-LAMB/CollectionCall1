using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingPlayerLamp : MonoBehaviour
{

    public Transform target;
    public float speed; 
    public Transform self;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        self.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
