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
    [SerializeField] GameObject[] PanelArray;
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
            PanelArray[index].SetActive(false);

        }
        else
        {
            if (GetSelectedCount() < 2)
            {
                isSelected[index] = true;
                imagesSelecteds[System.Int32.Parse(button.tag)].color = new Color(255, 255, 255);
                PanelArray[System.Int32.Parse(button.tag)].SetActive(true);

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
                    SelectionData.CharacterSelected1.SaludActual = SelectionData.CharacterSelected1.Salud;
                }
                else
                {
                    SelectionData.CharacterSelected2 = charactersDeck[i];
                    SelectionData.CharacterSelected2.SaludActual = SelectionData.CharacterSelected2.Salud;
                }

            }
        }

        //Limpiamos config mapa para regenerarlo
        PlayerPrefs.DeleteKey("Map");

        SceneManager.LoadScene("MapScene");

       
    }
}
