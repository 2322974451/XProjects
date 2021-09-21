using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014D9 RID: 5337
	internal class RpcC2M_SkyCraftMatchReq : Rpc
	{
		// Token: 0x0600E870 RID: 59504 RVA: 0x00341500 File Offset: 0x0033F700
		public override uint GetRpcType()
		{
			return 26016U;
		}

		// Token: 0x0600E871 RID: 59505 RVA: 0x00341517 File Offset: 0x0033F717
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCraftMatchReq>(stream, this.oArg);
		}

		// Token: 0x0600E872 RID: 59506 RVA: 0x00341527 File Offset: 0x0033F727
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SkyCraftMatchRes>(stream);
		}

		// Token: 0x0600E873 RID: 59507 RVA: 0x00341536 File Offset: 0x0033F736
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_SkyCraftMatchReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E874 RID: 59508 RVA: 0x00341552 File Offset: 0x0033F752
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_SkyCraftMatchReq.OnTimeout(this.oArg);
		}

		// Token: 0x040064DE RID: 25822
		public SkyCraftMatchReq oArg = new SkyCraftMatchReq();

		// Token: 0x040064DF RID: 25823
		public SkyCraftMatchRes oRes = null;
	}
}
