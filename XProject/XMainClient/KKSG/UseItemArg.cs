using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200003D RID: 61
	[ProtoContract(Name = "UseItemArg")]
	[Serializable]
	public class UseItemArg : IExtensible
	{
		// Token: 0x17000154 RID: 340
		// (get) Token: 0x0600040B RID: 1035 RVA: 0x0000A6BC File Offset: 0x000088BC
		// (set) Token: 0x0600040C RID: 1036 RVA: 0x0000A6E9 File Offset: 0x000088E9
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x0000A6F8 File Offset: 0x000088F8
		// (set) Token: 0x0600040E RID: 1038 RVA: 0x0000A718 File Offset: 0x00008918
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0000A75C File Offset: 0x0000895C
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0000A774 File Offset: 0x00008974
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x0000A780 File Offset: 0x00008980
		// (set) Token: 0x06000412 RID: 1042 RVA: 0x0000A7AC File Offset: 0x000089AC
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

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x0000A7BC File Offset: 0x000089BC
		// (set) Token: 0x06000414 RID: 1044 RVA: 0x0000A7DC File Offset: 0x000089DC
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

		// Token: 0x06000415 RID: 1045 RVA: 0x0000A820 File Offset: 0x00008A20
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0000A838 File Offset: 0x00008A38
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x0000A844 File Offset: 0x00008A44
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x0000A870 File Offset: 0x00008A70
		[ProtoMember(3, IsRequired = false, Name = "OpType", DataFormat = DataFormat.TwosComplement)]
		public uint OpType
		{
			get
			{
				return this._OpType ?? 0U;
			}
			set
			{
				this._OpType = new uint?(value);
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x0000A880 File Offset: 0x00008A80
		// (set) Token: 0x0600041A RID: 1050 RVA: 0x0000A8A0 File Offset: 0x00008AA0
		[XmlIgnore]
		[Browsable(false)]
		public bool OpTypeSpecified
		{
			get
			{
				return this._OpType != null;
			}
			set
			{
				bool flag = value == (this._OpType == null);
				if (flag)
				{
					this._OpType = (value ? new uint?(this.OpType) : null);
				}
			}
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0000A8E4 File Offset: 0x00008AE4
		private bool ShouldSerializeOpType()
		{
			return this.OpTypeSpecified;
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0000A8FC File Offset: 0x00008AFC
		private void ResetOpType()
		{
			this.OpTypeSpecified = false;
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x0000A908 File Offset: 0x00008B08
		[ProtoMember(4, Name = "uids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> uids
		{
			get
			{
				return this._uids;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x0000A920 File Offset: 0x00008B20
		// (set) Token: 0x0600041F RID: 1055 RVA: 0x0000A94C File Offset: 0x00008B4C
		[ProtoMember(5, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x0000A95C File Offset: 0x00008B5C
		// (set) Token: 0x06000421 RID: 1057 RVA: 0x0000A97C File Offset: 0x00008B7C
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

		// Token: 0x06000422 RID: 1058 RVA: 0x0000A9C0 File Offset: 0x00008BC0
		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0000A9D8 File Offset: 0x00008BD8
		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x0000A9E4 File Offset: 0x00008BE4
		// (set) Token: 0x06000425 RID: 1061 RVA: 0x0000AA11 File Offset: 0x00008C11
		[ProtoMember(6, IsRequired = false, Name = "petid", DataFormat = DataFormat.TwosComplement)]
		public ulong petid
		{
			get
			{
				return this._petid ?? 0UL;
			}
			set
			{
				this._petid = new ulong?(value);
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x0000AA20 File Offset: 0x00008C20
		// (set) Token: 0x06000427 RID: 1063 RVA: 0x0000AA40 File Offset: 0x00008C40
		[XmlIgnore]
		[Browsable(false)]
		public bool petidSpecified
		{
			get
			{
				return this._petid != null;
			}
			set
			{
				bool flag = value == (this._petid == null);
				if (flag)
				{
					this._petid = (value ? new ulong?(this.petid) : null);
				}
			}
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0000AA84 File Offset: 0x00008C84
		private bool ShouldSerializepetid()
		{
			return this.petidSpecified;
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0000AA9C File Offset: 0x00008C9C
		private void Resetpetid()
		{
			this.petidSpecified = false;
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x0000AAA8 File Offset: 0x00008CA8
		// (set) Token: 0x0600042B RID: 1067 RVA: 0x0000AAD4 File Offset: 0x00008CD4
		[ProtoMember(7, IsRequired = false, Name = "suit_id", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x0000AAE4 File Offset: 0x00008CE4
		// (set) Token: 0x0600042D RID: 1069 RVA: 0x0000AB04 File Offset: 0x00008D04
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

		// Token: 0x0600042E RID: 1070 RVA: 0x0000AB48 File Offset: 0x00008D48
		private bool ShouldSerializesuit_id()
		{
			return this.suit_idSpecified;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0000AB60 File Offset: 0x00008D60
		private void Resetsuit_id()
		{
			this.suit_idSpecified = false;
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x0000AB6C File Offset: 0x00008D6C
		// (set) Token: 0x06000431 RID: 1073 RVA: 0x0000AB98 File Offset: 0x00008D98
		[ProtoMember(8, IsRequired = false, Name = "color_id", DataFormat = DataFormat.TwosComplement)]
		public uint color_id
		{
			get
			{
				return this._color_id ?? 0U;
			}
			set
			{
				this._color_id = new uint?(value);
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x0000ABA8 File Offset: 0x00008DA8
		// (set) Token: 0x06000433 RID: 1075 RVA: 0x0000ABC8 File Offset: 0x00008DC8
		[XmlIgnore]
		[Browsable(false)]
		public bool color_idSpecified
		{
			get
			{
				return this._color_id != null;
			}
			set
			{
				bool flag = value == (this._color_id == null);
				if (flag)
				{
					this._color_id = (value ? new uint?(this.color_id) : null);
				}
			}
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0000AC0C File Offset: 0x00008E0C
		private bool ShouldSerializecolor_id()
		{
			return this.color_idSpecified;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0000AC24 File Offset: 0x00008E24
		private void Resetcolor_id()
		{
			this.color_idSpecified = false;
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x0000AC30 File Offset: 0x00008E30
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000111 RID: 273
		private ulong? _uid;

		// Token: 0x04000112 RID: 274
		private uint? _count;

		// Token: 0x04000113 RID: 275
		private uint? _OpType;

		// Token: 0x04000114 RID: 276
		private readonly List<ulong> _uids = new List<ulong>();

		// Token: 0x04000115 RID: 277
		private uint? _itemID;

		// Token: 0x04000116 RID: 278
		private ulong? _petid;

		// Token: 0x04000117 RID: 279
		private uint? _suit_id;

		// Token: 0x04000118 RID: 280
		private uint? _color_id;

		// Token: 0x04000119 RID: 281
		private IExtension extensionObject;
	}
}
