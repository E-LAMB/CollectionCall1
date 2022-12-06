using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertEnemy : MonoBehaviour
{

    public GameObject player_tester;
    public LayerMask player_layer;
    public bool player_in_range = false;
    public float player_range = 1f;

    public float cooldown = 0f;
    public Light spotlight;
    public float light_brightness = 10f;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");   
    }

    // Update is called once per frame
    void Update()
    {

        player_in_range = Physics.CheckSphere(player_tester.transform.position, player_range, player_layer);

        if (cooldown > -1f)
        {
            cooldown = cooldown - Time.deltaTime;
        }

        if (cooldown <= 0 && player_in_range == true)
        {
            enemy.GetComponent<EnemyAI>().KnowsLocation(3f);
            cooldown = 10f;
        }

        light_brightness = 2f - cooldown / 5f;
        spotlight.intensity = light_brightness;


    }
}
