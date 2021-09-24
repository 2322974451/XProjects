using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetWeeklyTaskInfoArg")]
	[Serializable]
	public class GetWeeklyTaskInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
