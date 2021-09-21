using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016ED RID: 5869
	internal class GVGCombatHandlerBase : DlgHandlerBase
	{
		// Token: 0x17003758 RID: 14168
		// (get) Token: 0x0600F22B RID: 61995 RVA: 0x0035AE98 File Offset: 0x00359098
		protected virtual bool InGVGTime
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003759 RID: 14169
		// (get) Token: 0x0600F22C RID: 61996 RVA: 0x0035AEAC File Offset: 0x003590AC
		protected virtual bool HasGVGJion
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700375A RID: 14170
		// (get) Token: 0x0600F22D RID: 61997 RVA: 0x0035AEC0 File Offset: 0x003590C0
		protected virtual bool VisibelEnterBattle
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700375B RID: 14171
		// (get) Token: 0x0600F22E RID: 61998 RVA: 0x0035AED4 File Offset: 0x003590D4
		protected virtual CrossGvgRoomState RoomState
		{
			get
			{
				return CrossGvgRoomState.CGRS_Idle;
			}
		}

		// Token: 0x0600F22F RID: 61999 RVA: 0x0035AEE8 File Offset: 0x003590E8
		protected virtual XGVGCombatGroupData GetCombatGroup(uint roomID)
		{
			return null;
		}

		// Token: 0x1700375C RID: 14172
		// (get) Token: 0x0600F230 RID: 62000 RVA: 0x0035AEFC File Offset: 0x003590FC
		protected virtual GuildArenaState TimeState
		{
			get
			{
				return GuildArenaState.GUILD_ARENA_END;
			}
		}

		// Token: 0x0600F231 RID: 62001 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void SetupOtherInfo()
		{
		}

		// Token: 0x0600F232 RID: 62002 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void EnterScene()
		{
		}

		// Token: 0x0600F233 RID: 62003 RVA: 0x0035AF10 File Offset: 0x00359110
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

		// Token: 0x0600F234 RID: 62004 RVA: 0x0035AFF8 File Offset: 0x003591F8
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

		// Token: 0x0600F235 RID: 62005 RVA: 0x0035B1CC File Offset: 0x003593CC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_enterBattle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterBattleClick));
			this.m_showRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowRankClick));
		}

		// Token: 0x0600F236 RID: 62006 RVA: 0x0035B208 File Offset: 0x00359408
		private bool OnShowRankClick(IXUIButton btn)
		{
			DlgBase<GuildArenaRankDlg, GuildArenaRankBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x0600F237 RID: 62007 RVA: 0x0035B228 File Offset: 0x00359428
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

		// Token: 0x0600F238 RID: 62008 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600F239 RID: 62009 RVA: 0x0035B274 File Offset: 0x00359474
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

		// Token: 0x0600F23A RID: 62010 RVA: 0x0035B2B8 File Offset: 0x003594B8
		private void InitCombatHandle()
		{
			this.CreateCombatHandle(0, this.FirstRoomSize);
			this.CreateCombatHandle(1, this.SecondRoomSize);
			this.CreateCombatHandle(2, this.TopRoomSize);
		}

		// Token: 0x0600F23B RID: 62011 RVA: 0x0035B2E8 File Offset: 0x003594E8
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

		// Token: 0x0600F23C RID: 62012 RVA: 0x0035B354 File Offset: 0x00359554
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

		// Token: 0x0600F23D RID: 62013 RVA: 0x0035B3C4 File Offset: 0x003595C4
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

		// Token: 0x0600F23E RID: 62014 RVA: 0x0035B444 File Offset: 0x00359644
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

		// Token: 0x040067AD RID: 26541
		private Transform m_CombatPanel;

		// Token: 0x040067AE RID: 26542
		private Transform m_NaPanel;

		// Token: 0x040067AF RID: 26543
		private List<GVGCombatInfoDisplay> m_GuildCombat = new List<GVGCombatInfoDisplay>();

		// Token: 0x040067B0 RID: 26544
		private GVGCombatGuildDisplay m_GuildCup;

		// Token: 0x040067B1 RID: 26545
		private IXUILabel m_combatTips;

		// Token: 0x040067B2 RID: 26546
		private IXUISprite m_honorSprite;

		// Token: 0x040067B3 RID: 26547
		private IXUILabel m_naLabel;

		// Token: 0x040067B4 RID: 26548
		private IXUIButton m_enterBattle;

		// Token: 0x040067B5 RID: 26549
		protected IXUIButton m_showRank;

		// Token: 0x040067B6 RID: 26550
		protected IXUILabel m_RegistrationCount;

		// Token: 0x040067B7 RID: 26551
		protected IXUILabel m_helpLabel;

		// Token: 0x040067B8 RID: 26552
		protected uint FirstRoomSize = 4U;

		// Token: 0x040067B9 RID: 26553
		protected uint SecondRoomSize = 2U;

		// Token: 0x040067BA RID: 26554
		protected uint TopRoomSize = 1U;
	}
}
