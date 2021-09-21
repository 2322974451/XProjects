using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200071F RID: 1823
	[ProtoContract(Name = "MayhemRankInfo")]
	[Serializable]
	public class MayhemRankInfo : IExtensible
	{
		// Token: 0x1700278A RID: 10122
		// (get) Token: 0x06007CBB RID: 31931 RVA: 0x000EE7FC File Offset: 0x000EC9FC
		// (set) Token: 0x06007CBC RID: 31932 RVA: 0x000EE829 File Offset: 0x000ECA29
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

		// Token: 0x1700278B RID: 10123
		// (get) Token: 0x06007CBD RID: 31933 RVA: 0x000EE838 File Offset: 0x000ECA38
		// (set) Token: 0x06007CBE RID: 31934 RVA: 0x000EE858 File Offset: 0x000ECA58
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

		// Token: 0x06007CBF RID: 31935 RVA: 0x000EE89C File Offset: 0x000ECA9C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007CC0 RID: 31936 RVA: 0x000EE8B4 File Offset: 0x000ECAB4
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700278C RID: 10124
		// (get) Token: 0x06007CC1 RID: 31937 RVA: 0x000EE8C0 File Offset: 0x000ECAC0
		// (set) Token: 0x06007CC2 RID: 31938 RVA: 0x000EE8EC File Offset: 0x000ECAEC
		[ProtoMember(2, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x1700278D RID: 10125
		// (get) Token: 0x06007CC3 RID: 31939 RVA: 0x000EE8FC File Offset: 0x000ECAFC
		// (set) Token: 0x06007CC4 RID: 31940 RVA: 0x000EE91C File Offset: 0x000ECB1C
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x06007CC5 RID: 31941 RVA: 0x000EE960 File Offset: 0x000ECB60
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06007CC6 RID: 31942 RVA: 0x000EE978 File Offset: 0x000ECB78
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x1700278E RID: 10126
		// (get) Token: 0x06007CC7 RID: 31943 RVA: 0x000EE984 File Offset: 0x000ECB84
		// (set) Token: 0x06007CC8 RID: 31944 RVA: 0x000EE9B0 File Offset: 0x000ECBB0
		[ProtoMember(3, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
		public uint killcount
		{
			get
			{
				return this._killcount ?? 0U;
			}
			set
			{
				this._killcount = new uint?(value);
			}
		}

		// Token: 0x1700278F RID: 10127
		// (get) Token: 0x06007CC9 RID: 31945 RVA: 0x000EE9C0 File Offset: 0x000ECBC0
		// (set) Token: 0x06007CCA RID: 31946 RVA: 0x000EE9E0 File Offset: 0x000ECBE0
		[XmlIgnore]
		[Browsable(false)]
		public bool killcountSpecified
		{
			get
			{
				return this._killcount != null;
			}
			set
			{
				bool flag = value == (this._killcount == null);
				if (flag)
				{
					this._killcount = (value ? new uint?(this.killcount) : null);
				}
			}
		}

		// Token: 0x06007CCB RID: 31947 RVA: 0x000EEA24 File Offset: 0x000ECC24
		private bool ShouldSerializekillcount()
		{
			return this.killcountSpecified;
		}

		// Token: 0x06007CCC RID: 31948 RVA: 0x000EEA3C File Offset: 0x000ECC3C
		private void Resetkillcount()
		{
			this.killcountSpecified = false;
		}

		// Token: 0x17002790 RID: 10128
		// (get) Token: 0x06007CCD RID: 31949 RVA: 0x000EEA48 File Offset: 0x000ECC48
		// (set) Token: 0x06007CCE RID: 31950 RVA: 0x000EEA74 File Offset: 0x000ECC74
		[ProtoMember(4, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002791 RID: 10129
		// (get) Token: 0x06007CCF RID: 31951 RVA: 0x000EEA84 File Offset: 0x000ECC84
		// (set) Token: 0x06007CD0 RID: 31952 RVA: 0x000EEAA4 File Offset: 0x000ECCA4
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

		// Token: 0x06007CD1 RID: 31953 RVA: 0x000EEAE8 File Offset: 0x000ECCE8
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06007CD2 RID: 31954 RVA: 0x000EEB00 File Offset: 0x000ECD00
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x17002792 RID: 10130
		// (get) Token: 0x06007CD3 RID: 31955 RVA: 0x000EEB0C File Offset: 0x000ECD0C
		// (set) Token: 0x06007CD4 RID: 31956 RVA: 0x000EEB38 File Offset: 0x000ECD38
		[ProtoMember(5, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		// Token: 0x17002793 RID: 10131
		// (get) Token: 0x06007CD5 RID: 31957 RVA: 0x000EEB48 File Offset: 0x000ECD48
		// (set) Token: 0x06007CD6 RID: 31958 RVA: 0x000EEB68 File Offset: 0x000ECD68
		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		// Token: 0x06007CD7 RID: 31959 RVA: 0x000EEBAC File Offset: 0x000ECDAC
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06007CD8 RID: 31960 RVA: 0x000EEBC4 File Offset: 0x000ECDC4
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x17002794 RID: 10132
		// (get) Token: 0x06007CD9 RID: 31961 RVA: 0x000EEBD0 File Offset: 0x000ECDD0
		// (set) Token: 0x06007CDA RID: 31962 RVA: 0x000EEBF1 File Offset: 0x000ECDF1
		[ProtoMember(6, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x17002795 RID: 10133
		// (get) Token: 0x06007CDB RID: 31963 RVA: 0x000EEBFC File Offset: 0x000ECDFC
		// (set) Token: 0x06007CDC RID: 31964 RVA: 0x000EEC18 File Offset: 0x000ECE18
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

		// Token: 0x06007CDD RID: 31965 RVA: 0x000EEC48 File Offset: 0x000ECE48
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007CDE RID: 31966 RVA: 0x000EEC60 File Offset: 0x000ECE60
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002796 RID: 10134
		// (get) Token: 0x06007CDF RID: 31967 RVA: 0x000EEC6C File Offset: 0x000ECE6C
		// (set) Token: 0x06007CE0 RID: 31968 RVA: 0x000EEC8D File Offset: 0x000ECE8D
		[ProtoMember(7, IsRequired = false, Name = "svrname", DataFormat = DataFormat.Default)]
		public string svrname
		{
			get
			{
				return this._svrname ?? "";
			}
			set
			{
				this._svrname = value;
			}
		}

		// Token: 0x17002797 RID: 10135
		// (get) Token: 0x06007CE1 RID: 31969 RVA: 0x000EEC98 File Offset: 0x000ECE98
		// (set) Token: 0x06007CE2 RID: 31970 RVA: 0x000EECB4 File Offset: 0x000ECEB4
		[XmlIgnore]
		[Browsable(false)]
		public bool svrnameSpecified
		{
			get
			{
				return this._svrname != null;
			}
			set
			{
				bool flag = value == (this._svrname == null);
				if (flag)
				{
					this._svrname = (value ? this.svrname : null);
				}
			}
		}

		// Token: 0x06007CE3 RID: 31971 RVA: 0x000EECE4 File Offset: 0x000ECEE4
		private bool ShouldSerializesvrname()
		{
			return this.svrnameSpecified;
		}

		// Token: 0x06007CE4 RID: 31972 RVA: 0x000EECFC File Offset: 0x000ECEFC
		private void Resetsvrname()
		{
			this.svrnameSpecified = false;
		}

		// Token: 0x17002798 RID: 10136
		// (get) Token: 0x06007CE5 RID: 31973 RVA: 0x000EED08 File Offset: 0x000ECF08
		// (set) Token: 0x06007CE6 RID: 31974 RVA: 0x000EED34 File Offset: 0x000ECF34
		[ProtoMember(8, IsRequired = false, Name = "pro", DataFormat = DataFormat.TwosComplement)]
		public uint pro
		{
			get
			{
				return this._pro ?? 0U;
			}
			set
			{
				this._pro = new uint?(value);
			}
		}

		// Token: 0x17002799 RID: 10137
		// (get) Token: 0x06007CE7 RID: 31975 RVA: 0x000EED44 File Offset: 0x000ECF44
		// (set) Token: 0x06007CE8 RID: 31976 RVA: 0x000EED64 File Offset: 0x000ECF64
		[XmlIgnore]
		[Browsable(false)]
		public bool proSpecified
		{
			get
			{
				return this._pro != null;
			}
			set
			{
				bool flag = value == (this._pro == null);
				if (flag)
				{
					this._pro = (value ? new uint?(this.pro) : null);
				}
			}
		}

		// Token: 0x06007CE9 RID: 31977 RVA: 0x000EEDA8 File Offset: 0x000ECFA8
		private bool ShouldSerializepro()
		{
			return this.proSpecified;
		}

		// Token: 0x06007CEA RID: 31978 RVA: 0x000EEDC0 File Offset: 0x000ECFC0
		private void Resetpro()
		{
			this.proSpecified = false;
		}

		// Token: 0x06007CEB RID: 31979 RVA: 0x000EEDCC File Offset: 0x000ECFCC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D60 RID: 7520
		private ulong? _roleid;

		// Token: 0x04001D61 RID: 7521
		private uint? _point;

		// Token: 0x04001D62 RID: 7522
		private uint? _killcount;

		// Token: 0x04001D63 RID: 7523
		private uint? _time;

		// Token: 0x04001D64 RID: 7524
		private uint? _serverid;

		// Token: 0x04001D65 RID: 7525
		private string _name;

		// Token: 0x04001D66 RID: 7526
		private string _svrname;

		// Token: 0x04001D67 RID: 7527
		private uint? _pro;

		// Token: 0x04001D68 RID: 7528
		private IExtension extensionObject;
	}
}
