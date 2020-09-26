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
    
    [SerializeField] private string _playerName ="Jacky";

    internal bool _isReady = false;
    internal bool _hasBet = false;


    private int _nDiceRange = 5;    //The total numbers of dices the player have
    private List<int> _pDice;      //The list of the dices that the player roll(values)
    [SerializeField] private List<DieController> _diceObjs;

    [SerializeField] private int _gold = 100;       //Later Use : Control the max rounds (-10g / round)
    private int _currentBet = 10;       // gold cost / round

    private PlayerHUD _playerHUD;
    private RoundController _roundController;

    #endregion

    #region GameMainFuctions
    private void Awake()
    {
        _playerHUD = GetComponent<PlayerHUD>();
        _roundController = FindObjectOfType<RoundController>();
        
    }
    void Start()
    {
        //Add listener to buttons via script to avoid our dump stupid brain to set them manualy...
        _playerHUD._readyBtn.onClick.AddListener(SetReadyAction);
        _playerHUD._goldeBtn.onClick.AddListener(BetGoldActionOnClick);
        _playerHUD._diceRollBtn.onClick.AddListener(RollDiceAction);


        _gold = 100;
        _currentBet = 10;

        //Initialize Player 
        Init();
    }
    void Update()
    {
        
    }
    #endregion

    //TEST: usage = for test perpose is used as reset fuction as well
    void Init()
    {
        //_gold = 100;
        //_currentBet = 10;
        _playerHUD.UpdateGoldText(_gold);


        _isReady = false;
        _hasBet = false;
    }

    #region PlayerActionsMethods

    public void BetGoldActionOnClick()
    {
        if(_gold >= _currentBet)
        {
            _gold -= _currentBet;
            _playerHUD.UpdateGoldText(_gold);

            _hasBet = true;
            //_roundController.SetGoldBet(true);
            //Debug.Log("GOLD : " + _gold);
        }
        else
        {
            _hasBet = false;
            //roundController.SetGoldBet(false);
            //Debug.Log("Not enough GOLD : " + _gold);
        }
        _playerHUD.UpdateBetActionParameters();
    }

    public void SetReadyAction()
    {
        _isReady = true;

        _playerHUD.UpdateReadyActionParemeters();
    }

    public void RollDiceAction()
    {
        //Calculate and copy the RNG dices List from the ROundController
        _pDice = _roundController.CreateRNGDiceList(_nDiceRange);

        _playerHUD.DisplayDicesUI(_pDice);

        for(int i = 0; i < _diceObjs.Count; i++)
        {
            //Rotate Dice
            _diceObjs[i].RotateToFace(_pDice[i]);
        }


        //RESET USE
        Init();
    }


    //Later Use
    private void LiarAction()
    {
        Debug.Log("Liar action has done");
    }

    private void CallAction()
    {
        Debug.Log("Call action has done");
    }

    private void LoseDie()
    {
        _diceObjs[0].HideDie();
        _diceObjs.RemoveAt(0);
    }
    #endregion

}
