using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001516 RID: 5398
	internal class PtcM2C_TeamRequestPlatFreind2Client : Protocol
	{
		// Token: 0x0600E971 RID: 59761 RVA: 0x00342BA8 File Offset: 0x00340DA8
		public override uint GetProtoType()
		{
			return 37841U;
		}

		// Token: 0x0600E972 RID: 59762 RVA: 0x00342BBF File Offset: 0x00340DBF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamRequestPlatFreind2ClientData>(stream, this.Data);
		}

		// Token: 0x0600E973 RID: 59763 RVA: 0x00342BCF File Offset: 0x00340DCF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeamRequestPlatFreind2ClientData>(stream);
		}

		// Token: 0x0600E974 RID: 59764 RVA: 0x00342BDE File Offset: 0x00340DDE
		public override void Process()
		{
			Process_PtcM2C_TeamRequestPlatFreind2Client.Process(this);
		}

		// Token: 0x04006512 RID: 25874
		public TeamRequestPlatFreind2ClientData Data = new TeamRequestPlatFreind2ClientData();
	}
}
