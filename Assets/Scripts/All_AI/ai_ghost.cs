using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_ghost : MonoBehaviour
{

    public Vector3 location;

    public float bounds;
    public Transform self;

    public LayerMask wall_layer;
    public LayerMask ground_layer;
    public LayerMask player;

    public float patience = 45f;
    public float max_patience = 45f; // How long the ghost remains patient for

    public float distance;
    public bool in_range;
    public bool found_location = false; 

    public bool teleport_space_safe_ray;
    public bool teleport_space_safe_sphere;
    public bool teleport_space_safe_distance;

    public GameObject summonable;
    public Vector3 hidden_offset;

    public float testing_position_y;
    public float wall_range;

    public GameObject player_object;
    public Transform player_transform;

    public Vector3 zero;
    public float zero_distance;

    public bool summoned;

    void FindNewPlace()
    {

        location.x = Random.Range(bounds * -1, bounds);
        location.z = Random.Range(bounds * -1, bounds);

        location.y = self.position.y;
        location.y += testing_position_y;

        teleport_space_safe_ray = Physics.Raycast(location,-transform.up,5f,ground_layer);
        Debug.DrawRay(location, -transform.up);
        teleport_space_safe_sphere = Physics.CheckSphere(location,wall_range,wall_layer);
        zero_distance = Vector3.Distance(self.position, zero);

        if (zero_distance > 15f)
        {
            teleport_space_safe_distance = true;
        } else
        {
            teleport_space_safe_distance = false;
        }

        if (teleport_space_safe_ray == true && teleport_space_safe_sphere == false && teleport_space_safe_distance == true)
        {
            
            found_location = true;
            location.y -= testing_position_y;
            patience = max_patience;
            self.position = location;
            summoned = false;

        } 

    }

    // Start is called before the first frame update
    void Start()
    {
        
        FindNewPlace();
        found_location = true;
        player_object = GameObject.Find("Player");
        player_transform = player_object.GetComponent<Transform>();
        summoned = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (patience < 0f && summoned == false)
        {

            summoned = true;
            Vector3 summon_position = self.position;
            Quaternion summon_rotation = self.rotation;

            Instantiate(summonable, summon_position, summon_rotation);

            player_transform.position = zero;

            self.position = self.position + hidden_offset;

            found_location = false;

        }

        in_range = Physics.CheckSphere(self.position,distance,player);

        if (in_range && Input.GetKeyDown(KeyCode.E))
        {

            found_location = false;
            
        }

        if (found_location == false)
        {
            FindNewPlace();
        }

        if (found_location == true)
        {
            patience -= Time.deltaTime;
        }

    }
}
