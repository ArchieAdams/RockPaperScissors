using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    public GameObject GameMenu;
    public GameObject EscapeMenu;

    private void Update()
    {
        CheckInput();  //Happens every frame
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Escape();
        }
    }

    public void Escape()
    {
        GameMenu.SetActive(false);
        EscapeMenu.SetActive(true);
    }

}
