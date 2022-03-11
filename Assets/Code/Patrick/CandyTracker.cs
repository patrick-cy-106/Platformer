using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyTracker : MonoBehaviour
{
    public int currLvl;
    public int candyNum;



    private void Start() {
        candyNum--;
    }

    private void OnDestroy() 
    {
        switch (currLvl)
        {
            case 1 when PublicVars.isAlive:
                if (PublicVars.levelOneCandy[candyNum] != 1)
                {
                    PublicVars.itemsCollected[currLvl-1]++;
                }
                PublicVars.levelOneCandy[candyNum] = 1;
                break;

            case 2 when PublicVars.isAlive:
                if (PublicVars.levelTwoCandy[candyNum] != 1)
                {
                    PublicVars.itemsCollected[currLvl-1]++;
                }
                PublicVars.levelTwoCandy[candyNum] = 1;
                break;

            case 3 when PublicVars.isAlive:
                if (PublicVars.levelThreeCandy[candyNum] != 1)
                {
                    PublicVars.itemsCollected[currLvl-1]++;
                }
                PublicVars.levelThreeCandy[candyNum] = 1;
                break;

            case 4 when PublicVars.isAlive:
                if (PublicVars.levelFourCandy[candyNum] != 1)
                {
                    PublicVars.itemsCollected[currLvl-1]++;
                }
                PublicVars.levelFourCandy[candyNum] = 1;
                break;

            case 5 when PublicVars.isAlive:
                if (PublicVars.levelFiveCandy[candyNum] != 1)
                {
                    PublicVars.itemsCollected[currLvl-1]++;
                }
                PublicVars.levelFiveCandy[candyNum] = 1;
                break;
        }
    }
}
