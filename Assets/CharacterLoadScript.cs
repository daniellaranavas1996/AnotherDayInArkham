using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLoadScript : MonoBehaviour
{

    
    [SerializeField] Character LoadedCharacter;

    [SerializeField] Image ImageCharacter;
    [SerializeField] TMPro.TextMeshProUGUI TextHP;
    [SerializeField] Slider Slide;

    // Start is called before the first frame update
    void Start()
    {

        if (gameObject.name == "ObjectPlayer1")
        {
            LoadedCharacter = SelectionData.CharacterSelected1;
        }
        else
        {
            LoadedCharacter = SelectionData.CharacterSelected2;
        }

        
        if (LoadedCharacter != null)
        {
            ImageCharacter.sprite = LoadedCharacter.CharacterModel;

            TextHP.text = LoadedCharacter.Salud.ToString("N0");

            float ValueSlide = LoadedCharacter.SaludActual / LoadedCharacter.Salud ;
            Slide.value = ValueSlide;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
