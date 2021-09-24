using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCityEstimateInfo")]
	[Serializable]
	public class SkyCityEstimateInfo : IExtensible
	{

		[ProtoMember(1, Name = "info", DataFormat = DataFormat.Default)]
		public List<SkyCityEstimateBaseInfo> info
		{
			get
			{
				return this._info;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "floor", DataFormat = DataFormat.TwosComplement)]
		public uint floor
		{
			get
			{
				return this._floor ?? 0U;
			}
			set
			{
				this._floor = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool floorSpecified
		{
			get
			{
				return this._floor != null;
			}
			set
			{
				bool flag = value == (this._floor == null);
				if (flag)
				{
					this._floor = (value ? new uint?(this.floor) : null);
				}
			}
		}

		private bool ShouldSerializefloor()
		{
			return this.floorSpecified;
		}

		private void Resetfloor()
		{
			this.floorSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "winteamid", DataFormat = DataFormat.TwosComplement)]
		public uint winteamid
		{
			get
			{
				return this._winteamid ?? 0U;
			}
			set
			{
				this._winteamid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winteamidSpecified
		{
			get
			{
				return this._winteamid != null;
			}
			set
			{
				bool flag = value == (this._winteamid == null);
				if (flag)
				{
					this._winteamid = (value ? new uint?(this.winteamid) : null);
				}
			}
		}

		private bool ShouldSerializewinteamid()
		{
			return this.winteamidSpecified;
		}

		private void Resetwinteamid()
		{
			this.winteamidSpecified = false;
		}

		[ProtoMember(4, Name = "teamscore", DataFormat = DataFormat.Default)]
		public List<SkyCityTeamScore> teamscore
		{
			get
			{
				return this._teamscore;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<SkyCityEstimateBaseInfo> _info = new List<SkyCityEstimateBaseInfo>();

		private uint? _floor;

		private uint? _winteamid;

		private readonly List<SkyCityTeamScore> _teamscore = new List<SkyCityTeamScore>();

		private IExtension extensionObject;
	}
}
