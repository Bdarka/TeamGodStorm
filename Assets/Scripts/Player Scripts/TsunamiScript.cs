using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TsunamiScript : MonoBehaviour
{
    public PlayerController playerController;

    // Physics variables
    public Rigidbody rb;
    public float moveSpeed;
    public float waveSpeed;
    public Vector3 movement;

    public SphereCollider waveCollider;
    public bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        rb = playerController.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            WaveCrash();
        }
    }

    public void FixedUpdate()
    {
        if(isAttacking == true)
        {
            rb.velocity = movement * (moveSpeed * waveSpeed) * Time.fixedDeltaTime;
            isAttacking = false;
        }

        else
        {
            rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
        }
        
    }

    public void WaveCrash()
    {
        waveCollider.enabled = true;
        isAttacking = true;

        playerController.sFXManager.PlaySFX("Water - (GODSTORM)");

        Collider[] colliders = Physics.OverlapSphere(waveCollider.transform.position, waveCollider.radius);
        GameObject prevCollision = null;

        foreach (Collider c in colliders)
        {
            // Debug.Log("Hit Building" + c.gameObject.name);
            BuildingScript b = c.gameObject.GetComponent<BuildingScript>();
            if (b != null && c.gameObject != prevCollision)
            {
                b.TakeDamage("Tsunami");
            }
            prevCollision = c.gameObject;
        }

        waveCollider.enabled = false;
    }
}
