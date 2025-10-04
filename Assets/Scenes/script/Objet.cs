using UnityEngine;

[CreateAssetMenu(fileName = "Objet", menuName ="Creer un nouvel objet")]//Crer une option dans le fichier Objet si il exist 
public class Objet : MonoBehaviour
{
    public enum objet_type{
        None,
        épée,
        potion,
        skate,
        hache,
    }

    [System.Serializable]        
    public class objet
    {
        public objet_type type;
        [SerializeField] Texte propriete;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
