using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetCrossGvgDataRes")]
	[Serializable]
	public class GetCrossGvgDataRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, Name = "rank", DataFormat = DataFormat.Default)]
		public List<CrossGvgGuildInfo> rank
		{
			get
			{
				return this._rank;
			}
		}

		[ProtoMember(3, Name = "record", DataFormat = DataFormat.Default)]
		public List<CrossGvgRacePointRecord> record
		{
			get
			{
				return this._record;
			}
		}

		[ProtoMember(4, Name = "rooms", DataFormat = DataFormat.Default)]
		public List<CrossGvgRoomInfo> rooms
		{
			get
			{
				return this._rooms;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public GuildArenaState state
		{
			get
			{
				return this._state ?? GuildArenaState.GUILD_ARENA_NOT_BEGIN;
			}
			set
			{
				this._state = new GuildArenaState?(value);
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
					this._state = (value ? new GuildArenaState?(this.state) : null);
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

		[ProtoMember(6, Name = "support_guildid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> support_guildid
		{
			get
			{
				return this._support_guildid;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "season_num", DataFormat = DataFormat.TwosComplement)]
		public uint season_num
		{
			get
			{
				return this._season_num ?? 0U;
			}
			set
			{
				this._season_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool season_numSpecified
		{
			get
			{
				return this._season_num != null;
			}
			set
			{
				bool flag = value == (this._season_num == null);
				if (flag)
				{
					this._season_num = (value ? new uint?(this.season_num) : null);
				}
			}
		}

		private bool ShouldSerializeseason_num()
		{
			return this.season_numSpecified;
		}

		private void Resetseason_num()
		{
			this.season_numSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<CrossGvgGuildInfo> _rank = new List<CrossGvgGuildInfo>();

		private readonly List<CrossGvgRacePointRecord> _record = new List<CrossGvgRacePointRecord>();

		private readonly List<CrossGvgRoomInfo> _rooms = new List<CrossGvgRoomInfo>();

		private GuildArenaState? _state;

		private readonly List<ulong> _support_guildid = new List<ulong>();

		private uint? _season_num;

		private IExtension extensionObject;
	}
}
