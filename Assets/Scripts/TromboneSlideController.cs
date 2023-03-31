using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TromboneSlideController : MonoBehaviour
{
    private InputDevice tromboneDevice;

    // The ID of the input feature that controls the slide
    private const string slideFeatureId = "TromboneSlide";

    // The current value of the slide input feature
    private float slideValue;

    // The minimum and maximum slide positions
    private const float minSlidePosition = 0f;
    private const float maxSlidePosition = 1f;

    // The initial position of the slide
    private Vector3 initialSlidePosition;

    // The transform of the slide
    public Transform slideTransform;

    private void Start()
    {
        // Get the input device that controls the trombone
        tromboneDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        // Get the initial position of the slide
        initialSlidePosition = slideTransform.localPosition;
    }

    private void Update()
    {
        // Get the value of the slide input feature
        tromboneDevice.TryGetFeatureValue(new InputFeatureUsage<float>(slideFeatureId), out slideValue);

        // Map the slide value to the slide position
        float slidePosition = Mathf.Lerp(minSlidePosition, maxSlidePosition, slideValue);

        // Set the position of the slide
        slideTransform.localPosition = Vector3.Lerp(initialSlidePosition, Vector3.zero, slidePosition);
    }
}

