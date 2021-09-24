using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ExpBackTypeMgr
	{

		public static int GetTypeInt(ExpBackType _type)
		{
			return XFastEnumIntEqualityComparer<ExpBackType>.ToInt(_type);
		}
	}
}
