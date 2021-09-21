using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010E6 RID: 4326
	internal class PtcC2G_AutoFightNTF : Protocol
	{
		// Token: 0x0600D850 RID: 55376 RVA: 0x003295F4 File Offset: 0x003277F4
		public override uint GetProtoType()
		{
			return 25699U;
		}

		// Token: 0x0600D851 RID: 55377 RVA: 0x0032960B File Offset: 0x0032780B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AutoFight>(stream, this.Data);
		}

		// Token: 0x0600D852 RID: 55378 RVA: 0x0032961B File Offset: 0x0032781B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AutoFight>(stream);
		}

		// Token: 0x0600D853 RID: 55379 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040061CD RID: 25037
		public AutoFight Data = new AutoFight();
	}
}
