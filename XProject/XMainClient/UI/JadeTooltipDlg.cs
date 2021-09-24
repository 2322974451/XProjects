using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class JadeTooltipDlg : TooltipDlg<JadeTooltipDlg, TooltipDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/JadeToolTipDlg";
			}
		}

		public void ShowToolTip(XItem mainItem, XItem compareItem, uint slot, bool bShowButtons = true)
		{
			this._slot = slot;
			this.ShowToolTip(mainItem, compareItem, bShowButtons, 0U);
		}

		protected override void Init()
		{
			base.Init();
			this.m_OperateList[0, 0] = new TooltipButtonOperateJadeUpgrade();
			this.m_OperateList[0, 1] = new TooltipButtonOperateRecycle(XSysDefine.XSys_Item_Jade);
			this.m_OperateList[0, 2] = new TooltipButtonOperateSell();
		}

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

		protected override void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			base.SetupTopFrame(goToolTip, data, bMain, instanceData, compareData);
			base._SetupType(goToolTip, data, 0);
			base._SetupProf(goToolTip, data, bMain, instanceData, 2);
			XJadeDocument specificDocument = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
			uint jadeLevel = specificDocument.jadeTable.GetByJadeID((uint)data.ItemID).JadeLevel;
			base._SetTopFrameLabel(goToolTip, 1, XStringDefineProxy.GetString("ToolTipText_Level"), string.Format(XStringDefineProxy.GetString("JADE_LEVEL_LIMIT"), specificDocument.JadeMosaicLevel[(int)(jadeLevel - 1U)].ToString()));
		}

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

		private uint _slot = 0U;
	}
}
