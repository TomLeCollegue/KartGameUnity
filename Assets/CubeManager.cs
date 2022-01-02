using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{

    public int direction;
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(ChangeDirection()); 
    }
    void Update()
    {
        float randomNumber = Random.Range(0, 5);
        if(direction == 0)
        {
            transform.Translate(Vector3.down * randomNumber * Time.deltaTime);
        } else
        {
            transform.Translate(Vector3.up * randomNumber * Time.deltaTime);
        }

    }

    IEnumerator ChangeDirection()
    {
        while(true)
        {
            direction = Random.Range(0, 2);
            yield return new WaitForSeconds(3f);
        }
    }
}
