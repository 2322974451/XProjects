using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionHairToolTipDlg : TooltipDlg<FashionHairToolTipDlg, FashionHairToolTipBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/FashionHairToolToolDlg";
			}
		}

		public override bool HideToolTip(bool forceHide = false)
		{
			return base.HideToolTip(forceHide);
		}

		protected override void Init()
		{
			base.Init();
			this.m_OperateList[0, 0] = new TooltipButtonOperateRecycle(XSysDefine.XSys_Fashion_Fashion);
			this.m_OperateList[0, 1] = new TooltipButtonOperateSell();
			this.m_OperateList[0, 2] = new TooltipButtonActivateFashion();
			this._doc = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
		}

		protected override void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			base.SetupTopFrame(goToolTip, data, bMain, instanceData, compareData);
			base._SetupLevel(goToolTip, data, 0);
			base._SetupProf(goToolTip, data, bMain, instanceData, 1);
			FashionList.RowData fashionConf = XBagDocument.GetFashionConf(data.ItemID);
			base._SetTopFrameLabel(goToolTip, 2, XStringDefineProxy.GetString("ToolTipText_Part"), (fashionConf != null) ? XSingleton<UiUtility>.singleton.GetFashionPartName((FashionPosition)fashionConf.EquipPos, true) : string.Empty);
			this.time = (goToolTip.transform.FindChild("TopFrame/Time/Left").GetComponent("XUILabel") as IXUILabel);
			ClientFashionData clientFashionData = this._doc.FindFashion(this.mainItemUID);
			ItemList.RowData itemConf = XBagDocument.GetItemConf(data.ItemID);
			bool flag = itemConf != null;
			if (flag)
			{
				bool flag2 = itemConf.TimeLimit == 0U;
				if (flag2)
				{
					this.time.SetText(XStringDefineProxy.GetString("FASHION_LIMIT_ALWAYS"));
				}
				else
				{
					bool flag3 = clientFashionData == null;
					if (flag3)
					{
						this.time.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)itemConf.TimeLimit, 5) + XStringDefineProxy.GetString("FASHION_LIMIT_UNWEAR"));
					}
					else
					{
						bool flag4 = clientFashionData.timeleft < 0.0;
						if (flag4)
						{
							this.time.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)itemConf.TimeLimit, 5) + XStringDefineProxy.GetString("FASHION_LIMIT_UNWEAR"));
						}
						else
						{
							this.time.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)itemConf.TimeLimit, 5));
						}
					}
				}
			}
		}

		protected override void SetAllAttrFrames(GameObject goToolTip, XAttrItem item, XAttrItem compareItem, bool bMain)
		{
		}

		protected override void SetupOtherFrame(GameObject goToolTip, XItem item, XItem compareItem, bool bMain)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(item.itemID);
			this._SetupDescription(goToolTip, itemConf);
		}

		protected override void SetupOtherFrame(GameObject goToolTip, ItemList.RowData data)
		{
			this._SetupDescription(goToolTip, data);
		}

		protected void _SetupDescription(GameObject goToolTip, ItemList.RowData data)
		{
			Transform transform = goToolTip.transform;
			IXUISprite ixuisprite = transform.FindChild("ScrollPanel/Description").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = ixuisprite.gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
			bool flag = data == null;
			if (flag)
			{
				ixuilabel.SetText("");
			}
			else
			{
				ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(data.ItemDescription));
			}
			ixuisprite.spriteHeight = ixuilabel.spriteHeight + -(int)ixuilabel.gameObject.transform.localPosition.y;
			this.totalFrameHeight += (float)ixuisprite.spriteHeight;
		}

		protected override void SetupToolTipButtons(GameObject goToolTip, XItem item, bool bMain)
		{
			base.SetupToolTipButtons(goToolTip, item, bMain);
			bool flag = !this.bShowButtons;
			if (!flag)
			{
				if (bMain)
				{
					base._SetupButtonVisiability(goToolTip, 0, item);
				}
			}
		}

		public override void OnUpdate()
		{
			ClientFashionData clientFashionData = this._doc.FindFashion(this.mainItemUID);
			bool flag = clientFashionData != null && clientFashionData.timeleft > 0.0;
			if (flag)
			{
				bool flag2 = this.time != null;
				if (flag2)
				{
					this.time.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)clientFashionData.timeleft, 5));
				}
			}
		}

		private XFashionDocument _doc;

		private IXUILabel time;
	}
}
