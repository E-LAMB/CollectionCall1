using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_ghost : MonoBehaviour
{

    public Vector3 location;

    public float bounds;
    public Transform self;

    public LayerMask walls;
    public LayerMask player;

    public float patience = 45f;
    public float max_patience = 45f; // How long the ghost remains patient for

    public float distance;
    public bool in_range;

    public GameObject summonable;

    void FindNewPlace()
    {

        location.x = Random.Range(bounds * -1, bounds);
        location.z = Random.Range(bounds * -1, bounds);

        location.y = self.position.y;

        self.position = location;
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

            Vector3 summon_position = self.position;
            Quaternion summon_rotation = self.rotation;

            Instantiate(summonable, summon_position, summon_rotation);

            FindNewPlace();

            if (!Physics.CheckSphere(location,3f,walls))
            {
                FindNewPlace();
            }

            if (!Physics.CheckSphere(location,3f,walls))
            {
                FindNewPlace();
            }

            if (!Physics.CheckSphere(location,3f,walls))
            {
                FindNewPlace();
            }

            if (!Physics.CheckSphere(location,3f,walls))
            {
                FindNewPlace();
            }

            patience = max_patience;
        }

        in_range = Physics.CheckSphere(self.position,distance,player);

        if (in_range)
        {
            patience = max_patience;
            FindNewPlace();

            if (!Physics.CheckSphere(location,3f,walls))
            {
                FindNewPlace();
            }

            if (!Physics.CheckSphere(location,3f,walls))
            {
                FindNewPlace();
            }
            
            if (!Physics.CheckSphere(location,3f,walls))
            {
                FindNewPlace();
            }
        }

        patience -= Time.deltaTime;

    }
}
