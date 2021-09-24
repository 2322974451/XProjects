using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AllianceGuildTerrRes")]
	[Serializable]
	public class AllianceGuildTerrRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcod", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcod
		{
			get
			{
				return this._errorcod ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcod = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodSpecified
		{
			get
			{
				return this._errorcod != null;
			}
			set
			{
				bool flag = value == (this._errorcod == null);
				if (flag)
				{
					this._errorcod = (value ? new ErrorCode?(this.errorcod) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcod()
		{
			return this.errorcodSpecified;
		}

		private void Reseterrorcod()
		{
			this.errorcodSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcod;

		private IExtension extensionObject;
	}
}
