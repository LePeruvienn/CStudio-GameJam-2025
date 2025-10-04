using System.Xml.Linq;
using UnityEngine;
using Mono.Cecil.Cil;
using NUnit.Framework;


public class Code_personnage : MonoBehaviour {

    [SerializeField] string name; //affiche et rend monifiable le nom en bas a droite
    public string Name { get { return name; } }

    [TextArea]

    [SerializeField] string description;
    public string Description { get { return description; } }

    [SerializeField] Sprite face_avant;
    public Sprite Face_avant { get { return face_avant; } }

    [SerializeField] Sprite face_arriere;
    public Sprite Face_arriere { get { return face_arriere; } }

    [SerializeField] Sprite cote_gauche;
    public Sprite Cote_gauche { get { return cote_gauche; } }

    [SerializeField] Sprite cote_droit;
    public Sprite Cote_droit { get { return cote_droit; } }

    [SerializeField] int hp;
    public int HP { get { return hp; } }

    [SerializeField] int defense;
    public int Defense { get { return defense; } }

    [SerializeField] int degats_magique;
    public int Degats_magique { get { return degats_magique; } }

    [SerializeField] List inventaires;
    public List Inventaire { get { return inventaires; } }



// Start is called once before the first execution of Update after the MonoBehaviour is created
 
void Start()
{
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
