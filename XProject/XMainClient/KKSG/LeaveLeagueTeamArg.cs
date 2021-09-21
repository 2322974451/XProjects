using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200037A RID: 890
	[ProtoContract(Name = "LeaveLeagueTeamArg")]
	[Serializable]
	public class LeaveLeagueTeamArg : IExtensible
	{
		// Token: 0x06003092 RID: 12434 RVA: 0x0005DB14 File Offset: 0x0005BD14
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C0C RID: 3084
		private IExtension extensionObject;
	}
}
