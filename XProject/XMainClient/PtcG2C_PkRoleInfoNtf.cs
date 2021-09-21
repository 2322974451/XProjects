using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010BA RID: 4282
	internal class PtcG2C_PkRoleInfoNtf : Protocol
	{
		// Token: 0x0600D7A4 RID: 55204 RVA: 0x003286EC File Offset: 0x003268EC
		public override uint GetProtoType()
		{
			return 8937U;
		}

		// Token: 0x0600D7A5 RID: 55205 RVA: 0x00328703 File Offset: 0x00326903
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PkRoleInfoNtf>(stream, this.Data);
		}

		// Token: 0x0600D7A6 RID: 55206 RVA: 0x00328713 File Offset: 0x00326913
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PkRoleInfoNtf>(stream);
		}

		// Token: 0x0600D7A7 RID: 55207 RVA: 0x00328722 File Offset: 0x00326922
		public override void Process()
		{
			Process_PtcG2C_PkRoleInfoNtf.Process(this);
		}

		// Token: 0x040061B0 RID: 25008
		public PkRoleInfoNtf Data = new PkRoleInfoNtf();
	}
}
