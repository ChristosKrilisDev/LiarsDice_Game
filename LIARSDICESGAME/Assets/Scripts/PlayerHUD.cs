using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    [SerializeField] private Transform _slotsHolder;
    [SerializeField] private /*readonly*/ GameObject[] _diceSlotsUi;
    [SerializeField] private List<GameObject> _diceSlotCopy;

    [Space]
    [Header("Start Members/First Phase")]
    [SerializeField] internal Button _readyBtn;
    [SerializeField] private GameObject _introBorder;
    [SerializeField] internal Button _diceRollBtn;

    [Space]
    [Header("Actions Members")]
    [SerializeField] private Button betActionBtn, challengeBtn;
    [SerializeField] private GameObject betPanel;
    [SerializeField] private GameObject _roundBorder, _actionsHolder;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Image _betInfoImg;

    [Space]
    [Header("Bet Members")]
    [SerializeReference] private GameObject _betConfimBorder;
    [SerializeField] private Text _amountTxt;
    [SerializeField] internal Button _increaseAmountBtn, _dicreaseAmountBtn;
    [SerializeField] private Text _numberTxt;
    [SerializeField] internal Button _increaseNumberBtn, _dicreaseNumberBtn;
    [SerializeField] internal Button _betBtn;

    #endregion

    void Start()
    {
        //Copy the arrray of slots to the diceList so we can mod it easier
        _diceSlotCopy = new List<GameObject>(_diceSlotsUi);
        Init();
    }

    internal void Init()
    {
        _readyBtn.onClick.AddListener(OnReadyClick);

        betActionBtn.onClick.AddListener(OnBetActionClick);

        UpdateAmountText(1 , 1);


        //Set up
        _introBorder.gameObject.SetActive(true);

        _diceRollBtn.gameObject.SetActive(false);
        _slotsHolder.gameObject.SetActive(false);
        _roundBorder.gameObject.SetActive(false);
        _betConfimBorder.gameObject.SetActive(false);
        _actionsHolder.gameObject.SetActive(false);
        _losePanel.gameObject.SetActive(false);
        _betInfoImg.gameObject.SetActive(false);
    }

    internal void ActivateAll()
    {
        _introBorder.gameObject.SetActive(true);

        _diceRollBtn.gameObject.SetActive(true);
        _slotsHolder.gameObject.SetActive(true);
        _roundBorder.gameObject.SetActive(true);
        _betConfimBorder.gameObject.SetActive(true);
        _actionsHolder.gameObject.SetActive(true);
        _losePanel.gameObject.SetActive(true);
        _betInfoImg.gameObject.SetActive(true);
    }


    //This will show only once : first phase
    private void OnReadyClick()
    {
        _introBorder.gameObject.SetActive(false);
        //Show roll dice btn : second phase
        StartSecondPhase();

    }

    private void StartSecondPhase()
    {
        _diceRollBtn.gameObject.SetActive(true);
        _slotsHolder.gameObject.SetActive(true);
        //_actionsHolder.gameObject.SetActive(true);
    }

    internal void ActivateActionsUI()
    {
        _actionsHolder.gameObject.SetActive(true);
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

    internal void OnBetActionClick()
    {
        if(betPanel.activeInHierarchy)
            betPanel.SetActive(false);
        else
            betPanel.SetActive(true);
    }

    internal void OpenLosePanel()
    {
        _losePanel.gameObject.SetActive(true);
    }

    internal void UpdateBetText(int amount , int number)
    {
        _betInfoImg.gameObject.SetActive(true);
        Text betTxt = _betInfoImg.transform.GetChild(0).GetComponent<Text>();
        betTxt.text = "You Bet : Amount" + amount + " and Number" + number;
    }

}
