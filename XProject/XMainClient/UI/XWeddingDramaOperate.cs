using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001702 RID: 5890
	internal class XWeddingDramaOperate : XDramaOperate
	{
		// Token: 0x0600F2D7 RID: 62167 RVA: 0x0035E5A9 File Offset: 0x0035C7A9
		public override void ShowNpc(XNpc npc)
		{
			base.ShowNpc(npc);
			this.doc = XDocuments.GetSpecificDocument<XWeddingDocument>(XWeddingDocument.uuID);
			this._param = XDataPool<XDramaOperateParam>.GetData();
			this._param.Npc = npc;
			XWeddingDocument.Doc.SendMarriageRelationInfo();
		}

		// Token: 0x0600F2D8 RID: 62168 RVA: 0x0035E5E8 File Offset: 0x0035C7E8
		public void RefreshOperateStatus()
		{
			switch (this.doc.GetMyMarriageRelation())
			{
			case MarriageStatus.MarriageStatus_Marriaged:
			{
				this._param.Text = XStringDefineProxy.GetString("MentorshipNpcDialog_0_Pupil");
				string @string = XStringDefineProxy.GetString("Wedding_Npc_HoldFeast");
				this._param.AppendButton(@string, new ButtonClickEventHandler(this.ToHoldWeddingFeast), 0UL);
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_BreakMarriage"), new ButtonClickEventHandler(this.ToBreakMarriage), 0UL);
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_JoinWedding"), new ButtonClickEventHandler(this.EnterMarriageScene), 0UL);
				break;
			}
			case MarriageStatus.MarriageStatus_WeddingHoldingNoCar:
				this._param.Text = XStringDefineProxy.GetString("MentorshipNpcDialog_0_Pupil");
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_InviteFriends"), new ButtonClickEventHandler(this.ToInviteFriends), 0UL);
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_JoinWedding"), new ButtonClickEventHandler(this.EnterMarriageScene), 0UL);
				break;
			case MarriageStatus.MarriageStatus_WeddingHoldedNoCar:
				this._param.Text = XStringDefineProxy.GetString("MentorshipNpcDialog_0_Pupil");
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_BreakMarriage"), new ButtonClickEventHandler(this.ToBreakMarriage), 0UL);
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_JoinWedding"), new ButtonClickEventHandler(this.EnterMarriageScene), 0UL);
				break;
			case MarriageStatus.MarriageStatus_WeddingCarNoWedding:
				this._param.Text = XStringDefineProxy.GetString("MentorshipNpcDialog_0_Pupil");
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_HoldFeast"), new ButtonClickEventHandler(this.ToHoldWeddingFeast), 0UL);
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_BreakMarriage"), new ButtonClickEventHandler(this.ToBreakMarriage), 0UL);
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_JoinWedding"), new ButtonClickEventHandler(this.EnterMarriageScene), 0UL);
				break;
			case MarriageStatus.MarriageStatus_WeddingHoldingAndCar:
				this._param.Text = XStringDefineProxy.GetString("MentorshipNpcDialog_0_Pupil");
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_InviteFriends"), new ButtonClickEventHandler(this.ToInviteFriends), 0UL);
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_JoinWedding"), new ButtonClickEventHandler(this.EnterMarriageScene), 0UL);
				break;
			case MarriageStatus.MarriageStatus_WeddingHoldedAndCar:
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_JoinWedding"), new ButtonClickEventHandler(this.EnterMarriageScene), 0UL);
				this._param.Text = XStringDefineProxy.GetString("MentorshipNpcDialog_0_Pupil");
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_BreakMarriage"), new ButtonClickEventHandler(this.ToBreakMarriage), 0UL);
				break;
			case MarriageStatus.MarriageStatus_DivorceApply:
				this._param.Text = XStringDefineProxy.GetString("MentorshipNpcDialog_0_Pupil");
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_CancelBreak"), new ButtonClickEventHandler(this.ClickToCancel), 0UL);
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_JoinWedding"), new ButtonClickEventHandler(this.EnterMarriageScene), 0UL);
				break;
			case MarriageStatus.MarriageStatus_Divorced:
				this._param.Text = XStringDefineProxy.GetString("MentorshipNpcDialog_0_Pupil");
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_JoinWedding"), new ButtonClickEventHandler(this.EnterMarriageScene), 0UL);
				break;
			default:
				this._param.Text = XStringDefineProxy.GetString("MentorshipNpcDialog_0_Pupil");
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_Abount"), new ButtonClickEventHandler(this.ToKnowMarriage), 0UL);
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_ToMarry"), new ButtonClickEventHandler(this.ToGetMarriage), 0UL);
				this._param.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_JoinWedding"), new ButtonClickEventHandler(this.EnterMarriageScene), 0UL);
				break;
			}
			base._FireEvent(this._param);
		}

		// Token: 0x0600F2D9 RID: 62169 RVA: 0x0035E9F8 File Offset: 0x0035CBF8
		private bool ClickToCancel(IXUIButton button)
		{
			XDramaOperateParam data = XDataPool<XDramaOperateParam>.GetData();
			this._param.Text = XStringDefineProxy.GetString("WeddingSelectToCancel");
			RoleOutLookBrief partnerInfo = this.doc.GetPartnerInfo();
			bool flag = partnerInfo != null && this.doc.DivorceApplyID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			if (flag)
			{
				XDramaOperateList xdramaOperateList = this._param.AppendList(partnerInfo.name, new SpriteClickEventHandler(this.ToCancelApplyDivorce), partnerInfo.roleid);
				xdramaOperateList.TargetTime = (float)this.doc.LeftDivorceTime;
			}
			else
			{
				this._param.Text = XStringDefineProxy.GetString("ERR_MARRIAGE_ONLY_APPLIER_CANCLEDIVORCE");
			}
			base._FireEvent(data);
			return true;
		}

		// Token: 0x0600F2DA RID: 62170 RVA: 0x0035EAB4 File Offset: 0x0035CCB4
		private void ToCancelApplyDivorce(IXUISprite uiSprite)
		{
			string message = XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeddingCancelBreakTip"));
			XSingleton<UiUtility>.singleton.ShowModalDialog(message, new ButtonClickEventHandler(this.ToSendCancelApplyDivorce));
		}

		// Token: 0x0600F2DB RID: 62171 RVA: 0x0035EAF4 File Offset: 0x0035CCF4
		private bool ToSendCancelApplyDivorce(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XWeddingDocument.Doc.SendMarriageOp(MarriageOpType.MarriageOpType_DivorceCancel, WeddingType.WeddingType_Normal, 0UL);
			return true;
		}

		// Token: 0x0600F2DC RID: 62172 RVA: 0x0035EB24 File Offset: 0x0035CD24
		private bool ToBreakMarriage(IXUIButton button)
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("MarriageFreeDivorceDay");
			bool flag = XWeddingDocument.Doc.CoupleOfflineTime < @int * 60 * 60 * 24;
			string message;
			if (flag)
			{
				RoleOutLookBrief partnerInfo = XWeddingDocument.Doc.GetPartnerInfo();
				SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("MarriageDivorceCost", true);
				int itemID = sequenceList[0, 0];
				int num = sequenceList[0, 1];
				string arg = num + XBagDocument.GetItemConf(itemID).ItemName[0];
				message = string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("Wedding_Npc_ToBreakTip")), arg, (partnerInfo == null) ? "" : partnerInfo.name);
			}
			else
			{
				message = XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeddingBreakFreeCostTip"));
			}
			XSingleton<UiUtility>.singleton.ShowModalDialog(message, new ButtonClickEventHandler(this.ToSendBreakMarriage));
			return true;
		}

		// Token: 0x0600F2DD RID: 62173 RVA: 0x0035EC24 File Offset: 0x0035CE24
		private bool ToSendBreakMarriage(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XWeddingDocument.Doc.SendMarriageOp(MarriageOpType.MarriageOpType_Divorce, WeddingType.WeddingType_Normal, 0UL);
			return true;
		}

		// Token: 0x0600F2DE RID: 62174 RVA: 0x0035EC54 File Offset: 0x0035CE54
		private string GetCostString(string global)
		{
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList(global, true);
			int itemID = sequenceList[0, 0];
			int num = sequenceList[0, 1];
			return num + "X" + XBagDocument.GetItemConf(itemID).ItemName[0];
		}

		// Token: 0x0600F2DF RID: 62175 RVA: 0x0035ECA8 File Offset: 0x0035CEA8
		private bool ToGetWeddingCar(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("WeddingCarConfirmTip"), new ButtonClickEventHandler(this.ToSendWeddingCar));
			return true;
		}

		// Token: 0x0600F2E0 RID: 62176 RVA: 0x0035ECDC File Offset: 0x0035CEDC
		private bool ToSendWeddingCar(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XWeddingDocument.Doc.SendWeddingCar();
			return true;
		}

		// Token: 0x0600F2E1 RID: 62177 RVA: 0x0035ED08 File Offset: 0x0035CF08
		private bool ToInviteFriends(IXUIButton button)
		{
			DlgBase<XWeddingInviteView, XWeddingInviteBehavior>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x0600F2E2 RID: 62178 RVA: 0x0035ED28 File Offset: 0x0035CF28
		private bool EnterMarriageScene(IXUIButton button)
		{
			DlgBase<WeddingEnterApplyView, WeddingEnterApplyBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x0600F2E3 RID: 62179 RVA: 0x0035ED48 File Offset: 0x0035CF48
		private bool ToHoldBetterWedding(IXUIButton button)
		{
			bool flag = this.IsAvailableTeam();
			if (flag)
			{
				DlgBase<XWeddingCostView, XWeddingCostBehavior>.singleton.RefreshUI(WeddingType.WeddingType_Luxury);
			}
			return true;
		}

		// Token: 0x0600F2E4 RID: 62180 RVA: 0x0035ED74 File Offset: 0x0035CF74
		private bool ToSendBetterWedding(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XWeddingDocument.Doc.SendMarriageOp(MarriageOpType.MarriageOpType_MarryApply, WeddingType.WeddingType_Luxury, 0UL);
			return true;
		}

		// Token: 0x0600F2E5 RID: 62181 RVA: 0x0035EDA4 File Offset: 0x0035CFA4
		private bool ToHoldNormalWedding(IXUIButton button)
		{
			bool flag = this.IsAvailableTeam();
			if (flag)
			{
				DlgBase<XWeddingCostView, XWeddingCostBehavior>.singleton.RefreshUI(WeddingType.WeddingType_Normal);
			}
			return true;
		}

		// Token: 0x0600F2E6 RID: 62182 RVA: 0x0035EDD0 File Offset: 0x0035CFD0
		private bool IsAvailableTeam()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool bInTeam = specificDocument.bInTeam;
			if (bInTeam)
			{
				List<XTeamMember> members = specificDocument.MyTeam.members;
				bool flag = members.Count == 2 && XSingleton<UiUtility>.singleton.IsOppositeSex((int)members[0].profession, (int)members[1].profession);
				if (flag)
				{
					return true;
				}
			}
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_WEDDING_NEED_TWO_MARRIAGE"), "fece00");
			return false;
		}

		// Token: 0x0600F2E7 RID: 62183 RVA: 0x0035EE5C File Offset: 0x0035D05C
		private bool ToSendNormalWedding(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XWeddingDocument.Doc.SendMarriageOp(MarriageOpType.MarriageOpType_MarryApply, WeddingType.WeddingType_Normal, 0UL);
			return true;
		}

		// Token: 0x0600F2E8 RID: 62184 RVA: 0x0035EE8C File Offset: 0x0035D08C
		private bool ToHoldWeddingFeast(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("WeddingFeastOnlyOnce"), new ButtonClickEventHandler(this.ToSendReqWedding));
			return true;
		}

		// Token: 0x0600F2E9 RID: 62185 RVA: 0x0035EEC0 File Offset: 0x0035D0C0
		private bool ToSendReqWedding(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XWeddingDocument.Doc.ReqHoldWedding();
			return true;
		}

		// Token: 0x0600F2EA RID: 62186 RVA: 0x0035EEEC File Offset: 0x0035D0EC
		private bool ToGetMarriage(IXUIButton button)
		{
			XDramaOperateParam data = XDataPool<XDramaOperateParam>.GetData();
			data.Text = XStringDefineProxy.GetString("MentorshipNpcDialog_0_Master");
			data.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_NormalWedding"), new ButtonClickEventHandler(this.ToHoldNormalWedding), 0UL);
			data.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_BetterWedding"), new ButtonClickEventHandler(this.ToHoldBetterWedding), 0UL);
			base._FireEvent(data);
			return true;
		}

		// Token: 0x0600F2EB RID: 62187 RVA: 0x0035EF5C File Offset: 0x0035D15C
		private bool ToKnowMarriage(IXUIButton button)
		{
			string text = XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeddingRule"));
			text = text.Replace("{s}", " ");
			XSingleton<UiUtility>.singleton.ShowModalDialog(text, XStringDefineProxy.GetString("COMMON_OK"), new ButtonClickEventHandler(this.ToCloseMarriageIntro), 50);
			return true;
		}

		// Token: 0x0600F2EC RID: 62188 RVA: 0x0035EFC0 File Offset: 0x0035D1C0
		private bool ToCloseMarriageIntro(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600F2ED RID: 62189 RVA: 0x0035EFE0 File Offset: 0x0035D1E0
		public void RefreshMarriageOp(MarriageRelationOpArg oarg, MarriageRelationOpRes oRes)
		{
			XDramaOperateParam data = XDataPool<XDramaOperateParam>.GetData();
			bool flag = oRes.error == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				switch (oarg.opType)
				{
				case MarriageOpType.MarriageOpType_MarryApply:
					data.Text = XSingleton<XStringTable>.singleton.GetString("WeddingApplySucceed");
					break;
				case MarriageOpType.MarriageOpType_Divorce:
					data.Text = XSingleton<XStringTable>.singleton.GetString("WeddingDivorceSendSuccess");
					break;
				case MarriageOpType.MarriageOpType_DivorceCancel:
					data.Text = XStringDefineProxy.GetString("WeddingDivorceCancelSuccess");
					break;
				}
			}
			else
			{
				data.Text = XStringDefineProxy.GetString(oRes.error);
			}
			base._FireEvent(data);
		}

		// Token: 0x0400681F RID: 26655
		private XDramaOperateParam _param;

		// Token: 0x04006820 RID: 26656
		private XWeddingDocument doc;
	}
}
