using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class ControllerScript : MonoBehaviour {
     

	// Use this for initialization
	void Start () {
        InteractionManager.InteractionSourcePressed += InteractionSourcePressed;
        InteractionManager.InteractionSourceDetected += InteractionManager_InteractionSourceDetected;
    }

    private void InteractionManager_InteractionSourceDetected(InteractionSourceDetectedEventArgs obj)
    {
       
    }

    // Update is called once per frame
    void Update () {
        var interactionSourceStates = InteractionManager.GetCurrentReading();
        foreach (var interactionSourceState in interactionSourceStates)
        {
            Debug.Log(interactionSourceState.anyPressed);
        }
    }
    private void InteractionSourcePressed(InteractionSourcePressedEventArgs obj)
    {
        //Debug.Log("here");
    }

}
