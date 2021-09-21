using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001368 RID: 4968
	internal class RpcC2M_getapplyguildlist : Rpc
	{
		// Token: 0x0600E294 RID: 58004 RVA: 0x0033944C File Offset: 0x0033764C
		public override uint GetRpcType()
		{
			return 31771U;
		}

		// Token: 0x0600E295 RID: 58005 RVA: 0x00339463 File Offset: 0x00337663
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<getapplyguildlistarg>(stream, this.oArg);
		}

		// Token: 0x0600E296 RID: 58006 RVA: 0x00339473 File Offset: 0x00337673
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<getapplyguildlistres>(stream);
		}

		// Token: 0x0600E297 RID: 58007 RVA: 0x00339482 File Offset: 0x00337682
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_getapplyguildlist.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E298 RID: 58008 RVA: 0x0033949E File Offset: 0x0033769E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_getapplyguildlist.OnTimeout(this.oArg);
		}

		// Token: 0x040063C4 RID: 25540
		public getapplyguildlistarg oArg = new getapplyguildlistarg();

		// Token: 0x040063C5 RID: 25541
		public getapplyguildlistres oRes = null;
	}
}
