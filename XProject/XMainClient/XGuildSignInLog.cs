using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D2D RID: 3373
	internal class XGuildSignInLog : ILogData, IComparable<ILogData>
	{
		// Token: 0x0600BB3F RID: 47935 RVA: 0x0026726C File Offset: 0x0026546C
		public string GetContent()
		{
			return XStringDefineProxy.GetString("GUILD_SIGNIN_CONTENT", new object[]
			{
				XLabelSymbolHelper.FormatName(this.name, this.uid, "00ffff"),
				XStringDefineProxy.GetString("GUILD_SIGNIN_TYPE" + this.type.ToString())
			});
		}

		// Token: 0x0600BB40 RID: 47936 RVA: 0x002672C4 File Offset: 0x002654C4
		public string GetTime()
		{
			return XSingleton<UiUtility>.singleton.TimeAgoFormatString(this.time);
		}

		// Token: 0x0600BB41 RID: 47937 RVA: 0x002672E8 File Offset: 0x002654E8
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

		// Token: 0x04004BB6 RID: 19382
		public ulong uid;

		// Token: 0x04004BB7 RID: 19383
		public string name;

		// Token: 0x04004BB8 RID: 19384
		public uint type;

		// Token: 0x04004BB9 RID: 19385
		public int time;
	}
}
