using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransitionInteraction : BaseInteraction
{
    [Header("Door Settings")]
    public Transform playerSpawnPoint;
    [SerializeField] protected string targetSceneName;
    public string doorKey;
    public string targetDoorKey;

    private PlayerTransitionManager playerTransitionManager;

    public override void BeginInteraction(GameObject otherInteractor, UnityAction endAction)
    {
        base.BeginInteraction(otherInteractor, endAction);

        playerTransitionManager = otherInteractor.GetComponent<PlayerTransitionManager>();
        SceneTransitionManager.instance.StartSceneTransitionAnimation(EndInteraction);
    }

    public override void EndInteraction()
    {
        playerTransitionManager.InitiateSceneTransition(targetSceneName, targetDoorKey);
        base.EndInteraction();
    }

    public TransitionInfo GetTransitionInfo()
    {
        return new TransitionInfo(
            name: gameObject.name,
            doorKey: doorKey,
            spawnPoint: playerSpawnPoint.position
        );
    }
}
