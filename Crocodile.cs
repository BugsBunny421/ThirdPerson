using UnityEngine;

public class Crocodile : MonoBehaviour
{
	public Transform cameraTransform;
	public float moveSpeed = 5f;
	public float rotationSpeed = 5f;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		// Get input axes
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		// Calculate movement direction relative to camera
		Vector3 movementDirection = cameraTransform.forward * verticalInput + cameraTransform.right * horizontalInput;
		movementDirection.y = 0f; // Ignore vertical movement

		// Normalize direction and apply movement speed
		movementDirection.Normalize();
		Vector3 movement = movementDirection * moveSpeed;

		// Apply movement to the rigidbody
		rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

		// Rotate the character to face the movement direction
		if (movementDirection != Vector3.zero)
		{
			Quaternion toRotation = Quaternion.LookRotation(movementDirection);
			transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
		}
	}
}
