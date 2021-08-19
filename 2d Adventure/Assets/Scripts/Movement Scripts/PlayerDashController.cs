using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDashController : MonoBehaviour
{
    [Header("Dash Settings")]
    [SerializeField] private float dashTime;
    [SerializeField] private float dashMult;
    [SerializeField] private float dashMotionTrailSpawnDelay;
    [SerializeField] private float dashMotionLifeTime;
    [SerializeField] private float dashCooldown;
    [SerializeField] private GameObject dashMotionTrailObject;

    private bool dashing = false;
    private float remainingCooldown = 0;

    private PlayerInputManager playerInputManager;
    private PlayerMovement playerMovement;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerInputManager = GetComponent<PlayerInputManager>();
        playerMovement = GetComponent<PlayerMovement>();

        EnableDash();
    }

    private void Update()
    {
        if (remainingCooldown > 0) { remainingCooldown -= Time.deltaTime; }
    }

    public void EnableDash() { playerInputManager.SubscribeToInputActionEvent("Dash", OnDash); }

    public void DisableDash() { playerInputManager.UnsubscribeToInputActionEvent("Dash", OnDash); }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (animator == null || dashing || remainingCooldown > 0) { return; }

        dashing = true;
        animator.SetBool("Dashing", true);

        playerMovement.moveSpeed *= dashMult;
        remainingCooldown = dashCooldown;

        StartCoroutine(DashTimer());
    }

    private IEnumerator DashTimer()
    {
        float remainingTime = dashTime;
        while (remainingTime > 0)
        {
            remainingTime -= dashMotionTrailSpawnDelay;

            GameObject newTrail = GameObject.Instantiate(dashMotionTrailObject);
            newTrail.transform.position = transform.position;

            Animator dashDuplicateAnimator = newTrail.GetComponent<Animator>();
            dashDuplicateAnimator.SetFloat("Horizontal", playerMovement.currentInputMoveSpeed.x);
            dashDuplicateAnimator.SetFloat("Vertical", playerMovement.currentInputMoveSpeed.y);

            GameObject.Destroy(newTrail, dashMotionLifeTime);

            yield return new WaitForSeconds(dashMotionTrailSpawnDelay);
        }

        animator.SetBool("Dashing", false);
        playerMovement.moveSpeed /= dashMult;
        dashing = false;
    }
}
