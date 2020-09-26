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
    [Header("Dice Number Slots")]
    [Tooltip("Add slots that hold the current value for each rolled dice")]
    //[SerializeField] private Transform _slotsHolder;
    [SerializeField]private /*readonly*/ GameObject[] _diceSlotsUi;
    [SerializeField]private List<GameObject> _diceSlotCopy;

    [Header("Start Members")]
    [SerializeField]internal Button _readyBtn;
    [SerializeField]internal Button _diceRollBtn;

    [Header("Bet Members")]
    [SerializeReference]private GameObject _betConfimBorder;
    [Space]
    [SerializeField] private Text _amountTxt;
    [SerializeField] internal Button _increaseAmountBtn, _dicreaseAmountBtn;
    [Space]
    [SerializeField] private Text _numberTxt;
    [SerializeField] internal Button _increaseNumberBtn, _dicreaseNumberBtn;
    [Space]
    [SerializeField] internal Button _betBtn;
    
    #endregion

    void Start()
    {
        //Copy the arrray of slots to the diceList so we can mod it easier
        _diceSlotCopy = new List<GameObject>(_diceSlotsUi);
        Init();
    }

    //TEST: usage = for test perpose is used as reset fuction as well
    internal void Init()
    {
        //_diceSlotsUi = _slotsHolder.GetChildCount();
        //_diceSlotCopy = (List<GameObject>)_diceSlotsUi.Clone();
        UpdateAmountText(1 , 1);
    }

    internal void DisplayDiceUI(List<int> dice)
    {
        for(int i = 0; i < dice.Count; i++)
            _diceSlotCopy[i].GetComponentInChildren<Text>().text = dice[i].ToString();
    }

    internal void UpdateDiceSlots(int currentDiceRange)
    {
        if(_diceSlotCopy.Count > currentDiceRange)
        {
            //Activate the BLOCK Img from that die slot
            _diceSlotCopy[0].transform.GetChild(1).GetComponent<Image>().gameObject.SetActive(true);
            _diceSlotCopy[0].GetComponentInChildren<Text>().text = null;
            //and then remove it from the slot list
            _diceSlotCopy.RemoveAt(0);

        }
    }

    //internal void UpdateGoldText(int newGoldValue) => 
    //    _goldTxt.text = newGoldValue.ToString();

    internal void UpdateReadyActionParemeters()
    {

        Debug.Log("Pressed Ready...");

        //_readyBtn.interactable = false;
        //_diceRollBtn.interactable = true;

    }

    internal void UpdateBetActionParameters()
    {
        Debug.Log("Pressed Bet...");
        //_goldeBtn.interactable = false;
        //_readyBtn.interactable = true;
    }

    internal void UpdateAmountText(int newAmountValue , int newNumberValue)
    {
        _amountTxt.text = newAmountValue.ToString();
        _numberTxt.text = newNumberValue.ToString();
    }


}
