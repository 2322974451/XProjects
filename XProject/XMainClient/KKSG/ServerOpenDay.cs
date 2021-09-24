using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ServerOpenDay")]
	[Serializable]
	public class ServerOpenDay : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "openday", DataFormat = DataFormat.TwosComplement)]
		public int openday
		{
			get
			{
				return this._openday ?? 0;
			}
			set
			{
				this._openday = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool opendaySpecified
		{
			get
			{
				return this._openday != null;
			}
			set
			{
				bool flag = value == (this._openday == null);
				if (flag)
				{
					this._openday = (value ? new int?(this.openday) : null);
				}
			}
		}

		private bool ShouldSerializeopenday()
		{
			return this.opendaySpecified;
		}

		private void Resetopenday()
		{
			this.opendaySpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "week", DataFormat = DataFormat.TwosComplement)]
		public uint week
		{
			get
			{
				return this._week ?? 0U;
			}
			set
			{
				this._week = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekSpecified
		{
			get
			{
				return this._week != null;
			}
			set
			{
				bool flag = value == (this._week == null);
				if (flag)
				{
					this._week = (value ? new uint?(this.week) : null);
				}
			}
		}

		private bool ShouldSerializeweek()
		{
			return this.weekSpecified;
		}

		private void Resetweek()
		{
			this.weekSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "daybeginsecdiff", DataFormat = DataFormat.TwosComplement)]
		public uint daybeginsecdiff
		{
			get
			{
				return this._daybeginsecdiff ?? 0U;
			}
			set
			{
				this._daybeginsecdiff = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daybeginsecdiffSpecified
		{
			get
			{
				return this._daybeginsecdiff != null;
			}
			set
			{
				bool flag = value == (this._daybeginsecdiff == null);
				if (flag)
				{
					this._daybeginsecdiff = (value ? new uint?(this.daybeginsecdiff) : null);
				}
			}
		}

		private bool ShouldSerializedaybeginsecdiff()
		{
			return this.daybeginsecdiffSpecified;
		}

		private void Resetdaybeginsecdiff()
		{
			this.daybeginsecdiffSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "nowTime", DataFormat = DataFormat.TwosComplement)]
		public uint nowTime
		{
			get
			{
				return this._nowTime ?? 0U;
			}
			set
			{
				this._nowTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nowTimeSpecified
		{
			get
			{
				return this._nowTime != null;
			}
			set
			{
				bool flag = value == (this._nowTime == null);
				if (flag)
				{
					this._nowTime = (value ? new uint?(this.nowTime) : null);
				}
			}
		}

		private bool ShouldSerializenowTime()
		{
			return this.nowTimeSpecified;
		}

		private void ResetnowTime()
		{
			this.nowTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _openday;

		private uint? _week;

		private uint? _daybeginsecdiff;

		private uint? _nowTime;

		private IExtension extensionObject;
	}
}
