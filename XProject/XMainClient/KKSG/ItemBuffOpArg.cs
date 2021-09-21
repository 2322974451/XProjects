using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002C2 RID: 706
	[ProtoContract(Name = "ItemBuffOpArg")]
	[Serializable]
	public class ItemBuffOpArg : IExtensible
	{
		// Token: 0x17000C25 RID: 3109
		// (get) Token: 0x06002712 RID: 10002 RVA: 0x0004BFB0 File Offset: 0x0004A1B0
		// (set) Token: 0x06002713 RID: 10003 RVA: 0x0004BFDC File Offset: 0x0004A1DC
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

		// Token: 0x17000C26 RID: 3110
		// (get) Token: 0x06002714 RID: 10004 RVA: 0x0004BFEC File Offset: 0x0004A1EC
		// (set) Token: 0x06002715 RID: 10005 RVA: 0x0004C00C File Offset: 0x0004A20C
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

		// Token: 0x06002716 RID: 10006 RVA: 0x0004C050 File Offset: 0x0004A250
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06002717 RID: 10007 RVA: 0x0004C068 File Offset: 0x0004A268
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x17000C27 RID: 3111
		// (get) Token: 0x06002718 RID: 10008 RVA: 0x0004C074 File Offset: 0x0004A274
		// (set) Token: 0x06002719 RID: 10009 RVA: 0x0004C0A0 File Offset: 0x0004A2A0
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

		// Token: 0x17000C28 RID: 3112
		// (get) Token: 0x0600271A RID: 10010 RVA: 0x0004C0B0 File Offset: 0x0004A2B0
		// (set) Token: 0x0600271B RID: 10011 RVA: 0x0004C0D0 File Offset: 0x0004A2D0
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

		// Token: 0x0600271C RID: 10012 RVA: 0x0004C114 File Offset: 0x0004A314
		private bool ShouldSerializeitemcount()
		{
			return this.itemcountSpecified;
		}

		// Token: 0x0600271D RID: 10013 RVA: 0x0004C12C File Offset: 0x0004A32C
		private void Resetitemcount()
		{
			this.itemcountSpecified = false;
		}

		// Token: 0x17000C29 RID: 3113
		// (get) Token: 0x0600271E RID: 10014 RVA: 0x0004C138 File Offset: 0x0004A338
		// (set) Token: 0x0600271F RID: 10015 RVA: 0x0004C164 File Offset: 0x0004A364
		[ProtoMember(3, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public uint op
		{
			get
			{
				return this._op ?? 0U;
			}
			set
			{
				this._op = new uint?(value);
			}
		}

		// Token: 0x17000C2A RID: 3114
		// (get) Token: 0x06002720 RID: 10016 RVA: 0x0004C174 File Offset: 0x0004A374
		// (set) Token: 0x06002721 RID: 10017 RVA: 0x0004C194 File Offset: 0x0004A394
		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new uint?(this.op) : null);
				}
			}
		}

		// Token: 0x06002722 RID: 10018 RVA: 0x0004C1D8 File Offset: 0x0004A3D8
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x06002723 RID: 10019 RVA: 0x0004C1F0 File Offset: 0x0004A3F0
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x17000C2B RID: 3115
		// (get) Token: 0x06002724 RID: 10020 RVA: 0x0004C1FC File Offset: 0x0004A3FC
		// (set) Token: 0x06002725 RID: 10021 RVA: 0x0004C228 File Offset: 0x0004A428
		[ProtoMember(4, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000C2C RID: 3116
		// (get) Token: 0x06002726 RID: 10022 RVA: 0x0004C238 File Offset: 0x0004A438
		// (set) Token: 0x06002727 RID: 10023 RVA: 0x0004C258 File Offset: 0x0004A458
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

		// Token: 0x06002728 RID: 10024 RVA: 0x0004C29C File Offset: 0x0004A49C
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06002729 RID: 10025 RVA: 0x0004C2B4 File Offset: 0x0004A4B4
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x0600272A RID: 10026 RVA: 0x0004C2C0 File Offset: 0x0004A4C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009B5 RID: 2485
		private uint? _itemid;

		// Token: 0x040009B6 RID: 2486
		private uint? _itemcount;

		// Token: 0x040009B7 RID: 2487
		private uint? _op;

		// Token: 0x040009B8 RID: 2488
		private uint? _index;

		// Token: 0x040009B9 RID: 2489
		private IExtension extensionObject;
	}
}
