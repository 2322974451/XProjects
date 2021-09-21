using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006FB RID: 1787
	[ProtoContract(Name = "PersonalHomePage")]
	[Serializable]
	public class PersonalHomePage : IExtensible
	{
		// Token: 0x1700262A RID: 9770
		// (get) Token: 0x0600787F RID: 30847 RVA: 0x000E679C File Offset: 0x000E499C
		// (set) Token: 0x06007880 RID: 30848 RVA: 0x000E67C8 File Offset: 0x000E49C8
		[ProtoMember(1, IsRequired = false, Name = "qq_vip", DataFormat = DataFormat.TwosComplement)]
		public uint qq_vip
		{
			get
			{
				return this._qq_vip ?? 0U;
			}
			set
			{
				this._qq_vip = new uint?(value);
			}
		}

		// Token: 0x1700262B RID: 9771
		// (get) Token: 0x06007881 RID: 30849 RVA: 0x000E67D8 File Offset: 0x000E49D8
		// (set) Token: 0x06007882 RID: 30850 RVA: 0x000E67F8 File Offset: 0x000E49F8
		[XmlIgnore]
		[Browsable(false)]
		public bool qq_vipSpecified
		{
			get
			{
				return this._qq_vip != null;
			}
			set
			{
				bool flag = value == (this._qq_vip == null);
				if (flag)
				{
					this._qq_vip = (value ? new uint?(this.qq_vip) : null);
				}
			}
		}

		// Token: 0x06007883 RID: 30851 RVA: 0x000E683C File Offset: 0x000E4A3C
		private bool ShouldSerializeqq_vip()
		{
			return this.qq_vipSpecified;
		}

		// Token: 0x06007884 RID: 30852 RVA: 0x000E6854 File Offset: 0x000E4A54
		private void Resetqq_vip()
		{
			this.qq_vipSpecified = false;
		}

		// Token: 0x1700262C RID: 9772
		// (get) Token: 0x06007885 RID: 30853 RVA: 0x000E6860 File Offset: 0x000E4A60
		// (set) Token: 0x06007886 RID: 30854 RVA: 0x000E688C File Offset: 0x000E4A8C
		[ProtoMember(2, IsRequired = false, Name = "paymember_id", DataFormat = DataFormat.TwosComplement)]
		public uint paymember_id
		{
			get
			{
				return this._paymember_id ?? 0U;
			}
			set
			{
				this._paymember_id = new uint?(value);
			}
		}

		// Token: 0x1700262D RID: 9773
		// (get) Token: 0x06007887 RID: 30855 RVA: 0x000E689C File Offset: 0x000E4A9C
		// (set) Token: 0x06007888 RID: 30856 RVA: 0x000E68BC File Offset: 0x000E4ABC
		[XmlIgnore]
		[Browsable(false)]
		public bool paymember_idSpecified
		{
			get
			{
				return this._paymember_id != null;
			}
			set
			{
				bool flag = value == (this._paymember_id == null);
				if (flag)
				{
					this._paymember_id = (value ? new uint?(this.paymember_id) : null);
				}
			}
		}

		// Token: 0x06007889 RID: 30857 RVA: 0x000E6900 File Offset: 0x000E4B00
		private bool ShouldSerializepaymember_id()
		{
			return this.paymember_idSpecified;
		}

		// Token: 0x0600788A RID: 30858 RVA: 0x000E6918 File Offset: 0x000E4B18
		private void Resetpaymember_id()
		{
			this.paymember_idSpecified = false;
		}

		// Token: 0x1700262E RID: 9774
		// (get) Token: 0x0600788B RID: 30859 RVA: 0x000E6924 File Offset: 0x000E4B24
		// (set) Token: 0x0600788C RID: 30860 RVA: 0x000E6945 File Offset: 0x000E4B45
		[ProtoMember(3, IsRequired = false, Name = "play_name", DataFormat = DataFormat.Default)]
		public string play_name
		{
			get
			{
				return this._play_name ?? "";
			}
			set
			{
				this._play_name = value;
			}
		}

		// Token: 0x1700262F RID: 9775
		// (get) Token: 0x0600788D RID: 30861 RVA: 0x000E6950 File Offset: 0x000E4B50
		// (set) Token: 0x0600788E RID: 30862 RVA: 0x000E696C File Offset: 0x000E4B6C
		[XmlIgnore]
		[Browsable(false)]
		public bool play_nameSpecified
		{
			get
			{
				return this._play_name != null;
			}
			set
			{
				bool flag = value == (this._play_name == null);
				if (flag)
				{
					this._play_name = (value ? this.play_name : null);
				}
			}
		}

		// Token: 0x0600788F RID: 30863 RVA: 0x000E699C File Offset: 0x000E4B9C
		private bool ShouldSerializeplay_name()
		{
			return this.play_nameSpecified;
		}

		// Token: 0x06007890 RID: 30864 RVA: 0x000E69B4 File Offset: 0x000E4BB4
		private void Resetplay_name()
		{
			this.play_nameSpecified = false;
		}

		// Token: 0x17002630 RID: 9776
		// (get) Token: 0x06007891 RID: 30865 RVA: 0x000E69C0 File Offset: 0x000E4BC0
		// (set) Token: 0x06007892 RID: 30866 RVA: 0x000E69EC File Offset: 0x000E4BEC
		[ProtoMember(4, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public uint uid
		{
			get
			{
				return this._uid ?? 0U;
			}
			set
			{
				this._uid = new uint?(value);
			}
		}

		// Token: 0x17002631 RID: 9777
		// (get) Token: 0x06007893 RID: 30867 RVA: 0x000E69FC File Offset: 0x000E4BFC
		// (set) Token: 0x06007894 RID: 30868 RVA: 0x000E6A1C File Offset: 0x000E4C1C
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
					this._uid = (value ? new uint?(this.uid) : null);
				}
			}
		}

		// Token: 0x06007895 RID: 30869 RVA: 0x000E6A60 File Offset: 0x000E4C60
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06007896 RID: 30870 RVA: 0x000E6A78 File Offset: 0x000E4C78
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17002632 RID: 9778
		// (get) Token: 0x06007897 RID: 30871 RVA: 0x000E6A84 File Offset: 0x000E4C84
		// (set) Token: 0x06007898 RID: 30872 RVA: 0x000E6AA5 File Offset: 0x000E4CA5
		[ProtoMember(5, IsRequired = false, Name = "declaration", DataFormat = DataFormat.Default)]
		public string declaration
		{
			get
			{
				return this._declaration ?? "";
			}
			set
			{
				this._declaration = value;
			}
		}

		// Token: 0x17002633 RID: 9779
		// (get) Token: 0x06007899 RID: 30873 RVA: 0x000E6AB0 File Offset: 0x000E4CB0
		// (set) Token: 0x0600789A RID: 30874 RVA: 0x000E6ACC File Offset: 0x000E4CCC
		[XmlIgnore]
		[Browsable(false)]
		public bool declarationSpecified
		{
			get
			{
				return this._declaration != null;
			}
			set
			{
				bool flag = value == (this._declaration == null);
				if (flag)
				{
					this._declaration = (value ? this.declaration : null);
				}
			}
		}

		// Token: 0x0600789B RID: 30875 RVA: 0x000E6AFC File Offset: 0x000E4CFC
		private bool ShouldSerializedeclaration()
		{
			return this.declarationSpecified;
		}

		// Token: 0x0600789C RID: 30876 RVA: 0x000E6B14 File Offset: 0x000E4D14
		private void Resetdeclaration()
		{
			this.declarationSpecified = false;
		}

		// Token: 0x17002634 RID: 9780
		// (get) Token: 0x0600789D RID: 30877 RVA: 0x000E6B20 File Offset: 0x000E4D20
		// (set) Token: 0x0600789E RID: 30878 RVA: 0x000E6B41 File Offset: 0x000E4D41
		[ProtoMember(6, IsRequired = false, Name = "server_name", DataFormat = DataFormat.Default)]
		public string server_name
		{
			get
			{
				return this._server_name ?? "";
			}
			set
			{
				this._server_name = value;
			}
		}

		// Token: 0x17002635 RID: 9781
		// (get) Token: 0x0600789F RID: 30879 RVA: 0x000E6B4C File Offset: 0x000E4D4C
		// (set) Token: 0x060078A0 RID: 30880 RVA: 0x000E6B68 File Offset: 0x000E4D68
		[XmlIgnore]
		[Browsable(false)]
		public bool server_nameSpecified
		{
			get
			{
				return this._server_name != null;
			}
			set
			{
				bool flag = value == (this._server_name == null);
				if (flag)
				{
					this._server_name = (value ? this.server_name : null);
				}
			}
		}

		// Token: 0x060078A1 RID: 30881 RVA: 0x000E6B98 File Offset: 0x000E4D98
		private bool ShouldSerializeserver_name()
		{
			return this.server_nameSpecified;
		}

		// Token: 0x060078A2 RID: 30882 RVA: 0x000E6BB0 File Offset: 0x000E4DB0
		private void Resetserver_name()
		{
			this.server_nameSpecified = false;
		}

		// Token: 0x17002636 RID: 9782
		// (get) Token: 0x060078A3 RID: 30883 RVA: 0x000E6BBC File Offset: 0x000E4DBC
		// (set) Token: 0x060078A4 RID: 30884 RVA: 0x000E6BE8 File Offset: 0x000E4DE8
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

		// Token: 0x17002637 RID: 9783
		// (get) Token: 0x060078A5 RID: 30885 RVA: 0x000E6BF8 File Offset: 0x000E4DF8
		// (set) Token: 0x060078A6 RID: 30886 RVA: 0x000E6C18 File Offset: 0x000E4E18
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

		// Token: 0x060078A7 RID: 30887 RVA: 0x000E6C5C File Offset: 0x000E4E5C
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x060078A8 RID: 30888 RVA: 0x000E6C74 File Offset: 0x000E4E74
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17002638 RID: 9784
		// (get) Token: 0x060078A9 RID: 30889 RVA: 0x000E6C80 File Offset: 0x000E4E80
		// (set) Token: 0x060078AA RID: 30890 RVA: 0x000E6CAC File Offset: 0x000E4EAC
		[ProtoMember(8, IsRequired = false, Name = "profession_id", DataFormat = DataFormat.TwosComplement)]
		public uint profession_id
		{
			get
			{
				return this._profession_id ?? 0U;
			}
			set
			{
				this._profession_id = new uint?(value);
			}
		}

		// Token: 0x17002639 RID: 9785
		// (get) Token: 0x060078AB RID: 30891 RVA: 0x000E6CBC File Offset: 0x000E4EBC
		// (set) Token: 0x060078AC RID: 30892 RVA: 0x000E6CDC File Offset: 0x000E4EDC
		[XmlIgnore]
		[Browsable(false)]
		public bool profession_idSpecified
		{
			get
			{
				return this._profession_id != null;
			}
			set
			{
				bool flag = value == (this._profession_id == null);
				if (flag)
				{
					this._profession_id = (value ? new uint?(this.profession_id) : null);
				}
			}
		}

		// Token: 0x060078AD RID: 30893 RVA: 0x000E6D20 File Offset: 0x000E4F20
		private bool ShouldSerializeprofession_id()
		{
			return this.profession_idSpecified;
		}

		// Token: 0x060078AE RID: 30894 RVA: 0x000E6D38 File Offset: 0x000E4F38
		private void Resetprofession_id()
		{
			this.profession_idSpecified = false;
		}

		// Token: 0x1700263A RID: 9786
		// (get) Token: 0x060078AF RID: 30895 RVA: 0x000E6D44 File Offset: 0x000E4F44
		// (set) Token: 0x060078B0 RID: 30896 RVA: 0x000E6D65 File Offset: 0x000E4F65
		[ProtoMember(9, IsRequired = false, Name = "guild_name", DataFormat = DataFormat.Default)]
		public string guild_name
		{
			get
			{
				return this._guild_name ?? "";
			}
			set
			{
				this._guild_name = value;
			}
		}

		// Token: 0x1700263B RID: 9787
		// (get) Token: 0x060078B1 RID: 30897 RVA: 0x000E6D70 File Offset: 0x000E4F70
		// (set) Token: 0x060078B2 RID: 30898 RVA: 0x000E6D8C File Offset: 0x000E4F8C
		[XmlIgnore]
		[Browsable(false)]
		public bool guild_nameSpecified
		{
			get
			{
				return this._guild_name != null;
			}
			set
			{
				bool flag = value == (this._guild_name == null);
				if (flag)
				{
					this._guild_name = (value ? this.guild_name : null);
				}
			}
		}

		// Token: 0x060078B3 RID: 30899 RVA: 0x000E6DBC File Offset: 0x000E4FBC
		private bool ShouldSerializeguild_name()
		{
			return this.guild_nameSpecified;
		}

		// Token: 0x060078B4 RID: 30900 RVA: 0x000E6DD4 File Offset: 0x000E4FD4
		private void Resetguild_name()
		{
			this.guild_nameSpecified = false;
		}

		// Token: 0x1700263C RID: 9788
		// (get) Token: 0x060078B5 RID: 30901 RVA: 0x000E6DE0 File Offset: 0x000E4FE0
		// (set) Token: 0x060078B6 RID: 30902 RVA: 0x000E6E14 File Offset: 0x000E5014
		[ProtoMember(10, IsRequired = false, Name = "power", DataFormat = DataFormat.TwosComplement)]
		public double power
		{
			get
			{
				return this._power ?? 0.0;
			}
			set
			{
				this._power = new double?(value);
			}
		}

		// Token: 0x1700263D RID: 9789
		// (get) Token: 0x060078B7 RID: 30903 RVA: 0x000E6E24 File Offset: 0x000E5024
		// (set) Token: 0x060078B8 RID: 30904 RVA: 0x000E6E44 File Offset: 0x000E5044
		[XmlIgnore]
		[Browsable(false)]
		public bool powerSpecified
		{
			get
			{
				return this._power != null;
			}
			set
			{
				bool flag = value == (this._power == null);
				if (flag)
				{
					this._power = (value ? new double?(this.power) : null);
				}
			}
		}

		// Token: 0x060078B9 RID: 30905 RVA: 0x000E6E88 File Offset: 0x000E5088
		private bool ShouldSerializepower()
		{
			return this.powerSpecified;
		}

		// Token: 0x060078BA RID: 30906 RVA: 0x000E6EA0 File Offset: 0x000E50A0
		private void Resetpower()
		{
			this.powerSpecified = false;
		}

		// Token: 0x1700263E RID: 9790
		// (get) Token: 0x060078BB RID: 30907 RVA: 0x000E6EAC File Offset: 0x000E50AC
		// (set) Token: 0x060078BC RID: 30908 RVA: 0x000E6ED8 File Offset: 0x000E50D8
		[ProtoMember(11, IsRequired = false, Name = "continue_login_time", DataFormat = DataFormat.TwosComplement)]
		public uint continue_login_time
		{
			get
			{
				return this._continue_login_time ?? 0U;
			}
			set
			{
				this._continue_login_time = new uint?(value);
			}
		}

		// Token: 0x1700263F RID: 9791
		// (get) Token: 0x060078BD RID: 30909 RVA: 0x000E6EE8 File Offset: 0x000E50E8
		// (set) Token: 0x060078BE RID: 30910 RVA: 0x000E6F08 File Offset: 0x000E5108
		[XmlIgnore]
		[Browsable(false)]
		public bool continue_login_timeSpecified
		{
			get
			{
				return this._continue_login_time != null;
			}
			set
			{
				bool flag = value == (this._continue_login_time == null);
				if (flag)
				{
					this._continue_login_time = (value ? new uint?(this.continue_login_time) : null);
				}
			}
		}

		// Token: 0x060078BF RID: 30911 RVA: 0x000E6F4C File Offset: 0x000E514C
		private bool ShouldSerializecontinue_login_time()
		{
			return this.continue_login_timeSpecified;
		}

		// Token: 0x060078C0 RID: 30912 RVA: 0x000E6F64 File Offset: 0x000E5164
		private void Resetcontinue_login_time()
		{
			this.continue_login_timeSpecified = false;
		}

		// Token: 0x17002640 RID: 9792
		// (get) Token: 0x060078C1 RID: 30913 RVA: 0x000E6F70 File Offset: 0x000E5170
		// (set) Token: 0x060078C2 RID: 30914 RVA: 0x000E6F9C File Offset: 0x000E519C
		[ProtoMember(12, IsRequired = false, Name = "online_time", DataFormat = DataFormat.TwosComplement)]
		public uint online_time
		{
			get
			{
				return this._online_time ?? 0U;
			}
			set
			{
				this._online_time = new uint?(value);
			}
		}

		// Token: 0x17002641 RID: 9793
		// (get) Token: 0x060078C3 RID: 30915 RVA: 0x000E6FAC File Offset: 0x000E51AC
		// (set) Token: 0x060078C4 RID: 30916 RVA: 0x000E6FCC File Offset: 0x000E51CC
		[XmlIgnore]
		[Browsable(false)]
		public bool online_timeSpecified
		{
			get
			{
				return this._online_time != null;
			}
			set
			{
				bool flag = value == (this._online_time == null);
				if (flag)
				{
					this._online_time = (value ? new uint?(this.online_time) : null);
				}
			}
		}

		// Token: 0x060078C5 RID: 30917 RVA: 0x000E7010 File Offset: 0x000E5210
		private bool ShouldSerializeonline_time()
		{
			return this.online_timeSpecified;
		}

		// Token: 0x060078C6 RID: 30918 RVA: 0x000E7028 File Offset: 0x000E5228
		private void Resetonline_time()
		{
			this.online_timeSpecified = false;
		}

		// Token: 0x17002642 RID: 9794
		// (get) Token: 0x060078C7 RID: 30919 RVA: 0x000E7034 File Offset: 0x000E5234
		[ProtoMember(13, Name = "carrer_data", DataFormat = DataFormat.Default)]
		public List<CareerData> carrer_data
		{
			get
			{
				return this._carrer_data;
			}
		}

		// Token: 0x060078C8 RID: 30920 RVA: 0x000E704C File Offset: 0x000E524C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C7D RID: 7293
		private uint? _qq_vip;

		// Token: 0x04001C7E RID: 7294
		private uint? _paymember_id;

		// Token: 0x04001C7F RID: 7295
		private string _play_name;

		// Token: 0x04001C80 RID: 7296
		private uint? _uid;

		// Token: 0x04001C81 RID: 7297
		private string _declaration;

		// Token: 0x04001C82 RID: 7298
		private string _server_name;

		// Token: 0x04001C83 RID: 7299
		private uint? _level;

		// Token: 0x04001C84 RID: 7300
		private uint? _profession_id;

		// Token: 0x04001C85 RID: 7301
		private string _guild_name;

		// Token: 0x04001C86 RID: 7302
		private double? _power;

		// Token: 0x04001C87 RID: 7303
		private uint? _continue_login_time;

		// Token: 0x04001C88 RID: 7304
		private uint? _online_time;

		// Token: 0x04001C89 RID: 7305
		private readonly List<CareerData> _carrer_data = new List<CareerData>();

		// Token: 0x04001C8A RID: 7306
		private IExtension extensionObject;
	}
}
