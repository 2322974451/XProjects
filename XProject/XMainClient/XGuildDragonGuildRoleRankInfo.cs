using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D72 RID: 3442
	public class XGuildDragonGuildRoleRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC97 RID: 48279 RVA: 0x0026DFE8 File Offset: 0x0026C1E8
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

		// Token: 0x0600BC98 RID: 48280 RVA: 0x0026E0AC File Offset: 0x0026C2AC
		public override string GetValue()
		{
			return this._value;
		}

		// Token: 0x04004C80 RID: 19584
		public uint time;

		// Token: 0x04004C81 RID: 19585
		private string _value;
	}
}
