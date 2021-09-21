using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000583 RID: 1411
	[ProtoContract(Name = "BattleRewardChest")]
	[Serializable]
	public class BattleRewardChest : IExtensible
	{
		// Token: 0x1700168B RID: 5771
		// (get) Token: 0x0600496E RID: 18798 RVA: 0x0008B94C File Offset: 0x00089B4C
		// (set) Token: 0x0600496F RID: 18799 RVA: 0x0008B978 File Offset: 0x00089B78
		[ProtoMember(1, IsRequired = false, Name = "chestType", DataFormat = DataFormat.TwosComplement)]
		public int chestType
		{
			get
			{
				return this._chestType ?? 0;
			}
			set
			{
				this._chestType = new int?(value);
			}
		}

		// Token: 0x1700168C RID: 5772
		// (get) Token: 0x06004970 RID: 18800 RVA: 0x0008B988 File Offset: 0x00089B88
		// (set) Token: 0x06004971 RID: 18801 RVA: 0x0008B9A8 File Offset: 0x00089BA8
		[XmlIgnore]
		[Browsable(false)]
		public bool chestTypeSpecified
		{
			get
			{
				return this._chestType != null;
			}
			set
			{
				bool flag = value == (this._chestType == null);
				if (flag)
				{
					this._chestType = (value ? new int?(this.chestType) : null);
				}
			}
		}

		// Token: 0x06004972 RID: 18802 RVA: 0x0008B9EC File Offset: 0x00089BEC
		private bool ShouldSerializechestType()
		{
			return this.chestTypeSpecified;
		}

		// Token: 0x06004973 RID: 18803 RVA: 0x0008BA04 File Offset: 0x00089C04
		private void ResetchestType()
		{
			this.chestTypeSpecified = false;
		}

		// Token: 0x1700168D RID: 5773
		// (get) Token: 0x06004974 RID: 18804 RVA: 0x0008BA10 File Offset: 0x00089C10
		// (set) Token: 0x06004975 RID: 18805 RVA: 0x0008BA3C File Offset: 0x00089C3C
		[ProtoMember(2, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
		public int itemID
		{
			get
			{
				return this._itemID ?? 0;
			}
			set
			{
				this._itemID = new int?(value);
			}
		}

		// Token: 0x1700168E RID: 5774
		// (get) Token: 0x06004976 RID: 18806 RVA: 0x0008BA4C File Offset: 0x00089C4C
		// (set) Token: 0x06004977 RID: 18807 RVA: 0x0008BA6C File Offset: 0x00089C6C
		[XmlIgnore]
		[Browsable(false)]
		public bool itemIDSpecified
		{
			get
			{
				return this._itemID != null;
			}
			set
			{
				bool flag = value == (this._itemID == null);
				if (flag)
				{
					this._itemID = (value ? new int?(this.itemID) : null);
				}
			}
		}

		// Token: 0x06004978 RID: 18808 RVA: 0x0008BAB0 File Offset: 0x00089CB0
		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		// Token: 0x06004979 RID: 18809 RVA: 0x0008BAC8 File Offset: 0x00089CC8
		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		// Token: 0x1700168F RID: 5775
		// (get) Token: 0x0600497A RID: 18810 RVA: 0x0008BAD4 File Offset: 0x00089CD4
		// (set) Token: 0x0600497B RID: 18811 RVA: 0x0008BB00 File Offset: 0x00089D00
		[ProtoMember(3, IsRequired = false, Name = "itemCount", DataFormat = DataFormat.TwosComplement)]
		public int itemCount
		{
			get
			{
				return this._itemCount ?? 0;
			}
			set
			{
				this._itemCount = new int?(value);
			}
		}

		// Token: 0x17001690 RID: 5776
		// (get) Token: 0x0600497C RID: 18812 RVA: 0x0008BB10 File Offset: 0x00089D10
		// (set) Token: 0x0600497D RID: 18813 RVA: 0x0008BB30 File Offset: 0x00089D30
		[XmlIgnore]
		[Browsable(false)]
		public bool itemCountSpecified
		{
			get
			{
				return this._itemCount != null;
			}
			set
			{
				bool flag = value == (this._itemCount == null);
				if (flag)
				{
					this._itemCount = (value ? new int?(this.itemCount) : null);
				}
			}
		}

		// Token: 0x0600497E RID: 18814 RVA: 0x0008BB74 File Offset: 0x00089D74
		private bool ShouldSerializeitemCount()
		{
			return this.itemCountSpecified;
		}

		// Token: 0x0600497F RID: 18815 RVA: 0x0008BB8C File Offset: 0x00089D8C
		private void ResetitemCount()
		{
			this.itemCountSpecified = false;
		}

		// Token: 0x17001691 RID: 5777
		// (get) Token: 0x06004980 RID: 18816 RVA: 0x0008BB98 File Offset: 0x00089D98
		// (set) Token: 0x06004981 RID: 18817 RVA: 0x0008BBC4 File Offset: 0x00089DC4
		[ProtoMember(4, IsRequired = false, Name = "isbind", DataFormat = DataFormat.Default)]
		public bool isbind
		{
			get
			{
				return this._isbind ?? false;
			}
			set
			{
				this._isbind = new bool?(value);
			}
		}

		// Token: 0x17001692 RID: 5778
		// (get) Token: 0x06004982 RID: 18818 RVA: 0x0008BBD4 File Offset: 0x00089DD4
		// (set) Token: 0x06004983 RID: 18819 RVA: 0x0008BBF4 File Offset: 0x00089DF4
		[XmlIgnore]
		[Browsable(false)]
		public bool isbindSpecified
		{
			get
			{
				return this._isbind != null;
			}
			set
			{
				bool flag = value == (this._isbind == null);
				if (flag)
				{
					this._isbind = (value ? new bool?(this.isbind) : null);
				}
			}
		}

		// Token: 0x06004984 RID: 18820 RVA: 0x0008BC38 File Offset: 0x00089E38
		private bool ShouldSerializeisbind()
		{
			return this.isbindSpecified;
		}

		// Token: 0x06004985 RID: 18821 RVA: 0x0008BC50 File Offset: 0x00089E50
		private void Resetisbind()
		{
			this.isbindSpecified = false;
		}

		// Token: 0x06004986 RID: 18822 RVA: 0x0008BC5C File Offset: 0x00089E5C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001256 RID: 4694
		private int? _chestType;

		// Token: 0x04001257 RID: 4695
		private int? _itemID;

		// Token: 0x04001258 RID: 4696
		private int? _itemCount;

		// Token: 0x04001259 RID: 4697
		private bool? _isbind;

		// Token: 0x0400125A RID: 4698
		private IExtension extensionObject;
	}
}
