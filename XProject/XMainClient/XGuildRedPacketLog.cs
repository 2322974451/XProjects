using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D2E RID: 3374
	internal class XGuildRedPacketLog : ILogData, IComparable<ILogData>
	{
		// Token: 0x0600BB43 RID: 47939 RVA: 0x00267338 File Offset: 0x00265538
		public void SetData(GetGuildBonusInfo data)
		{
			this.uid = data.roleID;
			this.name = data.roleName;
			this.itemcount = (int)data.getNum;
			this.time = (int)data.getTime;
		}

		// Token: 0x0600BB44 RID: 47940 RVA: 0x0026736C File Offset: 0x0026556C
		public string GetContent()
		{
			return XStringDefineProxy.GetString("GUILD_REDPACKET_LOG", new object[]
			{
				XLabelSymbolHelper.FormatName(this.name, this.uid, "00ffff"),
				XLabelSymbolHelper.FormatCostWithIcon(this.itemcount, (ItemEnum)this.itemid)
			});
		}

		// Token: 0x0600BB45 RID: 47941 RVA: 0x002673BC File Offset: 0x002655BC
		public string GetTime()
		{
			return XSingleton<UiUtility>.singleton.TimeAgoFormatString(this.time);
		}

		// Token: 0x0600BB46 RID: 47942 RVA: 0x002673E0 File Offset: 0x002655E0
		public int CompareTo(ILogData otherLog)
		{
			XGuildRedPacketLog xguildRedPacketLog = otherLog as XGuildRedPacketLog;
			bool flag = xguildRedPacketLog.time == this.time;
			int result;
			if (flag)
			{
				result = this.uid.CompareTo(xguildRedPacketLog.uid);
			}
			else
			{
				result = this.time.CompareTo(xguildRedPacketLog.time);
			}
			return result;
		}

		// Token: 0x04004BBA RID: 19386
		public ulong uid;

		// Token: 0x04004BBB RID: 19387
		public string name;

		// Token: 0x04004BBC RID: 19388
		public int itemid;

		// Token: 0x04004BBD RID: 19389
		public int itemcount;

		// Token: 0x04004BBE RID: 19390
		public int time;
	}
}
