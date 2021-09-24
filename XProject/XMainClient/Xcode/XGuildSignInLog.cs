using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildSignInLog : ILogData, IComparable<ILogData>
	{

		public string GetContent()
		{
			return XStringDefineProxy.GetString("GUILD_SIGNIN_CONTENT", new object[]
			{
				XLabelSymbolHelper.FormatName(this.name, this.uid, "00ffff"),
				XStringDefineProxy.GetString("GUILD_SIGNIN_TYPE" + this.type.ToString())
			});
		}

		public string GetTime()
		{
			return XSingleton<UiUtility>.singleton.TimeAgoFormatString(this.time);
		}

		public int CompareTo(ILogData otherLog)
		{
			XGuildSignInLog xguildSignInLog = otherLog as XGuildSignInLog;
			bool flag = xguildSignInLog.time == this.time;
			int result;
			if (flag)
			{
				result = this.uid.CompareTo(xguildSignInLog.uid);
			}
			else
			{
				result = this.time.CompareTo(xguildSignInLog.time);
			}
			return result;
		}

		public ulong uid;

		public string name;

		public uint type;

		public int time;
	}
}
