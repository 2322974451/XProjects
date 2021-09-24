using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamSmallChatHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.chatDoc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			this.teamDoc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this.m_BtnVoice = (base.PanelObject.transform.Find("BtnVoice").GetComponent("XUIButton") as IXUIButton);
			this.m_SpeakInfo = base.PanelObject.transform.Find("SpeakPanel/SpeakInfo").gameObject;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnVoice.RegisterPressEventHandler(new ButtonPressEventHandler(this._OnVoiceBtn));
			this.m_BtnVoice.RegisterDragEventHandler(new ButtonDragEventHandler(this._OnVoiceButtonDrag));
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_SpeakInfo.SetActive(false);
		}

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

		private ChatChannelType CurrentChannel
		{
			get
			{
				return this.teamDoc.bInTeam ? ChatChannelType.Team : ChatChannelType.World;
			}
		}

		private void _OnChatBgClicked(IXUISprite iSp)
		{
			DlgBase<XChatView, XChatBehaviour>.singleton.ShowChannel(this.CurrentChannel);
		}

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

		public void OnGetChatInfo(ChatInfo newInfo)
		{
			bool flag = newInfo.mChannelId != this.CurrentChannel;
			if (!flag)
			{
				this._SetChatInfo(newInfo);
				this._SetAllChatInfoPosition();
			}
		}

		private void _SetChatInfo(ChatInfo info)
		{
			XSmallChatInfo xsmallChatInfo = this._CreateSmallChatInfo();
			xsmallChatInfo.info = info;
			xsmallChatInfo.uiobject = (info.isAudioChat ? this.m_AudioPool.FetchGameObject(false) : this.m_TextPool.FetchGameObject(false));
			this._SetChatUI(xsmallChatInfo.info, xsmallChatInfo.uiobject);
			this.m_ChatList.Add(xsmallChatInfo);
		}

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

		private void _SetChatUI(ChatInfo info, GameObject go)
		{
			XChatSmallView.InitMiniChatUI(info, go);
		}

		private static int MSG_DISPLAY_COUNT = 3;

		private XUIPool m_TextPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_AudioPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIButton m_BtnVoice;

		private GameObject m_SpeakInfo;

		private List<XSmallChatInfo> m_ChatList = new List<XSmallChatInfo>();

		private XChatDocument chatDoc;

		private XTeamDocument teamDoc;

		private Vector2 m_DragDistance = Vector2.zero;

		private bool m_CancelRecord = false;
	}
}
