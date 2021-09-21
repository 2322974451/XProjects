using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200100B RID: 4107
	internal class Process_PtcG2C_AttributeChangeNotify
	{
		// Token: 0x0600D4D4 RID: 54484 RVA: 0x003222BC File Offset: 0x003204BC
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
