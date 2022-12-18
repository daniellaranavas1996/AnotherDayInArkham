using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DraggingActionsTestReturn : DraggingActionsTest 
{
    private Vector3 savedPos;

    public DG.Tweening.Ease TypeBouncing;

    private bool doingMove = false;
    public override void OnStartDrag()
    {
        if (!doingMove)
        {
            savedPos = transform.position;
            doingMove = true;
        }
    }

    public override void OnEndDrag()
    {

       //Según el efecto que queramos hará el efecto de "rebote" o deslizamiento.
       //Hay que controlar que una vez haga la acción no haga el OnEndDrag si no se descarte la carta.


       transform.DOMove(savedPos, 1f).SetEase(TypeBouncing, 0.5f, 0.1f);
        doingMove = false;
    }

    public override void OnDraggingInUpdate(){
        if (true)
        {

        }
    
    }

    protected override bool DragSuccessful()
    {
        return true;
    }



}
