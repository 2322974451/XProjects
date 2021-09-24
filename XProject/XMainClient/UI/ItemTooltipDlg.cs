using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ItemTooltipDlg : TooltipDlg<ItemTooltipDlg, ItemTooltipDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/ItemToolTipDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_OperateList[0, 0] = new TooltipButtonOperateItemUse();
			this.m_OperateList[0, 1] = new TooltipButtonOperateItemAny();
			this.m_OperateList[0, 2] = new TooltipButtonOperateRecycle(XSysDefine.XSys_Bag_Item);
			this.m_OperateList[0, 3] = new TooltipButtonOperateSell();
			this.m_OperateList[0, 4] = new TooltipButtonOperateCompose();
		}

		public void ShowToolTip(ulong MainUID, ulong CompareUID, bool bShowButtons = true)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(MainUID);
			XItem xitem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(CompareUID);
			bool flag = xitem.uid == 0UL;
			if (flag)
			{
				xitem = null;
			}
			this.ShowToolTip(itemByUID, xitem, bShowButtons, 0U);
		}

		protected override void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			base.SetupTopFrame(goToolTip, data, bMain, instanceData, compareData);
			ItemType itemType = (ItemType)data.ItemType;
			if (itemType != ItemType.ENCHANT)
			{
				base._SetupLevel(goToolTip, data, 0);
				base._SetupProf(goToolTip, data, bMain, instanceData, 1);
				base._SetupType(goToolTip, data, 2);
			}
			else
			{
				XEnchantDocument specificDocument = XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID);
				EnchantEquip.RowData enchantEquipData = specificDocument.GetEnchantEquipData(data.ItemID);
				base._SetTopFrameLabel(goToolTip, 0, XStringDefineProxy.GetString("ToolTipText_Level"), XStringDefineProxy.GetString("ToolTipText_UnderLevel", new object[]
				{
					data.ReqLevel.ToString()
				}));
				base._SetTopFrameLabel(goToolTip, 1, XStringDefineProxy.GetString("ToolTipText_Part"), (enchantEquipData != null) ? XStringDefineProxy.GetString("ToolTipText_EnchantType" + enchantEquipData.VisiblePos.ToString()) : string.Empty);
				base._SetupType(goToolTip, data, 2);
			}
			this.m_timeLab = goToolTip.transform.Find("TopFrame/countdown").GetComponent<IXUILabel>();
			this.m_bIsNeedTimeUpdate = true;
			this.m_timeLab.gameObject.SetActive(true);
			this.SetTimeLab();
		}

		private void SetTimeLab()
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.mainItemUID);
			bool flag = itemByUID == null || this.m_timeLab.gameObject == null;
			if (flag)
			{
				this.m_timeLab.gameObject.SetActive(false);
				this.m_bIsNeedTimeUpdate = false;
			}
			else
			{
				uint serverTimeSince = XActivityDocument.Doc.ServerTimeSince1970;
				bool flag2 = serverTimeSince >= itemByUID.bexpirationTime;
				if (flag2)
				{
					this.m_bIsNeedTimeUpdate = false;
					this.m_timeLab.gameObject.SetActive(false);
				}
				else
				{
					this.m_tempStr = XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)(itemByUID.bexpirationTime - serverTimeSince), 4);
					this.m_tempStr = XSingleton<UiUtility>.singleton.ReplaceReturn(string.Format("{0}{1}", XSingleton<XStringTable>.singleton.GetString("TipsEndTime"), this.m_tempStr));
					this.m_timeLab.SetText(this.m_tempStr);
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

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.m_bIsNeedTimeUpdate && Time.realtimeSinceStartup >= this.m_nextTime;
			if (flag)
			{
				this.m_nextTime = Time.realtimeSinceStartup + 60f;
				this.SetTimeLab();
			}
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

		private bool m_bIsNeedTimeUpdate = false;

		private IXUILabel m_timeLab;

		private string m_tempStr = string.Empty;

		private float m_nextTime = 0f;
	}
}
