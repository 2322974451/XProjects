using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetUnitAppearanceRes")]
	[Serializable]
	public class GetUnitAppearanceRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "UnitAppearance", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public UnitAppearance UnitAppearance
		{
			get
			{
				return this._UnitAppearance;
			}
			set
			{
				this._UnitAppearance = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private UnitAppearance _UnitAppearance = null;

		private ErrorCode? _errorcode;

		private IExtension extensionObject;
	}
}
