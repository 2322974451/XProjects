using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200100D RID: 4109
	internal class Process_RpcC2G_SkillLevelup
	{
		// Token: 0x0600D4DC RID: 54492 RVA: 0x0032237C File Offset: 0x0032057C
		public static void OnReply(SkillLevelupArg oArg, SkillLevelupRes oRes)
		{
			bool flag = oRes.errorcode == 257U;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = (ulong)oRes.errorcode == (ulong)((long)XFastEnumIntEqualityComparer<ErrorCode>.ToInt(ErrorCode.ERR_SUCCESS));
				if (flag2)
				{
					XSkillTreeDocument specificDocument = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
					specificDocument.OnSkillLevelUp(oArg.skillHash);
					uint skillLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillLevel(oArg.skillHash);
					bool flag3 = skillLevel == 1U;
					if (flag3)
					{
						bool flag4 = specificDocument.IsPassiveSkill(oArg.skillHash);
						bool flag5 = flag4;
						if (flag5)
						{
							List<SkillEmblem.RowData> skillRow = new List<SkillEmblem.RowData>();
							XEmblemDocument specificDocument2 = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
							bool flag6 = specificDocument2.IsEquipThisSkillEmblem(oArg.skillHash, ref skillRow);
							bool flag7 = flag6;
							if (flag7)
							{
								specificDocument.ShowTips(skillRow, true);
							}
						}
					}
				}
				else
				{
					SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(oArg.skillHash, 0U);
					bool flag8 = (ulong)oRes.errorcode == (ulong)((long)XFastEnumIntEqualityComparer<ErrorCode>.ToInt(ErrorCode.ERR_SKILL_POINT)) && skillConfig != null && skillConfig.IsAwake;
					if (flag8)
					{
						XSingleton<UiUtility>.singleton.ShowItemAccess(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.AWAKE_SKILL_POINT), null);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip((ErrorCode)oRes.errorcode, "fece00");
					}
				}
			}
		}

		// Token: 0x0600D4DD RID: 54493 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SkillLevelupArg oArg)
		{
		}
	}
}
