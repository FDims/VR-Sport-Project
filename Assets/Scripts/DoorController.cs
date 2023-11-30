using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
   public void SceneLoader(int SceneNumber){
        SceneManager.LoadScene(SceneNumber);
    }
    
}



