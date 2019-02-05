using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region contructions
    public static GameController controller;
    void Awake(){
        if(controller != null)
        {
            return;
        }
        controller = this;
    }
    #endregion
    
    [Header("Array of Transform")]
    public Transform[] Images;

    public enum STATE{MENU, PLAYING, END};
    private STATE currentSTATE = STATE.MENU;

    public STATE CurrentSTATE { get => currentSTATE; set => currentSTATE = value; }

    void Update(){
        switch(CurrentSTATE){
            case STATE.MENU:{

                break;
            }
            case STATE.PLAYING:{
                FuncStatePlaying();
                break;
            }
            case STATE.END:{

                break;
            }
        }
        print(CurrentSTATE);
    }

    void FuncStatePlaying(){
        if(Images[0].rotation.z == 0 &&
        Images[1].rotation.z == 0 &&
        Images[2].rotation.z == 0 &&
        Images[3].rotation.z == 0 &&
        Images[4].rotation.z == 0 &&
        Images[5].rotation.z == 0 &&
        Images[6].rotation.z == 0 &&
        Images[7].rotation.z == 0 
        ){
            currentSTATE = STATE.END;
            CanvasManager.FindObjectOfType<CanvasManager>().CurrentUISTAGE = CanvasManager.UISTAGE.GameOver;
        }
    }

}
