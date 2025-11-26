using UnityEngine;
using UnityEngine.InputSystem;

public class StepEnterAdvance : MonoBehaviour
{
    public StepManager stepManager;

    public InputActionReference buttonAction;

    // Steps where Enter should advance
    public int[] enterSteps = {0};

    void Start()
    {
        if (stepManager == null)
        {
            stepManager = FindObjectOfType<StepManager>();
            if (stepManager == null)
            {
                Debug.LogError("[StepEnterAdvance] No StepManager found in scene.");
            }
        }
    }
    private void OnEnable()
    {
        buttonAction.action.Enable();
    }

    private void OnDisable()
    {
        buttonAction.action.Disable();
    }

    void Update()
    {
        if (buttonAction.action.IsPressed())
        {
            //Debug.Log("[StepEnterAdvance] Enter pressed");

            if (stepManager == null)
            {
                Debug.LogError("[StepEnterAdvance] stepManager is null.");
                return;
            }

            int current = stepManager.CurrentStepNumber;
            //Debug.Log("[StepEnterAdvance] Current step = " + current);

            bool allowed = false;
            for (int i = 0; i < enterSteps.Length; i++)
            {
                if (enterSteps[i] == current)
                {
                    allowed = true;
                    break;
                }
            }

            if (!allowed)
            {
                //Debug.Log("[StepEnterAdvance] Enter pressed, but not a step that uses Enter.");
                return;
            }

            Debug.Log("[StepEnterAdvance] Attempting to advance from step " + current);
            stepManager.AdvanceFrom(current);
        }
    }
}
