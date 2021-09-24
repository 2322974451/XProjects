using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DailyTaskAskHelpRes")]
	[Serializable]
	public class DailyTaskAskHelpRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "code", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode code
		{
			get
			{
				return this._code ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._code = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool codeSpecified
		{
			get
			{
				return this._code != null;
			}
			set
			{
				bool flag = value == (this._code == null);
				if (flag)
				{
					this._code = (value ? new ErrorCode?(this.code) : null);
				}
			}
		}

		private bool ShouldSerializecode()
		{
			return this.codeSpecified;
		}

		private void Resetcode()
		{
			this.codeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "ask_uid", DataFormat = DataFormat.TwosComplement)]
		public uint ask_uid
		{
			get
			{
				return this._ask_uid ?? 0U;
			}
			set
			{
				this._ask_uid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ask_uidSpecified
		{
			get
			{
				return this._ask_uid != null;
			}
			set
			{
				bool flag = value == (this._ask_uid == null);
				if (flag)
				{
					this._ask_uid = (value ? new uint?(this.ask_uid) : null);
				}
			}
		}

		private bool ShouldSerializeask_uid()
		{
			return this.ask_uidSpecified;
		}

		private void Resetask_uid()
		{
			this.ask_uidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _code;

		private uint? _ask_uid;

		private IExtension extensionObject;
	}
}
