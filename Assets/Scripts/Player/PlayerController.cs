using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CharacterController cc;
    [SerializeField] private Inventari inventari;
    public Vector2 moveDir;
    [SerializeField] private float moveVel;

    [SerializeField] private GameObject objecteInteractuable;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        inventari = GetComponent<Inventari>();

        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.position -= Physics.gravity;

        //MoveRigidbody();
        MoveCC();

        AnimatorBlendController();
    }

    private void MoveRigidbody()
    {
        Vector3 _moveDir = transform.forward * moveDir.y + transform.right * moveDir.x;

        rb.velocity = _moveDir * moveVel * Time.fixedDeltaTime;
    }

    private void MoveCC()
    {
        Vector3 _moveDir = transform.forward * moveDir.y + transform.right * moveDir.x;

        cc.Move(_moveDir*moveVel*Time.fixedDeltaTime);
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

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Interactuable")) return;
        objecteInteractuable = other.gameObject;
    }

    public void Interact()
    {
        GetComponent<Inventari>().Agafar(objecteInteractuable);
    }


}
