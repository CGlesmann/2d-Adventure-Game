using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackController : MonoBehaviour
{
    [Header("Knockback Settings")]
    [SerializeField] private Transform baseTransform;
    [SerializeField] private float knockbackUpdateDelay;
    [SerializeField] private float knockbackUpdateAmount;

    [Header("Knockback Stats")]
    [SerializeField] private float knockbackResistance;

    private Coroutine currentKnockbackRoutine;
    private Vector3 knockbackForceVector;
    private float currentKnockbackPower;

    public void BeginKnockback(Vector3 collisionPoint, float knockbackAmount)
    {
        if (knockbackResistance >= knockbackAmount) { return; }

        currentKnockbackPower += (knockbackAmount - knockbackResistance);
        knockbackForceVector = (baseTransform.position - collisionPoint).normalized;
        if (currentKnockbackRoutine == null)
        {
            currentKnockbackRoutine = StartCoroutine(KnockbackUpdate());
        }
    }

    private IEnumerator KnockbackUpdate()
    {
        while (currentKnockbackPower > 0f)
        {
            currentKnockbackPower -= knockbackUpdateAmount;
            baseTransform.position += knockbackForceVector * knockbackUpdateAmount;

            yield return new WaitForSeconds(knockbackUpdateDelay);
        }

        currentKnockbackRoutine = null;
        currentKnockbackPower = 0f;
    }
}
