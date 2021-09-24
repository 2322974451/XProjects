using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class QuickReplyDlg : DlgBase<QuickReplyDlg, XQuickReplyBehavior>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/QuickReplyDlg";
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

		public void ShowView(int type, Action<bool> action = null)
		{
			this.m_quickReplyType = type;
			this.m_cancelAction = action;
			this.SetVisibleWithAnimation(true, null);
		}

		protected override void Init()
		{
			this._Doc = XDocuments.GetSpecificDocument<XQuickReplyDocument>(XQuickReplyDocument.uuID);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.OnUpdateReplyList();
			this.OnShowTitle();
		}

		private void OnShowTitle()
		{
			string key = string.Format("QUICK_REPLY_{0}", this.m_quickReplyType);
			this.m_uiBehaviour.m_Title.SetText(XStringDefineProxy.GetString(key));
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Voice.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnVoicePressButton));
			base.uiBehaviour.m_Voice.RegisterDragEventHandler(new ButtonDragEventHandler(this.OnVoiceDragButton));
		}

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

		private void _WrapContentItemUpdated(Transform t, int index)
		{
		}

		private XQuickReplyDocument _Doc;

		private int m_quickReplyType = 1;

		private Vector2 m_DragDistance = Vector2.zero;

		private bool m_CancelRecord = false;

		private Action<bool> m_cancelAction = null;
	}
}
