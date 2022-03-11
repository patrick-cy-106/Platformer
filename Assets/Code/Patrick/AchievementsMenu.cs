using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementsMenu : MonoBehaviour
{
    public TextMeshProUGUI lvl_1;
    public TextMeshProUGUI lvl_2;
    public TextMeshProUGUI lvl_3;
    public TextMeshProUGUI lvl_4;
    public TextMeshProUGUI lvl_5;
    
    private void Start()
    {
        lvl_1.text = "Level 1 Candy Collected: " + PublicVars.itemsCollected[0] + "/1";
        lvl_2.text = "Level 2 Candy Collected: " + PublicVars.itemsCollected[1] + "/3";
        lvl_3.text = "Level 3 Candy Collected: " + PublicVars.itemsCollected[2] + "/1";
        lvl_4.text = "Level 4 Candy Collected: " + PublicVars.itemsCollected[3] + "/4";
        lvl_5.text = "Level 5 Candy Collected: " + PublicVars.itemsCollected[4] + "/4";
    }
}
