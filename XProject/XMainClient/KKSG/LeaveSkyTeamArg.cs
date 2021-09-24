using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeaveSkyTeamArg")]
	[Serializable]
	public class LeaveSkyTeamArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
