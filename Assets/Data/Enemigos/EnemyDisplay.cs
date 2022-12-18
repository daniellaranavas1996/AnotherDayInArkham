using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyDisplay : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update

    public Enemy Enemy;

    public EnemyDisplay(Enemy enemy)
    {
        this.Enemy = enemy;
    }

    [SerializeField] public Image image;
    [SerializeField] public TextMeshProUGUI hp;
    [SerializeField] public Slider slide;



    private void Awake()
    {

        if (Enemy != null)
        {
            LoadFromAsset();
        }

    }

    public void LoadFromAsset()
    {

        Enemy.CalculaAtributos();





        hp.text = Enemy.SaludActual.ToString("N0");
        image.sprite = Enemy.EnemyModel;
        slide.value = (float)Enemy.SaludActual / (float)Enemy.Salud;

        if (Enemy.SaludActual <= 0)
        {
            image.sprite = Enemy.RipModel;
        }
    
}

    public void RefreshFromAsset()
    {



        hp.text = Enemy.SaludActual.ToString("N0");
        image.sprite = Enemy.EnemyModel;
        slide.value = (float)Enemy.SaludActual / (float)Enemy.Salud;


        if (Enemy.SaludActual <= 0)
        {
            image.sprite = Enemy.RipModel;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Something is dropping herrre");
    }
}
