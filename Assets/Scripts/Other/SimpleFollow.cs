using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    public GameObject TargetGameObject;

    private void FixedUpdate()
    {
        gameObject.transform.position = TargetGameObject.transform.position;
    }
}
