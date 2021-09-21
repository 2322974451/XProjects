using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C84 RID: 3204
	internal class XPKInvitationView : DlgBase<XPKInvitationView, XPKInvitationBehaviour>
	{
		// Token: 0x1700320C RID: 12812
		// (get) Token: 0x0600B507 RID: 46343 RVA: 0x00239568 File Offset: 0x00237768
		public override string fileName
		{
			get
			{
				return "GameSystem/pkdlg";
			}
		}

		// Token: 0x1700320D RID: 12813
		// (get) Token: 0x0600B508 RID: 46344 RVA: 0x00239580 File Offset: 0x00237780
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B509 RID: 46345 RVA: 0x00239593 File Offset: 0x00237793
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
		}

		// Token: 0x0600B50A RID: 46346 RVA: 0x002395B0 File Offset: 0x002377B0
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
			bool flag = false;
			for (int i = 0; i < this._Doc.AllInvitation.Count; i++)
			{
				bool flag2 = this._Doc.AllInvitation[i].ctime > 0U;
				if (flag2)
				{
					flag = true;
					break;
				}
			}
			bool flag3 = !flag;
			if (flag3)
			{
				this._Doc.InvitationCount = 0U;
			}
		}

		// Token: 0x0600B50B RID: 46347 RVA: 0x00239634 File Offset: 0x00237834
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdate));
			base.uiBehaviour.m_IgnoreAll.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnIgnoreAllClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClicked));
		}

		// Token: 0x0600B50C RID: 46348 RVA: 0x002396C0 File Offset: 0x002378C0
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_WrapContent.SetVisible(false);
			this.m_TimeLabelList.Clear();
			this.m_TimeInvID.Clear();
			this.m_TimeDic.Clear();
			this._Doc.ReqAllPKInvitation();
		}

		// Token: 0x0600B50D RID: 46349 RVA: 0x00239718 File Offset: 0x00237918
		public void StartTimer()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				for (int i = 0; i < this._Doc.AllInvitation.Count; i++)
				{
					this.m_TimeDic[this._Doc.AllInvitation[i].invID] = this._Doc.AllInvitation[i].ctime;
				}
				XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
				this._CDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdate), null);
			}
		}

		// Token: 0x0600B50E RID: 46350 RVA: 0x002397C4 File Offset: 0x002379C4
		private void LeftTimeUpdate(object o)
		{
			for (int i = 0; i < this._Doc.AllInvitation.Count; i++)
			{
				bool flag = this._Doc.AllInvitation[i].ctime > 0U;
				if (flag)
				{
					InvFightRoleBrief invFightRoleBrief = this._Doc.AllInvitation[i];
					uint ctime = invFightRoleBrief.ctime;
					invFightRoleBrief.ctime = ctime - 1U;
				}
				this.m_TimeDic[this._Doc.AllInvitation[i].invID] = this._Doc.AllInvitation[i].ctime;
				int num = this.m_TimeInvID.IndexOf(this._Doc.AllInvitation[i].invID);
				bool flag2 = num >= 0 && num < this.m_TimeLabelList.Count;
				if (flag2)
				{
					IXUILabel ixuilabel = this.m_TimeLabelList[num];
					bool flag3 = ixuilabel.IsVisible();
					if (flag3)
					{
						bool flag4 = this._Doc.AllInvitation[i].ctime > 0U;
						if (flag4)
						{
							ixuilabel.SetText(string.Format("{0}{1}", this._Doc.AllInvitation[i].ctime, XSingleton<XStringTable>.singleton.GetString("SECOND_DUARATION")));
						}
						else
						{
							ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString("PK_TIME_END"));
						}
					}
				}
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
			this._CDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdate), null);
		}

		// Token: 0x0600B50F RID: 46351 RVA: 0x00239978 File Offset: 0x00237B78
		public void RefreshList()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				base.uiBehaviour.m_WrapContent.SetVisible(true);
				base.uiBehaviour.m_WrapContent.SetContentCount(this._Doc.AllInvitation.Count, false);
			}
		}

		// Token: 0x0600B510 RID: 46352 RVA: 0x002399CC File Offset: 0x00237BCC
		private void OnWrapContentUpdate(Transform t, int index)
		{
			List<InvFightRoleBrief> allInvitation = this._Doc.AllInvitation;
			bool flag = index >= allInvitation.Count;
			if (!flag)
			{
				this.SetInvitationInfo(t, allInvitation[index]);
			}
		}

		// Token: 0x0600B511 RID: 46353 RVA: 0x00239A08 File Offset: 0x00237C08
		private void SetInvitationInfo(Transform t, InvFightRoleBrief info)
		{
			bool flag = info == null;
			if (!flag)
			{
				IXUISprite ixuisprite = t.Find("head").GetComponent("XUISprite") as IXUISprite;
				IXUILabelSymbol ixuilabelSymbol = t.Find("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				IXUILabel ixuilabel = t.Find("Level").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("Position").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.Find("time").GetComponent("XUILabel") as IXUILabel;
				IXUIButton ixuibutton = t.Find("yesBtn").GetComponent("XUIButton") as IXUIButton;
				IXUIButton ixuibutton2 = t.Find("noBtn").GetComponent("XUIButton") as IXUIButton;
				GameObject gameObject = t.Find("qqLaunch").gameObject;
				GameObject gameObject2 = t.Find("wxLaunch").gameObject;
				ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)info.profession));
				ixuilabelSymbol.InputText = XTitleDocument.GetTitleWithFormat(info.title, info.name);
				ixuilabel.SetText(info.level.ToString());
				ixuilabel2.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName((int)info.profession));
				gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ && info.isplatfriend);
				gameObject2.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat && info.isplatfriend);
				ixuibutton.ID = info.invID;
				ixuibutton2.ID = info.invID;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAcceptBtnClicked));
				ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRejectBtnClicked));
				int num = this.m_TimeLabelList.IndexOf(ixuilabel3);
				bool flag2 = num >= 0 && num < this.m_TimeInvID.Count;
				if (flag2)
				{
					this.m_TimeInvID[num] = info.invID;
				}
				else
				{
					this.m_TimeLabelList.Add(ixuilabel3);
					this.m_TimeInvID.Add(info.invID);
				}
				uint num2;
				bool flag3 = this.m_TimeDic.TryGetValue(info.invID, out num2);
				if (flag3)
				{
					bool flag4 = num2 > 0U;
					if (flag4)
					{
						ixuilabel3.SetText(string.Format("{0}{1}", num2, XSingleton<XStringTable>.singleton.GetString("SECOND_DUARATION")));
					}
					else
					{
						ixuilabel3.SetText(XSingleton<XStringTable>.singleton.GetString("PK_TIME_END"));
					}
				}
			}
		}

		// Token: 0x0600B512 RID: 46354 RVA: 0x00239CB4 File Offset: 0x00237EB4
		private bool OnAcceptBtnClicked(IXUIButton btn)
		{
			uint num;
			bool flag = this.m_TimeDic.TryGetValue(btn.ID, out num);
			if (flag)
			{
				bool flag2 = num > 0U;
				if (flag2)
				{
					this._Doc.AcceptInvitation(btn.ID);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PK_TIME_END_TIP"), "fece00");
				}
			}
			return true;
		}

		// Token: 0x0600B513 RID: 46355 RVA: 0x00239D20 File Offset: 0x00237F20
		private bool OnRejectBtnClicked(IXUIButton btn)
		{
			this._Doc.RejectInvitation(btn.ID);
			return true;
		}

		// Token: 0x0600B514 RID: 46356 RVA: 0x00239D48 File Offset: 0x00237F48
		private bool OnIgnoreAllClicked(IXUIButton btn)
		{
			this._Doc.IgnoreAllInvitation();
			return true;
		}

		// Token: 0x0600B515 RID: 46357 RVA: 0x00239D68 File Offset: 0x00237F68
		private bool OnHelpBtnClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_PK);
			return true;
		}

		// Token: 0x0600B516 RID: 46358 RVA: 0x00239D88 File Offset: 0x00237F88
		private bool OnCloseBtnClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x04004696 RID: 18070
		private XPKInvitationDocument _Doc;

		// Token: 0x04004697 RID: 18071
		private uint _CDToken = 0U;

		// Token: 0x04004698 RID: 18072
		private List<IXUILabel> m_TimeLabelList = new List<IXUILabel>();

		// Token: 0x04004699 RID: 18073
		private List<ulong> m_TimeInvID = new List<ulong>();

		// Token: 0x0400469A RID: 18074
		private Dictionary<ulong, uint> m_TimeDic = new Dictionary<ulong, uint>();
	}
}
