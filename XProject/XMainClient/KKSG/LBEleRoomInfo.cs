using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LBEleRoomInfo")]
	[Serializable]
	public class LBEleRoomInfo : IExtensible
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
		public LBEleTeamInfo team1
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
		public LBEleTeamInfo team2
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

		[ProtoMember(5, IsRequired = false, Name = "winleagueid", DataFormat = DataFormat.TwosComplement)]
		public ulong winleagueid
		{
			get
			{
				return this._winleagueid ?? 0UL;
			}
			set
			{
				this._winleagueid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winleagueidSpecified
		{
			get
			{
				return this._winleagueid != null;
			}
			set
			{
				bool flag = value == (this._winleagueid == null);
				if (flag)
				{
					this._winleagueid = (value ? new ulong?(this.winleagueid) : null);
				}
			}
		}

		private bool ShouldSerializewinleagueid()
		{
			return this.winleagueidSpecified;
		}

		private void Resetwinleagueid()
		{
			this.winleagueidSpecified = false;
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

		private LBEleTeamInfo _team1 = null;

		private LBEleTeamInfo _team2 = null;

		private LBEleRoomState? _state;

		private ulong? _winleagueid;

		private uint? _liveid;

		private IExtension extensionObject;
	}
}
