using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetLeagueEleInfoArg")]
	[Serializable]
	public class GetLeagueEleInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
