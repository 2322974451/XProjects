using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009FD RID: 2557
	internal class TeamLevelTypemgr
	{
		// Token: 0x06009C97 RID: 40087 RVA: 0x00195840 File Offset: 0x00193A40
		public static int GetTypeInt(TeamLevelType _type)
		{
			return XFastEnumIntEqualityComparer<TeamLevelType>.ToInt(_type);
		}
	}
}
