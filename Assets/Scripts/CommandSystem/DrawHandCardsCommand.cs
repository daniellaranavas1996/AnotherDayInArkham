using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHandCardsCommand : Command
{



    public List<Card> HandInHand;

    public DrawHandCardsCommand(List<Card> handInHand)
    {
        HandInHand = handInHand;
    }

    // Start is called before the first frame update
    public override void StartCommandExecution()
    {

        GameObject s = GameObject.FindWithTag("Slot1");
        ScriptableObject.CreateInstance<Card>();
        
    



        Command.CommandExecutionComplete();


    }


}
