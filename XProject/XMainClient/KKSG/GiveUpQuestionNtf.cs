using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GiveUpQuestionNtf")]
	[Serializable]
	public class GiveUpQuestionNtf : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
