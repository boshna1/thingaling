using System.Collections.Generic;
using UnityEngine;

public static class Global_Values
{
    public static float ArenaLength = 27f;
    public static float ArenaWidth = 27f;
    public enum Direction { Left, Right, Up, Down, D_UpLeft, D_UpRight, D_DownLeft, D_DownRight, Custom }
    public static float playerBaseSoul = 4;
    public static float playerBaseRepel = 1;
    public static float playerBaseAssault = 7;
    public static float playerBaseAct = 1;
    public static float playerBaseSpirit = 25;

    public static float currentBossSoul;
    public static float currentBossAssault;
    public static float currentBossRepel;
    public static float currentBossAct;


    public static float[] CalculateAllPlayerStats()// 0 = hp | 1 = ATK | 2 = DEF | 3 = SPD
    {
        float[] tempArray = new float[4];
        tempArray[0] = CalculatePlayerHP();
        tempArray[1] = CalculatePlayerATK();
        tempArray[2] = CalculatePlayerDEF();
        tempArray[3] = CalculatePlayerSPD();
        return tempArray;
    }

    public static float[] CalculateAllCurrentBossStats(float difficultyModifier) // 0 = hp | 1 = ATK | 2 = DEF | 3 = SPD
    {
        float[] tempArray = new float[4];
        tempArray[0] = CalculateBossHP(difficultyModifier);
        tempArray[1] = CalculateBossATK(difficultyModifier);
        tempArray[2] = CalculateBossDEF(difficultyModifier);
        tempArray[3] = CalculateBossSPD(difficultyModifier);
        return tempArray;
    }

    public static float CalculatePlayerHP()
    {
        float playerBaseHP = 0;
        for (int i = 0; i < playerBaseSoul; i++)
        {
            if (i < 10)
            {
                playerBaseHP += 25;
            }
            else if (i < 35)
            {
                playerBaseHP += 15;
            }
            else
            {
                playerBaseHP += 5;
            }
        }
        return playerBaseHP;
    }

    public static float CalculatePlayerATK()
    {
        float playerBaseATK = 0;
        for (int i = 0; i < playerBaseAssault; i++)
        {
            if (i < 15)
            {
                playerBaseATK += 1;
            }
            else if (i < 30)
            {
                playerBaseATK += 0.5f;
            }
            else
            {
                playerBaseATK += 0.2f;
            }
        }
        return playerBaseATK;

    }

    public static float CalculatePlayerDEF()
    {
        float playerBaseDEF = 0;
        for (int i = 0; i < playerBaseRepel; i++)
        {
            if (i < 15)
            {
                playerBaseDEF += 1;
            }
            else if (i < 30)
            {
                playerBaseDEF += 0.5f;
            }
            else
            {
                playerBaseDEF += 0.2f;
            }
        }
        return playerBaseDEF;

    }
    public static float CalculatePlayerSPD()
    {
        float playerBaseSPD = 50;
        for (int i = 0; i < playerBaseAct; i++)
        {
            if (i < 10)
            {
                playerBaseSPD += 5;
            }
            else if (i < 25)
            {
                playerBaseSPD += 2.5f;
            }
            else
            {
                playerBaseSPD += 1f;
            }
        }
        return playerBaseSPD;

    }

    public static float CalculateBossHP(float difficultyModifier)
    {
        float tempHP = 0;
        for (int i = 0; i < Mathf.Round(currentBossSoul * difficultyModifier); i++)
        {
            if (i < 10)
            {
                tempHP += 25;
            }
            else if (i < 35)
            {
                tempHP += 15;
            }
            else
            {
                tempHP += 5;
            }
        }
        return tempHP;
    }

    public static float CalculateBossATK(float difficultyModifier)
    {
        float tempATK = 0;
        for (int i = 0; i < Mathf.Round(currentBossAssault * difficultyModifier); i++)
        {
            if (i < 15)
            {
                tempATK += 1;
            }
            else if (i < 30)
            {
                tempATK += 0.5f;
            }
            else
            {
                tempATK += 0.2f;
            }
        }

        return tempATK;
    }

    public static float CalculateBossDEF(float difficultyModifier)
    {
        float tempDEF = 0;
        for (int i = 0; i < Mathf.Round(currentBossRepel * difficultyModifier); i++)
        {
            if (i < 15)
            {
                tempDEF += 1;
            }
            else if (i < 30)
            {
                tempDEF += 0.5f;
            }
            else
            {
                tempDEF += 0.2f;
            }
        }
        return (tempDEF);

    }
    public static float CalculateBossSPD(float difficultyModifier)
    {
        float tempSPD = 0;
        for (int i = 0; i < Mathf.Round(currentBossAct * difficultyModifier); i++)
        {
            if (i < 10)
            {
                tempSPD += 5;
            }
            else if (i < 25)
            {
                tempSPD += 2.5f;
            }
            else
            {
                tempSPD += 1f;
            }
        }
        return tempSPD;

    }
}
