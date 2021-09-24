using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_DeathNotify
	{

		public static void Process(PtcG2C_DeathNotify roPtc)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.uID);
			bool flag = entity != null;
			if (flag)
			{
				bool isPlayer = entity.IsPlayer;
				if (isPlayer)
				{
					XReviveDocument specificDocument = XDocuments.GetSpecificDocument<XReviveDocument>(XReviveDocument.uuID);
					specificDocument.SetReviveData((int)roPtc.Data.revivecount, (int)roPtc.Data.costrevivecount, roPtc.Data.type);
				}
				bool flag2 = entity.Machine != null && !entity.Machine.Enabled;
				if (flag2)
				{
					entity.Machine.Enabled = true;
				}
				entity.Net.OnDeathNotify(roPtc.Data);
			}
		}
	}
}
