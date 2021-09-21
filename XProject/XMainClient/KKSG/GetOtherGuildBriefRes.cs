using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000A6 RID: 166
	[ProtoContract(Name = "GetOtherGuildBriefRes")]
	[Serializable]
	public class GetOtherGuildBriefRes : IExtensible
	{
		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06000B4F RID: 2895 RVA: 0x000182EC File Offset: 0x000164EC
		// (set) Token: 0x06000B50 RID: 2896 RVA: 0x00018318 File Offset: 0x00016518
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06000B51 RID: 2897 RVA: 0x00018328 File Offset: 0x00016528
		// (set) Token: 0x06000B52 RID: 2898 RVA: 0x00018348 File Offset: 0x00016548
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x0001838C File Offset: 0x0001658C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x000183A4 File Offset: 0x000165A4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06000B55 RID: 2901 RVA: 0x000183B0 File Offset: 0x000165B0
		// (set) Token: 0x06000B56 RID: 2902 RVA: 0x000183D1 File Offset: 0x000165D1
		[ProtoMember(2, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06000B57 RID: 2903 RVA: 0x000183DC File Offset: 0x000165DC
		// (set) Token: 0x06000B58 RID: 2904 RVA: 0x000183F8 File Offset: 0x000165F8
		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x00018428 File Offset: 0x00016628
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x00018440 File Offset: 0x00016640
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06000B5B RID: 2907 RVA: 0x0001844C File Offset: 0x0001664C
		// (set) Token: 0x06000B5C RID: 2908 RVA: 0x0001846D File Offset: 0x0001666D
		[ProtoMember(3, IsRequired = false, Name = "leadername", DataFormat = DataFormat.Default)]
		public string leadername
		{
			get
			{
				return this._leadername ?? "";
			}
			set
			{
				this._leadername = value;
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x06000B5D RID: 2909 RVA: 0x00018478 File Offset: 0x00016678
		// (set) Token: 0x06000B5E RID: 2910 RVA: 0x00018494 File Offset: 0x00016694
		[XmlIgnore]
		[Browsable(false)]
		public bool leadernameSpecified
		{
			get
			{
				return this._leadername != null;
			}
			set
			{
				bool flag = value == (this._leadername == null);
				if (flag)
				{
					this._leadername = (value ? this.leadername : null);
				}
			}
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x000184C4 File Offset: 0x000166C4
		private bool ShouldSerializeleadername()
		{
			return this.leadernameSpecified;
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x000184DC File Offset: 0x000166DC
		private void Resetleadername()
		{
			this.leadernameSpecified = false;
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x06000B61 RID: 2913 RVA: 0x000184E8 File Offset: 0x000166E8
		// (set) Token: 0x06000B62 RID: 2914 RVA: 0x00018515 File Offset: 0x00016715
		[ProtoMember(4, IsRequired = false, Name = "leaderid", DataFormat = DataFormat.TwosComplement)]
		public ulong leaderid
		{
			get
			{
				return this._leaderid ?? 0UL;
			}
			set
			{
				this._leaderid = new ulong?(value);
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x06000B63 RID: 2915 RVA: 0x00018524 File Offset: 0x00016724
		// (set) Token: 0x06000B64 RID: 2916 RVA: 0x00018544 File Offset: 0x00016744
		[XmlIgnore]
		[Browsable(false)]
		public bool leaderidSpecified
		{
			get
			{
				return this._leaderid != null;
			}
			set
			{
				bool flag = value == (this._leaderid == null);
				if (flag)
				{
					this._leaderid = (value ? new ulong?(this.leaderid) : null);
				}
			}
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x00018588 File Offset: 0x00016788
		private bool ShouldSerializeleaderid()
		{
			return this.leaderidSpecified;
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x000185A0 File Offset: 0x000167A0
		private void Resetleaderid()
		{
			this.leaderidSpecified = false;
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x06000B67 RID: 2919 RVA: 0x000185AC File Offset: 0x000167AC
		// (set) Token: 0x06000B68 RID: 2920 RVA: 0x000185D8 File Offset: 0x000167D8
		[ProtoMember(5, IsRequired = false, Name = "guildlevel", DataFormat = DataFormat.TwosComplement)]
		public uint guildlevel
		{
			get
			{
				return this._guildlevel ?? 0U;
			}
			set
			{
				this._guildlevel = new uint?(value);
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06000B69 RID: 2921 RVA: 0x000185E8 File Offset: 0x000167E8
		// (set) Token: 0x06000B6A RID: 2922 RVA: 0x00018608 File Offset: 0x00016808
		[XmlIgnore]
		[Browsable(false)]
		public bool guildlevelSpecified
		{
			get
			{
				return this._guildlevel != null;
			}
			set
			{
				bool flag = value == (this._guildlevel == null);
				if (flag)
				{
					this._guildlevel = (value ? new uint?(this.guildlevel) : null);
				}
			}
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x0001864C File Offset: 0x0001684C
		private bool ShouldSerializeguildlevel()
		{
			return this.guildlevelSpecified;
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x00018664 File Offset: 0x00016864
		private void Resetguildlevel()
		{
			this.guildlevelSpecified = false;
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06000B6D RID: 2925 RVA: 0x00018670 File Offset: 0x00016870
		// (set) Token: 0x06000B6E RID: 2926 RVA: 0x0001869C File Offset: 0x0001689C
		[ProtoMember(6, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
		public uint icon
		{
			get
			{
				return this._icon ?? 0U;
			}
			set
			{
				this._icon = new uint?(value);
			}
		}

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06000B6F RID: 2927 RVA: 0x000186AC File Offset: 0x000168AC
		// (set) Token: 0x06000B70 RID: 2928 RVA: 0x000186CC File Offset: 0x000168CC
		[XmlIgnore]
		[Browsable(false)]
		public bool iconSpecified
		{
			get
			{
				return this._icon != null;
			}
			set
			{
				bool flag = value == (this._icon == null);
				if (flag)
				{
					this._icon = (value ? new uint?(this.icon) : null);
				}
			}
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x00018710 File Offset: 0x00016910
		private bool ShouldSerializeicon()
		{
			return this.iconSpecified;
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x00018728 File Offset: 0x00016928
		private void Reseticon()
		{
			this.iconSpecified = false;
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06000B73 RID: 2931 RVA: 0x00018734 File Offset: 0x00016934
		// (set) Token: 0x06000B74 RID: 2932 RVA: 0x00018755 File Offset: 0x00016955
		[ProtoMember(7, IsRequired = false, Name = "announcement", DataFormat = DataFormat.Default)]
		public string announcement
		{
			get
			{
				return this._announcement ?? "";
			}
			set
			{
				this._announcement = value;
			}
		}

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06000B75 RID: 2933 RVA: 0x00018760 File Offset: 0x00016960
		// (set) Token: 0x06000B76 RID: 2934 RVA: 0x0001877C File Offset: 0x0001697C
		[XmlIgnore]
		[Browsable(false)]
		public bool announcementSpecified
		{
			get
			{
				return this._announcement != null;
			}
			set
			{
				bool flag = value == (this._announcement == null);
				if (flag)
				{
					this._announcement = (value ? this.announcement : null);
				}
			}
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x000187AC File Offset: 0x000169AC
		private bool ShouldSerializeannouncement()
		{
			return this.announcementSpecified;
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x000187C4 File Offset: 0x000169C4
		private void Resetannouncement()
		{
			this.announcementSpecified = false;
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x06000B79 RID: 2937 RVA: 0x000187D0 File Offset: 0x000169D0
		// (set) Token: 0x06000B7A RID: 2938 RVA: 0x000187FC File Offset: 0x000169FC
		[ProtoMember(8, IsRequired = false, Name = "currentcount", DataFormat = DataFormat.TwosComplement)]
		public uint currentcount
		{
			get
			{
				return this._currentcount ?? 0U;
			}
			set
			{
				this._currentcount = new uint?(value);
			}
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x06000B7B RID: 2939 RVA: 0x0001880C File Offset: 0x00016A0C
		// (set) Token: 0x06000B7C RID: 2940 RVA: 0x0001882C File Offset: 0x00016A2C
		[XmlIgnore]
		[Browsable(false)]
		public bool currentcountSpecified
		{
			get
			{
				return this._currentcount != null;
			}
			set
			{
				bool flag = value == (this._currentcount == null);
				if (flag)
				{
					this._currentcount = (value ? new uint?(this.currentcount) : null);
				}
			}
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x00018870 File Offset: 0x00016A70
		private bool ShouldSerializecurrentcount()
		{
			return this.currentcountSpecified;
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x00018888 File Offset: 0x00016A88
		private void Resetcurrentcount()
		{
			this.currentcountSpecified = false;
		}

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x06000B7F RID: 2943 RVA: 0x00018894 File Offset: 0x00016A94
		// (set) Token: 0x06000B80 RID: 2944 RVA: 0x000188C0 File Offset: 0x00016AC0
		[ProtoMember(9, IsRequired = false, Name = "allcount", DataFormat = DataFormat.TwosComplement)]
		public uint allcount
		{
			get
			{
				return this._allcount ?? 0U;
			}
			set
			{
				this._allcount = new uint?(value);
			}
		}

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06000B81 RID: 2945 RVA: 0x000188D0 File Offset: 0x00016AD0
		// (set) Token: 0x06000B82 RID: 2946 RVA: 0x000188F0 File Offset: 0x00016AF0
		[XmlIgnore]
		[Browsable(false)]
		public bool allcountSpecified
		{
			get
			{
				return this._allcount != null;
			}
			set
			{
				bool flag = value == (this._allcount == null);
				if (flag)
				{
					this._allcount = (value ? new uint?(this.allcount) : null);
				}
			}
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x00018934 File Offset: 0x00016B34
		private bool ShouldSerializeallcount()
		{
			return this.allcountSpecified;
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x0001894C File Offset: 0x00016B4C
		private void Resetallcount()
		{
			this.allcountSpecified = false;
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x00018958 File Offset: 0x00016B58
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002D5 RID: 725
		private ErrorCode? _errorcode;

		// Token: 0x040002D6 RID: 726
		private string _guildname;

		// Token: 0x040002D7 RID: 727
		private string _leadername;

		// Token: 0x040002D8 RID: 728
		private ulong? _leaderid;

		// Token: 0x040002D9 RID: 729
		private uint? _guildlevel;

		// Token: 0x040002DA RID: 730
		private uint? _icon;

		// Token: 0x040002DB RID: 731
		private string _announcement;

		// Token: 0x040002DC RID: 732
		private uint? _currentcount;

		// Token: 0x040002DD RID: 733
		private uint? _allcount;

		// Token: 0x040002DE RID: 734
		private IExtension extensionObject;
	}
}
