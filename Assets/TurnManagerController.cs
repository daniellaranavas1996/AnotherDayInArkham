using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class TurnManagerController : MonoBehaviour
{
    [Header("Energia")]
    public Image[] poolEnergy;
    public bool PlayerTurn = true;
    public int energyQty;
    [Header("Enemigos y personajes")]
    public GameObject[] EnemigosObject;
    public CharacterLoadScript[] PlayerObjects;
    [Header("Mensajes de turno")]
    public GameObject TurnBoxPlayer;
    public GameObject EnemyBoxPlayer;

    public GameObject HasGanadoBox;
    public GameObject HasPerdidoBox;

    public GameObject ZonaClues;

    public HandManager hmanager;
    private static System.Random rng = new System.Random(System.Convert.ToInt32(System.DateTime.Now.ToString("ddhhmmss")));

    public bool youWin = false;
    public bool youLose = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTurn = false;
        energyQty = 3;

        PassTurn();


    }

    public void PassTurn()
    {

        if (youWin || youLose)
        {
            return;
        }
        if (!PlayerTurn)

        {
            PlayerTurn = true;
            RenuevaEnergia();
            Character character1 = SelectionData.CharacterSelected1;
            Character character2 = SelectionData.CharacterSelected2;
            hmanager.DrawTurn(character1, character2);

            TurnBoxPlayer.SetActive(true);
            WaitForSeconds w = new WaitForSeconds(2);

            TurnBoxPlayer.SetActive(false);



        }
        else
        {

            hmanager.ClearHands();

            PlayerTurn = false;
            EnemyBoxPlayer.SetActive(true);
            WaitForSeconds w = new WaitForSeconds(2);
            EnemyBoxPlayer.SetActive(false);

            DoIAMove();
            PassTurn();
        }

        checkIfWin();








    }

    private void DoIAMove()
    {
        rng = new System.Random(System.Convert.ToInt32(System.DateTime.Now.ToString("ddhhmmss")));
        foreach (GameObject item in EnemigosObject)
        {
            if (item.active)
            {
                Enemy en = item.GetComponent<EnemyDisplay>().Enemy;
                if (en.SaludActual > 0)
                {
                    int i = rng.Next(0, 1000) % 2;

                    if (i == 1)
                    {
                        if (SelectionData.CharacterSelected2.SaludActual > 0)
                        {
                            SelectionData.CharacterSelected2.SaludActual -= en.Ataque;


                        }
                        else
                        {
                            SelectionData.CharacterSelected1.SaludActual -= en.Ataque;

                        }

                    }
                    else
                    {
                        if (SelectionData.CharacterSelected1.SaludActual > 0)
                        {
                            SelectionData.CharacterSelected1.SaludActual -= en.Ataque;
                        }
                        else
                        {
                            SelectionData.CharacterSelected2.SaludActual -= en.Ataque;
                        }
                    }

                    PlayerObjects[0].GetComponent<CharacterLoadScript>().LoadFromAsset();
                    PlayerObjects[1].GetComponent<CharacterLoadScript>().LoadFromAsset();

                }


            }

            
        }


    }

    public void checkIfWin()
    {
        bool PlayersStillAlive = false;
        bool EnemiesStillAlive = false;
        foreach (GameObject item in EnemigosObject)
        {
            if (item.active == true)
            {
                Enemy en = item.GetComponent<EnemyDisplay>().Enemy;
                if (en.SaludActual > 0)
                {
                    EnemiesStillAlive = true;
                }
            }
               
            
        }

        if (SelectionData.CharacterSelected1.SaludActual > 0 || SelectionData.CharacterSelected2.SaludActual > 0)
        {
            PlayersStillAlive = true;
        }

        if (!PlayersStillAlive)
        {
            youLose = true;
            hmanager.ClearHands();

            HasPerdidoBox.SetActive(true);

            StartCoroutine(WaitForUnscaledSeconds(2000f));
            //SceneManager.LoadScene("MainMenu");

        }
        else if (!EnemiesStillAlive)
        {
            youWin = true;
            hmanager.ClearHands();

            HasGanadoBox.SetActive(true);
            StartCoroutine(WaitForUnscaledSeconds(2000f));


            //SceneManager.LoadScene("MapScene");

        }
    }
    public static IEnumerator WaitForUnscaledSeconds(float time)
    {
        float ttl = 0;
        while (time > ttl)
        {
            ttl += Time.unscaledDeltaTime;
            yield return null;
        }
    }
    public IEnumerator GamePauseXSeconds(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

    }

    public void RefreshCharacterData()
    {

        PlayerObjects[0].GetComponent<CharacterLoadScript>().LoadFromAsset();
        PlayerObjects[1].GetComponent<CharacterLoadScript>().LoadFromAsset();
    }

    private void RenuevaEnergia()
    {
        energyQty = 3;

        foreach (Image img in poolEnergy)
        {
            img.gameObject.SetActive(true);
        }


    }

    public void AjustaEnergia(int cantidadEnergia)
    {

        energyQty = energyQty - cantidadEnergia;


        for (int i = 0; i < 3 - energyQty; i++)
        {
            poolEnergy[i].gameObject.SetActive(false);

        }

    }
    public void IrAlMenuPrincipal()
    {

        SceneManager.LoadScene("MainMenu");

    }
    public void IrAlMapaPrincipal()
    {
        SceneManager.LoadScene("MapScene");

    }
}

    // Update is called once per frame
  
