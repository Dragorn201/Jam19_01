using System;
using UnityEngine;

public class TimelineDirector : MonoBehaviour
{
    //Internal
    private bool Mission2Started = false;
    
    //External
    public GameObject MariaStart;
    public GameObject MariaMission2;
    public EventDirector EventDirector;




    private void Update()
    {
        if (EventDirector.Mission2 && !Mission2Started)
        {
            MariaStart.SetActive(false);
            MariaMission2.SetActive(true);
            Mission2Started = true;
        }
    }
}
