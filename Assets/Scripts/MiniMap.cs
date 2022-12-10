using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    public Transform player;
    public Transform self;
    public Vector3 location;
    public float y_lock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        location = player.position;
        location.y = y_lock;

        self.position = location;

    }
}
