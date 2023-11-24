using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField] string scene;
    
    public void ChangeScene() 
    {
        SceneManager.LoadScene(scene);
    }
}
