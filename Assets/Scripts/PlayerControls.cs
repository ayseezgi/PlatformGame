using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Vector3 playerVelocity;
    [SerializeField] bool groundedPlayer;
    [SerializeField] float gravityValue;
    [SerializeField] GameObject activeChar;
    [SerializeField] float speed = 4f;
    [SerializeField] float rotateSpeed = 200f;
    [SerializeField] bool isJumping;

    public float GetVerticalSpeed()
    {
        return playerVelocity.y;
    }

    public void Bounce(float force)
    {
        playerVelocity.y = 0f;
        playerVelocity.y = force;
        isJumping = true;
    }

    public float GetFallSpeed()
    {
        return Mathf.Abs(playerVelocity.y);
    }

    void Start()
    {
        gravityValue = -20f;

        if (controller == null)
        {
            controller = GetComponent<CharacterController>();
        }
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
            isJumping = false;
        }

        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(0f, mouseX * 500f * Time.deltaTime, 0f);
        }

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 move = (forward * vertical + right * horizontal) * speed;
        controller.SimpleMove(move);

        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            isJumping = true;
            activeChar.GetComponent<Animator>().Play("Jump");
            playerVelocity.y = 10f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (Mathf.Abs(vertical) > 0.1f || Mathf.Abs(horizontal) > 0.1f)
        {
            if (!isJumping)
            {
                activeChar.GetComponent<Animator>().Play("Running");
            }
        }
        else
        {
            if (!isJumping)
            {
                activeChar.GetComponent<Animator>().Play("Idle");
            }
        }
    }
}


