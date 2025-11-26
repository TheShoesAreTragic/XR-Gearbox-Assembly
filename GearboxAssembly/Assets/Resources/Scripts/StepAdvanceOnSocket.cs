using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StepAdvanceOnSocket : MonoBehaviour
{
    public StepManager stepManager;
    public int stepToAdvanceFrom = 2;      // go from 2 -> 3
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    
    [Header("Optional filter")]
    public string requiredTag = "";        // e.g. "Gearbox Part" (leave empty to accept any)

    void Awake()
    {
        if (socket == null)
            socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
    }

    void OnEnable()
    {
        if (socket != null)
            socket.selectEntered.AddListener(OnSelectEntered);
    }

    void OnDisable()
    {
        if (socket != null)
            socket.selectEntered.RemoveListener(OnSelectEntered);
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (stepManager == null)
            stepManager = FindObjectOfType<StepManager>();

        if (stepManager == null) return;

        // If you only want a specific object, enforce by tag
        if (!string.IsNullOrEmpty(requiredTag))
        {
            if (!args.interactableObject.transform.CompareTag(requiredTag))
                return;
        }

        // This will only work if CurrentStepNumber == stepToAdvanceFrom (2)
        stepManager.AdvanceFrom(stepToAdvanceFrom);
    }
}
