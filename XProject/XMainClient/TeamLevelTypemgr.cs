using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TeamLevelTypemgr
	{

		public static int GetTypeInt(TeamLevelType _type)
		{
			return XFastEnumIntEqualityComparer<TeamLevelType>.ToInt(_type);
		}
	}
}
