using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNavmesh : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent agent;
    public Transform movement_target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        agent.SetDestination(movement_target.position);

    }
}
