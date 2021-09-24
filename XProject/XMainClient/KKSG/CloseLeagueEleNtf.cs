using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CloseLeagueEleNtf")]
	[Serializable]
	public class CloseLeagueEleNtf : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
