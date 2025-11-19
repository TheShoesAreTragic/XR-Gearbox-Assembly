using UnityEngine;

public class StepEnterAdvance : MonoBehaviour
{
    public StepManager stepManager;

    // Steps where Enter should advance
    public int[] enterSteps = { 1, 4, 5, 10 };

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("[StepEnterAdvance] Enter pressed");

            if (stepManager == null)
            {
                Debug.LogError("[StepEnterAdvance] stepManager is null.");
                return;
            }

            int current = stepManager.CurrentStepNumber;
            Debug.Log("[StepEnterAdvance] Current step = " + current);

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
                Debug.Log("[StepEnterAdvance] Enter pressed, but not a step that uses Enter.");
                return;
            }

            Debug.Log("[StepEnterAdvance] Attempting to advance from step " + current);
            stepManager.AdvanceFrom(current);
        }
    }
}
