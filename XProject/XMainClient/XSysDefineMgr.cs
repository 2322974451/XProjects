using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSysDefineMgr
	{

		public static int GetTypeInt(XSysDefine eType)
		{
			return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(eType);
		}
	}
}
