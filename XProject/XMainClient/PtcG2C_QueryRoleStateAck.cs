using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001457 RID: 5207
	internal class PtcG2C_QueryRoleStateAck : Protocol
	{
		// Token: 0x0600E665 RID: 58981 RVA: 0x0033E658 File Offset: 0x0033C858
		public override uint GetProtoType()
		{
			return 53402U;
		}

		// Token: 0x0600E666 RID: 58982 RVA: 0x0033E66F File Offset: 0x0033C86F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryRoleStateAck>(stream, this.Data);
		}

		// Token: 0x0600E667 RID: 58983 RVA: 0x0033E67F File Offset: 0x0033C87F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QueryRoleStateAck>(stream);
		}

		// Token: 0x0600E668 RID: 58984 RVA: 0x0033E68E File Offset: 0x0033C88E
		public override void Process()
		{
			Process_PtcG2C_QueryRoleStateAck.Process(this);
		}

		// Token: 0x0400647D RID: 25725
		public QueryRoleStateAck Data = new QueryRoleStateAck();
	}
}
