using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MovementController : MonoBehaviour
{
    [Header("Collision Settings")]
    [SerializeField] private LayerMask layersToCheckAgaisnt;
    [SerializeField] private int horizontalCollisionCheckCount = 5;
    [SerializeField] private int verticalCollisionCheckCount = 5;
    [SerializeField] private float buffer = 0.01f;
    private Collider2D targetTransformCollider;

    public void Move(Transform transformToMove, Vector2 moveSpeed)
    {
        targetTransformCollider = transformToMove.GetComponent<Collider2D>();

        if (CheckForCollision(transformToMove.position, moveSpeed))
        {
            return;
        }

        transformToMove.position += new Vector3(moveSpeed.x, moveSpeed.y, transformToMove.position.z);
        return;
    }

    public bool CheckForCollision(Vector2 position, Vector2 moveSpeed)
    {
        return ((moveSpeed.x != 0f && CheckHorizontalCollision(position, moveSpeed)) || (moveSpeed.y != 0f && CheckVerticalCollision(position, moveSpeed)));
    }

    public bool CheckHorizontalCollision(Vector2 position, Vector2 moveSpeed)
    {
        float horizontalPoint = (moveSpeed.x > 0) ? targetTransformCollider.bounds.max.x : targetTransformCollider.bounds.min.x;
        Vector3 startPoint = new Vector3(horizontalPoint, targetTransformCollider.bounds.max.y - buffer);
        Vector3 iterationValue = new Vector3(0f, (((targetTransformCollider.bounds.min.y + buffer) - (targetTransformCollider.bounds.max.y - buffer))) / (horizontalCollisionCheckCount - 1));

        for (int i = 0; i < horizontalCollisionCheckCount; i++)
        {
            Vector3 rayOrigin = startPoint + (iterationValue * i);
            RaycastHit2D raycastResult = Physics2D.Raycast(rayOrigin, moveSpeed.normalized, moveSpeed.magnitude, layersToCheckAgaisnt);

            //Debug.DrawRay(rayOrigin, moveSpeed.normalized, Color.black, 3f);

            if (raycastResult.collider != null)
            {
                return true;
            }
        }

        return false;
    }

    public bool CheckVerticalCollision(Vector2 position, Vector2 moveSpeed)
    {
        float verticalPoint = (moveSpeed.y > 0) ? targetTransformCollider.bounds.max.y : targetTransformCollider.bounds.min.y;
        Vector3 startPoint = new Vector3(targetTransformCollider.bounds.max.x - buffer, verticalPoint);
        Vector3 iterationValue = new Vector3(((targetTransformCollider.bounds.min.x + buffer) - (targetTransformCollider.bounds.max.x - buffer)) / (verticalCollisionCheckCount - 1), 0f);

        for (int i = 0; i < verticalCollisionCheckCount; i++)
        {
            Vector3 rayOrigin = startPoint + (iterationValue * i);
            RaycastHit2D raycastResult = Physics2D.Raycast(rayOrigin, moveSpeed.normalized, moveSpeed.magnitude, layersToCheckAgaisnt);

            //Debug.DrawRay(rayOrigin, moveSpeed.normalized, Color.black, 3f);

            if (raycastResult.collider != null)
            {
                return true;
            }
        }

        return false;
    }
}
