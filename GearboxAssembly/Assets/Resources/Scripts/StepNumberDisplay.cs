using TMPro;
using UnityEngine;

public class StepNumberDisplay : MonoBehaviour
{
    public StepManager stepManager;
    public TextMeshProUGUI stepText;

    void Start()
    {
        // Auto-find StepManager if not assigned
        if (stepManager == null)
            stepManager = FindObjectOfType<StepManager>();

        UpdateText();
    }

    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        if (stepManager == null || stepText == null) return;

        stepText.text = stepManager.CurrentStepNumber.ToString();
    }
}
