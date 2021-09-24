using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_AttributeChangeNotify
	{

		public static void Process(PtcG2C_AttributeChangeNotify roPtc)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.uID);
			bool flag = entity != null;
			if (flag)
			{
				entity.Net.OnAttributeChangedNotify(roPtc.Data);
			}
		}
	}
}
