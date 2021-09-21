using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200032E RID: 814
	[ProtoContract(Name = "GCFCommonArg")]
	[Serializable]
	public class GCFCommonArg : IExtensible
	{
		// Token: 0x17000DE5 RID: 3557
		// (get) Token: 0x06002CD2 RID: 11474 RVA: 0x00056C44 File Offset: 0x00054E44
		// (set) Token: 0x06002CD3 RID: 11475 RVA: 0x00056C70 File Offset: 0x00054E70
		[ProtoMember(1, IsRequired = false, Name = "reqtype", DataFormat = DataFormat.TwosComplement)]
		public GCFReqType reqtype
		{
			get
			{
				return this._reqtype ?? GCFReqType.GCF_JOIN_READY_SCENE;
			}
			set
			{
				this._reqtype = new GCFReqType?(value);
			}
		}

		// Token: 0x17000DE6 RID: 3558
		// (get) Token: 0x06002CD4 RID: 11476 RVA: 0x00056C80 File Offset: 0x00054E80
		// (set) Token: 0x06002CD5 RID: 11477 RVA: 0x00056CA0 File Offset: 0x00054EA0
		[XmlIgnore]
		[Browsable(false)]
		public bool reqtypeSpecified
		{
			get
			{
				return this._reqtype != null;
			}
			set
			{
				bool flag = value == (this._reqtype == null);
				if (flag)
				{
					this._reqtype = (value ? new GCFReqType?(this.reqtype) : null);
				}
			}
		}

		// Token: 0x06002CD6 RID: 11478 RVA: 0x00056CE4 File Offset: 0x00054EE4
		private bool ShouldSerializereqtype()
		{
			return this.reqtypeSpecified;
		}

		// Token: 0x06002CD7 RID: 11479 RVA: 0x00056CFC File Offset: 0x00054EFC
		private void Resetreqtype()
		{
			this.reqtypeSpecified = false;
		}

		// Token: 0x17000DE7 RID: 3559
		// (get) Token: 0x06002CD8 RID: 11480 RVA: 0x00056D08 File Offset: 0x00054F08
		// (set) Token: 0x06002CD9 RID: 11481 RVA: 0x00056D34 File Offset: 0x00054F34
		[ProtoMember(2, IsRequired = false, Name = "mapid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000DE8 RID: 3560
		// (get) Token: 0x06002CDA RID: 11482 RVA: 0x00056D44 File Offset: 0x00054F44
		// (set) Token: 0x06002CDB RID: 11483 RVA: 0x00056D64 File Offset: 0x00054F64
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

		// Token: 0x06002CDC RID: 11484 RVA: 0x00056DA8 File Offset: 0x00054FA8
		private bool ShouldSerializemapid()
		{
			return this.mapidSpecified;
		}

		// Token: 0x06002CDD RID: 11485 RVA: 0x00056DC0 File Offset: 0x00054FC0
		private void Resetmapid()
		{
			this.mapidSpecified = false;
		}

		// Token: 0x17000DE9 RID: 3561
		// (get) Token: 0x06002CDE RID: 11486 RVA: 0x00056DCC File Offset: 0x00054FCC
		// (set) Token: 0x06002CDF RID: 11487 RVA: 0x00056DF8 File Offset: 0x00054FF8
		[ProtoMember(3, IsRequired = false, Name = "territoryid", DataFormat = DataFormat.TwosComplement)]
		public uint territoryid
		{
			get
			{
				return this._territoryid ?? 0U;
			}
			set
			{
				this._territoryid = new uint?(value);
			}
		}

		// Token: 0x17000DEA RID: 3562
		// (get) Token: 0x06002CE0 RID: 11488 RVA: 0x00056E08 File Offset: 0x00055008
		// (set) Token: 0x06002CE1 RID: 11489 RVA: 0x00056E28 File Offset: 0x00055028
		[XmlIgnore]
		[Browsable(false)]
		public bool territoryidSpecified
		{
			get
			{
				return this._territoryid != null;
			}
			set
			{
				bool flag = value == (this._territoryid == null);
				if (flag)
				{
					this._territoryid = (value ? new uint?(this.territoryid) : null);
				}
			}
		}

		// Token: 0x06002CE2 RID: 11490 RVA: 0x00056E6C File Offset: 0x0005506C
		private bool ShouldSerializeterritoryid()
		{
			return this.territoryidSpecified;
		}

		// Token: 0x06002CE3 RID: 11491 RVA: 0x00056E84 File Offset: 0x00055084
		private void Resetterritoryid()
		{
			this.territoryidSpecified = false;
		}

		// Token: 0x06002CE4 RID: 11492 RVA: 0x00056E90 File Offset: 0x00055090
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B19 RID: 2841
		private GCFReqType? _reqtype;

		// Token: 0x04000B1A RID: 2842
		private uint? _mapid;

		// Token: 0x04000B1B RID: 2843
		private uint? _territoryid;

		// Token: 0x04000B1C RID: 2844
		private IExtension extensionObject;
	}
}
