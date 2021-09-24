using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{

	public class HallFameRoleInfo
	{

		public uint Rank = 0U;

		public string IconName;

		public string TeamName;

		public string RoleName;

		public RoleOutLookBrief OutLook;

		public ArenaStarHistData hisData;

		public List<int> LastData = new List<int>();
	}
}
