using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectControl : MonoBehaviour
{

    [SerializeField] RawImage imgCharacter;
    [SerializeField] bool isSelected;


    private void Start()
    {
        isSelected = false;
    }
    public void OnClickCharacter()
    {
        if (isSelected)
        {
            isSelected = false;
            imgCharacter.color = new Color(0.5f, 0.5f, 0.5f);
        }
        else
        {
            isSelected = true;
            imgCharacter.color = new Color(255, 255, 255);
        }    



    }


}
