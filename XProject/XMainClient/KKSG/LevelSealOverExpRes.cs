using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LevelSealOverExpRes")]
	[Serializable]
	public class LevelSealOverExpRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "m_uStatus", DataFormat = DataFormat.TwosComplement)]
		public uint m_uStatus
		{
			get
			{
				return this._m_uStatus ?? 0U;
			}
			set
			{
				this._m_uStatus = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool m_uStatusSpecified
		{
			get
			{
				return this._m_uStatus != null;
			}
			set
			{
				bool flag = value == (this._m_uStatus == null);
				if (flag)
				{
					this._m_uStatus = (value ? new uint?(this.m_uStatus) : null);
				}
			}
		}

		private bool ShouldSerializem_uStatus()
		{
			return this.m_uStatusSpecified;
		}

		private void Resetm_uStatus()
		{
			this.m_uStatusSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private uint? _m_uStatus;

		private IExtension extensionObject;
	}
}
