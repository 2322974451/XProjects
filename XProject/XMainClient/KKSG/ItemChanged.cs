using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200001A RID: 26
	[ProtoContract(Name = "ItemChanged")]
	[Serializable]
	public class ItemChanged : IExtensible
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600022C RID: 556 RVA: 0x00006E50 File Offset: 0x00005050
		[ProtoMember(1, Name = "NewItems", DataFormat = DataFormat.Default)]
		public List<Item> NewItems
		{
			get
			{
				return this._NewItems;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600022D RID: 557 RVA: 0x00006E68 File Offset: 0x00005068
		[ProtoMember(2, Name = "AttrChangeItems", DataFormat = DataFormat.Default)]
		public List<Item> AttrChangeItems
		{
			get
			{
				return this._AttrChangeItems;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600022E RID: 558 RVA: 0x00006E80 File Offset: 0x00005080
		[ProtoMember(3, Name = "RemoveItems", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> RemoveItems
		{
			get
			{
				return this._RemoveItems;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600022F RID: 559 RVA: 0x00006E98 File Offset: 0x00005098
		[ProtoMember(4, Name = "SwapItems", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> SwapItems
		{
			get
			{
				return this._SwapItems;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000230 RID: 560 RVA: 0x00006EB0 File Offset: 0x000050B0
		[ProtoMember(5, Name = "ChangeItems", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> ChangeItems
		{
			get
			{
				return this._ChangeItems;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000231 RID: 561 RVA: 0x00006EC8 File Offset: 0x000050C8
		[ProtoMember(6, Name = "VirtualItemID", DataFormat = DataFormat.TwosComplement)]
		public List<int> VirtualItemID
		{
			get
			{
				return this._VirtualItemID;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000232 RID: 562 RVA: 0x00006EE0 File Offset: 0x000050E0
		[ProtoMember(7, Name = "VirtualItemCount", DataFormat = DataFormat.TwosComplement)]
		public List<long> VirtualItemCount
		{
			get
			{
				return this._VirtualItemCount;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000233 RID: 563 RVA: 0x00006EF8 File Offset: 0x000050F8
		[ProtoMember(8, Name = "recyleadditems", DataFormat = DataFormat.Default)]
		public List<Item> recyleadditems
		{
			get
			{
				return this._recyleadditems;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000234 RID: 564 RVA: 0x00006F10 File Offset: 0x00005110
		[ProtoMember(9, Name = "recylechangeitems", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> recylechangeitems
		{
			get
			{
				return this._recylechangeitems;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000235 RID: 565 RVA: 0x00006F28 File Offset: 0x00005128
		// (set) Token: 0x06000236 RID: 566 RVA: 0x00006F54 File Offset: 0x00005154
		[ProtoMember(10, IsRequired = false, Name = "IsRearrange", DataFormat = DataFormat.Default)]
		public bool IsRearrange
		{
			get
			{
				return this._IsRearrange ?? false;
			}
			set
			{
				this._IsRearrange = new bool?(value);
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000237 RID: 567 RVA: 0x00006F64 File Offset: 0x00005164
		// (set) Token: 0x06000238 RID: 568 RVA: 0x00006F84 File Offset: 0x00005184
		[XmlIgnore]
		[Browsable(false)]
		public bool IsRearrangeSpecified
		{
			get
			{
				return this._IsRearrange != null;
			}
			set
			{
				bool flag = value == (this._IsRearrange == null);
				if (flag)
				{
					this._IsRearrange = (value ? new bool?(this.IsRearrange) : null);
				}
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00006FC8 File Offset: 0x000051C8
		private bool ShouldSerializeIsRearrange()
		{
			return this.IsRearrangeSpecified;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00006FE0 File Offset: 0x000051E0
		private void ResetIsRearrange()
		{
			this.IsRearrangeSpecified = false;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00006FEC File Offset: 0x000051EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400008D RID: 141
		private readonly List<Item> _NewItems = new List<Item>();

		// Token: 0x0400008E RID: 142
		private readonly List<Item> _AttrChangeItems = new List<Item>();

		// Token: 0x0400008F RID: 143
		private readonly List<ulong> _RemoveItems = new List<ulong>();

		// Token: 0x04000090 RID: 144
		private readonly List<ulong> _SwapItems = new List<ulong>();

		// Token: 0x04000091 RID: 145
		private readonly List<ulong> _ChangeItems = new List<ulong>();

		// Token: 0x04000092 RID: 146
		private readonly List<int> _VirtualItemID = new List<int>();

		// Token: 0x04000093 RID: 147
		private readonly List<long> _VirtualItemCount = new List<long>();

		// Token: 0x04000094 RID: 148
		private readonly List<Item> _recyleadditems = new List<Item>();

		// Token: 0x04000095 RID: 149
		private readonly List<ulong> _recylechangeitems = new List<ulong>();

		// Token: 0x04000096 RID: 150
		private bool? _IsRearrange;

		// Token: 0x04000097 RID: 151
		private IExtension extensionObject;
	}
}
