using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000070 RID: 112
	[ProtoContract(Name = "FashionChangedData")]
	[Serializable]
	public class FashionChangedData : IExtensible
	{
		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x00010758 File Offset: 0x0000E958
		// (set) Token: 0x06000737 RID: 1847 RVA: 0x00010784 File Offset: 0x0000E984
		[ProtoMember(1, IsRequired = false, Name = "changeType", DataFormat = DataFormat.TwosComplement)]
		public FashionNTFType changeType
		{
			get
			{
				return this._changeType ?? FashionNTFType.ADD_FASHION;
			}
			set
			{
				this._changeType = new FashionNTFType?(value);
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000738 RID: 1848 RVA: 0x00010794 File Offset: 0x0000E994
		// (set) Token: 0x06000739 RID: 1849 RVA: 0x000107B4 File Offset: 0x0000E9B4
		[XmlIgnore]
		[Browsable(false)]
		public bool changeTypeSpecified
		{
			get
			{
				return this._changeType != null;
			}
			set
			{
				bool flag = value == (this._changeType == null);
				if (flag)
				{
					this._changeType = (value ? new FashionNTFType?(this.changeType) : null);
				}
			}
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x000107F8 File Offset: 0x0000E9F8
		private bool ShouldSerializechangeType()
		{
			return this.changeTypeSpecified;
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00010810 File Offset: 0x0000EA10
		private void ResetchangeType()
		{
			this.changeTypeSpecified = false;
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x0600073C RID: 1852 RVA: 0x0001081C File Offset: 0x0000EA1C
		[ProtoMember(2, Name = "fashion", DataFormat = DataFormat.Default)]
		public List<FashionData> fashion
		{
			get
			{
				return this._fashion;
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x0600073D RID: 1853 RVA: 0x00010834 File Offset: 0x0000EA34
		// (set) Token: 0x0600073E RID: 1854 RVA: 0x00010860 File Offset: 0x0000EA60
		[ProtoMember(3, IsRequired = false, Name = "special_effects_id", DataFormat = DataFormat.TwosComplement)]
		public uint special_effects_id
		{
			get
			{
				return this._special_effects_id ?? 0U;
			}
			set
			{
				this._special_effects_id = new uint?(value);
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x0600073F RID: 1855 RVA: 0x00010870 File Offset: 0x0000EA70
		// (set) Token: 0x06000740 RID: 1856 RVA: 0x00010890 File Offset: 0x0000EA90
		[XmlIgnore]
		[Browsable(false)]
		public bool special_effects_idSpecified
		{
			get
			{
				return this._special_effects_id != null;
			}
			set
			{
				bool flag = value == (this._special_effects_id == null);
				if (flag)
				{
					this._special_effects_id = (value ? new uint?(this.special_effects_id) : null);
				}
			}
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x000108D4 File Offset: 0x0000EAD4
		private bool ShouldSerializespecial_effects_id()
		{
			return this.special_effects_idSpecified;
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x000108EC File Offset: 0x0000EAEC
		private void Resetspecial_effects_id()
		{
			this.special_effects_idSpecified = false;
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x000108F8 File Offset: 0x0000EAF8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001D6 RID: 470
		private FashionNTFType? _changeType;

		// Token: 0x040001D7 RID: 471
		private readonly List<FashionData> _fashion = new List<FashionData>();

		// Token: 0x040001D8 RID: 472
		private uint? _special_effects_id;

		// Token: 0x040001D9 RID: 473
		private IExtension extensionObject;
	}
}
