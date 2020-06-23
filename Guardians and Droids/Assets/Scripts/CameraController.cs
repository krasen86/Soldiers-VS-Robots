using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    [SerializeField] private GameObject player;
	private float cameraMovementFactor;
    private Vector3 offset;
	[SerializeField] private Vector2 maxCamera;
	[SerializeField] private Vector2 minCamera;

    void Start()
    {
        cameraMovementFactor = 0.2f;
    }


    void LateUpdate()
    {
        if(transform.position != player.transform.position)
		{
			offset = new Vector3(player.transform.position.x, player.transform.position.y ,transform.position.z);
			offset.x = Mathf.Clamp(offset.x, minCamera.x, maxCamera.x);
			offset.y = Mathf.Clamp(offset.y, minCamera.y, maxCamera.y);

			transform.position = Vector3.Lerp(transform.position, offset, cameraMovementFactor);
		}
    }
}
