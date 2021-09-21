using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200067B RID: 1659
	[ProtoContract(Name = "NpcLikeItem")]
	[Serializable]
	public class NpcLikeItem : IExtensible
	{
		// Token: 0x170021A0 RID: 8608
		// (get) Token: 0x06006A41 RID: 27201 RVA: 0x000CB308 File Offset: 0x000C9508
		// (set) Token: 0x06006A42 RID: 27202 RVA: 0x000CB334 File Offset: 0x000C9534
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

		// Token: 0x170021A1 RID: 8609
		// (get) Token: 0x06006A43 RID: 27203 RVA: 0x000CB344 File Offset: 0x000C9544
		// (set) Token: 0x06006A44 RID: 27204 RVA: 0x000CB364 File Offset: 0x000C9564
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

		// Token: 0x06006A45 RID: 27205 RVA: 0x000CB3A8 File Offset: 0x000C95A8
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06006A46 RID: 27206 RVA: 0x000CB3C0 File Offset: 0x000C95C0
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x170021A2 RID: 8610
		// (get) Token: 0x06006A47 RID: 27207 RVA: 0x000CB3CC File Offset: 0x000C95CC
		// (set) Token: 0x06006A48 RID: 27208 RVA: 0x000CB3F8 File Offset: 0x000C95F8
		[ProtoMember(2, IsRequired = false, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
		public uint itemcount
		{
			get
			{
				return this._itemcount ?? 0U;
			}
			set
			{
				this._itemcount = new uint?(value);
			}
		}

		// Token: 0x170021A3 RID: 8611
		// (get) Token: 0x06006A49 RID: 27209 RVA: 0x000CB408 File Offset: 0x000C9608
		// (set) Token: 0x06006A4A RID: 27210 RVA: 0x000CB428 File Offset: 0x000C9628
		[XmlIgnore]
		[Browsable(false)]
		public bool itemcountSpecified
		{
			get
			{
				return this._itemcount != null;
			}
			set
			{
				bool flag = value == (this._itemcount == null);
				if (flag)
				{
					this._itemcount = (value ? new uint?(this.itemcount) : null);
				}
			}
		}

		// Token: 0x06006A4B RID: 27211 RVA: 0x000CB46C File Offset: 0x000C966C
		private bool ShouldSerializeitemcount()
		{
			return this.itemcountSpecified;
		}

		// Token: 0x06006A4C RID: 27212 RVA: 0x000CB484 File Offset: 0x000C9684
		private void Resetitemcount()
		{
			this.itemcountSpecified = false;
		}

		// Token: 0x170021A4 RID: 8612
		// (get) Token: 0x06006A4D RID: 27213 RVA: 0x000CB490 File Offset: 0x000C9690
		// (set) Token: 0x06006A4E RID: 27214 RVA: 0x000CB4BC File Offset: 0x000C96BC
		[ProtoMember(3, IsRequired = false, Name = "addexp", DataFormat = DataFormat.TwosComplement)]
		public uint addexp
		{
			get
			{
				return this._addexp ?? 0U;
			}
			set
			{
				this._addexp = new uint?(value);
			}
		}

		// Token: 0x170021A5 RID: 8613
		// (get) Token: 0x06006A4F RID: 27215 RVA: 0x000CB4CC File Offset: 0x000C96CC
		// (set) Token: 0x06006A50 RID: 27216 RVA: 0x000CB4EC File Offset: 0x000C96EC
		[XmlIgnore]
		[Browsable(false)]
		public bool addexpSpecified
		{
			get
			{
				return this._addexp != null;
			}
			set
			{
				bool flag = value == (this._addexp == null);
				if (flag)
				{
					this._addexp = (value ? new uint?(this.addexp) : null);
				}
			}
		}

		// Token: 0x06006A51 RID: 27217 RVA: 0x000CB530 File Offset: 0x000C9730
		private bool ShouldSerializeaddexp()
		{
			return this.addexpSpecified;
		}

		// Token: 0x06006A52 RID: 27218 RVA: 0x000CB548 File Offset: 0x000C9748
		private void Resetaddexp()
		{
			this.addexpSpecified = false;
		}

		// Token: 0x170021A6 RID: 8614
		// (get) Token: 0x06006A53 RID: 27219 RVA: 0x000CB554 File Offset: 0x000C9754
		// (set) Token: 0x06006A54 RID: 27220 RVA: 0x000CB580 File Offset: 0x000C9780
		[ProtoMember(4, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public NpcFlItemType type
		{
			get
			{
				return this._type ?? NpcFlItemType.NPCFL_ITEM_NORMAL;
			}
			set
			{
				this._type = new NpcFlItemType?(value);
			}
		}

		// Token: 0x170021A7 RID: 8615
		// (get) Token: 0x06006A55 RID: 27221 RVA: 0x000CB590 File Offset: 0x000C9790
		// (set) Token: 0x06006A56 RID: 27222 RVA: 0x000CB5B0 File Offset: 0x000C97B0
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new NpcFlItemType?(this.type) : null);
				}
			}
		}

		// Token: 0x06006A57 RID: 27223 RVA: 0x000CB5F4 File Offset: 0x000C97F4
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06006A58 RID: 27224 RVA: 0x000CB60C File Offset: 0x000C980C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06006A59 RID: 27225 RVA: 0x000CB618 File Offset: 0x000C9818
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001999 RID: 6553
		private uint? _itemid;

		// Token: 0x0400199A RID: 6554
		private uint? _itemcount;

		// Token: 0x0400199B RID: 6555
		private uint? _addexp;

		// Token: 0x0400199C RID: 6556
		private NpcFlItemType? _type;

		// Token: 0x0400199D RID: 6557
		private IExtension extensionObject;
	}
}
