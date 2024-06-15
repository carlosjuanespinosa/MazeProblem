using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
        private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CharacterController cc;
     public Inventari inventari;
     public PlayerInputHandler inputActions;
    public PlayerInputHandlerChooseItems playerInputHandlerChoose;
    [SerializeField] public LookController lookController;
    public ChoosenItem choosenItem;
    public Vector2 moveDir;
    [SerializeField] private float moveVel;

    [SerializeField] private GameObject objecteInteractuable;

    [SerializeField] public GameObject cameraPersonatge;
    [SerializeField] public GameObject cameraInventari;

    [SerializeField] public RawImage cursor;
    [SerializeField] private Texture textureNormal;

    [SerializeField] public GameObject lastInteractableObject;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        inventari = GetComponent<Inventari>();
        inputActions = GetComponent<PlayerInputHandler>();
        playerInputHandlerChoose = GetComponent<PlayerInputHandlerChooseItems>();
        lookController = GetComponent<LookController>();
        choosenItem = GetComponent<ChoosenItem>();

        animator = GetComponentInChildren<Animator>();

        inputActions.enabled = true;
        playerInputHandlerChoose.enabled = false;
        lookController.enabled = true;
        choosenItem.enabled = false;

        cameraPersonatge.SetActive(true);
        cameraInventari.SetActive(false);

        cursor.texture = textureNormal;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //    transform.position -= Physics.gravity;

        MoveRigidbody();
        //MoveCC();

        AnimatorBlendController();

        ShowKeyToInteract();
    }

    private void MoveRigidbody()
    {
        Vector3 movement = transform.forward * moveDir.y + transform.right * moveDir.x;
        movement *= moveVel;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
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
            animator.SetFloat("MoveX", 1, .1f, Time.fixedDeltaTime);
            animator.SetFloat("MoveY", moveDir.y, .1f, Time.fixedDeltaTime);
        }
        else if (moveDir == new Vector2(-.707107f, -.707107f))
        {
            animator.SetFloat("MoveX",  -1, .1f, Time.fixedDeltaTime);
            animator.SetFloat("MoveY", moveDir.y, .1f, Time.fixedDeltaTime);
        }
        else
        {
            animator.SetFloat("MoveX", moveDir.x, .1f, Time.fixedDeltaTime);
            animator.SetFloat("MoveY", moveDir.y, .1f, Time.fixedDeltaTime);
        }
    }

    private void ShowKeyToInteract()
    {
        int maskInt = LayerMask.GetMask("Interactuable");
        Ray cameraRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 1f));
        if (Physics.Raycast(cameraRay, out RaycastHit raycastHit, 5f, maskInt))
        {
            if (raycastHit.transform.TryGetComponent(out ObjectId objectId))
            {
                cursor.texture = objectId.textureNormal;
            }
            else if (raycastHit.transform.TryGetComponent(out ObjecteFinal objecteFinal))
            {
                cursor.texture = objecteFinal.textureNormal;
            }
            else
            {
                cursor.texture = textureNormal;
            }
        }
        else
        {
            cursor.texture = textureNormal;
        }
    }

    public void Interact()
    {
        int maskInt = LayerMask.GetMask("Interactuable");
        Ray cameraRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 1f));
        if (Physics.Raycast(cameraRay, out RaycastHit raycastHit, 3f, maskInt))
        {
            if (raycastHit.transform.TryGetComponent(out ObjecteFinal interactableObject))
            {
                inventari.LlistarObjectes();
                inventari.llista.SetActive(true);
                choosenItem.objecteInteractuable = interactableObject;
                inputActions.enabled = false;
                playerInputHandlerChoose.enabled = true;
                lookController.enabled = false;
                choosenItem.enabled = true;
                cameraPersonatge.SetActive(false);
                cameraInventari.SetActive(true);
                cursor.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                GetComponent<Inventari>().Agafar(raycastHit.transform.gameObject);
            }
        }
    }
}
