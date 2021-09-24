using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CampDuelActivityOperationRes")]
	[Serializable]
	public class CampDuelActivityOperationRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CampDuelData data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "precedeCampID", DataFormat = DataFormat.TwosComplement)]
		public uint precedeCampID
		{
			get
			{
				return this._precedeCampID ?? 0U;
			}
			set
			{
				this._precedeCampID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool precedeCampIDSpecified
		{
			get
			{
				return this._precedeCampID != null;
			}
			set
			{
				bool flag = value == (this._precedeCampID == null);
				if (flag)
				{
					this._precedeCampID = (value ? new uint?(this.precedeCampID) : null);
				}
			}
		}

		private bool ShouldSerializeprecedeCampID()
		{
			return this.precedeCampIDSpecified;
		}

		private void ResetprecedeCampID()
		{
			this.precedeCampIDSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "campDuelPoint1", DataFormat = DataFormat.TwosComplement)]
		public uint campDuelPoint1
		{
			get
			{
				return this._campDuelPoint1 ?? 0U;
			}
			set
			{
				this._campDuelPoint1 = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool campDuelPoint1Specified
		{
			get
			{
				return this._campDuelPoint1 != null;
			}
			set
			{
				bool flag = value == (this._campDuelPoint1 == null);
				if (flag)
				{
					this._campDuelPoint1 = (value ? new uint?(this.campDuelPoint1) : null);
				}
			}
		}

		private bool ShouldSerializecampDuelPoint1()
		{
			return this.campDuelPoint1Specified;
		}

		private void ResetcampDuelPoint1()
		{
			this.campDuelPoint1Specified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "campDuelPoint2", DataFormat = DataFormat.TwosComplement)]
		public uint campDuelPoint2
		{
			get
			{
				return this._campDuelPoint2 ?? 0U;
			}
			set
			{
				this._campDuelPoint2 = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool campDuelPoint2Specified
		{
			get
			{
				return this._campDuelPoint2 != null;
			}
			set
			{
				bool flag = value == (this._campDuelPoint2 == null);
				if (flag)
				{
					this._campDuelPoint2 = (value ? new uint?(this.campDuelPoint2) : null);
				}
			}
		}

		private bool ShouldSerializecampDuelPoint2()
		{
			return this.campDuelPoint2Specified;
		}

		private void ResetcampDuelPoint2()
		{
			this.campDuelPoint2Specified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private CampDuelData _data = null;

		private uint? _precedeCampID;

		private uint? _campDuelPoint1;

		private uint? _campDuelPoint2;

		private IExtension extensionObject;
	}
}
