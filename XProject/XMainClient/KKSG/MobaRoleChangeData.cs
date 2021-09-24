using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MobaRoleChangeData")]
	[Serializable]
	public class MobaRoleChangeData : IExtensible
	{

		[ProtoMember(1, Name = "changeRole", DataFormat = DataFormat.Default)]
		public List<MobaRoleData> changeRole
		{
			get
			{
				return this._changeRole;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<MobaRoleData> _changeRole = new List<MobaRoleData>();

		private IExtension extensionObject;
	}
}
