using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200056A RID: 1386
	[ProtoContract(Name = "ItemForge")]
	[Serializable]
	public class ItemForge : IExtensible
	{
		// Token: 0x170015D6 RID: 5590
		// (get) Token: 0x06004756 RID: 18262 RVA: 0x000878E8 File Offset: 0x00085AE8
		[ProtoMember(1, Name = "attrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> attrs
		{
			get
			{
				return this._attrs;
			}
		}

		// Token: 0x170015D7 RID: 5591
		// (get) Token: 0x06004757 RID: 18263 RVA: 0x00087900 File Offset: 0x00085B00
		// (set) Token: 0x06004758 RID: 18264 RVA: 0x00087918 File Offset: 0x00085B18
		[ProtoMember(2, IsRequired = false, Name = "unReplacedAttr", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public AttributeInfo unReplacedAttr
		{
			get
			{
				return this._unReplacedAttr;
			}
			set
			{
				this._unReplacedAttr = value;
			}
		}

		// Token: 0x170015D8 RID: 5592
		// (get) Token: 0x06004759 RID: 18265 RVA: 0x00087924 File Offset: 0x00085B24
		[ProtoMember(3, Name = "haveAttrs", DataFormat = DataFormat.TwosComplement)]
		public List<uint> haveAttrs
		{
			get
			{
				return this._haveAttrs;
			}
		}

		// Token: 0x0600475A RID: 18266 RVA: 0x0008793C File Offset: 0x00085B3C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011D1 RID: 4561
		private readonly List<AttributeInfo> _attrs = new List<AttributeInfo>();

		// Token: 0x040011D2 RID: 4562
		private AttributeInfo _unReplacedAttr = null;

		// Token: 0x040011D3 RID: 4563
		private readonly List<uint> _haveAttrs = new List<uint>();

		// Token: 0x040011D4 RID: 4564
		private IExtension extensionObject;
	}
}
