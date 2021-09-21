using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200101E RID: 4126
	internal class Process_RpcC2G_ResetSkill
	{
		// Token: 0x0600D51F RID: 54559 RVA: 0x00323018 File Offset: 0x00321218
		public static void OnReply(ResetSkillArg oArg, ResetSkillRes oRes)
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
					bool flag3 = oArg.resetType == ResetType.RESET_PROFESSION;
					if (flag3)
					{
						XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession = oRes.prof;
						XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
						bool flag4 = entity != null && entity.Attributes != null;
						if (flag4)
						{
							entity.Attributes.Outlook.SetProfType(XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID);
							entity.Attributes.Outlook.CalculateOutLookFashion();
							XEquipChangeEventArgs @event = XEventPool<XEquipChangeEventArgs>.GetEvent();
							@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
							XSingleton<XEventMgr>.singleton.FireEvent(@event);
						}
					}
					bool flag5 = DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.LastSelectPromote > 1;
					if (flag5)
					{
						DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.LastSelectPromote = 1;
					}
					XSkillTreeDocument specificDocument = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
					specificDocument.SkillRefresh(true, true);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
			}
		}

		// Token: 0x0600D520 RID: 54560 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ResetSkillArg oArg)
		{
		}
	}
}
