using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SlideObject : MonoBehaviour
{
    public XRGrabInteractable bodyObject;
    public XRGrabInteractable slideObject;

    private Vector3 lastBodyObjectPosition;
    private Vector3 lastSlideObjectPosition;

    private void Start()
    {
        lastBodyObjectPosition = bodyObject.transform.position;
        lastSlideObjectPosition = slideObject.transform.position;
    }

    private void FixedUpdate()
    {
        // Calculate the movement of the body and slide objects
        Vector3 bodyMovement = bodyObject.transform.position - lastBodyObjectPosition;
        Vector3 slideMovement = slideObject.transform.position - lastSlideObjectPosition;

        // Project the movement vector onto the slide axis
        Vector3 slideMovementProjected = Vector3.Project(slideMovement, slideObject.transform.forward);

        // Apply the slide movement to the slide object
        slideObject.transform.position += slideMovementProjected;

        lastBodyObjectPosition = bodyObject.transform.position;
        lastSlideObjectPosition = slideObject.transform.position;
    }
}
