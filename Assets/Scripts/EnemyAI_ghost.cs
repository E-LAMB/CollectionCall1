using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_ghost : MonoBehaviour
{

    public Vector3 location;

    public float bounds;
    public Transform self;

    public float patience = 60f; // How long the ghost remains patient for

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
        

    }

    // Update is called once per frame
    void Update()
    {

        if (patience < 0f)
        {
            FindNewPlace();
            patience = 45f;
        }

        patience -= Time.deltaTime;

    }
}
