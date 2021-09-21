using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001259 RID: 4697
	internal class PtcG2C_PlayDiceNtf : Protocol
	{
		// Token: 0x0600DE3A RID: 56890 RVA: 0x00332FC0 File Offset: 0x003311C0
		public override uint GetProtoType()
		{
			return 50453U;
		}

		// Token: 0x0600DE3B RID: 56891 RVA: 0x00332FD7 File Offset: 0x003311D7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PlayDiceNtfData>(stream, this.Data);
		}

		// Token: 0x0600DE3C RID: 56892 RVA: 0x00332FE7 File Offset: 0x003311E7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PlayDiceNtfData>(stream);
		}

		// Token: 0x0600DE3D RID: 56893 RVA: 0x00332FF6 File Offset: 0x003311F6
		public override void Process()
		{
			Process_PtcG2C_PlayDiceNtf.Process(this);
		}

		// Token: 0x040062EC RID: 25324
		public PlayDiceNtfData Data = new PlayDiceNtfData();
	}
}
