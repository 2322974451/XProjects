using System;
using KKSG;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class GVGCombatInfoDisplay
	{

		public uint RoomID
		{
			get
			{
				return this.m_battleID;
			}
		}

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

		public void SetCombatState(CrossGvgRoomState state, uint watchID = 0U)
		{
			this.m_watchBtn.SetVisible(state == CrossGvgRoomState.CGRS_Fighting && watchID > 0U);
		}

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

		private GVGCombatGuildDisplay m_guildMemberA;

		private GVGCombatGuildDisplay m_guildMemberB;

		private IXUIButton m_watchBtn;

		private int m_combatID;

		private int m_index;

		private uint m_battleID;
	}
}
