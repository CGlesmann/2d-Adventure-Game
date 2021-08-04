using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthController : MonoBehaviour
{
    private void Awake()
    {
        UpdateDepth();
    }

    public void UpdateDepth()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
}
