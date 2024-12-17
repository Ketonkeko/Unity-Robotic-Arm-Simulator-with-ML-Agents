using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggeractivator : MonoBehaviour
{
    public MoveToGoalAgent yourScript;

    private void OnTriggerEnter(Collider other)
    {
        yourScript.HandleTriggerEvent(other.GetComponent<Goal>());
    }
}
