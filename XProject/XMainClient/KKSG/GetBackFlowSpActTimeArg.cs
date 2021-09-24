using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetBackFlowSpActTimeArg")]
	[Serializable]
	public class GetBackFlowSpActTimeArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
