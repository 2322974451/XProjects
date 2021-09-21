using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D16 RID: 3350
	internal class XTeamSmallChatHandler : DlgHandlerBase
	{
		// Token: 0x0600BAEC RID: 47852 RVA: 0x00264FC0 File Offset: 0x002631C0
		protected override void Init()
		{
			base.Init();
			this.chatDoc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			this.teamDoc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this.m_BtnVoice = (base.PanelObject.transform.Find("BtnVoice").GetComponent("XUIButton") as IXUIButton);
			this.m_SpeakInfo = base.PanelObject.transform.Find("SpeakPanel/SpeakInfo").gameObject;
		}

		// Token: 0x0600BAED RID: 47853 RVA: 0x0026503F File Offset: 0x0026323F
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnVoice.RegisterPressEventHandler(new ButtonPressEventHandler(this._OnVoiceBtn));
			this.m_BtnVoice.RegisterDragEventHandler(new ButtonDragEventHandler(this._OnVoiceButtonDrag));
		}

		// Token: 0x0600BAEE RID: 47854 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600BAEF RID: 47855 RVA: 0x00265079 File Offset: 0x00263279
		protected override void OnShow()
		{
			base.OnShow();
			this.m_SpeakInfo.SetActive(false);
		}

		// Token: 0x0600BAF0 RID: 47856 RVA: 0x00265090 File Offset: 0x00263290
		private void _OnVoiceButtonDrag(IXUIButton sp, Vector2 delta)
		{
			this.m_DragDistance += delta;
			bool flag = this.m_DragDistance.magnitude >= 100f;
			if (flag)
			{
				this.m_CancelRecord = true;
			}
			else
			{
				this.m_CancelRecord = false;
			}
		}

		// Token: 0x0600BAF1 RID: 47857 RVA: 0x002650DC File Offset: 0x002632DC
		private void _OnVoiceBtn(IXUIButton btn, bool state)
		{
			if (state)
			{
				this.m_DragDistance = Vector2.zero;
				bool useApollo = XChatDocument.UseApollo;
				if (useApollo)
				{
					XSingleton<XChatApolloMgr>.singleton.StartRecord(VoiceUsage.CHAT, null);
				}
				else
				{
					XSingleton<XChatIFlyMgr>.singleton.StartRecord(VoiceUsage.CHAT, null);
				}
			}
			else
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.SetActiveChannel(ChatChannelType.Team);
				bool useApollo2 = XChatDocument.UseApollo;
				if (useApollo2)
				{
					XSingleton<XChatApolloMgr>.singleton.StopRecord(this.m_CancelRecord);
				}
				else
				{
					XSingleton<XChatIFlyMgr>.singleton.StopRecord(this.m_CancelRecord);
				}
			}
		}

		// Token: 0x170032E9 RID: 13033
		// (get) Token: 0x0600BAF2 RID: 47858 RVA: 0x00265160 File Offset: 0x00263360
		private ChatChannelType CurrentChannel
		{
			get
			{
				return this.teamDoc.bInTeam ? ChatChannelType.Team : ChatChannelType.World;
			}
		}

		// Token: 0x0600BAF3 RID: 47859 RVA: 0x00265183 File Offset: 0x00263383
		private void _OnChatBgClicked(IXUISprite iSp)
		{
			DlgBase<XChatView, XChatBehaviour>.singleton.ShowChannel(this.CurrentChannel);
		}

		// Token: 0x0600BAF4 RID: 47860 RVA: 0x00265198 File Offset: 0x00263398
		public void RefreshPage()
		{
			List<ChatInfo> chatInfoList = this.chatDoc.GetChatInfoList(this.CurrentChannel);
			int num = (chatInfoList != null) ? Math.Min(chatInfoList.Count, XTeamSmallChatHandler.MSG_DISPLAY_COUNT) : 0;
			int num2 = Math.Max(0, num - XTeamSmallChatHandler.MSG_DISPLAY_COUNT);
			this.m_ChatList.Clear();
			this.m_TextPool.FakeReturnAll();
			this.m_AudioPool.FakeReturnAll();
			for (int i = num2; i < num; i++)
			{
				this._SetChatInfo(chatInfoList[i]);
			}
			this.m_TextPool.ActualReturnAll(false);
			this.m_AudioPool.ActualReturnAll(false);
			this._SetAllChatInfoPosition();
		}

		// Token: 0x0600BAF5 RID: 47861 RVA: 0x00265244 File Offset: 0x00263444
		public void OnGetChatInfo(ChatInfo newInfo)
		{
			bool flag = newInfo.mChannelId != this.CurrentChannel;
			if (!flag)
			{
				this._SetChatInfo(newInfo);
				this._SetAllChatInfoPosition();
			}
		}

		// Token: 0x0600BAF6 RID: 47862 RVA: 0x00265278 File Offset: 0x00263478
		private void _SetChatInfo(ChatInfo info)
		{
			XSmallChatInfo xsmallChatInfo = this._CreateSmallChatInfo();
			xsmallChatInfo.info = info;
			xsmallChatInfo.uiobject = (info.isAudioChat ? this.m_AudioPool.FetchGameObject(false) : this.m_TextPool.FetchGameObject(false));
			this._SetChatUI(xsmallChatInfo.info, xsmallChatInfo.uiobject);
			this.m_ChatList.Add(xsmallChatInfo);
		}

		// Token: 0x0600BAF7 RID: 47863 RVA: 0x002652DC File Offset: 0x002634DC
		private void _SetAllChatInfoPosition()
		{
			int num = 0;
			for (int i = 0; i < this.m_ChatList.Count; i++)
			{
				GameObject uiobject = this.m_ChatList[i].uiobject;
				IXUILabel ixuilabel = uiobject.transform.FindChild("content").GetComponent("XUILabel") as IXUILabel;
				uiobject.transform.localPosition = new Vector3(0f, (float)(-(float)num));
				num += (int)ixuilabel.GetPrintSize().y;
			}
		}

		// Token: 0x0600BAF8 RID: 47864 RVA: 0x00265364 File Offset: 0x00263564
		private XSmallChatInfo _CreateSmallChatInfo()
		{
			bool flag = this.m_ChatList.Count == XTeamSmallChatHandler.MSG_DISPLAY_COUNT;
			XSmallChatInfo xsmallChatInfo;
			if (flag)
			{
				xsmallChatInfo = this.m_ChatList[0];
				for (int i = 0; i < this.m_ChatList.Count - 1; i++)
				{
					this.m_ChatList[i] = this.m_ChatList[i + 1];
				}
				this.m_ChatList.RemoveAt(this.m_ChatList.Count - 1);
			}
			else
			{
				xsmallChatInfo = new XSmallChatInfo();
			}
			bool flag2 = xsmallChatInfo.info != null && xsmallChatInfo.uiobject != null;
			if (flag2)
			{
				bool isAudioChat = xsmallChatInfo.info.isAudioChat;
				if (isAudioChat)
				{
					this.m_AudioPool.ReturnInstance(xsmallChatInfo.uiobject, false);
				}
				else
				{
					this.m_TextPool.ReturnInstance(xsmallChatInfo.uiobject, false);
				}
			}
			return xsmallChatInfo;
		}

		// Token: 0x0600BAF9 RID: 47865 RVA: 0x00265456 File Offset: 0x00263656
		private void _SetChatUI(ChatInfo info, GameObject go)
		{
			XChatSmallView.InitMiniChatUI(info, go);
		}

		// Token: 0x04004B52 RID: 19282
		private static int MSG_DISPLAY_COUNT = 3;

		// Token: 0x04004B53 RID: 19283
		private XUIPool m_TextPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004B54 RID: 19284
		private XUIPool m_AudioPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004B55 RID: 19285
		private IXUIButton m_BtnVoice;

		// Token: 0x04004B56 RID: 19286
		private GameObject m_SpeakInfo;

		// Token: 0x04004B57 RID: 19287
		private List<XSmallChatInfo> m_ChatList = new List<XSmallChatInfo>();

		// Token: 0x04004B58 RID: 19288
		private XChatDocument chatDoc;

		// Token: 0x04004B59 RID: 19289
		private XTeamDocument teamDoc;

		// Token: 0x04004B5A RID: 19290
		private Vector2 m_DragDistance = Vector2.zero;

		// Token: 0x04004B5B RID: 19291
		private bool m_CancelRecord = false;
	}
}
