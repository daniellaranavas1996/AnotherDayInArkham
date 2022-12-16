using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CardDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Card card;
    [SerializeField] public TextMeshProUGUI nametext;
    [SerializeField] public TextMeshProUGUI description;
    [SerializeField] public TextMeshProUGUI energy;
    [SerializeField] public Image image;
    [SerializeField] public Image frameImage;

    public CardDisplay PreviewObject;

    private void Awake()
    {

        if (card != null)
        {
            LoadFromAsset();
        }




    }

    private void LoadFromAsset()
    {
        nametext.text = card.name.ToString();
        energy.text = card.Energy.ToString();
        description.text = card.description.ToString();
        image.sprite = card.artwork;

        if (PreviewObject != null)
        {

            PreviewObject.card = card;
            PreviewObject.LoadFromAsset();
        }

    }

    private bool canBePlayed = false;
    public bool CanBePlayed
    {
        get
        {
            return canBePlayed;
        }
        set
        {
            canBePlayed = value;

            //Para mas adelante mirar de hacer un glow detrás
        }
    }
    
}
