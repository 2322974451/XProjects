using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TrophyDetail")]
	[Serializable]
	public class TrophyDetail : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "tropy_order", DataFormat = DataFormat.TwosComplement)]
		public uint tropy_order
		{
			get
			{
				return this._tropy_order ?? 0U;
			}
			set
			{
				this._tropy_order = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tropy_orderSpecified
		{
			get
			{
				return this._tropy_order != null;
			}
			set
			{
				bool flag = value == (this._tropy_order == null);
				if (flag)
				{
					this._tropy_order = (value ? new uint?(this.tropy_order) : null);
				}
			}
		}

		private bool ShouldSerializetropy_order()
		{
			return this.tropy_orderSpecified;
		}

		private void Resettropy_order()
		{
			this.tropy_orderSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "trophy_time", DataFormat = DataFormat.TwosComplement)]
		public uint trophy_time
		{
			get
			{
				return this._trophy_time ?? 0U;
			}
			set
			{
				this._trophy_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool trophy_timeSpecified
		{
			get
			{
				return this._trophy_time != null;
			}
			set
			{
				bool flag = value == (this._trophy_time == null);
				if (flag)
				{
					this._trophy_time = (value ? new uint?(this.trophy_time) : null);
				}
			}
		}

		private bool ShouldSerializetrophy_time()
		{
			return this.trophy_timeSpecified;
		}

		private void Resettrophy_time()
		{
			this.trophy_timeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _tropy_order;

		private uint? _trophy_time;

		private IExtension extensionObject;
	}
}
