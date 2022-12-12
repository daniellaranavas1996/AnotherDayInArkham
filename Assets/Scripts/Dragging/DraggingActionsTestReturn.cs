using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DraggingActionsTestReturn : DraggingActionsTest 
{
    private Vector3 savedPos;

    public DG.Tweening.Ease TypeBouncing;

    public override void OnStartDrag()
    {
        savedPos = transform.position;
    }

    public override void OnEndDrag()
    {

       //Según el efecto que queramos hará el efecto de "rebote" o deslizamiento.
       //Hay que controlar que una vez haga la acción no haga el OnEndDrag si no se descarte la carta.
       transform.DOMove(savedPos, 1f).SetEase(TypeBouncing, 0.5f, 0.1f);
      
    }

    public override void OnDraggingInUpdate(){}

    protected override bool DragSuccessful()
    {
        return true;
    }
}
