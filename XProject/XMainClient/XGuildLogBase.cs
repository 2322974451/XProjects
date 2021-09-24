using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildLogBase : XDataBase, ILogData, IComparable<ILogData>
	{

		public virtual string GetContent()
		{
			return "";
		}

		public string GetTime()
		{
			return XSingleton<UiUtility>.singleton.TimeAgoFormatString(this.time);
		}

		public virtual void SetData(GHisRecord data)
		{
			this.uid = data.roleid;
			this.name = data.rolename;
			this.time = (int)data.time;
		}

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

		public GuildLogType eType;

		public ulong uid;

		public string name;

		public int time;
	}
}
