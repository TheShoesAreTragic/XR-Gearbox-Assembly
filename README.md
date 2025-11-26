# XR Gearbox Assembly

Gearbox assembly is a difficult process where precision, repeatability, and safety are essential. Traditional training relies on shadowing, paper SOPs, and undocumented information and skills. This leads to long training, inconsistent torquing sequences, occasional assembly errors, and production variability during training of new employees. Additionally, as processes are updated, new trainings will be released and required of existing employees to maximize assembly efficiency. Our goal is to reduce the time-to-competence for new trainees, reduce retraining time, and enhance new process adoption for existing employees through VR interactive training. This Unity project uses a guided, simulation‑based experience for learning the full assembly of a representative gearbox. Users can practice component identification, heating gears, hammering shafts through the gears, fitment order, and proper alignment of components.

## Build/Run Instructions

1. Clone the repository to your computer
2. Open Unity Hub and add a project from your disk
3. Select the GearboxAssembly folder within your local repo and select open
4. The project should load into Untiy Hub and open the Unity Editor
5. Navigate to the Assets/Scenes/VR_Training_Sim
6. Testing with the Quest 3:
   1. Open Build Profiles
   2. Switch to Meta Quest
   3. Make sure the VR_Training_Sim scene is selected
   4. Plug in the Quest and hit allow on both your laptop and the Quest
   5. Click Build and Run to build the scene onto the Quest
   6. You should load into the scene automatically and be able to test the scene
7. Testing with XR Device Simulator:
   1. Disable the XR Origin and Enable the XR Origin (Simulator) asset in the hierarchy
   2. Enable the XR Device Simulator asset
   3. Run the scene ang begin testing using your keyboard (g is grab and left click is the trigger button)
  
## Video Demo
