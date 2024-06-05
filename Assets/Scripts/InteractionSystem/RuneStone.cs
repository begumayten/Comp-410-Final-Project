using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RuneStone : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactionPrompt;

    private GameObject textChangerObject;
    private ControlText controlText;
    private int runeIndex;

    void Start()
    {
        textChangerObject = GameObject.Find("Control");
        if (textChangerObject != null)
        {
            controlText = textChangerObject.GetComponent<ControlText>();
            if (controlText == null)
            {
                Debug.LogError("ControlText component not found on the Control GameObject.");
            }
        }
        else
        {
            Debug.LogError("Control GameObject not found.");
        }
    }




    public string InteractionPrompt => interactionPrompt;

    public bool Interact(Interactor interactor, out bool interactWasSuccessful)
    {
        
        interactWasSuccessful = true;

        Debug.Log("Interacted with the rune stone.");
        if (controlText != null)
        {
            controlText.UpdateText(runeIndex);
        }
        else
        {
            Debug.LogError("ControlText component is not assigned.");
            interactWasSuccessful = false;
        }

        return interactWasSuccessful;
    }

    public void SetRuneIndex(int index)
    {
        runeIndex = index;
    }


}

