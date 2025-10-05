using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class gestionBouton1 : MonoBehaviour {
    public void btnNewScene1(string nomDeScene)
    {
        Debug.Log("charge une scene");
        SceneManager.LoadScene(nomDeScene, LoadSceneMode.Additive);
        EditorSceneManager.OpenScene("Assets/Scenes/donjoon.unity");
    }
    public void btnNewScene2(string nomDeScene)
    {
        Debug.Log("charge une scene");
        SceneManager.LoadScene(nomDeScene, LoadSceneMode.Additive);
        EditorSceneManager.OpenScene("Assets/Scenes/Foret.unity");
    }

}
