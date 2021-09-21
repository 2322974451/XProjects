using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006AA RID: 1706
	[ProtoContract(Name = "AuctOverlapData")]
	[Serializable]
	public class AuctOverlapData : IExtensible
	{
		// Token: 0x17002339 RID: 9017
		// (get) Token: 0x06006F46 RID: 28486 RVA: 0x000D4EC8 File Offset: 0x000D30C8
		// (set) Token: 0x06006F47 RID: 28487 RVA: 0x000D4EF5 File Offset: 0x000D30F5
		[ProtoMember(1, IsRequired = false, Name = "overlapid", DataFormat = DataFormat.TwosComplement)]
		public ulong overlapid
		{
			get
			{
				return this._overlapid ?? 0UL;
			}
			set
			{
				this._overlapid = new ulong?(value);
			}
		}

		// Token: 0x1700233A RID: 9018
		// (get) Token: 0x06006F48 RID: 28488 RVA: 0x000D4F04 File Offset: 0x000D3104
		// (set) Token: 0x06006F49 RID: 28489 RVA: 0x000D4F24 File Offset: 0x000D3124
		[XmlIgnore]
		[Browsable(false)]
		public bool overlapidSpecified
		{
			get
			{
				return this._overlapid != null;
			}
			set
			{
				bool flag = value == (this._overlapid == null);
				if (flag)
				{
					this._overlapid = (value ? new ulong?(this.overlapid) : null);
				}
			}
		}

		// Token: 0x06006F4A RID: 28490 RVA: 0x000D4F68 File Offset: 0x000D3168
		private bool ShouldSerializeoverlapid()
		{
			return this.overlapidSpecified;
		}

		// Token: 0x06006F4B RID: 28491 RVA: 0x000D4F80 File Offset: 0x000D3180
		private void Resetoverlapid()
		{
			this.overlapidSpecified = false;
		}

		// Token: 0x1700233B RID: 9019
		// (get) Token: 0x06006F4C RID: 28492 RVA: 0x000D4F8C File Offset: 0x000D318C
		// (set) Token: 0x06006F4D RID: 28493 RVA: 0x000D4FB8 File Offset: 0x000D31B8
		[ProtoMember(2, IsRequired = false, Name = "perprice", DataFormat = DataFormat.TwosComplement)]
		public uint perprice
		{
			get
			{
				return this._perprice ?? 0U;
			}
			set
			{
				this._perprice = new uint?(value);
			}
		}

		// Token: 0x1700233C RID: 9020
		// (get) Token: 0x06006F4E RID: 28494 RVA: 0x000D4FC8 File Offset: 0x000D31C8
		// (set) Token: 0x06006F4F RID: 28495 RVA: 0x000D4FE8 File Offset: 0x000D31E8
		[XmlIgnore]
		[Browsable(false)]
		public bool perpriceSpecified
		{
			get
			{
				return this._perprice != null;
			}
			set
			{
				bool flag = value == (this._perprice == null);
				if (flag)
				{
					this._perprice = (value ? new uint?(this.perprice) : null);
				}
			}
		}

		// Token: 0x06006F50 RID: 28496 RVA: 0x000D502C File Offset: 0x000D322C
		private bool ShouldSerializeperprice()
		{
			return this.perpriceSpecified;
		}

		// Token: 0x06006F51 RID: 28497 RVA: 0x000D5044 File Offset: 0x000D3244
		private void Resetperprice()
		{
			this.perpriceSpecified = false;
		}

		// Token: 0x1700233D RID: 9021
		// (get) Token: 0x06006F52 RID: 28498 RVA: 0x000D5050 File Offset: 0x000D3250
		// (set) Token: 0x06006F53 RID: 28499 RVA: 0x000D5068 File Offset: 0x000D3268
		[ProtoMember(3, IsRequired = false, Name = "itemdata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Item itemdata
		{
			get
			{
				return this._itemdata;
			}
			set
			{
				this._itemdata = value;
			}
		}

		// Token: 0x06006F54 RID: 28500 RVA: 0x000D5074 File Offset: 0x000D3274
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A9F RID: 6815
		private ulong? _overlapid;

		// Token: 0x04001AA0 RID: 6816
		private uint? _perprice;

		// Token: 0x04001AA1 RID: 6817
		private Item _itemdata = null;

		// Token: 0x04001AA2 RID: 6818
		private IExtension extensionObject;
	}
}
