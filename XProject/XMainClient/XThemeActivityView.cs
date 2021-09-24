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

	internal class XThemeActivityView : DlgBase<XThemeActivityView, XThemeActivityBehaviour>
	{

		private XThemeActivityDocument doc
		{
			get
			{
				return XThemeActivityDocument.Doc;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/ThemeActivity/ThemeActivityDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<BiochemicalHellDogFrameHandler>(ref this.m_HellDogHandler);
			DlgHandlerBase.EnsureUnload<MadDuckSiegeFrameHandler>(ref this.m_MadDuckHandler);
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			this.doc.View = this;
		}

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

		public override int[] GetTitanBarItems()
		{
			return this.GetTitan();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshTabs(this.m_selectSys);
		}

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

		public void ShowPrefab(XSysDefine sys = XSysDefine.XSys_None)
		{
			bool flag = base.IsVisible();
			if (!flag)
			{
				this.m_selectSys = sys;
				this.SetVisibleWithAnimation(true, null);
			}
		}

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

		public bool OnTabClicked(IXUICheckBox checkbox)
		{
			bool flag = !checkbox.bChecked;
			return !flag && this.RefreshUI((XSysDefine)checkbox.ID);
		}

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

		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

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

		private XSysDefine m_selectSys = XSysDefine.XSys_None;

		private DlgHandlerBase m_CurrHandler;

		public BiochemicalHellDogFrameHandler m_HellDogHandler;

		public MadDuckSiegeFrameHandler m_MadDuckHandler;

		public bool debug = false;

		private Dictionary<XSysDefine, IXUICheckBox> m_TabsDic = new Dictionary<XSysDefine, IXUICheckBox>();
	}
}
