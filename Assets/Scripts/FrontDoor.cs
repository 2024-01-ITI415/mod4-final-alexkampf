using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoor : MonoBehaviour
{

    public GameObject text;
    public GameObject inv;
    public AudioSource doorSound;
    public AudioSource lockedSound;
    public bool inReach;
    public bool locked;
    public bool unlocked;
    public bool key;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        key = false;
        unlocked = false;
        locked = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            text.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(inv.activeInHierarchy)
        {
            locked = false;
            key = true;
        }
        else
        {
            key = false;
        }

        if (key && inReach && Input.GetButtonDown("Interact"))
        {
            unlocked = true;
            DoorOpens();
        }
  

        if(locked && inReach && Input.GetButtonDown("Interact"))
        {
            lockedSound.Play();
        }
    }

    void DoorOpens()
    {
        doorSound.Play();
        //fadeout goes here?
    }

    
}
