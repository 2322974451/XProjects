using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010AA RID: 4266
	internal class PtcG2C_TeamSelectNotify : Protocol
	{
		// Token: 0x0600D766 RID: 55142 RVA: 0x00327E34 File Offset: 0x00326034
		public override uint GetProtoType()
		{
			return 25174U;
		}

		// Token: 0x0600D767 RID: 55143 RVA: 0x00327E4B File Offset: 0x0032604B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamSelect>(stream, this.Data);
		}

		// Token: 0x0600D768 RID: 55144 RVA: 0x00327E5B File Offset: 0x0032605B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeamSelect>(stream);
		}

		// Token: 0x0600D769 RID: 55145 RVA: 0x00327E6A File Offset: 0x0032606A
		public override void Process()
		{
			Process_PtcG2C_TeamSelectNotify.Process(this);
		}

		// Token: 0x040061A6 RID: 24998
		public TeamSelect Data = new TeamSelect();
	}
}
