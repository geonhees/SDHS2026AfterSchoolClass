using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ManagerBase : MonoBehaviour
{
    //추상화 클래스라서 GameManager에서 우회해서 호출
    public virtual void Initialize()
    {
        Debug.Log($"{GetType().Name} Initialized");
    }
}
