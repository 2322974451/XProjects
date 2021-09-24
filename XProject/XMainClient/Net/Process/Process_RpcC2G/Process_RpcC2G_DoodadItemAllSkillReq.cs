using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_DoodadItemAllSkillReq
	{

		public static void OnReply(EmptyData oArg, DoodadItemAllSkill oRes)
		{
			bool flag = XRaceDocument.Doc.RaceHandler != null;
			if (flag)
			{
				XRaceDocument.Doc.RaceHandler.RefreshDoodad(oRes);
			}
		}

		public static void OnTimeout(EmptyData oArg)
		{
		}
	}
}
