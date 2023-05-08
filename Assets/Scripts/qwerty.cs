using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class qwerty : MonoBehaviour
{

    public GameObject baseObject;
    public Slider slider;
    public List<SliderRange> ranges;
    public AudioSource audioSource;
    public XRController xrController;

    private SliderRange activeRange;
    private bool primaryButtonPressed = false;

    private void Start()
    {
        xrController = GetComponent<XRController>();
        xrController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonPressed);
        xrController.selectAction.action.performed += OnButtonPress;
        xrController.selectAction.action.canceled += OnButtonRelease;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 controlPosition = transform.position;
        Vector3 basePosition = baseObject.transform.position;
        float distance = Vector3.Distance(controlPosition, basePosition);

        slider.value = distance;
        Debug.Log("Slider Value: " + slider.value);

        foreach (SliderRange range in ranges)
        {
            if (slider.value >= range.min && slider.value <= range.max)
            {
                if (activeRange != range)
                {
                    activeRange = range;
                    Debug.Log("Current Range: " + activeRange.name);
                }
                break;
            }
        }

        // Check for primary button press to play the sound
        if (primaryButtonPressed)
        {
            if (activeRange != null && audioSource.clip != activeRange.soundClip && !audioSource.isPlaying)
            {
                audioSource.clip = activeRange.soundClip;
                audioSource.Play();
            }
        }
    }

    private void OnButtonPress(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        primaryButtonPressed = true;
    }

    private void OnButtonRelease(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        primaryButtonPressed = false;
        audioSource.Stop();
    }
}

