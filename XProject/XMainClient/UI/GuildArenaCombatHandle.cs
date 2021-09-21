using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001830 RID: 6192
	internal class GuildArenaCombatHandle : DlgHandlerBase
	{
		// Token: 0x1700392B RID: 14635
		// (get) Token: 0x06010134 RID: 65844 RVA: 0x003D6624 File Offset: 0x003D4824
		protected override string FileName
		{
			get
			{
				return "Guild/GuildArena/CombatFrame";
			}
		}

		// Token: 0x06010135 RID: 65845 RVA: 0x003D663C File Offset: 0x003D483C
		public override void RefreshData()
		{
			base.RefreshData();
			bool bInArenaTime = this._Doc.bInArenaTime;
			if (bInArenaTime)
			{
				this.m_RegistrationCount.SetVisible(true);
				this.m_CombatPanel.gameObject.SetActive(true);
				this.m_NaPanel.gameObject.SetActive(false);
				this.RefreshMessage();
				this.RefreshCombatHandle();
			}
			else
			{
				this.m_RegistrationCount.SetVisible(false);
				this.m_CombatPanel.gameObject.SetActive(false);
				this.m_NaPanel.gameObject.SetActive(true);
			}
			bool flag = this._Doc.bHasAvailableJion && this._Doc.VisibleEnterBattle;
			if (flag)
			{
				this.m_enterBattle.SetVisible(true);
				uint canEnterBattle = this._Doc.CanEnterBattle;
				if (canEnterBattle - 1U > 1U)
				{
					if (canEnterBattle != 3U)
					{
						this.m_enterBattle.SetGrey(false);
					}
					else
					{
						this.m_enterBattle.SetGrey(false);
					}
				}
				else
				{
					this.m_enterBattle.SetGrey(true);
				}
			}
			else
			{
				this.m_enterBattle.SetVisible(false);
			}
		}

		// Token: 0x06010136 RID: 65846 RVA: 0x003D675C File Offset: 0x003D495C
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			this.m_CombatPanel = base.PanelObject.transform.FindChild("Combat");
			this.m_NaPanel = base.PanelObject.transform.FindChild("NA");
			this.m_naLabel = (base.PanelObject.transform.FindChild("NA/tip").GetComponent("XUILabel") as IXUILabel);
			this.m_naLabel.SetText(XStringDefineProxy.GetString("GUILD_ARENA_COMBAT_NA"));
			Transform tabTpl = base.PanelObject.transform.FindChild("Combat/Tabs/TabTpl");
			this.m_tabControl.SetTabTpl(tabTpl);
			this.m_GuildCup = DlgHandlerBase.EnsureCreate<GuildArenaGuildInfo>(ref this.m_GuildCup, base.PanelObject.transform.FindChild("Combat/Cup").gameObject, null, true);
			this.m_combatTips = (base.PanelObject.transform.FindChild("Combat/txt_TimeLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_honorSprite = (base.PanelObject.transform.FindChild("Combat/honor").GetComponent("XUISprite") as IXUISprite);
			this.m_enterBattle = (base.PanelObject.transform.FindChild("Combat/LetMeDie").GetComponent("XUIButton") as IXUIButton);
			this.m_enterBattle.SetVisible(false);
			this.m_showRank = (base.PanelObject.transform.FindChild("TopRankBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_RegistrationCount = (base.PanelObject.transform.FindChild("Title/Period").GetComponent("XUILabel") as IXUILabel);
			this.m_RegistrationCount.SetVisible(false);
			this.InitCombatHandle();
		}

		// Token: 0x06010137 RID: 65847 RVA: 0x003D693A File Offset: 0x003D4B3A
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_enterBattle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterBattleClick));
			this.m_showRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowRankClick));
		}

		// Token: 0x06010138 RID: 65848 RVA: 0x003D6974 File Offset: 0x003D4B74
		private bool OnShowRankClick(IXUIButton btn)
		{
			DlgBase<GuildArenaRankDlg, GuildArenaRankBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x06010139 RID: 65849 RVA: 0x003D6994 File Offset: 0x003D4B94
		private bool OnEnterBattleClick(IXUIButton btn)
		{
			bool flag = this._Doc.CanEnterBattle != 1U && this._Doc.CanEnterBattle != 2U;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_ARENA_OUTTIME"), "fece00");
				result = false;
			}
			else
			{
				this._Doc.SendGuildArenaJoinBattle();
				result = false;
			}
			return result;
		}

		// Token: 0x0601013A RID: 65850 RVA: 0x003D69F8 File Offset: 0x003D4BF8
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
			this.m_RegistrationCount.SetText(XStringDefineProxy.GetString("CROSS_GVG_Registration", new object[]
			{
				this._Doc.RegistrationCount
			}));
			this._Doc.SendGuildArenaInfo();
		}

		// Token: 0x0601013B RID: 65851 RVA: 0x003D6A50 File Offset: 0x003D4C50
		public override void OnUnload()
		{
			this.UnLoadCombatHandle(ref this.m_GuildCombat);
			DlgHandlerBase.EnsureUnload<GuildArenaGuildInfo>(ref this.m_GuildCup);
			bool flag = this.m_tabControl != null;
			if (flag)
			{
				this.m_tabControl = null;
			}
			base.OnUnload();
		}

		// Token: 0x0601013C RID: 65852 RVA: 0x003D6A94 File Offset: 0x003D4C94
		private void InitCombatHandle()
		{
			this.CreateCombatHandle(0, 4);
			this.CreateCombatHandle(1, 2);
			this.CreateCombatHandle(2, 1);
		}

		// Token: 0x0601013D RID: 65853 RVA: 0x003D6AB4 File Offset: 0x003D4CB4
		private void UnLoadCombatHandle(ref List<GuildArenaCombatInfo> guildCombats)
		{
			bool flag = guildCombats == null;
			if (!flag)
			{
				int i = 0;
				int count = guildCombats.Count;
				while (i < count)
				{
					bool flag2 = guildCombats[i] != null;
					if (flag2)
					{
						guildCombats[i].OnUnload();
						guildCombats[i] = null;
					}
					i++;
				}
				guildCombats.Clear();
				guildCombats = null;
			}
		}

		// Token: 0x0601013E RID: 65854 RVA: 0x003D6B20 File Offset: 0x003D4D20
		private void CreateCombatHandle(int combat, int size)
		{
			for (int i = 0; i < size; i++)
			{
				string text = string.Format("Combat/Battle/Battle_{0}_{1}", combat, i);
				GuildArenaCombatInfo guildArenaCombatInfo = null;
				guildArenaCombatInfo = DlgHandlerBase.EnsureCreate<GuildArenaCombatInfo>(ref guildArenaCombatInfo, base.PanelObject.transform.FindChild(text).gameObject, null, true);
				guildArenaCombatInfo.Set(combat, i);
				this.m_GuildCombat.Add(guildArenaCombatInfo);
			}
		}

		// Token: 0x0601013F RID: 65855 RVA: 0x003D6B90 File Offset: 0x003D4D90
		private void RefreshCombatHandle()
		{
			this.RefreshTitleHandle();
			int i = 0;
			int count = this.m_GuildCombat.Count;
			while (i < count)
			{
				this.m_GuildCombat[i].SetCombatGroup((uint)this._Doc.SelectWarIndex);
				i++;
			}
			uint battleID = 7U;
			ulong arenaWinnerGuildID = this._Doc.GetArenaWinnerGuildID((uint)this._Doc.SelectWarIndex, battleID);
			this.m_GuildCup.SetGuildMember(arenaWinnerGuildID, arenaWinnerGuildID, true);
		}

		// Token: 0x06010140 RID: 65856 RVA: 0x003D6C0C File Offset: 0x003D4E0C
		private void RefreshTitleHandle()
		{
			string sprite = string.Empty;
			switch (this._Doc.SelectWarIndex)
			{
			case 1:
				sprite = "guildpvp_honor_0";
				break;
			case 2:
				sprite = "guildpvp_honor_1";
				break;
			case 3:
				sprite = "guildpvp_honor_2";
				break;
			}
			this.m_honorSprite.SetSprite(sprite);
			this.m_honorSprite.MakePixelPerfect();
		}

		// Token: 0x06010141 RID: 65857 RVA: 0x003D6C74 File Offset: 0x003D4E74
		private void RefreshMessage()
		{
			GuildArenaState timeState = this._Doc.TimeState;
			string text = string.Empty;
			switch (timeState)
			{
			case GuildArenaState.GUILD_ARENA_NOT_BEGIN:
			case GuildArenaState.GUILD_ARENA_BEGIN:
			case GuildArenaState.GUILD_ARENA_BATTLE_ONE:
				text = XStringDefineProxy.GetString("GUILD_ARENA_MESSAGE1");
				break;
			case GuildArenaState.GUILD_ARENA_BATTLE_TWO:
				text = XStringDefineProxy.GetString("GUILD_ARENA_MESSAGE2");
				break;
			case GuildArenaState.GUILD_ARENA_BATTLE_FINAL:
				text = XStringDefineProxy.GetString("GUILD_ARENA_MESSAGE3");
				break;
			default:
				text = string.Empty;
				break;
			}
			this.m_combatTips.SetText(text);
		}

		// Token: 0x040072A6 RID: 29350
		private Transform m_CombatPanel;

		// Token: 0x040072A7 RID: 29351
		private Transform m_NaPanel;

		// Token: 0x040072A8 RID: 29352
		private XUITabControl m_tabControl = new XUITabControl();

		// Token: 0x040072A9 RID: 29353
		private List<GuildArenaCombatInfo> m_GuildCombat = new List<GuildArenaCombatInfo>();

		// Token: 0x040072AA RID: 29354
		private GuildArenaGuildInfo m_GuildCup;

		// Token: 0x040072AB RID: 29355
		private IXUILabel m_combatTips;

		// Token: 0x040072AC RID: 29356
		private XGuildArenaDocument _Doc = null;

		// Token: 0x040072AD RID: 29357
		private IXUISprite m_honorSprite;

		// Token: 0x040072AE RID: 29358
		private IXUILabel m_naLabel;

		// Token: 0x040072AF RID: 29359
		private IXUIButton m_enterBattle;

		// Token: 0x040072B0 RID: 29360
		private IXUIButton m_showRank;

		// Token: 0x040072B1 RID: 29361
		private IXUILabel m_RegistrationCount;
	}
}
