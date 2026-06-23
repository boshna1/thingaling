using System.Collections.Generic;
using UnityEngine;
using static Global_Values;

public class v3_BatterUp : MonoBehaviour
{
    [SerializeField] Object_Pool objectPool;
    [SerializeField] List<v3_BatterUp_Object> v3_BU = new List<v3_BatterUp_Object>();
    bool phase2;
    int cycles;
    int phase2ModPos;
    bool Setup;
    int cannotBe = -2;
    float cannotBeRot = -2;
    int randomQuadrant;
    float randomRot;
    int v2Mod = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Execute();
        }
        if (Setup)
        {
            foreach (v3_BatterUp_Object obj in v3_BU)
            {
                do
                {
                    randomQuadrant = Random.Range(-1, 2);
                    randomRot = (Random.value < 0.5f) ? 0 : 90;
                    if (randomQuadrant == -1 || randomQuadrant == 1)
                    {
                        randomRot = 90;
                    }

                } while (randomQuadrant == cannotBe && randomRot == cannotBeRot);
                if (cannotBe == -2 && cannotBeRot == -2)
                {
                    cannotBe = randomQuadrant;
                    cannotBeRot = randomRot;
                }
                Debug.Log(randomQuadrant + " " + randomRot);
                Vector3 scale = new Vector3(1, 1, 1);
                Vector3 tempPos = new Vector3((ArenaLength / 3 * randomQuadrant), 0.5f, (ArenaLength / 3 * randomQuadrant) * v2Mod);
                Vector3 tempRot = new Vector3(0, randomRot, 0);
                Vector3 tempScale = scale;
                obj.SetParameters(tempRot, tempScale, tempPos, 0.5f, 0.25f, false, 2.5f);
            }

            foreach (v3_BatterUp_Object BU in v3_BU)
            {
                BU.Execute();
                objectPool.v3_BU_Objects.Add(BU);
            }
            v3_BU.Clear();
            Setup = false;
            randomRot = -2;
            randomQuadrant = -2;
        }
    }

    public void Execute()
    {
        int randomAmount = Random.Range(1, 3);
        Vector3 scale = new Vector3(1, 1, 1);
        randomRot = (Random.value < 0.5f) ? 0 : 90;
        Debug.Log(randomAmount);
        for (int i = 0; i < randomAmount;)
        {
            if (!phase2)
            {
                foreach (v3_BatterUp_Object obj in objectPool.v3_BU_Objects)
                {
                    if (!obj.isActive)
                    {
                        v3_BatterUp_Object tempObj = objectPool.Callv3BU();
                        v3_BU.Add(tempObj);
                        tempObj = null;
                        i++;
                        break;
                    }
                }
            }
            Setup = true;
        }

    }

    public void SetV2()
    {
        v2Mod = 1;
    }
}
