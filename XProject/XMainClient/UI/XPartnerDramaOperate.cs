using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XPartnerDramaOperate : XDramaOperate
	{

		public override void ShowNpc(XNpc npc)
		{
			base.ShowNpc(npc);
			XDramaOperateParam data = XDataPool<XDramaOperateParam>.GetData();
			data.Text = base._GetRandomNpcText(npc);
			data.Npc = npc;
			data.AppendButton(XSingleton<XStringTable>.singleton.GetString("PartnerNpcOk"), new ButtonClickEventHandler(this._OnOKClicked), 0UL);
			data.AppendButton(XSingleton<XStringTable>.singleton.GetString("PartnerNpcCancel"), null, 0UL);
			base._FireEvent(data);
		}

		private bool _OnOKClicked(IXUIButton btn)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			XPartnerDocument doc = XPartnerDocument.Doc;
			bool flag = doc.PartnerID > 0UL;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("HadGetedPartner"), "fece00");
				result = true;
			}
			else
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				bool flag2 = specificDocument.currentDungeonType != TeamLevelType.TeamLevelPartner;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("NeedPartnerTeam"), "fece00");
					result = true;
				}
				else
				{
					bool flag3 = !specificDocument.bInTeam;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("TEAM_NOT_HAVE_TEAM"), "fece00");
						result = true;
					}
					else
					{
						bool flag4 = specificDocument.MyTeam.members.Count != XSingleton<XGlobalConfig>.singleton.GetInt("PartnerNum");
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PartnerTeamNumNotEnough"), "fece00");
							result = true;
						}
						else
						{
							bool flag5 = !specificDocument.bIsLeader;
							if (flag5)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("NotPartnerTeamLeader"), "fece00");
								result = true;
							}
							else
							{
								specificDocument.ReqTeamOp(TeamOperate.TEAM_START_BATTLE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
								result = true;
							}
						}
					}
				}
			}
			return result;
		}
	}
}
