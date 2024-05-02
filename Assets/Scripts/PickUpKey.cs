using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{

    public GameObject key;
    public GameObject inv;
    public GameObject pickUpTxt;
    public AudioSource keySound;
    public bool inReach;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        pickUpTxt.SetActive(false);
        inv.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach=true;
            pickUpTxt.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach=false;
            pickUpTxt.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inReach && Input.GetButtonDown("Interact"))
        {
            key.SetActive(false );
            keySound.Play();
            inv.SetActive(true);
            pickUpTxt.SetActive(false);
        }
    }
}
