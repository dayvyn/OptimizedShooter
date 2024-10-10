using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
    public static readonly int IsWalking = Animator.StringToHash("IsWalking");

    private Vector3 movement;
	private Animator anim;
	private Rigidbody playerRigidbody;
	private int floorMask;
	private float camRayLength = 100f;
	private Transform playerTransform;

	void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
		playerTransform = GetComponent<Transform>();
        IA_PlayerControls1.playerControls.Player.Move.Enable();
    }

    private void OnDisable()
    {
        IA_PlayerControls1.playerControls.Player.Move.Disable();
    }

    void FixedUpdate()
	{
		PlayerInput(IA_PlayerControls1.playerControls.Player.Move.ReadValue<Vector2>());
        Turning();
	}

	void Move(float h, float v)
	{
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition(playerTransform.position + movement);
	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - playerTransform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;

		anim.SetBool(IsWalking, walking);
	}

	public void PlayerInput(Vector2 movementVector)
	{
		float x = movementVector.x;
		float y = movementVector.y;
		Move(x, y);
		Animating(x, y);
    }
}
