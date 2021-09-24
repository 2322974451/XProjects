using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HorseAward")]
	[Serializable]
	public class HorseAward : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "horse", DataFormat = DataFormat.TwosComplement)]
		public uint horse
		{
			get
			{
				return this._horse ?? 0U;
			}
			set
			{
				this._horse = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool horseSpecified
		{
			get
			{
				return this._horse != null;
			}
			set
			{
				bool flag = value == (this._horse == null);
				if (flag)
				{
					this._horse = (value ? new uint?(this.horse) : null);
				}
			}
		}

		private bool ShouldSerializehorse()
		{
			return this.horseSpecified;
		}

		private void Resethorse()
		{
			this.horseSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _time;

		private uint? _horse;

		private uint? _rank;

		private IExtension extensionObject;
	}
}
