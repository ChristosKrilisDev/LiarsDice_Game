using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    //TODO
    //ALOT!
    //:P
    public List<int> dicesvalues;

    internal List<int> CreateRNGDiceList(int dicesRange)
    {
        //Clear the oldest values, to prevent overflow
        dicesvalues.Clear();

        for(int i = 0; i < dicesRange; i++)
            dicesvalues.Add(RollDicesValues());

        return dicesvalues;
    }

    private int RollDicesValues() => Random.Range(1 , 7);


}
