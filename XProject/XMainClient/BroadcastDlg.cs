

using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class BroadcastDlg : DlgBase<BroadcastDlg, BroadcastBehaviour>
    {
        private static bool isCameraOpen = false;
        public readonly int max_count = 40;
        public List<BroadNode> barrages = new List<BroadNode>();
        public string lastCahceMsg = string.Empty;
        private Vector3 originPos = Vector3.zero;
        private float closeTime = 0.0f;
        private float closeDuration = 0.3f;
        private bool isClosing = false;
        private uint timer = 0;

        public override string fileName => "GameSystem/BroadcastDlg";

        public override bool autoload => true;

        public override bool isHideChat => false;

        protected override void Init()
        {
            base.Init();
            this.uiBehaviour.m_lblCamera.SetText(XStringDefineProxy.GetString("BROAD_CAMERA_OPEN"));
            GameObject tpl = this.uiBehaviour.loopScrool.GetTpl();
            if (!((UnityEngine.Object)tpl != (UnityEngine.Object)null) || !((UnityEngine.Object)tpl.GetComponent<BroadBarrageItem>() == (UnityEngine.Object)null))
                return;
            tpl.AddComponent<BroadBarrageItem>();
        }

        public override void RegisterEvent()
        {
            base.RegisterEvent();
            this.uiBehaviour.m_btnBarrage.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEndClick));
            this.uiBehaviour.m_btnCamera.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCameraClick));
            this.uiBehaviour.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClosePanel));
            this.uiBehaviour.m_btnShare.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareClick));
        }

        protected override void OnShow()
        {
            base.OnShow();
            this.timer = XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.TimerShow), (object)null);
            this.originPos = DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.GetIconPos();
            this.isClosing = false;
            this.uiBehaviour.transform.localPosition = Vector3.zero;
            this.uiBehaviour.transform.localScale = Vector3.one;
        }

        protected override void OnUnload()
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(this.timer);
            base.OnUnload();
        }

        public void Push(string _nickname, string _content)
        {
            BroadNode broadNode = new BroadNode();
            broadNode.nickname = _nickname;
            broadNode.content = _content;
            if (this.barrages.Count > this.max_count)
                this.barrages.RemoveRange(0, this.barrages.Count - this.max_count);
            this.barrages.Add(broadNode);
        }

        private void TimerShow(object o)
        {
            this.ShowList();
            this.timer = XSingleton<XTimerMgr>.singleton.SetTimer(0.4f, new XTimerMgr.ElapsedEventHandler(this.TimerShow), (object)null);
        }

        public void ShowList()
        {
            if (!this.IsVisible())
                return;
            List<LoopItemData> datas = new List<LoopItemData>();
            string str = string.Empty;
            for (int index = 0; index < this.barrages.Count; ++index)
            {
                BarrageMsg barrageMsg = new BarrageMsg();
                barrageMsg.LoopID = XSingleton<XCommon>.singleton.XHash(this.barrages[index].content + (object)index);
                barrageMsg.nickname = this.barrages[index].nickname;
                barrageMsg.content = this.barrages[index].content;
                datas.Add((LoopItemData)barrageMsg);
                str = XSingleton<XCommon>.singleton.StringCombine(barrageMsg.nickname, barrageMsg.content);
            }
            if (string.IsNullOrEmpty(this.lastCahceMsg) || this.lastCahceMsg != str)
                this.uiBehaviour.loopScrool.Init(datas, new DelegateHandler(this.RefreshItem), (System.Action)null, 1);
            if (this.barrages != null && this.barrages.Count > 0)
            {
                int index = this.barrages.Count - 1;
                this.lastCahceMsg = XSingleton<XCommon>.singleton.StringCombine(this.barrages[index].nickname, this.barrages[index].content);
            }
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!this.isClosing)
                return;
            this.uiBehaviour.gameObject.transform.localPosition = Vector3.Lerp(Vector3.zero, this.originPos, (Time.time - this.closeTime) / this.closeDuration);
            this.uiBehaviour.gameObject.transform.localScale = Vector3.Lerp(Vector3.one, 0.1f * Vector3.one, (Time.time - this.closeTime) / this.closeDuration);
            if ((double)Time.time - (double)this.closeTime >= (double)this.closeDuration)
            {
                this.isClosing = false;
                this.SetVisible(false, true);
                DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.Show(true);
            }
        }

        private void RefreshItem(ILoopItemObject item, LoopItemData data)
        {
            if (data is BarrageMsg barrageMsg)
            {
                GameObject gameObject = item.GetObj();
                if (!((UnityEngine.Object)gameObject != (UnityEngine.Object)null))
                    return;
                BroadBarrageItem component = gameObject.GetComponent<BroadBarrageItem>();
                if ((UnityEngine.Object)component != (UnityEngine.Object)null)
                    component.Refresh(barrageMsg.nickname, barrageMsg.content);
            }
            else
                XSingleton<XDebug>.singleton.AddErrorLog("BroadBarrageItem info is null");
        }

        private bool OnEndClick(IXUIButton btn)
        {
            XSingleton<XUpdater.XUpdater>.singleton.XBroadCast.StopBroadcast();
            this.ClosePanel(btn);
            return true;
        }

        private bool OnCameraClick(IXUIButton btn)
        {
            if (BroadcastDlg.isCameraOpen)
            {
                XSingleton<XUpdater.XUpdater>.singleton.XBroadCast.ShowCamera(false);
                BroadcastDlg.isCameraOpen = false;
                this.uiBehaviour.m_lblCamera.SetText(XStringDefineProxy.GetString("BROAD_CAMERA_OPEN"));
            }
            else if (XSingleton<XUpdater.XUpdater>.singleton.XBroadCast.ShowCamera(true))
            {
                BroadcastDlg.isCameraOpen = true;
                this.uiBehaviour.m_lblCamera.SetText(XStringDefineProxy.GetString("BROAD_CAMERA_CLOSE"));
            }
            return true;
        }

        private bool OnShareClick(IXUIButton btn)
        {
            XSingleton<XDebug>.singleton.AddGreenLog("sharebtn click");
            this.ClosePanel(btn);
            return true;
        }

        private bool ClosePanel(IXUIButton btn)
        {
            if (!this.isClosing)
            {
                this.closeTime = Time.time;
                this.isClosing = true;
            }
            return true;
        }
    }
}
