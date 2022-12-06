using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExposer : MonoBehaviour
{

    public bool is_exposed = false;

    public GameObject patient_1;
    public GameObject patient_2;
    public GameObject patient_3;
    public GameObject patient_4;
    public GameObject patient_5;
    public GameObject patient_6;

    // Update is called once per frame

    public void becomes_exposed()
    {
        is_exposed = true;
    }

    void Update()
    {

        if (is_exposed == true)
        {
            patient_1.GetComponent<EnemyAI_patients>().KnowsLocation(2f);
            patient_2.GetComponent<EnemyAI_patients>().KnowsLocation(2f);
            patient_3.GetComponent<EnemyAI_patients>().KnowsLocation(2f);
            patient_4.GetComponent<EnemyAI_patients>().KnowsLocation(2f);
            patient_5.GetComponent<EnemyAI_patients>().KnowsLocation(2f);
            patient_6.GetComponent<EnemyAI_patients>().KnowsLocation(2f);

            is_exposed = false;
        }

    }
}
