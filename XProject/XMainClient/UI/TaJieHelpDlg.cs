using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200180B RID: 6155
	internal class TaJieHelpDlg : DlgBase<TaJieHelpDlg, TaJieHelpBehaviour>
	{
		// Token: 0x170038F2 RID: 14578
		// (get) Token: 0x0600FF24 RID: 65316 RVA: 0x003C2168 File Offset: 0x003C0368
		public override string fileName
		{
			get
			{
				return "GameSystem/TajiebbDlg";
			}
		}

		// Token: 0x170038F3 RID: 14579
		// (get) Token: 0x0600FF25 RID: 65317 RVA: 0x003C2180 File Offset: 0x003C0380
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038F4 RID: 14580
		// (get) Token: 0x0600FF26 RID: 65318 RVA: 0x003C2194 File Offset: 0x003C0394
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038F5 RID: 14581
		// (get) Token: 0x0600FF27 RID: 65319 RVA: 0x003C21A8 File Offset: 0x003C03A8
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038F6 RID: 14582
		// (get) Token: 0x0600FF28 RID: 65320 RVA: 0x003C21BC File Offset: 0x003C03BC
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600FF29 RID: 65321 RVA: 0x003C21CF File Offset: 0x003C03CF
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600FF2A RID: 65322 RVA: 0x003C21D9 File Offset: 0x003C03D9
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600FF2B RID: 65323 RVA: 0x003C2200 File Offset: 0x003C0400
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600FF2C RID: 65324 RVA: 0x003C220A File Offset: 0x003C040A
		protected override void Init()
		{
			base.Init();
			this.m_doc = TaJieHelpDocument.Doc;
			base.uiBehaviour.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		// Token: 0x0600FF2D RID: 65325 RVA: 0x003C223C File Offset: 0x003C043C
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600FF2E RID: 65326 RVA: 0x003C2246 File Offset: 0x003C0446
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600FF2F RID: 65327 RVA: 0x003C2257 File Offset: 0x003C0457
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.FillContent();
		}

		// Token: 0x0600FF30 RID: 65328 RVA: 0x003C2268 File Offset: 0x003C0468
		private void FillContent()
		{
			this.m_tempData = this.m_doc.GetTaJieHelpData();
			base.uiBehaviour.m_wrapContent.SetContentCount(this.m_tempData.Count, false);
		}

		// Token: 0x0600FF31 RID: 65329 RVA: 0x003C229C File Offset: 0x003C049C
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

		// Token: 0x0600FF32 RID: 65330 RVA: 0x003C2458 File Offset: 0x003C0658
		private bool OnCloseClicked(IXUIButton btn)
		{
			string label = XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("TaJieHelpTips4"));
			XSingleton<UiUtility>.singleton.ShowModalDialog(label, XSingleton<XStringTable>.singleton.GetString("CloseUp"), XSingleton<XStringTable>.singleton.GetString("PackUp"), new ButtonClickEventHandler(this.DoOK), new ButtonClickEventHandler(this.DoCancle), false, XTempTipDefine.OD_START, 50);
			return true;
		}

		// Token: 0x0600FF33 RID: 65331 RVA: 0x003C24CC File Offset: 0x003C06CC
		private bool DoOK(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.SetVisible(false, true);
			this.m_doc.ShowHallBtn = false;
			return true;
		}

		// Token: 0x0600FF34 RID: 65332 RVA: 0x003C2500 File Offset: 0x003C0700
		private bool DoCancle(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600FF35 RID: 65333 RVA: 0x003C2528 File Offset: 0x003C0728
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

		// Token: 0x040070CB RID: 28875
		private TaJieHelpDocument m_doc;

		// Token: 0x040070CC RID: 28876
		private List<TaJieHelpTab.RowData> m_tempData;
	}
}
