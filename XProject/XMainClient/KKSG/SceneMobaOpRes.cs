using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SceneMobaOpRes")]
	[Serializable]
	public class SceneMobaOpRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "nowparam", DataFormat = DataFormat.TwosComplement)]
		public uint nowparam
		{
			get
			{
				return this._nowparam ?? 0U;
			}
			set
			{
				this._nowparam = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nowparamSpecified
		{
			get
			{
				return this._nowparam != null;
			}
			set
			{
				bool flag = value == (this._nowparam == null);
				if (flag)
				{
					this._nowparam = (value ? new uint?(this.nowparam) : null);
				}
			}
		}

		private bool ShouldSerializenowparam()
		{
			return this.nowparamSpecified;
		}

		private void Resetnowparam()
		{
			this.nowparamSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private uint? _nowparam;

		private IExtension extensionObject;
	}
}
