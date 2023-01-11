using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInvestigateController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject panelHuir;
    public GameObject panelInvestigar;
    public int pistas;
    public bool BossFight;
    public TMPro.TextMeshProUGUI CampoTextoPistas;

    private static System.Random rng = new System.Random(System.Convert.ToInt32(System.DateTime.Now.ToString("ddhhmmss")));

    void Start()
    {
        if (!BossFight)
        {
            pistas = rng.Next(10, 25);

        }
        else
        {
            pistas = rng.Next(25, 50);

        }
        CampoTextoPistas.text = $"{pistas} PISTAS";
    }

    // Update is called once per frame
    public void CompruebaPistas()
    {
        CampoTextoPistas.text = $"{pistas} PISTAS";
        if (pistas <= 0)
        {
            panelInvestigar.gameObject.SetActive(false);
            panelHuir.gameObject.SetActive(true);
        }
    }

    public void HuyeConPistas()
    {
        Debug.Log("Has escapado ;)");
        SceneManager.LoadScene("MapScene");
    }
}
