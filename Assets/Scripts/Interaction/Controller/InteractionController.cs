using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour {
    public List<IInteractive> interactivesInRange = new List<IInteractive>();
    private IInteractive closestInteractive;

    private void OnTriggerEnter(Collider other) {
        //check if other is interactive
        //if interactive add to interactivesInRange
    }

    private void OnTriggerExit(Collider other) {
        //check if other is interactive
        //if interactive remove from interactivesInRange
    }

    private void Update() { }

    public void HandleInteraction(InputAction.CallbackContext context) {
        if (context.performed) closestInteractive.Interact();
    }

    public void AddInteractive(IInteractive interactive) {
        interactivesInRange.Add(interactive);
        interactive.OnRangeEnter();
    }

    public void RemoveInteractive(IInteractive interactive) {
        interactivesInRange.Remove(interactive);
        interactive.OnRangeExit();
    }

    private void InCircleSection() { }
}

public interface IInteractive {
    void OnRangeEnter();
    void OnRangeExit();
    void Interact();
}

public class PickUpOnEnter : IInteractive {
    public void OnRangeEnter() { }

    public void OnRangeExit() { }

    public void Interact() { }
}
