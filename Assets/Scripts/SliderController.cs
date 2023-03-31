using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SliderController : MonoBehaviour
{
    public Transform controllerTransform;
    public float sliderMinValue = 0.0f;
    public float sliderMaxValue = 7.0f;
    public float sliderStep = 0.1f;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    private float sliderValue = 0.0f;
    private float previousSliderValue = 0.0f;
    private bool triggerPressed = false;

    void Update()
    {
        // Get the position of the controller in world space
        Vector3 controllerPosition = controllerTransform.position;

        // Convert the controller position to a slider value between 0 and 1
        sliderValue = Mathf.Clamp01((controllerPosition.x - transform.position.x) / (sliderMaxValue - sliderMinValue));

        // Snap the slider value to the nearest step
        sliderValue = Mathf.Round(sliderValue / sliderStep) * sliderStep;

        // Update the slider position
        transform.localPosition = new Vector3(sliderValue * (sliderMaxValue - sliderMinValue), 0, 0);

        // Check if the trigger button is pressed
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        bool triggerValue = false;
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            // Check if the trigger button was just pressed this frame
            if (!triggerPressed)
            {
                // Play a sound based on the current slider position
                int clipIndex = Mathf.RoundToInt(sliderValue / sliderStep);
                if (clipIndex >= 0 && clipIndex < audioClips.Length)
                {
                    audioSource.PlayOneShot(audioClips[clipIndex]);
                }
            }
            triggerPressed = true;
        }
        else
        {
            triggerPressed = false;
        }

        // Check if the slider value has changed
        if (sliderValue != previousSliderValue)
        {
            // TODO: Do something when the slider value changes

            previousSliderValue = sliderValue;
        }
    }
}
