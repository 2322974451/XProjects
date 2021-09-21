using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D35 RID: 3381
	internal struct XUnitAppearanceTeam
	{
		// Token: 0x170032F4 RID: 13044
		// (get) Token: 0x0600BB70 RID: 47984 RVA: 0x0026854C File Offset: 0x0026674C
		public bool bHasTeam
		{
			get
			{
				return this.teamID > 0U;
			}
		}

		// Token: 0x0600BB71 RID: 47985 RVA: 0x00268568 File Offset: 0x00266768
		public void SetData(UnitAppearanceTeam data)
		{
			bool flag = data == null;
			if (flag)
			{
				this.teamID = 0U;
				this.bPwd = false;
			}
			else
			{
				this.teamID = data.teamid;
				this.bPwd = data.haspassword;
			}
		}

		// Token: 0x04004BFA RID: 19450
		public uint teamID;

		// Token: 0x04004BFB RID: 19451
		public bool bPwd;
	}
}
