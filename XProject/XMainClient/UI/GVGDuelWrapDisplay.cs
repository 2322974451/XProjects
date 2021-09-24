using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GVGDuelWrapDisplay
	{

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

		public void Reset()
		{
			this.m_time.SetText(string.Empty);
			this.m_next.gameObject.SetActive(true);
			this.m_used.gameObject.SetActive(false);
			this.m_current.gameObject.SetActive(false);
		}

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

		private IXUILabel m_time;

		private IXUILabel m_guildNameCurrent;

		private IXUILabel m_guildNameUsed;

		private IXUILabel m_guildNameNext;

		private IXUISprite m_PortraitCurrent;

		private IXUISprite m_PortraitUsed;

		private IXUISprite m_PortraitNext;

		private IXUISprite m_enterBattle;

		private IXUILabel m_score;

		private Transform m_UsedPortraitEmpty;

		private Transform m_CurrentPortraitEmpty;

		private Transform m_NextPortraitEmpty;

		private Transform m_CurrentVS;

		private Transform m_CurrentMessage;

		private Transform m_win;

		private Transform m_lose;

		private Transform m_current;

		private Transform m_next;

		private Transform m_used;

		private int _index;
	}
}
