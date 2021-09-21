using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D70 RID: 3440
	public class XGuildDragonGuildRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC92 RID: 48274 RVA: 0x0026DEE0 File Offset: 0x0026C0E0
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

		// Token: 0x0600BC93 RID: 48275 RVA: 0x0026DFA4 File Offset: 0x0026C1A4
		public override string GetValue()
		{
			return this._value;
		}

		// Token: 0x04004C7E RID: 19582
		public uint time;

		// Token: 0x04004C7F RID: 19583
		private string _value;
	}
}
