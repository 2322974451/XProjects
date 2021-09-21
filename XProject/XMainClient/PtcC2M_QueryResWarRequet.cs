using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001389 RID: 5001
	internal class PtcC2M_QueryResWarRequet : Protocol
	{
		// Token: 0x0600E319 RID: 58137 RVA: 0x00339EF8 File Offset: 0x003380F8
		public override uint GetProtoType()
		{
			return 53580U;
		}

		// Token: 0x0600E31A RID: 58138 RVA: 0x00339F0F File Offset: 0x0033810F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryResWarArg>(stream, this.Data);
		}

		// Token: 0x0600E31B RID: 58139 RVA: 0x00339F1F File Offset: 0x0033811F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QueryResWarArg>(stream);
		}

		// Token: 0x0600E31C RID: 58140 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040063DD RID: 25565
		public QueryResWarArg Data = new QueryResWarArg();
	}
}
