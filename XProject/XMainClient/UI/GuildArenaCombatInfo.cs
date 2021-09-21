using System;
using KKSG;
using UILib;

namespace XMainClient.UI
{
	// Token: 0x02001831 RID: 6193
	internal class GuildArenaCombatInfo : DlgHandlerBase
	{
		// Token: 0x06010143 RID: 65859 RVA: 0x003D6D18 File Offset: 0x003D4F18
		protected override void Init()
		{
			base.Init();
			this.m_Doc = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			this.m_watchBtn = (base.PanelObject.transform.FindChild("btn_Watch").GetComponent("XUIButton") as IXUIButton);
			this.m_guildMemberA = DlgHandlerBase.EnsureCreate<GuildArenaGuildInfo>(ref this.m_guildMemberA, base.PanelObject.transform.FindChild("Team1").gameObject, null, true);
			this.m_guildMemberB = DlgHandlerBase.EnsureCreate<GuildArenaGuildInfo>(ref this.m_guildMemberB, base.PanelObject.transform.FindChild("Team2").gameObject, null, true);
			this.m_watchBtn.SetVisible(false);
		}

		// Token: 0x06010144 RID: 65860 RVA: 0x003D6DD0 File Offset: 0x003D4FD0
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

		// Token: 0x1700392C RID: 14636
		// (get) Token: 0x06010145 RID: 65861 RVA: 0x003D6E24 File Offset: 0x003D5024
		public uint BattleID
		{
			get
			{
				return this.m_battleID;
			}
		}

		// Token: 0x06010146 RID: 65862 RVA: 0x003D6E3C File Offset: 0x003D503C
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

		// Token: 0x06010147 RID: 65863 RVA: 0x003D6F10 File Offset: 0x003D5110
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

		// Token: 0x06010148 RID: 65864 RVA: 0x003D6FEC File Offset: 0x003D51EC
		public void SetCombatState(uint state, uint watchID = 0U)
		{
			this.m_watchBtn.SetVisible(state == 2U && watchID > 0U);
		}

		// Token: 0x06010149 RID: 65865 RVA: 0x003D7006 File Offset: 0x003D5206
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_watchBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnWatchClick));
		}

		// Token: 0x0601014A RID: 65866 RVA: 0x003D7028 File Offset: 0x003D5228
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<GuildArenaGuildInfo>(ref this.m_guildMemberA);
			DlgHandlerBase.EnsureUnload<GuildArenaGuildInfo>(ref this.m_guildMemberB);
			base.OnUnload();
		}

		// Token: 0x0601014B RID: 65867 RVA: 0x003D704C File Offset: 0x003D524C
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

		// Token: 0x040072B2 RID: 29362
		private GuildArenaGuildInfo m_guildMemberA;

		// Token: 0x040072B3 RID: 29363
		private GuildArenaGuildInfo m_guildMemberB;

		// Token: 0x040072B4 RID: 29364
		private IXUIButton m_watchBtn;

		// Token: 0x040072B5 RID: 29365
		private int m_combatID;

		// Token: 0x040072B6 RID: 29366
		private int m_index;

		// Token: 0x040072B7 RID: 29367
		private uint m_battleID;

		// Token: 0x040072B8 RID: 29368
		private XGuildArenaDocument m_Doc;

		// Token: 0x040072B9 RID: 29369
		private GuildArenaGroupData m_GroupData;
	}
}
