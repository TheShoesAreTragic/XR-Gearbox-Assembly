using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StepManager : MonoBehaviour
{
    [Serializable]
    public class StepDefinition
    {
        [Tooltip("Step number, e.g. 1, 2, 3 ... up to 13")]
        public int stepNumber;

        [Header("Scene objects to toggle when entering this step")]
        public GameObject[] enableOnEnter;
        public GameObject[] disableOnEnter;

        [Header("Optional events")]
        public UnityEvent onEnter;
        public UnityEvent onExit;
    }

    [Header("Steps (numbers should be unique)")]
    public StepDefinition[] steps;

    [Header("Starting step number")]
    public int startStepNumber = 1;

    public int CurrentStepNumber { get; private set; }

    Dictionary<int, int> stepIndexLookup;

    void Awake()
    {
        stepIndexLookup = new Dictionary<int, int>();

        // Build lookup: stepNumber -> index in array
        for (int i = 0; i < steps.Length; i++)
        {
            int num = steps[i].stepNumber;
            if (!stepIndexLookup.ContainsKey(num))
            {
                stepIndexLookup.Add(num, i);
            }
            else
            {
                Debug.LogWarning($"Duplicate step number {num} in StepManager.");
            }
        }

        SetStep(startStepNumber);
    }

    public void SetStep(int stepNumber)
    {
        Debug.Log($"[StepManager] SetStep called with {stepNumber}");

        // Exit previous step
        if (stepIndexLookup != null && stepIndexLookup.ContainsKey(CurrentStepNumber))
        {
            var oldDef = steps[stepIndexLookup[CurrentStepNumber]];
            oldDef.onExit?.Invoke();
        }

        CurrentStepNumber = stepNumber;

        if (!stepIndexLookup.ContainsKey(stepNumber))
        {
            Debug.LogError($"[StepManager] No StepDefinition found for step {stepNumber}");
            return;
        }

        var def = steps[stepIndexLookup[stepNumber]];

        // Toggle objects
        foreach (var go in def.enableOnEnter)
        {
            if (go != null) go.SetActive(true);
        }

        foreach (var go in def.disableOnEnter)
        {
            if (go != null) go.SetActive(false);
        }

        def.onEnter?.Invoke();
        Debug.Log($"[StepManager] Entered step {stepNumber}");
    }

    public void AdvanceFrom(int fromStepNumber)
    {
        Debug.Log($"[StepManager] AdvanceFrom called with {fromStepNumber}, current = {CurrentStepNumber}");

        if (CurrentStepNumber != fromStepNumber)
        {
            Debug.Log("[StepManager] AdvanceFrom ignored (current step doesn't match).");
            return;
        }

        if (!stepIndexLookup.ContainsKey(fromStepNumber))
        {
            Debug.LogError($"[StepManager] Step {fromStepNumber} not found.");
            return;
        }

        int currentIndex = stepIndexLookup[fromStepNumber];
        int nextIndex = currentIndex + 1;

        if (nextIndex >= steps.Length)
        {
            Debug.Log("[StepManager] Already at final step, no next.");
            return;
        }

        int nextStepNumber = steps[nextIndex].stepNumber;
        Debug.Log($"[StepManager] Advancing from {fromStepNumber} to {nextStepNumber}");
        SetStep(nextStepNumber);
    }

}
