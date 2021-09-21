using UILib;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C8E RID: 3214
	internal class AbyssPartyBattleHandler : DlgHandlerBase
	{
		// Token: 0x0600B593 RID: 46483 RVA: 0x0023D7EA File Offset: 0x0023B9EA
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XAbyssPartyDocument>(XAbyssPartyDocument.uuID);
			this.m_Difficulty = (base.transform.Find("Bg/Difficulty/Title").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x17003222 RID: 12834
		// (get) Token: 0x0600B594 RID: 46484 RVA: 0x0023D82C File Offset: 0x0023BA2C
		protected override string FileName
		{
			get
			{
				return "Battle/AbyssPartyBattleBegin";
			}
		}

		// Token: 0x0600B595 RID: 46485 RVA: 0x0023D844 File Offset: 0x0023BA44
		protected override void OnShow()
		{
			base.OnShow();
			AbyssPartyListTable.RowData abyssPartyList = this.doc.GetAbyssPartyList();
			bool flag = abyssPartyList != null;
			if (flag)
			{
				this.m_Difficulty.SetText(abyssPartyList.Name);
			}
		}

		// Token: 0x040046FC RID: 18172
		private XAbyssPartyDocument doc = null;

		// Token: 0x040046FD RID: 18173
		private IXUILabel m_Difficulty;
	}
}
