// Decompiled with JetBrains decompiler
// Type: UILib.IXUITool
// Assembly: UILib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 98636226-A9CD-4398-A93A-F8649E3E05B4
// Assembly location: F:\龙之谷\Client\Assets\Lib\UILib.dll

using UnityEngine;

namespace UILib
{
    public interface IXUITool
    {
        void SetActive(GameObject obj, bool state);

        void SetLayer(GameObject go, int layer);

        void SetUIEventFallThrough(GameObject obj);

        void SetUIGenericEventHandle(GameObject obj);

        void ShowTooltip(string str);

        void RegisterLoadUIAsynEventHandler(LoadUIAsynEventHandler eventHandler);

        Camera GetUICamera();

        void PlayAnim(Animation anim, string strClipName, AnimFinishedEventHandler eventHandler);

        void MarkParentAsChanged(GameObject go);

        void Destroy(Object obj);

        void SetUIDepthDelta(GameObject go, int delta);

        string GetLocalizedStr(string key);

        Vector2 CalculatePrintedSize(string text);

        void ReleaseAllDrawCall();

        void HideGameObject(GameObject go);

        void ShowGameObject(GameObject go, IXUIPanel panel);

        void ChangePanel(GameObject go, IUIRect parent, IXUIPanel panel);

        void ChangePanel(GameObject go, IUIRect parent, IUIPanel panel);

        void SetRootPanelUpdateFreq(int count);

        void PreLoad(bool load);

        void EnableUILoadingUpdate(bool enable);

        void SetUIOptOption(bool globalMerge, bool selectMerge, bool lowDeviceMerge);
    }
}
