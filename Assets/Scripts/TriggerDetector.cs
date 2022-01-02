using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.checkPointsManager.RegisterNewCheckPoint(other.gameObject);
    }
}
