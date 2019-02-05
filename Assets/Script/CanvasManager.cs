using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    [Header("GameObject Canvas UI")]
    public GameObject UIMenu;
    public GameObject UIInGame;
    public GameObject UIGameOver;

    
    public enum UISTAGE{ Menu, InGame, GameOver};
    private UISTAGE currentUISTAGE = UISTAGE.Menu;

    public UISTAGE CurrentUISTAGE { get => currentUISTAGE; set => currentUISTAGE = value; }

    void Start(){
        UIMenu.SetActive(false);
        UIInGame.SetActive(false);
        UIGameOver.SetActive(false);

    }

    void Update(){
        switch(CurrentUISTAGE){
            case UISTAGE.Menu:{
                FuncUIMenu();
                break;
            }
            case UISTAGE.InGame:{
                FuncUIIngame();
                break;
            }
            case UISTAGE.GameOver:{
                FuncUIGameOver();
                break;
            }
        }

    }

    #region Function of STAGE UI
    void FuncUIMenu(){
        if(GameController.controller.CurrentSTATE == GameController.STATE.MENU){
            UIMenu.SetActive(true);
            UIInGame.SetActive(false);
            UIGameOver.SetActive(false);
        }
        
    }

    void FuncUIIngame(){
        if(GameController.controller.CurrentSTATE == GameController.STATE.PLAYING){
            UIInGame.SetActive(true);
            UIMenu.SetActive(false);
            UIGameOver.SetActive(false);
        }
    }
    
    void FuncUIGameOver(){
        if(GameController.controller.CurrentSTATE == GameController.STATE.END){
            UIGameOver.SetActive(true);
            UIMenu.SetActive(false);
        }
    }
    #endregion

    #region Button
    public void BtnPlay(){
        GameController.controller.CurrentSTATE = GameController.STATE.PLAYING;
        CurrentUISTAGE = UISTAGE.InGame;
    } 
    public void BtnQuit(){
        Application.Quit();
    }
    public void BtnRePlay(){
        GameController.controller.CurrentSTATE = GameController.STATE.MENU;
        CurrentUISTAGE = UISTAGE.Menu;
    }
    #endregion
}
