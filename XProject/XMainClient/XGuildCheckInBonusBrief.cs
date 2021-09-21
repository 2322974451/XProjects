using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000A7D RID: 2685
	internal class XGuildCheckInBonusBrief
	{
		// Token: 0x17002F9E RID: 12190
		// (get) Token: 0x0600A37D RID: 41853 RVA: 0x001BFCA0 File Offset: 0x001BDEA0
		public uint needMemberCount
		{
			get
			{
				return this.bonueMemberCount - this.frontBonusMemberCount;
			}
		}

		// Token: 0x0600A37E RID: 41854 RVA: 0x001BFCC0 File Offset: 0x001BDEC0
		public void SetBrief(GuildBonusAppear appear)
		{
			bool flag = appear == null;
			if (!flag)
			{
				this.brief.SetData(appear);
				this.bonusID = appear.bonusID;
				this.bonusType = appear.bonusContentType;
				this.bonueMemberCount = appear.needCheckInNum;
			}
		}

		// Token: 0x04003B0D RID: 15117
		public uint bonusID = 0U;

		// Token: 0x04003B0E RID: 15118
		public uint bonueMemberCount = 0U;

		// Token: 0x04003B0F RID: 15119
		public BonusState bonusState = BonusState.Bonus_UnActive;

		// Token: 0x04003B10 RID: 15120
		public XGuildRedPacketBrief brief = new XGuildRedPacketBrief();

		// Token: 0x04003B11 RID: 15121
		public uint frontBonusMemberCount = 0U;

		// Token: 0x04003B12 RID: 15122
		public uint bonusType = 0U;
	}
}
