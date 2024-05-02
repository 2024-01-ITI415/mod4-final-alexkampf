using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;


public class FrontDoor : MonoBehaviour
{

    public GameObject player;
    public GameObject text;
    public GameObject inv;
    public GameObject gameOverScreen;
    public AudioSource doorSound;
    public AudioSource lockedSound;
    public bool inReach;
    public bool locked;
    public bool unlocked;
    public bool key;


    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
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
        gameOverScreen.SetActive(true);
        player.GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Main");
    }


}
