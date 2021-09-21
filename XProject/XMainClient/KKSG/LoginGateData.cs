using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005AD RID: 1453
	[ProtoContract(Name = "LoginGateData")]
	[Serializable]
	public class LoginGateData : IExtensible
	{
		// Token: 0x17001859 RID: 6233
		// (get) Token: 0x06004EE8 RID: 20200 RVA: 0x00096154 File Offset: 0x00094354
		// (set) Token: 0x06004EE9 RID: 20201 RVA: 0x00096175 File Offset: 0x00094375
		[ProtoMember(1, IsRequired = false, Name = "ip", DataFormat = DataFormat.Default)]
		public string ip
		{
			get
			{
				return this._ip ?? "";
			}
			set
			{
				this._ip = value;
			}
		}

		// Token: 0x1700185A RID: 6234
		// (get) Token: 0x06004EEA RID: 20202 RVA: 0x00096180 File Offset: 0x00094380
		// (set) Token: 0x06004EEB RID: 20203 RVA: 0x0009619C File Offset: 0x0009439C
		[XmlIgnore]
		[Browsable(false)]
		public bool ipSpecified
		{
			get
			{
				return this._ip != null;
			}
			set
			{
				bool flag = value == (this._ip == null);
				if (flag)
				{
					this._ip = (value ? this.ip : null);
				}
			}
		}

		// Token: 0x06004EEC RID: 20204 RVA: 0x000961CC File Offset: 0x000943CC
		private bool ShouldSerializeip()
		{
			return this.ipSpecified;
		}

		// Token: 0x06004EED RID: 20205 RVA: 0x000961E4 File Offset: 0x000943E4
		private void Resetip()
		{
			this.ipSpecified = false;
		}

		// Token: 0x1700185B RID: 6235
		// (get) Token: 0x06004EEE RID: 20206 RVA: 0x000961F0 File Offset: 0x000943F0
		// (set) Token: 0x06004EEF RID: 20207 RVA: 0x00096211 File Offset: 0x00094411
		[ProtoMember(2, IsRequired = false, Name = "zonename", DataFormat = DataFormat.Default)]
		public string zonename
		{
			get
			{
				return this._zonename ?? "";
			}
			set
			{
				this._zonename = value;
			}
		}

		// Token: 0x1700185C RID: 6236
		// (get) Token: 0x06004EF0 RID: 20208 RVA: 0x0009621C File Offset: 0x0009441C
		// (set) Token: 0x06004EF1 RID: 20209 RVA: 0x00096238 File Offset: 0x00094438
		[XmlIgnore]
		[Browsable(false)]
		public bool zonenameSpecified
		{
			get
			{
				return this._zonename != null;
			}
			set
			{
				bool flag = value == (this._zonename == null);
				if (flag)
				{
					this._zonename = (value ? this.zonename : null);
				}
			}
		}

		// Token: 0x06004EF2 RID: 20210 RVA: 0x00096268 File Offset: 0x00094468
		private bool ShouldSerializezonename()
		{
			return this.zonenameSpecified;
		}

		// Token: 0x06004EF3 RID: 20211 RVA: 0x00096280 File Offset: 0x00094480
		private void Resetzonename()
		{
			this.zonenameSpecified = false;
		}

		// Token: 0x1700185D RID: 6237
		// (get) Token: 0x06004EF4 RID: 20212 RVA: 0x0009628C File Offset: 0x0009448C
		// (set) Token: 0x06004EF5 RID: 20213 RVA: 0x000962AD File Offset: 0x000944AD
		[ProtoMember(3, IsRequired = false, Name = "servername", DataFormat = DataFormat.Default)]
		public string servername
		{
			get
			{
				return this._servername ?? "";
			}
			set
			{
				this._servername = value;
			}
		}

		// Token: 0x1700185E RID: 6238
		// (get) Token: 0x06004EF6 RID: 20214 RVA: 0x000962B8 File Offset: 0x000944B8
		// (set) Token: 0x06004EF7 RID: 20215 RVA: 0x000962D4 File Offset: 0x000944D4
		[XmlIgnore]
		[Browsable(false)]
		public bool servernameSpecified
		{
			get
			{
				return this._servername != null;
			}
			set
			{
				bool flag = value == (this._servername == null);
				if (flag)
				{
					this._servername = (value ? this.servername : null);
				}
			}
		}

		// Token: 0x06004EF8 RID: 20216 RVA: 0x00096304 File Offset: 0x00094504
		private bool ShouldSerializeservername()
		{
			return this.servernameSpecified;
		}

		// Token: 0x06004EF9 RID: 20217 RVA: 0x0009631C File Offset: 0x0009451C
		private void Resetservername()
		{
			this.servernameSpecified = false;
		}

		// Token: 0x1700185F RID: 6239
		// (get) Token: 0x06004EFA RID: 20218 RVA: 0x00096328 File Offset: 0x00094528
		// (set) Token: 0x06004EFB RID: 20219 RVA: 0x00096354 File Offset: 0x00094554
		[ProtoMember(4, IsRequired = false, Name = "port", DataFormat = DataFormat.TwosComplement)]
		public int port
		{
			get
			{
				return this._port ?? 0;
			}
			set
			{
				this._port = new int?(value);
			}
		}

		// Token: 0x17001860 RID: 6240
		// (get) Token: 0x06004EFC RID: 20220 RVA: 0x00096364 File Offset: 0x00094564
		// (set) Token: 0x06004EFD RID: 20221 RVA: 0x00096384 File Offset: 0x00094584
		[XmlIgnore]
		[Browsable(false)]
		public bool portSpecified
		{
			get
			{
				return this._port != null;
			}
			set
			{
				bool flag = value == (this._port == null);
				if (flag)
				{
					this._port = (value ? new int?(this.port) : null);
				}
			}
		}

		// Token: 0x06004EFE RID: 20222 RVA: 0x000963C8 File Offset: 0x000945C8
		private bool ShouldSerializeport()
		{
			return this.portSpecified;
		}

		// Token: 0x06004EFF RID: 20223 RVA: 0x000963E0 File Offset: 0x000945E0
		private void Resetport()
		{
			this.portSpecified = false;
		}

		// Token: 0x17001861 RID: 6241
		// (get) Token: 0x06004F00 RID: 20224 RVA: 0x000963EC File Offset: 0x000945EC
		// (set) Token: 0x06004F01 RID: 20225 RVA: 0x00096418 File Offset: 0x00094618
		[ProtoMember(5, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public int serverid
		{
			get
			{
				return this._serverid ?? 0;
			}
			set
			{
				this._serverid = new int?(value);
			}
		}

		// Token: 0x17001862 RID: 6242
		// (get) Token: 0x06004F02 RID: 20226 RVA: 0x00096428 File Offset: 0x00094628
		// (set) Token: 0x06004F03 RID: 20227 RVA: 0x00096448 File Offset: 0x00094648
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
					this._serverid = (value ? new int?(this.serverid) : null);
				}
			}
		}

		// Token: 0x06004F04 RID: 20228 RVA: 0x0009648C File Offset: 0x0009468C
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06004F05 RID: 20229 RVA: 0x000964A4 File Offset: 0x000946A4
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x17001863 RID: 6243
		// (get) Token: 0x06004F06 RID: 20230 RVA: 0x000964B0 File Offset: 0x000946B0
		// (set) Token: 0x06004F07 RID: 20231 RVA: 0x000964DC File Offset: 0x000946DC
		[ProtoMember(6, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		// Token: 0x17001864 RID: 6244
		// (get) Token: 0x06004F08 RID: 20232 RVA: 0x000964EC File Offset: 0x000946EC
		// (set) Token: 0x06004F09 RID: 20233 RVA: 0x0009650C File Offset: 0x0009470C
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		// Token: 0x06004F0A RID: 20234 RVA: 0x00096550 File Offset: 0x00094750
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06004F0B RID: 20235 RVA: 0x00096568 File Offset: 0x00094768
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x17001865 RID: 6245
		// (get) Token: 0x06004F0C RID: 20236 RVA: 0x00096574 File Offset: 0x00094774
		// (set) Token: 0x06004F0D RID: 20237 RVA: 0x000965A0 File Offset: 0x000947A0
		[ProtoMember(7, IsRequired = false, Name = "flag", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001866 RID: 6246
		// (get) Token: 0x06004F0E RID: 20238 RVA: 0x000965B0 File Offset: 0x000947B0
		// (set) Token: 0x06004F0F RID: 20239 RVA: 0x000965D0 File Offset: 0x000947D0
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

		// Token: 0x06004F10 RID: 20240 RVA: 0x00096614 File Offset: 0x00094814
		private bool ShouldSerializeflag()
		{
			return this.flagSpecified;
		}

		// Token: 0x06004F11 RID: 20241 RVA: 0x0009662C File Offset: 0x0009482C
		private void Resetflag()
		{
			this.flagSpecified = false;
		}

		// Token: 0x17001867 RID: 6247
		// (get) Token: 0x06004F12 RID: 20242 RVA: 0x00096638 File Offset: 0x00094838
		// (set) Token: 0x06004F13 RID: 20243 RVA: 0x00096664 File Offset: 0x00094864
		[ProtoMember(8, IsRequired = false, Name = "isbackflow", DataFormat = DataFormat.Default)]
		public bool isbackflow
		{
			get
			{
				return this._isbackflow ?? false;
			}
			set
			{
				this._isbackflow = new bool?(value);
			}
		}

		// Token: 0x17001868 RID: 6248
		// (get) Token: 0x06004F14 RID: 20244 RVA: 0x00096674 File Offset: 0x00094874
		// (set) Token: 0x06004F15 RID: 20245 RVA: 0x00096694 File Offset: 0x00094894
		[XmlIgnore]
		[Browsable(false)]
		public bool isbackflowSpecified
		{
			get
			{
				return this._isbackflow != null;
			}
			set
			{
				bool flag = value == (this._isbackflow == null);
				if (flag)
				{
					this._isbackflow = (value ? new bool?(this.isbackflow) : null);
				}
			}
		}

		// Token: 0x06004F16 RID: 20246 RVA: 0x000966D8 File Offset: 0x000948D8
		private bool ShouldSerializeisbackflow()
		{
			return this.isbackflowSpecified;
		}

		// Token: 0x06004F17 RID: 20247 RVA: 0x000966F0 File Offset: 0x000948F0
		private void Resetisbackflow()
		{
			this.isbackflowSpecified = false;
		}

		// Token: 0x17001869 RID: 6249
		// (get) Token: 0x06004F18 RID: 20248 RVA: 0x000966FC File Offset: 0x000948FC
		// (set) Token: 0x06004F19 RID: 20249 RVA: 0x00096728 File Offset: 0x00094928
		[ProtoMember(9, IsRequired = false, Name = "backflowlevel", DataFormat = DataFormat.TwosComplement)]
		public uint backflowlevel
		{
			get
			{
				return this._backflowlevel ?? 0U;
			}
			set
			{
				this._backflowlevel = new uint?(value);
			}
		}

		// Token: 0x1700186A RID: 6250
		// (get) Token: 0x06004F1A RID: 20250 RVA: 0x00096738 File Offset: 0x00094938
		// (set) Token: 0x06004F1B RID: 20251 RVA: 0x00096758 File Offset: 0x00094958
		[XmlIgnore]
		[Browsable(false)]
		public bool backflowlevelSpecified
		{
			get
			{
				return this._backflowlevel != null;
			}
			set
			{
				bool flag = value == (this._backflowlevel == null);
				if (flag)
				{
					this._backflowlevel = (value ? new uint?(this.backflowlevel) : null);
				}
			}
		}

		// Token: 0x06004F1C RID: 20252 RVA: 0x0009679C File Offset: 0x0009499C
		private bool ShouldSerializebackflowlevel()
		{
			return this.backflowlevelSpecified;
		}

		// Token: 0x06004F1D RID: 20253 RVA: 0x000967B4 File Offset: 0x000949B4
		private void Resetbackflowlevel()
		{
			this.backflowlevelSpecified = false;
		}

		// Token: 0x06004F1E RID: 20254 RVA: 0x000967C0 File Offset: 0x000949C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400137F RID: 4991
		private string _ip;

		// Token: 0x04001380 RID: 4992
		private string _zonename;

		// Token: 0x04001381 RID: 4993
		private string _servername;

		// Token: 0x04001382 RID: 4994
		private int? _port;

		// Token: 0x04001383 RID: 4995
		private int? _serverid;

		// Token: 0x04001384 RID: 4996
		private uint? _state;

		// Token: 0x04001385 RID: 4997
		private uint? _flag;

		// Token: 0x04001386 RID: 4998
		private bool? _isbackflow;

		// Token: 0x04001387 RID: 4999
		private uint? _backflowlevel;

		// Token: 0x04001388 RID: 5000
		private IExtension extensionObject;
	}
}
