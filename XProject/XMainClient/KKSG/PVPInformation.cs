using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PVPInformation")]
	[Serializable]
	public class PVPInformation : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "pk_info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PKInformation pk_info
		{
			get
			{
				return this._pk_info;
			}
			set
			{
				this._pk_info = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PKInformation _pk_info = null;

		private IExtension extensionObject;
	}
}
