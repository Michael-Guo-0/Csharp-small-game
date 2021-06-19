using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Database/FlyObject")]
public class PrefebFlyObject : ScriptableObject
{
    public Dictionary<int, GameObject> fly_obj_dict;
    
}
