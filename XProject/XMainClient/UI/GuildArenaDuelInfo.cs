using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildArenaDuelInfo
	{

		public void Init(Transform t, int index)
		{
			this.m_index = index;
			this.m_current = t.FindChild("Current");
			this.m_next = t.FindChild("Next");
			this.m_used = t.FindChild("Used");
			this.m_win = t.FindChild("Used/Result/Win");
			this.m_lose = t.FindChild("Used/Result/Lose");
			this.m_time = (t.FindChild("Day").GetComponent("XUILabel") as IXUILabel);
			this.m_guildNameCurrent = (t.FindChild("Current/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_guildNameUsed = (t.FindChild("Used/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_PortraitCurrent = (t.FindChild("Current/Portrait").GetComponent("XUISprite") as IXUISprite);
			this.m_PortraitUsed = (t.FindChild("Used/Portrait").GetComponent("XUISprite") as IXUISprite);
			this.m_CurrentPortraitEmpty = t.FindChild("Current/Portrait_empty");
			this.m_UsedPortraitEmpty = t.FindChild("Used/Portrait_empty");
			this.m_CurrentVS = t.FindChild("Current/VS");
			this.m_CurrentMessage = t.FindChild("Current/VS_empty");
			this.m_score = (t.FindChild("Used/Score").GetComponent("XUILabel") as IXUILabel);
			this.m_enterBattle = (t.FindChild("Current/Btn").GetComponent("XUISprite") as IXUISprite);
			this.m_PortraitCurrent.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickGuildHandle));
			this.m_PortraitUsed.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickGuildHandle));
			this.m_enterBattle.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnEnterBattle));
		}

		public void Refresh()
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			bool flag = this.m_index < specificDocument.DuelCombatInfos.Count;
			if (flag)
			{
				GuildArenaDuelCombatInfo guildArenaDuelCombatInfo = specificDocument.DuelCombatInfos[this.m_index];
				this.m_time.SetText(guildArenaDuelCombatInfo.ToTimeString());
				this.m_next.gameObject.SetActive(guildArenaDuelCombatInfo.Statu == GuildArenaDuelCombatStatu.Next);
				this.m_used.gameObject.SetActive(guildArenaDuelCombatInfo.Statu == GuildArenaDuelCombatStatu.Used);
				this.m_current.gameObject.SetActive(guildArenaDuelCombatInfo.Statu == GuildArenaDuelCombatStatu.Current);
				GuildArenaDuelCombatStatu statu = guildArenaDuelCombatInfo.Statu;
				if (statu != GuildArenaDuelCombatStatu.Used)
				{
					if (statu == GuildArenaDuelCombatStatu.Current)
					{
						this.m_guildNameCurrent.SetText(guildArenaDuelCombatInfo.GetGuildName());
						this.m_PortraitCurrent.SetSprite(guildArenaDuelCombatInfo.GetPortraitName());
						this.m_PortraitCurrent.SetVisible(guildArenaDuelCombatInfo.Pass());
						this.m_PortraitCurrent.SetVisible(guildArenaDuelCombatInfo.Pass());
						this.m_CurrentPortraitEmpty.gameObject.SetActive(!guildArenaDuelCombatInfo.Pass());
						this.m_enterBattle.SetGrey(guildArenaDuelCombatInfo.Step == IntegralState.integralenterscene || guildArenaDuelCombatInfo.Step == IntegralState.integralwatch);
						this.m_enterBattle.SetVisible(guildArenaDuelCombatInfo.Pass());
						this.m_CurrentVS.gameObject.SetActive(guildArenaDuelCombatInfo.Pass());
						this.m_CurrentMessage.gameObject.SetActive(!guildArenaDuelCombatInfo.Pass());
					}
				}
				else
				{
					this.m_guildNameUsed.SetText(guildArenaDuelCombatInfo.GetGuildName());
					this.m_PortraitUsed.SetSprite(guildArenaDuelCombatInfo.GetPortraitName());
					this.m_UsedPortraitEmpty.gameObject.SetActive(!guildArenaDuelCombatInfo.Pass());
					this.m_PortraitUsed.SetVisible(guildArenaDuelCombatInfo.Pass());
					this.m_score.SetText(XSingleton<XCommon>.singleton.StringCombine("+", guildArenaDuelCombatInfo.GuildScore.ToString()));
					this.m_win.gameObject.SetActive(guildArenaDuelCombatInfo.Winner);
					this.m_lose.gameObject.SetActive(!guildArenaDuelCombatInfo.Winner);
				}
			}
			else
			{
				this.Reset();
			}
		}

		private void OnEnterBattle(IXUISprite sprite)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.SendEnterDuelBattle(this.m_index);
		}

		public void Reset()
		{
			this.m_time.SetText(string.Empty);
			this.m_next.gameObject.SetActive(true);
			this.m_used.gameObject.SetActive(false);
			this.m_current.gameObject.SetActive(false);
		}

		private void OnClickGuildHandle(IXUISprite sprite)
		{
			bool flag = sprite.ID > 0UL;
			if (flag)
			{
				XGuildViewDocument specificDocument = XDocuments.GetSpecificDocument<XGuildViewDocument>(XGuildViewDocument.uuID);
				specificDocument.View(sprite.ID);
			}
		}

		private IXUILabel m_time;

		private IXUILabel m_guildNameCurrent;

		private IXUILabel m_guildNameUsed;

		private IXUISprite m_PortraitCurrent;

		private IXUISprite m_PortraitUsed;

		private IXUISprite m_enterBattle;

		private IXUILabel m_score;

		private Transform m_UsedPortraitEmpty;

		private Transform m_CurrentPortraitEmpty;

		private Transform m_CurrentVS;

		private Transform m_CurrentMessage;

		private Transform m_win;

		private Transform m_lose;

		private Transform m_current;

		private Transform m_next;

		private Transform m_used;

		private int m_index;
	}
}
