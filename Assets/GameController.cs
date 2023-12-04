using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject confirmationPopUp = null;

    public void Start()
    {
        DeactivatePopUp();
    }
    public void DeactivatePopUp()
    {
        confirmationPopUp.SetActive(false);
    }
    public void ActivatePopUp(GameObject PopUp)
    {
        DeactivatePopUp();

        PopUp.SetActive(true);
    }
    public void SceneLoader(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
