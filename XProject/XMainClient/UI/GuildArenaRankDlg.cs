using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001753 RID: 5971
	internal class GuildArenaRankDlg : DlgBase<GuildArenaRankDlg, GuildArenaRankBehaviour>
	{
		// Token: 0x170037F4 RID: 14324
		// (get) Token: 0x0600F6A6 RID: 63142 RVA: 0x0037FC30 File Offset: 0x0037DE30
		public override string fileName
		{
			get
			{
				return "Guild/GuildArena/GuildArenaRankDlg";
			}
		}

		// Token: 0x170037F5 RID: 14325
		// (get) Token: 0x0600F6A7 RID: 63143 RVA: 0x0037FC48 File Offset: 0x0037DE48
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037F6 RID: 14326
		// (get) Token: 0x0600F6A8 RID: 63144 RVA: 0x0037FC5C File Offset: 0x0037DE5C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F6A9 RID: 63145 RVA: 0x0037FC6F File Offset: 0x0037DE6F
		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdate));
		}

		// Token: 0x0600F6AA RID: 63146 RVA: 0x0037FC98 File Offset: 0x0037DE98
		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.SendReqGuildArenaHistory();
		}

		// Token: 0x0600F6AB RID: 63147 RVA: 0x0037FCC8 File Offset: 0x0037DEC8
		private void OnWrapContentUpdate(Transform t, int index)
		{
			IXUILabelSymbol ixuilabelSymbol = t.FindChild("First").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabelSymbol ixuilabelSymbol2 = t.FindChild("Second").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel = t.FindChild("Number").GetComponent("XUILabel") as IXUILabel;
			IXUIButton ixuibutton = t.FindChild("Btn_View").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.SetVisible(false);
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickShow));
			ixuilabel.SetText(XStringDefineProxy.GetString("GUILD_ARENA_INDEX", new object[]
			{
				index + 1
			}));
			bool flag = this.m_historys == null || index >= this.m_historys.Count;
			if (flag)
			{
				ixuilabelSymbol.InputText = "?";
				ixuilabelSymbol2.InputText = "?";
			}
			else
			{
				GuildArenaHistory guildArenaHistory = this.m_historys[index];
				ixuilabelSymbol.InputText = guildArenaHistory.first;
				ixuilabelSymbol2.InputText = guildArenaHistory.second;
			}
		}

		// Token: 0x0600F6AC RID: 63148 RVA: 0x0037FDE6 File Offset: 0x0037DFE6
		public void SetHistoryList(List<GuildArenaHistory> historys)
		{
			this.m_historys = historys;
			this.Refresh();
		}

		// Token: 0x0600F6AD RID: 63149 RVA: 0x0037FDF8 File Offset: 0x0037DFF8
		public void Refresh()
		{
			int num = 0;
			bool flag = this.m_historys != null;
			if (flag)
			{
				num = this.m_historys.Count;
			}
			base.uiBehaviour.m_WrapContent.SetContentCount(num, false);
			base.uiBehaviour.m_ScrollView.ResetPosition();
			base.uiBehaviour.m_NA.gameObject.SetActive(num == 0);
		}

		// Token: 0x0600F6AE RID: 63150 RVA: 0x0037FE60 File Offset: 0x0037E060
		private bool ClickShow(IXUIButton btn)
		{
			return false;
		}

		// Token: 0x0600F6AF RID: 63151 RVA: 0x0037FE73 File Offset: 0x0037E073
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickClose));
		}

		// Token: 0x0600F6B0 RID: 63152 RVA: 0x0037FE9C File Offset: 0x0037E09C
		private bool ClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x04006B2E RID: 27438
		private List<GuildArenaHistory> m_historys;
	}
}
