using UnityEngine;
using System.Collections;

public abstract class DraggingActions : MonoBehaviour {

    public abstract void OnStartDrag();

    public abstract void OnEndDrag();

    public abstract void OnDraggingInUpdate();

    public virtual bool CanDrag
    {
        get
        {            

            //Para ver si se puede dragear una carta o no, mientras no sea tu turno. ON PROCESS
            return true;
        }
    }



    protected abstract bool DragSuccessful();
}
