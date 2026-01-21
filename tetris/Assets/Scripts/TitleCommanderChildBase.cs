using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TitleCommanderChildBase : CommanderChildBase
{
    protected CommanderBase _titleCommander;

    public override void Initialize(CommanderBase commander)
    {
        base.Initialize(commander);
        _titleCommander = commander as TitleCommander;
    }
}
