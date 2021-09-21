using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200061B RID: 1563
	[ProtoContract(Name = "ActivateFashionCharm")]
	[Serializable]
	public class ActivateFashionCharm : IExtensible
	{
		// Token: 0x17001DE7 RID: 7655
		// (get) Token: 0x06005F2D RID: 24365 RVA: 0x000B5884 File Offset: 0x000B3A84
		// (set) Token: 0x06005F2E RID: 24366 RVA: 0x000B58B0 File Offset: 0x000B3AB0
		[ProtoMember(1, IsRequired = false, Name = "suit_id", DataFormat = DataFormat.TwosComplement)]
		public uint suit_id
		{
			get
			{
				return this._suit_id ?? 0U;
			}
			set
			{
				this._suit_id = new uint?(value);
			}
		}

		// Token: 0x17001DE8 RID: 7656
		// (get) Token: 0x06005F2F RID: 24367 RVA: 0x000B58C0 File Offset: 0x000B3AC0
		// (set) Token: 0x06005F30 RID: 24368 RVA: 0x000B58E0 File Offset: 0x000B3AE0
		[XmlIgnore]
		[Browsable(false)]
		public bool suit_idSpecified
		{
			get
			{
				return this._suit_id != null;
			}
			set
			{
				bool flag = value == (this._suit_id == null);
				if (flag)
				{
					this._suit_id = (value ? new uint?(this.suit_id) : null);
				}
			}
		}

		// Token: 0x06005F31 RID: 24369 RVA: 0x000B5924 File Offset: 0x000B3B24
		private bool ShouldSerializesuit_id()
		{
			return this.suit_idSpecified;
		}

		// Token: 0x06005F32 RID: 24370 RVA: 0x000B593C File Offset: 0x000B3B3C
		private void Resetsuit_id()
		{
			this.suit_idSpecified = false;
		}

		// Token: 0x17001DE9 RID: 7657
		// (get) Token: 0x06005F33 RID: 24371 RVA: 0x000B5948 File Offset: 0x000B3B48
		// (set) Token: 0x06005F34 RID: 24372 RVA: 0x000B5974 File Offset: 0x000B3B74
		[ProtoMember(2, IsRequired = false, Name = "activate_count", DataFormat = DataFormat.TwosComplement)]
		public uint activate_count
		{
			get
			{
				return this._activate_count ?? 0U;
			}
			set
			{
				this._activate_count = new uint?(value);
			}
		}

		// Token: 0x17001DEA RID: 7658
		// (get) Token: 0x06005F35 RID: 24373 RVA: 0x000B5984 File Offset: 0x000B3B84
		// (set) Token: 0x06005F36 RID: 24374 RVA: 0x000B59A4 File Offset: 0x000B3BA4
		[XmlIgnore]
		[Browsable(false)]
		public bool activate_countSpecified
		{
			get
			{
				return this._activate_count != null;
			}
			set
			{
				bool flag = value == (this._activate_count == null);
				if (flag)
				{
					this._activate_count = (value ? new uint?(this.activate_count) : null);
				}
			}
		}

		// Token: 0x06005F37 RID: 24375 RVA: 0x000B59E8 File Offset: 0x000B3BE8
		private bool ShouldSerializeactivate_count()
		{
			return this.activate_countSpecified;
		}

		// Token: 0x06005F38 RID: 24376 RVA: 0x000B5A00 File Offset: 0x000B3C00
		private void Resetactivate_count()
		{
			this.activate_countSpecified = false;
		}

		// Token: 0x17001DEB RID: 7659
		// (get) Token: 0x06005F39 RID: 24377 RVA: 0x000B5A0C File Offset: 0x000B3C0C
		[ProtoMember(3, Name = "items", DataFormat = DataFormat.TwosComplement)]
		public List<uint> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x06005F3A RID: 24378 RVA: 0x000B5A24 File Offset: 0x000B3C24
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400171D RID: 5917
		private uint? _suit_id;

		// Token: 0x0400171E RID: 5918
		private uint? _activate_count;

		// Token: 0x0400171F RID: 5919
		private readonly List<uint> _items = new List<uint>();

		// Token: 0x04001720 RID: 5920
		private IExtension extensionObject;
	}
}
