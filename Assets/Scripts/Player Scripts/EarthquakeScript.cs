using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeScript : MonoBehaviour
{
    public PlayerController playerController;
    public Animator animator;

    // Physics variables
    public Rigidbody rb;
    public float moveSpeed;
    public Vector3 movement;

    public SphereCollider tremorCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = playerController.GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Tremor();
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
    }

    public void Tremor()
    {
        tremorCollider.enabled = true;

        Collider[] colliders = Physics.OverlapSphere(tremorCollider.transform.position, tremorCollider.radius);
        GameObject prevCollision = null;

        foreach(Collider c in colliders)
        {
            Debug.Log("Hit Building" +  c.gameObject.name);
            BuildingScript b = c.gameObject.GetComponent<BuildingScript>();
            if(b != null && c.gameObject != prevCollision)
            {
                b.TakeDamage("Earthquake");
            }
            prevCollision = c.gameObject;
        }
        tremorCollider.enabled = false;
    }



    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            rb.useGravity = false;
        }
    }
}
