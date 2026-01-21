using System;
using UnityEngine;

public class TimelineDirector : MonoBehaviour
{
    //Internal
    private bool Mission2Started = false;
    private bool Mission5Started = false;
    
    //External
    public GameObject MariaStart;
    public GameObject MariaMission2;
    public GameObject MariaMission3;
    public EventDirector EventDirector;




    private void Update()
    {
        if (EventDirector.Mission2 && !Mission2Started)
        {
            MariaStart.SetActive(false);
            MariaMission2.SetActive(true);
            Mission2Started = true;
        }

        if (EventDirector.Mission5 && !Mission5Started)
        {
            MariaMission2.SetActive(false);
            MariaMission3.SetActive(true);
            Mission5Started = true;
        }
    }
}
