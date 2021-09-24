using System;
using KKSG;

namespace XMainClient
{

	internal struct XUnitAppearanceTeam
	{

		public bool bHasTeam
		{
			get
			{
				return this.teamID > 0U;
			}
		}

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

		public uint teamID;

		public bool bPwd;
	}
}
