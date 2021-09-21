using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200190B RID: 6411
	internal class JadeTooltipDlg : TooltipDlg<JadeTooltipDlg, TooltipDlgBehaviour>
	{
		// Token: 0x17003ACE RID: 15054
		// (get) Token: 0x06010C22 RID: 68642 RVA: 0x00433674 File Offset: 0x00431874
		public override string fileName
		{
			get
			{
				return "GameSystem/JadeToolTipDlg";
			}
		}

		// Token: 0x06010C23 RID: 68643 RVA: 0x0043368B File Offset: 0x0043188B
		public void ShowToolTip(XItem mainItem, XItem compareItem, uint slot, bool bShowButtons = true)
		{
			this._slot = slot;
			this.ShowToolTip(mainItem, compareItem, bShowButtons, 0U);
		}

		// Token: 0x06010C24 RID: 68644 RVA: 0x004336A4 File Offset: 0x004318A4
		protected override void Init()
		{
			base.Init();
			this.m_OperateList[0, 0] = new TooltipButtonOperateJadeUpgrade();
			this.m_OperateList[0, 1] = new TooltipButtonOperateRecycle(XSysDefine.XSys_Item_Jade);
			this.m_OperateList[0, 2] = new TooltipButtonOperateSell();
		}

		// Token: 0x06010C25 RID: 68645 RVA: 0x004336F4 File Offset: 0x004318F4
		protected override void SetupOtherFrame(GameObject goToolTip, XItem mainItem, XItem compareItem, bool bMain)
		{
			Transform transform = goToolTip.transform.FindChild("ScrollPanel");
			IXUISprite ixuisprite = transform.FindChild("Place").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = transform.FindChild("Description").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = transform.FindChild("Place/T").GetComponent("XUILabel") as IXUILabel;
			XJadeDocument specificDocument = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
			ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(specificDocument.jadeTable.GetByJadeID((uint)mainItem.itemID).MosaicPlace));
			ixuisprite.spriteHeight = -(int)ixuilabel.gameObject.transform.localPosition.y + ixuilabel.spriteHeight;
			base.AppendFrame(ixuisprite.gameObject, (float)ixuisprite.spriteHeight, null);
			base.AppendFrame(ixuisprite2.gameObject, (float)ixuisprite2.spriteHeight, null);
			base.SetupOtherFrame(goToolTip, mainItem, compareItem, bMain);
		}

		// Token: 0x06010C26 RID: 68646 RVA: 0x00433808 File Offset: 0x00431A08
		protected override void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			base.SetupTopFrame(goToolTip, data, bMain, instanceData, compareData);
			base._SetupType(goToolTip, data, 0);
			base._SetupProf(goToolTip, data, bMain, instanceData, 2);
			XJadeDocument specificDocument = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
			uint jadeLevel = specificDocument.jadeTable.GetByJadeID((uint)data.ItemID).JadeLevel;
			base._SetTopFrameLabel(goToolTip, 1, XStringDefineProxy.GetString("ToolTipText_Level"), string.Format(XStringDefineProxy.GetString("JADE_LEVEL_LIMIT"), specificDocument.JadeMosaicLevel[(int)(jadeLevel - 1U)].ToString()));
		}

		// Token: 0x06010C27 RID: 68647 RVA: 0x00433898 File Offset: 0x00431A98
		protected override int _GetPPT(XItem item, bool bMain, ref string valueText)
		{
			bool flag = item == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				uint ppt = item.GetPPT(bMain ? XSingleton<TooltipParam>.singleton.mainAttributes : XSingleton<TooltipParam>.singleton.compareAttributes);
				valueText = ppt.ToString();
				result = (int)ppt;
			}
			return result;
		}

		// Token: 0x06010C28 RID: 68648 RVA: 0x004338E0 File Offset: 0x00431AE0
		protected override void SetupToolTipButtons(GameObject goToolTip, XItem item, bool bMain)
		{
			base.SetupToolTipButtons(goToolTip, item, bMain);
			bool flag = !this.bShowButtons;
			if (!flag)
			{
				if (bMain)
				{
					bool flag2 = item.uid == 0UL;
					if (flag2)
					{
						base._SetupButtonVisiability(goToolTip, 1, item);
					}
					else
					{
						base._SetupButtonVisiability(goToolTip, 0, item);
					}
				}
			}
		}

		// Token: 0x04007ABE RID: 31422
		private uint _slot = 0U;
	}
}
