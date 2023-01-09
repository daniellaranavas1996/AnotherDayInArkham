using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectControl : MonoBehaviour
{

    [SerializeField] RawImage imgCharacter;
    [SerializeField] bool isSelected;
   public GameObject panelToHide;

    private void Start()
    {
        panelToHide.gameObject.SetActive(false);
        isSelected = false;
    }
    public void OnClickCharacter()
    {
        if (isSelected)
        {
            isSelected = false;
            imgCharacter.color = new Color(0.5f, 0.5f, 0.5f);
            panelToHide.gameObject.SetActive(false);
        }
        else
        {
            isSelected = true;
            imgCharacter.color = new Color(255, 255, 255);
            panelToHide.gameObject.SetActive(false);
        }    



    }


}
