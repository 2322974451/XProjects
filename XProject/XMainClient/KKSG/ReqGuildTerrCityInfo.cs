using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200033C RID: 828
	[ProtoContract(Name = "ReqGuildTerrCityInfo")]
	[Serializable]
	public class ReqGuildTerrCityInfo : IExtensible
	{
		// Token: 0x17000E1C RID: 3612
		// (get) Token: 0x06002D78 RID: 11640 RVA: 0x00057FD8 File Offset: 0x000561D8
		[ProtoMember(1, Name = "cityinfo", DataFormat = DataFormat.Default)]
		public List<CityData> cityinfo
		{
			get
			{
				return this._cityinfo;
			}
		}

		// Token: 0x17000E1D RID: 3613
		// (get) Token: 0x06002D79 RID: 11641 RVA: 0x00057FF0 File Offset: 0x000561F0
		// (set) Token: 0x06002D7A RID: 11642 RVA: 0x0005801C File Offset: 0x0005621C
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public GUILDTERRTYPE type
		{
			get
			{
				return this._type ?? GUILDTERRTYPE.TERR_NOT_OPEN;
			}
			set
			{
				this._type = new GUILDTERRTYPE?(value);
			}
		}

		// Token: 0x17000E1E RID: 3614
		// (get) Token: 0x06002D7B RID: 11643 RVA: 0x0005802C File Offset: 0x0005622C
		// (set) Token: 0x06002D7C RID: 11644 RVA: 0x0005804C File Offset: 0x0005624C
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new GUILDTERRTYPE?(this.type) : null);
				}
			}
		}

		// Token: 0x06002D7D RID: 11645 RVA: 0x00058090 File Offset: 0x00056290
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06002D7E RID: 11646 RVA: 0x000580A8 File Offset: 0x000562A8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000E1F RID: 3615
		// (get) Token: 0x06002D7F RID: 11647 RVA: 0x000580B4 File Offset: 0x000562B4
		// (set) Token: 0x06002D80 RID: 11648 RVA: 0x000580E0 File Offset: 0x000562E0
		[ProtoMember(3, IsRequired = false, Name = "targetid", DataFormat = DataFormat.TwosComplement)]
		public uint targetid
		{
			get
			{
				return this._targetid ?? 0U;
			}
			set
			{
				this._targetid = new uint?(value);
			}
		}

		// Token: 0x17000E20 RID: 3616
		// (get) Token: 0x06002D81 RID: 11649 RVA: 0x000580F0 File Offset: 0x000562F0
		// (set) Token: 0x06002D82 RID: 11650 RVA: 0x00058110 File Offset: 0x00056310
		[XmlIgnore]
		[Browsable(false)]
		public bool targetidSpecified
		{
			get
			{
				return this._targetid != null;
			}
			set
			{
				bool flag = value == (this._targetid == null);
				if (flag)
				{
					this._targetid = (value ? new uint?(this.targetid) : null);
				}
			}
		}

		// Token: 0x06002D83 RID: 11651 RVA: 0x00058154 File Offset: 0x00056354
		private bool ShouldSerializetargetid()
		{
			return this.targetidSpecified;
		}

		// Token: 0x06002D84 RID: 11652 RVA: 0x0005816C File Offset: 0x0005636C
		private void Resettargetid()
		{
			this.targetidSpecified = false;
		}

		// Token: 0x17000E21 RID: 3617
		// (get) Token: 0x06002D85 RID: 11653 RVA: 0x00058178 File Offset: 0x00056378
		// (set) Token: 0x06002D86 RID: 11654 RVA: 0x000581A5 File Offset: 0x000563A5
		[ProtoMember(4, IsRequired = false, Name = "allianceId", DataFormat = DataFormat.TwosComplement)]
		public ulong allianceId
		{
			get
			{
				return this._allianceId ?? 0UL;
			}
			set
			{
				this._allianceId = new ulong?(value);
			}
		}

		// Token: 0x17000E22 RID: 3618
		// (get) Token: 0x06002D87 RID: 11655 RVA: 0x000581B4 File Offset: 0x000563B4
		// (set) Token: 0x06002D88 RID: 11656 RVA: 0x000581D4 File Offset: 0x000563D4
		[XmlIgnore]
		[Browsable(false)]
		public bool allianceIdSpecified
		{
			get
			{
				return this._allianceId != null;
			}
			set
			{
				bool flag = value == (this._allianceId == null);
				if (flag)
				{
					this._allianceId = (value ? new ulong?(this.allianceId) : null);
				}
			}
		}

		// Token: 0x06002D89 RID: 11657 RVA: 0x00058218 File Offset: 0x00056418
		private bool ShouldSerializeallianceId()
		{
			return this.allianceIdSpecified;
		}

		// Token: 0x06002D8A RID: 11658 RVA: 0x00058230 File Offset: 0x00056430
		private void ResetallianceId()
		{
			this.allianceIdSpecified = false;
		}

		// Token: 0x17000E23 RID: 3619
		// (get) Token: 0x06002D8B RID: 11659 RVA: 0x0005823C File Offset: 0x0005643C
		// (set) Token: 0x06002D8C RID: 11660 RVA: 0x00058268 File Offset: 0x00056468
		[ProtoMember(5, IsRequired = false, Name = "max_territory_level", DataFormat = DataFormat.TwosComplement)]
		public uint max_territory_level
		{
			get
			{
				return this._max_territory_level ?? 0U;
			}
			set
			{
				this._max_territory_level = new uint?(value);
			}
		}

		// Token: 0x17000E24 RID: 3620
		// (get) Token: 0x06002D8D RID: 11661 RVA: 0x00058278 File Offset: 0x00056478
		// (set) Token: 0x06002D8E RID: 11662 RVA: 0x00058298 File Offset: 0x00056498
		[XmlIgnore]
		[Browsable(false)]
		public bool max_territory_levelSpecified
		{
			get
			{
				return this._max_territory_level != null;
			}
			set
			{
				bool flag = value == (this._max_territory_level == null);
				if (flag)
				{
					this._max_territory_level = (value ? new uint?(this.max_territory_level) : null);
				}
			}
		}

		// Token: 0x06002D8F RID: 11663 RVA: 0x000582DC File Offset: 0x000564DC
		private bool ShouldSerializemax_territory_level()
		{
			return this.max_territory_levelSpecified;
		}

		// Token: 0x06002D90 RID: 11664 RVA: 0x000582F4 File Offset: 0x000564F4
		private void Resetmax_territory_level()
		{
			this.max_territory_levelSpecified = false;
		}

		// Token: 0x06002D91 RID: 11665 RVA: 0x00058300 File Offset: 0x00056500
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B4A RID: 2890
		private readonly List<CityData> _cityinfo = new List<CityData>();

		// Token: 0x04000B4B RID: 2891
		private GUILDTERRTYPE? _type;

		// Token: 0x04000B4C RID: 2892
		private uint? _targetid;

		// Token: 0x04000B4D RID: 2893
		private ulong? _allianceId;

		// Token: 0x04000B4E RID: 2894
		private uint? _max_territory_level;

		// Token: 0x04000B4F RID: 2895
		private IExtension extensionObject;
	}
}
