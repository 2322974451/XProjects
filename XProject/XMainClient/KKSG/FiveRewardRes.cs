using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FiveRewardRes")]
	[Serializable]
	public class FiveRewardRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "twoday", DataFormat = DataFormat.Default)]
		public bool twoday
		{
			get
			{
				return this._twoday ?? false;
			}
			set
			{
				this._twoday = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool twodaySpecified
		{
			get
			{
				return this._twoday != null;
			}
			set
			{
				bool flag = value == (this._twoday == null);
				if (flag)
				{
					this._twoday = (value ? new bool?(this.twoday) : null);
				}
			}
		}

		private bool ShouldSerializetwoday()
		{
			return this.twodaySpecified;
		}

		private void Resettwoday()
		{
			this.twodaySpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "fiveday", DataFormat = DataFormat.Default)]
		public bool fiveday
		{
			get
			{
				return this._fiveday ?? false;
			}
			set
			{
				this._fiveday = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fivedaySpecified
		{
			get
			{
				return this._fiveday != null;
			}
			set
			{
				bool flag = value == (this._fiveday == null);
				if (flag)
				{
					this._fiveday = (value ? new bool?(this.fiveday) : null);
				}
			}
		}

		private bool ShouldSerializefiveday()
		{
			return this.fivedaySpecified;
		}

		private void Resetfiveday()
		{
			this.fivedaySpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "threeday", DataFormat = DataFormat.Default)]
		public bool threeday
		{
			get
			{
				return this._threeday ?? false;
			}
			set
			{
				this._threeday = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool threedaySpecified
		{
			get
			{
				return this._threeday != null;
			}
			set
			{
				bool flag = value == (this._threeday == null);
				if (flag)
				{
					this._threeday = (value ? new bool?(this.threeday) : null);
				}
			}
		}

		private bool ShouldSerializethreeday()
		{
			return this.threedaySpecified;
		}

		private void Resetthreeday()
		{
			this.threedaySpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "sevenday", DataFormat = DataFormat.Default)]
		public bool sevenday
		{
			get
			{
				return this._sevenday ?? false;
			}
			set
			{
				this._sevenday = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sevendaySpecified
		{
			get
			{
				return this._sevenday != null;
			}
			set
			{
				bool flag = value == (this._sevenday == null);
				if (flag)
				{
					this._sevenday = (value ? new bool?(this.sevenday) : null);
				}
			}
		}

		private bool ShouldSerializesevenday()
		{
			return this.sevendaySpecified;
		}

		private void Resetsevenday()
		{
			this.sevendaySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _twoday;

		private bool? _fiveday;

		private bool? _threeday;

		private bool? _sevenday;

		private IExtension extensionObject;
	}
}
