using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class ObjectSCUtilityScript 
{
    // Start is called before the first frame update
 public static void CreateAsset<T>() where T : ScriptableObject
    {
        //var assetToCreate = ScriptableObject.CreateInstance<T>();
        //ProjectWindowUtil.CreateAsset(assetToCreate, "New " + typeof(T).Name + ".asset");

    }
}
