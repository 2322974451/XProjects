using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeaveLeagueTeamArg")]
	[Serializable]
	public class LeaveLeagueTeamArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
