using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeekEnd4v4GetInfoRes")]
	[Serializable]
	public class WeekEnd4v4GetInfoRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "thisActivityID", DataFormat = DataFormat.TwosComplement)]
		public uint thisActivityID
		{
			get
			{
				return this._thisActivityID ?? 0U;
			}
			set
			{
				this._thisActivityID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool thisActivityIDSpecified
		{
			get
			{
				return this._thisActivityID != null;
			}
			set
			{
				bool flag = value == (this._thisActivityID == null);
				if (flag)
				{
					this._thisActivityID = (value ? new uint?(this.thisActivityID) : null);
				}
			}
		}

		private bool ShouldSerializethisActivityID()
		{
			return this.thisActivityIDSpecified;
		}

		private void ResetthisActivityID()
		{
			this.thisActivityIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "nextActivityID", DataFormat = DataFormat.TwosComplement)]
		public uint nextActivityID
		{
			get
			{
				return this._nextActivityID ?? 0U;
			}
			set
			{
				this._nextActivityID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nextActivityIDSpecified
		{
			get
			{
				return this._nextActivityID != null;
			}
			set
			{
				bool flag = value == (this._nextActivityID == null);
				if (flag)
				{
					this._nextActivityID = (value ? new uint?(this.nextActivityID) : null);
				}
			}
		}

		private bool ShouldSerializenextActivityID()
		{
			return this.nextActivityIDSpecified;
		}

		private void ResetnextActivityID()
		{
			this.nextActivityIDSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "joinCount", DataFormat = DataFormat.TwosComplement)]
		public uint joinCount
		{
			get
			{
				return this._joinCount ?? 0U;
			}
			set
			{
				this._joinCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool joinCountSpecified
		{
			get
			{
				return this._joinCount != null;
			}
			set
			{
				bool flag = value == (this._joinCount == null);
				if (flag)
				{
					this._joinCount = (value ? new uint?(this.joinCount) : null);
				}
			}
		}

		private bool ShouldSerializejoinCount()
		{
			return this.joinCountSpecified;
		}

		private void ResetjoinCount()
		{
			this.joinCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private uint? _thisActivityID;

		private uint? _nextActivityID;

		private uint? _joinCount;

		private IExtension extensionObject;
	}
}
