using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001750 RID: 5968
	internal class GuildArenaDuelInfo
	{
		// Token: 0x0600F699 RID: 63129 RVA: 0x0037F518 File Offset: 0x0037D718
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

		// Token: 0x0600F69A RID: 63130 RVA: 0x0037F6F0 File Offset: 0x0037D8F0
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

		// Token: 0x0600F69B RID: 63131 RVA: 0x0037F930 File Offset: 0x0037DB30
		private void OnEnterBattle(IXUISprite sprite)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.SendEnterDuelBattle(this.m_index);
		}

		// Token: 0x0600F69C RID: 63132 RVA: 0x0037F958 File Offset: 0x0037DB58
		public void Reset()
		{
			this.m_time.SetText(string.Empty);
			this.m_next.gameObject.SetActive(true);
			this.m_used.gameObject.SetActive(false);
			this.m_current.gameObject.SetActive(false);
		}

		// Token: 0x0600F69D RID: 63133 RVA: 0x0037F9B0 File Offset: 0x0037DBB0
		private void OnClickGuildHandle(IXUISprite sprite)
		{
			bool flag = sprite.ID > 0UL;
			if (flag)
			{
				XGuildViewDocument specificDocument = XDocuments.GetSpecificDocument<XGuildViewDocument>(XGuildViewDocument.uuID);
				specificDocument.View(sprite.ID);
			}
		}

		// Token: 0x04006B13 RID: 27411
		private IXUILabel m_time;

		// Token: 0x04006B14 RID: 27412
		private IXUILabel m_guildNameCurrent;

		// Token: 0x04006B15 RID: 27413
		private IXUILabel m_guildNameUsed;

		// Token: 0x04006B16 RID: 27414
		private IXUISprite m_PortraitCurrent;

		// Token: 0x04006B17 RID: 27415
		private IXUISprite m_PortraitUsed;

		// Token: 0x04006B18 RID: 27416
		private IXUISprite m_enterBattle;

		// Token: 0x04006B19 RID: 27417
		private IXUILabel m_score;

		// Token: 0x04006B1A RID: 27418
		private Transform m_UsedPortraitEmpty;

		// Token: 0x04006B1B RID: 27419
		private Transform m_CurrentPortraitEmpty;

		// Token: 0x04006B1C RID: 27420
		private Transform m_CurrentVS;

		// Token: 0x04006B1D RID: 27421
		private Transform m_CurrentMessage;

		// Token: 0x04006B1E RID: 27422
		private Transform m_win;

		// Token: 0x04006B1F RID: 27423
		private Transform m_lose;

		// Token: 0x04006B20 RID: 27424
		private Transform m_current;

		// Token: 0x04006B21 RID: 27425
		private Transform m_next;

		// Token: 0x04006B22 RID: 27426
		private Transform m_used;

		// Token: 0x04006B23 RID: 27427
		private int m_index;
	}
}
