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

	internal class GuildArenaCombatHandle : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Guild/GuildArena/CombatFrame";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_enterBattle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterBattleClick));
			this.m_showRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowRankClick));
		}

		private bool OnShowRankClick(IXUIButton btn)
		{
			DlgBase<GuildArenaRankDlg, GuildArenaRankBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

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

		private void InitCombatHandle()
		{
			this.CreateCombatHandle(0, 4);
			this.CreateCombatHandle(1, 2);
			this.CreateCombatHandle(2, 1);
		}

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

		private Transform m_CombatPanel;

		private Transform m_NaPanel;

		private XUITabControl m_tabControl = new XUITabControl();

		private List<GuildArenaCombatInfo> m_GuildCombat = new List<GuildArenaCombatInfo>();

		private GuildArenaGuildInfo m_GuildCup;

		private IXUILabel m_combatTips;

		private XGuildArenaDocument _Doc = null;

		private IXUISprite m_honorSprite;

		private IXUILabel m_naLabel;

		private IXUIButton m_enterBattle;

		private IXUIButton m_showRank;

		private IXUILabel m_RegistrationCount;
	}
}
