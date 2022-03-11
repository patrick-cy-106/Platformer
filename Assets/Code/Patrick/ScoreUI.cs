using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreUI;
    public int currLvl;
    private void FixedUpdate() {
        switch (currLvl)
        {
            case 1:
                scoreUI.text = "Candy Collected: " + PublicVars.itemsCollected[currLvl-1] + "/1";
                break;

            case 2:
                scoreUI.text = "Candy Collected: " + PublicVars.itemsCollected[currLvl-1] + "/3";
                break;

            case 3:
                scoreUI.text = "Candy Collected: " + PublicVars.itemsCollected[currLvl-1] + "/1";
                break;

            case 4:
                scoreUI.text = "Candy Collected: " + PublicVars.itemsCollected[currLvl-1] + "/4";
                break;

            case 5:
                scoreUI.text = "Candy Collected: " + PublicVars.itemsCollected[currLvl-1] + "/4";
                break;
                

        }
    }
}
