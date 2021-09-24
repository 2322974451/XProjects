using System;

namespace XMainClient
{

	internal class Process_PtcM2C_SendGuildSkillInfo
	{

		public static void Process(PtcM2C_SendGuildSkillInfo roPtc)
		{
			XGuildSkillDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSkillDocument>(XGuildSkillDocument.uuID);
			specificDocument.OnUpdateGuildSkillData(roPtc.Data);
		}
	}
}
