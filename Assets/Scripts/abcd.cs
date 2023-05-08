using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class abcd : MonoBehaviour

{
    public XRGrabInteractable leftObject; // Reference to the "left" object with XR Grab Interactable component.
    public XRGrabInteractable rightObject; // Reference to the "right" object with XR Grab Interactable component.

    private ConfigurableJoint joint; // Joint component to connect the objects.

    private void Start()
    {
        joint = gameObject.AddComponent<ConfigurableJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = rightObject.GetComponent<Rigidbody>();
        joint.anchor = Vector3.zero;
        joint.connectedAnchor = Vector3.zero;
        joint.xMotion = ConfigurableJointMotion.Locked;
        joint.yMotion = ConfigurableJointMotion.Locked;
        joint.zMotion = ConfigurableJointMotion.Locked;

        leftObject.onSelectEntered.AddListener(ConnectObjects);
        leftObject.onSelectExited.AddListener(DisconnectObjects);
    }

    private void OnDestroy()
    {
        leftObject.onSelectEntered.RemoveListener(ConnectObjects);
        leftObject.onSelectExited.RemoveListener(DisconnectObjects);
    }

    private void ConnectObjects(XRBaseInteractor interactor)
    {
        joint.connectedBody = rightObject.GetComponent<Rigidbody>();
    }

    private void DisconnectObjects(XRBaseInteractor interactor)
    {
        joint.connectedBody = null;
    }
}
