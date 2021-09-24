using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetHolidayStageInfoArg")]
	[Serializable]
	public class GetHolidayStageInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
