using System.Collections.Generic;
using UnityEngine;

public class v3_BackToIt : MonoBehaviour
{
    [SerializeField] Object_Pool objectPool;
    [SerializeField] List<v3_BackToIt_Object> v3_BTI = new List<v3_BackToIt_Object>();
    bool phase2;
    int cycles;
    int phase2ModPos;
    bool Setup;

    int v2Mod = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Execute();
        }
        if (Setup)
        {
            float randomScale = (Random.value < 0.5f) ? -1 : 1;
            foreach (v3_BackToIt_Object obj in v3_BTI)
            {
                Vector3 scale = new Vector3(1, 1, randomScale);
                Vector3 tempScale = scale;
                Vector3 pos = new Vector3(0, 0, 0);
                obj.SetParameters(tempScale, pos, 0.5f, 0.25f, false, 3.6f);
            }

            foreach (v3_BackToIt_Object TBTI in v3_BTI)
            {
                TBTI.Execute();
                objectPool.v3_BTI_Objects.Add(TBTI);
            }
            v3_BTI.Clear();
            Setup = false;
        }
    }

    public void Execute()
    {
        foreach (v3_BackToIt_Object obj in objectPool.v3_BTI_Objects)
        {
            if (!obj.isActive)
            {
                v3_BackToIt_Object tempObj = objectPool.Callv3BTI();
                v3_BTI.Add(tempObj);
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
