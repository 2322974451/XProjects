using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016F0 RID: 5872
	internal class GVGDuelWrapDisplay
	{
		// Token: 0x0600F251 RID: 62033 RVA: 0x0035BB38 File Offset: 0x00359D38
		public void Setup(Transform t, int index, SpriteClickEventHandler handler)
		{
			this._index = index;
			this.m_current = t.FindChild("Current");
			this.m_next = t.FindChild("Next");
			this.m_used = t.FindChild("Used");
			this.m_win = t.FindChild("Used/Result/Win");
			this.m_lose = t.FindChild("Used/Result/Lose");
			this.m_time = (t.FindChild("Day").GetComponent("XUILabel") as IXUILabel);
			this.m_guildNameCurrent = (t.FindChild("Current/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_guildNameUsed = (t.FindChild("Used/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_guildNameNext = (t.FindChild("Next/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_PortraitCurrent = (t.FindChild("Current/Portrait").GetComponent("XUISprite") as IXUISprite);
			this.m_PortraitUsed = (t.FindChild("Used/Portrait").GetComponent("XUISprite") as IXUISprite);
			this.m_PortraitNext = (t.FindChild("Next/Portrait").GetComponent("XUISprite") as IXUISprite);
			this.m_CurrentPortraitEmpty = t.FindChild("Current/Portrait_empty");
			this.m_UsedPortraitEmpty = t.FindChild("Used/Portrait_empty");
			this.m_NextPortraitEmpty = t.FindChild("Next/Portrait_empty");
			this.m_CurrentVS = t.FindChild("Current/VS");
			this.m_CurrentMessage = t.FindChild("Current/VS_empty");
			this.m_score = (t.FindChild("Used/Score").GetComponent("XUILabel") as IXUILabel);
			this.m_enterBattle = (t.FindChild("Current/Btn").GetComponent("XUISprite") as IXUISprite);
			this.m_enterBattle.RegisterSpriteClickEventHandler(handler);
			this.m_enterBattle.ID = (ulong)((long)index);
		}

		// Token: 0x0600F252 RID: 62034 RVA: 0x0035BD34 File Offset: 0x00359F34
		public void Reset()
		{
			this.m_time.SetText(string.Empty);
			this.m_next.gameObject.SetActive(true);
			this.m_used.gameObject.SetActive(false);
			this.m_current.gameObject.SetActive(false);
		}

		// Token: 0x0600F253 RID: 62035 RVA: 0x0035BD8C File Offset: 0x00359F8C
		public void Set(GVGDuelCombatInfo combatInfo)
		{
			bool flag = combatInfo == null;
			if (flag)
			{
				this.Reset();
			}
			else
			{
				this.m_time.SetText(combatInfo.ToTimeString());
				this.m_next.gameObject.SetActive(combatInfo.gs == GVGDuelStatu.IDLE);
				this.m_used.gameObject.SetActive(combatInfo.gs == GVGDuelStatu.FINISH);
				this.m_current.gameObject.SetActive(combatInfo.gs == GVGDuelStatu.FIGHTING);
				GVGDuelStatu gs = combatInfo.gs;
				if (gs != GVGDuelStatu.FINISH)
				{
					if (gs != GVGDuelStatu.FIGHTING)
					{
						this.m_guildNameNext.SetText(combatInfo.GetGuildName());
						this.m_PortraitNext.SetSprite(combatInfo.GetPortraitName());
						this.m_PortraitNext.SetVisible(combatInfo.Pass());
						this.m_PortraitNext.SetVisible(combatInfo.Pass());
						this.m_PortraitNext.ID = combatInfo.GuildID;
						this.m_NextPortraitEmpty.gameObject.SetActive(!combatInfo.Pass());
					}
					else
					{
						this.m_guildNameCurrent.SetText(combatInfo.GetGuildName());
						this.m_PortraitCurrent.SetSprite(combatInfo.GetPortraitName());
						this.m_PortraitCurrent.SetVisible(combatInfo.Pass());
						this.m_PortraitCurrent.SetVisible(combatInfo.Pass());
						this.m_PortraitCurrent.ID = combatInfo.GuildID;
						this.m_CurrentPortraitEmpty.gameObject.SetActive(!combatInfo.Pass());
						this.m_enterBattle.SetGrey(combatInfo.gs == GVGDuelStatu.FIGHTING);
						this.m_enterBattle.SetVisible(combatInfo.Pass());
						this.m_CurrentVS.gameObject.SetActive(combatInfo.Pass());
						this.m_CurrentMessage.gameObject.SetActive(!combatInfo.Pass());
					}
				}
				else
				{
					this.m_guildNameUsed.SetText(combatInfo.GetGuildName());
					this.m_PortraitUsed.SetSprite(combatInfo.GetPortraitName());
					this.m_UsedPortraitEmpty.gameObject.SetActive(!combatInfo.Pass());
					this.m_PortraitUsed.SetVisible(combatInfo.Pass());
					this.m_score.SetText(XSingleton<XCommon>.singleton.StringCombine("+", combatInfo.AddScore.ToString()));
					this.m_win.gameObject.SetActive(combatInfo.Winner);
					this.m_lose.gameObject.SetActive(!combatInfo.Winner);
					this.m_PortraitUsed.ID = combatInfo.GuildID;
				}
			}
		}

		// Token: 0x0600F254 RID: 62036 RVA: 0x0035C02C File Offset: 0x0035A22C
		public void Recycle()
		{
			this.m_time = null;
			this.m_guildNameCurrent = null;
			this.m_guildNameUsed = null;
			this.m_guildNameNext = null;
			this.m_PortraitCurrent = null;
			this.m_PortraitUsed = null;
			this.m_PortraitNext = null;
			this.m_enterBattle = null;
			this.m_score = null;
			this.m_UsedPortraitEmpty = null;
			this.m_CurrentPortraitEmpty = null;
			this.m_NextPortraitEmpty = null;
			this.m_CurrentVS = null;
			this.m_CurrentMessage = null;
			this.m_win = null;
			this.m_lose = null;
			this.m_current = null;
			this.m_next = null;
			this.m_used = null;
		}

		// Token: 0x040067C6 RID: 26566
		private IXUILabel m_time;

		// Token: 0x040067C7 RID: 26567
		private IXUILabel m_guildNameCurrent;

		// Token: 0x040067C8 RID: 26568
		private IXUILabel m_guildNameUsed;

		// Token: 0x040067C9 RID: 26569
		private IXUILabel m_guildNameNext;

		// Token: 0x040067CA RID: 26570
		private IXUISprite m_PortraitCurrent;

		// Token: 0x040067CB RID: 26571
		private IXUISprite m_PortraitUsed;

		// Token: 0x040067CC RID: 26572
		private IXUISprite m_PortraitNext;

		// Token: 0x040067CD RID: 26573
		private IXUISprite m_enterBattle;

		// Token: 0x040067CE RID: 26574
		private IXUILabel m_score;

		// Token: 0x040067CF RID: 26575
		private Transform m_UsedPortraitEmpty;

		// Token: 0x040067D0 RID: 26576
		private Transform m_CurrentPortraitEmpty;

		// Token: 0x040067D1 RID: 26577
		private Transform m_NextPortraitEmpty;

		// Token: 0x040067D2 RID: 26578
		private Transform m_CurrentVS;

		// Token: 0x040067D3 RID: 26579
		private Transform m_CurrentMessage;

		// Token: 0x040067D4 RID: 26580
		private Transform m_win;

		// Token: 0x040067D5 RID: 26581
		private Transform m_lose;

		// Token: 0x040067D6 RID: 26582
		private Transform m_current;

		// Token: 0x040067D7 RID: 26583
		private Transform m_next;

		// Token: 0x040067D8 RID: 26584
		private Transform m_used;

		// Token: 0x040067D9 RID: 26585
		private int _index;
	}
}
