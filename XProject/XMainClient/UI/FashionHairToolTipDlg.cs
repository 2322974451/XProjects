using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017C0 RID: 6080
	internal class FashionHairToolTipDlg : TooltipDlg<FashionHairToolTipDlg, FashionHairToolTipBehaviour>
	{
		// Token: 0x1700388A RID: 14474
		// (get) Token: 0x0600FBC5 RID: 64453 RVA: 0x003A87EC File Offset: 0x003A69EC
		public override string fileName
		{
			get
			{
				return "GameSystem/FashionHairToolToolDlg";
			}
		}

		// Token: 0x0600FBC6 RID: 64454 RVA: 0x003A8804 File Offset: 0x003A6A04
		public override bool HideToolTip(bool forceHide = false)
		{
			return base.HideToolTip(forceHide);
		}

		// Token: 0x0600FBC7 RID: 64455 RVA: 0x003A8828 File Offset: 0x003A6A28
		protected override void Init()
		{
			base.Init();
			this.m_OperateList[0, 0] = new TooltipButtonOperateRecycle(XSysDefine.XSys_Fashion_Fashion);
			this.m_OperateList[0, 1] = new TooltipButtonOperateSell();
			this.m_OperateList[0, 2] = new TooltipButtonActivateFashion();
			this._doc = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
		}

		// Token: 0x0600FBC8 RID: 64456 RVA: 0x003A8888 File Offset: 0x003A6A88
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

		// Token: 0x0600FBC9 RID: 64457 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void SetAllAttrFrames(GameObject goToolTip, XAttrItem item, XAttrItem compareItem, bool bMain)
		{
		}

		// Token: 0x0600FBCA RID: 64458 RVA: 0x003A8A10 File Offset: 0x003A6C10
		protected override void SetupOtherFrame(GameObject goToolTip, XItem item, XItem compareItem, bool bMain)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(item.itemID);
			this._SetupDescription(goToolTip, itemConf);
		}

		// Token: 0x0600FBCB RID: 64459 RVA: 0x003A8A33 File Offset: 0x003A6C33
		protected override void SetupOtherFrame(GameObject goToolTip, ItemList.RowData data)
		{
			this._SetupDescription(goToolTip, data);
		}

		// Token: 0x0600FBCC RID: 64460 RVA: 0x003A8A40 File Offset: 0x003A6C40
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

		// Token: 0x0600FBCD RID: 64461 RVA: 0x003A8B00 File Offset: 0x003A6D00
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

		// Token: 0x0600FBCE RID: 64462 RVA: 0x003A8B38 File Offset: 0x003A6D38
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

		// Token: 0x04006E8F RID: 28303
		private XFashionDocument _doc;

		// Token: 0x04006E90 RID: 28304
		private IXUILabel time;
	}
}
