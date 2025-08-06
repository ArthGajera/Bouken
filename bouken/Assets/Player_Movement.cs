using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
       
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+moveInput*speed*Time.fixedDeltaTime);

        animator.SetFloat("moveX",moveInput.x);
        animator.SetFloat("moveY", moveInput.y);
        animator.SetBool("isMoving",moveInput != Vector2.zero);

        if (moveInput.x != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveInput.x)*2.5f, 2.5f, 1f);
    }
}
