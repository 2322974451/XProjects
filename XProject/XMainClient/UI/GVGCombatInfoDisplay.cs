using System;
using KKSG;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x020016EE RID: 5870
	internal class GVGCombatInfoDisplay
	{
		// Token: 0x1700375D RID: 14173
		// (get) Token: 0x0600F240 RID: 62016 RVA: 0x0035B4E4 File Offset: 0x003596E4
		public uint RoomID
		{
			get
			{
				return this.m_battleID;
			}
		}

		// Token: 0x0600F241 RID: 62017 RVA: 0x0035B4FC File Offset: 0x003596FC
		public void Setup(Transform t)
		{
			this.m_watchBtn = (t.FindChild("btn_Watch").GetComponent("XUIButton") as IXUIButton);
			this.m_guildMemberA = new GVGCombatGuildDisplay();
			this.m_guildMemberA.Setup(t.FindChild("Team1"));
			this.m_guildMemberB = new GVGCombatGuildDisplay();
			this.m_guildMemberB.Setup(t.FindChild("Team2"));
			this.m_watchBtn.SetVisible(false);
			this.m_watchBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnWatchClick));
		}

		// Token: 0x0600F242 RID: 62018 RVA: 0x0035B594 File Offset: 0x00359794
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

		// Token: 0x1700375E RID: 14174
		// (get) Token: 0x0600F243 RID: 62019 RVA: 0x0035B5E8 File Offset: 0x003597E8
		public uint BattleID
		{
			get
			{
				return this.m_battleID;
			}
		}

		// Token: 0x0600F244 RID: 62020 RVA: 0x0035B600 File Offset: 0x00359800
		public void SetGroup(XGVGCombatGroupData combat)
		{
			bool flag = combat == null;
			if (flag)
			{
				this.m_watchBtn.ID = 0UL;
				this.SetCombatState((CrossGvgRoomState)0, 0U);
			}
			else
			{
				this.m_watchBtn.ID = (ulong)combat.WatchID;
				this.m_guildMemberA.SetGuildMember(combat.GuildOne, combat.Winner, false);
				this.m_guildMemberB.SetGuildMember(combat.GuildTwo, combat.Winner, false);
				this.SetCombatState(combat.RoomState, combat.WatchID);
			}
		}

		// Token: 0x0600F245 RID: 62021 RVA: 0x0035B68B File Offset: 0x0035988B
		public void SetCombatState(CrossGvgRoomState state, uint watchID = 0U)
		{
			this.m_watchBtn.SetVisible(state == CrossGvgRoomState.CGRS_Fighting && watchID > 0U);
		}

		// Token: 0x0600F246 RID: 62022 RVA: 0x0035B6A8 File Offset: 0x003598A8
		public void Recycle()
		{
			bool flag = this.m_guildMemberA != null;
			if (flag)
			{
				this.m_guildMemberA.Recycle();
				this.m_guildMemberA = null;
			}
			bool flag2 = this.m_guildMemberB != null;
			if (flag2)
			{
				this.m_guildMemberB.Recycle();
				this.m_guildMemberB = null;
			}
		}

		// Token: 0x0600F247 RID: 62023 RVA: 0x0035B6FC File Offset: 0x003598FC
		private bool OnWatchClick(IXUIButton watchBtn)
		{
			bool flag = watchBtn.ID > 0UL;
			if (flag)
			{
				XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
				specificDocument.EnterSpectateBattle((uint)watchBtn.ID, LiveType.LIVE_CROSSGVG);
			}
			return false;
		}

		// Token: 0x040067BB RID: 26555
		private GVGCombatGuildDisplay m_guildMemberA;

		// Token: 0x040067BC RID: 26556
		private GVGCombatGuildDisplay m_guildMemberB;

		// Token: 0x040067BD RID: 26557
		private IXUIButton m_watchBtn;

		// Token: 0x040067BE RID: 26558
		private int m_combatID;

		// Token: 0x040067BF RID: 26559
		private int m_index;

		// Token: 0x040067C0 RID: 26560
		private uint m_battleID;
	}
}
