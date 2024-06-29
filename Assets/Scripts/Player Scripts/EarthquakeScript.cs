using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeScript : MonoBehaviour
{
    public PlayerController playerController;
    public Animator animator;
    public Collider myCollider;
    public SphereCollider attackCollider;

    public float moveSpeed;
    public Vector3 movement;

    public Rigidbody rb;

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

        if(Input.GetKey(KeyCode.LeftShift))
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
        attackCollider.enabled = true;

        Collider[] colliders = Physics.OverlapSphere(attackCollider.transform.position, attackCollider.radius);

        foreach(Collider c in colliders)
        {

            Debug.Log("Hit Building" +  c.gameObject.name);
            BuildingScript b = c.gameObject.GetComponent<BuildingScript>();

            if(b != null)
            {
                if(b.Weakness == BuildingScript.BuildingWeakness.Earthquake)
                {
                    // Hurt the building 
                    b.buildingHealth -= 4;
                }
                else if(b.Resist == BuildingScript.BuildingResist.Earthquake)
                {
                    // Hurt the building, but not as much 
                    b.buildingHealth -= 2;
                }   
                else
                {
                    b.buildingHealth -= 3;
                }
            }
        }
    }



    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            rb.useGravity = false;
        }
    }
}
