using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200101F RID: 4127
	internal class RpcC2G_ChooseProfession : Rpc
	{
		// Token: 0x0600D523 RID: 54563 RVA: 0x0032318C File Offset: 0x0032138C
		public override uint GetRpcType()
		{
			return 24314U;
		}

		// Token: 0x0600D524 RID: 54564 RVA: 0x003231A3 File Offset: 0x003213A3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChooseProfArg>(stream, this.oArg);
		}

		// Token: 0x0600D525 RID: 54565 RVA: 0x003231B3 File Offset: 0x003213B3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChooseProfRes>(stream);
		}

		// Token: 0x0600D526 RID: 54566 RVA: 0x003231C2 File Offset: 0x003213C2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChooseProfession.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D527 RID: 54567 RVA: 0x003231DE File Offset: 0x003213DE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChooseProfession.OnTimeout(this.oArg);
		}

		// Token: 0x04006112 RID: 24850
		public ChooseProfArg oArg = new ChooseProfArg();

		// Token: 0x04006113 RID: 24851
		public ChooseProfRes oRes = null;
	}
}
