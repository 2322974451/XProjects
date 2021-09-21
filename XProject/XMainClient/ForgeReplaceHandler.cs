using System;
using KKSG;
using UILib;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000BEA RID: 3050
	internal class ForgeReplaceHandler : DlgHandlerBase
	{
		// Token: 0x0600ADC9 RID: 44489 RVA: 0x00206E38 File Offset: 0x00205038
		protected override void Init()
		{
			base.Init();
			this.m_doc = XForgeDocument.Doc;
			this.m_cancleBtn = (base.PanelObject.transform.FindChild("Bg/Cancel").GetComponent("XUIButton") as IXUIButton);
			this.m_sureBtn = (base.PanelObject.transform.FindChild("Bg/OK").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.PanelObject.transform.FindChild("Bg/AttrItem");
			this.m_beforeName = (transform.FindChild("BeforeName").GetComponent("XUILabel") as IXUILabel);
			this.m_beforeAttr = (transform.FindChild("BeforeValue").GetComponent("XUILabel") as IXUILabel);
			this.m_afterName = (transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_afterAttr = (transform.FindChild("NowValue").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600ADCA RID: 44490 RVA: 0x00206F42 File Offset: 0x00205142
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_cancleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancleClicked));
			this.m_sureBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSureClicked));
		}

		// Token: 0x0600ADCB RID: 44491 RVA: 0x00206F7C File Offset: 0x0020517C
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600ADCC RID: 44492 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600ADCD RID: 44493 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600ADCE RID: 44494 RVA: 0x00206F90 File Offset: 0x00205190
		private void FillContent()
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.CurUid);
			bool flag = itemByUID == null;
			if (!flag)
			{
				XEquipItem xequipItem = itemByUID as XEquipItem;
				bool flag2 = xequipItem.forgeAttrInfo.ForgeAttr.Count == 0;
				if (!flag2)
				{
					EquipSlotAttrDatas attrData = XForgeDocument.ForgeAttrMgr.GetAttrData((uint)itemByUID.itemID);
					bool flag3 = attrData == null;
					if (!flag3)
					{
						string color = attrData.GetColor(1, xequipItem.forgeAttrInfo.ForgeAttr[0]);
						string text = string.Format("[{0}]{1}[-]", color, XAttributeCommon.GetAttrStr((int)xequipItem.forgeAttrInfo.ForgeAttr[0].AttrID));
						this.m_beforeName.SetText(text);
						text = string.Format("[{0}]{1}[-]", color, xequipItem.forgeAttrInfo.ForgeAttr[0].AttrValue);
						this.m_beforeAttr.SetText(text);
						text = string.Format("[{0}]{1}[-]", color, XAttributeCommon.GetAttrStr((int)xequipItem.forgeAttrInfo.UnSavedAttrid));
						this.m_afterName.SetText(text);
						text = string.Format("[{0}]{1}[-]", color, xequipItem.forgeAttrInfo.UnSavedAttrValue);
						this.m_afterAttr.SetText(text);
					}
				}
			}
		}

		// Token: 0x0600ADCF RID: 44495 RVA: 0x002070E4 File Offset: 0x002052E4
		private bool OnCancleClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			this.m_doc.ReqForgeEquip(ForgeOpType.Forge_Retain);
			return true;
		}

		// Token: 0x0600ADD0 RID: 44496 RVA: 0x0020710C File Offset: 0x0020530C
		private bool OnSureClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			this.m_doc.ReqForgeEquip(ForgeOpType.Forge_Replace);
			return true;
		}

		// Token: 0x040041AC RID: 16812
		private XForgeDocument m_doc;

		// Token: 0x040041AD RID: 16813
		private IXUIButton m_cancleBtn;

		// Token: 0x040041AE RID: 16814
		private IXUIButton m_sureBtn;

		// Token: 0x040041AF RID: 16815
		private IXUILabel m_beforeName;

		// Token: 0x040041B0 RID: 16816
		private IXUILabel m_beforeAttr;

		// Token: 0x040041B1 RID: 16817
		private IXUILabel m_afterName;

		// Token: 0x040041B2 RID: 16818
		private IXUILabel m_afterAttr;
	}
}
