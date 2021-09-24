using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CheckQueuingNtf")]
	[Serializable]
	public class CheckQueuingNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "rolecount", DataFormat = DataFormat.TwosComplement)]
		public uint rolecount
		{
			get
			{
				return this._rolecount ?? 0U;
			}
			set
			{
				this._rolecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rolecountSpecified
		{
			get
			{
				return this._rolecount != null;
			}
			set
			{
				bool flag = value == (this._rolecount == null);
				if (flag)
				{
					this._rolecount = (value ? new uint?(this.rolecount) : null);
				}
			}
		}

		private bool ShouldSerializerolecount()
		{
			return this.rolecountSpecified;
		}

		private void Resetrolecount()
		{
			this.rolecountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public uint timeleft
		{
			get
			{
				return this._timeleft ?? 0U;
			}
			set
			{
				this._timeleft = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeleftSpecified
		{
			get
			{
				return this._timeleft != null;
			}
			set
			{
				bool flag = value == (this._timeleft == null);
				if (flag)
				{
					this._timeleft = (value ? new uint?(this.timeleft) : null);
				}
			}
		}

		private bool ShouldSerializetimeleft()
		{
			return this.timeleftSpecified;
		}

		private void Resettimeleft()
		{
			this.timeleftSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		private uint? _rolecount;

		private uint? _timeleft;

		private ErrorCode? _errorcode;

		private IExtension extensionObject;
	}
}
