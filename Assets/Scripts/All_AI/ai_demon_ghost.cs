using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_demon_ghost : MonoBehaviour
{

    public GameObject player;
    public Transform player_transform;
    public Vector3 location;
    public UnityEngine.AI.NavMeshAgent agent;
    public bool active_state = false;
    public Renderer my_renderer;
    public Renderer face_renderer;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player_transform = player.GetComponent<Transform>();
        my_renderer.enabled = false;
        face_renderer.enabled = false;
    }

    public void ghost_death()
    {
        active_state = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (active_state)
        {
            location = player_transform.position;
            agent.SetDestination(location);
            my_renderer.enabled = true;
            face_renderer.enabled = true;
            player.GetComponent<PlayerController>().force_to_look(transform.position + offset);
        }

    }
}
