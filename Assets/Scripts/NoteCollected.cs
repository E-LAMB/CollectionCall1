using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollected : MonoBehaviour
{

    public bool has_been_collected;

    public GameObject detector;
    public LayerMask player_layer;
    public float player_detection_range;

    public Transform visitor_summon_point;
    
    public GameObject counter;
    
    public MeshRenderer my_renderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
