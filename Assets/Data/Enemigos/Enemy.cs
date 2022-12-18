using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoEnemigo", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public string Name;
    ////A implementar posibles atributos; como fuerza, agilidad...
    //public int Strength;
    //public int Agility;
    //public int Wisdom;
    //public int Observation;
    
    public Sprite EnemyModel;
    public Sprite RipModel;
    public int Salud;
    public int Ataque;

    public int SaludActual;

    [Header("Rangos de atributos")]
    public int SaludMinima;
    public int SaludMaxima;

    internal void CalculaAtributos()
    {

        Salud = rng.Next(SaludMinima, SaludMaxima);
        Ataque = rng.Next(AtaqueMinimo, AtaqueMaximo);
        SaludActual = Salud;

    }

    public int AtaqueMinimo;
    public int AtaqueMaximo;




    private static System.Random rng = new System.Random(System.Convert.ToInt32(System.DateTime.Now.ToString("ddhhmmss")));

    public Enemy()
    {

        CalculaAtributos();
    }



    
}

