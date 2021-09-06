using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFireballAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Transform fireballSpawnPoint;
    [SerializeField] private GameObject fireballPrefab;

    private FireballController newFireballController;

    private void Awake()
    {
        playerInputManager.SubscribeToInputActionEvent("Fireball", OnFireballCast);
    }

    public void OnFireballCast(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            playerAnimator.SetTrigger("FireballCast");
        }
    }

    public void SpawnFireball()
    {
        GameObject newFireball = GameObject.Instantiate(fireballPrefab);
        newFireball.transform.position = fireballSpawnPoint.position;

        newFireballController = newFireball.GetComponent<FireballController>();
        newFireballController.InitializeFireball(new Vector2(1, 0), 20);
        newFireballController.LetFireballGo();
    }
}
