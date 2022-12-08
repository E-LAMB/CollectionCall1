using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] selection;
    public int selected_enemy;
    public GameObject summonable;
    public Transform self;

    // Start is called before the first frame update
    void Start()
    {
        int selection_length = selection.Length;
        selected_enemy = Random.Range(0,selection_length);
        summonable = selection[selected_enemy];
        Instantiate(summonable, self.position, self.rotation);
    }

}
