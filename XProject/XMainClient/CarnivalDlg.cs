using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BB7 RID: 2999
	internal class CarnivalDlg : DlgBase<CarnivalDlg, CarnivalBehavior>
	{
		// Token: 0x17003057 RID: 12375
		// (get) Token: 0x0600ABA6 RID: 43942 RVA: 0x001F6774 File Offset: 0x001F4974
		public XCarnivalDocument doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XCarnivalDocument>(XCarnivalDocument.uuID);
			}
		}

		// Token: 0x17003058 RID: 12376
		// (get) Token: 0x0600ABA7 RID: 43943 RVA: 0x001F6790 File Offset: 0x001F4990
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003059 RID: 12377
		// (get) Token: 0x0600ABA8 RID: 43944 RVA: 0x001F67A4 File Offset: 0x001F49A4
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Carnival);
			}
		}

		// Token: 0x1700305A RID: 12378
		// (get) Token: 0x0600ABA9 RID: 43945 RVA: 0x001F67C0 File Offset: 0x001F49C0
		public override string fileName
		{
			get
			{
				return "GameSystem/CarnivalDlg";
			}
		}

		// Token: 0x0600ABAA RID: 43946 RVA: 0x001F67D8 File Offset: 0x001F49D8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			for (int i = 0; i <= 6; i++)
			{
				base.uiBehaviour._tabs[i].ID = (ulong)((long)(i + 1));
				base.uiBehaviour._tabs[i].RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClick));
			}
			base.uiBehaviour._close.RegisterClickEventHandler(new ButtonClickEventHandler(this.Close));
		}

		// Token: 0x0600ABAB RID: 43947 RVA: 0x001F6855 File Offset: 0x001F4A55
		protected override void OnLoad()
		{
			base.OnLoad();
			DlgHandlerBase.EnsureCreate<CarnivalRwdHander>(ref this._rwdHander, base.uiBehaviour._rwdPanel, this, true);
			DlgHandlerBase.EnsureCreate<CarnivalContentHander>(ref this._contentHander, base.uiBehaviour._contentPanel, this, true);
		}

		// Token: 0x0600ABAC RID: 43948 RVA: 0x001F6891 File Offset: 0x001F4A91
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<CarnivalContentHander>(ref this._contentHander);
			DlgHandlerBase.EnsureUnload<CarnivalRwdHander>(ref this._rwdHander);
			base.OnUnload();
		}

		// Token: 0x0600ABAD RID: 43949 RVA: 0x001F68B3 File Offset: 0x001F4AB3
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshTabs();
			this.RefreshRedp();
			this.Refresh(CarnivalBelong.Rwd);
			this.RefreshTime();
		}

		// Token: 0x0600ABAE RID: 43950 RVA: 0x001F68DA File Offset: 0x001F4ADA
		protected override void OnHide()
		{
			this.doc.UpdateHallPoint(false);
			this._rwdHander.SetVisible(false);
			base.OnHide();
		}

		// Token: 0x0600ABAF RID: 43951 RVA: 0x001F6900 File Offset: 0x001F4B00
		private void RefreshTime()
		{
			XSingleton<XDebug>.singleton.AddLog("openday is: ", this.doc.openDay.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			bool flag = this.doc.openDay < this.doc.activityCloseDay - 1U;
			if (flag)
			{
				base.uiBehaviour._endLabel.SetText(XStringDefineProxy.GetString("CarnivalEnd", new object[]
				{
					this.doc.activityCloseDay - this.doc.openDay
				}));
			}
			else
			{
				bool flag2 = this.doc.activityCloseDay - this.doc.openDay == 1U;
				if (flag2)
				{
					base.uiBehaviour._endLabel.SetText(XStringDefineProxy.GetString("CarnivalLast"));
				}
				else
				{
					bool flag3 = this.doc.openDay < this.doc.claimCloseDay;
					if (flag3)
					{
						base.uiBehaviour._endLabel.SetText(XStringDefineProxy.GetString("CarnivalStop"));
					}
					else
					{
						base.uiBehaviour._endLabel.SetText(XStringDefineProxy.GetString("CarnivalTerminal"));
					}
				}
			}
		}

		// Token: 0x0600ABB0 RID: 43952 RVA: 0x001F6A28 File Offset: 0x001F4C28
		private bool OnTabClick(IXUICheckBox box)
		{
			ulong id = box.ID;
			bool flag = box.bChecked && (this.doc.currBelong == 0 || this.doc.currBelong != (int)id);
			if (flag)
			{
				this.doc.currBelong = (int)id;
				this.doc.currType = 1;
				CarnivalBelong currBelong = (CarnivalBelong)this.doc.currBelong;
				this.Refresh(currBelong);
			}
			return true;
		}

		// Token: 0x0600ABB1 RID: 43953 RVA: 0x001F6AA4 File Offset: 0x001F4CA4
		public void Refresh()
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this.RefreshTime();
				this.RefreshRedp();
				CarnivalBelong currBelong = (CarnivalBelong)this.doc.currBelong;
				bool flag2 = currBelong == CarnivalBelong.Rwd;
				if (flag2)
				{
					this._rwdHander.Refresh();
				}
				else
				{
					this._contentHander.RefreshList();
					this._contentHander.RefreshTab();
				}
			}
			this.RefreshHallRedp();
		}

		// Token: 0x0600ABB2 RID: 43954 RVA: 0x001F6B14 File Offset: 0x001F4D14
		private void Refresh(CarnivalBelong belong)
		{
			this._contentHander.SetVisible(belong != CarnivalBelong.Rwd);
			this._rwdHander.SetVisible(belong == CarnivalBelong.Rwd);
			bool flag = belong != CarnivalBelong.Rwd;
			if (flag)
			{
				this._contentHander.Refresh();
			}
			else
			{
				this._rwdHander.Refresh();
			}
		}

		// Token: 0x0600ABB3 RID: 43955 RVA: 0x001F6B70 File Offset: 0x001F4D70
		private void RefreshTabs()
		{
			for (int i = 0; i < 6; i++)
			{
				SuperActivity.RowData superActivity = this.doc.GetSuperActivity(i + 1);
				base.uiBehaviour._tabs[i].SetEnable(superActivity.offset <= this.doc.openDay);
				bool flag = base.uiBehaviour._lock[i] != null;
				if (flag)
				{
					base.uiBehaviour._lock[i].gameObject.SetActive(superActivity.offset > this.doc.openDay);
					IXUISprite ixuisprite = base.uiBehaviour._lock[i].GetComponent("XUISprite") as IXUISprite;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnLockTip));
				}
			}
			base.uiBehaviour._tabs[6].bChecked = true;
		}

		// Token: 0x0600ABB4 RID: 43956 RVA: 0x001F6C58 File Offset: 0x001F4E58
		private void OnLockTip(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CarnivalLock"), "fece00");
		}

		// Token: 0x0600ABB5 RID: 43957 RVA: 0x001F6C78 File Offset: 0x001F4E78
		private void RefreshRedp()
		{
			for (int i = 0; i < 6; i++)
			{
				bool flag = this.doc.HasRwdClaimed(i + 1);
				SuperActivity.RowData superActivity = this.doc.GetSuperActivity(i + 1);
				base.uiBehaviour._redpoint[i].SetActive(flag && superActivity.offset <= this.doc.openDay && !this.doc.IsActivityExpire());
			}
			uint needPoint = this.doc.needPoint;
			bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag2)
			{
				uint point = XSingleton<XAttributeMgr>.singleton.XPlayerData.point;
				bool flag3 = !XSingleton<XAttributeMgr>.singleton.XPlayerData.CarnivalClaimed;
				base.uiBehaviour._redpoint[6].SetActive(needPoint <= point && flag3 && !this.doc.IsActivityClosed());
			}
		}

		// Token: 0x0600ABB6 RID: 43958 RVA: 0x001F6D6C File Offset: 0x001F4F6C
		public void RefreshHallRedp()
		{
			bool bState = false;
			bool flag = !this.doc.IsActivityExpire();
			for (int i = 0; i < 6; i++)
			{
				bool flag2 = this.doc.HasRwdClaimed(i + 1);
				SuperActivity.RowData superActivity = this.doc.GetSuperActivity(i + 1);
				bool flag3 = flag2 && superActivity.offset <= this.doc.openDay && flag;
				if (flag3)
				{
					bState = true;
					break;
				}
			}
			uint needPoint = this.doc.needPoint;
			bool flag4 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag4)
			{
				uint point = XSingleton<XAttributeMgr>.singleton.XPlayerData.point;
				bool flag5 = !XSingleton<XAttributeMgr>.singleton.XPlayerData.CarnivalClaimed;
				bool flag6 = needPoint < point && flag5 && !this.doc.IsActivityClosed();
				if (flag6)
				{
					bState = true;
				}
			}
			XSingleton<XGameSysMgr>.singleton.SetSysRedState(XSysDefine.XSys_Carnival, bState);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Carnival, true);
		}

		// Token: 0x0600ABB7 RID: 43959 RVA: 0x001F6E70 File Offset: 0x001F5070
		private bool Close(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x04004076 RID: 16502
		public const int SYS_CNT = 6;

		// Token: 0x04004077 RID: 16503
		public CarnivalContentHander _contentHander;

		// Token: 0x04004078 RID: 16504
		public CarnivalRwdHander _rwdHander;
	}
}
