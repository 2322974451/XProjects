using System;
using KKSG;

namespace XMainClient
{

	public class XGuildMemberRankInfo : XBaseRankInfo
	{

		public void ProcessData(RoleGuildContribute info)
		{
			this.id = info.roleId;
			this.value = (ulong)info.contribute;
			this.name = info.RoleName;
			this.formatname = XTitleDocument.GetTitleWithFormat(0U, info.RoleName);
		}
	}
}
