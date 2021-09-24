using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleStateNtf")]
	[Serializable]
	public class RoleStateNtf : IExtensible
	{

		[ProtoMember(1, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		[ProtoMember(2, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public List<uint> state
		{
			get
			{
				return this._state;
			}
		}

		[ProtoMember(3, Name = "timelastlogin", DataFormat = DataFormat.TwosComplement)]
		public List<uint> timelastlogin
		{
			get
			{
				return this._timelastlogin;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ulong> _roleid = new List<ulong>();

		private readonly List<uint> _state = new List<uint>();

		private readonly List<uint> _timelastlogin = new List<uint>();

		private IExtension extensionObject;
	}
}
