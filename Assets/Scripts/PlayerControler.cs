using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControler : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    public float moveSpeed = 5f;
    private Enemy enemyScript;
    private RaycastHit hit; // Permet de créer une ligne devant le personnage afin de déterminer 
    //s'il y a ou non et a quelle distances des ennemis et savoir l'oriantation du personnage
    private Ray ray;
    public float rayDistance = 4f;
    public CapsuleCollider playerCollider;

    // nouvelles variables
    public float speed = 6f;            //The speed that the player will move.
    public float turnSpeed = 60f;
    public float turnSmoothing = 15f;

    private Vector3 movement;
    private Vector3 turning;
    private Rigidbody playerRigidbody;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        playerCollider = GetComponent<CapsuleCollider>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);

        float moveHotizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHotizontal, 0f, moveVertical);

        transform.Translate(movement * Time.deltaTime * moveSpeed);

        //----------------------------------------

        ray = new Ray(transform.position + new Vector3(0f, playerCollider.center.y, 0f), transform.forward); //Position of the game object (player) in the courant frame
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red); // Permet de voir la direction sur l'écran

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance < rayDistance)
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    print("There is an enemy ahead");
                }
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyScript = collision.gameObject.GetComponent<Enemy>();
            enemyScript.enemyHealth--;
        }
    }
    /*
    void FixedUpdate()
    {
        //Store input axes
        float lh = Input.GetAxisRaw("Horizontal");
        float lv = Input.GetAxisRaw("Vertical");


        Move(lh, lv);

        Animating(lh, lv);
    }

    void Move(float lh, float lv)
    {
        //Move the player
        movement.Set(lh, 0f, lv);

        //movement = Camera.main.transform.TransformDirection(movement);
        movement = movement.normalized * speed * Time.deltaTime;


        playerRigidbody.MovePosition(transform.position + movement);

        if (lh != 0f || lv != 0f)
        {
            Rotating(lh, lv);
        }

    }

    void Rotating(float lh, float lv)
    {
        Vector3 targetDirection = new Vector3(lh, 0f, lv);

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        Quaternion newRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRotation, turnSmoothing * Time.deltaTime);

        GetComponent<Rigidbody>().MoveRotation(newRotation);
    }

    void Animating(float lh, float lv)
    {
        bool running = lh != 0f || lv != 0f;

        anim.SetBool("IsRunning", running);
    }*/
}
