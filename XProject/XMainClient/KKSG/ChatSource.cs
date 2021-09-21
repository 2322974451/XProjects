using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005A0 RID: 1440
	[ProtoContract(Name = "ChatSource")]
	[Serializable]
	public class ChatSource : IExtensible
	{
		// Token: 0x170017FE RID: 6142
		// (get) Token: 0x06004DCD RID: 19917 RVA: 0x000940CC File Offset: 0x000922CC
		// (set) Token: 0x06004DCE RID: 19918 RVA: 0x000940F9 File Offset: 0x000922F9
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

		// Token: 0x170017FF RID: 6143
		// (get) Token: 0x06004DCF RID: 19919 RVA: 0x00094108 File Offset: 0x00092308
		// (set) Token: 0x06004DD0 RID: 19920 RVA: 0x00094128 File Offset: 0x00092328
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

		// Token: 0x06004DD1 RID: 19921 RVA: 0x0009416C File Offset: 0x0009236C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06004DD2 RID: 19922 RVA: 0x00094184 File Offset: 0x00092384
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17001800 RID: 6144
		// (get) Token: 0x06004DD3 RID: 19923 RVA: 0x00094190 File Offset: 0x00092390
		// (set) Token: 0x06004DD4 RID: 19924 RVA: 0x000941BC File Offset: 0x000923BC
		[ProtoMember(2, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001801 RID: 6145
		// (get) Token: 0x06004DD5 RID: 19925 RVA: 0x000941CC File Offset: 0x000923CC
		// (set) Token: 0x06004DD6 RID: 19926 RVA: 0x000941EC File Offset: 0x000923EC
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

		// Token: 0x06004DD7 RID: 19927 RVA: 0x00094230 File Offset: 0x00092430
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06004DD8 RID: 19928 RVA: 0x00094248 File Offset: 0x00092448
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x17001802 RID: 6146
		// (get) Token: 0x06004DD9 RID: 19929 RVA: 0x00094254 File Offset: 0x00092454
		// (set) Token: 0x06004DDA RID: 19930 RVA: 0x00094275 File Offset: 0x00092475
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

		// Token: 0x17001803 RID: 6147
		// (get) Token: 0x06004DDB RID: 19931 RVA: 0x00094280 File Offset: 0x00092480
		// (set) Token: 0x06004DDC RID: 19932 RVA: 0x0009429C File Offset: 0x0009249C
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

		// Token: 0x06004DDD RID: 19933 RVA: 0x000942CC File Offset: 0x000924CC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06004DDE RID: 19934 RVA: 0x000942E4 File Offset: 0x000924E4
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17001804 RID: 6148
		// (get) Token: 0x06004DDF RID: 19935 RVA: 0x000942F0 File Offset: 0x000924F0
		// (set) Token: 0x06004DE0 RID: 19936 RVA: 0x0009431C File Offset: 0x0009251C
		[ProtoMember(4, IsRequired = false, Name = "viplevel", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001805 RID: 6149
		// (get) Token: 0x06004DE1 RID: 19937 RVA: 0x0009432C File Offset: 0x0009252C
		// (set) Token: 0x06004DE2 RID: 19938 RVA: 0x0009434C File Offset: 0x0009254C
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

		// Token: 0x06004DE3 RID: 19939 RVA: 0x00094390 File Offset: 0x00092590
		private bool ShouldSerializeviplevel()
		{
			return this.viplevelSpecified;
		}

		// Token: 0x06004DE4 RID: 19940 RVA: 0x000943A8 File Offset: 0x000925A8
		private void Resetviplevel()
		{
			this.viplevelSpecified = false;
		}

		// Token: 0x17001806 RID: 6150
		// (get) Token: 0x06004DE5 RID: 19941 RVA: 0x000943B4 File Offset: 0x000925B4
		// (set) Token: 0x06004DE6 RID: 19942 RVA: 0x000943E0 File Offset: 0x000925E0
		[ProtoMember(5, IsRequired = false, Name = "powerpoint", DataFormat = DataFormat.TwosComplement)]
		public uint powerpoint
		{
			get
			{
				return this._powerpoint ?? 0U;
			}
			set
			{
				this._powerpoint = new uint?(value);
			}
		}

		// Token: 0x17001807 RID: 6151
		// (get) Token: 0x06004DE7 RID: 19943 RVA: 0x000943F0 File Offset: 0x000925F0
		// (set) Token: 0x06004DE8 RID: 19944 RVA: 0x00094410 File Offset: 0x00092610
		[XmlIgnore]
		[Browsable(false)]
		public bool powerpointSpecified
		{
			get
			{
				return this._powerpoint != null;
			}
			set
			{
				bool flag = value == (this._powerpoint == null);
				if (flag)
				{
					this._powerpoint = (value ? new uint?(this.powerpoint) : null);
				}
			}
		}

		// Token: 0x06004DE9 RID: 19945 RVA: 0x00094454 File Offset: 0x00092654
		private bool ShouldSerializepowerpoint()
		{
			return this.powerpointSpecified;
		}

		// Token: 0x06004DEA RID: 19946 RVA: 0x0009446C File Offset: 0x0009266C
		private void Resetpowerpoint()
		{
			this.powerpointSpecified = false;
		}

		// Token: 0x17001808 RID: 6152
		// (get) Token: 0x06004DEB RID: 19947 RVA: 0x00094478 File Offset: 0x00092678
		// (set) Token: 0x06004DEC RID: 19948 RVA: 0x000944A4 File Offset: 0x000926A4
		[ProtoMember(6, IsRequired = false, Name = "coverDesignationID", DataFormat = DataFormat.TwosComplement)]
		public uint coverDesignationID
		{
			get
			{
				return this._coverDesignationID ?? 0U;
			}
			set
			{
				this._coverDesignationID = new uint?(value);
			}
		}

		// Token: 0x17001809 RID: 6153
		// (get) Token: 0x06004DED RID: 19949 RVA: 0x000944B4 File Offset: 0x000926B4
		// (set) Token: 0x06004DEE RID: 19950 RVA: 0x000944D4 File Offset: 0x000926D4
		[XmlIgnore]
		[Browsable(false)]
		public bool coverDesignationIDSpecified
		{
			get
			{
				return this._coverDesignationID != null;
			}
			set
			{
				bool flag = value == (this._coverDesignationID == null);
				if (flag)
				{
					this._coverDesignationID = (value ? new uint?(this.coverDesignationID) : null);
				}
			}
		}

		// Token: 0x06004DEF RID: 19951 RVA: 0x00094518 File Offset: 0x00092718
		private bool ShouldSerializecoverDesignationID()
		{
			return this.coverDesignationIDSpecified;
		}

		// Token: 0x06004DF0 RID: 19952 RVA: 0x00094530 File Offset: 0x00092730
		private void ResetcoverDesignationID()
		{
			this.coverDesignationIDSpecified = false;
		}

		// Token: 0x1700180A RID: 6154
		// (get) Token: 0x06004DF1 RID: 19953 RVA: 0x0009453C File Offset: 0x0009273C
		// (set) Token: 0x06004DF2 RID: 19954 RVA: 0x00094568 File Offset: 0x00092768
		[ProtoMember(7, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700180B RID: 6155
		// (get) Token: 0x06004DF3 RID: 19955 RVA: 0x00094578 File Offset: 0x00092778
		// (set) Token: 0x06004DF4 RID: 19956 RVA: 0x00094598 File Offset: 0x00092798
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

		// Token: 0x06004DF5 RID: 19957 RVA: 0x000945DC File Offset: 0x000927DC
		private bool ShouldSerializepaymemberid()
		{
			return this.paymemberidSpecified;
		}

		// Token: 0x06004DF6 RID: 19958 RVA: 0x000945F4 File Offset: 0x000927F4
		private void Resetpaymemberid()
		{
			this.paymemberidSpecified = false;
		}

		// Token: 0x1700180C RID: 6156
		// (get) Token: 0x06004DF7 RID: 19959 RVA: 0x00094600 File Offset: 0x00092800
		// (set) Token: 0x06004DF8 RID: 19960 RVA: 0x0009462C File Offset: 0x0009282C
		[ProtoMember(8, IsRequired = false, Name = "military_rank", DataFormat = DataFormat.TwosComplement)]
		public uint military_rank
		{
			get
			{
				return this._military_rank ?? 0U;
			}
			set
			{
				this._military_rank = new uint?(value);
			}
		}

		// Token: 0x1700180D RID: 6157
		// (get) Token: 0x06004DF9 RID: 19961 RVA: 0x0009463C File Offset: 0x0009283C
		// (set) Token: 0x06004DFA RID: 19962 RVA: 0x0009465C File Offset: 0x0009285C
		[XmlIgnore]
		[Browsable(false)]
		public bool military_rankSpecified
		{
			get
			{
				return this._military_rank != null;
			}
			set
			{
				bool flag = value == (this._military_rank == null);
				if (flag)
				{
					this._military_rank = (value ? new uint?(this.military_rank) : null);
				}
			}
		}

		// Token: 0x06004DFB RID: 19963 RVA: 0x000946A0 File Offset: 0x000928A0
		private bool ShouldSerializemilitary_rank()
		{
			return this.military_rankSpecified;
		}

		// Token: 0x06004DFC RID: 19964 RVA: 0x000946B8 File Offset: 0x000928B8
		private void Resetmilitary_rank()
		{
			this.military_rankSpecified = false;
		}

		// Token: 0x1700180E RID: 6158
		// (get) Token: 0x06004DFD RID: 19965 RVA: 0x000946C4 File Offset: 0x000928C4
		// (set) Token: 0x06004DFE RID: 19966 RVA: 0x000946F0 File Offset: 0x000928F0
		[ProtoMember(9, IsRequired = false, Name = "heroid", DataFormat = DataFormat.TwosComplement)]
		public uint heroid
		{
			get
			{
				return this._heroid ?? 0U;
			}
			set
			{
				this._heroid = new uint?(value);
			}
		}

		// Token: 0x1700180F RID: 6159
		// (get) Token: 0x06004DFF RID: 19967 RVA: 0x00094700 File Offset: 0x00092900
		// (set) Token: 0x06004E00 RID: 19968 RVA: 0x00094720 File Offset: 0x00092920
		[XmlIgnore]
		[Browsable(false)]
		public bool heroidSpecified
		{
			get
			{
				return this._heroid != null;
			}
			set
			{
				bool flag = value == (this._heroid == null);
				if (flag)
				{
					this._heroid = (value ? new uint?(this.heroid) : null);
				}
			}
		}

		// Token: 0x06004E01 RID: 19969 RVA: 0x00094764 File Offset: 0x00092964
		private bool ShouldSerializeheroid()
		{
			return this.heroidSpecified;
		}

		// Token: 0x06004E02 RID: 19970 RVA: 0x0009477C File Offset: 0x0009297C
		private void Resetheroid()
		{
			this.heroidSpecified = false;
		}

		// Token: 0x17001810 RID: 6160
		// (get) Token: 0x06004E03 RID: 19971 RVA: 0x00094788 File Offset: 0x00092988
		// (set) Token: 0x06004E04 RID: 19972 RVA: 0x000947A9 File Offset: 0x000929A9
		[ProtoMember(10, IsRequired = false, Name = "desname", DataFormat = DataFormat.Default)]
		public string desname
		{
			get
			{
				return this._desname ?? "";
			}
			set
			{
				this._desname = value;
			}
		}

		// Token: 0x17001811 RID: 6161
		// (get) Token: 0x06004E05 RID: 19973 RVA: 0x000947B4 File Offset: 0x000929B4
		// (set) Token: 0x06004E06 RID: 19974 RVA: 0x000947D0 File Offset: 0x000929D0
		[XmlIgnore]
		[Browsable(false)]
		public bool desnameSpecified
		{
			get
			{
				return this._desname != null;
			}
			set
			{
				bool flag = value == (this._desname == null);
				if (flag)
				{
					this._desname = (value ? this.desname : null);
				}
			}
		}

		// Token: 0x06004E07 RID: 19975 RVA: 0x00094800 File Offset: 0x00092A00
		private bool ShouldSerializedesname()
		{
			return this.desnameSpecified;
		}

		// Token: 0x06004E08 RID: 19976 RVA: 0x00094818 File Offset: 0x00092A18
		private void Resetdesname()
		{
			this.desnameSpecified = false;
		}

		// Token: 0x17001812 RID: 6162
		// (get) Token: 0x06004E09 RID: 19977 RVA: 0x00094824 File Offset: 0x00092A24
		// (set) Token: 0x06004E0A RID: 19978 RVA: 0x0009483C File Offset: 0x00092A3C
		[ProtoMember(11, IsRequired = false, Name = "pre", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayConsume pre
		{
			get
			{
				return this._pre;
			}
			set
			{
				this._pre = value;
			}
		}

		// Token: 0x17001813 RID: 6163
		// (get) Token: 0x06004E0B RID: 19979 RVA: 0x00094848 File Offset: 0x00092A48
		// (set) Token: 0x06004E0C RID: 19980 RVA: 0x00094874 File Offset: 0x00092A74
		[ProtoMember(12, IsRequired = false, Name = "isBackFlow", DataFormat = DataFormat.Default)]
		public bool isBackFlow
		{
			get
			{
				return this._isBackFlow ?? false;
			}
			set
			{
				this._isBackFlow = new bool?(value);
			}
		}

		// Token: 0x17001814 RID: 6164
		// (get) Token: 0x06004E0D RID: 19981 RVA: 0x00094884 File Offset: 0x00092A84
		// (set) Token: 0x06004E0E RID: 19982 RVA: 0x000948A4 File Offset: 0x00092AA4
		[XmlIgnore]
		[Browsable(false)]
		public bool isBackFlowSpecified
		{
			get
			{
				return this._isBackFlow != null;
			}
			set
			{
				bool flag = value == (this._isBackFlow == null);
				if (flag)
				{
					this._isBackFlow = (value ? new bool?(this.isBackFlow) : null);
				}
			}
		}

		// Token: 0x06004E0F RID: 19983 RVA: 0x000948E8 File Offset: 0x00092AE8
		private bool ShouldSerializeisBackFlow()
		{
			return this.isBackFlowSpecified;
		}

		// Token: 0x06004E10 RID: 19984 RVA: 0x00094900 File Offset: 0x00092B00
		private void ResetisBackFlow()
		{
			this.isBackFlowSpecified = false;
		}

		// Token: 0x17001815 RID: 6165
		// (get) Token: 0x06004E11 RID: 19985 RVA: 0x0009490C File Offset: 0x00092B0C
		// (set) Token: 0x06004E12 RID: 19986 RVA: 0x00094938 File Offset: 0x00092B38
		[ProtoMember(13, IsRequired = false, Name = "campDuelID", DataFormat = DataFormat.TwosComplement)]
		public uint campDuelID
		{
			get
			{
				return this._campDuelID ?? 0U;
			}
			set
			{
				this._campDuelID = new uint?(value);
			}
		}

		// Token: 0x17001816 RID: 6166
		// (get) Token: 0x06004E13 RID: 19987 RVA: 0x00094948 File Offset: 0x00092B48
		// (set) Token: 0x06004E14 RID: 19988 RVA: 0x00094968 File Offset: 0x00092B68
		[XmlIgnore]
		[Browsable(false)]
		public bool campDuelIDSpecified
		{
			get
			{
				return this._campDuelID != null;
			}
			set
			{
				bool flag = value == (this._campDuelID == null);
				if (flag)
				{
					this._campDuelID = (value ? new uint?(this.campDuelID) : null);
				}
			}
		}

		// Token: 0x06004E15 RID: 19989 RVA: 0x000949AC File Offset: 0x00092BAC
		private bool ShouldSerializecampDuelID()
		{
			return this.campDuelIDSpecified;
		}

		// Token: 0x06004E16 RID: 19990 RVA: 0x000949C4 File Offset: 0x00092BC4
		private void ResetcampDuelID()
		{
			this.campDuelIDSpecified = false;
		}

		// Token: 0x06004E17 RID: 19991 RVA: 0x000949D0 File Offset: 0x00092BD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400133E RID: 4926
		private ulong? _roleid;

		// Token: 0x0400133F RID: 4927
		private uint? _profession;

		// Token: 0x04001340 RID: 4928
		private string _name;

		// Token: 0x04001341 RID: 4929
		private uint? _viplevel;

		// Token: 0x04001342 RID: 4930
		private uint? _powerpoint;

		// Token: 0x04001343 RID: 4931
		private uint? _coverDesignationID;

		// Token: 0x04001344 RID: 4932
		private uint? _paymemberid;

		// Token: 0x04001345 RID: 4933
		private uint? _military_rank;

		// Token: 0x04001346 RID: 4934
		private uint? _heroid;

		// Token: 0x04001347 RID: 4935
		private string _desname;

		// Token: 0x04001348 RID: 4936
		private PayConsume _pre = null;

		// Token: 0x04001349 RID: 4937
		private bool? _isBackFlow;

		// Token: 0x0400134A RID: 4938
		private uint? _campDuelID;

		// Token: 0x0400134B RID: 4939
		private IExtension extensionObject;
	}
}
