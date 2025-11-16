using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

// this class handles the training state
public class TrainingManager : MonoBehaviour
{
    #region Private Fields
    [SerializeField] private UIDocument _uiDocument;          // 2️⃣ Reference to the UI Document
    private VisualElement _root;
    private Label _stepLabel;
    private ProgressBar _stepProgress;
    private Button _nextButton;
    private Button _prevButton;
    private Button _hintButton;

    private Gearbox _gearbox;
    private Workstation _workstation;
    #endregion


    // Private Fields
    private int _currentStep;
    private int _totalSteps;
    private bool _isTrainingActive;




    #region Unity Lifecycle
    private void Awake()
    {
        // 3️⃣ Cache UI references
        if (_uiDocument != null)
        {
            _root = _uiDocument.rootVisualElement;
            _stepLabel = _root.Q<Label>("stepLabel");
            _stepProgress = _root.Q<ProgressBar>("stepProgress");
            _nextButton = _root.Q<Button>("nextButton");
            _prevButton = _root.Q<Button>("prevButton");
            _hintButton = _root.Q<Button>("hintButton");

            // Hook button events
            _nextButton.clicked += NextStep;
            _prevButton.clicked += PreviousStep;
            _hintButton.clicked += ShowHint;
        }
    }
    #endregion






    // Public Methods
    public void StartTraining()
    {
        _isTrainingActive = true;
        _currentStep = 0;
        _totalSteps = 10; // example value
        UpdateUI();

    }

    public void NextStep()
    {
        if (_currentStep < _totalSteps - 1)
        {
            _currentStep++;
            UpdateUI();
            LogProgress();
        }
    }
    public void PreviousStep()
    {
        if (_currentStep > 0)
        {
            _currentStep--;
            UpdateUI();
            LogProgress();
        }
    }

    public void EndTraining() { }

    public void ShowHint()
    {
        // logic to show hint for current step
        HighlightCurrentPart();
        ShowGhostPart();
    }


    // Private Methods
    private void UpdateUI()
    {

        if (_stepLabel != null)
            _stepLabel.text = $"Step {_currentStep + 1} of {_totalSteps}";

        if (_stepProgress != null)
            _stepProgress.value = (float)(_currentStep + 1) / _totalSteps;

    }


    private void HighlightCurrentPart() { }

    private void ShowGhostPart() { }


    private void LogProgress() { }














}
