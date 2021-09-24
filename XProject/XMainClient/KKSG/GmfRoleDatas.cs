using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GmfRoleDatas")]
	[Serializable]
	public class GmfRoleDatas : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "halfrole11", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfHalfRoles halfrole11
		{
			get
			{
				return this._halfrole11;
			}
			set
			{
				this._halfrole11 = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "halfrole22", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfHalfRoles halfrole22
		{
			get
			{
				return this._halfrole22;
			}
			set
			{
				this._halfrole22 = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GmfHalfRoles _halfrole11 = null;

		private GmfHalfRoles _halfrole22 = null;

		private IExtension extensionObject;
	}
}
