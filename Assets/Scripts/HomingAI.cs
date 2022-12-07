using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingAI : MonoBehaviour
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

    public Animator controller;

    // Start is called before the first frame update
    void Start()
    {
        player_object = GameObject.Find("Player");
        player_location = player_object.GetComponent<Transform>();
        fade_sector = 1 / fade;
        material_used = body.GetComponent<SkinnedMeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            controller.SetBool("CompleteAppearance",true);
            agent.SetDestination(location);
        }

        
    
    }
}
