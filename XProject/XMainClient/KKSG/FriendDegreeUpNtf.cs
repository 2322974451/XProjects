using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000F0 RID: 240
	[ProtoContract(Name = "FriendDegreeUpNtf")]
	[Serializable]
	public class FriendDegreeUpNtf : IExtensible
	{
		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x0001F6F4 File Offset: 0x0001D8F4
		// (set) Token: 0x06000F40 RID: 3904 RVA: 0x0001F721 File Offset: 0x0001D921
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

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06000F41 RID: 3905 RVA: 0x0001F730 File Offset: 0x0001D930
		// (set) Token: 0x06000F42 RID: 3906 RVA: 0x0001F750 File Offset: 0x0001D950
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

		// Token: 0x06000F43 RID: 3907 RVA: 0x0001F794 File Offset: 0x0001D994
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x0001F7AC File Offset: 0x0001D9AC
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06000F45 RID: 3909 RVA: 0x0001F7B8 File Offset: 0x0001D9B8
		// (set) Token: 0x06000F46 RID: 3910 RVA: 0x0001F7D9 File Offset: 0x0001D9D9
		[ProtoMember(2, IsRequired = false, Name = "friendname", DataFormat = DataFormat.Default)]
		public string friendname
		{
			get
			{
				return this._friendname ?? "";
			}
			set
			{
				this._friendname = value;
			}
		}

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06000F47 RID: 3911 RVA: 0x0001F7E4 File Offset: 0x0001D9E4
		// (set) Token: 0x06000F48 RID: 3912 RVA: 0x0001F800 File Offset: 0x0001DA00
		[XmlIgnore]
		[Browsable(false)]
		public bool friendnameSpecified
		{
			get
			{
				return this._friendname != null;
			}
			set
			{
				bool flag = value == (this._friendname == null);
				if (flag)
				{
					this._friendname = (value ? this.friendname : null);
				}
			}
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x0001F830 File Offset: 0x0001DA30
		private bool ShouldSerializefriendname()
		{
			return this.friendnameSpecified;
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x0001F848 File Offset: 0x0001DA48
		private void Resetfriendname()
		{
			this.friendnameSpecified = false;
		}

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06000F4B RID: 3915 RVA: 0x0001F854 File Offset: 0x0001DA54
		// (set) Token: 0x06000F4C RID: 3916 RVA: 0x0001F880 File Offset: 0x0001DA80
		[ProtoMember(3, IsRequired = false, Name = "orginlevel", DataFormat = DataFormat.TwosComplement)]
		public uint orginlevel
		{
			get
			{
				return this._orginlevel ?? 0U;
			}
			set
			{
				this._orginlevel = new uint?(value);
			}
		}

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06000F4D RID: 3917 RVA: 0x0001F890 File Offset: 0x0001DA90
		// (set) Token: 0x06000F4E RID: 3918 RVA: 0x0001F8B0 File Offset: 0x0001DAB0
		[XmlIgnore]
		[Browsable(false)]
		public bool orginlevelSpecified
		{
			get
			{
				return this._orginlevel != null;
			}
			set
			{
				bool flag = value == (this._orginlevel == null);
				if (flag)
				{
					this._orginlevel = (value ? new uint?(this.orginlevel) : null);
				}
			}
		}

		// Token: 0x06000F4F RID: 3919 RVA: 0x0001F8F4 File Offset: 0x0001DAF4
		private bool ShouldSerializeorginlevel()
		{
			return this.orginlevelSpecified;
		}

		// Token: 0x06000F50 RID: 3920 RVA: 0x0001F90C File Offset: 0x0001DB0C
		private void Resetorginlevel()
		{
			this.orginlevelSpecified = false;
		}

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06000F51 RID: 3921 RVA: 0x0001F918 File Offset: 0x0001DB18
		// (set) Token: 0x06000F52 RID: 3922 RVA: 0x0001F944 File Offset: 0x0001DB44
		[ProtoMember(4, IsRequired = false, Name = "currentlevel", DataFormat = DataFormat.TwosComplement)]
		public uint currentlevel
		{
			get
			{
				return this._currentlevel ?? 0U;
			}
			set
			{
				this._currentlevel = new uint?(value);
			}
		}

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06000F53 RID: 3923 RVA: 0x0001F954 File Offset: 0x0001DB54
		// (set) Token: 0x06000F54 RID: 3924 RVA: 0x0001F974 File Offset: 0x0001DB74
		[XmlIgnore]
		[Browsable(false)]
		public bool currentlevelSpecified
		{
			get
			{
				return this._currentlevel != null;
			}
			set
			{
				bool flag = value == (this._currentlevel == null);
				if (flag)
				{
					this._currentlevel = (value ? new uint?(this.currentlevel) : null);
				}
			}
		}

		// Token: 0x06000F55 RID: 3925 RVA: 0x0001F9B8 File Offset: 0x0001DBB8
		private bool ShouldSerializecurrentlevel()
		{
			return this.currentlevelSpecified;
		}

		// Token: 0x06000F56 RID: 3926 RVA: 0x0001F9D0 File Offset: 0x0001DBD0
		private void Resetcurrentlevel()
		{
			this.currentlevelSpecified = false;
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06000F57 RID: 3927 RVA: 0x0001F9DC File Offset: 0x0001DBDC
		// (set) Token: 0x06000F58 RID: 3928 RVA: 0x0001FA08 File Offset: 0x0001DC08
		[ProtoMember(5, IsRequired = false, Name = "currentleft", DataFormat = DataFormat.TwosComplement)]
		public uint currentleft
		{
			get
			{
				return this._currentleft ?? 0U;
			}
			set
			{
				this._currentleft = new uint?(value);
			}
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06000F59 RID: 3929 RVA: 0x0001FA18 File Offset: 0x0001DC18
		// (set) Token: 0x06000F5A RID: 3930 RVA: 0x0001FA38 File Offset: 0x0001DC38
		[XmlIgnore]
		[Browsable(false)]
		public bool currentleftSpecified
		{
			get
			{
				return this._currentleft != null;
			}
			set
			{
				bool flag = value == (this._currentleft == null);
				if (flag)
				{
					this._currentleft = (value ? new uint?(this.currentleft) : null);
				}
			}
		}

		// Token: 0x06000F5B RID: 3931 RVA: 0x0001FA7C File Offset: 0x0001DC7C
		private bool ShouldSerializecurrentleft()
		{
			return this.currentleftSpecified;
		}

		// Token: 0x06000F5C RID: 3932 RVA: 0x0001FA94 File Offset: 0x0001DC94
		private void Resetcurrentleft()
		{
			this.currentleftSpecified = false;
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06000F5D RID: 3933 RVA: 0x0001FAA0 File Offset: 0x0001DCA0
		// (set) Token: 0x06000F5E RID: 3934 RVA: 0x0001FACC File Offset: 0x0001DCCC
		[ProtoMember(6, IsRequired = false, Name = "daydegree", DataFormat = DataFormat.TwosComplement)]
		public uint daydegree
		{
			get
			{
				return this._daydegree ?? 0U;
			}
			set
			{
				this._daydegree = new uint?(value);
			}
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06000F5F RID: 3935 RVA: 0x0001FADC File Offset: 0x0001DCDC
		// (set) Token: 0x06000F60 RID: 3936 RVA: 0x0001FAFC File Offset: 0x0001DCFC
		[XmlIgnore]
		[Browsable(false)]
		public bool daydegreeSpecified
		{
			get
			{
				return this._daydegree != null;
			}
			set
			{
				bool flag = value == (this._daydegree == null);
				if (flag)
				{
					this._daydegree = (value ? new uint?(this.daydegree) : null);
				}
			}
		}

		// Token: 0x06000F61 RID: 3937 RVA: 0x0001FB40 File Offset: 0x0001DD40
		private bool ShouldSerializedaydegree()
		{
			return this.daydegreeSpecified;
		}

		// Token: 0x06000F62 RID: 3938 RVA: 0x0001FB58 File Offset: 0x0001DD58
		private void Resetdaydegree()
		{
			this.daydegreeSpecified = false;
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06000F63 RID: 3939 RVA: 0x0001FB64 File Offset: 0x0001DD64
		// (set) Token: 0x06000F64 RID: 3940 RVA: 0x0001FB90 File Offset: 0x0001DD90
		[ProtoMember(7, IsRequired = false, Name = "alldegree", DataFormat = DataFormat.TwosComplement)]
		public uint alldegree
		{
			get
			{
				return this._alldegree ?? 0U;
			}
			set
			{
				this._alldegree = new uint?(value);
			}
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06000F65 RID: 3941 RVA: 0x0001FBA0 File Offset: 0x0001DDA0
		// (set) Token: 0x06000F66 RID: 3942 RVA: 0x0001FBC0 File Offset: 0x0001DDC0
		[XmlIgnore]
		[Browsable(false)]
		public bool alldegreeSpecified
		{
			get
			{
				return this._alldegree != null;
			}
			set
			{
				bool flag = value == (this._alldegree == null);
				if (flag)
				{
					this._alldegree = (value ? new uint?(this.alldegree) : null);
				}
			}
		}

		// Token: 0x06000F67 RID: 3943 RVA: 0x0001FC04 File Offset: 0x0001DE04
		private bool ShouldSerializealldegree()
		{
			return this.alldegreeSpecified;
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x0001FC1C File Offset: 0x0001DE1C
		private void Resetalldegree()
		{
			this.alldegreeSpecified = false;
		}

		// Token: 0x06000F69 RID: 3945 RVA: 0x0001FC28 File Offset: 0x0001DE28
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003D4 RID: 980
		private ulong? _roleid;

		// Token: 0x040003D5 RID: 981
		private string _friendname;

		// Token: 0x040003D6 RID: 982
		private uint? _orginlevel;

		// Token: 0x040003D7 RID: 983
		private uint? _currentlevel;

		// Token: 0x040003D8 RID: 984
		private uint? _currentleft;

		// Token: 0x040003D9 RID: 985
		private uint? _daydegree;

		// Token: 0x040003DA RID: 986
		private uint? _alldegree;

		// Token: 0x040003DB RID: 987
		private IExtension extensionObject;
	}
}
