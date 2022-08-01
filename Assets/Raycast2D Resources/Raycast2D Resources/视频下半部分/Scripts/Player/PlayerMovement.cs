using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    private float moveH, moveV;
    public bool canMove=true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
    }

    //Physics Engine / AddForce
    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(moveH*Time.fixedDeltaTime, moveV*Time.fixedDeltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
            
        }
        
    }
}
