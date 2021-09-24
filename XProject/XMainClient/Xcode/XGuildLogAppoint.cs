using System;
using KKSG;

namespace XMainClient
{

	internal class XGuildLogAppoint : XGuildLogBase
	{

		public XGuildLogAppoint()
		{
			this.eType = GuildLogType.GLT_APPOINT;
		}

		public override string GetContent()
		{
			return XLabelSymbolHelper.FormatName(this.name, this.uid, "00ffff") + XStringDefineProxy.GetString("GUILD_LOG_APPOINT") + XGuildDocument.GuildPP.GetPositionName(this.position, true);
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XGuildLogAppoint>.Recycle(this);
		}

		public override void SetData(GHisRecord data)
		{
			base.SetData(data);
			this.position = (GuildPosition)data.position;
		}

		private GuildPosition position;
	}
}
