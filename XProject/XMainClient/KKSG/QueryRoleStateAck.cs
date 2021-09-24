using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryRoleStateAck")]
	[Serializable]
	public class QueryRoleStateAck : IExtensible
	{

		[ProtoMember(1, Name = "roleids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleids
		{
			get
			{
				return this._roleids;
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ulong> _roleids = new List<ulong>();

		private readonly List<uint> _state = new List<uint>();

		private IExtension extensionObject;
	}
}
