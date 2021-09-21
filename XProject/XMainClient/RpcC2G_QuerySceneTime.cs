using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200129B RID: 4763
	internal class RpcC2G_QuerySceneTime : Rpc
	{
		// Token: 0x0600DF4D RID: 57165 RVA: 0x00334640 File Offset: 0x00332840
		public override uint GetRpcType()
		{
			return 39595U;
		}

		// Token: 0x0600DF4E RID: 57166 RVA: 0x00334657 File Offset: 0x00332857
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QuerySceneTimeArg>(stream, this.oArg);
		}

		// Token: 0x0600DF4F RID: 57167 RVA: 0x00334667 File Offset: 0x00332867
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QuerySceneTimeRes>(stream);
		}

		// Token: 0x0600DF50 RID: 57168 RVA: 0x00334676 File Offset: 0x00332876
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QuerySceneTime.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DF51 RID: 57169 RVA: 0x00334692 File Offset: 0x00332892
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QuerySceneTime.OnTimeout(this.oArg);
		}

		// Token: 0x04006322 RID: 25378
		public QuerySceneTimeArg oArg = new QuerySceneTimeArg();

		// Token: 0x04006323 RID: 25379
		public QuerySceneTimeRes oRes = new QuerySceneTimeRes();
	}
}
