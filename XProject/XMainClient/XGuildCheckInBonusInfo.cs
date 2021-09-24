using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildCheckInBonusInfo
	{

		public XGuildCheckInBonusInfo()
		{
			DateTime now = DateTime.Now;
			this.timeofday = (double)(3600 * now.Hour + 60 * now.Minute + now.Second);
		}

		public void SetBonusBrief(List<GuildBonusAppear> appears)
		{
			int i = 0;
			int num = 4;
			while (i < num)
			{
				XGuildCheckInBonusBrief xguildCheckInBonusBrief = new XGuildCheckInBonusBrief();
				bool flag = i < appears.Count;
				if (flag)
				{
					GuildBonusAppear guildBonusAppear = appears[i];
					xguildCheckInBonusBrief.SetBrief(guildBonusAppear);
					bool flag2 = i > 0;
					if (flag2)
					{
						xguildCheckInBonusBrief.frontBonusMemberCount = appears[i - 1].needCheckInNum;
					}
					else
					{
						xguildCheckInBonusBrief.frontBonusMemberCount = 0U;
					}
					bool flag3 = (long)this.checkInNumber >= (long)((ulong)xguildCheckInBonusBrief.bonueMemberCount);
					if (flag3)
					{
						bool flag4 = guildBonusAppear.bonusID > 0U;
						if (flag4)
						{
							bool flag5 = guildBonusAppear.bonusStatus > 0U;
							if (flag5)
							{
								xguildCheckInBonusBrief.bonusState = BonusState.Bouns_Over;
							}
							else
							{
								xguildCheckInBonusBrief.bonusState = BonusState.Bonus_Actived;
							}
						}
						else
						{
							xguildCheckInBonusBrief.bonusState = BonusState.Bonus_Active;
						}
					}
					else
					{
						xguildCheckInBonusBrief.bonusState = BonusState.Bonus_UnActive;
					}
				}
				this.BonusBriefs[i] = xguildCheckInBonusBrief;
				i++;
			}
		}

		public int GetAddPercent(int onlineNum)
		{
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("GuildBonusOnLineNumAddPercent");
			string[] array = value.Split(XGlobalConfig.ListSeparator);
			int result = 0;
			int i = 0;
			int num = array.Length;
			while (i < num)
			{
				string[] array2 = array[i].Split(XGlobalConfig.SequenceSeparator);
				bool flag = int.Parse(array2[0]) > onlineNum;
				if (flag)
				{
					break;
				}
				result = int.Parse(array2[1]);
				i++;
			}
			return result;
		}

		public int ActiveCount
		{
			get
			{
				int num = 0;
				int i = 0;
				int num2 = this.BonusBriefs.Length;
				while (i < num2)
				{
					bool flag = this.BonusBriefs[i] != null && this.BonusBriefs[i].bonusState == BonusState.Bonus_Active;
					if (flag)
					{
						num++;
					}
					i++;
				}
				return num;
			}
		}

		public bool TryGetFreeBrief(out XGuildCheckInBonusBrief brief)
		{
			brief = null;
			int i = 0;
			int num = this.BonusBriefs.Length;
			while (i < num)
			{
				bool flag = this.BonusBriefs[i] != null && this.BonusBriefs[i].bonusState == BonusState.Bonus_Active;
				if (flag)
				{
					brief = this.BonusBriefs[i];
					return true;
				}
				i++;
			}
			return false;
		}

		public bool HasActive()
		{
			return this.ActiveCount > 0;
		}

		public bool AllActived()
		{
			int i = 0;
			int num = this.BonusBriefs.Length;
			while (i < num)
			{
				bool flag = this.BonusBriefs[i] == null || this.BonusBriefs[i].bonusState == BonusState.Bonus_Actived;
				if (flag)
				{
					return false;
				}
				i++;
			}
			return true;
		}

		public bool isCheckIn;

		public int checkInNumber;

		public int onLineNum;

		public int guildMemberNum;

		public double timeofday;

		public double leftAskBonusTime;

		public XGuildCheckInBonusBrief[] BonusBriefs = new XGuildCheckInBonusBrief[4];
	}
}
