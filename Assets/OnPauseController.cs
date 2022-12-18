using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPauseController : MonoBehaviour
{
    [SerializeField] Canvas CanvasToHide;

    public void ShowMenu()
    {
        CanvasToHide.gameObject.SetActive(true);
    }
}
