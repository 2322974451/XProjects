using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001907 RID: 6407
	internal class AttrTooltipDlg : TooltipDlg<AttrTooltipDlg, AttrTooltipDlgBehaviour>
	{
		// Token: 0x17003AC5 RID: 15045
		// (set) Token: 0x06010BA6 RID: 68518 RVA: 0x0042CD3D File Offset: 0x0042AF3D
		private IAttrTooltipDlgHandler CurrentTooltipDlgHandler
		{
			set
			{
				this._PreviousTooltipDlgHandler = this._CurrentTooltipDlgHandler;
				this._CurrentTooltipDlgHandler = value;
			}
		}

		// Token: 0x17003AC6 RID: 15046
		// (get) Token: 0x06010BA7 RID: 68519 RVA: 0x0042CD54 File Offset: 0x0042AF54
		public override string fileName
		{
			get
			{
				return "GameSystem/AttrToolTipDlg";
			}
		}

		// Token: 0x06010BA8 RID: 68520 RVA: 0x0042CD6B File Offset: 0x0042AF6B
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x06010BA9 RID: 68521 RVA: 0x0042CD78 File Offset: 0x0042AF78
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

		// Token: 0x06010BAA RID: 68522 RVA: 0x0042CDF0 File Offset: 0x0042AFF0
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

		// Token: 0x06010BAB RID: 68523 RVA: 0x0042CE2C File Offset: 0x0042B02C
		protected override void SetAllAttrFrames(GameObject goToolTip, XAttrItem item, XAttrItem compareItem, bool bMain)
		{
			base.SetAllAttrFrames(goToolTip, item, compareItem, bMain);
		}

		// Token: 0x06010BAC RID: 68524 RVA: 0x0042CE3C File Offset: 0x0042B03C
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

		// Token: 0x06010BAD RID: 68525 RVA: 0x0042CEB0 File Offset: 0x0042B0B0
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

		// Token: 0x17003AC7 RID: 15047
		// (get) Token: 0x06010BAE RID: 68526 RVA: 0x0042CEE4 File Offset: 0x0042B0E4
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

		// Token: 0x06010BAF RID: 68527 RVA: 0x0042CF18 File Offset: 0x0042B118
		protected override void SetupOtherFrame(GameObject goToolTip, XItem item, XItem compareItem, bool bMain)
		{
			base.SetupOtherFrame(goToolTip, item, compareItem, bMain);
			bool flag = this._CurrentTooltipDlgHandler != null;
			if (flag)
			{
				this._CurrentTooltipDlgHandler.SetupOtherFrame(goToolTip, item, compareItem, bMain);
			}
		}

		// Token: 0x06010BB0 RID: 68528 RVA: 0x0042CF50 File Offset: 0x0042B150
		protected override void SetupToolTipButtons(GameObject goToolTip, XItem item, bool bMain)
		{
			base.SetupToolTipButtons(goToolTip, item, bMain);
			bool flag = this._CurrentTooltipDlgHandler != null;
			if (flag)
			{
				this._CurrentTooltipDlgHandler.SetupToolTipButtons(goToolTip, item, bMain);
			}
		}

		// Token: 0x06010BB1 RID: 68529 RVA: 0x0042CF84 File Offset: 0x0042B184
		protected override bool OnButton1Clicked(IXUIButton button)
		{
			bool flag = this._CurrentTooltipDlgHandler != null;
			if (flag)
			{
				this._CurrentTooltipDlgHandler.OnButton1Clicked(button);
			}
			return base.OnButton1Clicked(button);
		}

		// Token: 0x06010BB2 RID: 68530 RVA: 0x0042CFB8 File Offset: 0x0042B1B8
		protected override bool OnButton2Clicked(IXUIButton button)
		{
			bool flag = this._CurrentTooltipDlgHandler != null;
			if (flag)
			{
				this._CurrentTooltipDlgHandler.OnButton2Clicked(button);
			}
			return base.OnButton2Clicked(button);
		}

		// Token: 0x06010BB3 RID: 68531 RVA: 0x0042CFEC File Offset: 0x0042B1EC
		protected override bool OnButton3Clicked(IXUIButton button)
		{
			bool flag = this._CurrentTooltipDlgHandler != null;
			if (flag)
			{
				this._CurrentTooltipDlgHandler.OnButton3Clicked(button);
			}
			return base.OnButton3Clicked(button);
		}

		// Token: 0x04007A4C RID: 31308
		private IAttrTooltipDlgHandler _CurrentTooltipDlgHandler = null;

		// Token: 0x04007A4D RID: 31309
		private IAttrTooltipDlgHandler _PreviousTooltipDlgHandler = null;
	}
}
