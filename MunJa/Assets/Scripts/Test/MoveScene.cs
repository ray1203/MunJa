using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public void MoveScene_(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
