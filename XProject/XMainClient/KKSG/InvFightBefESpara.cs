using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "InvFightBefESpara")]
	[Serializable]
	public class InvFightBefESpara : IExtensible
	{

		[ProtoMember(1, Name = "roles", DataFormat = DataFormat.Default)]
		public List<RoleSmallInfo> roles
		{
			get
			{
				return this._roles;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<RoleSmallInfo> _roles = new List<RoleSmallInfo>();

		private IExtension extensionObject;
	}
}
