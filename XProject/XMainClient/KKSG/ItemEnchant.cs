using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000567 RID: 1383
	[ProtoContract(Name = "ItemEnchant")]
	[Serializable]
	public class ItemEnchant : IExtensible
	{
		// Token: 0x170015C8 RID: 5576
		// (get) Token: 0x06004732 RID: 18226 RVA: 0x000874AC File Offset: 0x000856AC
		// (set) Token: 0x06004733 RID: 18227 RVA: 0x000874D8 File Offset: 0x000856D8
		[ProtoMember(1, IsRequired = false, Name = "enchantid", DataFormat = DataFormat.TwosComplement)]
		public uint enchantid
		{
			get
			{
				return this._enchantid ?? 0U;
			}
			set
			{
				this._enchantid = new uint?(value);
			}
		}

		// Token: 0x170015C9 RID: 5577
		// (get) Token: 0x06004734 RID: 18228 RVA: 0x000874E8 File Offset: 0x000856E8
		// (set) Token: 0x06004735 RID: 18229 RVA: 0x00087508 File Offset: 0x00085708
		[XmlIgnore]
		[Browsable(false)]
		public bool enchantidSpecified
		{
			get
			{
				return this._enchantid != null;
			}
			set
			{
				bool flag = value == (this._enchantid == null);
				if (flag)
				{
					this._enchantid = (value ? new uint?(this.enchantid) : null);
				}
			}
		}

		// Token: 0x06004736 RID: 18230 RVA: 0x0008754C File Offset: 0x0008574C
		private bool ShouldSerializeenchantid()
		{
			return this.enchantidSpecified;
		}

		// Token: 0x06004737 RID: 18231 RVA: 0x00087564 File Offset: 0x00085764
		private void Resetenchantid()
		{
			this.enchantidSpecified = false;
		}

		// Token: 0x170015CA RID: 5578
		// (get) Token: 0x06004738 RID: 18232 RVA: 0x00087570 File Offset: 0x00085770
		[ProtoMember(2, Name = "attrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> attrs
		{
			get
			{
				return this._attrs;
			}
		}

		// Token: 0x170015CB RID: 5579
		// (get) Token: 0x06004739 RID: 18233 RVA: 0x00087588 File Offset: 0x00085788
		// (set) Token: 0x0600473A RID: 18234 RVA: 0x000875B4 File Offset: 0x000857B4
		[ProtoMember(3, IsRequired = false, Name = "chooseAttrid", DataFormat = DataFormat.TwosComplement)]
		public uint chooseAttrid
		{
			get
			{
				return this._chooseAttrid ?? 0U;
			}
			set
			{
				this._chooseAttrid = new uint?(value);
			}
		}

		// Token: 0x170015CC RID: 5580
		// (get) Token: 0x0600473B RID: 18235 RVA: 0x000875C4 File Offset: 0x000857C4
		// (set) Token: 0x0600473C RID: 18236 RVA: 0x000875E4 File Offset: 0x000857E4
		[XmlIgnore]
		[Browsable(false)]
		public bool chooseAttridSpecified
		{
			get
			{
				return this._chooseAttrid != null;
			}
			set
			{
				bool flag = value == (this._chooseAttrid == null);
				if (flag)
				{
					this._chooseAttrid = (value ? new uint?(this.chooseAttrid) : null);
				}
			}
		}

		// Token: 0x0600473D RID: 18237 RVA: 0x00087628 File Offset: 0x00085828
		private bool ShouldSerializechooseAttrid()
		{
			return this.chooseAttridSpecified;
		}

		// Token: 0x0600473E RID: 18238 RVA: 0x00087640 File Offset: 0x00085840
		private void ResetchooseAttrid()
		{
			this.chooseAttridSpecified = false;
		}

		// Token: 0x170015CD RID: 5581
		// (get) Token: 0x0600473F RID: 18239 RVA: 0x0008764C File Offset: 0x0008584C
		[ProtoMember(4, Name = "enchantids", DataFormat = DataFormat.TwosComplement)]
		public List<uint> enchantids
		{
			get
			{
				return this._enchantids;
			}
		}

		// Token: 0x170015CE RID: 5582
		// (get) Token: 0x06004740 RID: 18240 RVA: 0x00087664 File Offset: 0x00085864
		[ProtoMember(5, Name = "allAttrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> allAttrs
		{
			get
			{
				return this._allAttrs;
			}
		}

		// Token: 0x170015CF RID: 5583
		// (get) Token: 0x06004741 RID: 18241 RVA: 0x0008767C File Offset: 0x0008587C
		[ProtoMember(6, Name = "enchantBaodi", DataFormat = DataFormat.TwosComplement)]
		public List<uint> enchantBaodi
		{
			get
			{
				return this._enchantBaodi;
			}
		}

		// Token: 0x170015D0 RID: 5584
		// (get) Token: 0x06004742 RID: 18242 RVA: 0x00087694 File Offset: 0x00085894
		[ProtoMember(7, Name = "baodiCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> baodiCount
		{
			get
			{
				return this._baodiCount;
			}
		}

		// Token: 0x06004743 RID: 18243 RVA: 0x000876AC File Offset: 0x000858AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011C4 RID: 4548
		private uint? _enchantid;

		// Token: 0x040011C5 RID: 4549
		private readonly List<AttributeInfo> _attrs = new List<AttributeInfo>();

		// Token: 0x040011C6 RID: 4550
		private uint? _chooseAttrid;

		// Token: 0x040011C7 RID: 4551
		private readonly List<uint> _enchantids = new List<uint>();

		// Token: 0x040011C8 RID: 4552
		private readonly List<AttributeInfo> _allAttrs = new List<AttributeInfo>();

		// Token: 0x040011C9 RID: 4553
		private readonly List<uint> _enchantBaodi = new List<uint>();

		// Token: 0x040011CA RID: 4554
		private readonly List<uint> _baodiCount = new List<uint>();

		// Token: 0x040011CB RID: 4555
		private IExtension extensionObject;
	}
}
