using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultFormScript : MonoBehaviour
{
    // Physics Components
    [HideInInspector] public Rigidbody rb;

    public PlayerController playerController;
    public Collider myCollider;
    public Vector3 movement;
    public float moveSpeed;

    public bool canPressSpace;
    public SphereCollider canITalk;

    // Start is called before the first frame update
    void Start()
    {
        rb = playerController.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

        if(Input.GetKeyDown(KeyCode.Space) && canPressSpace == true)
        {
            Collider[] colliders = Physics.OverlapSphere(canITalk.transform.position, canITalk.radius);

            foreach (Collider c in colliders)
            {
                /* NPCScript npc = c.GetComponent<NPCScript>();
                 if(npc != null)
                 {
                    // Start dialog system
                break;
                }   
                */
            }


        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
    }
}
