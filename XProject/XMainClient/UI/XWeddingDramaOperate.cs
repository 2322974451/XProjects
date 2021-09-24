using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XWeddingDramaOperate : XDramaOperate
	{

		public override void ShowNpc(XNpc npc)
		{
			base.ShowNpc(npc);
			this.doc = XDocuments.GetSpecificDocument<XWeddingDocument>(XWeddingDocument.uuID);
			this._param = XDataPool<XDramaOperateParam>.GetData();
			this._param.Npc = npc;
			XWeddingDocument.Doc.SendMarriageRelationInfo();
		}

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

		private void ToCancelApplyDivorce(IXUISprite uiSprite)
		{
			string message = XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeddingCancelBreakTip"));
			XSingleton<UiUtility>.singleton.ShowModalDialog(message, new ButtonClickEventHandler(this.ToSendCancelApplyDivorce));
		}

		private bool ToSendCancelApplyDivorce(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XWeddingDocument.Doc.SendMarriageOp(MarriageOpType.MarriageOpType_DivorceCancel, WeddingType.WeddingType_Normal, 0UL);
			return true;
		}

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

		private bool ToSendBreakMarriage(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XWeddingDocument.Doc.SendMarriageOp(MarriageOpType.MarriageOpType_Divorce, WeddingType.WeddingType_Normal, 0UL);
			return true;
		}

		private string GetCostString(string global)
		{
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList(global, true);
			int itemID = sequenceList[0, 0];
			int num = sequenceList[0, 1];
			return num + "X" + XBagDocument.GetItemConf(itemID).ItemName[0];
		}

		private bool ToGetWeddingCar(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("WeddingCarConfirmTip"), new ButtonClickEventHandler(this.ToSendWeddingCar));
			return true;
		}

		private bool ToSendWeddingCar(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XWeddingDocument.Doc.SendWeddingCar();
			return true;
		}

		private bool ToInviteFriends(IXUIButton button)
		{
			DlgBase<XWeddingInviteView, XWeddingInviteBehavior>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private bool EnterMarriageScene(IXUIButton button)
		{
			DlgBase<WeddingEnterApplyView, WeddingEnterApplyBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private bool ToHoldBetterWedding(IXUIButton button)
		{
			bool flag = this.IsAvailableTeam();
			if (flag)
			{
				DlgBase<XWeddingCostView, XWeddingCostBehavior>.singleton.RefreshUI(WeddingType.WeddingType_Luxury);
			}
			return true;
		}

		private bool ToSendBetterWedding(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XWeddingDocument.Doc.SendMarriageOp(MarriageOpType.MarriageOpType_MarryApply, WeddingType.WeddingType_Luxury, 0UL);
			return true;
		}

		private bool ToHoldNormalWedding(IXUIButton button)
		{
			bool flag = this.IsAvailableTeam();
			if (flag)
			{
				DlgBase<XWeddingCostView, XWeddingCostBehavior>.singleton.RefreshUI(WeddingType.WeddingType_Normal);
			}
			return true;
		}

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

		private bool ToSendNormalWedding(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XWeddingDocument.Doc.SendMarriageOp(MarriageOpType.MarriageOpType_MarryApply, WeddingType.WeddingType_Normal, 0UL);
			return true;
		}

		private bool ToHoldWeddingFeast(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("WeddingFeastOnlyOnce"), new ButtonClickEventHandler(this.ToSendReqWedding));
			return true;
		}

		private bool ToSendReqWedding(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XWeddingDocument.Doc.ReqHoldWedding();
			return true;
		}

		private bool ToGetMarriage(IXUIButton button)
		{
			XDramaOperateParam data = XDataPool<XDramaOperateParam>.GetData();
			data.Text = XStringDefineProxy.GetString("MentorshipNpcDialog_0_Master");
			data.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_NormalWedding"), new ButtonClickEventHandler(this.ToHoldNormalWedding), 0UL);
			data.AppendButton(XStringDefineProxy.GetString("Wedding_Npc_BetterWedding"), new ButtonClickEventHandler(this.ToHoldBetterWedding), 0UL);
			base._FireEvent(data);
			return true;
		}

		private bool ToKnowMarriage(IXUIButton button)
		{
			string text = XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeddingRule"));
			text = text.Replace("{s}", " ");
			XSingleton<UiUtility>.singleton.ShowModalDialog(text, XStringDefineProxy.GetString("COMMON_OK"), new ButtonClickEventHandler(this.ToCloseMarriageIntro), 50);
			return true;
		}

		private bool ToCloseMarriageIntro(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

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

		private XDramaOperateParam _param;

		private XWeddingDocument doc;
	}
}
