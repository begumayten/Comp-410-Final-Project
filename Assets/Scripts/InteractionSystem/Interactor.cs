using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;




    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, _interactionPointRadius, colliders, _interactableMask);

        if (numFound > 0)
        {
            var interactable = colliders[0].GetComponent<IInteractable>();
            if (interactable != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                bool interactWasSuccessful;
                interactable.Interact(this, out interactWasSuccessful);
                if (interactWasSuccessful)
                {
                    Debug.Log("Interaction was successful");
                }
                else
                {
                    Debug.Log("Interaction failed");
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, _interactionPointRadius);
    }
}