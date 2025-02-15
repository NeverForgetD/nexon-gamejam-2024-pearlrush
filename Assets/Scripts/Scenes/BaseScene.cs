//using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour//MonoBehaviourPunCallbacks
{
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown;

    [SerializeField] UI_Scene _sceneUI;
    public UI_Scene SceneUI { get => _sceneUI; set => _sceneUI = value; }

    protected virtual void Init()
    {
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null)
        {
            Managers.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
        }
    }

    public abstract void Clear();
}