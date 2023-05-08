using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidingObjects : MonoBehaviour

{
    public Transform slideObject;
    public float slideDistance = 1f;
    public Vector3 slideAxis = Vector3.right;

    private Vector3 initialSlidePos;

    void Start()
    {
        initialSlidePos = slideObject.localPosition;
    }

    void Update()
    {
        slideObject.localPosition = initialSlidePos + (slideAxis * Mathf.Clamp(Input.GetAxis("Horizontal"), -1f, 1f) * slideDistance);
    }
}

