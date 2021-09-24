using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SendFlowerRes")]
	[Serializable]
	public class SendFlowerRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "fatigue", DataFormat = DataFormat.TwosComplement)]
		public uint fatigue
		{
			get
			{
				return this._fatigue ?? 0U;
			}
			set
			{
				this._fatigue = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fatigueSpecified
		{
			get
			{
				return this._fatigue != null;
			}
			set
			{
				bool flag = value == (this._fatigue == null);
				if (flag)
				{
					this._fatigue = (value ? new uint?(this.fatigue) : null);
				}
			}
		}

		private bool ShouldSerializefatigue()
		{
			return this.fatigueSpecified;
		}

		private void Resetfatigue()
		{
			this.fatigueSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private uint? _fatigue;

		private IExtension extensionObject;
	}
}
