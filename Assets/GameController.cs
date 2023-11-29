using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void SceneLoader(string SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
