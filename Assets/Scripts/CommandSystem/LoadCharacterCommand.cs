using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadCharacterCommand : Command
{
    // Start is called before the first frame update

    public string ObjectName;
    public Character LoadedCharacter;
    public Image ImageCharacter;
    public Image RipModel;
    public TMPro.TextMeshProUGUI TextHP;
    public Slider Slide;

    public LoadCharacterCommand(string objectName, Character loadedCharacter, Image imageCharacter, TextMeshProUGUI textHP, Slider slide)
    {
        ObjectName = objectName;
        LoadedCharacter = loadedCharacter;
        ImageCharacter = imageCharacter;
        TextHP = textHP;
        Slide = slide;
    }

    public override void StartCommandExecution()
    {

        if (ObjectName == "ObjectPlayer1")
        {
            LoadedCharacter = SelectionData.CharacterSelected1;
        }
        else
        {
            LoadedCharacter = SelectionData.CharacterSelected2;
        }


        if (LoadedCharacter != null)
        {
            if (LoadedCharacter.SaludActual <= 0)
            {
                ImageCharacter.sprite = LoadedCharacter.RipModel;

            }
            else
            {
                ImageCharacter.sprite = LoadedCharacter.CharacterModel;

            }

            TextHP.text = LoadedCharacter.SaludActual.ToString("N0");

            float ValueSlide = (float)LoadedCharacter.SaludActual / (float)LoadedCharacter.Salud;
            Slide.value = ValueSlide;

        }

        LoadedCharacter.ShufleDeck();
        Command.CommandExecutionComplete();

        
    }
}
