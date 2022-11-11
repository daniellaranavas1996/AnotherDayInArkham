using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Card card;
    [SerializeField] public TextMeshPro nametext;
    [SerializeField] public TextMeshPro description;
    [SerializeField] public TextMeshPro energy;
    [SerializeField] public Image image;

    private void Start()
    {
        nametext.text = card.name.ToString();
        energy.text = card.Energy.ToString();
        
        description.text = card.description.ToString();
        image.sprite = card.artwork;


    }

}
