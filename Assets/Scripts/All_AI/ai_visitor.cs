using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_visitor : MonoBehaviour
{
    public Vector3 location;
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player_object;
    public Transform player_location;

    public float fade = 10f;
    public float fade_sector;
    public float fade_result;
    public Material material_used;
    public GameObject body;
    public GameObject myself;
    public GameObject ghost;

    public int player_chances;

    // Start is called before the first frame update
    void Start()
    {
        player_object = GameObject.Find("Player");
        player_location = player_object.GetComponent<Transform>();
        fade_sector = 1 / fade;
        material_used = body.GetComponent<MeshRenderer>().material;
        ghost = GameObject.Find("StoryMode_Ghost");
    }

    // Update is called once per frame
    void Update()
    {
        player_chances = ghost.GetComponent<ai_ghost>().chance_query();

        if (player_chances == 0)
        {
            Destroy(myself);
        }
        
        if (fade >= 0f)
        {
            fade -= Time.deltaTime;
        }

        fade_result = fade * fade_sector;
        fade_result = 1 - fade_result;

        material_used.color = new Vector4(1,1,1,fade_result);

        location = player_location.position;

        if (fade < 0)
        {
            agent.SetDestination(location);
        }

        
    
    }
}
