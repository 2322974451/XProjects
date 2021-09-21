using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CA8 RID: 3240
	internal class XThemeActivityView : DlgBase<XThemeActivityView, XThemeActivityBehaviour>
	{
		// Token: 0x1700323B RID: 12859
		// (get) Token: 0x0600B673 RID: 46707 RVA: 0x00242CEC File Offset: 0x00240EEC
		private XThemeActivityDocument doc
		{
			get
			{
				return XThemeActivityDocument.Doc;
			}
		}

		// Token: 0x1700323C RID: 12860
		// (get) Token: 0x0600B674 RID: 46708 RVA: 0x00242D04 File Offset: 0x00240F04
		public override string fileName
		{
			get
			{
				return "GameSystem/ThemeActivity/ThemeActivityDlg";
			}
		}

		// Token: 0x1700323D RID: 12861
		// (get) Token: 0x0600B675 RID: 46709 RVA: 0x00242D1C File Offset: 0x00240F1C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700323E RID: 12862
		// (get) Token: 0x0600B676 RID: 46710 RVA: 0x00242D30 File Offset: 0x00240F30
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700323F RID: 12863
		// (get) Token: 0x0600B677 RID: 46711 RVA: 0x00242D44 File Offset: 0x00240F44
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003240 RID: 12864
		// (get) Token: 0x0600B678 RID: 46712 RVA: 0x00242D58 File Offset: 0x00240F58
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B679 RID: 46713 RVA: 0x00242D6B File Offset: 0x00240F6B
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600B67A RID: 46714 RVA: 0x00242D75 File Offset: 0x00240F75
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600B67B RID: 46715 RVA: 0x00242D9C File Offset: 0x00240F9C
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<BiochemicalHellDogFrameHandler>(ref this.m_HellDogHandler);
			DlgHandlerBase.EnsureUnload<MadDuckSiegeFrameHandler>(ref this.m_MadDuckHandler);
			base.OnUnload();
		}

		// Token: 0x0600B67C RID: 46716 RVA: 0x00242DBE File Offset: 0x00240FBE
		protected override void Init()
		{
			base.Init();
			this.doc.View = this;
		}

		// Token: 0x0600B67D RID: 46717 RVA: 0x00242DD8 File Offset: 0x00240FD8
		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this.m_TabsDic != null;
			if (flag)
			{
				foreach (KeyValuePair<XSysDefine, IXUICheckBox> keyValuePair in this.m_TabsDic)
				{
					bool flag2 = keyValuePair.Value != null;
					if (flag2)
					{
						keyValuePair.Value.ForceSetFlag(false);
					}
				}
			}
			bool flag3 = this.m_CurrHandler != null;
			if (flag3)
			{
				this.m_CurrHandler.SetVisible(false);
			}
			this.m_selectSys = XSysDefine.XSys_None;
			this.doc.RefreshRedPoints();
		}

		// Token: 0x0600B67E RID: 46718 RVA: 0x00242E8C File Offset: 0x0024108C
		public override int[] GetTitanBarItems()
		{
			return this.GetTitan();
		}

		// Token: 0x0600B67F RID: 46719 RVA: 0x00242EA4 File Offset: 0x002410A4
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshTabs(this.m_selectSys);
		}

		// Token: 0x0600B680 RID: 46720 RVA: 0x00242EBC File Offset: 0x002410BC
		public override void StackRefresh()
		{
			base.StackRefresh();
			bool flag = this.m_CurrHandler != null;
			if (flag)
			{
				this.m_CurrHandler.StackRefresh();
			}
			this.RefreshRedpoint();
		}

		// Token: 0x0600B681 RID: 46721 RVA: 0x00242EF4 File Offset: 0x002410F4
		public void RefreshChangeUI(List<uint> removeIds = null)
		{
			bool flag = removeIds != null;
			if (flag)
			{
				bool flag2 = removeIds.Contains((uint)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this.m_selectSys));
				if (flag2)
				{
					this.m_selectSys = XSysDefine.XSys_None;
				}
			}
			this.RefreshTabs(this.m_selectSys);
			ILuaEngine xluaEngine = XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine;
			xluaEngine.hotfixMgr.TryFixRefresh(HotfixMode.AFTER, base.luaFileName, base.uiBehaviour.gameObject);
		}

		// Token: 0x0600B682 RID: 46722 RVA: 0x00242F60 File Offset: 0x00241160
		public void ShowPrefab(XSysDefine sys = XSysDefine.XSys_None)
		{
			bool flag = base.IsVisible();
			if (!flag)
			{
				this.m_selectSys = sys;
				this.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x0600B683 RID: 46723 RVA: 0x00242F8C File Offset: 0x0024118C
		private void RefreshTabs(XSysDefine system)
		{
			this.m_TabsDic.Clear();
			List<XSysDefine> list = new List<XSysDefine>();
			base.uiBehaviour.m_TabPool.FakeReturnAll();
			int num = 0;
			for (int i = 0; i < XThemeActivityDocument.ThemeActivityTable.Table.Length; i++)
			{
				ThemeActivity.RowData rowData = XThemeActivityDocument.ThemeActivityTable.Table[i];
				XSysDefine sysID = (XSysDefine)rowData.SysID;
				bool flag = this.debug || this.doc.SysIsOpen(sysID);
				if (flag)
				{
					list.Add(sysID);
					GameObject gameObject = base.uiBehaviour.m_TabPool.FetchGameObject(false);
					gameObject.transform.parent = base.uiBehaviour.m_tabParent;
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)base.uiBehaviour.m_TabPool.TplHeight * num), 0f);
					IXUICheckBox ixuicheckBox = gameObject.transform.FindChild("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
					ixuicheckBox.ID = (ulong)rowData.SysID;
					this.InitTabInfo(ixuicheckBox.gameObject, rowData.TabName, rowData.TabIcon);
					ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClicked));
					ixuicheckBox.ForceSetFlag(false);
					this.m_TabsDic.Add(sysID, ixuicheckBox);
					num++;
				}
			}
			base.uiBehaviour.m_TabPool.ActualReturnAll(false);
			this.SelectDefaultTab(list, system);
			this.RefreshRedpoint();
		}

		// Token: 0x0600B684 RID: 46724 RVA: 0x00243130 File Offset: 0x00241330
		private void InitTabInfo(GameObject tab, string tabName, string tabIcon)
		{
			IXUILabel ixuilabel = tab.transform.Find("TextLabel").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = tab.transform.Find("SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
			GameObject gameObject = tab.transform.Find("RedPoint").gameObject;
			IXUISprite ixuisprite = tab.transform.Find("P").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = tab.transform.Find("Selected/P").GetComponent("XUISprite") as IXUISprite;
			ixuilabel.SetText(tabName);
			ixuilabel2.SetText(tabName);
			gameObject.SetActive(false);
			ixuisprite.SetSprite(tabIcon);
			ixuisprite2.SetSprite(tabIcon);
		}

		// Token: 0x0600B685 RID: 46725 RVA: 0x00243200 File Offset: 0x00241400
		private void SelectDefaultTab(List<XSysDefine> listOpen, XSysDefine sys)
		{
			bool flag = this.m_TabsDic.ContainsKey(sys);
			if (flag)
			{
				this.m_TabsDic[sys].bChecked = true;
			}
			else
			{
				bool flag2 = sys == XSysDefine.XSys_None;
				if (flag2)
				{
					for (int i = 0; i < listOpen.Count; i++)
					{
						bool flag3 = !this.doc.GetTabRedPointState(listOpen[i]);
						if (!flag3)
						{
							this.m_TabsDic[listOpen[i]].bChecked = true;
							return;
						}
					}
				}
				bool flag4 = listOpen.Count > 0;
				if (flag4)
				{
					this.m_TabsDic[listOpen[0]].bChecked = true;
				}
			}
		}

		// Token: 0x0600B686 RID: 46726 RVA: 0x002432BC File Offset: 0x002414BC
		public void RefreshRedpoint()
		{
			foreach (KeyValuePair<XSysDefine, IXUICheckBox> keyValuePair in this.m_TabsDic)
			{
				bool flag = keyValuePair.Value.IsVisible();
				if (flag)
				{
					GameObject gameObject = keyValuePair.Value.gameObject.transform.Find("RedPoint").gameObject;
					gameObject.SetActive(this.doc.GetTabRedPointState(keyValuePair.Key));
				}
			}
		}

		// Token: 0x0600B687 RID: 46727 RVA: 0x0024335C File Offset: 0x0024155C
		private void SetupHandlers(XSysDefine sys)
		{
			this.m_selectSys = sys;
			SuperActivityTime.RowData dataBySystemID = XTempActivityDocument.Doc.GetDataBySystemID((uint)sys);
			bool sysFirstRedPoint = this.doc.GetSysFirstRedPoint(sys);
			if (sysFirstRedPoint)
			{
				this.doc.SendFirstHint(dataBySystemID.actid);
			}
			XSysDefine xsysDefine = sys;
			if (xsysDefine != XSysDefine.XSys_ThemeActivity_HellDog)
			{
				if (xsysDefine != XSysDefine.XSys_ThemeActivity_MadDuck)
				{
					this.m_CurrHandler = null;
					XSingleton<XDebug>.singleton.AddLog("System may be implemented in lua:", sys.ToString(), null, null, null, null, XDebugColor.XDebug_None);
					return;
				}
				this.m_CurrHandler = DlgHandlerBase.EnsureCreate<MadDuckSiegeFrameHandler>(ref this.m_MadDuckHandler, base.uiBehaviour.m_rightTra, false, this);
			}
			else
			{
				this.m_CurrHandler = DlgHandlerBase.EnsureCreate<BiochemicalHellDogFrameHandler>(ref this.m_HellDogHandler, base.uiBehaviour.m_rightTra, false, this);
			}
			DlgBase<TitanbarView, TitanBarBehaviour>.singleton.SetTitanItems(this.GetTitan());
		}

		// Token: 0x0600B688 RID: 46728 RVA: 0x00243434 File Offset: 0x00241634
		public bool OnTabClicked(IXUICheckBox checkbox)
		{
			bool flag = !checkbox.bChecked;
			return !flag && this.RefreshUI((XSysDefine)checkbox.ID);
		}

		// Token: 0x0600B689 RID: 46729 RVA: 0x00243464 File Offset: 0x00241664
		private bool RefreshUI(XSysDefine sys)
		{
			bool flag = this.m_CurrHandler != null;
			if (flag)
			{
				this.m_CurrHandler.SetVisible(false);
			}
			this.SetupHandlers(sys);
			bool flag2 = this.m_CurrHandler != null;
			if (flag2)
			{
				this.m_CurrHandler.SetVisible(true);
			}
			return true;
		}

		// Token: 0x0600B68A RID: 46730 RVA: 0x002434B8 File Offset: 0x002416B8
		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600B68B RID: 46731 RVA: 0x002434D4 File Offset: 0x002416D4
		public int[] GetTitan()
		{
			int[] result = null;
			XSysDefine selectSys = this.m_selectSys;
			if (selectSys == XSysDefine.XSys_ThemeActivity_MadDuck)
			{
				result = new int[]
				{
					int.Parse(MadDuckSiegeDocument.Doc.cost[0])
				};
			}
			return result;
		}

		// Token: 0x0400476D RID: 18285
		private XSysDefine m_selectSys = XSysDefine.XSys_None;

		// Token: 0x0400476E RID: 18286
		private DlgHandlerBase m_CurrHandler;

		// Token: 0x0400476F RID: 18287
		public BiochemicalHellDogFrameHandler m_HellDogHandler;

		// Token: 0x04004770 RID: 18288
		public MadDuckSiegeFrameHandler m_MadDuckHandler;

		// Token: 0x04004771 RID: 18289
		public bool debug = false;

		// Token: 0x04004772 RID: 18290
		private Dictionary<XSysDefine, IXUICheckBox> m_TabsDic = new Dictionary<XSysDefine, IXUICheckBox>();
	}
}
