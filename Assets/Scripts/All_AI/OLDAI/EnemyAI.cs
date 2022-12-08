using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Vector3[] patrol_points;

    public UnityEngine.AI.NavMeshAgent agent;

    public Vector3 location;

    public Transform player;

    public GameObject player_object;

    public bool ray_hits_player;
    public bool ray_hits_collision;

    public LayerMask seek_layers;
    public LayerMask blocked_layers;

    public float max_distance = 2000f;

    public bool moving_enabled = false;
    public float max_sight = 200f;

    public Vector3 shoot_position;

    public float player_distance = 0f;
    public float patrol_distance = 0f; // The distance the enemy is to it's patrol point

    public float interest_time = 1f; // The time since the last interesting event occured
    // This is such as seeing the player. During this time it will not look in a new direction.

    public float patrol_time = 0f; // The time since the last patrol point was set
    public float patrol_recovery_time = 20f; // The maximum time the enemy takes before it chooses another patrol point
    public int random_chosen;

    public Transform facing_direction;

    float knows_location_for = 0f;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    public void KnowsLocation(float knowledge_time)
    {

        knows_location_for = knowledge_time;
		interest_time = 10f;
		patrol_time = patrol_recovery_time;
		location = player.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (knows_location_for > 0f)
        {
            location = player.position;
            knows_location_for = knows_location_for - Time.deltaTime;
            agent.SetDestination(location);
        }

        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        shoot_position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);

        direction = (transform.position - player.position).normalized;
        direction = direction * -1f;

        player_distance = Vector3.Distance(transform.position, player.position);
        patrol_distance = Vector3.Distance(transform.position, location);

        if (player_distance > max_sight)
        {
            player_distance = max_sight;
        }

        ray_hits_player = Physics.Raycast(shoot_position, direction, player_distance, seek_layers);
        ray_hits_collision = Physics.Raycast(shoot_position, direction, player_distance, blocked_layers);

        Debug.DrawRay(shoot_position,direction*player_distance);

        if (ray_hits_player == true && ray_hits_collision == false)
        {
            KnowsLocation(1f);
            interest_time = 5f;
        }

        if (patrol_time <= 0f && interest_time <= 0f)
        {

            random_chosen = Random.Range(0, patrol_points.Length);

            location = patrol_points[random_chosen];

            patrol_time = patrol_recovery_time;
        }

        if (patrol_distance < 1f)
        {
            patrol_time = -1f;
        }

        if (interest_time >= 0f)
        {
            interest_time -= Time.deltaTime;
        }
        if (patrol_time >= 0f)
        {
            patrol_time -= Time.deltaTime;
        }

        agent.SetDestination(location);

    }
}
