using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    public bool interactable = false;
    public bool isOpen = false;


    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // On est déjà sur le script du coffre donc pas besoin de chercher plus d'objets


    }

    // Update is called once per frame
    void Update()
    {
        if (interactable == true && Input.GetKeyDown(KeyCode.Space))
        {
           
            anim.SetBool("isOpen", true); // Permet de changer des choses dans les paramètres

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = false;
        }
    }
}
