using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public delegate void OnTransitionManagerInitialized(TransitionInfo[] transitions);
    public delegate void OnSceneTransitionFinish();

    public static SceneTransitionManager instance;
    public static event OnTransitionManagerInitialized onTransitionManagerInitialized;
    public event OnSceneTransitionFinish onSceneTransitionFinish;

    private static Dictionary<string, TransitionInfo[]> transitionObjectsByScene;

    private void OnDestroy() { instance = null; }

    private void Awake()
    {
        instance = this;

        TransitionInfo[] cachedTransitions = GetCachedTransitionsForCurrentScene();
        if (cachedTransitions != null)
        {
            FinishInitialization(cachedTransitions);
            return;
        }

        TransitionInfo[] currentSceneTransitionObjects = QueryForCurrentSceneTransitions();
        if (currentSceneTransitionObjects == null) { Debug.LogWarning("Couldn't find Transitions for current scene"); return; }

        CacheCurrentSceneTransitions(currentSceneTransitionObjects);
        FinishInitialization(currentSceneTransitionObjects);
    }

    private TransitionInfo[] QueryForCurrentSceneTransitions()
    {
        TransitionInteraction[] transitions = GameObject.FindObjectsOfType<TransitionInteraction>();
        TransitionInfo[] transitionInfoObjects = new TransitionInfo[transitions.Length];

        int counter = 0;
        foreach (TransitionInteraction transition in transitions)
        {
            transitionInfoObjects[counter++] = transition.GetTransitionInfo();
        }
        return transitionInfoObjects;
    }

    private TransitionInfo[] GetCachedTransitionsForCurrentScene()
    {
        if (transitionObjectsByScene == null) { return null; }

        if (transitionObjectsByScene.TryGetValue(SceneManager.GetActiveScene().name, out TransitionInfo[] transitions))
        {
            return transitions;
        }

        return null;
    }

    private void CacheCurrentSceneTransitions(TransitionInfo[] transitions)
    {
        if (transitionObjectsByScene == null)
        {
            transitionObjectsByScene = new Dictionary<string, TransitionInfo[]>();
        }

        transitionObjectsByScene.Add(SceneManager.GetActiveScene().name, transitions);
        return;
    }

    private void FinishInitialization(TransitionInfo[] transitions)
    {
        if (onTransitionManagerInitialized != null)
        {
            onTransitionManagerInitialized(transitions);
        }
    }

    public void StartSceneTransitionAnimation(OnSceneTransitionFinish endAction)
    {
        onSceneTransitionFinish += endAction;
        GetComponent<Animator>()?.SetTrigger("Transition");
    }

    public void ExecuteSceneTransitionFinish()
    {
        if (onSceneTransitionFinish != null)
        {
            onSceneTransitionFinish();
        }
    }
}

public struct TransitionInfo
{
    public string name;
    public string doorKey;
    public Vector3 spawnPoint;

    public TransitionInfo(string name, string doorKey, Vector3 spawnPoint)
    {
        this.name = name;
        this.doorKey = doorKey;
        this.spawnPoint = spawnPoint;
    }
}