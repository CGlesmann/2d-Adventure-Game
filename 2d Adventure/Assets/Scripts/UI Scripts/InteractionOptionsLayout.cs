using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionOptionsLayout : MonoBehaviour
{
    [Header("Layout Options")]
    [SerializeField] private float topOffset;
    [SerializeField] private float verticalSpacing;

    private void OnEnable() 
    {
        OrganizeLayout();
    }

    // private void OnTransformChildrenChanged() 
    // {
    //     OrganizeLayout();
    // }

    private void OrganizeLayout()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform targetTransform = transform.GetChild(i);
            float targetPosition = topOffset + (verticalSpacing * i);
            
            targetTransform.localPosition = new Vector3(targetTransform.localPosition.x, targetPosition, 0f);
            Debug.Log(targetPosition);
        }
    }
}
