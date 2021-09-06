using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D), typeof(KnockbackController))]
public class BaseCombatEntity : MonoBehaviour
{
    [Header("Base Entity References")]
    [SerializeField] protected GameObject centralObjectToDestroy;
    [SerializeField] protected Image healthBarImage;

    [Header("Base Entity Stats")]
    [SerializeField] protected CombatStats combatStats;

    [Header("Damage Taken Settings")]
    [SerializeField] protected SpriteRenderer targetRenderer;
    [SerializeField] protected Color invulnerabilityAnimationColor;
    [SerializeField] protected float invulnerabilityFlashingInterval;

    protected Color baseColor;
    protected Coroutine invulnerabilityFlashingCoroutine;
    protected bool isVulnerable = true;

    protected virtual void Awake() { combatStats.InitializeStats(); }

    public virtual bool IsDefeated() { return combatStats.IsDefeated(); }
    public virtual void OnDefeat() { GameObject.Destroy(centralObjectToDestroy); }

    public virtual void TakeDamage(float damageAmount)
    {
        if (isVulnerable)
        {
            combatStats.TakeDamage(damageAmount);
            if (IsDefeated())
            {
                OnDefeat();
                return;
            }

            UpdateHealthbar();
            BeginTimedInvulnerabilityPeriod(combatStats.damageRecoveryTime);
            BeginDamageAnimation();
        }
    }

    public virtual void UpdateHealthbar()
    {
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = combatStats.remainingHealth / combatStats.entityHealth;
        }
    }

    public virtual void BeginInvulnerabilityPeriod() { isVulnerable = false; }
    public virtual void BeginDamageAnimation() { invulnerabilityFlashingCoroutine = StartCoroutine(BeginInvulnerabilityAnimation()); }

    public virtual void BeginTimedInvulnerabilityPeriod(float invulnerabilityTimePeriod)
    {
        BeginInvulnerabilityPeriod();
        StartCoroutine(InvulnerabilityTimer(invulnerabilityTimePeriod));
    }

    public virtual void EndDamageAnimation()
    {
        if (invulnerabilityFlashingCoroutine != null)
        {
            StopCoroutine(invulnerabilityFlashingCoroutine);
        }
    }

    public virtual void EndInvulnerabilityPeriod()
    {
        isVulnerable = true;

        if (invulnerabilityFlashingCoroutine != null)
        {
            StopCoroutine(invulnerabilityFlashingCoroutine);
            targetRenderer.color = baseColor;
        }
    }

    private IEnumerator BeginInvulnerabilityAnimation()
    {
        baseColor = targetRenderer.color;

        // The coroutine will be stop by a manual StopCoroutine method call 
        while (true)
        {
            if (targetRenderer.color == baseColor) { targetRenderer.color = invulnerabilityAnimationColor; }
            else
            { targetRenderer.color = baseColor; }

            yield return new WaitForSeconds(invulnerabilityFlashingInterval);
        }
    }

    private IEnumerator InvulnerabilityTimer(float invulnerabilityPeriodDuration)
    {
        yield return new WaitForSeconds(invulnerabilityPeriodDuration);
        EndInvulnerabilityPeriod();
    }
}
