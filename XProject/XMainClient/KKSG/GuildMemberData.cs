using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005B7 RID: 1463
	[ProtoContract(Name = "GuildMemberData")]
	[Serializable]
	public class GuildMemberData : IExtensible
	{
		// Token: 0x170018F0 RID: 6384
		// (get) Token: 0x060050BD RID: 20669 RVA: 0x00099928 File Offset: 0x00097B28
		// (set) Token: 0x060050BE RID: 20670 RVA: 0x00099949 File Offset: 0x00097B49
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

		// Token: 0x170018F1 RID: 6385
		// (get) Token: 0x060050BF RID: 20671 RVA: 0x00099954 File Offset: 0x00097B54
		// (set) Token: 0x060050C0 RID: 20672 RVA: 0x00099970 File Offset: 0x00097B70
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

		// Token: 0x060050C1 RID: 20673 RVA: 0x000999A0 File Offset: 0x00097BA0
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060050C2 RID: 20674 RVA: 0x000999B8 File Offset: 0x00097BB8
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170018F2 RID: 6386
		// (get) Token: 0x060050C3 RID: 20675 RVA: 0x000999C4 File Offset: 0x00097BC4
		// (set) Token: 0x060050C4 RID: 20676 RVA: 0x000999F1 File Offset: 0x00097BF1
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

		// Token: 0x170018F3 RID: 6387
		// (get) Token: 0x060050C5 RID: 20677 RVA: 0x00099A00 File Offset: 0x00097C00
		// (set) Token: 0x060050C6 RID: 20678 RVA: 0x00099A20 File Offset: 0x00097C20
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

		// Token: 0x060050C7 RID: 20679 RVA: 0x00099A64 File Offset: 0x00097C64
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x060050C8 RID: 20680 RVA: 0x00099A7C File Offset: 0x00097C7C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170018F4 RID: 6388
		// (get) Token: 0x060050C9 RID: 20681 RVA: 0x00099A88 File Offset: 0x00097C88
		// (set) Token: 0x060050CA RID: 20682 RVA: 0x00099AB4 File Offset: 0x00097CB4
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

		// Token: 0x170018F5 RID: 6389
		// (get) Token: 0x060050CB RID: 20683 RVA: 0x00099AC4 File Offset: 0x00097CC4
		// (set) Token: 0x060050CC RID: 20684 RVA: 0x00099AE4 File Offset: 0x00097CE4
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

		// Token: 0x060050CD RID: 20685 RVA: 0x00099B28 File Offset: 0x00097D28
		private bool ShouldSerializeposition()
		{
			return this.positionSpecified;
		}

		// Token: 0x060050CE RID: 20686 RVA: 0x00099B40 File Offset: 0x00097D40
		private void Resetposition()
		{
			this.positionSpecified = false;
		}

		// Token: 0x170018F6 RID: 6390
		// (get) Token: 0x060050CF RID: 20687 RVA: 0x00099B4C File Offset: 0x00097D4C
		// (set) Token: 0x060050D0 RID: 20688 RVA: 0x00099B78 File Offset: 0x00097D78
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

		// Token: 0x170018F7 RID: 6391
		// (get) Token: 0x060050D1 RID: 20689 RVA: 0x00099B88 File Offset: 0x00097D88
		// (set) Token: 0x060050D2 RID: 20690 RVA: 0x00099BA8 File Offset: 0x00097DA8
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

		// Token: 0x060050D3 RID: 20691 RVA: 0x00099BEC File Offset: 0x00097DEC
		private bool ShouldSerializecontribute()
		{
			return this.contributeSpecified;
		}

		// Token: 0x060050D4 RID: 20692 RVA: 0x00099C04 File Offset: 0x00097E04
		private void Resetcontribute()
		{
			this.contributeSpecified = false;
		}

		// Token: 0x170018F8 RID: 6392
		// (get) Token: 0x060050D5 RID: 20693 RVA: 0x00099C10 File Offset: 0x00097E10
		// (set) Token: 0x060050D6 RID: 20694 RVA: 0x00099C3C File Offset: 0x00097E3C
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

		// Token: 0x170018F9 RID: 6393
		// (get) Token: 0x060050D7 RID: 20695 RVA: 0x00099C4C File Offset: 0x00097E4C
		// (set) Token: 0x060050D8 RID: 20696 RVA: 0x00099C6C File Offset: 0x00097E6C
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

		// Token: 0x060050D9 RID: 20697 RVA: 0x00099CB0 File Offset: 0x00097EB0
		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		// Token: 0x060050DA RID: 20698 RVA: 0x00099CC8 File Offset: 0x00097EC8
		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		// Token: 0x170018FA RID: 6394
		// (get) Token: 0x060050DB RID: 20699 RVA: 0x00099CD4 File Offset: 0x00097ED4
		// (set) Token: 0x060050DC RID: 20700 RVA: 0x00099D00 File Offset: 0x00097F00
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

		// Token: 0x170018FB RID: 6395
		// (get) Token: 0x060050DD RID: 20701 RVA: 0x00099D10 File Offset: 0x00097F10
		// (set) Token: 0x060050DE RID: 20702 RVA: 0x00099D30 File Offset: 0x00097F30
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

		// Token: 0x060050DF RID: 20703 RVA: 0x00099D74 File Offset: 0x00097F74
		private bool ShouldSerializeflag()
		{
			return this.flagSpecified;
		}

		// Token: 0x060050E0 RID: 20704 RVA: 0x00099D8C File Offset: 0x00097F8C
		private void Resetflag()
		{
			this.flagSpecified = false;
		}

		// Token: 0x170018FC RID: 6396
		// (get) Token: 0x060050E1 RID: 20705 RVA: 0x00099D98 File Offset: 0x00097F98
		// (set) Token: 0x060050E2 RID: 20706 RVA: 0x00099DC4 File Offset: 0x00097FC4
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

		// Token: 0x170018FD RID: 6397
		// (get) Token: 0x060050E3 RID: 20707 RVA: 0x00099DD4 File Offset: 0x00097FD4
		// (set) Token: 0x060050E4 RID: 20708 RVA: 0x00099DF4 File Offset: 0x00097FF4
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

		// Token: 0x060050E5 RID: 20709 RVA: 0x00099E38 File Offset: 0x00098038
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x060050E6 RID: 20710 RVA: 0x00099E50 File Offset: 0x00098050
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x170018FE RID: 6398
		// (get) Token: 0x060050E7 RID: 20711 RVA: 0x00099E5C File Offset: 0x0009805C
		// (set) Token: 0x060050E8 RID: 20712 RVA: 0x00099E88 File Offset: 0x00098088
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

		// Token: 0x170018FF RID: 6399
		// (get) Token: 0x060050E9 RID: 20713 RVA: 0x00099E98 File Offset: 0x00098098
		// (set) Token: 0x060050EA RID: 20714 RVA: 0x00099EB8 File Offset: 0x000980B8
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

		// Token: 0x060050EB RID: 20715 RVA: 0x00099EFC File Offset: 0x000980FC
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x060050EC RID: 20716 RVA: 0x00099F14 File Offset: 0x00098114
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x17001900 RID: 6400
		// (get) Token: 0x060050ED RID: 20717 RVA: 0x00099F20 File Offset: 0x00098120
		// (set) Token: 0x060050EE RID: 20718 RVA: 0x00099F4C File Offset: 0x0009814C
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

		// Token: 0x17001901 RID: 6401
		// (get) Token: 0x060050EF RID: 20719 RVA: 0x00099F5C File Offset: 0x0009815C
		// (set) Token: 0x060050F0 RID: 20720 RVA: 0x00099F7C File Offset: 0x0009817C
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

		// Token: 0x060050F1 RID: 20721 RVA: 0x00099FC0 File Offset: 0x000981C0
		private bool ShouldSerializelastlogin()
		{
			return this.lastloginSpecified;
		}

		// Token: 0x060050F2 RID: 20722 RVA: 0x00099FD8 File Offset: 0x000981D8
		private void Resetlastlogin()
		{
			this.lastloginSpecified = false;
		}

		// Token: 0x17001902 RID: 6402
		// (get) Token: 0x060050F3 RID: 20723 RVA: 0x00099FE4 File Offset: 0x000981E4
		// (set) Token: 0x060050F4 RID: 20724 RVA: 0x0009A010 File Offset: 0x00098210
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

		// Token: 0x17001903 RID: 6403
		// (get) Token: 0x060050F5 RID: 20725 RVA: 0x0009A020 File Offset: 0x00098220
		// (set) Token: 0x060050F6 RID: 20726 RVA: 0x0009A040 File Offset: 0x00098240
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

		// Token: 0x060050F7 RID: 20727 RVA: 0x0009A084 File Offset: 0x00098284
		private bool ShouldSerializevip()
		{
			return this.vipSpecified;
		}

		// Token: 0x060050F8 RID: 20728 RVA: 0x0009A09C File Offset: 0x0009829C
		private void Resetvip()
		{
			this.vipSpecified = false;
		}

		// Token: 0x17001904 RID: 6404
		// (get) Token: 0x060050F9 RID: 20729 RVA: 0x0009A0A8 File Offset: 0x000982A8
		// (set) Token: 0x060050FA RID: 20730 RVA: 0x0009A0D4 File Offset: 0x000982D4
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

		// Token: 0x17001905 RID: 6405
		// (get) Token: 0x060050FB RID: 20731 RVA: 0x0009A0E4 File Offset: 0x000982E4
		// (set) Token: 0x060050FC RID: 20732 RVA: 0x0009A104 File Offset: 0x00098304
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

		// Token: 0x060050FD RID: 20733 RVA: 0x0009A148 File Offset: 0x00098348
		private bool ShouldSerializeisonline()
		{
			return this.isonlineSpecified;
		}

		// Token: 0x060050FE RID: 20734 RVA: 0x0009A160 File Offset: 0x00098360
		private void Resetisonline()
		{
			this.isonlineSpecified = false;
		}

		// Token: 0x17001906 RID: 6406
		// (get) Token: 0x060050FF RID: 20735 RVA: 0x0009A16C File Offset: 0x0009836C
		// (set) Token: 0x06005100 RID: 20736 RVA: 0x0009A198 File Offset: 0x00098398
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

		// Token: 0x17001907 RID: 6407
		// (get) Token: 0x06005101 RID: 20737 RVA: 0x0009A1A8 File Offset: 0x000983A8
		// (set) Token: 0x06005102 RID: 20738 RVA: 0x0009A1C8 File Offset: 0x000983C8
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

		// Token: 0x06005103 RID: 20739 RVA: 0x0009A20C File Offset: 0x0009840C
		private bool ShouldSerializeactivity()
		{
			return this.activitySpecified;
		}

		// Token: 0x06005104 RID: 20740 RVA: 0x0009A224 File Offset: 0x00098424
		private void Resetactivity()
		{
			this.activitySpecified = false;
		}

		// Token: 0x17001908 RID: 6408
		// (get) Token: 0x06005105 RID: 20741 RVA: 0x0009A230 File Offset: 0x00098430
		// (set) Token: 0x06005106 RID: 20742 RVA: 0x0009A25C File Offset: 0x0009845C
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

		// Token: 0x17001909 RID: 6409
		// (get) Token: 0x06005107 RID: 20743 RVA: 0x0009A26C File Offset: 0x0009846C
		// (set) Token: 0x06005108 RID: 20744 RVA: 0x0009A28C File Offset: 0x0009848C
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

		// Token: 0x06005109 RID: 20745 RVA: 0x0009A2D0 File Offset: 0x000984D0
		private bool ShouldSerializepaymemberid()
		{
			return this.paymemberidSpecified;
		}

		// Token: 0x0600510A RID: 20746 RVA: 0x0009A2E8 File Offset: 0x000984E8
		private void Resetpaymemberid()
		{
			this.paymemberidSpecified = false;
		}

		// Token: 0x1700190A RID: 6410
		// (get) Token: 0x0600510B RID: 20747 RVA: 0x0009A2F4 File Offset: 0x000984F4
		// (set) Token: 0x0600510C RID: 20748 RVA: 0x0009A320 File Offset: 0x00098520
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

		// Token: 0x1700190B RID: 6411
		// (get) Token: 0x0600510D RID: 20749 RVA: 0x0009A330 File Offset: 0x00098530
		// (set) Token: 0x0600510E RID: 20750 RVA: 0x0009A350 File Offset: 0x00098550
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

		// Token: 0x0600510F RID: 20751 RVA: 0x0009A394 File Offset: 0x00098594
		private bool ShouldSerializetitle()
		{
			return this.titleSpecified;
		}

		// Token: 0x06005110 RID: 20752 RVA: 0x0009A3AC File Offset: 0x000985AC
		private void Resettitle()
		{
			this.titleSpecified = false;
		}

		// Token: 0x1700190C RID: 6412
		// (get) Token: 0x06005111 RID: 20753 RVA: 0x0009A3B8 File Offset: 0x000985B8
		// (set) Token: 0x06005112 RID: 20754 RVA: 0x0009A3E4 File Offset: 0x000985E4
		[ProtoMember(15, IsRequired = false, Name = "task_luck", DataFormat = DataFormat.TwosComplement)]
		public uint task_luck
		{
			get
			{
				return this._task_luck ?? 0U;
			}
			set
			{
				this._task_luck = new uint?(value);
			}
		}

		// Token: 0x1700190D RID: 6413
		// (get) Token: 0x06005113 RID: 20755 RVA: 0x0009A3F4 File Offset: 0x000985F4
		// (set) Token: 0x06005114 RID: 20756 RVA: 0x0009A414 File Offset: 0x00098614
		[XmlIgnore]
		[Browsable(false)]
		public bool task_luckSpecified
		{
			get
			{
				return this._task_luck != null;
			}
			set
			{
				bool flag = value == (this._task_luck == null);
				if (flag)
				{
					this._task_luck = (value ? new uint?(this.task_luck) : null);
				}
			}
		}

		// Token: 0x06005115 RID: 20757 RVA: 0x0009A458 File Offset: 0x00098658
		private bool ShouldSerializetask_luck()
		{
			return this.task_luckSpecified;
		}

		// Token: 0x06005116 RID: 20758 RVA: 0x0009A470 File Offset: 0x00098670
		private void Resettask_luck()
		{
			this.task_luckSpecified = false;
		}

		// Token: 0x1700190E RID: 6414
		// (get) Token: 0x06005117 RID: 20759 RVA: 0x0009A47C File Offset: 0x0009867C
		// (set) Token: 0x06005118 RID: 20760 RVA: 0x0009A4A8 File Offset: 0x000986A8
		[ProtoMember(16, IsRequired = false, Name = "task_score", DataFormat = DataFormat.TwosComplement)]
		public uint task_score
		{
			get
			{
				return this._task_score ?? 0U;
			}
			set
			{
				this._task_score = new uint?(value);
			}
		}

		// Token: 0x1700190F RID: 6415
		// (get) Token: 0x06005119 RID: 20761 RVA: 0x0009A4B8 File Offset: 0x000986B8
		// (set) Token: 0x0600511A RID: 20762 RVA: 0x0009A4D8 File Offset: 0x000986D8
		[XmlIgnore]
		[Browsable(false)]
		public bool task_scoreSpecified
		{
			get
			{
				return this._task_score != null;
			}
			set
			{
				bool flag = value == (this._task_score == null);
				if (flag)
				{
					this._task_score = (value ? new uint?(this.task_score) : null);
				}
			}
		}

		// Token: 0x0600511B RID: 20763 RVA: 0x0009A51C File Offset: 0x0009871C
		private bool ShouldSerializetask_score()
		{
			return this.task_scoreSpecified;
		}

		// Token: 0x0600511C RID: 20764 RVA: 0x0009A534 File Offset: 0x00098734
		private void Resettask_score()
		{
			this.task_scoreSpecified = false;
		}

		// Token: 0x17001910 RID: 6416
		// (get) Token: 0x0600511D RID: 20765 RVA: 0x0009A540 File Offset: 0x00098740
		// (set) Token: 0x0600511E RID: 20766 RVA: 0x0009A56C File Offset: 0x0009876C
		[ProtoMember(17, IsRequired = false, Name = "can_refresh", DataFormat = DataFormat.Default)]
		public bool can_refresh
		{
			get
			{
				return this._can_refresh ?? false;
			}
			set
			{
				this._can_refresh = new bool?(value);
			}
		}

		// Token: 0x17001911 RID: 6417
		// (get) Token: 0x0600511F RID: 20767 RVA: 0x0009A57C File Offset: 0x0009877C
		// (set) Token: 0x06005120 RID: 20768 RVA: 0x0009A59C File Offset: 0x0009879C
		[XmlIgnore]
		[Browsable(false)]
		public bool can_refreshSpecified
		{
			get
			{
				return this._can_refresh != null;
			}
			set
			{
				bool flag = value == (this._can_refresh == null);
				if (flag)
				{
					this._can_refresh = (value ? new bool?(this.can_refresh) : null);
				}
			}
		}

		// Token: 0x06005121 RID: 20769 RVA: 0x0009A5E0 File Offset: 0x000987E0
		private bool ShouldSerializecan_refresh()
		{
			return this.can_refreshSpecified;
		}

		// Token: 0x06005122 RID: 20770 RVA: 0x0009A5F8 File Offset: 0x000987F8
		private void Resetcan_refresh()
		{
			this.can_refreshSpecified = false;
		}

		// Token: 0x06005123 RID: 20771 RVA: 0x0009A604 File Offset: 0x00098804
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040013D6 RID: 5078
		private string _name;

		// Token: 0x040013D7 RID: 5079
		private ulong? _roleid;

		// Token: 0x040013D8 RID: 5080
		private int? _position;

		// Token: 0x040013D9 RID: 5081
		private uint? _contribute;

		// Token: 0x040013DA RID: 5082
		private uint? _ppt;

		// Token: 0x040013DB RID: 5083
		private uint? _flag;

		// Token: 0x040013DC RID: 5084
		private uint? _level;

		// Token: 0x040013DD RID: 5085
		private RoleType? _profession;

		// Token: 0x040013DE RID: 5086
		private uint? _lastlogin;

		// Token: 0x040013DF RID: 5087
		private uint? _vip;

		// Token: 0x040013E0 RID: 5088
		private bool? _isonline;

		// Token: 0x040013E1 RID: 5089
		private uint? _activity;

		// Token: 0x040013E2 RID: 5090
		private uint? _paymemberid;

		// Token: 0x040013E3 RID: 5091
		private uint? _title;

		// Token: 0x040013E4 RID: 5092
		private uint? _task_luck;

		// Token: 0x040013E5 RID: 5093
		private uint? _task_score;

		// Token: 0x040013E6 RID: 5094
		private bool? _can_refresh;

		// Token: 0x040013E7 RID: 5095
		private IExtension extensionObject;
	}
}
