using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000673 RID: 1651
	[ProtoContract(Name = "DragonGroupRecordInfoList")]
	[Serializable]
	public class DragonGroupRecordInfoList : IExtensible
	{
		// Token: 0x17002137 RID: 8503
		// (get) Token: 0x0600690A RID: 26890 RVA: 0x000C8CA8 File Offset: 0x000C6EA8
		// (set) Token: 0x0600690B RID: 26891 RVA: 0x000C8CD4 File Offset: 0x000C6ED4
		[ProtoMember(1, IsRequired = false, Name = "stageid", DataFormat = DataFormat.TwosComplement)]
		public uint stageid
		{
			get
			{
				return this._stageid ?? 0U;
			}
			set
			{
				this._stageid = new uint?(value);
			}
		}

		// Token: 0x17002138 RID: 8504
		// (get) Token: 0x0600690C RID: 26892 RVA: 0x000C8CE4 File Offset: 0x000C6EE4
		// (set) Token: 0x0600690D RID: 26893 RVA: 0x000C8D04 File Offset: 0x000C6F04
		[XmlIgnore]
		[Browsable(false)]
		public bool stageidSpecified
		{
			get
			{
				return this._stageid != null;
			}
			set
			{
				bool flag = value == (this._stageid == null);
				if (flag)
				{
					this._stageid = (value ? new uint?(this.stageid) : null);
				}
			}
		}

		// Token: 0x0600690E RID: 26894 RVA: 0x000C8D48 File Offset: 0x000C6F48
		private bool ShouldSerializestageid()
		{
			return this.stageidSpecified;
		}

		// Token: 0x0600690F RID: 26895 RVA: 0x000C8D60 File Offset: 0x000C6F60
		private void Resetstageid()
		{
			this.stageidSpecified = false;
		}

		// Token: 0x17002139 RID: 8505
		// (get) Token: 0x06006910 RID: 26896 RVA: 0x000C8D6C File Offset: 0x000C6F6C
		// (set) Token: 0x06006911 RID: 26897 RVA: 0x000C8D98 File Offset: 0x000C6F98
		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700213A RID: 8506
		// (get) Token: 0x06006912 RID: 26898 RVA: 0x000C8DA8 File Offset: 0x000C6FA8
		// (set) Token: 0x06006913 RID: 26899 RVA: 0x000C8DC8 File Offset: 0x000C6FC8
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

		// Token: 0x06006914 RID: 26900 RVA: 0x000C8E0C File Offset: 0x000C700C
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06006915 RID: 26901 RVA: 0x000C8E24 File Offset: 0x000C7024
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x1700213B RID: 8507
		// (get) Token: 0x06006916 RID: 26902 RVA: 0x000C8E30 File Offset: 0x000C7030
		// (set) Token: 0x06006917 RID: 26903 RVA: 0x000C8E5C File Offset: 0x000C705C
		[ProtoMember(3, IsRequired = false, Name = "costtime", DataFormat = DataFormat.TwosComplement)]
		public uint costtime
		{
			get
			{
				return this._costtime ?? 0U;
			}
			set
			{
				this._costtime = new uint?(value);
			}
		}

		// Token: 0x1700213C RID: 8508
		// (get) Token: 0x06006918 RID: 26904 RVA: 0x000C8E6C File Offset: 0x000C706C
		// (set) Token: 0x06006919 RID: 26905 RVA: 0x000C8E8C File Offset: 0x000C708C
		[XmlIgnore]
		[Browsable(false)]
		public bool costtimeSpecified
		{
			get
			{
				return this._costtime != null;
			}
			set
			{
				bool flag = value == (this._costtime == null);
				if (flag)
				{
					this._costtime = (value ? new uint?(this.costtime) : null);
				}
			}
		}

		// Token: 0x0600691A RID: 26906 RVA: 0x000C8ED0 File Offset: 0x000C70D0
		private bool ShouldSerializecosttime()
		{
			return this.costtimeSpecified;
		}

		// Token: 0x0600691B RID: 26907 RVA: 0x000C8EE8 File Offset: 0x000C70E8
		private void Resetcosttime()
		{
			this.costtimeSpecified = false;
		}

		// Token: 0x1700213D RID: 8509
		// (get) Token: 0x0600691C RID: 26908 RVA: 0x000C8EF4 File Offset: 0x000C70F4
		[ProtoMember(4, Name = "roleinfo", DataFormat = DataFormat.Default)]
		public List<DragonGroupRoleInfo> roleinfo
		{
			get
			{
				return this._roleinfo;
			}
		}

		// Token: 0x1700213E RID: 8510
		// (get) Token: 0x0600691D RID: 26909 RVA: 0x000C8F0C File Offset: 0x000C710C
		// (set) Token: 0x0600691E RID: 26910 RVA: 0x000C8F38 File Offset: 0x000C7138
		[ProtoMember(5, IsRequired = false, Name = "iswin", DataFormat = DataFormat.Default)]
		public bool iswin
		{
			get
			{
				return this._iswin ?? false;
			}
			set
			{
				this._iswin = new bool?(value);
			}
		}

		// Token: 0x1700213F RID: 8511
		// (get) Token: 0x0600691F RID: 26911 RVA: 0x000C8F48 File Offset: 0x000C7148
		// (set) Token: 0x06006920 RID: 26912 RVA: 0x000C8F68 File Offset: 0x000C7168
		[XmlIgnore]
		[Browsable(false)]
		public bool iswinSpecified
		{
			get
			{
				return this._iswin != null;
			}
			set
			{
				bool flag = value == (this._iswin == null);
				if (flag)
				{
					this._iswin = (value ? new bool?(this.iswin) : null);
				}
			}
		}

		// Token: 0x06006921 RID: 26913 RVA: 0x000C8FAC File Offset: 0x000C71AC
		private bool ShouldSerializeiswin()
		{
			return this.iswinSpecified;
		}

		// Token: 0x06006922 RID: 26914 RVA: 0x000C8FC4 File Offset: 0x000C71C4
		private void Resetiswin()
		{
			this.iswinSpecified = false;
		}

		// Token: 0x17002140 RID: 8512
		// (get) Token: 0x06006923 RID: 26915 RVA: 0x000C8FD0 File Offset: 0x000C71D0
		// (set) Token: 0x06006924 RID: 26916 RVA: 0x000C8FFC File Offset: 0x000C71FC
		[ProtoMember(6, IsRequired = false, Name = "isFirstPass", DataFormat = DataFormat.Default)]
		public bool isFirstPass
		{
			get
			{
				return this._isFirstPass ?? false;
			}
			set
			{
				this._isFirstPass = new bool?(value);
			}
		}

		// Token: 0x17002141 RID: 8513
		// (get) Token: 0x06006925 RID: 26917 RVA: 0x000C900C File Offset: 0x000C720C
		// (set) Token: 0x06006926 RID: 26918 RVA: 0x000C902C File Offset: 0x000C722C
		[XmlIgnore]
		[Browsable(false)]
		public bool isFirstPassSpecified
		{
			get
			{
				return this._isFirstPass != null;
			}
			set
			{
				bool flag = value == (this._isFirstPass == null);
				if (flag)
				{
					this._isFirstPass = (value ? new bool?(this.isFirstPass) : null);
				}
			}
		}

		// Token: 0x06006927 RID: 26919 RVA: 0x000C9070 File Offset: 0x000C7270
		private bool ShouldSerializeisFirstPass()
		{
			return this.isFirstPassSpecified;
		}

		// Token: 0x06006928 RID: 26920 RVA: 0x000C9088 File Offset: 0x000C7288
		private void ResetisFirstPass()
		{
			this.isFirstPassSpecified = false;
		}

		// Token: 0x17002142 RID: 8514
		// (get) Token: 0x06006929 RID: 26921 RVA: 0x000C9094 File Offset: 0x000C7294
		// (set) Token: 0x0600692A RID: 26922 RVA: 0x000C90C0 File Offset: 0x000C72C0
		[ProtoMember(7, IsRequired = false, Name = "isServerFirstPass", DataFormat = DataFormat.Default)]
		public bool isServerFirstPass
		{
			get
			{
				return this._isServerFirstPass ?? false;
			}
			set
			{
				this._isServerFirstPass = new bool?(value);
			}
		}

		// Token: 0x17002143 RID: 8515
		// (get) Token: 0x0600692B RID: 26923 RVA: 0x000C90D0 File Offset: 0x000C72D0
		// (set) Token: 0x0600692C RID: 26924 RVA: 0x000C90F0 File Offset: 0x000C72F0
		[XmlIgnore]
		[Browsable(false)]
		public bool isServerFirstPassSpecified
		{
			get
			{
				return this._isServerFirstPass != null;
			}
			set
			{
				bool flag = value == (this._isServerFirstPass == null);
				if (flag)
				{
					this._isServerFirstPass = (value ? new bool?(this.isServerFirstPass) : null);
				}
			}
		}

		// Token: 0x0600692D RID: 26925 RVA: 0x000C9134 File Offset: 0x000C7334
		private bool ShouldSerializeisServerFirstPass()
		{
			return this.isServerFirstPassSpecified;
		}

		// Token: 0x0600692E RID: 26926 RVA: 0x000C914C File Offset: 0x000C734C
		private void ResetisServerFirstPass()
		{
			this.isServerFirstPassSpecified = false;
		}

		// Token: 0x17002144 RID: 8516
		// (get) Token: 0x0600692F RID: 26927 RVA: 0x000C9158 File Offset: 0x000C7358
		// (set) Token: 0x06006930 RID: 26928 RVA: 0x000C9184 File Offset: 0x000C7384
		[ProtoMember(8, IsRequired = false, Name = "commendnum", DataFormat = DataFormat.TwosComplement)]
		public uint commendnum
		{
			get
			{
				return this._commendnum ?? 0U;
			}
			set
			{
				this._commendnum = new uint?(value);
			}
		}

		// Token: 0x17002145 RID: 8517
		// (get) Token: 0x06006931 RID: 26929 RVA: 0x000C9194 File Offset: 0x000C7394
		// (set) Token: 0x06006932 RID: 26930 RVA: 0x000C91B4 File Offset: 0x000C73B4
		[XmlIgnore]
		[Browsable(false)]
		public bool commendnumSpecified
		{
			get
			{
				return this._commendnum != null;
			}
			set
			{
				bool flag = value == (this._commendnum == null);
				if (flag)
				{
					this._commendnum = (value ? new uint?(this.commendnum) : null);
				}
			}
		}

		// Token: 0x06006933 RID: 26931 RVA: 0x000C91F8 File Offset: 0x000C73F8
		private bool ShouldSerializecommendnum()
		{
			return this.commendnumSpecified;
		}

		// Token: 0x06006934 RID: 26932 RVA: 0x000C9210 File Offset: 0x000C7410
		private void Resetcommendnum()
		{
			this.commendnumSpecified = false;
		}

		// Token: 0x17002146 RID: 8518
		// (get) Token: 0x06006935 RID: 26933 RVA: 0x000C921C File Offset: 0x000C741C
		// (set) Token: 0x06006936 RID: 26934 RVA: 0x000C9248 File Offset: 0x000C7448
		[ProtoMember(9, IsRequired = false, Name = "watchnum", DataFormat = DataFormat.TwosComplement)]
		public uint watchnum
		{
			get
			{
				return this._watchnum ?? 0U;
			}
			set
			{
				this._watchnum = new uint?(value);
			}
		}

		// Token: 0x17002147 RID: 8519
		// (get) Token: 0x06006937 RID: 26935 RVA: 0x000C9258 File Offset: 0x000C7458
		// (set) Token: 0x06006938 RID: 26936 RVA: 0x000C9278 File Offset: 0x000C7478
		[XmlIgnore]
		[Browsable(false)]
		public bool watchnumSpecified
		{
			get
			{
				return this._watchnum != null;
			}
			set
			{
				bool flag = value == (this._watchnum == null);
				if (flag)
				{
					this._watchnum = (value ? new uint?(this.watchnum) : null);
				}
			}
		}

		// Token: 0x06006939 RID: 26937 RVA: 0x000C92BC File Offset: 0x000C74BC
		private bool ShouldSerializewatchnum()
		{
			return this.watchnumSpecified;
		}

		// Token: 0x0600693A RID: 26938 RVA: 0x000C92D4 File Offset: 0x000C74D4
		private void Resetwatchnum()
		{
			this.watchnumSpecified = false;
		}

		// Token: 0x17002148 RID: 8520
		// (get) Token: 0x0600693B RID: 26939 RVA: 0x000C92E0 File Offset: 0x000C74E0
		// (set) Token: 0x0600693C RID: 26940 RVA: 0x000C930C File Offset: 0x000C750C
		[ProtoMember(10, IsRequired = false, Name = "ismostcommendnum", DataFormat = DataFormat.Default)]
		public bool ismostcommendnum
		{
			get
			{
				return this._ismostcommendnum ?? false;
			}
			set
			{
				this._ismostcommendnum = new bool?(value);
			}
		}

		// Token: 0x17002149 RID: 8521
		// (get) Token: 0x0600693D RID: 26941 RVA: 0x000C931C File Offset: 0x000C751C
		// (set) Token: 0x0600693E RID: 26942 RVA: 0x000C933C File Offset: 0x000C753C
		[XmlIgnore]
		[Browsable(false)]
		public bool ismostcommendnumSpecified
		{
			get
			{
				return this._ismostcommendnum != null;
			}
			set
			{
				bool flag = value == (this._ismostcommendnum == null);
				if (flag)
				{
					this._ismostcommendnum = (value ? new bool?(this.ismostcommendnum) : null);
				}
			}
		}

		// Token: 0x0600693F RID: 26943 RVA: 0x000C9380 File Offset: 0x000C7580
		private bool ShouldSerializeismostcommendnum()
		{
			return this.ismostcommendnumSpecified;
		}

		// Token: 0x06006940 RID: 26944 RVA: 0x000C9398 File Offset: 0x000C7598
		private void Resetismostcommendnum()
		{
			this.ismostcommendnumSpecified = false;
		}

		// Token: 0x1700214A RID: 8522
		// (get) Token: 0x06006941 RID: 26945 RVA: 0x000C93A4 File Offset: 0x000C75A4
		// (set) Token: 0x06006942 RID: 26946 RVA: 0x000C93D0 File Offset: 0x000C75D0
		[ProtoMember(11, IsRequired = false, Name = "ismostwatchnum", DataFormat = DataFormat.Default)]
		public bool ismostwatchnum
		{
			get
			{
				return this._ismostwatchnum ?? false;
			}
			set
			{
				this._ismostwatchnum = new bool?(value);
			}
		}

		// Token: 0x1700214B RID: 8523
		// (get) Token: 0x06006943 RID: 26947 RVA: 0x000C93E0 File Offset: 0x000C75E0
		// (set) Token: 0x06006944 RID: 26948 RVA: 0x000C9400 File Offset: 0x000C7600
		[XmlIgnore]
		[Browsable(false)]
		public bool ismostwatchnumSpecified
		{
			get
			{
				return this._ismostwatchnum != null;
			}
			set
			{
				bool flag = value == (this._ismostwatchnum == null);
				if (flag)
				{
					this._ismostwatchnum = (value ? new bool?(this.ismostwatchnum) : null);
				}
			}
		}

		// Token: 0x06006945 RID: 26949 RVA: 0x000C9444 File Offset: 0x000C7644
		private bool ShouldSerializeismostwatchnum()
		{
			return this.ismostwatchnumSpecified;
		}

		// Token: 0x06006946 RID: 26950 RVA: 0x000C945C File Offset: 0x000C765C
		private void Resetismostwatchnum()
		{
			this.ismostwatchnumSpecified = false;
		}

		// Token: 0x06006947 RID: 26951 RVA: 0x000C9468 File Offset: 0x000C7668
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001957 RID: 6487
		private uint? _stageid;

		// Token: 0x04001958 RID: 6488
		private uint? _time;

		// Token: 0x04001959 RID: 6489
		private uint? _costtime;

		// Token: 0x0400195A RID: 6490
		private readonly List<DragonGroupRoleInfo> _roleinfo = new List<DragonGroupRoleInfo>();

		// Token: 0x0400195B RID: 6491
		private bool? _iswin;

		// Token: 0x0400195C RID: 6492
		private bool? _isFirstPass;

		// Token: 0x0400195D RID: 6493
		private bool? _isServerFirstPass;

		// Token: 0x0400195E RID: 6494
		private uint? _commendnum;

		// Token: 0x0400195F RID: 6495
		private uint? _watchnum;

		// Token: 0x04001960 RID: 6496
		private bool? _ismostcommendnum;

		// Token: 0x04001961 RID: 6497
		private bool? _ismostwatchnum;

		// Token: 0x04001962 RID: 6498
		private IExtension extensionObject;
	}
}
