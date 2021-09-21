using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014C9 RID: 5321
	internal class RpcC2G_GetPlatformShareChest : Rpc
	{
		// Token: 0x0600E82D RID: 59437 RVA: 0x0034101C File Offset: 0x0033F21C
		public override uint GetRpcType()
		{
			return 7875U;
		}

		// Token: 0x0600E82E RID: 59438 RVA: 0x00341033 File Offset: 0x0033F233
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPlatformShareChestArg>(stream, this.oArg);
		}

		// Token: 0x0600E82F RID: 59439 RVA: 0x00341043 File Offset: 0x0033F243
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPlatformShareChestRes>(stream);
		}

		// Token: 0x0600E830 RID: 59440 RVA: 0x00341052 File Offset: 0x0033F252
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetPlatformShareChest.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E831 RID: 59441 RVA: 0x0034106E File Offset: 0x0033F26E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetPlatformShareChest.OnTimeout(this.oArg);
		}

		// Token: 0x040064D1 RID: 25809
		public GetPlatformShareChestArg oArg = new GetPlatformShareChestArg();

		// Token: 0x040064D2 RID: 25810
		public GetPlatformShareChestRes oRes = null;
	}
}
