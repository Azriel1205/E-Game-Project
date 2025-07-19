using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<GateController> gates; // List of gates instead of one gate
    public int requiredSodium = 2;
    public int requiredPotassium = 1;

    public List<AltarChange> sodiumAltars;
    public List<AltarChange> potassiumAltars;

    private bool gatesAreOpen = false; // Prevent constant SetActive calls every frame

    private void Update()
    {
        int totalSodium = 0;
        int totalPotassium = 0;

        foreach (var altar in sodiumAltars)
            totalSodium += altar.IonCount;

        foreach (var altar in potassiumAltars)
            totalPotassium += altar.IonCount;

        bool puzzleComplete = (totalSodium == requiredSodium && totalPotassium == requiredPotassium);

        if (puzzleComplete && !gatesAreOpen)
        {
            foreach (var gate in gates)
            {
                gate.OpenGate();
            }
            gatesAreOpen = true;
        }
        else if (!puzzleComplete && gatesAreOpen)
        {
            foreach (var gate in gates)
            {
                gate.CloseGate();
            }
            gatesAreOpen = false;
        }
    }
}
