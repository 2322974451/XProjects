using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XNPCFavorDrama
	{

		public void ShowNpc(XNpc npc)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(true, true);
			this.doc = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			this._param = XDataPool<XFavorParam>.GetData();
			this._param.Npc = npc;
			this.npcId = npc.TypeID;
			XNPCFavorDocument.ShowNPCDrama(npc.TypeID);
		}

		public uint GetXNpcId()
		{
			return this.npcId;
		}

		public void RefreshOperateStatus(bool isfirst = false, string text = null)
		{
			bool flag = this._param == null;
			if (!flag)
			{
				EFavorState state = this.doc.GetState(this.GetXNpcId());
				bool bRecycled = this._param.bRecycled;
				if (bRecycled)
				{
					this._param = XDataPool<XFavorParam>.GetData();
				}
				switch (state)
				{
				case EFavorState.CanSend:
					this._param.Text = ((text == null) ? this.GetRandomGiveWords() : text);
					this._param.isShowSend = !this.IsSendDialogOpen();
					this._param.isShowExchange = false;
					this._param.sendCallback = new ButtonClickEventHandler(this.ToSend);
					break;
				case EFavorState.SendWithExchange:
				case EFavorState.Exchange:
					this._param.Text = ((text == null) ? this.GetRandomGiveWords() : text);
					this._param.isShowSend = (!this.IsSendDialogOpen() && !this.IsChangeDialogOpen());
					this._param.isShowExchange = !this.IsChangeDialogOpen();
					this._param.isShowExchangeRedpoint = true;
					this._param.sendCallback = new ButtonClickEventHandler(this.ToSend);
					this._param.exchangeCallback = new ButtonClickEventHandler(this.ToExchange);
					break;
				}
				this._FireEvent(this._param);
			}
		}

		private bool IsSendDialogOpen()
		{
			return DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible() && DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsSendDilogVisible();
		}

		private bool IsChangeDialogOpen()
		{
			return DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible() && DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsChangeDialogVisible();
		}

		private void _FireEvent(XFavorParam param)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetUpFavorParam(param);
			param.Recycle();
		}

		private bool ToSend(IXUIButton button)
		{
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				NpcFeelingOneNpc oneNpcByXId = this.doc.GetOneNpcByXId(this.GetXNpcId());
				bool flag2 = oneNpcByXId != null && this.doc.IsCanSend();
				if (flag2)
				{
					bool flag3 = this.doc.IsCanLevelUp(oneNpcByXId);
					if (flag3)
					{
						NpcFeeling.RowData npcTableInfoByXId = XNPCFavorDocument.GetNpcTableInfoByXId(this.GetXNpcId());
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("NPCFavorisFull"), npcTableInfoByXId.name), "fece00");
					}
					else
					{
						DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.ShowNPCFavorSend();
						this.RefreshOperateStatus(false, this.GetRandomGiveWords());
						this._FireEvent(this._param);
					}
				}
			}
			return true;
		}

		private bool ToExchange(IXUIButton button)
		{
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.ShowNPCFavorExchnage();
				this.RefreshOperateStatus(false, this.GetRandomExchangeWords());
				this._FireEvent(this._param);
			}
			return true;
		}

		private bool ToConfirmSend()
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private string GetRandomGiveWords()
		{
			NpcFeeling.RowData npcTableInfoByXId = XNPCFavorDocument.GetNpcTableInfoByXId(this.GetXNpcId());
			return (npcTableInfoByXId == null) ? string.Empty : this.GetRandomStr(npcTableInfoByXId.giveWords);
		}

		private string GetSendSuccessWords()
		{
			NpcFeeling.RowData npcTableInfoByXId = XNPCFavorDocument.GetNpcTableInfoByXId(this.GetXNpcId());
			return (npcTableInfoByXId == null) ? string.Empty : this.GetRandomStr(npcTableInfoByXId.giveSuccessWords);
		}

		private string GetRandomExchangeWords()
		{
			NpcFeeling.RowData npcTableInfoByXId = XNPCFavorDocument.GetNpcTableInfoByXId(this.GetXNpcId());
			return (npcTableInfoByXId == null) ? string.Empty : this.GetRandomStr(npcTableInfoByXId.exchangeWords);
		}

		private string GetExchangeSuccessWords()
		{
			NpcFeeling.RowData npcTableInfoByXId = XNPCFavorDocument.GetNpcTableInfoByXId(this.GetXNpcId());
			return (npcTableInfoByXId == null) ? string.Empty : this.GetRandomStr(npcTableInfoByXId.giveSuccessWords);
		}

		private string GetRandomStr(string[] content)
		{
			bool flag = content != null && content.Length != 0;
			string result;
			if (flag)
			{
				result = content[XSingleton<XCommon>.singleton.RandomInt(content.Length)];
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		public void SendSuccess()
		{
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.NtfSendDramaRefresh();
				this.RefreshOperateStatus(false, this.GetSendSuccessWords());
				this._FireEvent(this._param);
			}
			this.doc.PlaySendSuccessFx(this.GetXNpcId());
		}

		public void ExchangeSuccess()
		{
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.NtfExchangeDlgClose();
				this.RefreshOperateStatus(false, this.GetExchangeSuccessWords());
				this._FireEvent(this._param);
			}
			this.doc.PlayExchangeSuccessFx(this.GetXNpcId());
		}

		private XFavorParam _param;

		private XNPCFavorDocument doc;

		private uint npcId = 0U;

		public bool BDeprecated = true;
	}
}
