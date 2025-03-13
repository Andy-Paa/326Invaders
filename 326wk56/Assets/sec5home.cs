using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sec5home : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadDemoSceneAfterDelay(7f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadDemoSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("demo");
    }
}
