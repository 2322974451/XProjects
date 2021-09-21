using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011FE RID: 4606
	internal class RpcC2G_SynPetInfo : Rpc
	{
		// Token: 0x0600DCBC RID: 56508 RVA: 0x00330C70 File Offset: 0x0032EE70
		public override uint GetRpcType()
		{
			return 6548U;
		}

		// Token: 0x0600DCBD RID: 56509 RVA: 0x00330C87 File Offset: 0x0032EE87
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynPetInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600DCBE RID: 56510 RVA: 0x00330C97 File Offset: 0x0032EE97
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SynPetInfoRes>(stream);
		}

		// Token: 0x0600DCBF RID: 56511 RVA: 0x00330CA6 File Offset: 0x0032EEA6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SynPetInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DCC0 RID: 56512 RVA: 0x00330CC2 File Offset: 0x0032EEC2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SynPetInfo.OnTimeout(this.oArg);
		}

		// Token: 0x0400629F RID: 25247
		public SynPetInfoArg oArg = new SynPetInfoArg();

		// Token: 0x040062A0 RID: 25248
		public SynPetInfoRes oRes = new SynPetInfoRes();
	}
}
