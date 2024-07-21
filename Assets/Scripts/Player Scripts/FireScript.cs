using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    // 
    public PlayerController playerController;

    // Physics
    public Rigidbody rb;
    public float moveSpeed;
    [HideInInspector] public Vector3 movement;

    // Attack Collider
    public SphereCollider flameCollider;


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

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            FlameOn();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
    }

    public void FlameOn()
    {
        flameCollider.enabled = true;
        playerController.sFXManager.PlaySFX("Fire - (GODSTORM)");

        Collider[] colliders = Physics.OverlapSphere(flameCollider.transform.position, flameCollider.radius);
        GameObject prevCollision = null;

        foreach (Collider c in colliders)
        {
            //  Debug.Log("Hit Building" +  c.gameObject.name);
            BuildingScript b = c.gameObject.GetComponent<BuildingScript>();
            if (b != null && c.gameObject != prevCollision)
            {
                b.TakeDamage("Fire", playerController);
            }
            prevCollision = c.gameObject;
        }
        flameCollider.enabled = false;
    }
}
