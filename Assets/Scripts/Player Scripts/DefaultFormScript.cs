using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;



public class DefaultFormScript : MonoBehaviour
{
    // Physics Components
    [HideInInspector] public Rigidbody rb;
    [SerializeField] private DialogueUI dialogueUI;

    // Movement Components
    public PlayerController playerController;
    public Collider myCollider;
    public Vector3 movement;
    public float moveSpeed;

    // Dialogue System
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable {get; set;}
    public bool canPressSpace;
    public SphereCollider canITalk;

    // Visual Components
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = playerController.GetComponent<Rigidbody>();
        rb.useGravity = false;

        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, (Input.GetAxisRaw("Vertical")));
        if(Input.GetAxisRaw("Horizontal") == (Input.GetAxisRaw("Vertical")))
        {
            movement = new Vector3(0f, 0f, 0f);
        }

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

        if(Input.GetKeyDown(KeyCode.F)){

            Interactable?.Ineract(this);
        }

        #region Set Animator Booleans
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetBool("WalkDown", true);
            animator.SetBool("WalkUp", false);
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkRight", false);
        }
        else if (Input.GetAxisRaw("Vertical") == 1)
        {
            animator.SetBool("WalkDown", false);
            animator.SetBool("WalkUp", true);
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkRight", false);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            animator.SetBool("WalkDown", false);
            animator.SetBool("WalkUp", false);
            animator.SetBool("WalkLeft", true);
            animator.SetBool("WalkRight", false);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            animator.SetBool("WalkDown", false);
            animator.SetBool("WalkUp", false);
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkRight", true);
        }
        else
        {
            animator.SetBool("WalkDown", false);
            animator.SetBool("WalkUp", false);
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkRight", false);
        }


        #endregion
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;


    }

    public void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
