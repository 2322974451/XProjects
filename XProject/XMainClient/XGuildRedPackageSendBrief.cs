using System;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A7E RID: 2686
	internal class XGuildRedPackageSendBrief : IComparable<XGuildRedPackageSendBrief>
	{
		// Token: 0x0600A380 RID: 41856 RVA: 0x001BFD40 File Offset: 0x001BDF40
		public void SendData(GuildBonusAppear data)
		{
			this.typeID = data.bonusContentType;
			this.uid = (ulong)data.bonusID;
			this.itemid = data.bonusType;
			this.senderName = data.sourceName;
			this.fetchedCount = data.alreadyGetPeopleNum;
			this.maxCount = data.maxPeopleNum;
			this.endTime = Time.time + data.leftOpenTime;
			this.bonusInfo = XGuildRedPacketDocument.GetRedPacketConfig(this.typeID);
			this.senderType = ((XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID == data.sourceID) ? BonusSender.Bonus_Self : BonusSender.Bonus_Other);
		}

		// Token: 0x0600A381 RID: 41857 RVA: 0x001BFDE0 File Offset: 0x001BDFE0
		public int CompareTo(XGuildRedPackageSendBrief other)
		{
			bool flag = this.senderType == other.senderType;
			int result;
			if (flag)
			{
				result = this.endTime.CompareTo(other.endTime);
			}
			else
			{
				result = this.senderType.CompareTo(other.senderType);
			}
			return result;
		}

		// Token: 0x04003B13 RID: 15123
		public uint typeID;

		// Token: 0x04003B14 RID: 15124
		public ulong uid;

		// Token: 0x04003B15 RID: 15125
		public uint itemid;

		// Token: 0x04003B16 RID: 15126
		public string senderName;

		// Token: 0x04003B17 RID: 15127
		public uint fetchedCount;

		// Token: 0x04003B18 RID: 15128
		public uint maxCount;

		// Token: 0x04003B19 RID: 15129
		public float endTime;

		// Token: 0x04003B1A RID: 15130
		public BonusSender senderType;

		// Token: 0x04003B1B RID: 15131
		public GuildBonusTable.RowData bonusInfo;
	}
}
