using UILib;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AbyssPartyBattleHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XAbyssPartyDocument>(XAbyssPartyDocument.uuID);
			this.m_Difficulty = (base.transform.Find("Bg/Difficulty/Title").GetComponent("XUILabel") as IXUILabel);
		}

		protected override string FileName
		{
			get
			{
				return "Battle/AbyssPartyBattleBegin";
			}
		}

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

		private XAbyssPartyDocument doc = null;

		private IXUILabel m_Difficulty;
	}
}
