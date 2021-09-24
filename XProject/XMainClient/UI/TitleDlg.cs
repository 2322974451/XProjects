using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	public class TitleDlg : DlgBase<TitleDlg, TitleDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/TitleDlg";
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Title);
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			this.m_titleDisplay = new List<TitleItemDisplay>();
		}

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

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XTitleDocument>(XTitleDocument.uuID);
			this._Doc.TitleView = this;
			this.m_leftPos = base.uiBehaviour.m_CurrentTitle.transform.localPosition;
			this.m_rightPos = base.uiBehaviour.m_NextTitle.transform.localPosition;
			this.m_middlePos = new Vector3(0f, this.m_leftPos.y, this.m_leftPos.z);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickClose));
			base.uiBehaviour.m_Promote.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickPromote));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickHelp));
		}

		private bool ClickHelp(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Title);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshTitleDisplay();
		}

		public void Refresh()
		{
			this.RefreshTitleDisplay();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.Refresh();
		}

		private bool ClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

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

		private bool ClickPromote(IXUIButton btn)
		{
			this._Doc.GetTitleLevelUp();
			return false;
		}

		private XTitleDocument _Doc;

		private List<TitleItemDisplay> m_titleDisplay;

		private Vector3 m_leftPos;

		private Vector3 m_rightPos;

		private Vector3 m_middlePos;
	}
}
