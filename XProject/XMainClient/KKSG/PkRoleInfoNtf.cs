using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkRoleInfoNtf")]
	[Serializable]
	public class PkRoleInfoNtf : IExtensible
	{

		[ProtoMember(1, Name = "pkroleinfo", DataFormat = DataFormat.Default)]
		public List<PkRoleInfo> pkroleinfo
		{
			get
			{
				return this._pkroleinfo;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<PkRoleInfo> _pkroleinfo = new List<PkRoleInfo>();

		private IExtension extensionObject;
	}
}
