using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006E2 RID: 1762
	[ProtoContract(Name = "GCFZhanChBriefInfo")]
	[Serializable]
	public class GCFZhanChBriefInfo : IExtensible
	{
		// Token: 0x1700253D RID: 9533
		// (get) Token: 0x0600759A RID: 30106 RVA: 0x000E0FE4 File Offset: 0x000DF1E4
		// (set) Token: 0x0600759B RID: 30107 RVA: 0x000E1010 File Offset: 0x000DF210
		[ProtoMember(1, IsRequired = false, Name = "mapid", DataFormat = DataFormat.TwosComplement)]
		public uint mapid
		{
			get
			{
				return this._mapid ?? 0U;
			}
			set
			{
				this._mapid = new uint?(value);
			}
		}

		// Token: 0x1700253E RID: 9534
		// (get) Token: 0x0600759C RID: 30108 RVA: 0x000E1020 File Offset: 0x000DF220
		// (set) Token: 0x0600759D RID: 30109 RVA: 0x000E1040 File Offset: 0x000DF240
		[XmlIgnore]
		[Browsable(false)]
		public bool mapidSpecified
		{
			get
			{
				return this._mapid != null;
			}
			set
			{
				bool flag = value == (this._mapid == null);
				if (flag)
				{
					this._mapid = (value ? new uint?(this.mapid) : null);
				}
			}
		}

		// Token: 0x0600759E RID: 30110 RVA: 0x000E1084 File Offset: 0x000DF284
		private bool ShouldSerializemapid()
		{
			return this.mapidSpecified;
		}

		// Token: 0x0600759F RID: 30111 RVA: 0x000E109C File Offset: 0x000DF29C
		private void Resetmapid()
		{
			this.mapidSpecified = false;
		}

		// Token: 0x1700253F RID: 9535
		// (get) Token: 0x060075A0 RID: 30112 RVA: 0x000E10A8 File Offset: 0x000DF2A8
		// (set) Token: 0x060075A1 RID: 30113 RVA: 0x000E10D4 File Offset: 0x000DF2D4
		[ProtoMember(2, IsRequired = false, Name = "multipoint", DataFormat = DataFormat.TwosComplement)]
		public uint multipoint
		{
			get
			{
				return this._multipoint ?? 0U;
			}
			set
			{
				this._multipoint = new uint?(value);
			}
		}

		// Token: 0x17002540 RID: 9536
		// (get) Token: 0x060075A2 RID: 30114 RVA: 0x000E10E4 File Offset: 0x000DF2E4
		// (set) Token: 0x060075A3 RID: 30115 RVA: 0x000E1104 File Offset: 0x000DF304
		[XmlIgnore]
		[Browsable(false)]
		public bool multipointSpecified
		{
			get
			{
				return this._multipoint != null;
			}
			set
			{
				bool flag = value == (this._multipoint == null);
				if (flag)
				{
					this._multipoint = (value ? new uint?(this.multipoint) : null);
				}
			}
		}

		// Token: 0x060075A4 RID: 30116 RVA: 0x000E1148 File Offset: 0x000DF348
		private bool ShouldSerializemultipoint()
		{
			return this.multipointSpecified;
		}

		// Token: 0x060075A5 RID: 30117 RVA: 0x000E1160 File Offset: 0x000DF360
		private void Resetmultipoint()
		{
			this.multipointSpecified = false;
		}

		// Token: 0x17002541 RID: 9537
		// (get) Token: 0x060075A6 RID: 30118 RVA: 0x000E116C File Offset: 0x000DF36C
		// (set) Token: 0x060075A7 RID: 30119 RVA: 0x000E1198 File Offset: 0x000DF398
		[ProtoMember(3, IsRequired = false, Name = "curusercount", DataFormat = DataFormat.TwosComplement)]
		public uint curusercount
		{
			get
			{
				return this._curusercount ?? 0U;
			}
			set
			{
				this._curusercount = new uint?(value);
			}
		}

		// Token: 0x17002542 RID: 9538
		// (get) Token: 0x060075A8 RID: 30120 RVA: 0x000E11A8 File Offset: 0x000DF3A8
		// (set) Token: 0x060075A9 RID: 30121 RVA: 0x000E11C8 File Offset: 0x000DF3C8
		[XmlIgnore]
		[Browsable(false)]
		public bool curusercountSpecified
		{
			get
			{
				return this._curusercount != null;
			}
			set
			{
				bool flag = value == (this._curusercount == null);
				if (flag)
				{
					this._curusercount = (value ? new uint?(this.curusercount) : null);
				}
			}
		}

		// Token: 0x060075AA RID: 30122 RVA: 0x000E120C File Offset: 0x000DF40C
		private bool ShouldSerializecurusercount()
		{
			return this.curusercountSpecified;
		}

		// Token: 0x060075AB RID: 30123 RVA: 0x000E1224 File Offset: 0x000DF424
		private void Resetcurusercount()
		{
			this.curusercountSpecified = false;
		}

		// Token: 0x17002543 RID: 9539
		// (get) Token: 0x060075AC RID: 30124 RVA: 0x000E1230 File Offset: 0x000DF430
		// (set) Token: 0x060075AD RID: 30125 RVA: 0x000E125C File Offset: 0x000DF45C
		[ProtoMember(4, IsRequired = false, Name = "maxusercount", DataFormat = DataFormat.TwosComplement)]
		public uint maxusercount
		{
			get
			{
				return this._maxusercount ?? 0U;
			}
			set
			{
				this._maxusercount = new uint?(value);
			}
		}

		// Token: 0x17002544 RID: 9540
		// (get) Token: 0x060075AE RID: 30126 RVA: 0x000E126C File Offset: 0x000DF46C
		// (set) Token: 0x060075AF RID: 30127 RVA: 0x000E128C File Offset: 0x000DF48C
		[XmlIgnore]
		[Browsable(false)]
		public bool maxusercountSpecified
		{
			get
			{
				return this._maxusercount != null;
			}
			set
			{
				bool flag = value == (this._maxusercount == null);
				if (flag)
				{
					this._maxusercount = (value ? new uint?(this.maxusercount) : null);
				}
			}
		}

		// Token: 0x060075B0 RID: 30128 RVA: 0x000E12D0 File Offset: 0x000DF4D0
		private bool ShouldSerializemaxusercount()
		{
			return this.maxusercountSpecified;
		}

		// Token: 0x060075B1 RID: 30129 RVA: 0x000E12E8 File Offset: 0x000DF4E8
		private void Resetmaxusercount()
		{
			this.maxusercountSpecified = false;
		}

		// Token: 0x17002545 RID: 9541
		// (get) Token: 0x060075B2 RID: 30130 RVA: 0x000E12F4 File Offset: 0x000DF4F4
		// (set) Token: 0x060075B3 RID: 30131 RVA: 0x000E1320 File Offset: 0x000DF520
		[ProtoMember(5, IsRequired = false, Name = "isopen", DataFormat = DataFormat.Default)]
		public bool isopen
		{
			get
			{
				return this._isopen ?? false;
			}
			set
			{
				this._isopen = new bool?(value);
			}
		}

		// Token: 0x17002546 RID: 9542
		// (get) Token: 0x060075B4 RID: 30132 RVA: 0x000E1330 File Offset: 0x000DF530
		// (set) Token: 0x060075B5 RID: 30133 RVA: 0x000E1350 File Offset: 0x000DF550
		[XmlIgnore]
		[Browsable(false)]
		public bool isopenSpecified
		{
			get
			{
				return this._isopen != null;
			}
			set
			{
				bool flag = value == (this._isopen == null);
				if (flag)
				{
					this._isopen = (value ? new bool?(this.isopen) : null);
				}
			}
		}

		// Token: 0x060075B6 RID: 30134 RVA: 0x000E1394 File Offset: 0x000DF594
		private bool ShouldSerializeisopen()
		{
			return this.isopenSpecified;
		}

		// Token: 0x060075B7 RID: 30135 RVA: 0x000E13AC File Offset: 0x000DF5AC
		private void Resetisopen()
		{
			this.isopenSpecified = false;
		}

		// Token: 0x060075B8 RID: 30136 RVA: 0x000E13B8 File Offset: 0x000DF5B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BE7 RID: 7143
		private uint? _mapid;

		// Token: 0x04001BE8 RID: 7144
		private uint? _multipoint;

		// Token: 0x04001BE9 RID: 7145
		private uint? _curusercount;

		// Token: 0x04001BEA RID: 7146
		private uint? _maxusercount;

		// Token: 0x04001BEB RID: 7147
		private bool? _isopen;

		// Token: 0x04001BEC RID: 7148
		private IExtension extensionObject;
	}
}
