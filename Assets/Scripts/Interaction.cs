using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    private Collider2D interactableCollider;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactableCollider != null)
        {
            
            IInteractable interactable = interactableCollider.GetComponent<IInteractable>();

            if (interactable != null)
            {
               
                interactable.Interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            interactableCollider = collision; 
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            interactableCollider = null; 
        }
    }
}
