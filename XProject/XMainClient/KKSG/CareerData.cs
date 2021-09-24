using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CareerData")]
	[Serializable]
	public class CareerData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public CarrerDataType type
		{
			get
			{
				return this._type ?? CarrerDataType.CARRER_DATA_LEVEL;
			}
			set
			{
				this._type = new CarrerDataType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new CarrerDataType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
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

		[ProtoMember(3, IsRequired = false, Name = "para1", DataFormat = DataFormat.TwosComplement)]
		public uint para1
		{
			get
			{
				return this._para1 ?? 0U;
			}
			set
			{
				this._para1 = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool para1Specified
		{
			get
			{
				return this._para1 != null;
			}
			set
			{
				bool flag = value == (this._para1 == null);
				if (flag)
				{
					this._para1 = (value ? new uint?(this.para1) : null);
				}
			}
		}

		private bool ShouldSerializepara1()
		{
			return this.para1Specified;
		}

		private void Resetpara1()
		{
			this.para1Specified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private CarrerDataType? _type;

		private uint? _time;

		private uint? _para1;

		private IExtension extensionObject;
	}
}
