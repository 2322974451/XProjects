using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildRedPacketLog : ILogData, IComparable<ILogData>
	{

		public void SetData(GetGuildBonusInfo data)
		{
			this.uid = data.roleID;
			this.name = data.roleName;
			this.itemcount = (int)data.getNum;
			this.time = (int)data.getTime;
		}

		public string GetContent()
		{
			return XStringDefineProxy.GetString("GUILD_REDPACKET_LOG", new object[]
			{
				XLabelSymbolHelper.FormatName(this.name, this.uid, "00ffff"),
				XLabelSymbolHelper.FormatCostWithIcon(this.itemcount, (ItemEnum)this.itemid)
			});
		}

		public string GetTime()
		{
			return XSingleton<UiUtility>.singleton.TimeAgoFormatString(this.time);
		}

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

		public ulong uid;

		public string name;

		public int itemid;

		public int itemcount;

		public int time;
	}
}
