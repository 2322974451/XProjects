using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013A1 RID: 5025
	internal class RpcC2M_DelGuildInherit : Rpc
	{
		// Token: 0x0600E380 RID: 58240 RVA: 0x0033A750 File Offset: 0x00338950
		public override uint GetRpcType()
		{
			return 3671U;
		}

		// Token: 0x0600E381 RID: 58241 RVA: 0x0033A767 File Offset: 0x00338967
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DelGuildInheritArg>(stream, this.oArg);
		}

		// Token: 0x0600E382 RID: 58242 RVA: 0x0033A777 File Offset: 0x00338977
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DelGuildInheritRes>(stream);
		}

		// Token: 0x0600E383 RID: 58243 RVA: 0x0033A786 File Offset: 0x00338986
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DelGuildInherit.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E384 RID: 58244 RVA: 0x0033A7A2 File Offset: 0x003389A2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DelGuildInherit.OnTimeout(this.oArg);
		}

		// Token: 0x040063F2 RID: 25586
		public DelGuildInheritArg oArg = new DelGuildInheritArg();

		// Token: 0x040063F3 RID: 25587
		public DelGuildInheritRes oRes = null;
	}
}
