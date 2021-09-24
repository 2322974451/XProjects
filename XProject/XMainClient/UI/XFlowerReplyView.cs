using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XFlowerReplyView : DlgBase<XFlowerReplyView, XFlowerReplyBehavior>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/FlowerReply";
			}
		}

		public override int layer
		{
			get
			{
				return 100;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		public void ShowView(int itemID, ulong senderID, string senderName, int senderPower, int senderProfession, int senderVip, int sendCount)
		{
			this._flowerID = itemID;
			this._senderID = senderID;
			this._senderName = senderName;
			this._senderPower = senderPower;
			this._senderProfession = senderProfession;
			this._senderVip = senderVip;
			this._sendCount = sendCount;
			this.SetVisibleWithAnimation(true, null);
		}

		protected override void Init()
		{
			this._Doc = XDocuments.GetSpecificDocument<XFlowerReplyDocument>(XFlowerReplyDocument.uuID);
			this._Doc.View = this;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.UpdateReplyBg();
			base.uiBehaviour.m_SpeakPanel.gameObject.SetActive(false);
			base.uiBehaviour.m_SenderName.SetText(this._senderName);
			base.uiBehaviour.m_SenderCount.SetText(this._sendCount.ToString());
			base.uiBehaviour.m_FlowerName.SetText(XSingleton<UiUtility>.singleton.ChooseProfString(XBagDocument.GetItemConf(this._flowerID).ItemName, 0U));
			base.uiBehaviour.m_ThxContent.SetText(this._Doc.GetThxContent(this._flowerID, this._sendCount));
		}

		private void UpdateReplyBg()
		{
			int num = this._flowerID - XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FLOWER_RED_ROSE);
			for (int i = 0; i < base.uiBehaviour.m_ReplayBgList.Count; i++)
			{
				base.uiBehaviour.m_ReplayBgList[i].SetActive(i == num);
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Voice.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnVoicePressButton));
			base.uiBehaviour.m_Voice.RegisterDragEventHandler(new ButtonDragEventHandler(this.OnVoiceDragButton));
			base.uiBehaviour.m_QuickThx.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReplyClicked));
		}

		private bool OnReplyClicked(IXUIButton button)
		{
			DlgBase<XChatView, XChatBehaviour>.singleton.ChatFriendId = this._senderID;
			ChatInfo chatInfo = new ChatInfo();
			chatInfo.mTime = DateTime.Now;
			chatInfo.isSelfSender = true;
			chatInfo.mReceiverName = this._senderName;
			chatInfo.mReceiverId = this._senderID;
			chatInfo.mReciverPowerPoint = (uint)this._senderPower;
			chatInfo.mRecieverProfession = (uint)this._senderProfession;
			chatInfo.mReceiverVip = (uint)this._senderVip;
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			specificDocument.AddChatinfo2FriendList(chatInfo);
			DlgBase<XChatView, XChatBehaviour>.singleton.SendChatContent(XStringDefineProxy.GetString("FLOWER_QUICK_THX"), ChatChannelType.Friends, true, null, false, 0UL, 0f, false, false);
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("INVITATION_SENT_NOTIFICATION"), "fece00");
			this.CloseDlg();
			return true;
		}

		private void CloseDlg()
		{
			this.SetVisibleWithAnimation(false, null);
		}

		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this.OnClosed != null;
			if (flag)
			{
				this.OnClosed();
			}
		}

		private void OnCloseClicked(IXUISprite go)
		{
			this.CloseDlg();
		}

		private void OnVoicePressButton(IXUIButton button, bool state)
		{
			if (state)
			{
				this.m_DragDistance = Vector2.zero;
				bool useApollo = XChatDocument.UseApollo;
				if (useApollo)
				{
					XSingleton<XChatApolloMgr>.singleton.StartRecord(VoiceUsage.FLOWER_REPLY, null);
				}
				else
				{
					XSingleton<XChatIFlyMgr>.singleton.StartRecord(VoiceUsage.FLOWER_REPLY, null);
				}
			}
			else
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.ChatFriendId = this._senderID;
				ChatInfo chatInfo = new ChatInfo();
				chatInfo.mTime = DateTime.Now;
				chatInfo.isSelfSender = true;
				chatInfo.mReceiverName = this._senderName;
				chatInfo.mReceiverId = this._senderID;
				chatInfo.mReciverPowerPoint = (uint)this._senderPower;
				chatInfo.mRecieverProfession = (uint)this._senderProfession;
				chatInfo.mReceiverVip = (uint)this._senderVip;
				XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
				specificDocument.AddChatinfo2FriendList(chatInfo);
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("INVITATION_SENT_NOTIFICATION"), "fece00");
				bool useApollo2 = XChatDocument.UseApollo;
				if (useApollo2)
				{
					XSingleton<XChatApolloMgr>.singleton.StopRecord(this.m_CancelRecord);
				}
				else
				{
					XSingleton<XChatIFlyMgr>.singleton.StopRecord(this.m_CancelRecord);
				}
				bool flag = !this.m_CancelRecord;
				if (flag)
				{
					this.CloseDlg();
				}
			}
		}

		private void OnVoiceDragButton(IXUIButton button, Vector2 delta)
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

		public Action OnClosed;

		private XFlowerReplyDocument _Doc;

		private int _flowerID;

		private ulong _senderID;

		private string _senderName;

		private int _senderPower;

		private int _senderProfession;

		private int _senderVip;

		private int _sendCount;

		private Vector2 m_DragDistance = Vector2.zero;

		private bool m_CancelRecord = false;
	}
}
