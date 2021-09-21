// Decompiled with JetBrains decompiler
// Type: XMainClient.UI.XShowGetItemUIView
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class XShowGetItemUIView : DlgBase<XShowGetItemUIView, XShowGetItemUIBehaviour>
    {
        private XShowGetItemDocument _doc = (XShowGetItemDocument)null;
        private List<XItem> m_items = new List<XItem>();
        private uint m_token = 0;
        private OnTweenFinishEventHandler mAnimEnd;
        public bool isPlaying = false;

        public override string fileName => "GameSystem/ShowGetItemDlg";

        public override bool autoload => true;

        public override bool needOnTop => true;

        public override bool isHideChat => false;

        protected override void OnHide()
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
            base.OnHide();
        }

        protected override void OnUnload()
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
            base.OnUnload();
        }

        protected override void Init()
        {
            base.Init();
            if (this._doc != null)
                return;
            this._doc = XDocuments.GetSpecificDocument<XShowGetItemDocument>(XShowGetItemDocument.uuID);
        }

        protected override void OnShow()
        {
        }

        private void Print(List<XItem> _items, string tag)
        {
            for (int index = 0; index < _items.Count; ++index)
                XSingleton<XDebug>.singleton.AddGreenLog(XSingleton<XCommon>.singleton.StringCombine(tag, " itemid:" + (object)_items[index].itemID + " cnt:" + (object)_items[index].itemCount));
        }

        public void ShowItems(List<XItem> _items, OnTweenFinishEventHandler _end)
        {
            if (this._doc == null)
                this._doc = XDocuments.GetSpecificDocument<XShowGetItemDocument>(XShowGetItemDocument.uuID);
            if (XEquipCreateDocument.Doc.IsForbidGetItemUI || this._doc.IsForbidByLua)
            {
                this.SetVisible(false, true);
                XShowGetItemDocument.ItemUIQueue.Clear();
            }
            else
            {
                if (!this.IsVisible())
                    this.SetVisibleWithAnimation(true, (DlgBase<XShowGetItemUIView, XShowGetItemUIBehaviour>.OnAnimationOver)null);
                this.isPlaying = true;
                this.mAnimEnd = _end;
                this.m_items = _items;
                this.uiBehaviour.m_ShowItemPool.ReturnAll();
                this.GridItems();
                this.uiBehaviour.m_tweenBg.ResetTween(true);
                this.uiBehaviour.m_tweenBg.PlayTween(true);
                XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
                XSingleton<XDebug>.singleton.AddGreenLog(this.uiBehaviour.m_tweener.Duration.ToString());
                this.m_token = XSingleton<XTimerMgr>.singleton.SetTimer(this.uiBehaviour.m_tweener.Duration, new XTimerMgr.ElapsedEventHandler(this.OnPlayEnd), (object)this.uiBehaviour.m_tweenBg);
            }
        }

        public void OnPlayEnd(object o = null)
        {
            if (o != null)
            {
                IXUITweenTool tween = o as IXUITweenTool;
                this.isPlaying = false;
                if (this.mAnimEnd != null)
                {
                    XSingleton<XDebug>.singleton.AddLog("play end!");
                    this.mAnimEnd(tween);
                }
            }
            XSingleton<XDebug>.singleton.AddGreenLog("the end event");
        }

        public void OnPlayEnd(IXUITweenTool tween)
        {
            this.isPlaying = false;
            if (this.mAnimEnd == null)
                return;
            XSingleton<XDebug>.singleton.AddLog("play end!");
            this.mAnimEnd(tween);
        }

        public void HandlePlayEnd()
        {
            if (!((Object)this.uiBehaviour != (Object)null) || this.uiBehaviour.m_ShowItemPool == null)
                return;
            this.uiBehaviour.m_ShowItemPool.ReturnAll();
        }

        private void GridItems()
        {
            int count = this.m_items.Count;
            Vector3 vector3 = new Vector3(200f, -12f, 0.0f);
            this.uiBehaviour.m_sprBgTip.spriteHeight = count > 5 ? 300 : 250;
            for (int index = 0; index < count; ++index)
            {
                if (count > 5)
                {
                    int num = count % 2 == 0 ? count / 2 : count / 2 + 1;
                    if (index < num)
                    {
                        vector3.x = (float)(100.0 * ((double)index - (double)(num - 1) / 2.0));
                        vector3.y = -120f;
                    }
                    else
                    {
                        vector3.x = (float)(100.0 * ((double)(index - num) - (double)(count - num - 1) / 2.0));
                        vector3.y = -220f;
                    }
                }
                else
                {
                    vector3.x = (float)(100.0 * ((double)index - (double)(count - 1) / 2.0));
                    vector3.y = -145f;
                }
                GameObject go = this.uiBehaviour.m_ShowItemPool.FetchGameObject();
                go.name = "item" + (object)index;
                go.transform.localPosition = vector3;
                XSingleton<XItemDrawerMgr>.singleton.DrawItem(go, this.m_items[index]);
            }
        }
    }
}
