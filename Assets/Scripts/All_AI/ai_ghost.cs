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

    public GameObject summonable;

    void FindNewPlace()
    {

        location.x = Random.Range(bounds * -1, bounds);
        location.z = Random.Range(bounds * -1, bounds);

        location.y = self.position.y;

        teleport_space_safe_ray = Physics.Raycast(location,-transform.up,5f,ground_layer);
        Debug.DrawRay(location, -transform.up);
        teleport_space_safe_sphere = Physics.CheckSphere(location,3f,wall_layer);

        if (teleport_space_safe_ray == true && teleport_space_safe_sphere == false)
        {
            Vector3 summon_position = self.position;
            Quaternion summon_rotation = self.rotation;
            Instantiate(summonable, summon_position, summon_rotation);
            
            found_location = true;
            patience = max_patience;
            self.position = location;
        } 

    }

    // Start is called before the first frame update
    void Start()
    {
        
        FindNewPlace();

    }

    // Update is called once per frame
    void Update()
    {

        if (patience < 0f)
        {

            found_location = false;

            FindNewPlace();

        }

        in_range = Physics.CheckSphere(self.position,distance,player);

        if (in_range)
        {

            found_location = false;
            FindNewPlace();
        }

        patience -= Time.deltaTime;

    }
}
