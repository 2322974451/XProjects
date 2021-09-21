using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013C0 RID: 5056
	internal class PtcM2C_GuildBuffCDParamNtf : Protocol
	{
		// Token: 0x0600E3FD RID: 58365 RVA: 0x0033B188 File Offset: 0x00339388
		public override uint GetProtoType()
		{
			return 4703U;
		}

		// Token: 0x0600E3FE RID: 58366 RVA: 0x0033B19F File Offset: 0x0033939F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBuffCDParam>(stream, this.Data);
		}

		// Token: 0x0600E3FF RID: 58367 RVA: 0x0033B1AF File Offset: 0x003393AF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildBuffCDParam>(stream);
		}

		// Token: 0x0600E400 RID: 58368 RVA: 0x0033B1BE File Offset: 0x003393BE
		public override void Process()
		{
			Process_PtcM2C_GuildBuffCDParamNtf.Process(this);
		}

		// Token: 0x04006409 RID: 25609
		public GuildBuffCDParam Data = new GuildBuffCDParam();
	}
}
