using UnityEngine;

public class GearPart : MonoBehaviour
{
  public string partName;
  public bool isAssembled = false;


  //positions and rotations for assembled and exploded states
  [SerializeField] private Vector3 assembledPosition;
  [SerializeField] private Quaternion assembledRotation;
  [SerializeField] private Vector3 explodedPosition;
  [SerializeField] private Quaternion explodedRotation;



  [SerializeField] private int stepNumber; // step in the assembly process where this part is used

  // Method to mark the part as assembled
  public void AssemblePart()
  {
    isAssembled = true;
    // Additional logic for when the part is assembled
  }

  // Method to reset the part to unassembled state
  public void ResetPart()
  {
    isAssembled = false;
    // Additional logic for resetting the part
  }

}
