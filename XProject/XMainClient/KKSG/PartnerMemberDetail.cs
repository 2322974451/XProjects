using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006DB RID: 1755
	[ProtoContract(Name = "PartnerMemberDetail")]
	[Serializable]
	public class PartnerMemberDetail : IExtensible
	{
		// Token: 0x170024F3 RID: 9459
		// (get) Token: 0x060074B4 RID: 29876 RVA: 0x000DF494 File Offset: 0x000DD694
		// (set) Token: 0x060074B5 RID: 29877 RVA: 0x000DF4C1 File Offset: 0x000DD6C1
		[ProtoMember(1, IsRequired = false, Name = "memberid", DataFormat = DataFormat.TwosComplement)]
		public ulong memberid
		{
			get
			{
				return this._memberid ?? 0UL;
			}
			set
			{
				this._memberid = new ulong?(value);
			}
		}

		// Token: 0x170024F4 RID: 9460
		// (get) Token: 0x060074B6 RID: 29878 RVA: 0x000DF4D0 File Offset: 0x000DD6D0
		// (set) Token: 0x060074B7 RID: 29879 RVA: 0x000DF4F0 File Offset: 0x000DD6F0
		[XmlIgnore]
		[Browsable(false)]
		public bool memberidSpecified
		{
			get
			{
				return this._memberid != null;
			}
			set
			{
				bool flag = value == (this._memberid == null);
				if (flag)
				{
					this._memberid = (value ? new ulong?(this.memberid) : null);
				}
			}
		}

		// Token: 0x060074B8 RID: 29880 RVA: 0x000DF534 File Offset: 0x000DD734
		private bool ShouldSerializememberid()
		{
			return this.memberidSpecified;
		}

		// Token: 0x060074B9 RID: 29881 RVA: 0x000DF54C File Offset: 0x000DD74C
		private void Resetmemberid()
		{
			this.memberidSpecified = false;
		}

		// Token: 0x170024F5 RID: 9461
		// (get) Token: 0x060074BA RID: 29882 RVA: 0x000DF558 File Offset: 0x000DD758
		// (set) Token: 0x060074BB RID: 29883 RVA: 0x000DF584 File Offset: 0x000DD784
		[ProtoMember(2, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170024F6 RID: 9462
		// (get) Token: 0x060074BC RID: 29884 RVA: 0x000DF594 File Offset: 0x000DD794
		// (set) Token: 0x060074BD RID: 29885 RVA: 0x000DF5B4 File Offset: 0x000DD7B4
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

		// Token: 0x060074BE RID: 29886 RVA: 0x000DF5F8 File Offset: 0x000DD7F8
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x060074BF RID: 29887 RVA: 0x000DF610 File Offset: 0x000DD810
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x170024F7 RID: 9463
		// (get) Token: 0x060074C0 RID: 29888 RVA: 0x000DF61C File Offset: 0x000DD81C
		// (set) Token: 0x060074C1 RID: 29889 RVA: 0x000DF63D File Offset: 0x000DD83D
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

		// Token: 0x170024F8 RID: 9464
		// (get) Token: 0x060074C2 RID: 29890 RVA: 0x000DF648 File Offset: 0x000DD848
		// (set) Token: 0x060074C3 RID: 29891 RVA: 0x000DF664 File Offset: 0x000DD864
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

		// Token: 0x060074C4 RID: 29892 RVA: 0x000DF694 File Offset: 0x000DD894
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060074C5 RID: 29893 RVA: 0x000DF6AC File Offset: 0x000DD8AC
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170024F9 RID: 9465
		// (get) Token: 0x060074C6 RID: 29894 RVA: 0x000DF6B8 File Offset: 0x000DD8B8
		// (set) Token: 0x060074C7 RID: 29895 RVA: 0x000DF6E4 File Offset: 0x000DD8E4
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

		// Token: 0x170024FA RID: 9466
		// (get) Token: 0x060074C8 RID: 29896 RVA: 0x000DF6F4 File Offset: 0x000DD8F4
		// (set) Token: 0x060074C9 RID: 29897 RVA: 0x000DF714 File Offset: 0x000DD914
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

		// Token: 0x060074CA RID: 29898 RVA: 0x000DF758 File Offset: 0x000DD958
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x060074CB RID: 29899 RVA: 0x000DF770 File Offset: 0x000DD970
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x170024FB RID: 9467
		// (get) Token: 0x060074CC RID: 29900 RVA: 0x000DF77C File Offset: 0x000DD97C
		// (set) Token: 0x060074CD RID: 29901 RVA: 0x000DF7A8 File Offset: 0x000DD9A8
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

		// Token: 0x170024FC RID: 9468
		// (get) Token: 0x060074CE RID: 29902 RVA: 0x000DF7B8 File Offset: 0x000DD9B8
		// (set) Token: 0x060074CF RID: 29903 RVA: 0x000DF7D8 File Offset: 0x000DD9D8
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

		// Token: 0x060074D0 RID: 29904 RVA: 0x000DF81C File Offset: 0x000DDA1C
		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		// Token: 0x060074D1 RID: 29905 RVA: 0x000DF834 File Offset: 0x000DDA34
		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		// Token: 0x170024FD RID: 9469
		// (get) Token: 0x060074D2 RID: 29906 RVA: 0x000DF840 File Offset: 0x000DDA40
		[ProtoMember(6, Name = "fashion", DataFormat = DataFormat.TwosComplement)]
		public List<uint> fashion
		{
			get
			{
				return this._fashion;
			}
		}

		// Token: 0x170024FE RID: 9470
		// (get) Token: 0x060074D3 RID: 29907 RVA: 0x000DF858 File Offset: 0x000DDA58
		// (set) Token: 0x060074D4 RID: 29908 RVA: 0x000DF870 File Offset: 0x000DDA70
		[ProtoMember(7, IsRequired = false, Name = "outlook", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLook outlook
		{
			get
			{
				return this._outlook;
			}
			set
			{
				this._outlook = value;
			}
		}

		// Token: 0x170024FF RID: 9471
		// (get) Token: 0x060074D5 RID: 29909 RVA: 0x000DF87C File Offset: 0x000DDA7C
		// (set) Token: 0x060074D6 RID: 29910 RVA: 0x000DF8A8 File Offset: 0x000DDAA8
		[ProtoMember(8, IsRequired = false, Name = "viplevel", DataFormat = DataFormat.TwosComplement)]
		public uint viplevel
		{
			get
			{
				return this._viplevel ?? 0U;
			}
			set
			{
				this._viplevel = new uint?(value);
			}
		}

		// Token: 0x17002500 RID: 9472
		// (get) Token: 0x060074D7 RID: 29911 RVA: 0x000DF8B8 File Offset: 0x000DDAB8
		// (set) Token: 0x060074D8 RID: 29912 RVA: 0x000DF8D8 File Offset: 0x000DDAD8
		[XmlIgnore]
		[Browsable(false)]
		public bool viplevelSpecified
		{
			get
			{
				return this._viplevel != null;
			}
			set
			{
				bool flag = value == (this._viplevel == null);
				if (flag)
				{
					this._viplevel = (value ? new uint?(this.viplevel) : null);
				}
			}
		}

		// Token: 0x060074D9 RID: 29913 RVA: 0x000DF91C File Offset: 0x000DDB1C
		private bool ShouldSerializeviplevel()
		{
			return this.viplevelSpecified;
		}

		// Token: 0x060074DA RID: 29914 RVA: 0x000DF934 File Offset: 0x000DDB34
		private void Resetviplevel()
		{
			this.viplevelSpecified = false;
		}

		// Token: 0x17002501 RID: 9473
		// (get) Token: 0x060074DB RID: 29915 RVA: 0x000DF940 File Offset: 0x000DDB40
		// (set) Token: 0x060074DC RID: 29916 RVA: 0x000DF96C File Offset: 0x000DDB6C
		[ProtoMember(9, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002502 RID: 9474
		// (get) Token: 0x060074DD RID: 29917 RVA: 0x000DF97C File Offset: 0x000DDB7C
		// (set) Token: 0x060074DE RID: 29918 RVA: 0x000DF99C File Offset: 0x000DDB9C
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

		// Token: 0x060074DF RID: 29919 RVA: 0x000DF9E0 File Offset: 0x000DDBE0
		private bool ShouldSerializepaymemberid()
		{
			return this.paymemberidSpecified;
		}

		// Token: 0x060074E0 RID: 29920 RVA: 0x000DF9F8 File Offset: 0x000DDBF8
		private void Resetpaymemberid()
		{
			this.paymemberidSpecified = false;
		}

		// Token: 0x17002503 RID: 9475
		// (get) Token: 0x060074E1 RID: 29921 RVA: 0x000DFA04 File Offset: 0x000DDC04
		// (set) Token: 0x060074E2 RID: 29922 RVA: 0x000DFA30 File Offset: 0x000DDC30
		[ProtoMember(10, IsRequired = false, Name = "is_apply_leave", DataFormat = DataFormat.Default)]
		public bool is_apply_leave
		{
			get
			{
				return this._is_apply_leave ?? false;
			}
			set
			{
				this._is_apply_leave = new bool?(value);
			}
		}

		// Token: 0x17002504 RID: 9476
		// (get) Token: 0x060074E3 RID: 29923 RVA: 0x000DFA40 File Offset: 0x000DDC40
		// (set) Token: 0x060074E4 RID: 29924 RVA: 0x000DFA60 File Offset: 0x000DDC60
		[XmlIgnore]
		[Browsable(false)]
		public bool is_apply_leaveSpecified
		{
			get
			{
				return this._is_apply_leave != null;
			}
			set
			{
				bool flag = value == (this._is_apply_leave == null);
				if (flag)
				{
					this._is_apply_leave = (value ? new bool?(this.is_apply_leave) : null);
				}
			}
		}

		// Token: 0x060074E5 RID: 29925 RVA: 0x000DFAA4 File Offset: 0x000DDCA4
		private bool ShouldSerializeis_apply_leave()
		{
			return this.is_apply_leaveSpecified;
		}

		// Token: 0x060074E6 RID: 29926 RVA: 0x000DFABC File Offset: 0x000DDCBC
		private void Resetis_apply_leave()
		{
			this.is_apply_leaveSpecified = false;
		}

		// Token: 0x17002505 RID: 9477
		// (get) Token: 0x060074E7 RID: 29927 RVA: 0x000DFAC8 File Offset: 0x000DDCC8
		// (set) Token: 0x060074E8 RID: 29928 RVA: 0x000DFAF4 File Offset: 0x000DDCF4
		[ProtoMember(11, IsRequired = false, Name = "left_leave_time", DataFormat = DataFormat.TwosComplement)]
		public uint left_leave_time
		{
			get
			{
				return this._left_leave_time ?? 0U;
			}
			set
			{
				this._left_leave_time = new uint?(value);
			}
		}

		// Token: 0x17002506 RID: 9478
		// (get) Token: 0x060074E9 RID: 29929 RVA: 0x000DFB04 File Offset: 0x000DDD04
		// (set) Token: 0x060074EA RID: 29930 RVA: 0x000DFB24 File Offset: 0x000DDD24
		[XmlIgnore]
		[Browsable(false)]
		public bool left_leave_timeSpecified
		{
			get
			{
				return this._left_leave_time != null;
			}
			set
			{
				bool flag = value == (this._left_leave_time == null);
				if (flag)
				{
					this._left_leave_time = (value ? new uint?(this.left_leave_time) : null);
				}
			}
		}

		// Token: 0x060074EB RID: 29931 RVA: 0x000DFB68 File Offset: 0x000DDD68
		private bool ShouldSerializeleft_leave_time()
		{
			return this.left_leave_timeSpecified;
		}

		// Token: 0x060074EC RID: 29932 RVA: 0x000DFB80 File Offset: 0x000DDD80
		private void Resetleft_leave_time()
		{
			this.left_leave_timeSpecified = false;
		}

		// Token: 0x060074ED RID: 29933 RVA: 0x000DFB8C File Offset: 0x000DDD8C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BB9 RID: 7097
		private ulong? _memberid;

		// Token: 0x04001BBA RID: 7098
		private RoleType? _profession;

		// Token: 0x04001BBB RID: 7099
		private string _name;

		// Token: 0x04001BBC RID: 7100
		private uint? _level;

		// Token: 0x04001BBD RID: 7101
		private uint? _ppt;

		// Token: 0x04001BBE RID: 7102
		private readonly List<uint> _fashion = new List<uint>();

		// Token: 0x04001BBF RID: 7103
		private OutLook _outlook = null;

		// Token: 0x04001BC0 RID: 7104
		private uint? _viplevel;

		// Token: 0x04001BC1 RID: 7105
		private uint? _paymemberid;

		// Token: 0x04001BC2 RID: 7106
		private bool? _is_apply_leave;

		// Token: 0x04001BC3 RID: 7107
		private uint? _left_leave_time;

		// Token: 0x04001BC4 RID: 7108
		private IExtension extensionObject;
	}
}
