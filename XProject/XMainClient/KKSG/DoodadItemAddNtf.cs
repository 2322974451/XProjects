using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200032B RID: 811
	[ProtoContract(Name = "DoodadItemAddNtf")]
	[Serializable]
	public class DoodadItemAddNtf : IExtensible
	{
		// Token: 0x17000DDC RID: 3548
		// (get) Token: 0x06002CB3 RID: 11443 RVA: 0x000568A8 File Offset: 0x00054AA8
		// (set) Token: 0x06002CB4 RID: 11444 RVA: 0x000568D4 File Offset: 0x00054AD4
		[ProtoMember(1, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000DDD RID: 3549
		// (get) Token: 0x06002CB5 RID: 11445 RVA: 0x000568E4 File Offset: 0x00054AE4
		// (set) Token: 0x06002CB6 RID: 11446 RVA: 0x00056904 File Offset: 0x00054B04
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

		// Token: 0x06002CB7 RID: 11447 RVA: 0x00056948 File Offset: 0x00054B48
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06002CB8 RID: 11448 RVA: 0x00056960 File Offset: 0x00054B60
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x17000DDE RID: 3550
		// (get) Token: 0x06002CB9 RID: 11449 RVA: 0x0005696C File Offset: 0x00054B6C
		// (set) Token: 0x06002CBA RID: 11450 RVA: 0x00056998 File Offset: 0x00054B98
		[ProtoMember(2, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000DDF RID: 3551
		// (get) Token: 0x06002CBB RID: 11451 RVA: 0x000569A8 File Offset: 0x00054BA8
		// (set) Token: 0x06002CBC RID: 11452 RVA: 0x000569C8 File Offset: 0x00054BC8
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

		// Token: 0x06002CBD RID: 11453 RVA: 0x00056A0C File Offset: 0x00054C0C
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06002CBE RID: 11454 RVA: 0x00056A24 File Offset: 0x00054C24
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x06002CBF RID: 11455 RVA: 0x00056A30 File Offset: 0x00054C30
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B11 RID: 2833
		private uint? _itemid;

		// Token: 0x04000B12 RID: 2834
		private uint? _index;

		// Token: 0x04000B13 RID: 2835
		private IExtension extensionObject;
	}
}
