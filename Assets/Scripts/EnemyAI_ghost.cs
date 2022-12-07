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

        if (Physics.CheckSphere(self.position,10f,player))
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
