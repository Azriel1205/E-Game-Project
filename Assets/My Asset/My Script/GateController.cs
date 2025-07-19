using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public GameObject closedGate;
    public GameObject openGate;

    public void OpenGate()
    {
        closedGate.SetActive(false); // Deactivate closed gate
        openGate.SetActive(true); // Activate open gate
    }

    public void CloseGate()
    {
        closedGate.SetActive(true); // Activate closed gate
        openGate.SetActive(false); // Deactivate open gate
    }
}
