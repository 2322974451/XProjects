using System;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient
{

	internal abstract class XItem : XDataBase
	{

		public ItemType Type
		{
			get
			{
				return (ItemType)this.type;
			}
		}

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

		public uint Prof
		{
			get
			{
				return XBagDocument.GetItemProf(this.itemID);
			}
		}

		public IXItemDescription Description
		{
			get
			{
				return XItem.GetItemDescription(this.Type, this.itemID);
			}
		}

		public virtual uint GetPPT(XAttributes attributes = null)
		{
			return 0U;
		}

		public virtual bool bHasPPT
		{
			get
			{
				return false;
			}
		}

		public virtual string ToPPTString(XAttributes attributes = null)
		{
			return string.Empty;
		}

		public virtual bool Treasure
		{
			get
			{
				return false;
			}
		}

		public virtual AttrType Atype
		{
			get
			{
				return AttrType.None;
			}
		}

		public static bool IsVirtualItem(int itemID)
		{
			return itemID < XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.VIRTUAL_ITEM_MAX);
		}

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

		public ulong uid;

		public uint type;

		public int itemID;

		public int itemCount;

		public bool bBinding;

		public uint smeltDegreeNum;

		public ItemList.RowData itemConf;

		public double blocking;

		public uint bexpirationTime;

		private static XEquipDescription s_EquipDescription = new XEquipDescription();

		private static XEmblemDescription s_EmblemDescription = new XEmblemDescription();

		private static XJadeDescription s_JadeDescription = new XJadeDescription();

		private static XFashionDescription s_FashionDescription = new XFashionDescription();

		private static XFashionHairDescription s_FashionHairDescription = new XFashionHairDescription();

		private static XNormalDescription s_NormalDescription = new XNormalDescription();

		private static XartifactDescription s_ArtifactDescription = new XartifactDescription();
	}
}
