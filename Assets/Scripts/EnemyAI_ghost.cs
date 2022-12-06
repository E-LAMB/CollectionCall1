using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_ghost : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent agent;

    public Vector3 location;

    public Transform player;

    public GameObject player_object;

    public int ghost_state;
    // 1 = stalking
    // 2 = hunting

    public float hunting_time = 10f;
    public float max_hunting_time = 0f;
    public float stalking_time = 40f;
    public float finding_stalk_delay = 10f;

    public Transform facing_direction;

    public Material ghost_material;
    Vector4 transparency_colour;

    // Start is called before the first frame update
    void Start()
    {
        
        ghost_state = 1;

    }

    // Update is called once per frame
    void Update()
    {

        if (ghost_state == 1)
        {
            float random_flicker = Random.Range(0f,0.7f);
            transparency_colour = new Vector4(1f,1f,1f,random_flicker);
            ghost_material.color = transparency_colour;
        }   else
        {
            transparency_colour = new Vector4(1f,1f,1f,1f);
            ghost_material.color = transparency_colour;
        }
  
    }
}
