using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public float smoothing = 5f;

	private Vector3 offset;

	Transform camTransform;

	void Start()
	{
		camTransform = transform;	
		offset = camTransform.position - target.position;
	}

	void FixedUpdate()
	{
		Vector3 targetCamPos = target.position + offset;
        camTransform.position = Vector3.Lerp(camTransform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
