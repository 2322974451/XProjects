using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MulActivitInfo")]
	[Serializable]
	public class MulActivitInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public int id
		{
			get
			{
				return this._id ?? 0;
			}
			set
			{
				this._id = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new int?(this.id) : null);
				}
			}
		}

		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		private void Resetid()
		{
			this.idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "openstate", DataFormat = DataFormat.TwosComplement)]
		public MulActivityTimeState openstate
		{
			get
			{
				return this._openstate ?? MulActivityTimeState.MULACTIVITY_BEfOREOPEN;
			}
			set
			{
				this._openstate = new MulActivityTimeState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool openstateSpecified
		{
			get
			{
				return this._openstate != null;
			}
			set
			{
				bool flag = value == (this._openstate == null);
				if (flag)
				{
					this._openstate = (value ? new MulActivityTimeState?(this.openstate) : null);
				}
			}
		}

		private bool ShouldSerializeopenstate()
		{
			return this.openstateSpecified;
		}

		private void Resetopenstate()
		{
			this.openstateSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "dayjoincount", DataFormat = DataFormat.TwosComplement)]
		public int dayjoincount
		{
			get
			{
				return this._dayjoincount ?? 0;
			}
			set
			{
				this._dayjoincount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dayjoincountSpecified
		{
			get
			{
				return this._dayjoincount != null;
			}
			set
			{
				bool flag = value == (this._dayjoincount == null);
				if (flag)
				{
					this._dayjoincount = (value ? new int?(this.dayjoincount) : null);
				}
			}
		}

		private bool ShouldSerializedayjoincount()
		{
			return this.dayjoincountSpecified;
		}

		private void Resetdayjoincount()
		{
			this.dayjoincountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "beginmin", DataFormat = DataFormat.TwosComplement)]
		public uint beginmin
		{
			get
			{
				return this._beginmin ?? 0U;
			}
			set
			{
				this._beginmin = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool beginminSpecified
		{
			get
			{
				return this._beginmin != null;
			}
			set
			{
				bool flag = value == (this._beginmin == null);
				if (flag)
				{
					this._beginmin = (value ? new uint?(this.beginmin) : null);
				}
			}
		}

		private bool ShouldSerializebeginmin()
		{
			return this.beginminSpecified;
		}

		private void Resetbeginmin()
		{
			this.beginminSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "endmin", DataFormat = DataFormat.TwosComplement)]
		public uint endmin
		{
			get
			{
				return this._endmin ?? 0U;
			}
			set
			{
				this._endmin = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool endminSpecified
		{
			get
			{
				return this._endmin != null;
			}
			set
			{
				bool flag = value == (this._endmin == null);
				if (flag)
				{
					this._endmin = (value ? new uint?(this.endmin) : null);
				}
			}
		}

		private bool ShouldSerializeendmin()
		{
			return this.endminSpecified;
		}

		private void Resetendmin()
		{
			this.endminSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "real_open_state", DataFormat = DataFormat.TwosComplement)]
		public ActOpenState real_open_state
		{
			get
			{
				return this._real_open_state ?? ActOpenState.ActOpenState_NotOpen;
			}
			set
			{
				this._real_open_state = new ActOpenState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool real_open_stateSpecified
		{
			get
			{
				return this._real_open_state != null;
			}
			set
			{
				bool flag = value == (this._real_open_state == null);
				if (flag)
				{
					this._real_open_state = (value ? new ActOpenState?(this.real_open_state) : null);
				}
			}
		}

		private bool ShouldSerializereal_open_state()
		{
			return this.real_open_stateSpecified;
		}

		private void Resetreal_open_state()
		{
			this.real_open_stateSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "is_playing", DataFormat = DataFormat.Default)]
		public bool is_playing
		{
			get
			{
				return this._is_playing ?? false;
			}
			set
			{
				this._is_playing = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_playingSpecified
		{
			get
			{
				return this._is_playing != null;
			}
			set
			{
				bool flag = value == (this._is_playing == null);
				if (flag)
				{
					this._is_playing = (value ? new bool?(this.is_playing) : null);
				}
			}
		}

		private bool ShouldSerializeis_playing()
		{
			return this.is_playingSpecified;
		}

		private void Resetis_playing()
		{
			this.is_playingSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _id;

		private MulActivityTimeState? _openstate;

		private uint? _lefttime;

		private int? _dayjoincount;

		private uint? _beginmin;

		private uint? _endmin;

		private ActOpenState? _real_open_state;

		private bool? _is_playing;

		private IExtension extensionObject;
	}
}
