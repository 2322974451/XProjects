using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200108B RID: 4235
	internal class RpcC2G_OpenSceneChest : Rpc
	{
		// Token: 0x0600D6EE RID: 55022 RVA: 0x00326F00 File Offset: 0x00325100
		public override uint GetRpcType()
		{
			return 27401U;
		}

		// Token: 0x0600D6EF RID: 55023 RVA: 0x00326F17 File Offset: 0x00325117
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OpenSceneChestArg>(stream, this.oArg);
		}

		// Token: 0x0600D6F0 RID: 55024 RVA: 0x00326F27 File Offset: 0x00325127
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<OpenSceneChestRes>(stream);
		}

		// Token: 0x0600D6F1 RID: 55025 RVA: 0x00326F36 File Offset: 0x00325136
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_OpenSceneChest.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D6F2 RID: 55026 RVA: 0x00326F52 File Offset: 0x00325152
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_OpenSceneChest.OnTimeout(this.oArg);
		}

		// Token: 0x04006191 RID: 24977
		public OpenSceneChestArg oArg = new OpenSceneChestArg();

		// Token: 0x04006192 RID: 24978
		public OpenSceneChestRes oRes = new OpenSceneChestRes();
	}
}
