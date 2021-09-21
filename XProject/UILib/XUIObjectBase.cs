// Decompiled with JetBrains decompiler
// Type: XUIObjectBase
// Assembly: UILib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 98636226-A9CD-4398-A93A-F8649E3E05B4
// Assembly location: F:\龙之谷\Client\Assets\Lib\UILib.dll

using System.Runtime.CompilerServices;
using UILib;
using UnityEngine;

public abstract class XUIObjectBase : MonoBehaviour, IXUIObject
{
    private IXUIObject m_parent = (IXUIObject)null;
    private ulong m_id;
    private bool m_bExculsive = false;

    public virtual IXUIObject parent
    {
        get => this.m_parent;
        set => this.m_parent = value;
    }

    public ulong ID
    {
        get => this.m_id;
        set => this.m_id = value;
    }

    public bool Exculsive
    {
        get => this.m_bExculsive;
        set => this.m_bExculsive = value;
    }

    public bool IsVisible() => this.gameObject.activeInHierarchy;

    public virtual void SetVisible(bool bVisible) => this.gameObject.SetActive(bVisible);

    public virtual void OnFocus()
    {
        if (this.parent == null)
            return;
        this.parent.OnFocus();
    }

    public IXUIObject GetUIObject(string strName)
    {
        Transform child = this.transform.FindChild(strName);
        return (Object)null != (Object)child ? (IXUIObject)child.GetComponent<XUIObjectBase>() : (IXUIObject)null;
    }

    public virtual void Highlight(bool bTrue)
    {
    }

    protected virtual void OnPress(bool isPressed) => this.OnFocus();

    protected virtual void OnDrag(Vector2 delta) => this.OnFocus();

    public virtual void Init()
    {
    }

    protected virtual void OnAwake()
    {
    }

    protected virtual void OnStart()
    {
    }

    protected virtual void OnUpdate()
    {
    }

    private void Awake() => this.OnAwake();

    private void Start() => this.OnStart();

    //[SpecialName]
    //GameObject IXUIObject.get_gameObject() => this.gameObject;
}
