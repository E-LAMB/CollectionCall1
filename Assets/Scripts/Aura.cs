using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Aura : MonoBehaviour
{

    public MeshRenderer my_renderer;
    public static bool should_reveal;

    public PostProcessVolume volume_using;
    public AutoExposure usingAE;

    public bool player_aura = false;

    // Start is called before the first frame update
    void Start()
    {
        if (player_aura == true)
        {
            volume_using.profile.TryGetSettings(out usingAE);
        }
    }

    public void switch_state()
    {
        should_reveal = !should_reveal;
    }

    // Update is called once per frame
    void Update()
    {

        if (player_aura == false)
        {

            if (should_reveal)
            {
                my_renderer.enabled = true;
            } else
            {
                my_renderer.enabled = false;
            }


        }else
        {
            if (should_reveal)
            {
                usingAE.active = true;
            } else
            {
                usingAE.active = false;
            }

        }



    }
}
