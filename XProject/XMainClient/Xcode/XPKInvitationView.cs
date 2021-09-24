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

	internal class XPKInvitationView : DlgBase<XPKInvitationView, XPKInvitationBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/pkdlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdate));
			base.uiBehaviour.m_IgnoreAll.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnIgnoreAllClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_WrapContent.SetVisible(false);
			this.m_TimeLabelList.Clear();
			this.m_TimeInvID.Clear();
			this.m_TimeDic.Clear();
			this._Doc.ReqAllPKInvitation();
		}

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

		public void RefreshList()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				base.uiBehaviour.m_WrapContent.SetVisible(true);
				base.uiBehaviour.m_WrapContent.SetContentCount(this._Doc.AllInvitation.Count, false);
			}
		}

		private void OnWrapContentUpdate(Transform t, int index)
		{
			List<InvFightRoleBrief> allInvitation = this._Doc.AllInvitation;
			bool flag = index >= allInvitation.Count;
			if (!flag)
			{
				this.SetInvitationInfo(t, allInvitation[index]);
			}
		}

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

		private bool OnRejectBtnClicked(IXUIButton btn)
		{
			this._Doc.RejectInvitation(btn.ID);
			return true;
		}

		private bool OnIgnoreAllClicked(IXUIButton btn)
		{
			this._Doc.IgnoreAllInvitation();
			return true;
		}

		private bool OnHelpBtnClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_PK);
			return true;
		}

		private bool OnCloseBtnClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private XPKInvitationDocument _Doc;

		private uint _CDToken = 0U;

		private List<IXUILabel> m_TimeLabelList = new List<IXUILabel>();

		private List<ulong> m_TimeInvID = new List<ulong>();

		private Dictionary<ulong, uint> m_TimeDic = new Dictionary<ulong, uint>();
	}
}
