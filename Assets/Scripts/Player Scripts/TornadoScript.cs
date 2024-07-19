using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoScript : MonoBehaviour
{
    public PlayerController playerController;

    // Physics variables
    public float moveSpeed;
    public Rigidbody rb;
    [HideInInspector] public Vector3 movement;

    // I want to make the Tornado occasionally move beyond their control
    public float movementCount;
    private int randRoll;
    private float randMove;

    public SphereCollider vortexCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = playerController.GetComponent<Rigidbody>();
        movementCount = 15;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        movementCount += Time.deltaTime;

        if(movementCount > 2)
        {
            randRoll = Random.Range(0, 100);

            if(randRoll <= 25) 
            {
                randMove = 1.25f;
            }
            else
            {
                randMove = 1;
            }

            movementCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            Vortex();
        }
    }

    public void FixedUpdate()
    {
        rb.velocity = movement * (moveSpeed * randMove) * Time.fixedDeltaTime;
    }

    public void Vortex()
    {
        playerController.sFXManager.PlaySFX("Wind - (GODSTORM)");
        vortexCollider.enabled = true;

        // Checking to see what is in the attack radius and makes sure we don't hit the same object twice
        Collider[] colliders = Physics.OverlapSphere(vortexCollider.transform.position, vortexCollider.radius);
        GameObject prevCollision = null;

        foreach (Collider c in colliders)
        {
           // Debug.Log("Hit Building" + c.gameObject.name);
            BuildingScript b = c.gameObject.GetComponent<BuildingScript>();
            if (b != null && c.gameObject != prevCollision)
            {
                b.TakeDamage("Tornado");
            }
            prevCollision = c.gameObject;
        }

        vortexCollider.enabled = false;
    }
}
