using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001877 RID: 6263
	internal class QuickReplyDlg : DlgBase<QuickReplyDlg, XQuickReplyBehavior>
	{
		// Token: 0x170039C1 RID: 14785
		// (get) Token: 0x060104CC RID: 66764 RVA: 0x003F1C50 File Offset: 0x003EFE50
		public override string fileName
		{
			get
			{
				return "GameSystem/QuickReplyDlg";
			}
		}

		// Token: 0x170039C2 RID: 14786
		// (get) Token: 0x060104CD RID: 66765 RVA: 0x003F1C68 File Offset: 0x003EFE68
		public override int layer
		{
			get
			{
				return 100;
			}
		}

		// Token: 0x170039C3 RID: 14787
		// (get) Token: 0x060104CE RID: 66766 RVA: 0x003F1C7C File Offset: 0x003EFE7C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060104CF RID: 66767 RVA: 0x003F1C8F File Offset: 0x003EFE8F
		public void ShowView(int type, Action<bool> action = null)
		{
			this.m_quickReplyType = type;
			this.m_cancelAction = action;
			this.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x060104D0 RID: 66768 RVA: 0x003F1CA9 File Offset: 0x003EFEA9
		protected override void Init()
		{
			this._Doc = XDocuments.GetSpecificDocument<XQuickReplyDocument>(XQuickReplyDocument.uuID);
		}

		// Token: 0x060104D1 RID: 66769 RVA: 0x003F1CBC File Offset: 0x003EFEBC
		protected override void OnShow()
		{
			base.OnShow();
			this.OnUpdateReplyList();
			this.OnShowTitle();
		}

		// Token: 0x060104D2 RID: 66770 RVA: 0x003F1CD4 File Offset: 0x003EFED4
		private void OnShowTitle()
		{
			string key = string.Format("QUICK_REPLY_{0}", this.m_quickReplyType);
			this.m_uiBehaviour.m_Title.SetText(XStringDefineProxy.GetString(key));
		}

		// Token: 0x060104D3 RID: 66771 RVA: 0x003F1D10 File Offset: 0x003EFF10
		private void OnUpdateReplyList()
		{
			List<QuickReplyTable.RowData> quickReplyList = this._Doc.GetQuickReplyList(this.m_quickReplyType);
			bool flag = quickReplyList == null;
			if (!flag)
			{
				int count = quickReplyList.Count;
				this.m_uiBehaviour.m_ItemPool.FakeReturnAll();
				for (int i = 0; i < count; i++)
				{
					GameObject gameObject = this.m_uiBehaviour.m_ItemPool.FetchGameObject(false);
					QuickReplyTable.RowData rowData = quickReplyList[i];
					gameObject.name = rowData.ID.ToString();
					gameObject.transform.localPosition = this.m_uiBehaviour.m_ItemPool.TplPos - new Vector3(0f, (float)(this.m_uiBehaviour.m_ItemPool.TplHeight * i));
					IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel = gameObject.transform.FindChild("Content").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(rowData.Content);
					ixuisprite.ID = (ulong)((long)rowData.ID);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReplyClicked));
				}
				this.m_uiBehaviour.m_ItemPool.ActualReturnAll(false);
				this.m_uiBehaviour.m_WrapScrollView.ResetPosition();
			}
		}

		// Token: 0x060104D4 RID: 66772 RVA: 0x003F1E6C File Offset: 0x003F006C
		private void OnReplyClicked(IXUISprite button)
		{
			QuickReplyTable.RowData rowData = this._Doc.GetRowData((int)button.ID);
			DlgBase<XChatView, XChatBehaviour>.singleton.AddChat(rowData.Content, ChatChannelType.Guild, null, false);
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("INVITATION_SENT_NOTIFICATION"), "fece00");
			bool flag = this.m_cancelAction != null;
			if (flag)
			{
				this.m_cancelAction(true);
				this.m_cancelAction = null;
				this.SetVisible(false, true);
			}
		}

		// Token: 0x060104D5 RID: 66773 RVA: 0x003F1EE8 File Offset: 0x003F00E8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Voice.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnVoicePressButton));
			base.uiBehaviour.m_Voice.RegisterDragEventHandler(new ButtonDragEventHandler(this.OnVoiceDragButton));
		}

		// Token: 0x060104D6 RID: 66774 RVA: 0x003F1F54 File Offset: 0x003F0154
		private void OnCloseClicked(IXUISprite go)
		{
			bool flag = this.m_cancelAction != null;
			if (flag)
			{
				this.m_cancelAction(false);
				this.m_cancelAction = null;
			}
			this.SetVisible(false, true);
		}

		// Token: 0x060104D7 RID: 66775 RVA: 0x003F1F90 File Offset: 0x003F0190
		private void OnVoicePressButton(IXUIButton button, bool state)
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
				DlgBase<XChatView, XChatBehaviour>.singleton.SetActiveChannel(ChatChannelType.Guild);
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
					bool flag2 = this.m_cancelAction != null;
					if (flag2)
					{
						this.m_cancelAction(true);
						this.m_cancelAction = null;
						this.SetVisible(false, true);
					}
				}
			}
		}

		// Token: 0x060104D8 RID: 66776 RVA: 0x003F2050 File Offset: 0x003F0250
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

		// Token: 0x060104D9 RID: 66777 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void _WrapContentItemUpdated(Transform t, int index)
		{
		}

		// Token: 0x0400753E RID: 30014
		private XQuickReplyDocument _Doc;

		// Token: 0x0400753F RID: 30015
		private int m_quickReplyType = 1;

		// Token: 0x04007540 RID: 30016
		private Vector2 m_DragDistance = Vector2.zero;

		// Token: 0x04007541 RID: 30017
		private bool m_CancelRecord = false;

		// Token: 0x04007542 RID: 30018
		private Action<bool> m_cancelAction = null;
	}
}
