using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform shottingOffset;

        // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
         {
            GameObject shot = Instantiate(bulletPrefab, shottingOffset.position, Quaternion.identity);
            Debug.Log("Bang!");
            Destroy(shot, 4f);

        }
    }
}
