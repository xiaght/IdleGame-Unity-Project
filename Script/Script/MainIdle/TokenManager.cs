using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour
{
    public GameManager gm;
    public ulong totalValue;

    private void Start()
    {

    }

    public void SendTimeValue(ulong value) {

        gm.SetTimeValue(value);
    }
    public void SendGoldUse(ulong value) {

        gm.SetGold(value);
    }
}
