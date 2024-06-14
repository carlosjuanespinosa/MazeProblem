using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private Rigidbody rb;
    public Vector2 moveDir;
    [SerializeField] private float moveVel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();

        AnimatorBlendController();
    }

    private void Move()
    {
        Vector3 _moveDir = transform.forward * moveDir.y + transform.right * moveDir.x;

        rb.velocity = _moveDir * moveVel * Time.fixedDeltaTime;
    }

    private void AnimatorBlendController()
    {
        if (moveDir == Vector2.zero)
        {
            //animator.SetBool("Walk", false);
            animator.SetFloat("MoveX", moveDir.x, .1f, Time.fixedDeltaTime);
            animator.SetFloat("MoveY", moveDir.y, .1f, Time.fixedDeltaTime);
        }
        else if (moveDir == new Vector2(.707107f, -.707107f))
        {
            animator.SetFloat("MoveX", -1, .1f, Time.fixedDeltaTime);
            animator.SetFloat("MoveY", moveDir.y, .1f, Time.fixedDeltaTime);
        }
        else if (moveDir == new Vector2(-.707107f, -.707107f))
        {
            animator.SetFloat("MoveX",  1, .1f, Time.fixedDeltaTime);
            animator.SetFloat("MoveY", moveDir.y, .1f, Time.fixedDeltaTime);
        }
        else
        {
            animator.SetFloat("MoveX", moveDir.x, .1f, Time.fixedDeltaTime);
            animator.SetFloat("MoveY", moveDir.y, .1f, Time.fixedDeltaTime);
        }
    }
}
