using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200072D RID: 1837
	[ProtoContract(Name = "DragonGuildMembersInfo")]
	[Serializable]
	public class DragonGuildMembersInfo : IExtensible
	{
		// Token: 0x17002819 RID: 10265
		// (get) Token: 0x06007E7A RID: 32378 RVA: 0x000F1D20 File Offset: 0x000EFF20
		// (set) Token: 0x06007E7B RID: 32379 RVA: 0x000F1D41 File Offset: 0x000EFF41
		[ProtoMember(1, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x1700281A RID: 10266
		// (get) Token: 0x06007E7C RID: 32380 RVA: 0x000F1D4C File Offset: 0x000EFF4C
		// (set) Token: 0x06007E7D RID: 32381 RVA: 0x000F1D68 File Offset: 0x000EFF68
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

		// Token: 0x06007E7E RID: 32382 RVA: 0x000F1D98 File Offset: 0x000EFF98
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007E7F RID: 32383 RVA: 0x000F1DB0 File Offset: 0x000EFFB0
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700281B RID: 10267
		// (get) Token: 0x06007E80 RID: 32384 RVA: 0x000F1DBC File Offset: 0x000EFFBC
		// (set) Token: 0x06007E81 RID: 32385 RVA: 0x000F1DE9 File Offset: 0x000EFFE9
		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700281C RID: 10268
		// (get) Token: 0x06007E82 RID: 32386 RVA: 0x000F1DF8 File Offset: 0x000EFFF8
		// (set) Token: 0x06007E83 RID: 32387 RVA: 0x000F1E18 File Offset: 0x000F0018
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

		// Token: 0x06007E84 RID: 32388 RVA: 0x000F1E5C File Offset: 0x000F005C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007E85 RID: 32389 RVA: 0x000F1E74 File Offset: 0x000F0074
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700281D RID: 10269
		// (get) Token: 0x06007E86 RID: 32390 RVA: 0x000F1E80 File Offset: 0x000F0080
		// (set) Token: 0x06007E87 RID: 32391 RVA: 0x000F1EAC File Offset: 0x000F00AC
		[ProtoMember(3, IsRequired = false, Name = "position", DataFormat = DataFormat.TwosComplement)]
		public int position
		{
			get
			{
				return this._position ?? 0;
			}
			set
			{
				this._position = new int?(value);
			}
		}

		// Token: 0x1700281E RID: 10270
		// (get) Token: 0x06007E88 RID: 32392 RVA: 0x000F1EBC File Offset: 0x000F00BC
		// (set) Token: 0x06007E89 RID: 32393 RVA: 0x000F1EDC File Offset: 0x000F00DC
		[XmlIgnore]
		[Browsable(false)]
		public bool positionSpecified
		{
			get
			{
				return this._position != null;
			}
			set
			{
				bool flag = value == (this._position == null);
				if (flag)
				{
					this._position = (value ? new int?(this.position) : null);
				}
			}
		}

		// Token: 0x06007E8A RID: 32394 RVA: 0x000F1F20 File Offset: 0x000F0120
		private bool ShouldSerializeposition()
		{
			return this.positionSpecified;
		}

		// Token: 0x06007E8B RID: 32395 RVA: 0x000F1F38 File Offset: 0x000F0138
		private void Resetposition()
		{
			this.positionSpecified = false;
		}

		// Token: 0x1700281F RID: 10271
		// (get) Token: 0x06007E8C RID: 32396 RVA: 0x000F1F44 File Offset: 0x000F0144
		// (set) Token: 0x06007E8D RID: 32397 RVA: 0x000F1F70 File Offset: 0x000F0170
		[ProtoMember(4, IsRequired = false, Name = "contribute", DataFormat = DataFormat.TwosComplement)]
		public uint contribute
		{
			get
			{
				return this._contribute ?? 0U;
			}
			set
			{
				this._contribute = new uint?(value);
			}
		}

		// Token: 0x17002820 RID: 10272
		// (get) Token: 0x06007E8E RID: 32398 RVA: 0x000F1F80 File Offset: 0x000F0180
		// (set) Token: 0x06007E8F RID: 32399 RVA: 0x000F1FA0 File Offset: 0x000F01A0
		[XmlIgnore]
		[Browsable(false)]
		public bool contributeSpecified
		{
			get
			{
				return this._contribute != null;
			}
			set
			{
				bool flag = value == (this._contribute == null);
				if (flag)
				{
					this._contribute = (value ? new uint?(this.contribute) : null);
				}
			}
		}

		// Token: 0x06007E90 RID: 32400 RVA: 0x000F1FE4 File Offset: 0x000F01E4
		private bool ShouldSerializecontribute()
		{
			return this.contributeSpecified;
		}

		// Token: 0x06007E91 RID: 32401 RVA: 0x000F1FFC File Offset: 0x000F01FC
		private void Resetcontribute()
		{
			this.contributeSpecified = false;
		}

		// Token: 0x17002821 RID: 10273
		// (get) Token: 0x06007E92 RID: 32402 RVA: 0x000F2008 File Offset: 0x000F0208
		// (set) Token: 0x06007E93 RID: 32403 RVA: 0x000F2034 File Offset: 0x000F0234
		[ProtoMember(5, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public uint ppt
		{
			get
			{
				return this._ppt ?? 0U;
			}
			set
			{
				this._ppt = new uint?(value);
			}
		}

		// Token: 0x17002822 RID: 10274
		// (get) Token: 0x06007E94 RID: 32404 RVA: 0x000F2044 File Offset: 0x000F0244
		// (set) Token: 0x06007E95 RID: 32405 RVA: 0x000F2064 File Offset: 0x000F0264
		[XmlIgnore]
		[Browsable(false)]
		public bool pptSpecified
		{
			get
			{
				return this._ppt != null;
			}
			set
			{
				bool flag = value == (this._ppt == null);
				if (flag)
				{
					this._ppt = (value ? new uint?(this.ppt) : null);
				}
			}
		}

		// Token: 0x06007E96 RID: 32406 RVA: 0x000F20A8 File Offset: 0x000F02A8
		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		// Token: 0x06007E97 RID: 32407 RVA: 0x000F20C0 File Offset: 0x000F02C0
		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		// Token: 0x17002823 RID: 10275
		// (get) Token: 0x06007E98 RID: 32408 RVA: 0x000F20CC File Offset: 0x000F02CC
		// (set) Token: 0x06007E99 RID: 32409 RVA: 0x000F20F8 File Offset: 0x000F02F8
		[ProtoMember(6, IsRequired = false, Name = "flag", DataFormat = DataFormat.TwosComplement)]
		public uint flag
		{
			get
			{
				return this._flag ?? 0U;
			}
			set
			{
				this._flag = new uint?(value);
			}
		}

		// Token: 0x17002824 RID: 10276
		// (get) Token: 0x06007E9A RID: 32410 RVA: 0x000F2108 File Offset: 0x000F0308
		// (set) Token: 0x06007E9B RID: 32411 RVA: 0x000F2128 File Offset: 0x000F0328
		[XmlIgnore]
		[Browsable(false)]
		public bool flagSpecified
		{
			get
			{
				return this._flag != null;
			}
			set
			{
				bool flag = value == (this._flag == null);
				if (flag)
				{
					this._flag = (value ? new uint?(this.flag) : null);
				}
			}
		}

		// Token: 0x06007E9C RID: 32412 RVA: 0x000F216C File Offset: 0x000F036C
		private bool ShouldSerializeflag()
		{
			return this.flagSpecified;
		}

		// Token: 0x06007E9D RID: 32413 RVA: 0x000F2184 File Offset: 0x000F0384
		private void Resetflag()
		{
			this.flagSpecified = false;
		}

		// Token: 0x17002825 RID: 10277
		// (get) Token: 0x06007E9E RID: 32414 RVA: 0x000F2190 File Offset: 0x000F0390
		// (set) Token: 0x06007E9F RID: 32415 RVA: 0x000F21BC File Offset: 0x000F03BC
		[ProtoMember(7, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002826 RID: 10278
		// (get) Token: 0x06007EA0 RID: 32416 RVA: 0x000F21CC File Offset: 0x000F03CC
		// (set) Token: 0x06007EA1 RID: 32417 RVA: 0x000F21EC File Offset: 0x000F03EC
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

		// Token: 0x06007EA2 RID: 32418 RVA: 0x000F2230 File Offset: 0x000F0430
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06007EA3 RID: 32419 RVA: 0x000F2248 File Offset: 0x000F0448
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17002827 RID: 10279
		// (get) Token: 0x06007EA4 RID: 32420 RVA: 0x000F2254 File Offset: 0x000F0454
		// (set) Token: 0x06007EA5 RID: 32421 RVA: 0x000F2280 File Offset: 0x000F0480
		[ProtoMember(8, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public RoleType profession
		{
			get
			{
				return this._profession ?? RoleType.Role_INVALID;
			}
			set
			{
				this._profession = new RoleType?(value);
			}
		}

		// Token: 0x17002828 RID: 10280
		// (get) Token: 0x06007EA6 RID: 32422 RVA: 0x000F2290 File Offset: 0x000F0490
		// (set) Token: 0x06007EA7 RID: 32423 RVA: 0x000F22B0 File Offset: 0x000F04B0
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
					this._profession = (value ? new RoleType?(this.profession) : null);
				}
			}
		}

		// Token: 0x06007EA8 RID: 32424 RVA: 0x000F22F4 File Offset: 0x000F04F4
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06007EA9 RID: 32425 RVA: 0x000F230C File Offset: 0x000F050C
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x17002829 RID: 10281
		// (get) Token: 0x06007EAA RID: 32426 RVA: 0x000F2318 File Offset: 0x000F0518
		// (set) Token: 0x06007EAB RID: 32427 RVA: 0x000F2344 File Offset: 0x000F0544
		[ProtoMember(9, IsRequired = false, Name = "lastlogin", DataFormat = DataFormat.TwosComplement)]
		public uint lastlogin
		{
			get
			{
				return this._lastlogin ?? 0U;
			}
			set
			{
				this._lastlogin = new uint?(value);
			}
		}

		// Token: 0x1700282A RID: 10282
		// (get) Token: 0x06007EAC RID: 32428 RVA: 0x000F2354 File Offset: 0x000F0554
		// (set) Token: 0x06007EAD RID: 32429 RVA: 0x000F2374 File Offset: 0x000F0574
		[XmlIgnore]
		[Browsable(false)]
		public bool lastloginSpecified
		{
			get
			{
				return this._lastlogin != null;
			}
			set
			{
				bool flag = value == (this._lastlogin == null);
				if (flag)
				{
					this._lastlogin = (value ? new uint?(this.lastlogin) : null);
				}
			}
		}

		// Token: 0x06007EAE RID: 32430 RVA: 0x000F23B8 File Offset: 0x000F05B8
		private bool ShouldSerializelastlogin()
		{
			return this.lastloginSpecified;
		}

		// Token: 0x06007EAF RID: 32431 RVA: 0x000F23D0 File Offset: 0x000F05D0
		private void Resetlastlogin()
		{
			this.lastloginSpecified = false;
		}

		// Token: 0x1700282B RID: 10283
		// (get) Token: 0x06007EB0 RID: 32432 RVA: 0x000F23DC File Offset: 0x000F05DC
		// (set) Token: 0x06007EB1 RID: 32433 RVA: 0x000F2408 File Offset: 0x000F0608
		[ProtoMember(10, IsRequired = false, Name = "vip", DataFormat = DataFormat.TwosComplement)]
		public uint vip
		{
			get
			{
				return this._vip ?? 0U;
			}
			set
			{
				this._vip = new uint?(value);
			}
		}

		// Token: 0x1700282C RID: 10284
		// (get) Token: 0x06007EB2 RID: 32434 RVA: 0x000F2418 File Offset: 0x000F0618
		// (set) Token: 0x06007EB3 RID: 32435 RVA: 0x000F2438 File Offset: 0x000F0638
		[XmlIgnore]
		[Browsable(false)]
		public bool vipSpecified
		{
			get
			{
				return this._vip != null;
			}
			set
			{
				bool flag = value == (this._vip == null);
				if (flag)
				{
					this._vip = (value ? new uint?(this.vip) : null);
				}
			}
		}

		// Token: 0x06007EB4 RID: 32436 RVA: 0x000F247C File Offset: 0x000F067C
		private bool ShouldSerializevip()
		{
			return this.vipSpecified;
		}

		// Token: 0x06007EB5 RID: 32437 RVA: 0x000F2494 File Offset: 0x000F0694
		private void Resetvip()
		{
			this.vipSpecified = false;
		}

		// Token: 0x1700282D RID: 10285
		// (get) Token: 0x06007EB6 RID: 32438 RVA: 0x000F24A0 File Offset: 0x000F06A0
		// (set) Token: 0x06007EB7 RID: 32439 RVA: 0x000F24CC File Offset: 0x000F06CC
		[ProtoMember(11, IsRequired = false, Name = "isonline", DataFormat = DataFormat.Default)]
		public bool isonline
		{
			get
			{
				return this._isonline ?? false;
			}
			set
			{
				this._isonline = new bool?(value);
			}
		}

		// Token: 0x1700282E RID: 10286
		// (get) Token: 0x06007EB8 RID: 32440 RVA: 0x000F24DC File Offset: 0x000F06DC
		// (set) Token: 0x06007EB9 RID: 32441 RVA: 0x000F24FC File Offset: 0x000F06FC
		[XmlIgnore]
		[Browsable(false)]
		public bool isonlineSpecified
		{
			get
			{
				return this._isonline != null;
			}
			set
			{
				bool flag = value == (this._isonline == null);
				if (flag)
				{
					this._isonline = (value ? new bool?(this.isonline) : null);
				}
			}
		}

		// Token: 0x06007EBA RID: 32442 RVA: 0x000F2540 File Offset: 0x000F0740
		private bool ShouldSerializeisonline()
		{
			return this.isonlineSpecified;
		}

		// Token: 0x06007EBB RID: 32443 RVA: 0x000F2558 File Offset: 0x000F0758
		private void Resetisonline()
		{
			this.isonlineSpecified = false;
		}

		// Token: 0x1700282F RID: 10287
		// (get) Token: 0x06007EBC RID: 32444 RVA: 0x000F2564 File Offset: 0x000F0764
		// (set) Token: 0x06007EBD RID: 32445 RVA: 0x000F2590 File Offset: 0x000F0790
		[ProtoMember(12, IsRequired = false, Name = "activity", DataFormat = DataFormat.TwosComplement)]
		public uint activity
		{
			get
			{
				return this._activity ?? 0U;
			}
			set
			{
				this._activity = new uint?(value);
			}
		}

		// Token: 0x17002830 RID: 10288
		// (get) Token: 0x06007EBE RID: 32446 RVA: 0x000F25A0 File Offset: 0x000F07A0
		// (set) Token: 0x06007EBF RID: 32447 RVA: 0x000F25C0 File Offset: 0x000F07C0
		[XmlIgnore]
		[Browsable(false)]
		public bool activitySpecified
		{
			get
			{
				return this._activity != null;
			}
			set
			{
				bool flag = value == (this._activity == null);
				if (flag)
				{
					this._activity = (value ? new uint?(this.activity) : null);
				}
			}
		}

		// Token: 0x06007EC0 RID: 32448 RVA: 0x000F2604 File Offset: 0x000F0804
		private bool ShouldSerializeactivity()
		{
			return this.activitySpecified;
		}

		// Token: 0x06007EC1 RID: 32449 RVA: 0x000F261C File Offset: 0x000F081C
		private void Resetactivity()
		{
			this.activitySpecified = false;
		}

		// Token: 0x17002831 RID: 10289
		// (get) Token: 0x06007EC2 RID: 32450 RVA: 0x000F2628 File Offset: 0x000F0828
		// (set) Token: 0x06007EC3 RID: 32451 RVA: 0x000F2654 File Offset: 0x000F0854
		[ProtoMember(13, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
		public uint paymemberid
		{
			get
			{
				return this._paymemberid ?? 0U;
			}
			set
			{
				this._paymemberid = new uint?(value);
			}
		}

		// Token: 0x17002832 RID: 10290
		// (get) Token: 0x06007EC4 RID: 32452 RVA: 0x000F2664 File Offset: 0x000F0864
		// (set) Token: 0x06007EC5 RID: 32453 RVA: 0x000F2684 File Offset: 0x000F0884
		[XmlIgnore]
		[Browsable(false)]
		public bool paymemberidSpecified
		{
			get
			{
				return this._paymemberid != null;
			}
			set
			{
				bool flag = value == (this._paymemberid == null);
				if (flag)
				{
					this._paymemberid = (value ? new uint?(this.paymemberid) : null);
				}
			}
		}

		// Token: 0x06007EC6 RID: 32454 RVA: 0x000F26C8 File Offset: 0x000F08C8
		private bool ShouldSerializepaymemberid()
		{
			return this.paymemberidSpecified;
		}

		// Token: 0x06007EC7 RID: 32455 RVA: 0x000F26E0 File Offset: 0x000F08E0
		private void Resetpaymemberid()
		{
			this.paymemberidSpecified = false;
		}

		// Token: 0x17002833 RID: 10291
		// (get) Token: 0x06007EC8 RID: 32456 RVA: 0x000F26EC File Offset: 0x000F08EC
		// (set) Token: 0x06007EC9 RID: 32457 RVA: 0x000F2718 File Offset: 0x000F0918
		[ProtoMember(14, IsRequired = false, Name = "title", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002834 RID: 10292
		// (get) Token: 0x06007ECA RID: 32458 RVA: 0x000F2728 File Offset: 0x000F0928
		// (set) Token: 0x06007ECB RID: 32459 RVA: 0x000F2748 File Offset: 0x000F0948
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

		// Token: 0x06007ECC RID: 32460 RVA: 0x000F278C File Offset: 0x000F098C
		private bool ShouldSerializetitle()
		{
			return this.titleSpecified;
		}

		// Token: 0x06007ECD RID: 32461 RVA: 0x000F27A4 File Offset: 0x000F09A4
		private void Resettitle()
		{
			this.titleSpecified = false;
		}

		// Token: 0x06007ECE RID: 32462 RVA: 0x000F27B0 File Offset: 0x000F09B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DB9 RID: 7609
		private string _name;

		// Token: 0x04001DBA RID: 7610
		private ulong? _roleid;

		// Token: 0x04001DBB RID: 7611
		private int? _position;

		// Token: 0x04001DBC RID: 7612
		private uint? _contribute;

		// Token: 0x04001DBD RID: 7613
		private uint? _ppt;

		// Token: 0x04001DBE RID: 7614
		private uint? _flag;

		// Token: 0x04001DBF RID: 7615
		private uint? _level;

		// Token: 0x04001DC0 RID: 7616
		private RoleType? _profession;

		// Token: 0x04001DC1 RID: 7617
		private uint? _lastlogin;

		// Token: 0x04001DC2 RID: 7618
		private uint? _vip;

		// Token: 0x04001DC3 RID: 7619
		private bool? _isonline;

		// Token: 0x04001DC4 RID: 7620
		private uint? _activity;

		// Token: 0x04001DC5 RID: 7621
		private uint? _paymemberid;

		// Token: 0x04001DC6 RID: 7622
		private uint? _title;

		// Token: 0x04001DC7 RID: 7623
		private IExtension extensionObject;
	}
}
