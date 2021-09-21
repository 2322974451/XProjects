using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000D1 RID: 209
	[ProtoContract(Name = "EnemyDoodadInfo")]
	[Serializable]
	public class EnemyDoodadInfo : IExtensible
	{
		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06000D5F RID: 3423 RVA: 0x0001BEDC File Offset: 0x0001A0DC
		// (set) Token: 0x06000D60 RID: 3424 RVA: 0x0001BF08 File Offset: 0x0001A108
		[ProtoMember(1, IsRequired = false, Name = "waveid", DataFormat = DataFormat.TwosComplement)]
		public int waveid
		{
			get
			{
				return this._waveid ?? 0;
			}
			set
			{
				this._waveid = new int?(value);
			}
		}

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06000D61 RID: 3425 RVA: 0x0001BF18 File Offset: 0x0001A118
		// (set) Token: 0x06000D62 RID: 3426 RVA: 0x0001BF38 File Offset: 0x0001A138
		[XmlIgnore]
		[Browsable(false)]
		public bool waveidSpecified
		{
			get
			{
				return this._waveid != null;
			}
			set
			{
				bool flag = value == (this._waveid == null);
				if (flag)
				{
					this._waveid = (value ? new int?(this.waveid) : null);
				}
			}
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x0001BF7C File Offset: 0x0001A17C
		private bool ShouldSerializewaveid()
		{
			return this.waveidSpecified;
		}

		// Token: 0x06000D64 RID: 3428 RVA: 0x0001BF94 File Offset: 0x0001A194
		private void Resetwaveid()
		{
			this.waveidSpecified = false;
		}

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06000D65 RID: 3429 RVA: 0x0001BFA0 File Offset: 0x0001A1A0
		// (set) Token: 0x06000D66 RID: 3430 RVA: 0x0001BFCC File Offset: 0x0001A1CC
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public int type
		{
			get
			{
				return this._type ?? 0;
			}
			set
			{
				this._type = new int?(value);
			}
		}

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06000D67 RID: 3431 RVA: 0x0001BFDC File Offset: 0x0001A1DC
		// (set) Token: 0x06000D68 RID: 3432 RVA: 0x0001BFFC File Offset: 0x0001A1FC
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
					this._type = (value ? new int?(this.type) : null);
				}
			}
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x0001C040 File Offset: 0x0001A240
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x0001C058 File Offset: 0x0001A258
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06000D6B RID: 3435 RVA: 0x0001C064 File Offset: 0x0001A264
		// (set) Token: 0x06000D6C RID: 3436 RVA: 0x0001C090 File Offset: 0x0001A290
		[ProtoMember(3, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06000D6D RID: 3437 RVA: 0x0001C0A0 File Offset: 0x0001A2A0
		// (set) Token: 0x06000D6E RID: 3438 RVA: 0x0001C0C0 File Offset: 0x0001A2C0
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x0001C104 File Offset: 0x0001A304
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x0001C11C File Offset: 0x0001A31C
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x06000D71 RID: 3441 RVA: 0x0001C128 File Offset: 0x0001A328
		// (set) Token: 0x06000D72 RID: 3442 RVA: 0x0001C154 File Offset: 0x0001A354
		[ProtoMember(4, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06000D73 RID: 3443 RVA: 0x0001C164 File Offset: 0x0001A364
		// (set) Token: 0x06000D74 RID: 3444 RVA: 0x0001C184 File Offset: 0x0001A384
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

		// Token: 0x06000D75 RID: 3445 RVA: 0x0001C1C8 File Offset: 0x0001A3C8
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x0001C1E0 File Offset: 0x0001A3E0
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06000D77 RID: 3447 RVA: 0x0001C1EC File Offset: 0x0001A3EC
		// (set) Token: 0x06000D78 RID: 3448 RVA: 0x0001C204 File Offset: 0x0001A404
		[ProtoMember(5, IsRequired = false, Name = "pos", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Vec3 pos
		{
			get
			{
				return this._pos;
			}
			set
			{
				this._pos = value;
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06000D79 RID: 3449 RVA: 0x0001C210 File Offset: 0x0001A410
		// (set) Token: 0x06000D7A RID: 3450 RVA: 0x0001C23C File Offset: 0x0001A43C
		[ProtoMember(6, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06000D7B RID: 3451 RVA: 0x0001C24C File Offset: 0x0001A44C
		// (set) Token: 0x06000D7C RID: 3452 RVA: 0x0001C26C File Offset: 0x0001A46C
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

		// Token: 0x06000D7D RID: 3453 RVA: 0x0001C2B0 File Offset: 0x0001A4B0
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x0001C2C8 File Offset: 0x0001A4C8
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06000D7F RID: 3455 RVA: 0x0001C2D4 File Offset: 0x0001A4D4
		// (set) Token: 0x06000D80 RID: 3456 RVA: 0x0001C300 File Offset: 0x0001A500
		[ProtoMember(7, IsRequired = false, Name = "dropperTemplateID", DataFormat = DataFormat.TwosComplement)]
		public uint dropperTemplateID
		{
			get
			{
				return this._dropperTemplateID ?? 0U;
			}
			set
			{
				this._dropperTemplateID = new uint?(value);
			}
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06000D81 RID: 3457 RVA: 0x0001C310 File Offset: 0x0001A510
		// (set) Token: 0x06000D82 RID: 3458 RVA: 0x0001C330 File Offset: 0x0001A530
		[XmlIgnore]
		[Browsable(false)]
		public bool dropperTemplateIDSpecified
		{
			get
			{
				return this._dropperTemplateID != null;
			}
			set
			{
				bool flag = value == (this._dropperTemplateID == null);
				if (flag)
				{
					this._dropperTemplateID = (value ? new uint?(this.dropperTemplateID) : null);
				}
			}
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x0001C374 File Offset: 0x0001A574
		private bool ShouldSerializedropperTemplateID()
		{
			return this.dropperTemplateIDSpecified;
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x0001C38C File Offset: 0x0001A58C
		private void ResetdropperTemplateID()
		{
			this.dropperTemplateIDSpecified = false;
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06000D85 RID: 3461 RVA: 0x0001C398 File Offset: 0x0001A598
		// (set) Token: 0x06000D86 RID: 3462 RVA: 0x0001C3C5 File Offset: 0x0001A5C5
		[ProtoMember(8, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06000D87 RID: 3463 RVA: 0x0001C3D4 File Offset: 0x0001A5D4
		// (set) Token: 0x06000D88 RID: 3464 RVA: 0x0001C3F4 File Offset: 0x0001A5F4
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x0001C438 File Offset: 0x0001A638
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x0001C450 File Offset: 0x0001A650
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06000D8B RID: 3467 RVA: 0x0001C45C File Offset: 0x0001A65C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400035E RID: 862
		private int? _waveid;

		// Token: 0x0400035F RID: 863
		private int? _type;

		// Token: 0x04000360 RID: 864
		private uint? _id;

		// Token: 0x04000361 RID: 865
		private uint? _count;

		// Token: 0x04000362 RID: 866
		private Vec3 _pos = null;

		// Token: 0x04000363 RID: 867
		private uint? _index;

		// Token: 0x04000364 RID: 868
		private uint? _dropperTemplateID;

		// Token: 0x04000365 RID: 869
		private ulong? _roleid;

		// Token: 0x04000366 RID: 870
		private IExtension extensionObject;
	}
}
