using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{

    public bool interactable = false;
    public bool isOpen = false;

    private Animator anim;

    public Rigidbody coinPrefab;
    public Transform spawner;

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
            isOpen = !isOpen;
            anim.SetBool("openChest", isOpen); // Permet de changer des choses dans les paramètres

            
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

   void GetCoin(Rigidbody coinInstance)
    {
       
        coinInstance = Instantiate(coinPrefab, spawner.position, spawner.rotation) as Rigidbody; //Clones the object original and returns the clone
        coinInstance.AddForce(spawner.up * 100);
    }
            

}
