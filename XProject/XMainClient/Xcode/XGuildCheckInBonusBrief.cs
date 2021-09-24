using System;
using KKSG;

namespace XMainClient
{

	internal class XGuildCheckInBonusBrief
	{

		public uint needMemberCount
		{
			get
			{
				return this.bonueMemberCount - this.frontBonusMemberCount;
			}
		}

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

		public uint bonusID = 0U;

		public uint bonueMemberCount = 0U;

		public BonusState bonusState = BonusState.Bonus_UnActive;

		public XGuildRedPacketBrief brief = new XGuildRedPacketBrief();

		public uint frontBonusMemberCount = 0U;

		public uint bonusType = 0U;
	}
}
