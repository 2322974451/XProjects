using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008F9 RID: 2297
	internal class GVGDuelCombatInfo
	{
		// Token: 0x06008AF3 RID: 35571 RVA: 0x00128570 File Offset: 0x00126770
		public string GetPortraitName()
		{
			return XGuildDocument.GetPortraitName((int)this.GuildIcon);
		}

		// Token: 0x06008AF4 RID: 35572 RVA: 0x00128590 File Offset: 0x00126790
		public bool Pass()
		{
			return this.GuildID > 0UL;
		}

		// Token: 0x06008AF5 RID: 35573 RVA: 0x001285AC File Offset: 0x001267AC
		public void Setup(CrossGvgRacePointRecord cgrp)
		{
			this.roomID = cgrp.roomid;
			this.CombatTime = cgrp.time;
			this.GuildID = cgrp.opponent.guildid;
			this.GuildName = cgrp.opponent.guildname;
			this.GuildScore = cgrp.opponent.score;
			this.GuildIcon = cgrp.opponent.icon;
			this.ServerID = (ulong)cgrp.opponent.serverid;
			this.Winner = cgrp.iswin;
			this.AddScore = cgrp.addscore;
			this.Convert(cgrp.state);
		}

		// Token: 0x06008AF6 RID: 35574 RVA: 0x00128650 File Offset: 0x00126850
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

		// Token: 0x06008AF7 RID: 35575 RVA: 0x0012869C File Offset: 0x0012689C
		public string GetGuildName()
		{
			bool flag = this.GuildID > 0UL;
			string @string;
			if (flag)
			{
				@string = XStringDefineProxy.GetString("CROSS_GVG_GUILDNAME", new object[]
				{
					this.ServerID,
					this.GuildName
				});
			}
			else
			{
				@string = XStringDefineProxy.GetString("GUILD_ARENA_UNCOMBAT");
			}
			return @string;
		}

		// Token: 0x06008AF8 RID: 35576 RVA: 0x001286F0 File Offset: 0x001268F0
		public string ToTimeString()
		{
			return XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)this.CombatTime, XStringDefineProxy.GetString("TIME_FORMAT_YYMMDD"), true);
		}

		// Token: 0x04002C52 RID: 11346
		public uint roomID;

		// Token: 0x04002C53 RID: 11347
		public ulong GuildID;

		// Token: 0x04002C54 RID: 11348
		public uint GuildScore;

		// Token: 0x04002C55 RID: 11349
		public string GuildName;

		// Token: 0x04002C56 RID: 11350
		public uint GuildIcon;

		// Token: 0x04002C57 RID: 11351
		public uint CombatTime;

		// Token: 0x04002C58 RID: 11352
		public ulong ServerID;

		// Token: 0x04002C59 RID: 11353
		public bool Winner;

		// Token: 0x04002C5A RID: 11354
		public bool isShow = false;

		// Token: 0x04002C5B RID: 11355
		public GVGDuelStatu gs = GVGDuelStatu.IDLE;

		// Token: 0x04002C5C RID: 11356
		public GVGDuelCombatInfo.GVGDuelCombatStatu Statu = GVGDuelCombatInfo.GVGDuelCombatStatu.Next;

		// Token: 0x04002C5D RID: 11357
		public uint AddScore = 0U;

		// Token: 0x02001958 RID: 6488
		public enum GVGDuelCombatStatu
		{
			// Token: 0x04007DCD RID: 32205
			Used,
			// Token: 0x04007DCE RID: 32206
			Current,
			// Token: 0x04007DCF RID: 32207
			Next
		}
	}
}
