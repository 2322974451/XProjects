using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001243 RID: 4675
	internal class RpcC2G_breakAtlas : Rpc
	{
		// Token: 0x0600DDDD RID: 56797 RVA: 0x003327D4 File Offset: 0x003309D4
		public override uint GetRpcType()
		{
			return 13728U;
		}

		// Token: 0x0600DDDE RID: 56798 RVA: 0x003327EB File Offset: 0x003309EB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<breakAtlas>(stream, this.oArg);
		}

		// Token: 0x0600DDDF RID: 56799 RVA: 0x003327FB File Offset: 0x003309FB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<breakAtlasRes>(stream);
		}

		// Token: 0x0600DDE0 RID: 56800 RVA: 0x0033280A File Offset: 0x00330A0A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_breakAtlas.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DDE1 RID: 56801 RVA: 0x00332826 File Offset: 0x00330A26
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_breakAtlas.OnTimeout(this.oArg);
		}

		// Token: 0x040062D9 RID: 25305
		public breakAtlas oArg = new breakAtlas();

		// Token: 0x040062DA RID: 25306
		public breakAtlasRes oRes = new breakAtlasRes();
	}
}
