using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class AttrTooltipDlg : TooltipDlg<AttrTooltipDlg, AttrTooltipDlgBehaviour>
	{

		private IAttrTooltipDlgHandler CurrentTooltipDlgHandler
		{
			set
			{
				this._PreviousTooltipDlgHandler = this._CurrentTooltipDlgHandler;
				this._CurrentTooltipDlgHandler = value;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/AttrToolTipDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
		}

		public override bool HideToolTip(bool forceHide = false)
		{
			bool flag = base.HideToolTip(forceHide);
			if (flag)
			{
				base.uiBehaviour.m_EmblemPartPool.ReturnAll(false);
				base.uiBehaviour.m_JadePartPool.ReturnAll(false);
				bool flag2 = this._CurrentTooltipDlgHandler != null;
				if (flag2)
				{
					this._CurrentTooltipDlgHandler.HideToolTip(forceHide);
				}
				bool flag3 = this._PreviousTooltipDlgHandler != null;
				if (flag3)
				{
					this._PreviousTooltipDlgHandler.HideToolTip(forceHide);
				}
			}
			return true;
		}

		public override IXUISprite ShowToolTip(XItem mainItem, XItem compareItem, bool bShowButtons, uint profession = 0U)
		{
			bool flag = mainItem != null;
			if (flag)
			{
				ItemType type = mainItem.Type;
				this.CurrentTooltipDlgHandler = null;
			}
			return base.ShowToolTip(mainItem, compareItem, bShowButtons, profession);
		}

		protected override void SetAllAttrFrames(GameObject goToolTip, XAttrItem item, XAttrItem compareItem, bool bMain)
		{
			base.SetAllAttrFrames(goToolTip, item, compareItem, bMain);
		}

		protected override void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			base.SetupTopFrame(goToolTip, data, bMain, instanceData, compareData);
			IXUILabel ixuilabel = goToolTip.transform.FindChild("TopFrame/Type").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XSingleton<UiUtility>.singleton.GetItemTypeStr((int)data.ItemType));
			bool flag = this._CurrentTooltipDlgHandler != null;
			if (flag)
			{
				this._CurrentTooltipDlgHandler.SetupTopFrame(goToolTip, data, instanceData, compareData);
			}
		}

		protected override int _GetPPT(XItem item, bool bMain, ref string valueText)
		{
			bool flag = this._CurrentTooltipDlgHandler != null;
			int result;
			if (flag)
			{
				result = this._CurrentTooltipDlgHandler._GetPPT(item, bMain, ref valueText);
			}
			else
			{
				result = -1;
			}
			return result;
		}

		protected override string _PPTTitle
		{
			get
			{
				bool flag = this._CurrentTooltipDlgHandler != null;
				string ppttitle;
				if (flag)
				{
					ppttitle = this._CurrentTooltipDlgHandler._PPTTitle;
				}
				else
				{
					ppttitle = base._PPTTitle;
				}
				return ppttitle;
			}
		}

		protected override void SetupOtherFrame(GameObject goToolTip, XItem item, XItem compareItem, bool bMain)
		{
			base.SetupOtherFrame(goToolTip, item, compareItem, bMain);
			bool flag = this._CurrentTooltipDlgHandler != null;
			if (flag)
			{
				this._CurrentTooltipDlgHandler.SetupOtherFrame(goToolTip, item, compareItem, bMain);
			}
		}

		protected override void SetupToolTipButtons(GameObject goToolTip, XItem item, bool bMain)
		{
			base.SetupToolTipButtons(goToolTip, item, bMain);
			bool flag = this._CurrentTooltipDlgHandler != null;
			if (flag)
			{
				this._CurrentTooltipDlgHandler.SetupToolTipButtons(goToolTip, item, bMain);
			}
		}

		protected override bool OnButton1Clicked(IXUIButton button)
		{
			bool flag = this._CurrentTooltipDlgHandler != null;
			if (flag)
			{
				this._CurrentTooltipDlgHandler.OnButton1Clicked(button);
			}
			return base.OnButton1Clicked(button);
		}

		protected override bool OnButton2Clicked(IXUIButton button)
		{
			bool flag = this._CurrentTooltipDlgHandler != null;
			if (flag)
			{
				this._CurrentTooltipDlgHandler.OnButton2Clicked(button);
			}
			return base.OnButton2Clicked(button);
		}

		protected override bool OnButton3Clicked(IXUIButton button)
		{
			bool flag = this._CurrentTooltipDlgHandler != null;
			if (flag)
			{
				this._CurrentTooltipDlgHandler.OnButton3Clicked(button);
			}
			return base.OnButton3Clicked(button);
		}

		private IAttrTooltipDlgHandler _CurrentTooltipDlgHandler = null;

		private IAttrTooltipDlgHandler _PreviousTooltipDlgHandler = null;
	}
}
