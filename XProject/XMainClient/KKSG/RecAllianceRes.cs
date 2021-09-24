using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RecAllianceRes")]
	[Serializable]
	public class RecAllianceRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "allianceId", DataFormat = DataFormat.TwosComplement)]
		public ulong allianceId
		{
			get
			{
				return this._allianceId ?? 0UL;
			}
			set
			{
				this._allianceId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool allianceIdSpecified
		{
			get
			{
				return this._allianceId != null;
			}
			set
			{
				bool flag = value == (this._allianceId == null);
				if (flag)
				{
					this._allianceId = (value ? new ulong?(this.allianceId) : null);
				}
			}
		}

		private bool ShouldSerializeallianceId()
		{
			return this.allianceIdSpecified;
		}

		private void ResetallianceId()
		{
			this.allianceIdSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private ulong? _allianceId;

		private IExtension extensionObject;
	}
}
