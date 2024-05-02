using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Read : MonoBehaviour
{
    public GameObject player;
    public GameObject note;
    public GameObject pickUpTxt;
    public AudioSource pickupSound;
    public bool inReach;
    // Start is called before the first frame update
    void Start()
    {
        note.SetActive(false);
        pickUpTxt.SetActive(false);
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpTxt.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpTxt.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(inReach && Input.GetButtonDown("Interact"))
        {
            note.SetActive(true);
            pickupSound.Play();
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ExitButton()
    {
        note.SetActive(false);
        player.GetComponent<FirstPersonController>().enabled = true;
    }
}
