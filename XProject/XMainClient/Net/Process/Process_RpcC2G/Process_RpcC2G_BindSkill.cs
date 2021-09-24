using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_BindSkill
	{

		public static void OnReply(BingSkillArg oArg, BindSkillRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSkillTreeDocument specificDocument = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
					bool flag3 = oArg.slot < oRes.skillslot.Count;
					if (flag3)
					{
						specificDocument.ShowEmblemTips((ulong)oRes.skillslot[oArg.slot], oArg.slot);
					}
					for (int i = 0; i < XSingleton<XAttributeMgr>.singleton.XPlayerData.skillSlot.Length; i++)
					{
						bool flag4 = i < oRes.skillslot.Count;
						if (flag4)
						{
							XSingleton<XAttributeMgr>.singleton.XPlayerData.skillSlot[i] = oRes.skillslot[i];
						}
					}
					XEmblemDocument specificDocument2 = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
					specificDocument2.UpdateRedPoints();
					specificDocument.SkillRefresh(false, true);
					XSingleton<XTutorialHelper>.singleton.SkillBind = true;
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
			}
		}

		public static void OnTimeout(BingSkillArg oArg)
		{
		}
	}
}
