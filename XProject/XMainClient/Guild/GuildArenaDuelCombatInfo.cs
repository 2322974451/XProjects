using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildArenaDuelCombatInfo
	{

		public string GetPortraitName()
		{
			return XGuildDocument.GetPortraitName((int)this.GuildIcon);
		}

		public bool Pass()
		{
			return this.GuildID > 0UL;
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

		public string ToTimeString()
		{
			return XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)this.CombatTime, XStringDefineProxy.GetString("TIME_FORMAT_YYMMDD"), true);
		}

		public ulong GuildID;

		public bool IsDo;

		public uint GuildScore;

		public string GuildName;

		public uint GuildIcon;

		public uint CombatTime;

		public bool Winner;

		public bool isShow = false;

		public IntegralState Step = IntegralState.integralready;

		public GVGDuelStatu gs = GVGDuelStatu.IDLE;

		public GuildArenaDuelCombatStatu Statu = GuildArenaDuelCombatStatu.Next;

		public uint AddScore = 0U;
	}
}
