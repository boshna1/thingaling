using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static Global_Values;

public class v1_BatterUp : MonoBehaviour
{
    [SerializeField] Object_Pool objectPool;
    [SerializeField] List<v1_BatterUp_Object> tuto_BU = new List<v1_BatterUp_Object>();
    bool phase2;
    int cycles;
    int phase2ModPos;
    bool Setup;
    int cannotBe = -2;
    int randomQuadrant;
    float randomRot;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Execute();
        }
        if (Setup)
        {
            foreach (v1_BatterUp_Object obj in tuto_BU)
            {
                do
                {
                    randomQuadrant = Random.Range(-1, 2);
                } while (randomQuadrant == cannotBe);
                if (cannotBe == -2)
                {
                    cannotBe = randomQuadrant;
                }
                Vector3 scale = new Vector3(1, 1, 1);
                Vector3 tempPos = new Vector3((ArenaLength / 3 * randomQuadrant), 0.5f, (ArenaLength / 3 * randomQuadrant) * phase2ModPos);
                Vector3 tempRot = new Vector3(0, 90, 0);
                Vector3 tempScale = scale;
                obj.SetParameters(tempRot, tempScale, tempPos, 0.5f, 0.25f, false, 2f);
            }

            foreach (v1_BatterUp_Object TBTI in tuto_BU)
            {
                TBTI.Execute();
                objectPool.v1_BU_Objects.Add(TBTI);
            }
            tuto_BU.Clear();
            Setup = false;
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
                foreach (v1_BatterUp_Object obj in objectPool.v1_BU_Objects)
                {
                    if (!obj.isActive)
                    {
                        v1_BatterUp_Object tempObj = objectPool.Callv1BU();
                        tuto_BU.Add(tempObj);
                        tempObj = null;
                        i++;
                        break;
                    }
                }
            }
            Setup = true;
        }

    }
}
