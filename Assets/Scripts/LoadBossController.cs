using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBossController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] EnemigoSlots;
    public Enemy[] PosiblesEnemigos;

    private static System.Random rng = new System.Random(System.Convert.ToInt32(System.DateTime.Now.ToString("ddhhmmss")));



    void Start()
    {
        int qtyEnemy = 1;
        Debug.Log($"BOSS!");

        int i = 1;
        foreach (GameObject slot in EnemigoSlots)
        {
           

                int typeEnemy = rng.Next(1, PosiblesEnemigos.Length);

                slot.GetComponent<EnemyDisplay>().Enemy = PosiblesEnemigos[typeEnemy-1];
                slot.GetComponent<EnemyDisplay>().LoadFromAsset();
                slot.SetActive(true);
          
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
