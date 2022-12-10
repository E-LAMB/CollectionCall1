using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg_Manager : MonoBehaviour
{

    public GameObject leg_FL;
    public GameObject leg_FR;
    public GameObject leg_BL;
    public GameObject leg_BR;

    public float grace = 2f;
    public float timer = 0f;
    public float max_timer = 1f;

    public bool current_state = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (grace > -1f)
        {
            grace -= Time.deltaTime;
        }

        if (grace < 0f)
        {

            if (timer > -1f)
            {
                timer -= Time.deltaTime;
            }

            if (timer < 0f)
            {

                if (current_state)
                {
                    current_state = false;

                    leg_FL.GetComponent<KneesMoving>().set_state(false);
                    leg_FR.GetComponent<KneesMoving>().set_state(true);
                    leg_BL.GetComponent<KneesMoving>().set_state(true);
                    leg_BR.GetComponent<KneesMoving>().set_state(false);

                } else
                {
                    current_state = true;

                    leg_FL.GetComponent<KneesMoving>().set_state(true);
                    leg_FR.GetComponent<KneesMoving>().set_state(false);
                    leg_BL.GetComponent<KneesMoving>().set_state(false);
                    leg_BR.GetComponent<KneesMoving>().set_state(true);

                }

                timer = max_timer;

            }
        }




    }
}
