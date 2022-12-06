using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{

    public MeshRenderer my_renderer;
    public static bool should_reveal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void switch_state()
    {
        should_reveal = !should_reveal;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (should_reveal)
        {
            my_renderer.enabled = true;
        } else
        {
            my_renderer.enabled = false;
        }

    }
}
