using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001344 RID: 4932
	internal class RpcC2M_OPenGardenFarmland : Rpc
	{
		// Token: 0x0600E205 RID: 57861 RVA: 0x00338740 File Offset: 0x00336940
		public override uint GetRpcType()
		{
			return 42589U;
		}

		// Token: 0x0600E206 RID: 57862 RVA: 0x00338757 File Offset: 0x00336957
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OpenGardenFarmlandArg>(stream, this.oArg);
		}

		// Token: 0x0600E207 RID: 57863 RVA: 0x00338767 File Offset: 0x00336967
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<OpenGardenFarmlandRes>(stream);
		}

		// Token: 0x0600E208 RID: 57864 RVA: 0x00338776 File Offset: 0x00336976
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_OPenGardenFarmland.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E209 RID: 57865 RVA: 0x00338792 File Offset: 0x00336992
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_OPenGardenFarmland.OnTimeout(this.oArg);
		}

		// Token: 0x040063A9 RID: 25513
		public OpenGardenFarmlandArg oArg = new OpenGardenFarmlandArg();

		// Token: 0x040063AA RID: 25514
		public OpenGardenFarmlandRes oRes = null;
	}
}
