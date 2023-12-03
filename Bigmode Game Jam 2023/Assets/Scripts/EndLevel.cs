using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;

    private void OnTriggerEnter2D(Collider2D other)
    {
        sceneLoader = sceneLoader.GetComponent<SceneLoader>();
        if (other.gameObject.CompareTag("Player"))
        {
            sceneLoader.LoadNextScene();
            Debug.Log("Player reached the end of the level");
        }
    }
}
