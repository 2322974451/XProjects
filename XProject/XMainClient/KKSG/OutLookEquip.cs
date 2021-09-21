using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000573 RID: 1395
	[ProtoContract(Name = "OutLookEquip")]
	[Serializable]
	public class OutLookEquip : IExtensible
	{
		// Token: 0x1700160E RID: 5646
		// (get) Token: 0x060047FB RID: 18427 RVA: 0x00088BE0 File Offset: 0x00086DE0
		[ProtoMember(1, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> itemid
		{
			get
			{
				return this._itemid;
			}
		}

		// Token: 0x1700160F RID: 5647
		// (get) Token: 0x060047FC RID: 18428 RVA: 0x00088BF8 File Offset: 0x00086DF8
		[ProtoMember(2, Name = "enhancelevel", DataFormat = DataFormat.TwosComplement)]
		public List<uint> enhancelevel
		{
			get
			{
				return this._enhancelevel;
			}
		}

		// Token: 0x17001610 RID: 5648
		// (get) Token: 0x060047FD RID: 18429 RVA: 0x00088C10 File Offset: 0x00086E10
		[ProtoMember(3, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public List<uint> slot
		{
			get
			{
				return this._slot;
			}
		}

		// Token: 0x17001611 RID: 5649
		// (get) Token: 0x060047FE RID: 18430 RVA: 0x00088C28 File Offset: 0x00086E28
		// (set) Token: 0x060047FF RID: 18431 RVA: 0x00088C54 File Offset: 0x00086E54
		[ProtoMember(4, IsRequired = false, Name = "enhancemaster", DataFormat = DataFormat.TwosComplement)]
		public uint enhancemaster
		{
			get
			{
				return this._enhancemaster ?? 0U;
			}
			set
			{
				this._enhancemaster = new uint?(value);
			}
		}

		// Token: 0x17001612 RID: 5650
		// (get) Token: 0x06004800 RID: 18432 RVA: 0x00088C64 File Offset: 0x00086E64
		// (set) Token: 0x06004801 RID: 18433 RVA: 0x00088C84 File Offset: 0x00086E84
		[XmlIgnore]
		[Browsable(false)]
		public bool enhancemasterSpecified
		{
			get
			{
				return this._enhancemaster != null;
			}
			set
			{
				bool flag = value == (this._enhancemaster == null);
				if (flag)
				{
					this._enhancemaster = (value ? new uint?(this.enhancemaster) : null);
				}
			}
		}

		// Token: 0x06004802 RID: 18434 RVA: 0x00088CC8 File Offset: 0x00086EC8
		private bool ShouldSerializeenhancemaster()
		{
			return this.enhancemasterSpecified;
		}

		// Token: 0x06004803 RID: 18435 RVA: 0x00088CE0 File Offset: 0x00086EE0
		private void Resetenhancemaster()
		{
			this.enhancemasterSpecified = false;
		}

		// Token: 0x06004804 RID: 18436 RVA: 0x00088CEC File Offset: 0x00086EEC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011FE RID: 4606
		private readonly List<uint> _itemid = new List<uint>();

		// Token: 0x040011FF RID: 4607
		private readonly List<uint> _enhancelevel = new List<uint>();

		// Token: 0x04001200 RID: 4608
		private readonly List<uint> _slot = new List<uint>();

		// Token: 0x04001201 RID: 4609
		private uint? _enhancemaster;

		// Token: 0x04001202 RID: 4610
		private IExtension extensionObject;
	}
}
