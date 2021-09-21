using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000063 RID: 99
	[ProtoContract(Name = "BuyGoldAndFatigueArg")]
	[Serializable]
	public class BuyGoldAndFatigueArg : IExtensible
	{
		// Token: 0x1700022D RID: 557
		// (get) Token: 0x060006AF RID: 1711 RVA: 0x0000F7A0 File Offset: 0x0000D9A0
		// (set) Token: 0x060006B0 RID: 1712 RVA: 0x0000F7CC File Offset: 0x0000D9CC
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public buyextype type
		{
			get
			{
				return this._type ?? buyextype.DIAMONE_BUY_DRAGONCOIN;
			}
			set
			{
				this._type = new buyextype?(value);
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x060006B1 RID: 1713 RVA: 0x0000F7DC File Offset: 0x0000D9DC
		// (set) Token: 0x060006B2 RID: 1714 RVA: 0x0000F7FC File Offset: 0x0000D9FC
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new buyextype?(this.type) : null);
				}
			}
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x0000F840 File Offset: 0x0000DA40
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x0000F858 File Offset: 0x0000DA58
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x060006B5 RID: 1717 RVA: 0x0000F864 File Offset: 0x0000DA64
		// (set) Token: 0x060006B6 RID: 1718 RVA: 0x0000F890 File Offset: 0x0000DA90
		[ProtoMember(2, IsRequired = false, Name = "fatigueID", DataFormat = DataFormat.TwosComplement)]
		public uint fatigueID
		{
			get
			{
				return this._fatigueID ?? 0U;
			}
			set
			{
				this._fatigueID = new uint?(value);
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x0000F8A0 File Offset: 0x0000DAA0
		// (set) Token: 0x060006B8 RID: 1720 RVA: 0x0000F8C0 File Offset: 0x0000DAC0
		[XmlIgnore]
		[Browsable(false)]
		public bool fatigueIDSpecified
		{
			get
			{
				return this._fatigueID != null;
			}
			set
			{
				bool flag = value == (this._fatigueID == null);
				if (flag)
				{
					this._fatigueID = (value ? new uint?(this.fatigueID) : null);
				}
			}
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x0000F904 File Offset: 0x0000DB04
		private bool ShouldSerializefatigueID()
		{
			return this.fatigueIDSpecified;
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x0000F91C File Offset: 0x0000DB1C
		private void ResetfatigueID()
		{
			this.fatigueIDSpecified = false;
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x060006BB RID: 1723 RVA: 0x0000F928 File Offset: 0x0000DB28
		// (set) Token: 0x060006BC RID: 1724 RVA: 0x0000F954 File Offset: 0x0000DB54
		[ProtoMember(3, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x0000F964 File Offset: 0x0000DB64
		// (set) Token: 0x060006BE RID: 1726 RVA: 0x0000F984 File Offset: 0x0000DB84
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x0000F9C8 File Offset: 0x0000DBC8
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x0000F9E0 File Offset: 0x0000DBE0
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x0000F9EC File Offset: 0x0000DBEC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001B2 RID: 434
		private buyextype? _type;

		// Token: 0x040001B3 RID: 435
		private uint? _fatigueID;

		// Token: 0x040001B4 RID: 436
		private uint? _count;

		// Token: 0x040001B5 RID: 437
		private IExtension extensionObject;
	}
}
