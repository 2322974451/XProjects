using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CED RID: 3309
	internal class GuildArenaDuelCombatInfo
	{
		// Token: 0x0600B93B RID: 47419 RVA: 0x0025930C File Offset: 0x0025750C
		public string GetPortraitName()
		{
			return XGuildDocument.GetPortraitName((int)this.GuildIcon);
		}

		// Token: 0x0600B93C RID: 47420 RVA: 0x0025932C File Offset: 0x0025752C
		public bool Pass()
		{
			return this.GuildID > 0UL;
		}

		// Token: 0x0600B93D RID: 47421 RVA: 0x00259348 File Offset: 0x00257548
		public void Convert(CrossGvgRoomState room)
		{
			switch (room)
			{
			case CrossGvgRoomState.CGRS_Idle:
				this.gs = GVGDuelStatu.IDLE;
				break;
			case CrossGvgRoomState.CGRS_Fighting:
				this.gs = GVGDuelStatu.FIGHTING;
				break;
			case CrossGvgRoomState.CGRS_Finish:
				this.gs = GVGDuelStatu.FINISH;
				break;
			default:
				this.gs = GVGDuelStatu.IDLE;
				break;
			}
		}

		// Token: 0x0600B93E RID: 47422 RVA: 0x00259394 File Offset: 0x00257594
		public string GetGuildName()
		{
			bool flag = this.GuildID > 0UL;
			string result;
			if (flag)
			{
				result = this.GuildName;
			}
			else
			{
				result = XStringDefineProxy.GetString("GUILD_ARENA_UNCOMBAT");
			}
			return result;
		}

		// Token: 0x0600B93F RID: 47423 RVA: 0x002593C8 File Offset: 0x002575C8
		public string ToTimeString()
		{
			return XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)this.CombatTime, XStringDefineProxy.GetString("TIME_FORMAT_YYMMDD"), true);
		}

		// Token: 0x040049C8 RID: 18888
		public ulong GuildID;

		// Token: 0x040049C9 RID: 18889
		public bool IsDo;

		// Token: 0x040049CA RID: 18890
		public uint GuildScore;

		// Token: 0x040049CB RID: 18891
		public string GuildName;

		// Token: 0x040049CC RID: 18892
		public uint GuildIcon;

		// Token: 0x040049CD RID: 18893
		public uint CombatTime;

		// Token: 0x040049CE RID: 18894
		public bool Winner;

		// Token: 0x040049CF RID: 18895
		public bool isShow = false;

		// Token: 0x040049D0 RID: 18896
		public IntegralState Step = IntegralState.integralready;

		// Token: 0x040049D1 RID: 18897
		public GVGDuelStatu gs = GVGDuelStatu.IDLE;

		// Token: 0x040049D2 RID: 18898
		public GuildArenaDuelCombatStatu Statu = GuildArenaDuelCombatStatu.Next;

		// Token: 0x040049D3 RID: 18899
		public uint AddScore = 0U;
	}
}
