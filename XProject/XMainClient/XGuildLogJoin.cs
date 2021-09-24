using System;

namespace XMainClient
{

	internal class XGuildLogJoin : XGuildLogBase
	{

		public XGuildLogJoin()
		{
			this.eType = GuildLogType.GLT_JOIN;
		}

		public override string GetContent()
		{
			return XLabelSymbolHelper.FormatName(this.name, this.uid, "00ffff") + XStringDefineProxy.GetString("GUILD_LOG_JOIN");
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XGuildLogJoin>.Recycle(this);
		}
	}
}
