using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200073B RID: 1851
	[ProtoContract(Name = "DoodadItemSkill")]
	[Serializable]
	public class DoodadItemSkill : IExtensible
	{
		// Token: 0x170028B1 RID: 10417
		// (get) Token: 0x0600805B RID: 32859 RVA: 0x000F572C File Offset: 0x000F392C
		// (set) Token: 0x0600805C RID: 32860 RVA: 0x000F5758 File Offset: 0x000F3958
		[ProtoMember(1, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		// Token: 0x170028B2 RID: 10418
		// (get) Token: 0x0600805D RID: 32861 RVA: 0x000F5768 File Offset: 0x000F3968
		// (set) Token: 0x0600805E RID: 32862 RVA: 0x000F5788 File Offset: 0x000F3988
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		// Token: 0x0600805F RID: 32863 RVA: 0x000F57CC File Offset: 0x000F39CC
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06008060 RID: 32864 RVA: 0x000F57E4 File Offset: 0x000F39E4
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x170028B3 RID: 10419
		// (get) Token: 0x06008061 RID: 32865 RVA: 0x000F57F0 File Offset: 0x000F39F0
		// (set) Token: 0x06008062 RID: 32866 RVA: 0x000F581C File Offset: 0x000F3A1C
		[ProtoMember(2, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		// Token: 0x170028B4 RID: 10420
		// (get) Token: 0x06008063 RID: 32867 RVA: 0x000F582C File Offset: 0x000F3A2C
		// (set) Token: 0x06008064 RID: 32868 RVA: 0x000F584C File Offset: 0x000F3A4C
		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		// Token: 0x06008065 RID: 32869 RVA: 0x000F5890 File Offset: 0x000F3A90
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06008066 RID: 32870 RVA: 0x000F58A8 File Offset: 0x000F3AA8
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x170028B5 RID: 10421
		// (get) Token: 0x06008067 RID: 32871 RVA: 0x000F58B4 File Offset: 0x000F3AB4
		// (set) Token: 0x06008068 RID: 32872 RVA: 0x000F58E0 File Offset: 0x000F3AE0
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

		// Token: 0x170028B6 RID: 10422
		// (get) Token: 0x06008069 RID: 32873 RVA: 0x000F58F0 File Offset: 0x000F3AF0
		// (set) Token: 0x0600806A RID: 32874 RVA: 0x000F5910 File Offset: 0x000F3B10
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

		// Token: 0x0600806B RID: 32875 RVA: 0x000F5954 File Offset: 0x000F3B54
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x0600806C RID: 32876 RVA: 0x000F596C File Offset: 0x000F3B6C
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x0600806D RID: 32877 RVA: 0x000F5978 File Offset: 0x000F3B78
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E14 RID: 7700
		private uint? _index;

		// Token: 0x04001E15 RID: 7701
		private uint? _itemid;

		// Token: 0x04001E16 RID: 7702
		private uint? _count;

		// Token: 0x04001E17 RID: 7703
		private IExtension extensionObject;
	}
}
