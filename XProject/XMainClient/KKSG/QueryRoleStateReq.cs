using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryRoleStateReq")]
	[Serializable]
	public class QueryRoleStateReq : IExtensible
	{

		[ProtoMember(1, Name = "roleids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleids
		{
			get
			{
				return this._roleids;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ulong> _roleids = new List<ulong>();

		private IExtension extensionObject;
	}
}
