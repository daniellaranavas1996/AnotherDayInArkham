using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLoadScript : MonoBehaviour
{

    
    public Character LoadedCharacter;

    [SerializeField] Image ImageCharacter;
    [SerializeField] TMPro.TextMeshProUGUI TextHP;
    [SerializeField] Slider Slide;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "ObjectPlayer1")
        {

           
            //SelectionData.CharacterSelected1.SaludActual = SelectionData.CharacterSelected1.Salud;
            new LoadCharacterCommand(gameObject.name, SelectionData.CharacterSelected1, ImageCharacter, TextHP, Slide).AddToQueue();

        }
        else
        {


            //SelectionData.CharacterSelected2.SaludActual = SelectionData.CharacterSelected2.Salud;
            new LoadCharacterCommand(gameObject.name, SelectionData.CharacterSelected2, ImageCharacter, TextHP, Slide).AddToQueue();

        }
   

        

    }

    public void LoadFromAsset()
    {
        if (gameObject.name == "ObjectPlayer1")
        {
            new LoadCharacterCommand(gameObject.name, SelectionData.CharacterSelected1, ImageCharacter, TextHP, Slide).AddToQueue();            
          
        }else
        {
            new LoadCharacterCommand(gameObject.name, SelectionData.CharacterSelected2, ImageCharacter, TextHP, Slide).AddToQueue();

        }


    }



}
