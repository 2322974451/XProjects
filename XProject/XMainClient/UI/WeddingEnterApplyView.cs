using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018DB RID: 6363
	internal class WeddingEnterApplyView : DlgBase<WeddingEnterApplyView, WeddingEnterApplyBehaviour>
	{
		// Token: 0x17003A6C RID: 14956
		// (get) Token: 0x0601094A RID: 67914 RVA: 0x00415E98 File Offset: 0x00414098
		public override string fileName
		{
			get
			{
				return "GameSystem/Wedding/WeddingEnterApplyDlg";
			}
		}

		// Token: 0x17003A6D RID: 14957
		// (get) Token: 0x0601094B RID: 67915 RVA: 0x00415EB0 File Offset: 0x004140B0
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A6E RID: 14958
		// (get) Token: 0x0601094C RID: 67916 RVA: 0x00415EC4 File Offset: 0x004140C4
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A6F RID: 14959
		// (get) Token: 0x0601094D RID: 67917 RVA: 0x00415ED8 File Offset: 0x004140D8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0601094E RID: 67918 RVA: 0x00415EEB File Offset: 0x004140EB
		protected override void Init()
		{
			base.uiBehaviour.m_EmptyList.SetText(XSingleton<XStringTable>.singleton.GetString("WeddingEnterEmpty"));
		}

		// Token: 0x0601094F RID: 67919 RVA: 0x00415F10 File Offset: 0x00414110
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_ToggleEnter.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnToggleChanged));
			base.uiBehaviour.m_ToggleApply.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnToggleChanged));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
			base.uiBehaviour.m_ClosedSpr.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseClicked));
			base.uiBehaviour.m_GoApplyTab.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoApplyTabClicked));
		}

		// Token: 0x06010950 RID: 67920 RVA: 0x00415FB8 File Offset: 0x004141B8
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_ToggleEnter.bChecked = true;
			XWeddingDocument specificDocument = XDocuments.GetSpecificDocument<XWeddingDocument>(XWeddingDocument.uuID);
			specificDocument.GetAllWeddingInfo();
		}

		// Token: 0x06010951 RID: 67921 RVA: 0x00415FF1 File Offset: 0x004141F1
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
		}

		// Token: 0x06010952 RID: 67922 RVA: 0x0041600C File Offset: 0x0041420C
		public override void StackRefresh()
		{
			XWeddingDocument specificDocument = XDocuments.GetSpecificDocument<XWeddingDocument>(XWeddingDocument.uuID);
			specificDocument.GetAllWeddingInfo();
		}

		// Token: 0x06010953 RID: 67923 RVA: 0x0041602C File Offset: 0x0041422C
		public void RefreshInfo()
		{
			bool flag = this.m_SelectedTab < 0;
			if (!flag)
			{
				bool active = this.m_SelectedTab == 0 && this.GetCurrWeddingList().Count == 0;
				base.uiBehaviour.m_EmptyList.gameObject.SetActive(active);
				base.uiBehaviour.m_GoApplyTab.gameObject.SetActive(active);
				bool active2 = this.m_SelectedTab == 1 && this.GetCurrWeddingList().Count == 0;
				base.uiBehaviour.m_EmptyList2.gameObject.SetActive(active2);
				this.StartTimer();
				base.uiBehaviour.m_WrapContent.SetContentCount(this.GetCurrWeddingList().Count, false);
			}
		}

		// Token: 0x06010954 RID: 67924 RVA: 0x004160EC File Offset: 0x004142EC
		private List<WeddingBriefInfo> GetCurrWeddingList()
		{
			XWeddingDocument specificDocument = XDocuments.GetSpecificDocument<XWeddingDocument>(XWeddingDocument.uuID);
			bool flag = this.m_SelectedTab == 0;
			List<WeddingBriefInfo> result;
			if (flag)
			{
				result = specificDocument.CanEnterWedding;
			}
			else
			{
				result = specificDocument.CanApplyWedding;
			}
			return result;
		}

		// Token: 0x06010955 RID: 67925 RVA: 0x00416128 File Offset: 0x00414328
		private void _WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = this.m_SelectedTab < 0;
			if (!flag)
			{
				bool flag2 = index >= this.GetCurrWeddingList().Count;
				if (!flag2)
				{
					List<WeddingBriefInfo> currWeddingList = this.GetCurrWeddingList();
					WeddingBriefInfo weddingBriefInfo = currWeddingList[index];
					bool flag3 = weddingBriefInfo == null;
					if (!flag3)
					{
						IXUILabel ixuilabel = t.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
						string @string = XStringDefineProxy.GetString((weddingBriefInfo.brief.type == WeddingType.WeddingType_Normal) ? "WeddingEnterApplyNameN" : "WeddingEnterApplyNameS", new object[]
						{
							weddingBriefInfo.brief.role1.name,
							weddingBriefInfo.brief.role2.name
						});
						ixuilabel.SetText(@string);
						IXUILabel ixuilabel2 = t.FindChild("Invited").GetComponent("XUILabel") as IXUILabel;
						ixuilabel2.SetText((this.m_SelectedTab == 0) ? XStringDefineProxy.GetString("WeddingEnterApplyType1") : XStringDefineProxy.GetString("WeddingEnterApplyType2"));
						IXUIButton ixuibutton = t.FindChild("Invited/BtnInvite").GetComponent("XUIButton") as IXUIButton;
						ixuibutton.ID = weddingBriefInfo.brief.weddingid;
						ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnWeddingBtnClicked));
						ixuilabel2.gameObject.SetActive(!weddingBriefInfo.isApply);
						GameObject gameObject = t.FindChild("Bg2").gameObject;
						gameObject.SetActive(weddingBriefInfo.isApply);
						IXUILabel ixuilabel3 = t.FindChild("Time").GetComponent("XUILabel") as IXUILabel;
						int num = this.m_TimeLabelList.IndexOf(ixuilabel3);
						bool flag4 = num >= 0 && num < this.m_TimeInvID.Count;
						if (flag4)
						{
							this.m_TimeInvID[num] = weddingBriefInfo.brief.weddingid;
						}
						else
						{
							this.m_TimeLabelList.Add(ixuilabel3);
							this.m_TimeInvID.Add(weddingBriefInfo.brief.weddingid);
						}
						uint num2;
						bool flag5 = this.m_TimeDic.TryGetValue(weddingBriefInfo.brief.weddingid, out num2);
						if (flag5)
						{
							bool flag6 = num2 > 0U;
							if (flag6)
							{
								ixuilabel3.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)num2, 2, 3, 4, false, true));
							}
							else
							{
								ixuilabel3.SetText(XSingleton<XStringTable>.singleton.GetString("WeddingEnterApplyEnd"));
							}
						}
					}
				}
			}
		}

		// Token: 0x06010956 RID: 67926 RVA: 0x00416398 File Offset: 0x00414598
		public void StartTimer()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.m_TimeLabelList.Clear();
				this.m_TimeInvID.Clear();
				this.m_TimeDic.Clear();
				List<WeddingBriefInfo> currWeddingList = this.GetCurrWeddingList();
				for (int i = 0; i < currWeddingList.Count; i++)
				{
					this.m_TimeDic[currWeddingList[i].brief.weddingid] = currWeddingList[i].brief.lefttime;
				}
				XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
				this._CDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdate), null);
			}
		}

		// Token: 0x06010957 RID: 67927 RVA: 0x0041645C File Offset: 0x0041465C
		private void LeftTimeUpdate(object o)
		{
			List<WeddingBriefInfo> currWeddingList = this.GetCurrWeddingList();
			for (int i = 0; i < currWeddingList.Count; i++)
			{
				bool flag = currWeddingList[i].brief.lefttime > 0U;
				if (flag)
				{
					WeddingBrief brief = currWeddingList[i].brief;
					uint lefttime = brief.lefttime;
					brief.lefttime = lefttime - 1U;
				}
				this.m_TimeDic[currWeddingList[i].brief.weddingid] = currWeddingList[i].brief.lefttime;
				int num = this.m_TimeInvID.IndexOf(currWeddingList[i].brief.weddingid);
				bool flag2 = num >= 0 && num < this.m_TimeLabelList.Count;
				if (flag2)
				{
					IXUILabel ixuilabel = this.m_TimeLabelList[num];
					bool flag3 = ixuilabel.IsVisible();
					if (flag3)
					{
						bool flag4 = currWeddingList[i].brief.lefttime > 0U;
						if (flag4)
						{
							ixuilabel.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)currWeddingList[i].brief.lefttime, 2, 3, 4, false, true));
						}
						else
						{
							ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString("WeddingEnterApplyEnd"));
						}
					}
				}
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
			this._CDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdate), null);
		}

		// Token: 0x06010958 RID: 67928 RVA: 0x004165DC File Offset: 0x004147DC
		private bool OnWeddingBtnClicked(IXUIButton btn)
		{
			ulong id = btn.ID;
			XWeddingDocument specificDocument = XDocuments.GetSpecificDocument<XWeddingDocument>(XWeddingDocument.uuID);
			bool flag = this.m_SelectedTab == 0;
			if (flag)
			{
				specificDocument.EnterWedding(id);
			}
			else
			{
				specificDocument.WeddingInviteOperate(WeddingInviteOperType.Wedding_Apply, XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, id);
				this.UpdateApplyBtnState(btn);
			}
			return true;
		}

		// Token: 0x06010959 RID: 67929 RVA: 0x0041663C File Offset: 0x0041483C
		public void UpdateApplyBtnState(IXUIButton btn)
		{
			GameObject gameObject = btn.gameObject.transform.parent.parent.FindChild("Bg2").gameObject;
			gameObject.SetActive(true);
			btn.gameObject.transform.parent.gameObject.SetActive(false);
		}

		// Token: 0x0601095A RID: 67930 RVA: 0x00416694 File Offset: 0x00414894
		private bool OnGoApplyTabClicked(IXUIButton btn)
		{
			base.uiBehaviour.m_ToggleApply.bChecked = true;
			return true;
		}

		// Token: 0x0601095B RID: 67931 RVA: 0x004166BC File Offset: 0x004148BC
		private bool _OnCloseClicked(IXUIButton iSp)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0601095C RID: 67932 RVA: 0x004166D8 File Offset: 0x004148D8
		private bool _OnToggleChanged(IXUICheckBox go)
		{
			bool flag = !go.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_SelectedTab = (int)go.ID;
				base.uiBehaviour.m_Title.SetText((this.m_SelectedTab == 0) ? XStringDefineProxy.GetString("WeddingEnterApplyTab1") : XStringDefineProxy.GetString("WeddingEnterApplyTab2"));
				XWeddingDocument specificDocument = XDocuments.GetSpecificDocument<XWeddingDocument>(XWeddingDocument.uuID);
				specificDocument.GetAllWeddingInfo();
				result = true;
			}
			return result;
		}

		// Token: 0x0400785E RID: 30814
		private int m_SelectedTab = -1;

		// Token: 0x0400785F RID: 30815
		private uint _CDToken = 0U;

		// Token: 0x04007860 RID: 30816
		private List<IXUILabel> m_TimeLabelList = new List<IXUILabel>();

		// Token: 0x04007861 RID: 30817
		private List<ulong> m_TimeInvID = new List<ulong>();

		// Token: 0x04007862 RID: 30818
		private Dictionary<ulong, uint> m_TimeDic = new Dictionary<ulong, uint>();
	}
}
