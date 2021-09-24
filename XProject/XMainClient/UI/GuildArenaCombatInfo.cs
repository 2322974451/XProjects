using System;
using KKSG;
using UILib;

namespace XMainClient.UI
{

	internal class GuildArenaCombatInfo : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_Doc = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			this.m_watchBtn = (base.PanelObject.transform.FindChild("btn_Watch").GetComponent("XUIButton") as IXUIButton);
			this.m_guildMemberA = DlgHandlerBase.EnsureCreate<GuildArenaGuildInfo>(ref this.m_guildMemberA, base.PanelObject.transform.FindChild("Team1").gameObject, null, true);
			this.m_guildMemberB = DlgHandlerBase.EnsureCreate<GuildArenaGuildInfo>(ref this.m_guildMemberB, base.PanelObject.transform.FindChild("Team2").gameObject, null, true);
			this.m_watchBtn.SetVisible(false);
		}

		public void Set(int combat, int index)
		{
			this.m_combatID = combat;
			this.m_index = index;
			switch (combat)
			{
			case 0:
				this.m_battleID = (uint)(index + 1);
				break;
			case 1:
				this.m_battleID = (uint)(index + 5);
				break;
			case 2:
				this.m_battleID = 7U;
				break;
			}
		}

		public uint BattleID
		{
			get
			{
				return this.m_battleID;
			}
		}

		public void SetCombatGroup(uint selectTabIndex)
		{
			this.m_GroupData = this.m_Doc.GetGuildGroup(selectTabIndex, this.BattleID);
			bool flag = this.m_GroupData == null;
			if (flag)
			{
				this.m_watchBtn.ID = 0UL;
				this.SetCombatState(0U, 0U);
				this.SetNextWinner(selectTabIndex);
			}
			else
			{
				this.m_watchBtn.ID = (ulong)this.m_GroupData.watchId;
				this.m_guildMemberA.SetGuildMember(this.m_GroupData.guildOneId, this.m_GroupData.winerId, false);
				this.m_guildMemberB.SetGuildMember(this.m_GroupData.guildTwoId, this.m_GroupData.winerId, false);
				this.SetCombatState(this.m_GroupData.warstate, this.m_GroupData.watchId);
			}
		}

		private void SetNextWinner(uint selectTabIndex)
		{
			switch (this.m_battleID)
			{
			case 5U:
				this.m_guildMemberA.SetGuildMember(this.m_Doc.GetArenaWinnerGuildID(selectTabIndex, 1U), 0UL, false);
				this.m_guildMemberB.SetGuildMember(this.m_Doc.GetArenaWinnerGuildID(selectTabIndex, 2U), 0UL, false);
				break;
			case 6U:
				this.m_guildMemberA.SetGuildMember(this.m_Doc.GetArenaWinnerGuildID(selectTabIndex, 3U), 0UL, false);
				this.m_guildMemberB.SetGuildMember(this.m_Doc.GetArenaWinnerGuildID(selectTabIndex, 4U), 0UL, false);
				break;
			case 7U:
				this.m_guildMemberA.SetGuildMember(this.m_Doc.GetArenaWinnerGuildID(selectTabIndex, 5U), 0UL, false);
				this.m_guildMemberB.SetGuildMember(this.m_Doc.GetArenaWinnerGuildID(selectTabIndex, 6U), 0UL, false);
				break;
			}
		}

		public void SetCombatState(uint state, uint watchID = 0U)
		{
			this.m_watchBtn.SetVisible(state == 2U && watchID > 0U);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_watchBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnWatchClick));
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<GuildArenaGuildInfo>(ref this.m_guildMemberA);
			DlgHandlerBase.EnsureUnload<GuildArenaGuildInfo>(ref this.m_guildMemberB);
			base.OnUnload();
		}

		private bool OnWatchClick(IXUIButton watchBtn)
		{
			bool flag = watchBtn.ID > 0UL;
			if (flag)
			{
				XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
				specificDocument.EnterSpectateBattle((uint)watchBtn.ID, LiveType.LIVE_GUILDBATTLE);
			}
			return false;
		}

		private GuildArenaGuildInfo m_guildMemberA;

		private GuildArenaGuildInfo m_guildMemberB;

		private IXUIButton m_watchBtn;

		private int m_combatID;

		private int m_index;

		private uint m_battleID;

		private XGuildArenaDocument m_Doc;

		private GuildArenaGroupData m_GroupData;
	}
}
