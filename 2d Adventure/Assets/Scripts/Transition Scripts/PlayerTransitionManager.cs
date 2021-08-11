using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTransitionManager : MonoBehaviour
{
    private static PlayerTransitionManager transitionManager = null;
    private string targetDoorKey = "";

    private void Awake()
    {
        if (transitionManager != null)
        {
            GameObject.Destroy(gameObject);
            return;
        }

        transitionManager = this;
        GameObject.DontDestroyOnLoad(gameObject);
        SceneTransitionManager.onTransitionManagerInitialized += SpawnPlayerAtDoor;

        return;
    }

    public void InitiateSceneTransition(string targetScene, string doorKeyToSpawnAt)
    {
        targetDoorKey = doorKeyToSpawnAt;
        GetComponent<PlayerInteractionManager>().UnsubscribeInteractionAction();

        SceneManager.LoadScene(targetScene, LoadSceneMode.Single);
    }

    public void SpawnPlayerAtDoor(TransitionInfo[] transitions)
    {
        if (transitions == null || transitions.Length == 0)
        {
            Debug.LogError("No transitions were returned from the SceneTransitionManager, can't spawn player");
            return;
        }

        bool isPositionSet = false;
        foreach (TransitionInfo transition in transitions)
        {
            if (transition.doorKey == targetDoorKey)
            {
                if (transition.spawnPoint == null)
                {
                    Debug.LogError($"{transition.name} doesn't have a player spawn point set");
                    return;
                }

                transform.position = transition.spawnPoint;
                isPositionSet = true;
                break;
            }
        }

        if (!isPositionSet)
        {
            Debug.LogError($"Couldn't find a transition with the key {targetDoorKey}");
            return;
        }
    }
}
