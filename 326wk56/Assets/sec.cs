using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class sec : MonoBehaviour
{
    private static sec instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadGameScene()
    {
        StartCoroutine(_LoadGameScene());
    }

    IEnumerator _LoadGameScene()
    {
        AsyncOperation loadOp = SceneManager.LoadSceneAsync("Game");
        while (!loadOp.isDone)
        {
            yield return null;
        }

        // Ensure the scene is loaded before searching for the player
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            Debug.Log(player.name);
        }
        else
        {
            Debug.LogWarning("Player object not found!");
        }

        // Unsubscribe after execution
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
