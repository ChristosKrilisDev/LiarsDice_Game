using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This Class will handle the actions that the player can do in game,
/// Also, this class will communicate with the server to send and resive data
/// </summary>

[RequireComponent(typeof(PlayerHUD))]
public class PlayerController : MonoBehaviour
{

    #region Members
    [SerializeField] private string _playerName = "Jacky";

    private List<int> _pDice;      //The list of the dices that the player roll(values)
    [Header("In game dice Objs ")]
    [SerializeField] private List<DieController> _diceObjs; //In-game dice objects


    [Header("Bet Members")]
    [SerializeField] private int _betAmmount = 1;
    [SerializeField] private int _betNumber = 1;


    private PlayerHUD _playerHUD;
    private RoundController _roundController;

    #endregion

    #region GameMainFuctions
    private void Awake()
    {
        _playerHUD = GetComponent<PlayerHUD>();
        _roundController = FindObjectOfType<RoundController>();

        Init();
    }
    void Start()
    {

    }
    void Update()
    {
        if(HasLostAllDice())
            Debug.Log("dead men tell no tails");

        if(Input.GetKeyDown(KeyCode.Q))
        {
            LoseDie();
        }
    }
    #endregion

    void Init()
    {
        _playerHUD.ActivateAll();
        //Add listener to buttons via script to avoid our dump stupid brain to set them manualy...
        _playerHUD._diceRollBtn.onClick.AddListener(RollDiceAction);

        //Bet Btns Listeners
        //This format is also for multi fuctions insert
        _playerHUD._increaseAmountBtn.onClick.AddListener(() => { IncreaseAmount(true); });
        _playerHUD._dicreaseAmountBtn.onClick.AddListener(() => { IncreaseAmount(false); });

        _playerHUD._increaseNumberBtn.onClick.AddListener(() => { IncreaseNumber(true); });
        _playerHUD._dicreaseNumberBtn.onClick.AddListener(() => { IncreaseNumber(false); });

        _playerHUD._betBtn.onClick.AddListener(BetActionClick);
    }

    #region PlayerActionsMethods

    public void RollDiceAction()
    {
        //Calculate and copy the RNG dices List from the RoundController
        //return a list ot _pDice
        _pDice = _roundController.CreateRNGDiceList(_diceObjs.Count);

        _playerHUD.DisplayDiceUI(_pDice);

        for(int i = 0; i < _diceObjs.Count; i++)
        {
            //Rotate Dice
            _diceObjs[i].RotateToFace(_pDice[i]);
        }

        //Hide BTN
        _playerHUD._diceRollBtn.gameObject.SetActive(false);
        _playerHUD.ActivateActionsUI();
    }

    //Player actions
    private void Challenge()
    {
        Debug.Log("Liar action has done");
    }

    #region BetMethods

    /// <summary>
    /// RULES : Increase amount only towards + , So we need to know the last bet
    ///         Increase number with the same amount
    ///         Increase amount and change any number(1-6)
    ///         
    /// </summary>

    private void IncreaseAmount(bool IncreaseModifier)
    {
        if(IncreaseModifier)
            _betAmmount++;
        else if(!IncreaseModifier)
            if(_betAmmount - 1 > 0)     //Only abs values
                _betAmmount--;

        _playerHUD.UpdateAmountText(_betAmmount , _betNumber);
    }
    private void IncreaseNumber(bool IncreaseModifier)
    {
        if(IncreaseModifier)
        {
            if(_betNumber <= 5 && _betNumber != 6)
                // cant run this code with value 6 and above
                _betNumber++;
        }
        else if(!IncreaseModifier)
            if(_betNumber >= 2 && !IncreaseModifier)
                _betNumber--;

        _playerHUD.UpdateAmountText(_betAmmount , _betNumber);
    }
    private void BetActionClick()
    {
        _playerHUD.OnBetActionClick();
        _playerHUD.UpdateBetText(_betAmmount , _betNumber);
        //Debug.Log("#Player# You bet , Amount : " + _betAmmount + " and Number : " + _betNumber);
    }
    #endregion
    #endregion
    //Whoever Lose a challenge lose a die and become the first player in next round
    private void LoseDie()
    {
        Debug.Log("you lose 1 Die");
        //remove a die
        _diceObjs[0].HideDie();
        _diceObjs.RemoveAt(0);

        //Update UI
        _playerHUD.UpdateDiceSlots(_diceObjs.Count);
    }
    private bool HasLostAllDice()
    {
        if(_diceObjs.Count == 0)
        {
            Debug.Log("No more dice for you mate");
            _playerHUD.OpenLosePanel();
        }

        bool x = _diceObjs.Count >= 1;
        return !x;
    }
}
