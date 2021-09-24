using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GVGCombatHandlerBase : DlgHandlerBase
	{

		protected virtual bool InGVGTime
		{
			get
			{
				return false;
			}
		}

		protected virtual bool HasGVGJion
		{
			get
			{
				return false;
			}
		}

		protected virtual bool VisibelEnterBattle
		{
			get
			{
				return false;
			}
		}

		protected virtual CrossGvgRoomState RoomState
		{
			get
			{
				return CrossGvgRoomState.CGRS_Idle;
			}
		}

		protected virtual XGVGCombatGroupData GetCombatGroup(uint roomID)
		{
			return null;
		}

		protected virtual GuildArenaState TimeState
		{
			get
			{
				return GuildArenaState.GUILD_ARENA_END;
			}
		}

		protected virtual void SetupOtherInfo()
		{
		}

		protected virtual void EnterScene()
		{
		}

		public override void RefreshData()
		{
			base.RefreshData();
			bool inGVGTime = this.InGVGTime;
			if (inGVGTime)
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
			this.SetupOtherInfo();
			bool flag = this.HasGVGJion && this.VisibelEnterBattle;
			if (flag)
			{
				this.m_enterBattle.SetVisible(true);
				this.m_enterBattle.SetGrey(this.RoomState == CrossGvgRoomState.CGRS_Fighting);
			}
			else
			{
				this.m_enterBattle.SetVisible(false);
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_CombatPanel = base.PanelObject.transform.FindChild("Combat");
			this.m_NaPanel = base.PanelObject.transform.FindChild("NA");
			this.m_naLabel = (base.PanelObject.transform.FindChild("NA/tip").GetComponent("XUILabel") as IXUILabel);
			this.m_naLabel.SetText(XStringDefineProxy.GetString("GUILD_ARENA_COMBAT_NA"));
			this.m_helpLabel = (base.PanelObject.transform.FindChild("txt_helpLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildCup = new GVGCombatGuildDisplay();
			this.m_GuildCup.Setup(base.PanelObject.transform.FindChild("Combat/Cup"));
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
			bool flag = this.RoomState != CrossGvgRoomState.CGRS_Fighting;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_ARENA_OUTTIME"), "fece00");
				result = false;
			}
			else
			{
				this.EnterScene();
				result = false;
			}
			return result;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		public override void OnUnload()
		{
			this.UnLoadCombatHandle(ref this.m_GuildCombat);
			bool flag = this.m_GuildCup != null;
			if (flag)
			{
				this.m_GuildCup.Recycle();
				this.m_GuildCup = null;
			}
			base.OnUnload();
		}

		private void InitCombatHandle()
		{
			this.CreateCombatHandle(0, this.FirstRoomSize);
			this.CreateCombatHandle(1, this.SecondRoomSize);
			this.CreateCombatHandle(2, this.TopRoomSize);
		}

		private void UnLoadCombatHandle(ref List<GVGCombatInfoDisplay> guildCombats)
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
						guildCombats[i].Recycle();
						guildCombats[i] = null;
					}
					i++;
				}
				guildCombats.Clear();
				guildCombats = null;
			}
		}

		private void CreateCombatHandle(int combat, uint size)
		{
			int num = 0;
			while ((long)num < (long)((ulong)size))
			{
				string text = string.Format("Combat/Battle/Battle_{0}_{1}", combat, num);
				GVGCombatInfoDisplay gvgcombatInfoDisplay = new GVGCombatInfoDisplay();
				gvgcombatInfoDisplay.Setup(base.PanelObject.transform.FindChild(text));
				gvgcombatInfoDisplay.Set(combat, num);
				this.m_GuildCombat.Add(gvgcombatInfoDisplay);
				num++;
			}
		}

		private void RefreshCombatHandle()
		{
			int i = 0;
			int count = this.m_GuildCombat.Count;
			while (i < count)
			{
				this.m_GuildCombat[i].SetGroup(this.GetCombatGroup(this.m_GuildCombat[i].RoomID));
				i++;
			}
			XGVGCombatGroupData combatGroup = this.GetCombatGroup(7U);
			this.m_GuildCup.SetGuildMember((combatGroup != null && combatGroup.Winner != null) ? combatGroup.Winner : null, null, true);
		}

		private void RefreshMessage()
		{
			string text = string.Empty;
			switch (this.TimeState)
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

		private List<GVGCombatInfoDisplay> m_GuildCombat = new List<GVGCombatInfoDisplay>();

		private GVGCombatGuildDisplay m_GuildCup;

		private IXUILabel m_combatTips;

		private IXUISprite m_honorSprite;

		private IXUILabel m_naLabel;

		private IXUIButton m_enterBattle;

		protected IXUIButton m_showRank;

		protected IXUILabel m_RegistrationCount;

		protected IXUILabel m_helpLabel;

		protected uint FirstRoomSize = 4U;

		protected uint SecondRoomSize = 2U;

		protected uint TopRoomSize = 1U;
	}
}
