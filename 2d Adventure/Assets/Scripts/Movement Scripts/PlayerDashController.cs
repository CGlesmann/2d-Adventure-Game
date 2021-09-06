using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDashController : MonoBehaviour
{
    [Header("Dash Settings")]
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashMotionTrailSpawnDelay;
    [SerializeField] private float dashMotionLifeTime;
    [SerializeField] private float dashCooldown;
    [SerializeField] private GameObject dashMotionTrailObject;

    private bool dashing = false;
    private float remainingCooldown = 0;

    private PlayerCombatController playerCombatController;
    private PlayerInputManager playerInputManager;
    private PlayerMovement playerMovement;
    private MovementController movementController;
    private Animator animator;
    private Vector3 dashDirection;

    private void Awake()
    {
        playerCombatController = GetComponent<PlayerCombatController>();
        animator = GetComponent<Animator>();
        playerInputManager = GetComponent<PlayerInputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        movementController = GetComponent<MovementController>();

        EnableDash();
    }

    private void Update()
    {
        if (remainingCooldown > 0) { remainingCooldown -= Time.deltaTime; }
        if (dashing)
        {
            movementController.Move(transform, dashDirection * dashSpeed * Time.deltaTime);
        }
    }

    public void EnableDash() { playerInputManager.SubscribeToInputActionEvent("Dash", OnDash); }

    public void DisableDash() { playerInputManager.UnsubscribeToInputActionEvent("Dash", OnDash); }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (animator == null || dashing || remainingCooldown > 0 || playerMovement.currentInputMoveSpeed == Vector2.zero) { return; }

        dashing = true;
        animator.SetBool("Dashing", true);

        //playerMovement.moveSpeed *= dashMult;
        dashDirection = playerMovement.currentInputMoveSpeed;
        playerMovement.PauseMovement();
        remainingCooldown = dashCooldown;

        playerCombatController.BeginTimedInvulnerabilityPeriod(dashTime);
        StartCoroutine(Dashing());
    }

    private IEnumerator Dashing()
    {
        float remainingTime = dashTime;
        while (remainingTime > 0)
        {
            //transform.position += dashDirection * dashSpeed * dashMotionTrailSpawnDelay; // * Time.deltaTime;
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
        //playerMovement.moveSpeed /= dashMult;
        playerMovement.UnpauseMovement();
        dashing = false;
    }
}
