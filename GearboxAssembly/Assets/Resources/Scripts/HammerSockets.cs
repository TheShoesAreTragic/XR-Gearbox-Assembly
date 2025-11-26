using UnityEngine;


public class HammerSockets : MonoBehaviour
{
    [Header("Required References")]
    public Transform gear;                     // Position of the gear
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable shaftGrab;           // The shaft
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable hammerGrab;          // The hammer
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor gearSocket;          // Socket on the gear
    public Transform shaftTransform;

    [Header("Assembly Conditions")]
    public float maxDistance = 0.25f;       // Shaft must be close to hole
    public float maxAngle = 5f;                   // Acceptable orientation

    private bool assemblyComplete = false;

    private void Start()
    {
        // Ensure the socket is disabled until we allow assembly
        gearSocket.enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision Detected!");

        if (assemblyComplete)
        {
            Debug.Log("Assembly already complete for these parts.");
            return;
        }

        // Must be the hammer hitting the shaft
        if (!collision.GetComponent<Collider>().CompareTag("Hammer"))
        {
            Debug.Log("Not a hammer collision.");
            return;
        }
        // Player must be holding both objects
        if (!hammerGrab.isSelected || !shaftGrab.isSelected)
        {
            Debug.Log("Both objects are not being held.");
            return;
        }

        // Shaft must be positioned close to the gear hole
        float dist = Vector3.Distance(shaftGrab.transform.position, gear.position);
        Debug.Log(dist);
        if (dist > maxDistance)
        {
            Debug.Log("Objects aren't close enough!");
            return;
        }

        // Shaft must be oriented horizontally (0-5° from vertical)
        if (!IsShaftAngleValid(shaftTransform))
        {
            Debug.Log("Angle of shaft is incorrect");
            return;
        }

        // All conditions met → complete assembly
        Debug.Log("Objects should snap together now!");
        CompleteAssembly();
    }

    private bool IsShaftAngleValid(Transform shaftTransform)
    {    
        float angle = Vector3.Angle(shaftTransform.right, Vector3.up);

        bool is_up = angle <= maxAngle;
        bool is_down = angle >= maxAngle + 170;

        return (is_up || is_down);
    }

    private void CompleteAssembly()
    {
        assemblyComplete = true;
        Debug.Log("[HammerSockets] Assembly complete!");

        // 1. Enable socket so snapping is allowed
        gearSocket.enabled = true;

        // 2. Release shaft from user's hand if still held
        // if (shaftGrab.isSelected)
        // {
        //     var interactor = shaftGrab.firstInteractorSelecting;
        //     shaftGrab.interactionManager.SelectExit(
        //         (UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor)interactor,
        //         (UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable)shaftGrab
        //     );
        // }

        // // 3. Force the socket to take ownership of the shaft
        // gearSocket.interactionManager.SelectEnter(
        //     (UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor)gearSocket,
        //     (UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable)shaftGrab
        // );
    }
}
