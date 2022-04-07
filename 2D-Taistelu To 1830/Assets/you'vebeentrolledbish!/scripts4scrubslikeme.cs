using UnityEngine;
// N. Gin
public class scripts4scrubslikeme : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    public Rigidbody2D myRigidbody2D;

    public CircleCollider2D feet;
    private float horizontalMovement = 0f;
    public int facing = 1;
    
    public LayerMask PoopLMAO;

    public Animator animator;

    helnth healthsoyoudonotdie;


    // Start is called before the first frame update
    void Start()
    {
        healthsoyoudonotdie = GetComponent<helnth>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && feet.IsTouchingLayers(PoopLMAO))
        {
            if (Input.GetButtonDown("Jump") && feet.IsTouchingLayers(PoopLMAO))
            {
                myRigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                animator.SetTrigger("Jump");
            }
            if (feet.IsTouchingLayers(PoopLMAO))
            {
                animator.SetBool("IsTouchingGrass", true);


                animator.SetBool("IsTouchingGrass", false);

            }
        }
    }

    void FixedUpdate()
    {
        if (healthsoyoudonotdie.isHit)
        {
            myRigidbody2D.velocity = new Vector2(horizontalMovement * speed, myRigidbody2D.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        }
    }

}