using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LargeRoomRoleParam")]
	[Serializable]
	public class LargeRoomRoleParam : IExtensible
	{

		[ProtoMember(1, Name = "name", DataFormat = DataFormat.Default)]
		public List<string> name
		{
			get
			{
				return this._name;
			}
		}

		[ProtoMember(2, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<string> _name = new List<string>();

		private readonly List<ulong> _roleid = new List<ulong>();

		private IExtension extensionObject;
	}
}
