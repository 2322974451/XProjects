using System;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B5D RID: 2909
	internal class Process_PtcM2C_HintNotifyMS
	{
		// Token: 0x0600A8FF RID: 43263 RVA: 0x001E1548 File Offset: 0x001DF748
		public static void Process(PtcM2C_HintNotifyMS roPtc)
		{
			int i = 0;
			while (i < roPtc.Data.systemid.Count)
			{
				XSysDefine xsysDefine = (XSysDefine)roPtc.Data.systemid[i];
				XSysDefine xsysDefine2 = xsysDefine;
				if (xsysDefine2 <= XSysDefine.XSys_Flower_Rank_Activity)
				{
					if (xsysDefine2 <= XSysDefine.XSys_Mentorship)
					{
						if (xsysDefine2 != XSysDefine.XSys_Qualifying)
						{
							if (xsysDefine2 != XSysDefine.XSys_Mentorship)
							{
								goto IL_222;
							}
							XMentorshipDocument.Doc.HasRedPointOnTasks = true;
						}
						else
						{
							XQualifyingDocument specificDocument = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
							specificDocument.RedPoint = true;
						}
					}
					else if (xsysDefine2 != XSysDefine.XSys_GuildDragon)
					{
						if (xsysDefine2 != XSysDefine.XSys_Home)
						{
							if (xsysDefine2 != XSysDefine.XSys_Flower_Rank_Activity)
							{
								goto IL_222;
							}
							XFlowerRankDocument specificDocument2 = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
							specificDocument2.CanGetActivityAward = !roPtc.Data.isremove;
						}
						else
						{
							HomeMainDocument.Doc.HomeMainRedDot = roPtc.Data.isremove;
						}
					}
					else
					{
						XGuildDragonDocument specificDocument3 = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
						specificDocument3.bCanFight = !roPtc.Data.isremove;
					}
				}
				else if (xsysDefine2 <= XSysDefine.XSys_Wedding)
				{
					if (xsysDefine2 != XSysDefine.XSys_WeekNest)
					{
						if (xsysDefine2 != XSysDefine.XSys_Announcement)
						{
							if (xsysDefine2 != XSysDefine.XSys_Wedding)
							{
								goto IL_222;
							}
							XWeddingDocument.Doc.IsHadLivenessRedPoint = !roPtc.Data.isremove;
						}
						else
						{
							XAnnouncementDocument specificDocument4 = XDocuments.GetSpecificDocument<XAnnouncementDocument>(XAnnouncementDocument.uuID);
							specificDocument4.RedPoint = !roPtc.Data.isremove;
						}
					}
					else
					{
						XWeekNestDocument.Doc.HadRedDot = !roPtc.Data.isremove;
					}
				}
				else if (xsysDefine2 != XSysDefine.XSys_GuildHall_SignIn)
				{
					if (xsysDefine2 != XSysDefine.XSys_GuildRelax_JokerMatch)
					{
						if (xsysDefine2 != XSysDefine.XSys_JockerKing)
						{
							goto IL_222;
						}
						XJokerKingDocument specificDocument5 = XDocuments.GetSpecificDocument<XJokerKingDocument>(XJokerKingDocument.uuID);
						specificDocument5.bAvaiableIconWhenShow = !roPtc.Data.isremove;
					}
					else
					{
						XGuildJockerMatchDocument specificDocument6 = XDocuments.GetSpecificDocument<XGuildJockerMatchDocument>(XGuildJockerMatchDocument.uuID);
						specificDocument6.bAvaiableIconWhenShow = !roPtc.Data.isremove;
					}
				}
				else
				{
					XGuildSignInDocument specificDocument7 = XDocuments.GetSpecificDocument<XGuildSignInDocument>(XGuildSignInDocument.uuID);
					specificDocument7.SignInSelection = 0U;
				}
				IL_23E:
				bool flag = xsysDefine == XSysDefine.XSys_Mail;
				if (flag)
				{
					DlgBase<XChatView, XChatBehaviour>.singleton.ShowMailRedpoint();
				}
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(xsysDefine, true);
				i++;
				continue;
				IL_222:
				XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(xsysDefine, !roPtc.Data.isremove);
				goto IL_23E;
			}
		}
	}
}
