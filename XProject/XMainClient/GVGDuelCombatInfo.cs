using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GVGDuelCombatInfo
	{

		public string GetPortraitName()
		{
			return XGuildDocument.GetPortraitName((int)this.GuildIcon);
		}

		public bool Pass()
		{
			return this.GuildID > 0UL;
		}

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

		public string ToTimeString()
		{
			return XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)this.CombatTime, XStringDefineProxy.GetString("TIME_FORMAT_YYMMDD"), true);
		}

		public uint roomID;

		public ulong GuildID;

		public uint GuildScore;

		public string GuildName;

		public uint GuildIcon;

		public uint CombatTime;

		public ulong ServerID;

		public bool Winner;

		public bool isShow = false;

		public GVGDuelStatu gs = GVGDuelStatu.IDLE;

		public GVGDuelCombatInfo.GVGDuelCombatStatu Statu = GVGDuelCombatInfo.GVGDuelCombatStatu.Next;

		public uint AddScore = 0U;

		public enum GVGDuelCombatStatu
		{

			Used,

			Current,

			Next
		}
	}
}
