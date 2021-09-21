using System;
using KKSG;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000A7F RID: 2687
	internal class XGuildRedPacketBrief : IComparable<XGuildRedPacketBrief>
	{
		// Token: 0x0600A383 RID: 41859 RVA: 0x001BFE34 File Offset: 0x001BE034
		public void SetData(GuildBonusAppear data)
		{
			this.uid = (ulong)data.bonusID;
			this.itemid = (int)data.bonusType;
			this.senderName = data.sourceName;
			this.fetchedCount = data.alreadyGetPeopleNum;
			this.maxCount = data.maxPeopleNum;
			this.iconUrl = data.iconUrl;
			this.sourceID = data.sourceID;
			this.sourceName = data.sourceName;
			bool flag = data.bonusStatus == 0U;
			if (flag)
			{
				this.fetchState = FetchState.FS_CAN_FETCH;
			}
			else
			{
				bool flag2 = data.bonusStatus == 1U;
				if (flag2)
				{
					this.fetchState = FetchState.FS_CANNOT_FETCH;
				}
				else
				{
					bool flag3 = data.bonusStatus == 2U;
					if (flag3)
					{
						this.fetchState = FetchState.FS_ALREADY_FETCH;
					}
					else
					{
						this.fetchState = FetchState.FS_FETCHED;
					}
				}
			}
			this.endTime = Time.time + data.leftOpenTime;
		}

		// Token: 0x0600A384 RID: 41860 RVA: 0x001BFF00 File Offset: 0x001BE100
		public int CompareTo(XGuildRedPacketBrief other)
		{
			bool flag = this.fetchState == other.fetchState;
			int result;
			if (flag)
			{
				result = this.endTime.CompareTo(other.endTime);
			}
			else
			{
				result = this.fetchState.CompareTo(other.fetchState);
			}
			return result;
		}

		// Token: 0x04003B1C RID: 15132
		public uint typeid;

		// Token: 0x04003B1D RID: 15133
		public ulong uid;

		// Token: 0x04003B1E RID: 15134
		public int itemid;

		// Token: 0x04003B1F RID: 15135
		public string senderName;

		// Token: 0x04003B20 RID: 15136
		public uint fetchedCount;

		// Token: 0x04003B21 RID: 15137
		public uint maxCount;

		// Token: 0x04003B22 RID: 15138
		public float endTime;

		// Token: 0x04003B23 RID: 15139
		public string iconUrl;

		// Token: 0x04003B24 RID: 15140
		public ulong sourceID;

		// Token: 0x04003B25 RID: 15141
		public string sourceName;

		// Token: 0x04003B26 RID: 15142
		public FetchState fetchState;
	}
}
