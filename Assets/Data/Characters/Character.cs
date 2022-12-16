using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPersonaje", menuName = "Personaje")]
public class Character : ScriptableObject
{
    public string Name;
    ////A implementar posibles atributos; como fuerza, agilidad...
    //public int Strength;
    //public int Agility;
    //public int Wisdom;
    //public int Observation;
    
    public string Text;
    public Sprite CharacterModel;
    public List<Card> Deck;

    public int Salud;
    public int SaludActual;
    
}

