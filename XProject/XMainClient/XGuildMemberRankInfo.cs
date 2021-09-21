using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D77 RID: 3447
	public class XGuildMemberRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BCA2 RID: 48290 RVA: 0x0026E247 File Offset: 0x0026C447
		public void ProcessData(RoleGuildContribute info)
		{
			this.id = info.roleId;
			this.value = (ulong)info.contribute;
			this.name = info.RoleName;
			this.formatname = XTitleDocument.GetTitleWithFormat(0U, info.RoleName);
		}
	}
}
