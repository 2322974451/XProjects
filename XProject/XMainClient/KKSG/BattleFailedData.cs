using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleFailedData")]
	[Serializable]
	public class BattleFailedData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "timespan", DataFormat = DataFormat.TwosComplement)]
		public uint timespan
		{
			get
			{
				return this._timespan ?? 0U;
			}
			set
			{
				this._timespan = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timespanSpecified
		{
			get
			{
				return this._timespan != null;
			}
			set
			{
				bool flag = value == (this._timespan == null);
				if (flag)
				{
					this._timespan = (value ? new uint?(this.timespan) : null);
				}
			}
		}

		private bool ShouldSerializetimespan()
		{
			return this.timespanSpecified;
		}

		private void Resettimespan()
		{
			this.timespanSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "hppercent", DataFormat = DataFormat.TwosComplement)]
		public uint hppercent
		{
			get
			{
				return this._hppercent ?? 0U;
			}
			set
			{
				this._hppercent = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hppercentSpecified
		{
			get
			{
				return this._hppercent != null;
			}
			set
			{
				bool flag = value == (this._hppercent == null);
				if (flag)
				{
					this._hppercent = (value ? new uint?(this.hppercent) : null);
				}
			}
		}

		private bool ShouldSerializehppercent()
		{
			return this.hppercentSpecified;
		}

		private void Resethppercent()
		{
			this.hppercentSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "deathcount", DataFormat = DataFormat.TwosComplement)]
		public uint deathcount
		{
			get
			{
				return this._deathcount ?? 0U;
			}
			set
			{
				this._deathcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool deathcountSpecified
		{
			get
			{
				return this._deathcount != null;
			}
			set
			{
				bool flag = value == (this._deathcount == null);
				if (flag)
				{
					this._deathcount = (value ? new uint?(this.deathcount) : null);
				}
			}
		}

		private bool ShouldSerializedeathcount()
		{
			return this.deathcountSpecified;
		}

		private void Resetdeathcount()
		{
			this.deathcountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _timespan;

		private uint? _hppercent;

		private uint? _deathcount;

		private IExtension extensionObject;
	}
}
