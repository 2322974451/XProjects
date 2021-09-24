using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	public class XGuildDragonGuildRoleRankInfo : XBaseRankInfo
	{

		public override void ProcessData(RankData data)
		{
			this.name = data.RoleName;
			this.formatname = XTitleDocument.GetTitleWithFormat(data.titleID, data.RoleName);
			this.id = data.RoleId;
			this.rank = data.Rank;
			this.value = (ulong)data.damage;
			this.time = data.time;
			bool flag = this.time == uint.MaxValue;
			if (flag)
			{
				this._value = XStringDefineProxy.GetString("RANK_DAMAGE", new object[]
				{
					XSingleton<UiUtility>.singleton.NumberFormat(this.value)
				});
			}
			else
			{
				this._value = XStringDefineProxy.GetString("RANK_KILL", new object[]
				{
					XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this.time, 5)
				});
			}
		}

		public override string GetValue()
		{
			return this._value;
		}

		public uint time;

		private string _value;
	}
}
