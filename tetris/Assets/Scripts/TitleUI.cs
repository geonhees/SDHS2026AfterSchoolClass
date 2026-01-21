using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : TitleCommanderChildBase
{
    [SerializeField]
    public Button _startButton;

    public override void Initialize(CommanderBase commander)
    {
        base.Initialize(commander);
        _startButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        if (_commander is TitleCommander title)
        {
            title.StartGame();
        }
    }
}
