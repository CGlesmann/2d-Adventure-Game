using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackCollider))]
public class FireballController : MonoBehaviour
{
    [Header("Fireball Stats")]
    [SerializeField] private float moveSpeed;
    private Transform playerHandPoint;
    private Vector3 moveVector;
    private bool canMove;

    public void SetStickPoint(Transform playerHandPoint)
    {
        this.playerHandPoint = playerHandPoint;
        canMove = false;
    }

    public void InitializeFireball(Vector2 moveVector, float damage)
    {
        this.moveVector = moveVector;

        AttackCollider attackCollider = GetComponent<AttackCollider>();
        attackCollider.InitializeAttackCollider(transform, damage);
        attackCollider.SetAmountOfAttacks(1, 0);
    }

    public void LetFireballGo()
    {
        canMove = true;
    }

    private void Update()
    {
        if (canMove)
        {
            transform.position += moveVector * moveSpeed * Time.deltaTime;
            return;
        }

        if (playerHandPoint != null)
        {
            transform.position = playerHandPoint.position;
        }
    }
}
