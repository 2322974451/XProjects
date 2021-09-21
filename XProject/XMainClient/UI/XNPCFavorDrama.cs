using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001701 RID: 5889
	internal class XNPCFavorDrama
	{
		// Token: 0x0600F2C6 RID: 62150 RVA: 0x0035E074 File Offset: 0x0035C274
		public void ShowNpc(XNpc npc)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(true, true);
			this.doc = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			this._param = XDataPool<XFavorParam>.GetData();
			this._param.Npc = npc;
			this.npcId = npc.TypeID;
			XNPCFavorDocument.ShowNPCDrama(npc.TypeID);
		}

		// Token: 0x0600F2C7 RID: 62151 RVA: 0x0035E0D0 File Offset: 0x0035C2D0
		public uint GetXNpcId()
		{
			return this.npcId;
		}

		// Token: 0x0600F2C8 RID: 62152 RVA: 0x0035E0E8 File Offset: 0x0035C2E8
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

		// Token: 0x0600F2C9 RID: 62153 RVA: 0x0035E240 File Offset: 0x0035C440
		private bool IsSendDialogOpen()
		{
			return DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible() && DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsSendDilogVisible();
		}

		// Token: 0x0600F2CA RID: 62154 RVA: 0x0035E26C File Offset: 0x0035C46C
		private bool IsChangeDialogOpen()
		{
			return DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible() && DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsChangeDialogVisible();
		}

		// Token: 0x0600F2CB RID: 62155 RVA: 0x0035E297 File Offset: 0x0035C497
		private void _FireEvent(XFavorParam param)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetUpFavorParam(param);
			param.Recycle();
		}

		// Token: 0x0600F2CC RID: 62156 RVA: 0x0035E2B0 File Offset: 0x0035C4B0
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

		// Token: 0x0600F2CD RID: 62157 RVA: 0x0035E370 File Offset: 0x0035C570
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

		// Token: 0x0600F2CE RID: 62158 RVA: 0x0035E3BC File Offset: 0x0035C5BC
		private bool ToConfirmSend()
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600F2CF RID: 62159 RVA: 0x0035E3DC File Offset: 0x0035C5DC
		private string GetRandomGiveWords()
		{
			NpcFeeling.RowData npcTableInfoByXId = XNPCFavorDocument.GetNpcTableInfoByXId(this.GetXNpcId());
			return (npcTableInfoByXId == null) ? string.Empty : this.GetRandomStr(npcTableInfoByXId.giveWords);
		}

		// Token: 0x0600F2D0 RID: 62160 RVA: 0x0035E410 File Offset: 0x0035C610
		private string GetSendSuccessWords()
		{
			NpcFeeling.RowData npcTableInfoByXId = XNPCFavorDocument.GetNpcTableInfoByXId(this.GetXNpcId());
			return (npcTableInfoByXId == null) ? string.Empty : this.GetRandomStr(npcTableInfoByXId.giveSuccessWords);
		}

		// Token: 0x0600F2D1 RID: 62161 RVA: 0x0035E444 File Offset: 0x0035C644
		private string GetRandomExchangeWords()
		{
			NpcFeeling.RowData npcTableInfoByXId = XNPCFavorDocument.GetNpcTableInfoByXId(this.GetXNpcId());
			return (npcTableInfoByXId == null) ? string.Empty : this.GetRandomStr(npcTableInfoByXId.exchangeWords);
		}

		// Token: 0x0600F2D2 RID: 62162 RVA: 0x0035E478 File Offset: 0x0035C678
		private string GetExchangeSuccessWords()
		{
			NpcFeeling.RowData npcTableInfoByXId = XNPCFavorDocument.GetNpcTableInfoByXId(this.GetXNpcId());
			return (npcTableInfoByXId == null) ? string.Empty : this.GetRandomStr(npcTableInfoByXId.giveSuccessWords);
		}

		// Token: 0x0600F2D3 RID: 62163 RVA: 0x0035E4AC File Offset: 0x0035C6AC
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

		// Token: 0x0600F2D4 RID: 62164 RVA: 0x0035E4E4 File Offset: 0x0035C6E4
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

		// Token: 0x0600F2D5 RID: 62165 RVA: 0x0035E53C File Offset: 0x0035C73C
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

		// Token: 0x0400681B RID: 26651
		private XFavorParam _param;

		// Token: 0x0400681C RID: 26652
		private XNPCFavorDocument doc;

		// Token: 0x0400681D RID: 26653
		private uint npcId = 0U;

		// Token: 0x0400681E RID: 26654
		public bool BDeprecated = true;
	}
}
