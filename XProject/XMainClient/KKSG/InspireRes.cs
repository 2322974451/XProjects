using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "InspireRes")]
	[Serializable]
	public class InspireRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		private void Resetcount()
		{
			this.countSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "cooldowntime", DataFormat = DataFormat.TwosComplement)]
		public uint cooldowntime
		{
			get
			{
				return this._cooldowntime ?? 0U;
			}
			set
			{
				this._cooldowntime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cooldowntimeSpecified
		{
			get
			{
				return this._cooldowntime != null;
			}
			set
			{
				bool flag = value == (this._cooldowntime == null);
				if (flag)
				{
					this._cooldowntime = (value ? new uint?(this.cooldowntime) : null);
				}
			}
		}

		private bool ShouldSerializecooldowntime()
		{
			return this.cooldowntimeSpecified;
		}

		private void Resetcooldowntime()
		{
			this.cooldowntimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _ErrorCode;

		private uint? _count;

		private uint? _cooldowntime;

		private IExtension extensionObject;
	}
}
