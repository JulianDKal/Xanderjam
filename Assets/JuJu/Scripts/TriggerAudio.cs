using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
        public FMODUnity.EventReference Eventref;
        [FMODUnity.EventRef(MigrateTo ="Eventref")]
        public string Event;
        public bool playOnAwake;
        

        public void PlayOneShot()
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached(Event, gameObject);
        }

        private void Start()
        {

            if (playOnAwake) PlayOneShot();
        }
    

    

}
