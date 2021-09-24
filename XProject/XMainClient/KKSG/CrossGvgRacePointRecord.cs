using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CrossGvgRacePointRecord")]
	[Serializable]
	public class CrossGvgRacePointRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		private void Resettime()
		{
			this.timeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "opponent", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CrossGvgGuildInfo opponent
		{
			get
			{
				return this._opponent;
			}
			set
			{
				this._opponent = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public CrossGvgRoomState state
		{
			get
			{
				return this._state ?? CrossGvgRoomState.CGRS_Idle;
			}
			set
			{
				this._state = new CrossGvgRoomState?(value);
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
					this._state = (value ? new CrossGvgRoomState?(this.state) : null);
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

		[ProtoMember(4, IsRequired = false, Name = "iswin", DataFormat = DataFormat.Default)]
		public bool iswin
		{
			get
			{
				return this._iswin ?? false;
			}
			set
			{
				this._iswin = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iswinSpecified
		{
			get
			{
				return this._iswin != null;
			}
			set
			{
				bool flag = value == (this._iswin == null);
				if (flag)
				{
					this._iswin = (value ? new bool?(this.iswin) : null);
				}
			}
		}

		private bool ShouldSerializeiswin()
		{
			return this.iswinSpecified;
		}

		private void Resetiswin()
		{
			this.iswinSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "addscore", DataFormat = DataFormat.TwosComplement)]
		public uint addscore
		{
			get
			{
				return this._addscore ?? 0U;
			}
			set
			{
				this._addscore = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool addscoreSpecified
		{
			get
			{
				return this._addscore != null;
			}
			set
			{
				bool flag = value == (this._addscore == null);
				if (flag)
				{
					this._addscore = (value ? new uint?(this.addscore) : null);
				}
			}
		}

		private bool ShouldSerializeaddscore()
		{
			return this.addscoreSpecified;
		}

		private void Resetaddscore()
		{
			this.addscoreSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "roomid", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _time;

		private CrossGvgGuildInfo _opponent = null;

		private CrossGvgRoomState? _state;

		private bool? _iswin;

		private uint? _addscore;

		private uint? _roomid;

		private IExtension extensionObject;
	}
}
