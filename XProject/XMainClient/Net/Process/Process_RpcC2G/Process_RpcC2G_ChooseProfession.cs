using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_ChooseProfession
	{

		public static void OnReply(ChooseProfArg oArg, ChooseProfRes oRes)
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
					XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession = oArg.prof;
					int num = XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession);
					XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
					bool flag3 = entity != null && entity.Attributes != null;
					if (flag3)
					{
						entity.Attributes.Outlook.SetProfType((uint)num);
						entity.Attributes.Outlook.CalculateOutLookFashion();
						XEquipChangeEventArgs @event = XEventPool<XEquipChangeEventArgs>.GetEvent();
						@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
					}
					bool flag4 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
					if (flag4)
					{
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetAvatar(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(num));
					}
					XSkillTreeDocument specificDocument = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
					specificDocument.CreateAndPlayFxFxFirework();
					specificDocument.SkillRefresh(true, true);
					XSingleton<XTutorialHelper>.singleton.SwitchProf = true;
				}
			}
		}

		public static void OnTimeout(ChooseProfArg oArg)
		{
		}
	}
}
