using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EmblemLevelUpRes")]
	[Serializable]
	public class EmblemLevelUpRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "islevelup", DataFormat = DataFormat.Default)]
		public bool islevelup
		{
			get
			{
				return this._islevelup ?? false;
			}
			set
			{
				this._islevelup = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool islevelupSpecified
		{
			get
			{
				return this._islevelup != null;
			}
			set
			{
				bool flag = value == (this._islevelup == null);
				if (flag)
				{
					this._islevelup = (value ? new bool?(this.islevelup) : null);
				}
			}
		}

		private bool ShouldSerializeislevelup()
		{
			return this.islevelupSpecified;
		}

		private void Resetislevelup()
		{
			this.islevelupSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _ErrorCode;

		private bool? _islevelup;

		private IExtension extensionObject;
	}
}
