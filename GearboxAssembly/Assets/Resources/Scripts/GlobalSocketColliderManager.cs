using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GlobalSocketColliderManager : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor[] sockets;

    void Awake()
    {
        // Find all sockets in the scene
        sockets = FindObjectsOfType<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>(true);
    }

    void Start()
    {
        // Re-enable ALL colliders in the entire scene at startup
        Collider[] all = FindObjectsOfType<Collider>(true);
        foreach (var c in all)
            c.enabled = true;

        // Subscribe to selectEntered on every socket
        foreach (var socket in sockets)
        {
            socket.selectEntered.AddListener(OnSocketAttached);
        }
    }

    private void OnSocketAttached(SelectEnterEventArgs args)
    {
        // Disable all colliders on the attached object
        Transform attached = args.interactableObject.transform;
        Collider[] cols = attached.GetComponentsInChildren<Collider>(true);

        foreach (var c in cols)
            c.enabled = false;
    }

    void OnDestroy()
    {
        // Remove listeners to avoid problems on scene reloads
        foreach (var socket in sockets)
        {
            if (socket != null)
                socket.selectEntered.RemoveListener(OnSocketAttached);
        }
    }
}
