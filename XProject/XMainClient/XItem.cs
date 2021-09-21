using System;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DF0 RID: 3568
	internal abstract class XItem : XDataBase
	{
		// Token: 0x170033EA RID: 13290
		// (get) Token: 0x0600C113 RID: 49427 RVA: 0x0028E4EC File Offset: 0x0028C6EC
		public ItemType Type
		{
			get
			{
				return (ItemType)this.type;
			}
		}

		// Token: 0x0600C114 RID: 49428 RVA: 0x0028E504 File Offset: 0x0028C704
		public override void Init()
		{
			base.Init();
			this.uid = 0UL;
			this.type = 0U;
			this.itemID = 0;
			this.itemCount = 0;
			this.smeltDegreeNum = 0U;
			this.bBinding = false;
			this.itemConf = null;
		}

		// Token: 0x170033EB RID: 13291
		// (get) Token: 0x0600C115 RID: 49429 RVA: 0x0028E540 File Offset: 0x0028C740
		public uint Prof
		{
			get
			{
				return XBagDocument.GetItemProf(this.itemID);
			}
		}

		// Token: 0x170033EC RID: 13292
		// (get) Token: 0x0600C116 RID: 49430 RVA: 0x0028E560 File Offset: 0x0028C760
		public IXItemDescription Description
		{
			get
			{
				return XItem.GetItemDescription(this.Type, this.itemID);
			}
		}

		// Token: 0x0600C117 RID: 49431 RVA: 0x0028E584 File Offset: 0x0028C784
		public virtual uint GetPPT(XAttributes attributes = null)
		{
			return 0U;
		}

		// Token: 0x170033ED RID: 13293
		// (get) Token: 0x0600C118 RID: 49432 RVA: 0x0028E598 File Offset: 0x0028C798
		public virtual bool bHasPPT
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600C119 RID: 49433 RVA: 0x0028E5AC File Offset: 0x0028C7AC
		public virtual string ToPPTString(XAttributes attributes = null)
		{
			return string.Empty;
		}

		// Token: 0x170033EE RID: 13294
		// (get) Token: 0x0600C11A RID: 49434 RVA: 0x0028E5C4 File Offset: 0x0028C7C4
		public virtual bool Treasure
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170033EF RID: 13295
		// (get) Token: 0x0600C11B RID: 49435 RVA: 0x0028E5D8 File Offset: 0x0028C7D8
		public virtual AttrType Atype
		{
			get
			{
				return AttrType.None;
			}
		}

		// Token: 0x0600C11C RID: 49436 RVA: 0x0028E5EC File Offset: 0x0028C7EC
		public static bool IsVirtualItem(int itemID)
		{
			return itemID < XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.VIRTUAL_ITEM_MAX);
		}

		// Token: 0x0600C11D RID: 49437 RVA: 0x0028E608 File Offset: 0x0028C808
		public static IXItemDescription GetItemDescription(ItemType type, int itemid = 0)
		{
			switch (type)
			{
			case ItemType.EQUIP:
				return XItem.s_EquipDescription;
			case ItemType.PECK:
			case ItemType.VIRTUAL_ITEM:
			case ItemType.MATERAIL:
				break;
			case ItemType.FASHION:
				return XItem.SelectFashionDescription(itemid);
			case ItemType.EMBLEM:
				return XItem.s_EmblemDescription;
			case ItemType.JADE:
				return XItem.s_JadeDescription;
			default:
				if (type == ItemType.ARTIFACT)
				{
					return XItem.s_ArtifactDescription;
				}
				break;
			}
			return XItem.s_NormalDescription;
		}

		// Token: 0x0600C11E RID: 49438 RVA: 0x0028E678 File Offset: 0x0028C878
		private static IXItemDescription SelectFashionDescription(int itemid)
		{
			bool flag = itemid == 0;
			IXItemDescription result;
			if (flag)
			{
				result = XItem.s_FashionDescription;
			}
			else
			{
				FashionList.RowData fashionConf = XBagDocument.GetFashionConf(itemid);
				bool flag2 = fashionConf == null || XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.Hair) != (int)fashionConf.EquipPos;
				if (flag2)
				{
					result = XItem.s_FashionDescription;
				}
				else
				{
					result = XItem.s_FashionHairDescription;
				}
			}
			return result;
		}

		// Token: 0x0400512B RID: 20779
		public ulong uid;

		// Token: 0x0400512C RID: 20780
		public uint type;

		// Token: 0x0400512D RID: 20781
		public int itemID;

		// Token: 0x0400512E RID: 20782
		public int itemCount;

		// Token: 0x0400512F RID: 20783
		public bool bBinding;

		// Token: 0x04005130 RID: 20784
		public uint smeltDegreeNum;

		// Token: 0x04005131 RID: 20785
		public ItemList.RowData itemConf;

		// Token: 0x04005132 RID: 20786
		public double blocking;

		// Token: 0x04005133 RID: 20787
		public uint bexpirationTime;

		// Token: 0x04005134 RID: 20788
		private static XEquipDescription s_EquipDescription = new XEquipDescription();

		// Token: 0x04005135 RID: 20789
		private static XEmblemDescription s_EmblemDescription = new XEmblemDescription();

		// Token: 0x04005136 RID: 20790
		private static XJadeDescription s_JadeDescription = new XJadeDescription();

		// Token: 0x04005137 RID: 20791
		private static XFashionDescription s_FashionDescription = new XFashionDescription();

		// Token: 0x04005138 RID: 20792
		private static XFashionHairDescription s_FashionHairDescription = new XFashionHairDescription();

		// Token: 0x04005139 RID: 20793
		private static XNormalDescription s_NormalDescription = new XNormalDescription();

		// Token: 0x0400513A RID: 20794
		private static XartifactDescription s_ArtifactDescription = new XartifactDescription();
	}
}
