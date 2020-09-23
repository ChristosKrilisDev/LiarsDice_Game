using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controlls the User Interface and Update it
/// Controll Only the HUD (heads-up display) , the player UI Like Gold, his own dices etc.
/// </summary>
public class PlayerHUD : MonoBehaviour
{

    #region Members
    [Header("Dice Number Slots")][Tooltip("Add slots that hold the current value for each rolled dice")]
    public GameObject[] _diceSlotsUi;

    [Header("Texts")]
    [SerializeField] private Text _goldTxt;

    [Header("Buttons")]
    [SerializeField]internal Button _goldeBtn;
    [SerializeField]internal Button _readyBtn;
    [SerializeField]internal Button _diceRollBtn;

    #endregion

    void Start()
    {

        Init();
    }

    //TEST: usage = for test perpose is used as reset fuction as well
    internal void Init()
    {
        _goldeBtn.interactable = true;
        _readyBtn.interactable = false;
        _diceRollBtn.interactable = false;
    }

    internal void DisplayDicesUI(List<int> dices)
    {
        for(int i = 0; i < dices.Count; i++)
            _diceSlotsUi[i].GetComponentInChildren<Text>().text = dices[i].ToString();

        Init();
    }

    internal void UpdateGoldText(int newGoldValue) => 
        _goldTxt.text = newGoldValue.ToString();


    internal void UpdateReadyActionParemeters()
    {

        Debug.Log("Pressed Ready...");

        _readyBtn.interactable = false;
        _diceRollBtn.interactable = true;

    }

    internal void UpdateBetActionParameters()
    {
        Debug.Log("Pressed Bet...");
        _goldeBtn.interactable = false;
        _readyBtn.interactable = true;
    }



}
