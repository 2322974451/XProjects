using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014CB RID: 5323
	internal class RpcC2M_ModifyMsGuildName : Rpc
	{
		// Token: 0x0600E836 RID: 59446 RVA: 0x00341110 File Offset: 0x0033F310
		public override uint GetRpcType()
		{
			return 21709U;
		}

		// Token: 0x0600E837 RID: 59447 RVA: 0x00341127 File Offset: 0x0033F327
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ModifyArg>(stream, this.oArg);
		}

		// Token: 0x0600E838 RID: 59448 RVA: 0x00341137 File Offset: 0x0033F337
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ModifyRes>(stream);
		}

		// Token: 0x0600E839 RID: 59449 RVA: 0x00341146 File Offset: 0x0033F346
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ModifyMsGuildName.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E83A RID: 59450 RVA: 0x00341162 File Offset: 0x0033F362
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ModifyMsGuildName.OnTimeout(this.oArg);
		}

		// Token: 0x040064D3 RID: 25811
		public ModifyArg oArg = new ModifyArg();

		// Token: 0x040064D4 RID: 25812
		public ModifyRes oRes = null;
	}
}
