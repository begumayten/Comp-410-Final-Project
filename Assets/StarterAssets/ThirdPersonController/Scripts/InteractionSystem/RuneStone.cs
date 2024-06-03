using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneStone : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactionPrompt;

    public string InteractionPrompt => interactionPrompt;

    public bool Interact(Interactor interactor, out bool interactWasSuccessful)
    {
        
        interactWasSuccessful = true;
        Debug.Log("Interacted with the rune stone.");
        return interactWasSuccessful;
    }
}
