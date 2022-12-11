using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollected : MonoBehaviour
{

    public bool has_been_collected;

    public Transform detector;
    public LayerMask player_layer;
    public float player_detection_range;
    public bool player_in_range;

    public Transform visitor_summon_point;
    public GameObject visitor_prefab;
    
    public GameObject counter;
    
    public MeshRenderer my_renderer;
    public Light light_used;

    // Start is called before the first frame update
    void Start()
    {
        counter = GameObject.Find("NoteTracker");
        light_used.intensity = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
        player_in_range = Physics.CheckSphere(detector.position,player_detection_range,player_layer);

        if (player_in_range && has_been_collected == false && Input.GetKeyDown(KeyCode.E))
        {
            has_been_collected = true;
            my_renderer.enabled = false;
            counter.GetComponent<NoteCounter>().GotNote();

            light_used.intensity = 0f;

            Vector3 summon_position = visitor_summon_point.position;
            Quaternion summon_rotation = visitor_summon_point.rotation;
            Instantiate(visitor_prefab, summon_position, summon_rotation);
        }

    }
}
