using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SurviveReqArg")]
	[Serializable]
	public class SurviveReqArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
