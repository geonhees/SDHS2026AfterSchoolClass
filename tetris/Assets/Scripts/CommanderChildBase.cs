using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CommanderChildBase : MonoBehaviour
{
    protected CommanderBase _commander;

    public virtual void Initialize(CommanderBase commander)
    {
        _commander = commander;
    }
}
