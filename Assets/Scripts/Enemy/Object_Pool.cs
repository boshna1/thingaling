using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Object_Pool : MonoBehaviour
{
    public List<BackToIt_Object> BTI_Objects = new List<BackToIt_Object>();
    public List<v3_BatterUp_Object> v3_BU_Objects = new List<v3_BatterUp_Object>();
    public List<v1_BatterUp_Object> v1_BU_Objects = new List<v1_BatterUp_Object>();
    public List<v3_BackToIt_Object> v3_BTI_Objects = new List<v3_BackToIt_Object>();
    public List<v3_BackToIt_Object> v2_BTI_Objects = new List<v3_BackToIt_Object>();

    public BackToIt_Object CallBTI()
    {
        foreach (BackToIt_Object bti in BTI_Objects)
        {
            if (!bti.isActive)
            {
                BTI_Objects.Remove(bti);
                return bti;
            }
        }
        return null;
    }
    public v3_BatterUp_Object Callv3BU()
    {
        foreach (v3_BatterUp_Object bti in v3_BU_Objects)
        {
            if (!bti.isActive)
            {
                v3_BU_Objects.Remove(bti);
                return bti;
            }
        }
        return null;
    }

    public v1_BatterUp_Object Callv1BU()
    {
        foreach (v1_BatterUp_Object bti in v1_BU_Objects)
        {
            if (!bti.isActive)
            {
                v1_BU_Objects.Remove(bti);
                return bti;
            }
        }
        return null;
    }

    public v3_BackToIt_Object Callv3BTI()
    {
        foreach (v3_BackToIt_Object bti in v3_BTI_Objects)
        {
            if (!bti.isActive)
            {
                v3_BTI_Objects.Remove(bti);
                return bti;
            }
        }
        return null;
    }
}
