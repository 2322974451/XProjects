using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000661 RID: 1633
	[ProtoContract(Name = "ItemRecord")]
	[Serializable]
	public class ItemRecord : IExtensible
	{
		// Token: 0x17002082 RID: 8322
		// (get) Token: 0x060066F3 RID: 26355 RVA: 0x000C4A88 File Offset: 0x000C2C88
		// (set) Token: 0x060066F4 RID: 26356 RVA: 0x000C4AB4 File Offset: 0x000C2CB4
		[ProtoMember(1, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
		public uint itemID
		{
			get
			{
				return this._itemID ?? 0U;
			}
			set
			{
				this._itemID = new uint?(value);
			}
		}

		// Token: 0x17002083 RID: 8323
		// (get) Token: 0x060066F5 RID: 26357 RVA: 0x000C4AC4 File Offset: 0x000C2CC4
		// (set) Token: 0x060066F6 RID: 26358 RVA: 0x000C4AE4 File Offset: 0x000C2CE4
		[XmlIgnore]
		[Browsable(false)]
		public bool itemIDSpecified
		{
			get
			{
				return this._itemID != null;
			}
			set
			{
				bool flag = value == (this._itemID == null);
				if (flag)
				{
					this._itemID = (value ? new uint?(this.itemID) : null);
				}
			}
		}

		// Token: 0x060066F7 RID: 26359 RVA: 0x000C4B28 File Offset: 0x000C2D28
		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		// Token: 0x060066F8 RID: 26360 RVA: 0x000C4B40 File Offset: 0x000C2D40
		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		// Token: 0x17002084 RID: 8324
		// (get) Token: 0x060066F9 RID: 26361 RVA: 0x000C4B4C File Offset: 0x000C2D4C
		// (set) Token: 0x060066FA RID: 26362 RVA: 0x000C4B78 File Offset: 0x000C2D78
		[ProtoMember(2, IsRequired = false, Name = "itemCount", DataFormat = DataFormat.TwosComplement)]
		public uint itemCount
		{
			get
			{
				return this._itemCount ?? 0U;
			}
			set
			{
				this._itemCount = new uint?(value);
			}
		}

		// Token: 0x17002085 RID: 8325
		// (get) Token: 0x060066FB RID: 26363 RVA: 0x000C4B88 File Offset: 0x000C2D88
		// (set) Token: 0x060066FC RID: 26364 RVA: 0x000C4BA8 File Offset: 0x000C2DA8
		[XmlIgnore]
		[Browsable(false)]
		public bool itemCountSpecified
		{
			get
			{
				return this._itemCount != null;
			}
			set
			{
				bool flag = value == (this._itemCount == null);
				if (flag)
				{
					this._itemCount = (value ? new uint?(this.itemCount) : null);
				}
			}
		}

		// Token: 0x060066FD RID: 26365 RVA: 0x000C4BEC File Offset: 0x000C2DEC
		private bool ShouldSerializeitemCount()
		{
			return this.itemCountSpecified;
		}

		// Token: 0x060066FE RID: 26366 RVA: 0x000C4C04 File Offset: 0x000C2E04
		private void ResetitemCount()
		{
			this.itemCountSpecified = false;
		}

		// Token: 0x17002086 RID: 8326
		// (get) Token: 0x060066FF RID: 26367 RVA: 0x000C4C10 File Offset: 0x000C2E10
		// (set) Token: 0x06006700 RID: 26368 RVA: 0x000C4C3C File Offset: 0x000C2E3C
		[ProtoMember(3, IsRequired = false, Name = "isreceive", DataFormat = DataFormat.Default)]
		public bool isreceive
		{
			get
			{
				return this._isreceive ?? false;
			}
			set
			{
				this._isreceive = new bool?(value);
			}
		}

		// Token: 0x17002087 RID: 8327
		// (get) Token: 0x06006701 RID: 26369 RVA: 0x000C4C4C File Offset: 0x000C2E4C
		// (set) Token: 0x06006702 RID: 26370 RVA: 0x000C4C6C File Offset: 0x000C2E6C
		[XmlIgnore]
		[Browsable(false)]
		public bool isreceiveSpecified
		{
			get
			{
				return this._isreceive != null;
			}
			set
			{
				bool flag = value == (this._isreceive == null);
				if (flag)
				{
					this._isreceive = (value ? new bool?(this.isreceive) : null);
				}
			}
		}

		// Token: 0x06006703 RID: 26371 RVA: 0x000C4CB0 File Offset: 0x000C2EB0
		private bool ShouldSerializeisreceive()
		{
			return this.isreceiveSpecified;
		}

		// Token: 0x06006704 RID: 26372 RVA: 0x000C4CC8 File Offset: 0x000C2EC8
		private void Resetisreceive()
		{
			this.isreceiveSpecified = false;
		}

		// Token: 0x06006705 RID: 26373 RVA: 0x000C4CD4 File Offset: 0x000C2ED4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040018DF RID: 6367
		private uint? _itemID;

		// Token: 0x040018E0 RID: 6368
		private uint? _itemCount;

		// Token: 0x040018E1 RID: 6369
		private bool? _isreceive;

		// Token: 0x040018E2 RID: 6370
		private IExtension extensionObject;
	}
}
