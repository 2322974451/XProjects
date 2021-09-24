using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GuildArenaRankDlg : DlgBase<GuildArenaRankDlg, GuildArenaRankBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildArena/GuildArenaRankDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdate));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.SendReqGuildArenaHistory();
		}

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

		public void SetHistoryList(List<GuildArenaHistory> historys)
		{
			this.m_historys = historys;
			this.Refresh();
		}

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

		private bool ClickShow(IXUIButton btn)
		{
			return false;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickClose));
		}

		private bool ClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private List<GuildArenaHistory> m_historys;
	}
}
