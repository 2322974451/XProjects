using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000739 RID: 1849
	[ProtoContract(Name = "DailyTaskRefreshRoleInfo")]
	[Serializable]
	public class DailyTaskRefreshRoleInfo : IExtensible
	{
		// Token: 0x1700288F RID: 10383
		// (get) Token: 0x06007FF1 RID: 32753 RVA: 0x000F4A38 File Offset: 0x000F2C38
		// (set) Token: 0x06007FF2 RID: 32754 RVA: 0x000F4A65 File Offset: 0x000F2C65
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002890 RID: 10384
		// (get) Token: 0x06007FF3 RID: 32755 RVA: 0x000F4A74 File Offset: 0x000F2C74
		// (set) Token: 0x06007FF4 RID: 32756 RVA: 0x000F4A94 File Offset: 0x000F2C94
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

		// Token: 0x06007FF5 RID: 32757 RVA: 0x000F4AD8 File Offset: 0x000F2CD8
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007FF6 RID: 32758 RVA: 0x000F4AF0 File Offset: 0x000F2CF0
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17002891 RID: 10385
		// (get) Token: 0x06007FF7 RID: 32759 RVA: 0x000F4AFC File Offset: 0x000F2CFC
		// (set) Token: 0x06007FF8 RID: 32760 RVA: 0x000F4B1D File Offset: 0x000F2D1D
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x17002892 RID: 10386
		// (get) Token: 0x06007FF9 RID: 32761 RVA: 0x000F4B28 File Offset: 0x000F2D28
		// (set) Token: 0x06007FFA RID: 32762 RVA: 0x000F4B44 File Offset: 0x000F2D44
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

		// Token: 0x06007FFB RID: 32763 RVA: 0x000F4B74 File Offset: 0x000F2D74
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007FFC RID: 32764 RVA: 0x000F4B8C File Offset: 0x000F2D8C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002893 RID: 10387
		// (get) Token: 0x06007FFD RID: 32765 RVA: 0x000F4B98 File Offset: 0x000F2D98
		// (set) Token: 0x06007FFE RID: 32766 RVA: 0x000F4BC4 File Offset: 0x000F2DC4
		[ProtoMember(3, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002894 RID: 10388
		// (get) Token: 0x06007FFF RID: 32767 RVA: 0x000F4BD4 File Offset: 0x000F2DD4
		// (set) Token: 0x06008000 RID: 32768 RVA: 0x000F4BF4 File Offset: 0x000F2DF4
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

		// Token: 0x06008001 RID: 32769 RVA: 0x000F4C38 File Offset: 0x000F2E38
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06008002 RID: 32770 RVA: 0x000F4C50 File Offset: 0x000F2E50
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x17002895 RID: 10389
		// (get) Token: 0x06008003 RID: 32771 RVA: 0x000F4C5C File Offset: 0x000F2E5C
		// (set) Token: 0x06008004 RID: 32772 RVA: 0x000F4C88 File Offset: 0x000F2E88
		[ProtoMember(4, IsRequired = false, Name = "luck", DataFormat = DataFormat.TwosComplement)]
		public uint luck
		{
			get
			{
				return this._luck ?? 0U;
			}
			set
			{
				this._luck = new uint?(value);
			}
		}

		// Token: 0x17002896 RID: 10390
		// (get) Token: 0x06008005 RID: 32773 RVA: 0x000F4C98 File Offset: 0x000F2E98
		// (set) Token: 0x06008006 RID: 32774 RVA: 0x000F4CB8 File Offset: 0x000F2EB8
		[XmlIgnore]
		[Browsable(false)]
		public bool luckSpecified
		{
			get
			{
				return this._luck != null;
			}
			set
			{
				bool flag = value == (this._luck == null);
				if (flag)
				{
					this._luck = (value ? new uint?(this.luck) : null);
				}
			}
		}

		// Token: 0x06008007 RID: 32775 RVA: 0x000F4CFC File Offset: 0x000F2EFC
		private bool ShouldSerializeluck()
		{
			return this.luckSpecified;
		}

		// Token: 0x06008008 RID: 32776 RVA: 0x000F4D14 File Offset: 0x000F2F14
		private void Resetluck()
		{
			this.luckSpecified = false;
		}

		// Token: 0x17002897 RID: 10391
		// (get) Token: 0x06008009 RID: 32777 RVA: 0x000F4D20 File Offset: 0x000F2F20
		// (set) Token: 0x0600800A RID: 32778 RVA: 0x000F4D4C File Offset: 0x000F2F4C
		[ProtoMember(5, IsRequired = false, Name = "refresh_num", DataFormat = DataFormat.TwosComplement)]
		public uint refresh_num
		{
			get
			{
				return this._refresh_num ?? 0U;
			}
			set
			{
				this._refresh_num = new uint?(value);
			}
		}

		// Token: 0x17002898 RID: 10392
		// (get) Token: 0x0600800B RID: 32779 RVA: 0x000F4D5C File Offset: 0x000F2F5C
		// (set) Token: 0x0600800C RID: 32780 RVA: 0x000F4D7C File Offset: 0x000F2F7C
		[XmlIgnore]
		[Browsable(false)]
		public bool refresh_numSpecified
		{
			get
			{
				return this._refresh_num != null;
			}
			set
			{
				bool flag = value == (this._refresh_num == null);
				if (flag)
				{
					this._refresh_num = (value ? new uint?(this.refresh_num) : null);
				}
			}
		}

		// Token: 0x0600800D RID: 32781 RVA: 0x000F4DC0 File Offset: 0x000F2FC0
		private bool ShouldSerializerefresh_num()
		{
			return this.refresh_numSpecified;
		}

		// Token: 0x0600800E RID: 32782 RVA: 0x000F4DD8 File Offset: 0x000F2FD8
		private void Resetrefresh_num()
		{
			this.refresh_numSpecified = false;
		}

		// Token: 0x17002899 RID: 10393
		// (get) Token: 0x0600800F RID: 32783 RVA: 0x000F4DE4 File Offset: 0x000F2FE4
		// (set) Token: 0x06008010 RID: 32784 RVA: 0x000F4E10 File Offset: 0x000F3010
		[ProtoMember(6, IsRequired = false, Name = "already_ask", DataFormat = DataFormat.Default)]
		public bool already_ask
		{
			get
			{
				return this._already_ask ?? false;
			}
			set
			{
				this._already_ask = new bool?(value);
			}
		}

		// Token: 0x1700289A RID: 10394
		// (get) Token: 0x06008011 RID: 32785 RVA: 0x000F4E20 File Offset: 0x000F3020
		// (set) Token: 0x06008012 RID: 32786 RVA: 0x000F4E40 File Offset: 0x000F3040
		[XmlIgnore]
		[Browsable(false)]
		public bool already_askSpecified
		{
			get
			{
				return this._already_ask != null;
			}
			set
			{
				bool flag = value == (this._already_ask == null);
				if (flag)
				{
					this._already_ask = (value ? new bool?(this.already_ask) : null);
				}
			}
		}

		// Token: 0x06008013 RID: 32787 RVA: 0x000F4E84 File Offset: 0x000F3084
		private bool ShouldSerializealready_ask()
		{
			return this.already_askSpecified;
		}

		// Token: 0x06008014 RID: 32788 RVA: 0x000F4E9C File Offset: 0x000F309C
		private void Resetalready_ask()
		{
			this.already_askSpecified = false;
		}

		// Token: 0x1700289B RID: 10395
		// (get) Token: 0x06008015 RID: 32789 RVA: 0x000F4EA8 File Offset: 0x000F30A8
		// (set) Token: 0x06008016 RID: 32790 RVA: 0x000F4ED4 File Offset: 0x000F30D4
		[ProtoMember(7, IsRequired = false, Name = "already_refused", DataFormat = DataFormat.Default)]
		public bool already_refused
		{
			get
			{
				return this._already_refused ?? false;
			}
			set
			{
				this._already_refused = new bool?(value);
			}
		}

		// Token: 0x1700289C RID: 10396
		// (get) Token: 0x06008017 RID: 32791 RVA: 0x000F4EE4 File Offset: 0x000F30E4
		// (set) Token: 0x06008018 RID: 32792 RVA: 0x000F4F04 File Offset: 0x000F3104
		[XmlIgnore]
		[Browsable(false)]
		public bool already_refusedSpecified
		{
			get
			{
				return this._already_refused != null;
			}
			set
			{
				bool flag = value == (this._already_refused == null);
				if (flag)
				{
					this._already_refused = (value ? new bool?(this.already_refused) : null);
				}
			}
		}

		// Token: 0x06008019 RID: 32793 RVA: 0x000F4F48 File Offset: 0x000F3148
		private bool ShouldSerializealready_refused()
		{
			return this.already_refusedSpecified;
		}

		// Token: 0x0600801A RID: 32794 RVA: 0x000F4F60 File Offset: 0x000F3160
		private void Resetalready_refused()
		{
			this.already_refusedSpecified = false;
		}

		// Token: 0x1700289D RID: 10397
		// (get) Token: 0x0600801B RID: 32795 RVA: 0x000F4F6C File Offset: 0x000F316C
		// (set) Token: 0x0600801C RID: 32796 RVA: 0x000F4F98 File Offset: 0x000F3198
		[ProtoMember(8, IsRequired = false, Name = "already_helped", DataFormat = DataFormat.Default)]
		public bool already_helped
		{
			get
			{
				return this._already_helped ?? false;
			}
			set
			{
				this._already_helped = new bool?(value);
			}
		}

		// Token: 0x1700289E RID: 10398
		// (get) Token: 0x0600801D RID: 32797 RVA: 0x000F4FA8 File Offset: 0x000F31A8
		// (set) Token: 0x0600801E RID: 32798 RVA: 0x000F4FC8 File Offset: 0x000F31C8
		[XmlIgnore]
		[Browsable(false)]
		public bool already_helpedSpecified
		{
			get
			{
				return this._already_helped != null;
			}
			set
			{
				bool flag = value == (this._already_helped == null);
				if (flag)
				{
					this._already_helped = (value ? new bool?(this.already_helped) : null);
				}
			}
		}

		// Token: 0x0600801F RID: 32799 RVA: 0x000F500C File Offset: 0x000F320C
		private bool ShouldSerializealready_helped()
		{
			return this.already_helpedSpecified;
		}

		// Token: 0x06008020 RID: 32800 RVA: 0x000F5024 File Offset: 0x000F3224
		private void Resetalready_helped()
		{
			this.already_helpedSpecified = false;
		}

		// Token: 0x1700289F RID: 10399
		// (get) Token: 0x06008021 RID: 32801 RVA: 0x000F5030 File Offset: 0x000F3230
		// (set) Token: 0x06008022 RID: 32802 RVA: 0x000F505C File Offset: 0x000F325C
		[ProtoMember(9, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		// Token: 0x170028A0 RID: 10400
		// (get) Token: 0x06008023 RID: 32803 RVA: 0x000F506C File Offset: 0x000F326C
		// (set) Token: 0x06008024 RID: 32804 RVA: 0x000F508C File Offset: 0x000F328C
		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		// Token: 0x06008025 RID: 32805 RVA: 0x000F50D0 File Offset: 0x000F32D0
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06008026 RID: 32806 RVA: 0x000F50E8 File Offset: 0x000F32E8
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x170028A1 RID: 10401
		// (get) Token: 0x06008027 RID: 32807 RVA: 0x000F50F4 File Offset: 0x000F32F4
		// (set) Token: 0x06008028 RID: 32808 RVA: 0x000F5120 File Offset: 0x000F3320
		[ProtoMember(10, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x170028A2 RID: 10402
		// (get) Token: 0x06008029 RID: 32809 RVA: 0x000F5130 File Offset: 0x000F3330
		// (set) Token: 0x0600802A RID: 32810 RVA: 0x000F5150 File Offset: 0x000F3350
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x0600802B RID: 32811 RVA: 0x000F5194 File Offset: 0x000F3394
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x0600802C RID: 32812 RVA: 0x000F51AC File Offset: 0x000F33AC
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170028A3 RID: 10403
		// (get) Token: 0x0600802D RID: 32813 RVA: 0x000F51B8 File Offset: 0x000F33B8
		// (set) Token: 0x0600802E RID: 32814 RVA: 0x000F51E4 File Offset: 0x000F33E4
		[ProtoMember(11, IsRequired = false, Name = "is_online", DataFormat = DataFormat.Default)]
		public bool is_online
		{
			get
			{
				return this._is_online ?? false;
			}
			set
			{
				this._is_online = new bool?(value);
			}
		}

		// Token: 0x170028A4 RID: 10404
		// (get) Token: 0x0600802F RID: 32815 RVA: 0x000F51F4 File Offset: 0x000F33F4
		// (set) Token: 0x06008030 RID: 32816 RVA: 0x000F5214 File Offset: 0x000F3414
		[XmlIgnore]
		[Browsable(false)]
		public bool is_onlineSpecified
		{
			get
			{
				return this._is_online != null;
			}
			set
			{
				bool flag = value == (this._is_online == null);
				if (flag)
				{
					this._is_online = (value ? new bool?(this.is_online) : null);
				}
			}
		}

		// Token: 0x06008031 RID: 32817 RVA: 0x000F5258 File Offset: 0x000F3458
		private bool ShouldSerializeis_online()
		{
			return this.is_onlineSpecified;
		}

		// Token: 0x06008032 RID: 32818 RVA: 0x000F5270 File Offset: 0x000F3470
		private void Resetis_online()
		{
			this.is_onlineSpecified = false;
		}

		// Token: 0x06008033 RID: 32819 RVA: 0x000F527C File Offset: 0x000F347C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E01 RID: 7681
		private ulong? _roleid;

		// Token: 0x04001E02 RID: 7682
		private string _name;

		// Token: 0x04001E03 RID: 7683
		private RoleType? _profession;

		// Token: 0x04001E04 RID: 7684
		private uint? _luck;

		// Token: 0x04001E05 RID: 7685
		private uint? _refresh_num;

		// Token: 0x04001E06 RID: 7686
		private bool? _already_ask;

		// Token: 0x04001E07 RID: 7687
		private bool? _already_refused;

		// Token: 0x04001E08 RID: 7688
		private bool? _already_helped;

		// Token: 0x04001E09 RID: 7689
		private uint? _score;

		// Token: 0x04001E0A RID: 7690
		private uint? _time;

		// Token: 0x04001E0B RID: 7691
		private bool? _is_online;

		// Token: 0x04001E0C RID: 7692
		private IExtension extensionObject;
	}
}
