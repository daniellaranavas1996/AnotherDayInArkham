using Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostLoadScript : MonoBehaviour
{
    // Se pasa el controlador de mapa para que al crear esta escena se genere el mapa (ya dependiendo de la configuraci�n dentro del MapManager).
    public MapManager mapManager;


    void Start()
    {
        mapManager.GenerateNewMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        mapManager.SaveMap();
    }
}
