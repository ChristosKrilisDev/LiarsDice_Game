using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Holds all the UI states and have activity fuctions
/// </summary>
public class UiGroupManager : MonoBehaviour
{

    private GameObject _introGroup, _onRollGroup, _gameMainGroup, _actionsBtnsGroup, _roundBorderGroup;


    public enum UISTATE
    {
        INTRO_STATE, 
        ROLL_STATE,
        MAIN_STATE,
        CHOOSEACTION_STATE,
        BET_STATE,
        CHALLENGE_STATE,
        LOSE_STATE,
        END_STATE
    }

    public UISTATE _uiSTATE = new UISTATE();

    private void Start()
    {
       _uiSTATE = UISTATE.INTRO_STATE;
    }


    private void UiGroupSwitcher()
    {
        switch(_uiSTATE)
        {
            case UISTATE.INTRO_STATE:
            break;
            case UISTATE.ROLL_STATE:
            break;
            case UISTATE.MAIN_STATE:
            break;
            case UISTATE.CHOOSEACTION_STATE:
            break;
            case UISTATE.BET_STATE:
            break;
            case UISTATE.CHALLENGE_STATE:
            break;
            case UISTATE.LOSE_STATE:
            break;
            case UISTATE.END_STATE:
            break;
            default:
            break;
        }
    }


    //public void SetUIState(UISTATE UiState) => UiGroupSwitcher(UiState);


    public void OpenIntro()
    {
        _uiSTATE = UISTATE.INTRO_STATE;
        UiGroupSwitcher();
    }

    public void OpenRollState()
    {
        _uiSTATE = UISTATE.ROLL_STATE;
        UiGroupSwitcher();
    }
    public void OpenMainState()
    {
        _uiSTATE = UISTATE.MAIN_STATE;
        UiGroupSwitcher();
    }



}
