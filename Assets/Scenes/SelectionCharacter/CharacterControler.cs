using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterControler : MonoBehaviour
{
    [SerializeField] RawImage[] imagesSelecteds;
    [SerializeField] bool[] isSelected;
    [SerializeField] List<string> SelectedCharacters;
    [SerializeField] Button botonComenzar;
    [SerializeField] Character[] charactersDeck;
    private int GetSelectedCount()
    {
        return isSelected.Where(x => x == true).Count();
    }


    private void Start()
    {
        SelectedCharacters = new List<string>();
    }
    public void OnClickCharacter(Button button)
    {

        int index = System.Int32.Parse(button.tag);
        if (isSelected[index])
        {
            isSelected[index] = false;            
            imagesSelecteds[index].color = new Color(0.5f, 0.5f, 0.5f);

        }
        else
        {
            if (GetSelectedCount() < 2)
            {
                isSelected[index] = true;
                imagesSelecteds[System.Int32.Parse(button.tag)].color = new Color(255, 255, 255);

            }
         
        }
        if (GetSelectedCount() < 2)
        {
            botonComenzar.interactable = false;
        }
        else
        {
            botonComenzar.interactable = true;
            
        }

    }


    public void ComenzarJuego()
    {
        //(1) yorick, (2) daisy, (3) Agnes, (4) Roland
        SelectionData.CharacterSelected1 = null;
        SelectionData.CharacterSelected2 = null;
        for (int i = 0; i < isSelected.Length ; i++)
        {
            if (isSelected[i] == true)
            {
                if (SelectionData.CharacterSelected1 == null)
                {
                    SelectionData.CharacterSelected1 = charactersDeck[i];
                }
                else
                {
                    SelectionData.CharacterSelected2 = charactersDeck[i];
                }

            }
        }

        SceneManager.LoadScene("CombatScene");

       
    }
}
