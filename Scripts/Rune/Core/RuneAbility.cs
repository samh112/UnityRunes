using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuneAbility : ScriptableObject
{  
    public abstract void Activate(GameObject parent);

    public abstract void Deactivate(GameObject parent);

    public abstract void RetrieveInfo();
}
