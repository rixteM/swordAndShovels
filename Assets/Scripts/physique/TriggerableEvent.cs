using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableEvent : MonoBehaviour
{
    public GameObject[] destructors;
    //private Rigidbody[] rbs;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foreach (GameObject destructor in destructors)
            {
                destructor.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
