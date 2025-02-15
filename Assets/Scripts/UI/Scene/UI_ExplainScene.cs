using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ExplainScene : UI_Scene
{
    [SerializeField] Button _startButton;
    public Button StartButton { get => _startButton; private set => _startButton = value; }
    public override void Init()
    {
        base.Init();
        GetComponent<Canvas>().sortingOrder += 1;
        if (StartButton == null)
            StartButton = GetComponentInChildren<Button>();
        StartButton.gameObject.AddUIEvent(OnClickStartButton);
    }

    public void OnClickStartButton(PointerEventData eventData)
    {
        Managers.Sound.Play("Sounds/SFX/UI_Button");
        if (Managers.Scene.AsyncLoadSceneOper != null)
        {
            if (Managers.Scene.AsyncLoadSceneOper.isDone || Managers.Scene.AsyncLoadSceneOper.progress >= 0.9f)
            {
                Managers.Scene.AsyncLoadSceneOper.allowSceneActivation = true;
            }
        }
    }

    public void OnClickedButton()
    {
        Managers.Sound.Play("Sounds/SFX/UI_Button");
        Managers.Scene.LoadScene(Define.Scene.GameScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
