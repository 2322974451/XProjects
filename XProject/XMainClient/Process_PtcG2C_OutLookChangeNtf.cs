using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B5C RID: 2908
	internal class Process_PtcG2C_OutLookChangeNtf
	{
		// Token: 0x0600A8FD RID: 43261 RVA: 0x001E1500 File Offset: 0x001DF700
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
