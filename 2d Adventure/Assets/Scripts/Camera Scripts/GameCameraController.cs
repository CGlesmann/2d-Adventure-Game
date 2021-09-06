using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Vector3 offset;
    [SerializeField] private float cameraFollowSpeed;

    private static Transform playerTransform;
    private Vector3 cameraOrigin;

    private void Start()
    {
        if (playerTransform == null) { playerTransform = GameObject.FindObjectOfType<PlayerMovement>().transform; }
        if (playerTransform == null)
        {
            Debug.LogError("Couldn't find a player target for the Game Camera");
            return;
        }

        cameraOrigin = transform.position;
    }

    private void Update()
    {
        if (cameraFollowSpeed > 0)
        {
            if (playerTransform == null) { return; }

            transform.position = Vector3.Lerp(transform.position, playerTransform.position + offset, cameraFollowSpeed * Time.deltaTime);
            return;
        }
    }
}
