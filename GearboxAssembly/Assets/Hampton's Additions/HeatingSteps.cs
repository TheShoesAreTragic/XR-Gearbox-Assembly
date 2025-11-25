using UnityEngine;

public class HeatingStep : MonoBehaviour
{
    public StepManager stepManager;

    public int[] heatingSteps = { 1, 4, 5, 9 };
    public string[] heatingStepGearNames = { "Bevel Pinion", "Pinion", "Bevel Gear", "Gear" };

    public AudioSource tickingAudio;
    public AudioSource dingAudio;

    public float heatingDuration = 5f;

    private bool heatingStarted = false;
    private bool gearInside = false;
    private string gearNameInside = null;

    private void OnTriggerEnter(Collider other)
    {
        gearInside = true;
        gearNameInside = other.gameObject.name;

        Debug.Log("[HeatingStep] Gear inside: " + gearNameInside);

        TryStartHeating();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == gearNameInside)
        {
            gearInside = false;
            gearNameInside = null;

            Debug.Log("[HeatingStep] Gear removed.");
        }
    }

    private void Update()
    {
        TryStartHeating();
    }

    private void TryStartHeating()
    {
        if (heatingStarted) return;
        if (!gearInside) return;

        int currentStep = stepManager.CurrentStepNumber;

        // Find step index
        int index = System.Array.IndexOf(heatingSteps, currentStep);
        if (index == -1) return; // Not a heating step

        // Check if object matches this step's required gear
        string requiredGear = heatingStepGearNames[index];

        // Allows "GearName(Clone)" automatically
        if (!gearNameInside.StartsWith(requiredGear))
        {
            Debug.Log("[HeatingStep] Wrong gear. Expected: " + requiredGear);
            return;
        }

        StartCoroutine(HeatProcess());
    }

    private System.Collections.IEnumerator HeatProcess()
    {
        heatingStarted = true;
        Debug.Log("[HeatingStep] Heating started.");

        if (tickingAudio != null) tickingAudio.Play();

        yield return new WaitForSeconds(heatingDuration);

        if (tickingAudio != null) tickingAudio.Stop();
        if (dingAudio != null) dingAudio.Play();

        Debug.Log("[HeatingStep] Heating complete.");
        heatingStarted = false;

        stepManager.AdvanceFrom(stepManager.CurrentStepNumber);
    }
}
