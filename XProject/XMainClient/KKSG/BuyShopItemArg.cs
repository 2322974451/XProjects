using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200005C RID: 92
	[ProtoContract(Name = "BuyShopItemArg")]
	[Serializable]
	public class BuyShopItemArg : IExtensible
	{
		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x0000E494 File Offset: 0x0000C694
		// (set) Token: 0x06000612 RID: 1554 RVA: 0x0000E4C1 File Offset: 0x0000C6C1
		[ProtoMember(1, IsRequired = false, Name = "ItemUniqueId", DataFormat = DataFormat.TwosComplement)]
		public ulong ItemUniqueId
		{
			get
			{
				return this._ItemUniqueId ?? 0UL;
			}
			set
			{
				this._ItemUniqueId = new ulong?(value);
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000613 RID: 1555 RVA: 0x0000E4D0 File Offset: 0x0000C6D0
		// (set) Token: 0x06000614 RID: 1556 RVA: 0x0000E4F0 File Offset: 0x0000C6F0
		[XmlIgnore]
		[Browsable(false)]
		public bool ItemUniqueIdSpecified
		{
			get
			{
				return this._ItemUniqueId != null;
			}
			set
			{
				bool flag = value == (this._ItemUniqueId == null);
				if (flag)
				{
					this._ItemUniqueId = (value ? new ulong?(this.ItemUniqueId) : null);
				}
			}
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x0000E534 File Offset: 0x0000C734
		private bool ShouldSerializeItemUniqueId()
		{
			return this.ItemUniqueIdSpecified;
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x0000E54C File Offset: 0x0000C74C
		private void ResetItemUniqueId()
		{
			this.ItemUniqueIdSpecified = false;
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000617 RID: 1559 RVA: 0x0000E558 File Offset: 0x0000C758
		// (set) Token: 0x06000618 RID: 1560 RVA: 0x0000E584 File Offset: 0x0000C784
		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000619 RID: 1561 RVA: 0x0000E594 File Offset: 0x0000C794
		// (set) Token: 0x0600061A RID: 1562 RVA: 0x0000E5B4 File Offset: 0x0000C7B4
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

		// Token: 0x0600061B RID: 1563 RVA: 0x0000E5F8 File Offset: 0x0000C7F8
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x0000E610 File Offset: 0x0000C810
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0000E61C File Offset: 0x0000C81C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400018B RID: 395
		private ulong? _ItemUniqueId;

		// Token: 0x0400018C RID: 396
		private uint? _count;

		// Token: 0x0400018D RID: 397
		private IExtension extensionObject;
	}
}
