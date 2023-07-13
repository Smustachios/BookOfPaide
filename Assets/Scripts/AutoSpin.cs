using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Plays autospins.
/// </summary>
public class AutoSpin : MonoBehaviour
{
    public GameManager gameManager;
    public UIStrings uiStrings;
    public bool spinActive = false;

    private int _nOfAutoSpins = 0;
    public int NOfAutoSpins
    {
        get
        {
            return _nOfAutoSpins;
        }
        set
        {
            _nOfAutoSpins = value;

            // Update auto spin button text.
            if (value == 0)
            {
                uiStrings.UpdateAutospinsString("AUTO\nSPINS");
            }
            else
            {
                uiStrings.UpdateAutospinsString(_nOfAutoSpins.ToString());
            }
        }
    }

    // Start 50 spins if player presses auto spin button.
    public void AutoSpinButton()
    {
        NOfAutoSpins = 50;
    }

    // Game manager will change spin active to false at the end of the spin, if auto spins are still active
    // then start next spin.
    private void Update()
    {
        if (NOfAutoSpins > 0 && spinActive == false)
        {
            NOfAutoSpins--;
            gameManager.StartSpin();
        }
    }
}
