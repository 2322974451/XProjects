using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMyMentorInfoArg")]
	[Serializable]
	public class GetMyMentorInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
