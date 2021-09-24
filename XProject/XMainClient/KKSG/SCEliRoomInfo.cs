using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SCEliRoomInfo")]
	[Serializable]
	public class SCEliRoomInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roomid", DataFormat = DataFormat.TwosComplement)]
		public uint roomid
		{
			get
			{
				return this._roomid ?? 0U;
			}
			set
			{
				this._roomid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roomidSpecified
		{
			get
			{
				return this._roomid != null;
			}
			set
			{
				bool flag = value == (this._roomid == null);
				if (flag)
				{
					this._roomid = (value ? new uint?(this.roomid) : null);
				}
			}
		}

		private bool ShouldSerializeroomid()
		{
			return this.roomidSpecified;
		}

		private void Resetroomid()
		{
			this.roomidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "team1", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SCEliTeamInfo team1
		{
			get
			{
				return this._team1;
			}
			set
			{
				this._team1 = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "team2", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SCEliTeamInfo team2
		{
			get
			{
				return this._team2;
			}
			set
			{
				this._team2 = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public LBEleRoomState state
		{
			get
			{
				return this._state ?? LBEleRoomState.LBEleRoomState_Idle;
			}
			set
			{
				this._state = new LBEleRoomState?(value);
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
					this._state = (value ? new LBEleRoomState?(this.state) : null);
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

		[ProtoMember(5, IsRequired = false, Name = "win_stid", DataFormat = DataFormat.TwosComplement)]
		public ulong win_stid
		{
			get
			{
				return this._win_stid ?? 0UL;
			}
			set
			{
				this._win_stid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool win_stidSpecified
		{
			get
			{
				return this._win_stid != null;
			}
			set
			{
				bool flag = value == (this._win_stid == null);
				if (flag)
				{
					this._win_stid = (value ? new ulong?(this.win_stid) : null);
				}
			}
		}

		private bool ShouldSerializewin_stid()
		{
			return this.win_stidSpecified;
		}

		private void Resetwin_stid()
		{
			this.win_stidSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "liveid", DataFormat = DataFormat.TwosComplement)]
		public uint liveid
		{
			get
			{
				return this._liveid ?? 0U;
			}
			set
			{
				this._liveid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool liveidSpecified
		{
			get
			{
				return this._liveid != null;
			}
			set
			{
				bool flag = value == (this._liveid == null);
				if (flag)
				{
					this._liveid = (value ? new uint?(this.liveid) : null);
				}
			}
		}

		private bool ShouldSerializeliveid()
		{
			return this.liveidSpecified;
		}

		private void Resetliveid()
		{
			this.liveidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _roomid;

		private SCEliTeamInfo _team1 = null;

		private SCEliTeamInfo _team2 = null;

		private LBEleRoomState? _state;

		private ulong? _win_stid;

		private uint? _liveid;

		private IExtension extensionObject;
	}
}
