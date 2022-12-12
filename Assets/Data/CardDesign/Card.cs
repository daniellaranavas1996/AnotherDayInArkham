using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevaCarta", menuName = "Cartas")]
public class Card : ScriptableObject
{

    public new string name;
    public string description;    
    public Sprite artwork;

    public int Energy;
    //Mecanicas a implementar

    //Cantidad de daño a realizar al enemigo
    public int AmountToDamage;
    //Cantidad a investigar en la ubicación
    public int AmountToInvestigate;
    //Cantidad a curar a una aliado
    public int AmountToHealToAlly;
    //Cantidad a proteger
    public int AmountToProtect;
    //Cantidad de cartas a robar
    public int AmountToDraw;

    public bool BadResultOnPair;

    public int DamageOnBadResult;

    public TargetingType tipoTarget;

}

public enum TargetingType
{
    TargetCreature,
    TargetAlly,
    AllAllies,
    AllEnemies,
    Both,
    Nothing,
    ClueTarget
    

}

