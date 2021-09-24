using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleFieldReadyInfo")]
	[Serializable]
	public class BattleFieldReadyInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "round", DataFormat = DataFormat.TwosComplement)]
		public uint round
		{
			get
			{
				return this._round ?? 0U;
			}
			set
			{
				this._round = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roundSpecified
		{
			get
			{
				return this._round != null;
			}
			set
			{
				bool flag = value == (this._round == null);
				if (flag)
				{
					this._round = (value ? new uint?(this.round) : null);
				}
			}
		}

		private bool ShouldSerializeround()
		{
			return this.roundSpecified;
		}

		private void Resetround()
		{
			this.roundSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "failed", DataFormat = DataFormat.Default)]
		public bool failed
		{
			get
			{
				return this._failed ?? false;
			}
			set
			{
				this._failed = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool failedSpecified
		{
			get
			{
				return this._failed != null;
			}
			set
			{
				bool flag = value == (this._failed == null);
				if (flag)
				{
					this._failed = (value ? new bool?(this.failed) : null);
				}
			}
		}

		private bool ShouldSerializefailed()
		{
			return this.failedSpecified;
		}

		private void Resetfailed()
		{
			this.failedSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "end", DataFormat = DataFormat.Default)]
		public bool end
		{
			get
			{
				return this._end ?? false;
			}
			set
			{
				this._end = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool endSpecified
		{
			get
			{
				return this._end != null;
			}
			set
			{
				bool flag = value == (this._end == null);
				if (flag)
				{
					this._end = (value ? new bool?(this.end) : null);
				}
			}
		}

		private bool ShouldSerializeend()
		{
			return this.endSpecified;
		}

		private void Resetend()
		{
			this.endSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _round;

		private uint? _time;

		private bool? _failed;

		private bool? _end;

		private IExtension extensionObject;
	}
}
