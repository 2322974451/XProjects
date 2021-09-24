using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMobaBattleWeekRewardRes")]
	[Serializable]
	public class GetMobaBattleWeekRewardRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "weekprize", DataFormat = DataFormat.TwosComplement)]
		public uint weekprize
		{
			get
			{
				return this._weekprize ?? 0U;
			}
			set
			{
				this._weekprize = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekprizeSpecified
		{
			get
			{
				return this._weekprize != null;
			}
			set
			{
				bool flag = value == (this._weekprize == null);
				if (flag)
				{
					this._weekprize = (value ? new uint?(this.weekprize) : null);
				}
			}
		}

		private bool ShouldSerializeweekprize()
		{
			return this.weekprizeSpecified;
		}

		private void Resetweekprize()
		{
			this.weekprizeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "getnextweekprize", DataFormat = DataFormat.Default)]
		public bool getnextweekprize
		{
			get
			{
				return this._getnextweekprize ?? false;
			}
			set
			{
				this._getnextweekprize = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getnextweekprizeSpecified
		{
			get
			{
				return this._getnextweekprize != null;
			}
			set
			{
				bool flag = value == (this._getnextweekprize == null);
				if (flag)
				{
					this._getnextweekprize = (value ? new bool?(this.getnextweekprize) : null);
				}
			}
		}

		private bool ShouldSerializegetnextweekprize()
		{
			return this.getnextweekprizeSpecified;
		}

		private void Resetgetnextweekprize()
		{
			this.getnextweekprizeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private uint? _weekprize;

		private bool? _getnextweekprize;

		private IExtension extensionObject;
	}
}
