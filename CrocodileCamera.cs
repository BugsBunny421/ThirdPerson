using UnityEngine;

public class CrocodileCamera : MonoBehaviour
{
	public Transform target;
	public float rotationSpeed = 5f;
	public Vector3 offset;
	public float minRotationAngle = -45f;
	public float maxRotationAngle = 45f;

	private float currentRotationAngle = 0f;

	void Start()
	{
	}

	void LateUpdate()
	{
		float horizontalInput = Input.GetAxis("Mouse X");
		float verticalInput = -Input.GetAxis("Mouse Y");

		// Apply horizontal rotation
		Quaternion horizontalRotation = Quaternion.Euler(0f, horizontalInput * rotationSpeed, 0f);
		offset = horizontalRotation * offset;

		// Calculate vertical rotation angle
		currentRotationAngle -= verticalInput * rotationSpeed;
		currentRotationAngle = Mathf.Clamp(currentRotationAngle, minRotationAngle, maxRotationAngle);

		// Apply vertical rotation
		Quaternion verticalRotation = Quaternion.Euler(currentRotationAngle, 0f, 0f);
		Vector3 finalOffset = verticalRotation * offset;

		transform.position = target.position + finalOffset;
		transform.LookAt(target.position);
	}
}
