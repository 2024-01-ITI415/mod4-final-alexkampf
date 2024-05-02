using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsFlicker : MonoBehaviour
{
    public Light lightObj;
    public AudioSource lightSound;
    public float min;
    public float max;
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(min, max);
    }

    // Update is called once per frame
    void Update()
    {
        lightsFlickering();
    }

    void lightsFlickering()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            lightObj.enabled = !lightObj.enabled;
            timer = Random.Range(min, max);
            lightSound.Play();
        }
    }
}
