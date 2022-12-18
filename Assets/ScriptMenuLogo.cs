using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptMenuLogo : MonoBehaviour
{
    public Image imageToRotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        imageToRotate.rectTransform.Rotate(0, 0, 0.003f);


    }
}
