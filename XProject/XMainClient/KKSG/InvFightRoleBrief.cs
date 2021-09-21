using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006DD RID: 1757
	[ProtoContract(Name = "InvFightRoleBrief")]
	[Serializable]
	public class InvFightRoleBrief : IExtensible
	{
		// Token: 0x17002511 RID: 9489
		// (get) Token: 0x0600750F RID: 29967 RVA: 0x000DFF78 File Offset: 0x000DE178
		// (set) Token: 0x06007510 RID: 29968 RVA: 0x000DFFA5 File Offset: 0x000DE1A5
		[ProtoMember(1, IsRequired = false, Name = "invID", DataFormat = DataFormat.TwosComplement)]
		public ulong invID
		{
			get
			{
				return this._invID ?? 0UL;
			}
			set
			{
				this._invID = new ulong?(value);
			}
		}

		// Token: 0x17002512 RID: 9490
		// (get) Token: 0x06007511 RID: 29969 RVA: 0x000DFFB4 File Offset: 0x000DE1B4
		// (set) Token: 0x06007512 RID: 29970 RVA: 0x000DFFD4 File Offset: 0x000DE1D4
		[XmlIgnore]
		[Browsable(false)]
		public bool invIDSpecified
		{
			get
			{
				return this._invID != null;
			}
			set
			{
				bool flag = value == (this._invID == null);
				if (flag)
				{
					this._invID = (value ? new ulong?(this.invID) : null);
				}
			}
		}

		// Token: 0x06007513 RID: 29971 RVA: 0x000E0018 File Offset: 0x000DE218
		private bool ShouldSerializeinvID()
		{
			return this.invIDSpecified;
		}

		// Token: 0x06007514 RID: 29972 RVA: 0x000E0030 File Offset: 0x000DE230
		private void ResetinvID()
		{
			this.invIDSpecified = false;
		}

		// Token: 0x17002513 RID: 9491
		// (get) Token: 0x06007515 RID: 29973 RVA: 0x000E003C File Offset: 0x000DE23C
		// (set) Token: 0x06007516 RID: 29974 RVA: 0x000E0068 File Offset: 0x000DE268
		[ProtoMember(2, IsRequired = false, Name = "title", DataFormat = DataFormat.TwosComplement)]
		public uint title
		{
			get
			{
				return this._title ?? 0U;
			}
			set
			{
				this._title = new uint?(value);
			}
		}

		// Token: 0x17002514 RID: 9492
		// (get) Token: 0x06007517 RID: 29975 RVA: 0x000E0078 File Offset: 0x000DE278
		// (set) Token: 0x06007518 RID: 29976 RVA: 0x000E0098 File Offset: 0x000DE298
		[XmlIgnore]
		[Browsable(false)]
		public bool titleSpecified
		{
			get
			{
				return this._title != null;
			}
			set
			{
				bool flag = value == (this._title == null);
				if (flag)
				{
					this._title = (value ? new uint?(this.title) : null);
				}
			}
		}

		// Token: 0x06007519 RID: 29977 RVA: 0x000E00DC File Offset: 0x000DE2DC
		private bool ShouldSerializetitle()
		{
			return this.titleSpecified;
		}

		// Token: 0x0600751A RID: 29978 RVA: 0x000E00F4 File Offset: 0x000DE2F4
		private void Resettitle()
		{
			this.titleSpecified = false;
		}

		// Token: 0x17002515 RID: 9493
		// (get) Token: 0x0600751B RID: 29979 RVA: 0x000E0100 File Offset: 0x000DE300
		// (set) Token: 0x0600751C RID: 29980 RVA: 0x000E0121 File Offset: 0x000DE321
		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17002516 RID: 9494
		// (get) Token: 0x0600751D RID: 29981 RVA: 0x000E012C File Offset: 0x000DE32C
		// (set) Token: 0x0600751E RID: 29982 RVA: 0x000E0148 File Offset: 0x000DE348
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x0600751F RID: 29983 RVA: 0x000E0178 File Offset: 0x000DE378
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007520 RID: 29984 RVA: 0x000E0190 File Offset: 0x000DE390
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002517 RID: 9495
		// (get) Token: 0x06007521 RID: 29985 RVA: 0x000E019C File Offset: 0x000DE39C
		// (set) Token: 0x06007522 RID: 29986 RVA: 0x000E01C8 File Offset: 0x000DE3C8
		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x17002518 RID: 9496
		// (get) Token: 0x06007523 RID: 29987 RVA: 0x000E01D8 File Offset: 0x000DE3D8
		// (set) Token: 0x06007524 RID: 29988 RVA: 0x000E01F8 File Offset: 0x000DE3F8
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06007525 RID: 29989 RVA: 0x000E023C File Offset: 0x000DE43C
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06007526 RID: 29990 RVA: 0x000E0254 File Offset: 0x000DE454
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17002519 RID: 9497
		// (get) Token: 0x06007527 RID: 29991 RVA: 0x000E0260 File Offset: 0x000DE460
		// (set) Token: 0x06007528 RID: 29992 RVA: 0x000E028C File Offset: 0x000DE48C
		[ProtoMember(5, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		// Token: 0x1700251A RID: 9498
		// (get) Token: 0x06007529 RID: 29993 RVA: 0x000E029C File Offset: 0x000DE49C
		// (set) Token: 0x0600752A RID: 29994 RVA: 0x000E02BC File Offset: 0x000DE4BC
		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		// Token: 0x0600752B RID: 29995 RVA: 0x000E0300 File Offset: 0x000DE500
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x0600752C RID: 29996 RVA: 0x000E0318 File Offset: 0x000DE518
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x1700251B RID: 9499
		// (get) Token: 0x0600752D RID: 29997 RVA: 0x000E0324 File Offset: 0x000DE524
		// (set) Token: 0x0600752E RID: 29998 RVA: 0x000E0350 File Offset: 0x000DE550
		[ProtoMember(6, IsRequired = false, Name = "ctime", DataFormat = DataFormat.TwosComplement)]
		public uint ctime
		{
			get
			{
				return this._ctime ?? 0U;
			}
			set
			{
				this._ctime = new uint?(value);
			}
		}

		// Token: 0x1700251C RID: 9500
		// (get) Token: 0x0600752F RID: 29999 RVA: 0x000E0360 File Offset: 0x000DE560
		// (set) Token: 0x06007530 RID: 30000 RVA: 0x000E0380 File Offset: 0x000DE580
		[XmlIgnore]
		[Browsable(false)]
		public bool ctimeSpecified
		{
			get
			{
				return this._ctime != null;
			}
			set
			{
				bool flag = value == (this._ctime == null);
				if (flag)
				{
					this._ctime = (value ? new uint?(this.ctime) : null);
				}
			}
		}

		// Token: 0x06007531 RID: 30001 RVA: 0x000E03C4 File Offset: 0x000DE5C4
		private bool ShouldSerializectime()
		{
			return this.ctimeSpecified;
		}

		// Token: 0x06007532 RID: 30002 RVA: 0x000E03DC File Offset: 0x000DE5DC
		private void Resetctime()
		{
			this.ctimeSpecified = false;
		}

		// Token: 0x1700251D RID: 9501
		// (get) Token: 0x06007533 RID: 30003 RVA: 0x000E03E8 File Offset: 0x000DE5E8
		// (set) Token: 0x06007534 RID: 30004 RVA: 0x000E0414 File Offset: 0x000DE614
		[ProtoMember(7, IsRequired = false, Name = "isplatfriend", DataFormat = DataFormat.Default)]
		public bool isplatfriend
		{
			get
			{
				return this._isplatfriend ?? false;
			}
			set
			{
				this._isplatfriend = new bool?(value);
			}
		}

		// Token: 0x1700251E RID: 9502
		// (get) Token: 0x06007535 RID: 30005 RVA: 0x000E0424 File Offset: 0x000DE624
		// (set) Token: 0x06007536 RID: 30006 RVA: 0x000E0444 File Offset: 0x000DE644
		[XmlIgnore]
		[Browsable(false)]
		public bool isplatfriendSpecified
		{
			get
			{
				return this._isplatfriend != null;
			}
			set
			{
				bool flag = value == (this._isplatfriend == null);
				if (flag)
				{
					this._isplatfriend = (value ? new bool?(this.isplatfriend) : null);
				}
			}
		}

		// Token: 0x06007537 RID: 30007 RVA: 0x000E0488 File Offset: 0x000DE688
		private bool ShouldSerializeisplatfriend()
		{
			return this.isplatfriendSpecified;
		}

		// Token: 0x06007538 RID: 30008 RVA: 0x000E04A0 File Offset: 0x000DE6A0
		private void Resetisplatfriend()
		{
			this.isplatfriendSpecified = false;
		}

		// Token: 0x06007539 RID: 30009 RVA: 0x000E04AC File Offset: 0x000DE6AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BCB RID: 7115
		private ulong? _invID;

		// Token: 0x04001BCC RID: 7116
		private uint? _title;

		// Token: 0x04001BCD RID: 7117
		private string _name;

		// Token: 0x04001BCE RID: 7118
		private uint? _level;

		// Token: 0x04001BCF RID: 7119
		private uint? _profession;

		// Token: 0x04001BD0 RID: 7120
		private uint? _ctime;

		// Token: 0x04001BD1 RID: 7121
		private bool? _isplatfriend;

		// Token: 0x04001BD2 RID: 7122
		private IExtension extensionObject;
	}
}
