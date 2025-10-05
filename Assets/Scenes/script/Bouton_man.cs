using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gestionBouton1 : MonoBehaviour {
    public void btnNewScene(string nouvelleScene)
    {
        SceneManager.LoadScene(nouvelleScene);//Telechaer une nouvelle Scene
    }
    public Text Titre = null;
    public void change_nom()
    {
        if (Titre.text == "Daursariel") Titre.text = "YES";
        else Titre.text = "Daursariel";
    }
    public void btnNewScene2(string nouvelleScene)
    {
        SceneManager.LoadScene(nouvelleScene);//Telechaer une nouvelle Scene
    }


}
