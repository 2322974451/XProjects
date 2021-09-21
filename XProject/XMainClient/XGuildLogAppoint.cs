using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D2B RID: 3371
	internal class XGuildLogAppoint : XGuildLogBase
	{
		// Token: 0x0600BB38 RID: 47928 RVA: 0x0026718C File Offset: 0x0026538C
		public XGuildLogAppoint()
		{
			this.eType = GuildLogType.GLT_APPOINT;
		}

		// Token: 0x0600BB39 RID: 47929 RVA: 0x002671A0 File Offset: 0x002653A0
		public override string GetContent()
		{
			return XLabelSymbolHelper.FormatName(this.name, this.uid, "00ffff") + XStringDefineProxy.GetString("GUILD_LOG_APPOINT") + XGuildDocument.GuildPP.GetPositionName(this.position, true);
		}

		// Token: 0x0600BB3A RID: 47930 RVA: 0x002671E8 File Offset: 0x002653E8
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XGuildLogAppoint>.Recycle(this);
		}

		// Token: 0x0600BB3B RID: 47931 RVA: 0x002671F9 File Offset: 0x002653F9
		public override void SetData(GHisRecord data)
		{
			base.SetData(data);
			this.position = (GuildPosition)data.position;
		}

		// Token: 0x04004BB5 RID: 19381
		private GuildPosition position;
	}
}
