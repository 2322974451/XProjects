using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A7C RID: 2684
	internal class XGuildCheckInBonusInfo
	{
		// Token: 0x0600A376 RID: 41846 RVA: 0x001BF9BC File Offset: 0x001BDBBC
		public XGuildCheckInBonusInfo()
		{
			DateTime now = DateTime.Now;
			this.timeofday = (double)(3600 * now.Hour + 60 * now.Minute + now.Second);
		}

		// Token: 0x0600A377 RID: 41847 RVA: 0x001BFA0C File Offset: 0x001BDC0C
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

		// Token: 0x0600A378 RID: 41848 RVA: 0x001BFAF0 File Offset: 0x001BDCF0
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

		// Token: 0x17002F9D RID: 12189
		// (get) Token: 0x0600A379 RID: 41849 RVA: 0x001BFB6C File Offset: 0x001BDD6C
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

		// Token: 0x0600A37A RID: 41850 RVA: 0x001BFBC8 File Offset: 0x001BDDC8
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

		// Token: 0x0600A37B RID: 41851 RVA: 0x001BFC2C File Offset: 0x001BDE2C
		public bool HasActive()
		{
			return this.ActiveCount > 0;
		}

		// Token: 0x0600A37C RID: 41852 RVA: 0x001BFC48 File Offset: 0x001BDE48
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

		// Token: 0x04003B06 RID: 15110
		public bool isCheckIn;

		// Token: 0x04003B07 RID: 15111
		public int checkInNumber;

		// Token: 0x04003B08 RID: 15112
		public int onLineNum;

		// Token: 0x04003B09 RID: 15113
		public int guildMemberNum;

		// Token: 0x04003B0A RID: 15114
		public double timeofday;

		// Token: 0x04003B0B RID: 15115
		public double leftAskBonusTime;

		// Token: 0x04003B0C RID: 15116
		public XGuildCheckInBonusBrief[] BonusBriefs = new XGuildCheckInBonusBrief[4];
	}
}
