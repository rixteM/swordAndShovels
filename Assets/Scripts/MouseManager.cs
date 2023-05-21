using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MouseManager : MonoBehaviour
{
    // Know what ojbet are clickable
    public LayerMask clickableLayer;
    //Swap Cursors per object

    public Texture2D pointer; // Normal pointer ( I can click en antthing)
    public Texture2D target; // Curso for clickable objects
    public Texture2D doorway; // Curso for door ways
    public Texture2D combat; // Cursor fot comabt actions

    public EventVector3 OnClickEnvironment;

    

    //// Use this fir initiation
    //void Start() // Initialize the variable
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
        {
            bool door = false;
            bool item = false;

            if (hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }

            else if (hit.collider.gameObject.tag == "Item")
            {
                Cursor.SetCursor(combat, new Vector2(16, 16), CursorMode.Auto);
                item = true;
            }

            else
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (door)
                {
                    Transform doorway = hit.collider.gameObject.transform;

                    OnClickEnvironment.Invoke(doorway.position);
                    Debug.Log("DOOR");
                }

                else if (item)
                {
                    Transform itemPos = hit.collider.gameObject.transform;

                    OnClickEnvironment.Invoke(itemPos.position);
                    Debug.Log("ITEM");
            }

                else
                {
                    OnClickEnvironment.Invoke(hit.point);
                }

            }
        }
        else
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
        }

    }
}

[System.Serializable]

public class EventVector3 : UnityEvent<Vector3> { }

