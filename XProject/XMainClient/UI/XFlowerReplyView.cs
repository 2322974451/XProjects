using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001829 RID: 6185
	internal class XFlowerReplyView : DlgBase<XFlowerReplyView, XFlowerReplyBehavior>
	{
		// Token: 0x17003922 RID: 14626
		// (get) Token: 0x060100DF RID: 65759 RVA: 0x003D40C0 File Offset: 0x003D22C0
		public override string fileName
		{
			get
			{
				return "GameSystem/FlowerReply";
			}
		}

		// Token: 0x17003923 RID: 14627
		// (get) Token: 0x060100E0 RID: 65760 RVA: 0x003D40D8 File Offset: 0x003D22D8
		public override int layer
		{
			get
			{
				return 100;
			}
		}

		// Token: 0x17003924 RID: 14628
		// (get) Token: 0x060100E1 RID: 65761 RVA: 0x003D40EC File Offset: 0x003D22EC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003925 RID: 14629
		// (get) Token: 0x060100E2 RID: 65762 RVA: 0x003D4100 File Offset: 0x003D2300
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003926 RID: 14630
		// (get) Token: 0x060100E3 RID: 65763 RVA: 0x003D4114 File Offset: 0x003D2314
		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060100E4 RID: 65764 RVA: 0x003D4128 File Offset: 0x003D2328
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

		// Token: 0x060100E5 RID: 65765 RVA: 0x003D4174 File Offset: 0x003D2374
		protected override void Init()
		{
			this._Doc = XDocuments.GetSpecificDocument<XFlowerReplyDocument>(XFlowerReplyDocument.uuID);
			this._Doc.View = this;
		}

		// Token: 0x060100E6 RID: 65766 RVA: 0x003D4194 File Offset: 0x003D2394
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

		// Token: 0x060100E7 RID: 65767 RVA: 0x003D4250 File Offset: 0x003D2450
		private void UpdateReplyBg()
		{
			int num = this._flowerID - XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FLOWER_RED_ROSE);
			for (int i = 0; i < base.uiBehaviour.m_ReplayBgList.Count; i++)
			{
				base.uiBehaviour.m_ReplayBgList[i].SetActive(i == num);
			}
		}

		// Token: 0x060100E8 RID: 65768 RVA: 0x003D42AC File Offset: 0x003D24AC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Voice.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnVoicePressButton));
			base.uiBehaviour.m_Voice.RegisterDragEventHandler(new ButtonDragEventHandler(this.OnVoiceDragButton));
			base.uiBehaviour.m_QuickThx.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReplyClicked));
		}

		// Token: 0x060100E9 RID: 65769 RVA: 0x003D4338 File Offset: 0x003D2538
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

		// Token: 0x060100EA RID: 65770 RVA: 0x003D4405 File Offset: 0x003D2605
		private void CloseDlg()
		{
			this.SetVisibleWithAnimation(false, null);
		}

		// Token: 0x060100EB RID: 65771 RVA: 0x003D4414 File Offset: 0x003D2614
		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this.OnClosed != null;
			if (flag)
			{
				this.OnClosed();
			}
		}

		// Token: 0x060100EC RID: 65772 RVA: 0x003D4444 File Offset: 0x003D2644
		private void OnCloseClicked(IXUISprite go)
		{
			this.CloseDlg();
		}

		// Token: 0x060100ED RID: 65773 RVA: 0x003D4450 File Offset: 0x003D2650
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

		// Token: 0x060100EE RID: 65774 RVA: 0x003D4574 File Offset: 0x003D2774
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

		// Token: 0x04007272 RID: 29298
		public Action OnClosed;

		// Token: 0x04007273 RID: 29299
		private XFlowerReplyDocument _Doc;

		// Token: 0x04007274 RID: 29300
		private int _flowerID;

		// Token: 0x04007275 RID: 29301
		private ulong _senderID;

		// Token: 0x04007276 RID: 29302
		private string _senderName;

		// Token: 0x04007277 RID: 29303
		private int _senderPower;

		// Token: 0x04007278 RID: 29304
		private int _senderProfession;

		// Token: 0x04007279 RID: 29305
		private int _senderVip;

		// Token: 0x0400727A RID: 29306
		private int _sendCount;

		// Token: 0x0400727B RID: 29307
		private Vector2 m_DragDistance = Vector2.zero;

		// Token: 0x0400727C RID: 29308
		private bool m_CancelRecord = false;
	}
}
