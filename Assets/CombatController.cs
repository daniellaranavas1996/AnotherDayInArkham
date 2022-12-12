using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Image Jugador1; 
    [SerializeField] Image Jugador2; 
    void Start()
    {
        if (SelectionData.CharacterSelected1 != null && SelectionData.CharacterSelected2 != null)
        {
            Jugador1.sprite = SelectionData.CharacterSelected1.CharacterModel;
            Jugador2.sprite = SelectionData.CharacterSelected2.CharacterModel;
        }
    }

   
}
