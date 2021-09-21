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
	// Token: 0x02000A1A RID: 2586
	[Hotfix]
	internal class XBackFlowDlg : DlgBase<XBackFlowDlg, XBackFlowBehavior>
	{
		// Token: 0x17002EB5 RID: 11957
		// (get) Token: 0x06009E20 RID: 40480 RVA: 0x0019E0B8 File Offset: 0x0019C2B8
		public override string fileName
		{
			get
			{
				return "Hall/BackflowDlg";
			}
		}

		// Token: 0x17002EB6 RID: 11958
		// (get) Token: 0x06009E21 RID: 40481 RVA: 0x0019E0D0 File Offset: 0x0019C2D0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002EB7 RID: 11959
		// (get) Token: 0x06009E22 RID: 40482 RVA: 0x0019E0E4 File Offset: 0x0019C2E4
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002EB8 RID: 11960
		// (get) Token: 0x06009E23 RID: 40483 RVA: 0x0019E0F8 File Offset: 0x0019C2F8
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.Xsys_Backflow);
			}
		}

		// Token: 0x17002EB9 RID: 11961
		// (get) Token: 0x06009E24 RID: 40484 RVA: 0x0019E114 File Offset: 0x0019C314
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06009E25 RID: 40485 RVA: 0x0019E127 File Offset: 0x0019C327
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x06009E26 RID: 40486 RVA: 0x0019E131 File Offset: 0x0019C331
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x06009E27 RID: 40487 RVA: 0x0019E13C File Offset: 0x0019C33C
		protected override void OnUnload()
		{
			this.UnloadHandlers();
			bool flag = this._curHandler != null;
			if (flag)
			{
				this._curHandler.SetVisible(false);
			}
			this._curHandler = null;
			this._tabList.Clear();
			XBackFlowDocument.Doc.StopRefreshLeftTime();
			bool flag2 = this._backflowEffect != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._backflowEffect, true);
			}
			this._backflowEffect = null;
			base.OnUnload();
		}

		// Token: 0x06009E28 RID: 40488 RVA: 0x0019E1B8 File Offset: 0x0019C3B8
		protected override void Init()
		{
			base.Init();
			this._tabName2Sys = XSingleton<XGlobalConfig>.singleton.GetStringSeqList("XBackFlowTabName2Sys");
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDlg));
			this._endTime = (base.uiBehaviour.transform.Find("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			this._backflowEffect = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_huanyinghuigu", null, true);
			this._backflowEffect.SetActive(false);
		}

		// Token: 0x06009E29 RID: 40489 RVA: 0x0019E250 File Offset: 0x0019C450
		protected override void OnHide()
		{
			this._curShowSys = XSysDefine.XSys_None;
			this._tabList.Clear();
			bool flag = this._curHandler != null;
			if (flag)
			{
				this._curHandler.SetVisible(false);
			}
			this._curHandler = null;
			XBackFlowDocument.Doc.StopRefreshLeftTime();
			base.OnHide();
		}

		// Token: 0x06009E2A RID: 40490 RVA: 0x0019E2A4 File Offset: 0x0019C4A4
		protected override void OnShow()
		{
			base.OnShow();
			this.UpdateTabs();
			XBackFlowDocument.Doc.SendBackFlowActivityOperation(BackFlowActOp.BackFlowAct_TreasureData, 0U);
			this._backflowEffect.SetActive(false);
			bool firstShowBackFlowDlg = XBackFlowDocument.Doc.FirstShowBackFlowDlg;
			if (firstShowBackFlowDlg)
			{
				XBackFlowDocument.Doc.FirstShowBackFlowDlg = false;
				this.PlayBackFlowEffect();
			}
		}

		// Token: 0x06009E2B RID: 40491 RVA: 0x0019E2FC File Offset: 0x0019C4FC
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshHandler();
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(this._curShowSys, true);
			this.RefreshTabRedPoint(this._curShowSys, XBackFlowDocument.Doc.GetRedPointState(this._curShowSys));
		}

		// Token: 0x06009E2C RID: 40492 RVA: 0x0019E33C File Offset: 0x0019C53C
		public void ShowHandler(XSysDefine sys)
		{
			this._curShowSys = sys;
			this.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x06009E2D RID: 40493 RVA: 0x0019E34F File Offset: 0x0019C54F
		public void RefreshTabs(XSysDefine sys)
		{
			this._curShowSys = sys;
			this.UpdateTabs();
		}

		// Token: 0x06009E2E RID: 40494 RVA: 0x0019E360 File Offset: 0x0019C560
		public void RefreshTabRedPoint(XSysDefine sys, bool red)
		{
			for (int i = 0; i < this._tabList.Count; i++)
			{
				bool flag = this._tabList[i].ID == (ulong)((long)sys);
				if (flag)
				{
					GameObject gameObject = this._tabList[i].gameObject.transform.Find("RedPoint").gameObject;
					gameObject.SetActive(red);
				}
			}
		}

		// Token: 0x06009E2F RID: 40495 RVA: 0x0019E3D4 File Offset: 0x0019C5D4
		public void RefreshHandler()
		{
			bool flag = this._curHandler != null && this._curHandler.IsVisible();
			if (flag)
			{
				this._curHandler.RefreshData();
			}
		}

		// Token: 0x06009E30 RID: 40496 RVA: 0x0019E408 File Offset: 0x0019C608
		public void PlayDogEffect()
		{
			bool flag = this._welfareHandler != null && this._welfareHandler.IsVisible();
			if (flag)
			{
				this._welfareHandler.PlayDogEffect();
			}
		}

		// Token: 0x06009E31 RID: 40497 RVA: 0x0019E43C File Offset: 0x0019C63C
		public void PlayBackFlowEffect()
		{
			bool flag = this._backflowEffect != null;
			if (flag)
			{
				this._backflowEffect.SetActive(true);
				this._backflowEffect.Play(base.uiBehaviour.HandlersParent, Vector3.zero, Vector3.one, 1f, true, false);
			}
		}

		// Token: 0x06009E32 RID: 40498 RVA: 0x0019E490 File Offset: 0x0019C690
		public void RefreshLeftTime(uint leftTime)
		{
			bool flag = leftTime >= 1U;
			if (flag)
			{
				this._endTime.gameObject.SetActive(this._curShowSys != XSysDefine.XSys_BackFlowMall);
				bool flag2 = leftTime >= 43200U;
				if (flag2)
				{
					this._endTime.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)leftTime, 4));
				}
				else
				{
					this._endTime.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)leftTime, 5));
				}
			}
			else
			{
				this._endTime.gameObject.SetActive(false);
			}
		}

		// Token: 0x06009E33 RID: 40499 RVA: 0x0019E524 File Offset: 0x0019C724
		private void SetupHandlers(XSysDefine sys)
		{
			bool flag = this._curHandler != null;
			if (flag)
			{
				this._curHandler.SetVisible(false);
			}
			bool flag2 = XSingleton<XPandoraSDKDocument>.singleton.IsPandoraSDKTab(sys, "callBack");
			if (flag2)
			{
				this._curHandler = DlgHandlerBase.EnsureCreate<XBackFlowPandoraSDKHandler>(ref this.m_pandoraSDKHandler, base.uiBehaviour.HandlersParent, false, this);
				bool flag3 = this.m_pandoraSDKHandler != null;
				if (flag3)
				{
					this.m_pandoraSDKHandler.SetCurrSys(sys);
					this.m_pandoraSDKHandler.SetVisible(true);
				}
			}
			else
			{
				switch (sys)
				{
				case XSysDefine.Xsys_Backflow_LavishGift:
					this._curHandler = DlgHandlerBase.EnsureCreate<XBackFlowWelfareHandler>(ref this._welfareHandler, base.uiBehaviour.HandlersParent, true, this);
					return;
				case XSysDefine.Xsys_Backflow_Dailylogin:
				case XSysDefine.Xsys_Backflow_GiftBag:
				case XSysDefine.Xsys_Server_Two:
					break;
				case XSysDefine.Xsys_Backflow_NewServerReward:
					this._curHandler = DlgHandlerBase.EnsureCreate<XBackFlowServerHandler>(ref this._serverHandler, base.uiBehaviour.HandlersParent, true, this);
					return;
				case XSysDefine.Xsys_Backflow_LevelUp:
					this._curHandler = DlgHandlerBase.EnsureCreate<XBackFlowLevelUpHandler>(ref this._levelUpHandler, base.uiBehaviour.HandlersParent, true, this);
					return;
				case XSysDefine.Xsys_Backflow_Task:
					this._curHandler = DlgHandlerBase.EnsureCreate<XBackFlowTasksHandler>(ref this._taskHandler, base.uiBehaviour.HandlersParent, true, this);
					return;
				case XSysDefine.Xsys_Backflow_Target:
					this._curHandler = DlgHandlerBase.EnsureCreate<XBackFlowTargetHandler>(ref this._targetHandler, base.uiBehaviour.HandlersParent, true, this);
					return;
				case XSysDefine.Xsys_Backflow_Privilege:
					this._curHandler = DlgHandlerBase.EnsureCreate<XBackFlowPrivilegeHandler>(ref this._privilegeHandler, base.uiBehaviour.HandlersParent, true, this);
					return;
				default:
					if (sys == XSysDefine.XSys_BackFlowMall)
					{
						this._endTime.gameObject.SetActive(false);
						this._curHandler = DlgHandlerBase.EnsureCreate<XBackFlowMallHandler>(ref this._mallHandler, base.uiBehaviour.HandlersParent, true, this);
						return;
					}
					break;
				}
				XSingleton<XDebug>.singleton.AddErrorLog("No sys in backflow", null, null, null, null, null);
			}
		}

		// Token: 0x06009E34 RID: 40500 RVA: 0x0019E710 File Offset: 0x0019C910
		private void UnloadHandlers()
		{
			DlgHandlerBase.EnsureUnload<XBackFlowLevelUpHandler>(ref this._levelUpHandler);
			DlgHandlerBase.EnsureUnload<XBackFlowMallHandler>(ref this._mallHandler);
			DlgHandlerBase.EnsureUnload<XBackFlowWelfareHandler>(ref this._welfareHandler);
			DlgHandlerBase.EnsureUnload<XBackFlowTasksHandler>(ref this._taskHandler);
			DlgHandlerBase.EnsureUnload<XBackFlowTargetHandler>(ref this._targetHandler);
			DlgHandlerBase.EnsureUnload<XBackFlowPrivilegeHandler>(ref this._privilegeHandler);
			DlgHandlerBase.EnsureUnload<XBackFlowServerHandler>(ref this._serverHandler);
			DlgHandlerBase.EnsureUnload<XBackFlowPandoraSDKHandler>(ref this.m_pandoraSDKHandler);
			XSingleton<XPandoraSDKDocument>.singleton.ClosePandoraTabPanel("callBack");
		}

		// Token: 0x06009E35 RID: 40501 RVA: 0x0019E790 File Offset: 0x0019C990
		private void UpdateTabs()
		{
			this._tabList.Clear();
			base.uiBehaviour.TabItemPool.ReturnAll(false);
			List<XSysDefine> list = new List<XSysDefine>();
			bool flag = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.Xsys_Backflow_LevelUp);
			if (flag)
			{
				list.Add(XSysDefine.Xsys_Backflow_LevelUp);
			}
			bool flag2 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.Xsys_Backflow_Target);
			if (flag2)
			{
				list.Add(XSysDefine.Xsys_Backflow_Target);
			}
			bool flag3 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.Xsys_Backflow_Task);
			if (flag3)
			{
				list.Add(XSysDefine.Xsys_Backflow_Task);
			}
			bool flag4 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.Xsys_Backflow_LavishGift);
			if (flag4)
			{
				list.Add(XSysDefine.Xsys_Backflow_LavishGift);
			}
			bool flag5 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_BackFlowMall);
			if (flag5)
			{
				list.Add(XSysDefine.XSys_BackFlowMall);
			}
			bool flag6 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.Xsys_Backflow_Privilege);
			if (flag6)
			{
				list.Add(XSysDefine.Xsys_Backflow_Privilege);
			}
			bool flag7 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.Xsys_Backflow_NewServerReward);
			if (flag7)
			{
				list.Add(XSysDefine.Xsys_Backflow_NewServerReward);
			}
			bool flag8 = this._curShowSys == XSysDefine.XSys_None || (!list.Contains(this._curShowSys) && list.Count > 0 && !XSingleton<XPandoraSDKDocument>.singleton.IsPandoraSDKTab(this._curShowSys, "callBack"));
			if (flag8)
			{
				this._curShowSys = list[0];
			}
			for (int i = 0; i < list.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.TabItemPool.FetchGameObject(false);
				Vector3 tplPos = base.uiBehaviour.TabItemPool.TplPos;
				gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(i * base.uiBehaviour.TabItemPool.TplHeight), 0f);
				Transform transform = gameObject.transform.Find("Bg/RedPoint");
				transform.gameObject.SetActive(XBackFlowDocument.Doc.GetRedPointState(list[i]));
				IXUICheckBox ixuicheckBox = gameObject.transform.Find("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.ForceSetFlag(false);
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabChange));
				ixuicheckBox.ID = (ulong)((long)list[i]);
				this._tabList.Add(ixuicheckBox);
				for (int j = 0; j < (int)this._tabName2Sys.Count; j++)
				{
					bool flag9 = this._tabName2Sys[j, 1] == ixuicheckBox.ID.ToString();
					if (flag9)
					{
						IXUILabel ixuilabel = gameObject.transform.Find("Bg/TextLabel").GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel2 = gameObject.transform.Find("Bg/SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
						ixuilabel.SetText(this._tabName2Sys[j, 0]);
						ixuilabel2.SetText(this._tabName2Sys[j, 0]);
					}
				}
			}
			List<ActivityTabInfo> pandoraSDKTabListInfo = XSingleton<XPandoraSDKDocument>.singleton.GetPandoraSDKTabListInfo("callBack");
			bool flag10 = pandoraSDKTabListInfo != null;
			if (flag10)
			{
				for (int k = 0; k < pandoraSDKTabListInfo.Count; k++)
				{
					GameObject gameObject2 = base.uiBehaviour.TabItemPool.FetchGameObject(false);
					Vector3 tplPos2 = base.uiBehaviour.TabItemPool.TplPos;
					gameObject2.transform.localPosition = new Vector3(tplPos2.x, tplPos2.y - (float)(this._tabList.Count * base.uiBehaviour.TabItemPool.TplHeight), 0f);
					IXUICheckBox ixuicheckBox2 = gameObject2.transform.Find("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
					ixuicheckBox2.ForceSetFlag(false);
					ixuicheckBox2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabChange));
					ixuicheckBox2.ID = (ulong)((long)pandoraSDKTabListInfo[k].sysID);
					this._tabList.Add(ixuicheckBox2);
					IXUILabel ixuilabel3 = gameObject2.transform.Find("Bg/TextLabel").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel4 = gameObject2.transform.Find("Bg/SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
					ixuilabel3.SetText(pandoraSDKTabListInfo[k].tabName);
					ixuilabel4.SetText(pandoraSDKTabListInfo[k].tabName);
					GameObject gameObject3 = gameObject2.transform.Find("Bg/RedPoint").gameObject;
					gameObject3.SetActive(pandoraSDKTabListInfo[k].redPointShow);
				}
			}
			for (int l = 0; l < this._tabList.Count; l++)
			{
				bool flag11 = this._tabList[l].ID == (ulong)((long)this._curShowSys);
				if (flag11)
				{
					bool bChecked = this._tabList[l].bChecked;
					if (bChecked)
					{
						this.SetupHandlers(this._curShowSys);
					}
					else
					{
						this._tabList[l].bChecked = true;
					}
					break;
				}
			}
		}

		// Token: 0x06009E36 RID: 40502 RVA: 0x0019ED08 File Offset: 0x0019CF08
		private bool OnTabChange(IXUICheckBox iXUICheckBox)
		{
			bool bChecked = iXUICheckBox.bChecked;
			if (bChecked)
			{
				XSysDefine xsysDefine = (XSysDefine)iXUICheckBox.ID;
				this._curShowSys = xsysDefine;
				this.SetupHandlers(xsysDefine);
			}
			return true;
		}

		// Token: 0x06009E37 RID: 40503 RVA: 0x0019ED40 File Offset: 0x0019CF40
		private bool OnCloseDlg(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x04003806 RID: 14342
		private XBackFlowLevelUpHandler _levelUpHandler;

		// Token: 0x04003807 RID: 14343
		private XBackFlowMallHandler _mallHandler;

		// Token: 0x04003808 RID: 14344
		private XBackFlowWelfareHandler _welfareHandler;

		// Token: 0x04003809 RID: 14345
		private XBackFlowTasksHandler _taskHandler;

		// Token: 0x0400380A RID: 14346
		private XBackFlowTargetHandler _targetHandler;

		// Token: 0x0400380B RID: 14347
		private XBackFlowPrivilegeHandler _privilegeHandler;

		// Token: 0x0400380C RID: 14348
		private XBackFlowServerHandler _serverHandler;

		// Token: 0x0400380D RID: 14349
		private XBackFlowPandoraSDKHandler m_pandoraSDKHandler;

		// Token: 0x0400380E RID: 14350
		private XSysDefine _curShowSys = XSysDefine.XSys_None;

		// Token: 0x0400380F RID: 14351
		private SeqList<string> _tabName2Sys;

		// Token: 0x04003810 RID: 14352
		private List<IXUICheckBox> _tabList = new List<IXUICheckBox>();

		// Token: 0x04003811 RID: 14353
		private DlgHandlerBase _curHandler;

		// Token: 0x04003812 RID: 14354
		private XFx _backflowEffect;

		// Token: 0x04003813 RID: 14355
		private IXUILabel _endTime;
	}
}
