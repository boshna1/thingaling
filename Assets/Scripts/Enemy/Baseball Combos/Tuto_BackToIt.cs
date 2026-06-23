using UnityEngine;
using static Global_Values;
using System.Collections.Generic;

public class Tuto_BackToIt : MonoBehaviour
{
    [SerializeField] Object_Pool objectPool;
    [SerializeField] List<BackToIt_Object> v1_BTI = new List<BackToIt_Object>();
    bool phase2;
    int cycles;
    int phase2ModPos;
    bool Setup;

    int v2Mod = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Execute();
        }
        if (Setup)
        {
            float randomScale = (Random.value < 0.5f) ? -1 : 1;
            foreach (BackToIt_Object obj in v1_BTI)
            {
                Vector3 scale = new Vector3(1, 1, randomScale);
                Vector3 tempScale = scale;
                Vector3 pos = new Vector3(0, 0, 0);
                obj.SetParameters(pos, tempScale, 0.5f, 0.25f, false, 3.6f);
            }

            foreach (BackToIt_Object TBTI in v1_BTI)
            {
                TBTI.Execute();
                objectPool.BTI_Objects.Add(TBTI);
            }
            v1_BTI.Clear();
            Setup = false;
        }
    }

    public void Execute()
    {
        Vector3 scale = new Vector3(1, 1, 1);

        foreach (BackToIt_Object obj in objectPool.BTI_Objects)
        {
            if (!obj.isActive)
            {
                BackToIt_Object tempObj = objectPool.CallBTI();
                v1_BTI.Add(tempObj);
                tempObj = null;
                break;
            }
        }
        Setup = true;

    }

    public void SetV2()
    {
        v2Mod = 1;
    }
}
