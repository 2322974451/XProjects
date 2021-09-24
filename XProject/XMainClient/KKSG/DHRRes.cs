using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DHRRes")]
	[Serializable]
	public class DHRRes : IExtensible
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

		[ProtoMember(2, Name = "rewstate", DataFormat = DataFormat.Default)]
		public List<DHRewrad2State> rewstate
		{
			get
			{
				return this._rewstate;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "helpcount", DataFormat = DataFormat.TwosComplement)]
		public uint helpcount
		{
			get
			{
				return this._helpcount ?? 0U;
			}
			set
			{
				this._helpcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool helpcountSpecified
		{
			get
			{
				return this._helpcount != null;
			}
			set
			{
				bool flag = value == (this._helpcount == null);
				if (flag)
				{
					this._helpcount = (value ? new uint?(this.helpcount) : null);
				}
			}
		}

		private bool ShouldSerializehelpcount()
		{
			return this.helpcountSpecified;
		}

		private void Resethelpcount()
		{
			this.helpcountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "wanthelp", DataFormat = DataFormat.Default)]
		public bool wanthelp
		{
			get
			{
				return this._wanthelp ?? false;
			}
			set
			{
				this._wanthelp = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wanthelpSpecified
		{
			get
			{
				return this._wanthelp != null;
			}
			set
			{
				bool flag = value == (this._wanthelp == null);
				if (flag)
				{
					this._wanthelp = (value ? new bool?(this.wanthelp) : null);
				}
			}
		}

		private bool ShouldSerializewanthelp()
		{
			return this.wanthelpSpecified;
		}

		private void Resetwanthelp()
		{
			this.wanthelpSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private readonly List<DHRewrad2State> _rewstate = new List<DHRewrad2State>();

		private uint? _helpcount;

		private bool? _wanthelp;

		private IExtension extensionObject;
	}
}
