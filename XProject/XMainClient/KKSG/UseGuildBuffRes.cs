using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UseGuildBuffRes")]
	[Serializable]
	public class UseGuildBuffRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "cd", DataFormat = DataFormat.TwosComplement)]
		public uint cd
		{
			get
			{
				return this._cd ?? 0U;
			}
			set
			{
				this._cd = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cdSpecified
		{
			get
			{
				return this._cd != null;
			}
			set
			{
				bool flag = value == (this._cd == null);
				if (flag)
				{
					this._cd = (value ? new uint?(this.cd) : null);
				}
			}
		}

		private bool ShouldSerializecd()
		{
			return this.cdSpecified;
		}

		private void Resetcd()
		{
			this.cdSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private uint? _cd;

		private IExtension extensionObject;
	}
}
