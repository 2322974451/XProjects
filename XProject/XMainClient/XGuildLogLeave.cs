using System;

namespace XMainClient
{
	// Token: 0x02000D2A RID: 3370
	internal class XGuildLogLeave : XGuildLogBase
	{
		// Token: 0x0600BB35 RID: 47925 RVA: 0x00267130 File Offset: 0x00265330
		public XGuildLogLeave()
		{
			this.eType = GuildLogType.GLT_LEAVE;
		}

		// Token: 0x0600BB36 RID: 47926 RVA: 0x00267144 File Offset: 0x00265344
		public override string GetContent()
		{
			return XLabelSymbolHelper.FormatName(this.name, this.uid, "00ffff") + XStringDefineProxy.GetString("GUILD_LOG_LEAVE");
		}

		// Token: 0x0600BB37 RID: 47927 RVA: 0x0026717B File Offset: 0x0026537B
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XGuildLogLeave>.Recycle(this);
		}
	}
}
