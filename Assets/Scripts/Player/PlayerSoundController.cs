using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioSource heart;
    public AudioSource breath;

    // Start is called before the first frame update
    void Start()
    {
        updateAudio(0,5);
    }

    public void updateAudio(float hp, float maxhp)
    {
        if(hp<=0)
        {
            heart.volume=0;
            breath.volume=0;
        }
        else
        {
            //formula new_volume = base_volume + (1 - current_health/max_health) * max_volume_change
            heart.volume= 0.2f+(1-(hp/maxhp))*0.75f;
            heart.pitch= 0.8f+(1-(hp/maxhp))*0.7f;
            breath.volume= 0.4f+(1-(hp/maxhp))*0.63f;
            Debug.Log((hp/maxhp));
        }
        /*
        heart 1v 1.35p
        breathing 0.9v 1p

        heart 0.5v 0.8p
        breathing 0.5v 1p
        */

    }
}
