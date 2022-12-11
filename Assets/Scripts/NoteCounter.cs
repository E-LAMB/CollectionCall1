using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCounter : MonoBehaviour
{

    public int notes = 0;

    public void GotNote()
    {
        notes += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
