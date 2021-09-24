using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GardenOverviewArg")]
	[Serializable]
	public class GardenOverviewArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
