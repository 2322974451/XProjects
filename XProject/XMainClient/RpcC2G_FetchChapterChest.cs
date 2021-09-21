using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001075 RID: 4213
	internal class RpcC2G_FetchChapterChest : Rpc
	{
		// Token: 0x0600D68F RID: 54927 RVA: 0x0032648C File Offset: 0x0032468C
		public override uint GetRpcType()
		{
			return 21099U;
		}

		// Token: 0x0600D690 RID: 54928 RVA: 0x003264A3 File Offset: 0x003246A3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchChapterChestArg>(stream, this.oArg);
		}

		// Token: 0x0600D691 RID: 54929 RVA: 0x003264B3 File Offset: 0x003246B3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchChapterChestRes>(stream);
		}

		// Token: 0x0600D692 RID: 54930 RVA: 0x003264C2 File Offset: 0x003246C2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FetchChapterChest.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D693 RID: 54931 RVA: 0x003264DE File Offset: 0x003246DE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FetchChapterChest.OnTimeout(this.oArg);
		}

		// Token: 0x0400617E RID: 24958
		public FetchChapterChestArg oArg = new FetchChapterChestArg();

		// Token: 0x0400617F RID: 24959
		public FetchChapterChestRes oRes = new FetchChapterChestRes();
	}
}
