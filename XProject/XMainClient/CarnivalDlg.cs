using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class CarnivalDlg : DlgBase<CarnivalDlg, CarnivalBehavior>
	{

		public XCarnivalDocument doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XCarnivalDocument>(XCarnivalDocument.uuID);
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Carnival);
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/CarnivalDlg";
			}
		}

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

		protected override void OnLoad()
		{
			base.OnLoad();
			DlgHandlerBase.EnsureCreate<CarnivalRwdHander>(ref this._rwdHander, base.uiBehaviour._rwdPanel, this, true);
			DlgHandlerBase.EnsureCreate<CarnivalContentHander>(ref this._contentHander, base.uiBehaviour._contentPanel, this, true);
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<CarnivalContentHander>(ref this._contentHander);
			DlgHandlerBase.EnsureUnload<CarnivalRwdHander>(ref this._rwdHander);
			base.OnUnload();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshTabs();
			this.RefreshRedp();
			this.Refresh(CarnivalBelong.Rwd);
			this.RefreshTime();
		}

		protected override void OnHide()
		{
			this.doc.UpdateHallPoint(false);
			this._rwdHander.SetVisible(false);
			base.OnHide();
		}

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

		private void OnLockTip(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CarnivalLock"), "fece00");
		}

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

		private bool Close(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		public const int SYS_CNT = 6;

		public CarnivalContentHander _contentHander;

		public CarnivalRwdHander _rwdHander;
	}
}
