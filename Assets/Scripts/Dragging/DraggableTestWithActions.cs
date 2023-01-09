using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DraggableTestWithActions : MonoBehaviour
{

    public bool UsePointerDisplacement = true;
    // PRIVATE FIELDS
    // a reference to a DraggingActionsTest script
    private DraggingActionsTest da;

    // a flag to know if we are currently dragging this GameObject
    private bool dragging = false;

    // distance from the center of this Game Object to the point where we clicked to start dragging 
    private Vector3 pointerDisplacement = Vector3.zero;

    // distance from camera to mouse on Z axis 
    private float zDisplacement;

    public BoxCollider2D box;

    public LayerMask EnemyMask;

    public TurnManagerController tmanager;

    private static System.Random rng = new System.Random(System.Convert.ToInt32(System.DateTime.Now.ToString("ddhhmmss")));
    // MONOBEHAVIOUR METHODS
    void Awake()
    {
        da = GetComponent<DraggingActionsTest>();
    }

    void OnMouseDown()
    {
        if (tmanager.youWin || tmanager.youWin)
        {
            return;
        }
        if (da.CanDrag)
        {
            dragging = true;
            da.OnStartDrag();
            zDisplacement = -Camera.main.transform.position.z + transform.position.z;
            if (UsePointerDisplacement)
                pointerDisplacement = -transform.position + MouseInWorldCoords();
            else
                pointerDisplacement = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            Vector3 mousePos = MouseInWorldCoords();
            da.OnDraggingInUpdate();
            //Debug.Log(mousePos);
            transform.position = new Vector3(mousePos.x - pointerDisplacement.x, mousePos.y - pointerDisplacement.y, transform.position.z);
        }
    }

    void OnMouseUp()
    {

        if (tmanager.youWin || tmanager.youLose)
        {
            return;
        }
        if (dragging)
        {


            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitData;
            Physics.Raycast(ray, out hitData);
            bool resolved = false;
            if (hitData.collider != null)
            {
                Debug.Log("HUBO HIT HIT HIT " + hitData.collider.name);

                Card card = gameObject.GetComponent<CardDisplay>().card;

                if (card.Energy <= tmanager.energyQty)
                {
                    if ((card.tipoTarget == TargetingType.AllEnemies || card.tipoTarget == TargetingType.TargetCreature) && hitData.collider.name.Contains("Enemigo"))
                    {
                        GameObject enemy = hitData.collider.gameObject;
                        if (enemy.GetComponent<EnemyDisplay>().Enemy.SaludActual <= 0)
                        {
                            resolved = false;
                            return;
                        }
                        enemy.GetComponent<EnemyDisplay>().Enemy.SaludActual -= card.AmountToDamage;
                        enemy.GetComponent<EnemyDisplay>().RefreshFromAsset();
                        resolved = true;

                        if (card.BadResultOnPair)
                        {
                            int flipCoin = rng.Next(1,1000) % 2;
                            if (flipCoin == 1) //badresult y hacer daño
                            {

                                SelectionData.CharacterSelected1.SaludActual -= card.DamageOnBadResult;
                                SelectionData.CharacterSelected2.SaludActual -= card.DamageOnBadResult;

                                tmanager.RefreshCharacterData();
                            }
                        }


                    }

                    if (card.AmountToInvestigate > 0)
                    {

                        GameObject zoneClues = tmanager.ZonaClues;
                        zoneClues.gameObject.GetComponent<LoadInvestigateController>();
                        zoneClues.GetComponent<LoadInvestigateController>().pistas -= card.AmountToInvestigate;
                        zoneClues.GetComponent<LoadInvestigateController>().CompruebaPistas();
                        resolved = true;
                    }


                    if ((card.tipoTarget == TargetingType.AllAllies || card.tipoTarget == TargetingType.TargetAlly) && hitData.collider.name.Contains("Player"))
                    {
                        
                        if (card.tipoTarget == TargetingType.TargetAlly)
                        {

                            if (hitData.collider.name.Contains("Player1"))
                            {
                                if (card.AmountToHealToAlly > 0)
                                {
                                    if ((SelectionData.CharacterSelected1.SaludActual + card.AmountToHealToAlly) >= SelectionData.CharacterSelected1.Salud)
                                    {
                                        SelectionData.CharacterSelected1.SaludActual += card.AmountToHealToAlly;
                                    }
                                    else
                                    {
                                        SelectionData.CharacterSelected1.SaludActual = SelectionData.CharacterSelected1.Salud;
                                    }
                                }
                          

                                //PROTEGER SIEMPPRE PONDRÁ VIDA DE MÁS
                                SelectionData.CharacterSelected1.SaludActual += card.AmountToProtect;
                            }
                            else
                            {
                                if (card.AmountToHealToAlly > 0)
                                {

                                    if ((SelectionData.CharacterSelected2.SaludActual + card.AmountToHealToAlly) >= SelectionData.CharacterSelected2.Salud)
                                    {

                                        SelectionData.CharacterSelected2.SaludActual += card.AmountToHealToAlly;
                                    }
                                    else
                                    {
                                        SelectionData.CharacterSelected2.SaludActual = SelectionData.CharacterSelected2.Salud;
                                    }

                                }
                                    

                                SelectionData.CharacterSelected2.SaludActual += card.AmountToProtect;
                            }
                        }
                        if (card.tipoTarget == TargetingType.AllAllies)
                        {

                            if ((SelectionData.CharacterSelected1.SaludActual + card.AmountToHealToAlly) <= SelectionData.CharacterSelected1.Salud)
                            {
                                SelectionData.CharacterSelected1.SaludActual += card.AmountToHealToAlly;
                            }
                            else
                            {
                                SelectionData.CharacterSelected1.SaludActual = SelectionData.CharacterSelected1.Salud;
                            }

                            if ((SelectionData.CharacterSelected2.SaludActual + card.AmountToHealToAlly) <= SelectionData.CharacterSelected2.Salud)
                            {

                                SelectionData.CharacterSelected2.SaludActual += card.AmountToHealToAlly;
                            }
                            else
                            {
                                SelectionData.CharacterSelected2.SaludActual = SelectionData.CharacterSelected2.Salud;
                            }

                                 
                            
                            
                            SelectionData.CharacterSelected1.SaludActual += card.AmountToProtect;                       
                            SelectionData.CharacterSelected2.SaludActual += card.AmountToProtect;


                        }

                        if (card.BadResultOnPair)
                        {
                            int flipCoin = rng.Next(1, 1000) % 2;
                            if (flipCoin == 1) //badresult y hacer daño
                            {

                                SelectionData.CharacterSelected1.SaludActual -= card.DamageOnBadResult;
                                SelectionData.CharacterSelected2.SaludActual -= card.DamageOnBadResult;


                            }
                        }

                        tmanager.RefreshCharacterData();
                            resolved = true;



                    }


                    if (resolved)
                    {
                        tmanager.AjustaEnergia(card.Energy);
                        Destroy(this.gameObject);
                    }

                    tmanager.checkIfWin();

                }

              


                dragging = false;
                
                 da.OnEndDrag();


            


            }
            else
            {
                dragging = false;
                da.OnEndDrag();

            }



        }
    }

    // returns mouse position in World coordinates for our GameObject to follow. 
    private Vector3 MouseInWorldCoords()
    {
        var screenMousePos = Input.mousePosition;
        //Debug.Log(screenMousePos);
        screenMousePos.z = zDisplacement;
        return Camera.main.ScreenToWorldPoint(screenMousePos);
    }




}
