using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsManager : MonoBehaviour
{
    public GameObject[] checkpoints;

    private List<GameObject> triggeredCheckPoints = new List<GameObject>();


    public void RegisterNewCheckPoint(GameObject gameObject)
    {
        if(!triggeredCheckPoints.Contains(gameObject))
        {
            if(gameObject.name != "FinishLane" || triggeredCheckPoints.Count == checkpoints.Length - 1)
            {
                Debug.Log("Trigger");
                triggeredCheckPoints.Add(gameObject);
                if(triggeredCheckPoints.Count == checkpoints.Length)
                {
                    GameManager.singleton.FinishGame();
                }
            }
        }
    }
}
