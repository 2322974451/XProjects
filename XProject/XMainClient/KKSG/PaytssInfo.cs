using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PaytssInfo")]
	[Serializable]
	public class PaytssInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "begintime", DataFormat = DataFormat.TwosComplement)]
		public int begintime
		{
			get
			{
				return this._begintime ?? 0;
			}
			set
			{
				this._begintime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool begintimeSpecified
		{
			get
			{
				return this._begintime != null;
			}
			set
			{
				bool flag = value == (this._begintime == null);
				if (flag)
				{
					this._begintime = (value ? new int?(this.begintime) : null);
				}
			}
		}

		private bool ShouldSerializebegintime()
		{
			return this.begintimeSpecified;
		}

		private void Resetbegintime()
		{
			this.begintimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "endtime", DataFormat = DataFormat.TwosComplement)]
		public int endtime
		{
			get
			{
				return this._endtime ?? 0;
			}
			set
			{
				this._endtime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool endtimeSpecified
		{
			get
			{
				return this._endtime != null;
			}
			set
			{
				bool flag = value == (this._endtime == null);
				if (flag)
				{
					this._endtime = (value ? new int?(this.endtime) : null);
				}
			}
		}

		private bool ShouldSerializeendtime()
		{
			return this.endtimeSpecified;
		}

		private void Resetendtime()
		{
			this.endtimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lastGetAwardTime", DataFormat = DataFormat.TwosComplement)]
		public int lastGetAwardTime
		{
			get
			{
				return this._lastGetAwardTime ?? 0;
			}
			set
			{
				this._lastGetAwardTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastGetAwardTimeSpecified
		{
			get
			{
				return this._lastGetAwardTime != null;
			}
			set
			{
				bool flag = value == (this._lastGetAwardTime == null);
				if (flag)
				{
					this._lastGetAwardTime = (value ? new int?(this.lastGetAwardTime) : null);
				}
			}
		}

		private bool ShouldSerializelastGetAwardTime()
		{
			return this.lastGetAwardTimeSpecified;
		}

		private void ResetlastGetAwardTime()
		{
			this.lastGetAwardTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _begintime;

		private int? _endtime;

		private int? _lastGetAwardTime;

		private IExtension extensionObject;
	}
}
