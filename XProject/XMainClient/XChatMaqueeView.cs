// Decompiled with JetBrains decompiler
// Type: XMainClient.XChatMaqueeView
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XChatMaqueeView : DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>
    {
        private XChatDocument _doc = (XChatDocument)null;
        private bool m_IsPlaying;
        private List<MaqueeInfo> m_MaqueeFirst = new List<MaqueeInfo>();
        private List<MaqueeInfo> m_MaqueeSecond = new List<MaqueeInfo>();
        private List<MaqueeInfo> m_MaqueeThird = new List<MaqueeInfo>();
        private int m_OffsetStart = 0;
        private int m_OffsetEnd = 0;
        private int m_CurOffset = 0;
        private float m_CurShowTime = 0.0f;
        private bool m_MaqueeSwitch = true;
        private MaqueeInfo m_PlayingMaquee;

        public override string fileName => "GameSystem/ChatMaqueeDlg";

        public override bool isHideChat => false;

        public override int group => 1;

        public override bool autoload => true;

        public override bool needOnTop => true;

        protected override void Init()
        {
            this._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
            this._doc.ChatMaqueeView = this;
        }

        public override void RegisterEvent()
        {
        }

        protected override void OnShow() => base.OnShow();

        protected override void OnUnload()
        {
            this._doc = (XChatDocument)null;
            this.m_IsPlaying = false;
            this.m_MaqueeThird.Clear();
            base.OnUnload();
        }

        public void ShowMaquee() => this.SetVisible(true, true);

        public void HideMaquee() => this.SetVisible(false, true);

        public void SetMaqueeSwitch(bool enable)
        {
            this.m_MaqueeSwitch = enable;
            if (!this.IsLoaded())
                return;
            if (!enable)
            {
                this.m_IsPlaying = false;
                this.SetVisible(false, true);
            }
            else
                this.PlayFinished();
        }

        public void ReceiveChatInfo(KKSG.ChatInfo chatinfo)
        {
            SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
            int num;
            switch (sceneType)
            {
                case SceneType.SCENE_HALL:
                case SceneType.SCENE_BATTLE:
                case SceneType.SCENE_NEST:
                case SceneType.SCENE_GUILD_HALL:
                case SceneType.SCENE_ABYSSS:
                case SceneType.SCENE_FAMILYGARDEN:
                case SceneType.SCENE_TOWER:
                    num = 0;
                    break;
                default:
                    num = sceneType != SceneType.SCENE_LEISURE ? 1 : 0;
                    break;
            }
            if (num != 0 || !this.m_MaqueeSwitch || chatinfo.level > XSingleton<XAttributeMgr>.singleton.XPlayerData.Level)
                return;
            if (chatinfo.channel == 5U)
                this.AddMaqueeNormalInfo(chatinfo.info, 0.0f);
            else
                this.AddMaqueeNormalInfo(chatinfo.info, 5f);
        }

        public void AddMaqueeNormalInfo(string info, float stopTime)
        {
            if (info == null)
                return;
            this.ShowMaquee();
            MaqueeInfo maquee = new MaqueeInfo();
            maquee.content = info;
            maquee.playTimes = 1;
            maquee.showTime = stopTime;
            maquee.playSpeed = XSingleton<XGlobalConfig>.singleton.GetInt("MaqueeSpeed");
            this.m_MaqueeThird.Add(maquee);
            if (this.m_IsPlaying)
                return;
            this.StartPlayMaquee(maquee);
        }

        public void StartPlayMaquee(MaqueeInfo maquee)
        {
            string strText = XLabelSymbolHelper.RemoveFormatInfo(maquee.content);
            if (!this.IsVisible())
                this.SetVisible(true, true);
            this.uiBehaviour.m_MaqueeText.SetText(strText);
            Vector2 printSize = this.uiBehaviour.m_MaqueeText.GetPrintSize();
            this.uiBehaviour.m_MaqueeTextSymbol.InputText = strText;
            this.m_PlayingMaquee = maquee;
            this.m_IsPlaying = true;
            this.m_CurShowTime = maquee.showTime;
            this.m_OffsetStart = (int)((double)printSize.x / 2.0) + this.uiBehaviour.m_MaqueeBoard.spriteWidth / 2 + 20;
            this.m_OffsetEnd = -1 * this.m_OffsetStart;
            this.m_CurOffset = this.m_OffsetStart;
            this.uiBehaviour.m_MaqueeTween.PlayTween(true);
        }

        public void UpdateMaquee(float delta)
        {
            if (!this.m_IsPlaying || !this.IsVisible())
                return;
            if (this.m_CurOffset <= 0 && (double)this.m_CurShowTime > 0.0)
            {
                this.m_CurShowTime -= delta;
            }
            else
            {
                this.m_CurOffset -= (int)((double)delta * (double)this.m_PlayingMaquee.playSpeed);
                this.uiBehaviour.m_MaqueeText.gameObject.transform.localPosition = new Vector3((float)this.m_CurOffset, this.uiBehaviour.m_MaqueeText.gameObject.transform.localPosition.y, this.uiBehaviour.m_MaqueeText.gameObject.transform.localPosition.z);
                if (this.m_CurOffset > this.m_OffsetEnd)
                    return;
                this.PlayFinished();
            }
        }

        public void PlayFinished()
        {
            if (this.m_PlayingMaquee == null)
                return;
            if (this.m_PlayingMaquee.playTimes > 1)
            {
                this.m_CurOffset = this.m_OffsetStart;
                --this.m_PlayingMaquee.playTimes;
                this.m_CurShowTime = this.m_PlayingMaquee.showTime;
            }
            else
            {
                this.m_MaqueeThird.RemoveAt(0);
                if (this.m_MaqueeThird.Count > 0)
                {
                    this.StartPlayMaquee(this.m_MaqueeThird[0]);
                }
                else
                {
                    this.m_IsPlaying = false;
                    this.uiBehaviour.m_MaqueeTween.PlayTween(false);
                    this.UnLoad(false);
                }
            }
        }
    }
}
