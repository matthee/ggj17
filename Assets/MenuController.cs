using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
  public void StartGame() {
    SceneManager.LoadScene ("GameScene");
  }

  public void ExitGame() {
    #if UNITY_EDITOR
    EditorApplication.ExecuteMenuItem("Edit/Play");
    #else
    Application.Quit ();
    #endif
  }
}
