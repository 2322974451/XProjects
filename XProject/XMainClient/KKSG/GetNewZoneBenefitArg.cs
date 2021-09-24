using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetNewZoneBenefitArg")]
	[Serializable]
	public class GetNewZoneBenefitArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
