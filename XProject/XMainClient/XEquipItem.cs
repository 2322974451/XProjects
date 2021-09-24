using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XEquipItem : XAttrItem
	{

		public override bool bHasPPT
		{
			get
			{
				return true;
			}
		}

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

		public override bool Treasure
		{
			get
			{
				return this.randAttrInfo.RandAttr.Count > 2;
			}
		}

		public override AttrType Atype
		{
			get
			{
				return this.attrType;
			}
		}

		public IEnumerable<XItemChangeAttr> EnhanceAttr()
		{
			return this.enhanceInfo.EnhanceAttr;
		}

		public IEnumerable<XItemChangeAttr> ReinforceAttr()
		{
			return this.reinforceInfo.ReinforceAttr;
		}

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

		public override void Recycle()
		{
			base.Recycle();
			this.Init();
			XDataPool<XEquipItem>.Recycle(this);
		}

		public XEnhanceInfo enhanceInfo = default(XEnhanceInfo);

		public XJadeInfo jadeInfo = default(XJadeInfo);

		public XReinforceInfo reinforceInfo = default(XReinforceInfo);

		public XSmeltingInfo smeltingInfo = default(XSmeltingInfo);

		public XRandAttrInfo randAttrInfo = default(XRandAttrInfo);

		public XEnchantInfo enchantInfo = default(XEnchantInfo);

		public XForgeAttrInfo forgeAttrInfo = default(XForgeAttrInfo);

		public XequipFuseInfo fuseInfo = default(XequipFuseInfo);

		public AttrType attrType = AttrType.None;
	}
}
