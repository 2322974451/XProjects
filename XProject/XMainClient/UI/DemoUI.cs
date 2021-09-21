// Decompiled with JetBrains decompiler
// Type: XMainClient.UI.DemoUI
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class DemoUI : DlgBase<DemoUI, DemoUIBehaviour>
    {
        public static uint MAX_MESSAGE_COUNT = 20;
        private Queue<string> messages = new Queue<string>();
        private LinkedList<string> inputs = new LinkedList<string>();
        private LinkedListNode<string> lastInput = (LinkedListNode<string>)null;
        private float lastMessageY = 0.0f;
        private object locker = new object();
        private IPlatform _platform = (IPlatform)null;

        public override string fileName => "DebugDlg";

        public override int layer => 1;

        public override bool autoload => true;

        public override bool isMainUI => true;

        protected override void Init() => this._platform = XSingleton<XUpdater.XUpdater>.singleton.XPlatform;

        public override void Reset()
        {
        }

        public override void RegisterEvent()
        {
            this.uiBehaviour.m_Button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnButtonClick));
            this.uiBehaviour.m_PreviousButton.RegisterClickEventHandler(new ButtonClickEventHandler(this._onPreviousBtnClick));
            this.uiBehaviour.m_NextButton.RegisterClickEventHandler(new ButtonClickEventHandler(this._onNextBtnClick));
            this.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._onCloseBtnClick));
            this.uiBehaviour.m_Input.RegisterKeyTriggeredEventHandler(new InputKeyTriggeredEventHandler(this._onKeyTriggered));
            this.uiBehaviour.m_Input.RegisterSubmitEventHandler(new InputSubmitEventHandler(this.OnSubmit));
            this.uiBehaviour.m_Open.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFpsClick));
        }

        protected override void OnShow()
        {
            this._refreshMessages();
            this.uiBehaviour.m_ScrollView.ResetPosition();
            this.uiBehaviour.m_Input.selected(true);
            this.uiBehaviour.m_Bg.SetActive(true);
        }

        public override void OnUpdate() => this.UpdateFPS();

        private bool _onPreviousBtnClick(IXUIButton go)
        {
            this._onKeyTriggered(this.uiBehaviour.m_Input, KeyCode.UpArrow);
            return true;
        }

        private bool _onNextBtnClick(IXUIButton go)
        {
            this._onKeyTriggered(this.uiBehaviour.m_Input, KeyCode.DownArrow);
            return true;
        }

        private bool _onCloseBtnClick(IXUIButton go)
        {
            this.uiBehaviour.m_Bg.SetActive(false);
            return true;
        }

        private void _onKeyTriggered(IXUIInput input, KeyCode key)
        {
            switch (key)
            {
                case KeyCode.UpArrow:
                    if (this.inputs.Count == 0)
                        return;
                    if (this.lastInput != null)
                    {
                        if (this.lastInput.Previous != null)
                        {
                            this.lastInput = this.lastInput.Previous;
                            break;
                        }
                        break;
                    }
                    this.lastInput = this.inputs.Last;
                    break;
                case KeyCode.DownArrow:
                    if (this.inputs.Count == 0)
                        return;
                    if (this.lastInput != null)
                    {
                        if (this.lastInput.Next != null)
                        {
                            this.lastInput = this.lastInput.Next;
                            break;
                        }
                        break;
                    }
                    this.lastInput = this.inputs.First;
                    break;
                default:
                    return;
            }
            if (this.lastInput == null)
                return;
            this.uiBehaviour.m_Input.SetText(this.lastInput.Value);
        }

        private void UpdateLastLabelPos(IXUILabel label) => this.lastMessageY -= (float)label.spriteHeight;

        private float GetLastLabelPos(IXUILabel label) => this.lastMessageY - (float)(label.spriteHeight / 2);

        private void _refreshMessages()
        {
            Vector3 tplPos = this.uiBehaviour.m_MessagePool.TplPos;
            this.lastMessageY = tplPos.y;
            this.uiBehaviour.m_MessagePool.ReturnAll();
            this.uiBehaviour.m_ActiveMessages.Clear();
            foreach (string message in this.messages)
            {
                GameObject gameObject = this.uiBehaviour.m_MessagePool.FetchGameObject();
                IXUILabel component = gameObject.GetComponent("XUILabel") as IXUILabel;
                component.SetText(message);
                this.uiBehaviour.m_ActiveMessages.Add(component);
                gameObject.transform.localPosition = new Vector3(tplPos.x, this.GetLastLabelPos(component), 0.0f);
                this.UpdateLastLabelPos(component);
            }
        }

        public void AddMessage(string message)
        {
            if (!this.IsVisible())
                return;
            lock (this.locker)
            {
                if ((long)this.messages.Count > (long)DemoUI.MAX_MESSAGE_COUNT)
                    this.messages.Dequeue();
                this.messages.Enqueue(message);
                if (this.messages.Count != this.uiBehaviour.m_ActiveMessages.Count)
                {
                    if (this.messages.Count - this.uiBehaviour.m_ActiveMessages.Count == 1)
                    {
                        GameObject gameObject = this.uiBehaviour.m_MessagePool.FetchGameObject();
                        IXUILabel component = gameObject.GetComponent("XUILabel") as IXUILabel;
                        component.SetText(message);
                        this.uiBehaviour.m_ActiveMessages.Add(component);
                        Vector3 tplPos = this.uiBehaviour.m_MessagePool.TplPos;
                        gameObject.transform.localPosition = new Vector3(tplPos.x, this.GetLastLabelPos(component), 0.0f);
                        this.UpdateLastLabelPos(component);
                    }
                    else
                        this._refreshMessages();
                }
                else
                {
                    int num = -1;
                    Vector3 tplPos = this.uiBehaviour.m_MessagePool.TplPos;
                    this.lastMessageY = tplPos.y;
                    foreach (string message1 in this.messages)
                    {
                        IXUILabel activeMessage = this.uiBehaviour.m_ActiveMessages[++num];
                        activeMessage.SetText(message1);
                        activeMessage.gameObject.transform.localPosition = new Vector3(tplPos.x, this.GetLastLabelPos(activeMessage), 0.0f);
                        this.UpdateLastLabelPos(activeMessage);
                    }
                }
                this.uiBehaviour.m_ScrollView.ResetPosition();
            }
        }

        private void _addInput(string s)
        {
            if ((long)this.inputs.Count > (long)DemoUI.MAX_MESSAGE_COUNT)
                this.inputs.RemoveFirst();
            this.inputs.AddLast(s);
            this.lastInput = (LinkedListNode<string>)null;
        }

        private void OnSubmit(IXUIInput go) => this.Submit();

        private bool OnButtonClick(IXUIButton go)
        {
            this.Submit();
            return true;
        }

        private void Submit()
        {
            string text = this.uiBehaviour.m_Input.GetText();
            this._addInput(text);
            string[] separator = new string[1] { "\n" };
            string[] strArray = text.Split(separator, StringSplitOptions.None);
            for (int index = 0; index < strArray.Length; ++index)
            {
                this.AddMessage("> " + strArray[index]);
                if (!XSingleton<XCommand>.singleton.ProcessCommand(strArray[index]))
                    this.AddMessage(string.Format("[ff0000]Invalid Command: {0}[-]", (object)strArray[index]));
            }
            this.uiBehaviour.m_Input.SetText("");
            this.uiBehaviour.m_Input.selected(true);
        }

        private bool OnFpsClick(IXUIButton go)
        {
            if (this.uiBehaviour.m_Bg.activeInHierarchy)
                this.uiBehaviour.m_Bg.SetActive(false);
            else
                this.uiBehaviour.m_Bg.SetActive(true);
            return true;
        }

        public void UpdateFPS()
        {
            if (!XSingleton<XTimerMgr>.singleton.NeedFixedUpdate || this._platform.IsPublish())
                return;
            if (XSingleton<XGame>.singleton.ShowBuildLog)
            {
                string syncModeString = XSingleton<XGame>.singleton.GetSyncModeString();
                string str = "Debug Q";
                IXUILabel fps = this.uiBehaviour.m_fps;
                object[] objArray = new object[16];
                objArray[0] = (object)str;
                objArray[1] = (object)" Build:";
                objArray[2] = (object)XLinkTimeStamp.BuildDateTime.ToString();
                objArray[3] = (object)"\nFps: ";
                float num = XSingleton<XGame>.singleton.Fps;
                objArray[4] = (object)num.ToString("F1");
                objArray[5] = (object)" Avg Fps: ";
                num = XSingleton<XGame>.singleton.FpsAvg;
                objArray[6] = (object)num.ToString("F1");
                objArray[7] = (object)"\n";
                objArray[8] = (object)syncModeString;
                objArray[9] = (object)XSingleton<XClientNetwork>.singleton.ServerIP;
                objArray[10] = (object)"\nSend:";
                objArray[11] = (object)XSingleton<XClientNetwork>.singleton.SendBytes;
                objArray[12] = (object)" Recv:";
                objArray[13] = (object)XSingleton<XClientNetwork>.singleton.RecvBytes;
                objArray[14] = (object)" delay:";
                objArray[15] = (object)XSingleton<XServerTimeMgr>.singleton.GetDelay();
                string strText = string.Concat(objArray);
                fps.SetText(strText);
            }
            else
                this.uiBehaviour.m_fps.SetText("");
        }

        public void Toggle()
        {
            if (!this.IsVisible())
                this.SetVisible(true, true);
            else if (this.uiBehaviour.m_Bg.activeInHierarchy)
            {
                this.uiBehaviour.m_Bg.SetActive(false);
                this.uiBehaviour.m_Input.selected(false);
            }
            else
            {
                this.uiBehaviour.m_Bg.SetActive(true);
                this.uiBehaviour.m_Input.selected(true);
            }
        }

        public bool IsMainUIVisible() => this.IsVisible() && this.uiBehaviour.m_Bg.activeInHierarchy;
    }
}
