using UnityEngine;




// class manages the the gearbox assembly process, the part interactions, manages the parts
public class Gearbox : MonoBehaviour
{


    public string gearboxModelNumber = "k47";






    private GameObject[] parts = new GameObject[10];


    private void FixedUpdate()
    {

    }



    // public methods
    public void ResetAssembly() { }

    public void ExplodeParts() { }
    public void ReassembleParts() { }



    // // event listeners
    // private void OnTriggerEnter(Collider other)
    // {
    //     // determine if the collider belongs to a GearPart
    //     GearPart part = other.GetComponent<GearPart>();
    //     if (part != null)
    //     {
    //         // add part to the assembly list
    //         parts.Add(part);


    //     }


    // }



    // Private Methods
    private void CollectParts() { }


    private void AssembleGearbox() { }




    // collect all parts of the gearbox












}
