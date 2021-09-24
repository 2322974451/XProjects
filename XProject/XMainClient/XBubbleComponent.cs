

using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XBubbleComponent : XComponent
    {
        private GameObject _billboard = (GameObject)null;
        private float _heroHeight = 0.0f;
        public static string BUBBLE_TEMPLATE = "UI/Billboard/Bubble";
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Bubble");
        private IXUILabelSymbol _text;
        private IXUILabel _label;
        private IXUISprite _board;
        private uint _timer = 0;
        private XTimerMgr.ElapsedEventHandler _hideBubbleCb = (XTimerMgr.ElapsedEventHandler)null;
        private Transform mCameraTrans;
        private float mSrcDistance;

        public override uint ID => XBubbleComponent.uuID;

        public XBubbleComponent() => this._hideBubbleCb = new XTimerMgr.ElapsedEventHandler(this.HideBubble);

        public override void OnAttachToHost(XObject host)
        {
            base.OnAttachToHost(host);
            this._billboard = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(XBubbleComponent.BUBBLE_TEMPLATE, this._entity.EngineObject.Position, this._entity.EngineObject.Rotation);
            this._billboard.name = this._entity.ID.ToString();
            if (this._entity.IsNpc)
                XSingleton<UiUtility>.singleton.AddChild(XSingleton<XGameUI>.singleton.NpcHpbarRoot.gameObject, this._billboard);
            else
                XSingleton<UiUtility>.singleton.AddChild(XSingleton<XGameUI>.singleton.HpbarRoot.gameObject, this._billboard);
            this._heroHeight = Math.Max(this._entity.Height, 0.9f);
            this._billboard.transform.localScale = new Vector3((float)(0.00999999977648258 * (double)this._heroHeight / 1.5), (float)(0.00999999977648258 * (double)this._heroHeight / 1.5), (float)(0.00999999977648258 * (double)this._heroHeight / 1.5));
            this._text = this._billboard.transform.FindChild("chattext/text/content").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
            this._label = this._billboard.transform.FindChild("chattext/text/content").GetComponent("XUILabel") as IXUILabel;
            this._board = this._billboard.transform.FindChild("chattext/text/content/board").GetComponent("XUISprite") as IXUISprite;
            this.mCameraTrans = XSingleton<XScene>.singleton.GameCamera.CameraTrans;
            this.mSrcDistance = 8f;
        }

        protected override void EventSubscribe() => this.RegisterEvent(XEventDefine.XEvent_Bubble, new XComponent.XEventHandler(this.ShowBubble));

        public override void OnDetachFromHost()
        {
            if (this._timer > 0U)
                XSingleton<XTimerMgr>.singleton.KillTimer(this._timer);
            this.DestroyGameObjects();
            base.OnDetachFromHost();
        }

        protected void DestroyGameObjects() => XResourceLoaderMgr.SafeDestroy(ref this._billboard);

        protected bool ShowBubble(XEventArgs e)
        {
            XBubbleEventArgs xbubbleEventArgs = e as XBubbleEventArgs;
            this._billboard.gameObject.SetActive(true);
            this._text.InputText = xbubbleEventArgs.bubbletext;
            DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.ShowCurrTempMsg(xbubbleEventArgs.bubbletext, xbubbleEventArgs.speaker);
            if (this._timer > 0U)
                XSingleton<XTimerMgr>.singleton.KillTimer(this._timer);
            this._timer = XSingleton<XTimerMgr>.singleton.SetTimer(xbubbleEventArgs.existtime, this._hideBubbleCb, (object)null);
            return true;
        }

        protected void HideBubble(object o)
        {
            this._billboard.gameObject.SetActive(false);
            this._timer = 0U;
        }

        public override void PostUpdate(float fDeltaT)
        {
            if ((UnityEngine.Object)this._billboard == (UnityEngine.Object)null || !(this._host is XEntity host))
                return;
            if (!XEntity.ValideEntity(host) && !host.IsAffiliate)
            {
                this._billboard.SetActive(false);
            }
            else
            {
                float num1 = 0.2f + this._entity.Height;
                if (this._entity.IsAffiliate)
                    num1 = (float)(0.0500000007450581 + (double)this._entity.Height / 2.0);
                this._entity.EngineObject.SyncPos();
                this._billboard.transform.position = new Vector3(this._entity.EngineObject.Position.x, this._entity.EngineObject.Position.y + num1, this._entity.EngineObject.Position.z);
                this._billboard.transform.rotation = XSingleton<XScene>.singleton.GameCamera.Rotaton;
                if ((UnityEngine.Object)this.mCameraTrans != (UnityEngine.Object)null)
                {
                    float num2 = Vector3.Distance(this._entity.EngineObject.Position, this.mCameraTrans.position) / this.mSrcDistance;
                    this._heroHeight = (this._entity.IsAffiliate ? 1.6f : 2f) * Mathf.Clamp(num2, 0.2f, 1.2f);
                    this._billboard.transform.localScale = new Vector3((float)(0.00999999977648258 * (double)this._heroHeight / 1.5), (float)(0.00999999977648258 * (double)this._heroHeight / 1.5), (float)(0.00999999977648258 * (double)this._heroHeight / 1.5));
                }
                if (Time.frameCount % 15 != 0)
                    return;
                this.SetBillBoardDepth(Vector3.Distance(XSingleton<XScene>.singleton.GameCamera.UnityCamera.transform.position, this._billboard.transform.position));
            }
        }

        private void SetBillBoardDepth(float dis = 0.0f)
        {
            int num = -(int)((double)dis * 100.0);
            if (this._label == null || this._board == null)
                return;
            this._label.spriteDepth = num + 1;
            this._board.spriteDepth = num;
        }
    }
}
