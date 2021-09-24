using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SystemRewardTypeMrg
	{

		public static uint GetTypeUInt(SystemRewardType _type)
		{
			return (uint)XFastEnumIntEqualityComparer<SystemRewardType>.ToInt(_type);
		}
	}
}
