using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XMentorshipPupilsDramaOperate : XDramaOperate
	{

		public override void ShowNpc(XNpc npc)
		{
			base.ShowNpc(npc);
			this.doc = XDocuments.GetSpecificDocument<XMentorshipDocument>(XMentorshipDocument.uuID);
			this._param = XDataPool<XDramaOperateParam>.GetData();
			this._param.Npc = npc;
			XMentorshipDocument.Doc.SendMentorshipInfoReq();
		}

		public void RefreshOperateStatus()
		{
			switch (this.doc.GetMyMentorShip())
			{
			case MyMentorship.None:
				this._param.Text = XStringDefineProxy.GetString("MentorshipNpcDialog_0_None");
				this._param.AppendButton(XStringDefineProxy.GetString("MentorshipNpcButton_FindMaster"), new ButtonClickEventHandler(this._FindMaster), 0UL);
				this._param.AppendButton(XStringDefineProxy.GetString("MentorshipNpcButton_FindPupil"), new ButtonClickEventHandler(this._FindPupil), 0UL);
				break;
			case MyMentorship.Mentorship_Pupil:
				this._param.Text = XStringDefineProxy.GetString("MentorshipNpcDialog_0_Pupil");
				this._param.AppendButton(XStringDefineProxy.GetString("MentorshipNpcButton_ProcessRelation"), new ButtonClickEventHandler(this._ProcessRelation), 0UL);
				this._param.AppendButton(XStringDefineProxy.GetString("MentorshipNpcButton_SelectForceComplete"), new ButtonClickEventHandler(this._SelectForceComplete), 0UL);
				break;
			case MyMentorship.Mentorship_Master:
				this._param.Text = XStringDefineProxy.GetString("MentorshipNpcDialog_0_Master");
				this._param.AppendButton(XStringDefineProxy.GetString("MentorshipNpcButton_ProcessRelation"), new ButtonClickEventHandler(this._ProcessRelation), 0UL);
				this._param.AppendButton(XStringDefineProxy.GetString("MentorshipNpcButton_SelectComplete"), new ButtonClickEventHandler(this._SelectComplete), 0UL);
				break;
			}
			base._FireEvent(this._param);
		}

		private bool _FindMaster(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Mentorship, 0UL);
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		private bool _FindPupil(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Mentorship, 0UL);
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		private int _GetBreakTargetTime(uint breakTime)
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("MentorBreakConfirmTime");
			return @int + (int)breakTime - this.doc.ReceiveingProtocolTime - (int)Time.time;
		}

		private bool _ProcessRelation(IXUIButton btn)
		{
			XDramaOperateParam data = XDataPool<XDramaOperateParam>.GetData();
			data.Text = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("MentorshipNpcDialog_ProcessRelation"));
			int num = int.MaxValue;
			int relationTargetsCount = this.doc.GetRelationTargetsCount();
			int num2 = 0;
			for (int i = 0; i < relationTargetsCount; i++)
			{
				MentorRelationInfo relationTargetInfo = this.doc.GetRelationTargetInfo(i);
				for (int j = 0; j < relationTargetInfo.statusTimeList.Count; j++)
				{
					MentorRelationTime mentorRelationTime = relationTargetInfo.statusTimeList[j];
					bool flag = mentorRelationTime.status == MentorRelationStatus.MentorRelationBreakApply;
					if (flag)
					{
						int num3 = this._GetBreakTargetTime(mentorRelationTime.time);
						bool flag2 = num3 > 0;
						if (flag2)
						{
							num = Math.Min(num3, num);
							bool flag3 = relationTargetInfo.breakApplyRoleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
							if (flag3)
							{
								num2++;
							}
						}
						break;
					}
				}
			}
			XDramaOperateButton xdramaOperateButton = data.AppendButton(XStringDefineProxy.GetString("MentorshipNpcButton_SelectBreak"), new ButtonClickEventHandler(this._SelectBreak), 0UL);
			xdramaOperateButton.StateEnable = (num2 < relationTargetsCount);
			XDramaOperateButton xdramaOperateButton2 = data.AppendButton(XStringDefineProxy.GetString("MentorshipNpcButton_SelectBreakCancel"), new ButtonClickEventHandler(this._SelectBreakCancel), 0UL);
			bool flag4 = num != int.MaxValue;
			if (flag4)
			{
				xdramaOperateButton2.TargetTime = (float)num + Time.realtimeSinceStartup;
				xdramaOperateButton2.TimeNote = XSingleton<XStringTable>.singleton.GetString("MentorshipBreaking");
			}
			xdramaOperateButton2.StateEnable = (num2 != 0);
			base._FireEvent(data);
			return true;
		}

		private bool _SelectComplete(IXUIButton btn)
		{
			XDramaOperateParam data = XDataPool<XDramaOperateParam>.GetData();
			data.Text = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("MentorshipNpcDialog_SelectComplete"));
			data.AppendButton(XStringDefineProxy.GetString("MentorshipNpcButton_SelectNormalComplete"), new ButtonClickEventHandler(this._SelectNormalComplete), 0UL);
			data.AppendButton(XStringDefineProxy.GetString("MentorshipNpcButton_SelectForceComplete"), new ButtonClickEventHandler(this._SelectForceComplete), 0UL);
			base._FireEvent(data);
			return true;
		}

		private void _CreateSelection(string noneText, string pupilText, string masterText, SpriteClickEventHandler handler, MentorRelationStatus status = MentorRelationStatus.MentorRelationMax)
		{
			MyMentorship myMentorShip = this.doc.GetMyMentorShip();
			XDramaOperateParam data = XDataPool<XDramaOperateParam>.GetData();
			int relationTargetsCount = this.doc.GetRelationTargetsCount();
			bool flag = relationTargetsCount == 0 || myMentorShip == MyMentorship.None;
			if (flag)
			{
				data.Text = noneText;
			}
			else
			{
				data.Text = ((myMentorShip == MyMentorship.Mentorship_Pupil) ? pupilText : masterText);
				for (int i = 0; i < relationTargetsCount; i++)
				{
					MentorRelationInfo relationTargetInfo = this.doc.GetRelationTargetInfo(i);
					bool flag2 = status == MentorRelationStatus.MentorRelationMax;
					if (flag2)
					{
						data.AppendList(relationTargetInfo.roleInfo.name, handler, relationTargetInfo.roleInfo.roleID);
					}
					else
					{
						int num = 0;
						for (int j = 0; j < relationTargetInfo.statusTimeList.Count; j++)
						{
							MentorRelationTime mentorRelationTime = relationTargetInfo.statusTimeList[j];
							bool flag3 = mentorRelationTime.status == MentorRelationStatus.MentorRelationBreakApply;
							if (flag3)
							{
								num = this._GetBreakTargetTime(mentorRelationTime.time);
								bool flag4 = num > 0;
								if (flag4)
								{
									break;
								}
							}
						}
						bool flag5 = num > 0;
						if (flag5)
						{
							bool flag6 = status == MentorRelationStatus.MentorRelationBreakApply && relationTargetInfo.breakApplyRoleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
							if (flag6)
							{
								XDramaOperateList xdramaOperateList = data.AppendList(relationTargetInfo.roleInfo.name, handler, relationTargetInfo.roleInfo.roleID);
								xdramaOperateList.TargetTime = (float)num + Time.realtimeSinceStartup;
							}
						}
						else
						{
							bool flag7 = status == MentorRelationStatus.MentorRelationBreak;
							if (flag7)
							{
								XDramaOperateList xdramaOperateList2 = data.AppendList(relationTargetInfo.roleInfo.name, handler, relationTargetInfo.roleInfo.roleID);
								xdramaOperateList2.TimeNote = XStringDefineProxy.GetString("MentorshipBreaking");
							}
						}
					}
				}
			}
			base._FireEvent(data);
		}

		private bool _SelectForceComplete(IXUIButton btn)
		{
			this._CreateSelection(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("MentorshipNpcDialog_NoRelation")), XStringDefineProxy.GetString("MentorshipNpcDialog_SelectForceCompletePupil"), XStringDefineProxy.GetString("MentorshipNpcDialog_SelectForceCompleteMaster"), new SpriteClickEventHandler(this._ForceComplete), MentorRelationStatus.MentorRelationMax);
			return true;
		}

		private bool _SelectNormalComplete(IXUIButton btn)
		{
			this._CreateSelection(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("MentorshipNpcDialog_NoRelation")), XStringDefineProxy.GetString("MentorshipNpcDialog_SelectNormalCompletePupil"), XStringDefineProxy.GetString("MentorshipNpcDialog_SelectNormalCompleteMaster"), new SpriteClickEventHandler(this._NormalComplete), MentorRelationStatus.MentorRelationMax);
			return true;
		}

		private bool _SelectBreak(IXUIButton btn)
		{
			this._CreateSelection(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("MentorshipNpcDialog_NoRelation")), XStringDefineProxy.GetString("MentorshipNpcDialog_SelectBreakPupil"), XStringDefineProxy.GetString("MentorshipNpcDialog_SelectBreakMaster"), new SpriteClickEventHandler(this._Break), MentorRelationStatus.MentorRelationBreak);
			return true;
		}

		private bool _SelectBreakCancel(IXUIButton btn)
		{
			this._CreateSelection(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("MentorshipNpcDialog_NoBreakingRelation")), XStringDefineProxy.GetString("MentorshipNpcDialog_SelectBreakCancelPupil"), XStringDefineProxy.GetString("MentorshipNpcDialog_SelectBreakCancelMaster"), new SpriteClickEventHandler(this._BreakCancel), MentorRelationStatus.MentorRelationBreakApply);
			return true;
		}

		private void _GetSelectedRole(IXUISprite iSp)
		{
			this.m_SelectedRoleID = 0UL;
			this.m_SelectedRoleName = string.Empty;
			bool flag = iSp != null;
			if (flag)
			{
				MentorRelationInfo relationTargetInfoByRoleID = this.doc.GetRelationTargetInfoByRoleID(iSp.ID);
				bool flag2 = relationTargetInfoByRoleID != null;
				if (flag2)
				{
					this.m_SelectedRoleID = relationTargetInfoByRoleID.roleInfo.roleID;
					this.m_SelectedRoleName = relationTargetInfoByRoleID.roleInfo.name;
				}
			}
		}

		private void _Break(IXUISprite iSp)
		{
			this._GetSelectedRole(iSp);
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("MentorshipBreakConfirm", new object[]
			{
				this.m_SelectedRoleName
			}), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this._DoBreak));
		}

		private bool _DoBreak(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.doc.SendMentorRelationOp(MentorRelationOpType.MentorRelationOp_Break, this.m_SelectedRoleID, 0);
			return true;
		}

		private void _OnBreak(MentorRelationOpRes oRes)
		{
			XDramaOperateParam data = XDataPool<XDramaOperateParam>.GetData();
			ErrorCode error = oRes.error;
			if (error != ErrorCode.ERR_SUCCESS)
			{
				data.Text = XStringDefineProxy.GetString(oRes.error);
			}
			else
			{
				data.Text = XStringDefineProxy.GetString("MentorshipBreakSuccess");
			}
			base._FireEvent(data);
		}

		private void _BreakCancel(IXUISprite iSp)
		{
			this._GetSelectedRole(iSp);
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("MentorshipBreakCancelConfirm", new object[]
			{
				this.m_SelectedRoleName
			}), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this._DoBreakCancel));
		}

		private bool _DoBreakCancel(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.doc.SendMentorRelationOp(MentorRelationOpType.MentorRelationOp_BreakCancel, this.m_SelectedRoleID, 0);
			return true;
		}

		private void _OnBreakCancel(MentorRelationOpRes oRes)
		{
			XDramaOperateParam data = XDataPool<XDramaOperateParam>.GetData();
			ErrorCode error = oRes.error;
			if (error != ErrorCode.ERR_SUCCESS)
			{
				data.Text = XStringDefineProxy.GetString(oRes.error);
			}
			else
			{
				data.Text = XStringDefineProxy.GetString("MentorshipBreakCancelSuccess");
			}
			base._FireEvent(data);
		}

		private void _PlayCompleteFx()
		{
			XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_yh", XSingleton<XGameUI>.singleton.UIRoot.transform, Vector3.zero, Vector3.one, 1f, false, 8f, true);
		}

		private void _ForceComplete(IXUISprite iSp)
		{
			this._GetSelectedRole(iSp);
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("MentorshipForceCompleteConfirm", new object[]
			{
				this.m_SelectedRoleName
			}), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this._DoForceComplete));
		}

		private bool _DoForceComplete(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			bool flag = XMentorshipDocument.Doc.IsMentorshipInDaysEnough(this.m_SelectedRoleID) && XMentorshipDocument.Doc.IsCompletedTaskEnough(this.m_SelectedRoleID);
			if (flag)
			{
				this.doc.SendMentorRelationOp(MentorRelationOpType.MentorRelationOp_ForceComplete, this.m_SelectedRoleID, 0);
			}
			return true;
		}

		private void _OnForceComplete(MentorRelationOpRes oRes)
		{
			XDramaOperateParam data = XDataPool<XDramaOperateParam>.GetData();
			ErrorCode error = oRes.error;
			if (error != ErrorCode.ERR_SUCCESS)
			{
				data.Text = XStringDefineProxy.GetString(oRes.error);
			}
			else
			{
				data.Text = XStringDefineProxy.GetString("MentorshipForceCompleteSuccess");
				this._PlayCompleteFx();
				XMentorshipDocument.Doc.SendMentorshipInfoReq();
			}
			base._FireEvent(data);
		}

		private void _NormalComplete(IXUISprite iSp)
		{
			this._GetSelectedRole(iSp);
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("MentorshipNormalCompleteConfirm", new object[]
			{
				this.m_SelectedRoleName
			}), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this._DoNormalComplete));
		}

		private bool _DoNormalComplete(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			bool flag = XMentorshipDocument.Doc.IsMentorshipInDaysEnough(this.m_SelectedRoleID) && XMentorshipDocument.Doc.IsCompletedTaskEnough(this.m_SelectedRoleID);
			if (flag)
			{
				this.doc.SendMentorRelationOp(MentorRelationOpType.MentorRelationOp_NormalComplete, this.m_SelectedRoleID, 0);
			}
			return true;
		}

		private void _OnNormalComplete(MentorRelationOpRes oRes)
		{
			XDramaOperateParam data = XDataPool<XDramaOperateParam>.GetData();
			ErrorCode error = oRes.error;
			if (error != ErrorCode.ERR_SUCCESS)
			{
				data.Text = XStringDefineProxy.GetString(oRes.error);
			}
			else
			{
				data.Text = XStringDefineProxy.GetString("MentorshipNormalCompleteSuccess");
				this._PlayCompleteFx();
				XMentorshipDocument.Doc.SendMentorshipInfoReq();
			}
			base._FireEvent(data);
		}

		public void OnMentorRelationOp(MentorRelationOpArg oArg, MentorRelationOpRes oRes)
		{
			switch (oArg.operation)
			{
			case MentorRelationOpType.MentorRelationOp_Break:
				this._OnBreak(oRes);
				break;
			case MentorRelationOpType.MentorRelationOp_BreakCancel:
				this._OnBreakCancel(oRes);
				break;
			case MentorRelationOpType.MentorRelationOp_NormalComplete:
				this._OnNormalComplete(oRes);
				break;
			case MentorRelationOpType.MentorRelationOp_ForceComplete:
				this._OnForceComplete(oRes);
				break;
			}
		}

		private ulong m_SelectedRoleID = 0UL;

		private string m_SelectedRoleName = null;

		private XDramaOperateParam _param;

		private XMentorshipDocument doc;
	}
}
