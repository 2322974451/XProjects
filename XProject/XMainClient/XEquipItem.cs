using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DEA RID: 3562
	internal class XEquipItem : XAttrItem
	{
		// Token: 0x170033E3 RID: 13283
		// (get) Token: 0x0600C0F4 RID: 49396 RVA: 0x0028DDAC File Offset: 0x0028BFAC
		public override bool bHasPPT
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C0F5 RID: 49397 RVA: 0x0028DDC0 File Offset: 0x0028BFC0
		public override string ToPPTString(XAttributes attributes = null)
		{
			uint num = this.GetPPT(attributes);
			string result = string.Empty;
			bool bPreview = this.randAttrInfo.bPreview;
			if (bPreview)
			{
				uint num2 = 0U;
				uint num3 = 0U;
				EquipSlotAttrDatas attrData = XCharacterEquipDocument.RandomAttrMgr.GetAttrData((uint)this.itemID);
				bool flag = attrData != null;
				if (flag)
				{
					num2 = num + EquipSlotAttrDatas.GetMinPPT(attrData, attributes, false);
					num3 = num + EquipSlotAttrDatas.GetMaxPPT(attrData, attributes);
				}
				EquipSlotAttrDatas attrData2 = XForgeDocument.ForgeAttrMgr.GetAttrData((uint)this.itemID);
				bool flag2 = attrData != null;
				if (flag2)
				{
					num2 += EquipSlotAttrDatas.GetMinPPT(attrData, attributes, true);
					num3 += num + EquipSlotAttrDatas.GetMaxPPT(attrData, attributes);
				}
				result = string.Format("{0} - {1}", num2, num3);
			}
			else
			{
				for (int i = 0; i < this.randAttrInfo.RandAttr.Count; i++)
				{
					num += (uint)XSingleton<XPowerPointCalculator>.singleton.GetPPT(this.randAttrInfo.RandAttr[i], attributes, -1);
				}
				for (int j = 0; j < this.forgeAttrInfo.ForgeAttr.Count; j++)
				{
					num += (uint)XSingleton<XPowerPointCalculator>.singleton.GetPPT(this.forgeAttrInfo.ForgeAttr[j], attributes, -1);
				}
				result = num.ToString();
			}
			return result;
		}

		// Token: 0x170033E4 RID: 13284
		// (get) Token: 0x0600C0F6 RID: 49398 RVA: 0x0028DF28 File Offset: 0x0028C128
		public override bool Treasure
		{
			get
			{
				return this.randAttrInfo.RandAttr.Count > 2;
			}
		}

		// Token: 0x170033E5 RID: 13285
		// (get) Token: 0x0600C0F7 RID: 49399 RVA: 0x0028DF50 File Offset: 0x0028C150
		public override AttrType Atype
		{
			get
			{
				return this.attrType;
			}
		}

		// Token: 0x0600C0F8 RID: 49400 RVA: 0x0028DF68 File Offset: 0x0028C168
		public IEnumerable<XItemChangeAttr> EnhanceAttr()
		{
			return this.enhanceInfo.EnhanceAttr;
		}

		// Token: 0x0600C0F9 RID: 49401 RVA: 0x0028DF88 File Offset: 0x0028C188
		public IEnumerable<XItemChangeAttr> ReinforceAttr()
		{
			return this.reinforceInfo.ReinforceAttr;
		}

		// Token: 0x0600C0FA RID: 49402 RVA: 0x0028DFA8 File Offset: 0x0028C1A8
		public override void Init()
		{
			base.Init();
			this.jadeInfo.Init();
			this.enhanceInfo.Init();
			this.randAttrInfo.Init();
			this.enchantInfo.Init();
			this.forgeAttrInfo.Init();
			this.fuseInfo.Init();
		}

		// Token: 0x0600C0FB RID: 49403 RVA: 0x0028E005 File Offset: 0x0028C205
		public override void Recycle()
		{
			base.Recycle();
			this.Init();
			XDataPool<XEquipItem>.Recycle(this);
		}

		// Token: 0x0400511A RID: 20762
		public XEnhanceInfo enhanceInfo = default(XEnhanceInfo);

		// Token: 0x0400511B RID: 20763
		public XJadeInfo jadeInfo = default(XJadeInfo);

		// Token: 0x0400511C RID: 20764
		public XReinforceInfo reinforceInfo = default(XReinforceInfo);

		// Token: 0x0400511D RID: 20765
		public XSmeltingInfo smeltingInfo = default(XSmeltingInfo);

		// Token: 0x0400511E RID: 20766
		public XRandAttrInfo randAttrInfo = default(XRandAttrInfo);

		// Token: 0x0400511F RID: 20767
		public XEnchantInfo enchantInfo = default(XEnchantInfo);

		// Token: 0x04005120 RID: 20768
		public XForgeAttrInfo forgeAttrInfo = default(XForgeAttrInfo);

		// Token: 0x04005121 RID: 20769
		public XequipFuseInfo fuseInfo = default(XequipFuseInfo);

		// Token: 0x04005122 RID: 20770
		public AttrType attrType = AttrType.None;
	}
}
