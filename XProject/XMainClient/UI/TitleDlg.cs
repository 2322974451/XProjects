using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001869 RID: 6249
	public class TitleDlg : DlgBase<TitleDlg, TitleDlgBehaviour>
	{
		// Token: 0x170039A3 RID: 14755
		// (get) Token: 0x0601044E RID: 66638 RVA: 0x003EFC1C File Offset: 0x003EDE1C
		public override string fileName
		{
			get
			{
				return "GameSystem/TitleDlg";
			}
		}

		// Token: 0x170039A4 RID: 14756
		// (get) Token: 0x0601044F RID: 66639 RVA: 0x003EFC34 File Offset: 0x003EDE34
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Title);
			}
		}

		// Token: 0x170039A5 RID: 14757
		// (get) Token: 0x06010450 RID: 66640 RVA: 0x003EFC50 File Offset: 0x003EDE50
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170039A6 RID: 14758
		// (get) Token: 0x06010451 RID: 66641 RVA: 0x003EFC64 File Offset: 0x003EDE64
		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170039A7 RID: 14759
		// (get) Token: 0x06010452 RID: 66642 RVA: 0x003EFC78 File Offset: 0x003EDE78
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010453 RID: 66643 RVA: 0x003EFC8B File Offset: 0x003EDE8B
		protected override void OnLoad()
		{
			base.OnLoad();
			this.m_titleDisplay = new List<TitleItemDisplay>();
		}

		// Token: 0x06010454 RID: 66644 RVA: 0x003EFCA0 File Offset: 0x003EDEA0
		protected override void OnUnload()
		{
			this._Doc.TitleView = null;
			bool flag = this.m_titleDisplay != null;
			if (flag)
			{
				this.m_titleDisplay.Clear();
				this.m_titleDisplay = null;
			}
			bool flag2 = base.uiBehaviour != null;
			if (flag2)
			{
				base.uiBehaviour.m_CurrentTitle.Reset();
				base.uiBehaviour.m_NextTitle.Reset();
			}
			base.OnUnload();
		}

		// Token: 0x06010455 RID: 66645 RVA: 0x003EFD18 File Offset: 0x003EDF18
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XTitleDocument>(XTitleDocument.uuID);
			this._Doc.TitleView = this;
			this.m_leftPos = base.uiBehaviour.m_CurrentTitle.transform.localPosition;
			this.m_rightPos = base.uiBehaviour.m_NextTitle.transform.localPosition;
			this.m_middlePos = new Vector3(0f, this.m_leftPos.y, this.m_leftPos.z);
		}

		// Token: 0x06010456 RID: 66646 RVA: 0x003EFDA8 File Offset: 0x003EDFA8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickClose));
			base.uiBehaviour.m_Promote.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickPromote));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickHelp));
		}

		// Token: 0x06010457 RID: 66647 RVA: 0x003EFE14 File Offset: 0x003EE014
		private bool ClickHelp(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Title);
			return true;
		}

		// Token: 0x06010458 RID: 66648 RVA: 0x003EFE34 File Offset: 0x003EE034
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshTitleDisplay();
		}

		// Token: 0x06010459 RID: 66649 RVA: 0x003EFE45 File Offset: 0x003EE045
		public void Refresh()
		{
			this.RefreshTitleDisplay();
		}

		// Token: 0x0601045A RID: 66650 RVA: 0x003EFE4F File Offset: 0x003EE04F
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.Refresh();
		}

		// Token: 0x0601045B RID: 66651 RVA: 0x003EFE60 File Offset: 0x003EE060
		private bool ClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		// Token: 0x0601045C RID: 66652 RVA: 0x003EFE7C File Offset: 0x003EE07C
		private void RefreshTitleDisplay()
		{
			base.uiBehaviour.m_CurrentTitle.Set(this._Doc.CurrentTitle);
			base.uiBehaviour.m_NextTitle.Set(this._Doc.NextTitle);
			this.SetNextInfo(this._Doc.NextTitle);
			base.uiBehaviour.m_CurrentTitle.transform.localPosition = (this._Doc.IsMax ? this.m_middlePos : this.m_leftPos);
			base.uiBehaviour.m_point.SetActive(!this._Doc.IsMax);
			base.uiBehaviour.m_Promote.SetEnable(this._Doc.bEnableTitleLevelUp, false);
			base.uiBehaviour.m_redPoint.SetAlpha((float)(this._Doc.bEnableTitleLevelUp ? 1 : 0));
		}

		// Token: 0x0601045D RID: 66653 RVA: 0x003EFF64 File Offset: 0x003EE164
		private void SetNextInfo(TitleTable.RowData rowData)
		{
			bool flag = rowData == null;
			if (flag)
			{
				this.ResetActive();
				base.uiBehaviour.m_MaxTitle.SetActive(true);
			}
			else
			{
				int i = this.m_titleDisplay.Count;
				int num = 1 + rowData.NeedItem.Count;
				bool flag2 = i != num;
				while (i < num)
				{
					GameObject gameObject = XCommon.Instantiate<GameObject>(base.uiBehaviour.m_ItemTpl);
					gameObject.name = XSingleton<XCommon>.singleton.StringCombine("item_", i.ToString());
					gameObject.transform.parent = base.uiBehaviour.m_ScrollView.gameObject.transform;
					gameObject.transform.localPosition = new Vector3(0f, (float)(-35 * i), 0f);
					gameObject.transform.localScale = Vector3.one;
					TitleItemDisplay titleItemDisplay = new TitleItemDisplay();
					titleItemDisplay.Init(gameObject.transform);
					this.m_titleDisplay.Add(titleItemDisplay);
					i++;
				}
				for (int j = 0; j < i; j++)
				{
					bool flag3 = j == 0;
					if (flag3)
					{
						this.m_titleDisplay[j].SetVisible(true);
						this.m_titleDisplay[j].Set(0U, rowData.NeedPowerPoint, rowData.desc);
					}
					else
					{
						bool flag4 = j < num;
						if (flag4)
						{
							this.m_titleDisplay[j].SetVisible(true);
							this.m_titleDisplay[j].Set(rowData.NeedItem[j - 1, 0], rowData.NeedItem[j - 1, 1], rowData.desc);
						}
						else
						{
							this.m_titleDisplay[j].SetVisible(false);
						}
					}
				}
				bool flag5 = flag2;
				if (flag5)
				{
					base.uiBehaviour.m_ScrollView.ResetPosition();
				}
				base.uiBehaviour.m_MaxTitle.SetActive(false);
			}
		}

		// Token: 0x0601045E RID: 66654 RVA: 0x003F0178 File Offset: 0x003EE378
		private void ResetActive()
		{
			bool flag = this.m_titleDisplay != null && this.m_titleDisplay.Count > 0;
			if (flag)
			{
				int count = this.m_titleDisplay.Count;
				for (int i = 0; i < count; i++)
				{
					this.m_titleDisplay[i].SetVisible(false);
				}
			}
		}

		// Token: 0x0601045F RID: 66655 RVA: 0x003F01D8 File Offset: 0x003EE3D8
		private bool ClickPromote(IXUIButton btn)
		{
			this._Doc.GetTitleLevelUp();
			return false;
		}

		// Token: 0x040074F8 RID: 29944
		private XTitleDocument _Doc;

		// Token: 0x040074F9 RID: 29945
		private List<TitleItemDisplay> m_titleDisplay;

		// Token: 0x040074FA RID: 29946
		private Vector3 m_leftPos;

		// Token: 0x040074FB RID: 29947
		private Vector3 m_rightPos;

		// Token: 0x040074FC RID: 29948
		private Vector3 m_middlePos;
	}
}
