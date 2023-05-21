using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExample : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter()
    {
        print("OnTriggerEnter");
    }

    void OnTriggerStay()
    {
        print("OnTriggerStay");
    }

    void OnTriggerExit()
    {
        print("OnTriggerExit");
    }
}
