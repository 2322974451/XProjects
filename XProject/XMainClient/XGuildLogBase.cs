using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D28 RID: 3368
	internal class XGuildLogBase : XDataBase, ILogData, IComparable<ILogData>
	{
		// Token: 0x0600BB2C RID: 47916 RVA: 0x00266FCC File Offset: 0x002651CC
		public virtual string GetContent()
		{
			return "";
		}

		// Token: 0x0600BB2D RID: 47917 RVA: 0x00266FE4 File Offset: 0x002651E4
		public string GetTime()
		{
			return XSingleton<UiUtility>.singleton.TimeAgoFormatString(this.time);
		}

		// Token: 0x0600BB2E RID: 47918 RVA: 0x00267006 File Offset: 0x00265206
		public virtual void SetData(GHisRecord data)
		{
			this.uid = data.roleid;
			this.name = data.rolename;
			this.time = (int)data.time;
		}

		// Token: 0x0600BB2F RID: 47919 RVA: 0x00267030 File Offset: 0x00265230
		public static XGuildLogBase CreateLog(uint type)
		{
			XGuildLogBase result;
			switch (type)
			{
			case 1U:
				result = XDataPool<XGuildLogJoin>.GetData();
				break;
			case 2U:
				result = XDataPool<XGuildLogLeave>.GetData();
				break;
			case 3U:
				result = XDataPool<XGuildLogAppoint>.GetData();
				break;
			default:
				if (type != 9U)
				{
					result = null;
				}
				else
				{
					result = XDataPool<XGuildLogBossMVP>.GetData();
				}
				break;
			}
			return result;
		}

		// Token: 0x0600BB30 RID: 47920 RVA: 0x00267084 File Offset: 0x00265284
		public int CompareTo(ILogData otherLog)
		{
			XGuildLogBase xguildLogBase = otherLog as XGuildLogBase;
			bool flag = xguildLogBase.time == this.time;
			int result;
			if (flag)
			{
				result = this.uid.CompareTo(xguildLogBase.uid);
			}
			else
			{
				result = this.time.CompareTo(xguildLogBase.time);
			}
			return result;
		}

		// Token: 0x04004BB1 RID: 19377
		public GuildLogType eType;

		// Token: 0x04004BB2 RID: 19378
		public ulong uid;

		// Token: 0x04004BB3 RID: 19379
		public string name;

		// Token: 0x04004BB4 RID: 19380
		public int time;
	}
}
