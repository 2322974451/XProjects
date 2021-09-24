using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCityAllTeamBaseInfo")]
	[Serializable]
	public class SkyCityAllTeamBaseInfo : IExtensible
	{

		[ProtoMember(1, Name = "info", DataFormat = DataFormat.Default)]
		public List<SkyCityTeamBaseInfo> info
		{
			get
			{
				return this._info;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "games", DataFormat = DataFormat.TwosComplement)]
		public uint games
		{
			get
			{
				return this._games ?? 0U;
			}
			set
			{
				this._games = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gamesSpecified
		{
			get
			{
				return this._games != null;
			}
			set
			{
				bool flag = value == (this._games == null);
				if (flag)
				{
					this._games = (value ? new uint?(this.games) : null);
				}
			}
		}

		private bool ShouldSerializegames()
		{
			return this.gamesSpecified;
		}

		private void Resetgames()
		{
			this.gamesSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "floor", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<SkyCityTeamBaseInfo> _info = new List<SkyCityTeamBaseInfo>();

		private uint? _games;

		private uint? _floor;

		private IExtension extensionObject;
	}
}
