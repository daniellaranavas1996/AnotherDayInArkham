using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] EnemigoSlots;
    public Enemy[] PosiblesEnemigos;

    private static System.Random rng = new System.Random(System.Convert.ToInt32(System.DateTime.Now.ToString("ddhhmmss")));



    void Start()
    {
        int qtyEnemy = rng.Next(1, 4);
        Debug.Log($"Pues te ha tocado {qtyEnemy} enemigos. Suerte:)");

        int i = 1;
        foreach (GameObject slot in EnemigoSlots)
        {
            if (i <= qtyEnemy)
            {

                int typeEnemy = rng.Next(1, PosiblesEnemigos.Length);

                slot.GetComponent<EnemyDisplay>().Enemy = PosiblesEnemigos[typeEnemy-1];
                slot.GetComponent<EnemyDisplay>().LoadFromAsset();

                slot.SetActive(true);
            }
            else
            {
                slot.SetActive(false);
            }
            i++;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
