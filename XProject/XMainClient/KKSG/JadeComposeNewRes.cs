using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "JadeComposeNewRes")]
	[Serializable]
	public class JadeComposeNewRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "jadeSealID", DataFormat = DataFormat.TwosComplement)]
		public uint jadeSealID
		{
			get
			{
				return this._jadeSealID ?? 0U;
			}
			set
			{
				this._jadeSealID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool jadeSealIDSpecified
		{
			get
			{
				return this._jadeSealID != null;
			}
			set
			{
				bool flag = value == (this._jadeSealID == null);
				if (flag)
				{
					this._jadeSealID = (value ? new uint?(this.jadeSealID) : null);
				}
			}
		}

		private bool ShouldSerializejadeSealID()
		{
			return this.jadeSealIDSpecified;
		}

		private void ResetjadeSealID()
		{
			this.jadeSealIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _ErrorCode;

		private uint? _jadeSealID;

		private IExtension extensionObject;
	}
}
