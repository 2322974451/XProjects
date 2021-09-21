using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006A9 RID: 1705
	[ProtoContract(Name = "AuctItemBrief")]
	[Serializable]
	public class AuctItemBrief : IExtensible
	{
		// Token: 0x17002335 RID: 9013
		// (get) Token: 0x06006F38 RID: 28472 RVA: 0x000D4D10 File Offset: 0x000D2F10
		// (set) Token: 0x06006F39 RID: 28473 RVA: 0x000D4D3C File Offset: 0x000D2F3C
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

		// Token: 0x17002336 RID: 9014
		// (get) Token: 0x06006F3A RID: 28474 RVA: 0x000D4D4C File Offset: 0x000D2F4C
		// (set) Token: 0x06006F3B RID: 28475 RVA: 0x000D4D6C File Offset: 0x000D2F6C
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

		// Token: 0x06006F3C RID: 28476 RVA: 0x000D4DB0 File Offset: 0x000D2FB0
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06006F3D RID: 28477 RVA: 0x000D4DC8 File Offset: 0x000D2FC8
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x17002337 RID: 9015
		// (get) Token: 0x06006F3E RID: 28478 RVA: 0x000D4DD4 File Offset: 0x000D2FD4
		// (set) Token: 0x06006F3F RID: 28479 RVA: 0x000D4E00 File Offset: 0x000D3000
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

		// Token: 0x17002338 RID: 9016
		// (get) Token: 0x06006F40 RID: 28480 RVA: 0x000D4E10 File Offset: 0x000D3010
		// (set) Token: 0x06006F41 RID: 28481 RVA: 0x000D4E30 File Offset: 0x000D3030
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

		// Token: 0x06006F42 RID: 28482 RVA: 0x000D4E74 File Offset: 0x000D3074
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06006F43 RID: 28483 RVA: 0x000D4E8C File Offset: 0x000D308C
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06006F44 RID: 28484 RVA: 0x000D4E98 File Offset: 0x000D3098
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A9C RID: 6812
		private uint? _itemid;

		// Token: 0x04001A9D RID: 6813
		private uint? _count;

		// Token: 0x04001A9E RID: 6814
		private IExtension extensionObject;
	}
}
