using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SynGuildArenaBattleInfo")]
	[Serializable]
	public class SynGuildArenaBattleInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "warType", DataFormat = DataFormat.TwosComplement)]
		public uint warType
		{
			get
			{
				return this._warType ?? 0U;
			}
			set
			{
				this._warType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool warTypeSpecified
		{
			get
			{
				return this._warType != null;
			}
			set
			{
				bool flag = value == (this._warType == null);
				if (flag)
				{
					this._warType = (value ? new uint?(this.warType) : null);
				}
			}
		}

		private bool ShouldSerializewarType()
		{
			return this.warTypeSpecified;
		}

		private void ResetwarType()
		{
			this.warTypeSpecified = false;
		}

		[ProtoMember(2, Name = "arenaBattleInfo", DataFormat = DataFormat.Default)]
		public List<GuildArenaGroupData> arenaBattleInfo
		{
			get
			{
				return this._arenaBattleInfo;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "timestate", DataFormat = DataFormat.TwosComplement)]
		public GuildArenaState timestate
		{
			get
			{
				return this._timestate ?? GuildArenaState.GUILD_ARENA_NOT_BEGIN;
			}
			set
			{
				this._timestate = new GuildArenaState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timestateSpecified
		{
			get
			{
				return this._timestate != null;
			}
			set
			{
				bool flag = value == (this._timestate == null);
				if (flag)
				{
					this._timestate = (value ? new GuildArenaState?(this.timestate) : null);
				}
			}
		}

		private bool ShouldSerializetimestate()
		{
			return this.timestateSpecified;
		}

		private void Resettimestate()
		{
			this.timestateSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
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

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _warType;

		private readonly List<GuildArenaGroupData> _arenaBattleInfo = new List<GuildArenaGroupData>();

		private GuildArenaState? _timestate;

		private uint? _state;

		private IExtension extensionObject;
	}
}
