using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class TaJieHelpDlg : DlgBase<TaJieHelpDlg, TaJieHelpBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/TajiebbDlg";
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
			base.uiBehaviour.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc = TaJieHelpDocument.Doc;
			base.uiBehaviour.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.FillContent();
		}

		private void FillContent()
		{
			this.m_tempData = this.m_doc.GetTaJieHelpData();
			base.uiBehaviour.m_wrapContent.SetContentCount(this.m_tempData.Count, false);
		}

		private void WrapContentItemUpdated(Transform t, int index)
		{
			TaJieHelpTab.RowData rowData = this.m_tempData[index];
			bool flag = rowData == null;
			if (!flag)
			{
				IXUISprite ixuisprite = t.FindChild("BQ").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.spriteName = rowData.IconName;
				IXUILabel ixuilabel = t.FindChild("Label1").GetComponent("XUILabel") as IXUILabel;
				string text = rowData.Name;
				bool flag2 = rowData.SysID == 0U;
				if (flag2)
				{
					text = this.m_doc.GetSceneName();
				}
				ixuilabel.SetText(text);
				ixuilabel = (t.FindChild("Label2").GetComponent("XUILabel") as IXUILabel);
				IXUILabel ixuilabel2 = t.FindChild("Label3").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.gameObject.SetActive(false);
				int curType = this.m_doc.CurType;
				bool flag3 = rowData.SysID == 0U && curType == 18;
				if (flag3)
				{
					ixuilabel.SetText(this.m_doc.GetdDragonTips());
				}
				else
				{
					ixuilabel.SetText(rowData.Des);
				}
				IXUIButton ixuibutton = t.FindChild("GO").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = (ulong)rowData.SysID;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoClick));
				ixuilabel = (t.FindChild("GO/MoneyCost").GetComponent("XUILabel") as IXUILabel);
				bool flag4 = rowData.SysID == 0U;
				if (flag4)
				{
					ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString("CheckTheStrategy"));
				}
				else
				{
					ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString("PVPActivity_Go"));
				}
			}
		}

		private bool OnCloseClicked(IXUIButton btn)
		{
			string label = XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("TaJieHelpTips4"));
			XSingleton<UiUtility>.singleton.ShowModalDialog(label, XSingleton<XStringTable>.singleton.GetString("CloseUp"), XSingleton<XStringTable>.singleton.GetString("PackUp"), new ButtonClickEventHandler(this.DoOK), new ButtonClickEventHandler(this.DoCancle), false, XTempTipDefine.OD_START, 50);
			return true;
		}

		private bool DoOK(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.SetVisible(false, true);
			this.m_doc.ShowHallBtn = false;
			return true;
		}

		private bool DoCancle(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.SetVisible(false, true);
			return true;
		}

		private bool OnGoClick(IXUIButton btn)
		{
			ulong id = btn.ID;
			bool flag = id == 0UL;
			if (flag)
			{
				string url = this.m_doc.GetUrl();
				bool flag2 = url != string.Empty;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.OpenUrl(url, false);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("NoStrategy"), "fece00");
				}
			}
			else
			{
				XSingleton<XGameSysMgr>.singleton.OpenSystem((int)id);
			}
			return true;
		}

		private TaJieHelpDocument m_doc;

		private List<TaJieHelpTab.RowData> m_tempData;
	}
}
