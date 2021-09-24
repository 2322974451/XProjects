using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_OutLookChangeNtf
	{

		public static void Process(PtcG2C_OutLookChangeNtf roPtc)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.roleid);
			bool flag = entity == null;
			if (!flag)
			{
				XOutlookHelper.SetOutLookReplace(entity.Attributes, entity, roPtc.Data.outlook);
			}
		}
	}
}
