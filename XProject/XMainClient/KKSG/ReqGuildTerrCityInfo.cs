using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqGuildTerrCityInfo")]
	[Serializable]
	public class ReqGuildTerrCityInfo : IExtensible
	{

		[ProtoMember(1, Name = "cityinfo", DataFormat = DataFormat.Default)]
		public List<CityData> cityinfo
		{
			get
			{
				return this._cityinfo;
			}
		}

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

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

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

		private bool ShouldSerializetargetid()
		{
			return this.targetidSpecified;
		}

		private void Resettargetid()
		{
			this.targetidSpecified = false;
		}

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

		private bool ShouldSerializeallianceId()
		{
			return this.allianceIdSpecified;
		}

		private void ResetallianceId()
		{
			this.allianceIdSpecified = false;
		}

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

		private bool ShouldSerializemax_territory_level()
		{
			return this.max_territory_levelSpecified;
		}

		private void Resetmax_territory_level()
		{
			this.max_territory_levelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<CityData> _cityinfo = new List<CityData>();

		private GUILDTERRTYPE? _type;

		private uint? _targetid;

		private ulong? _allianceId;

		private uint? _max_territory_level;

		private IExtension extensionObject;
	}
}
