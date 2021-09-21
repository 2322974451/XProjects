using System;
using KKSG;
using UILib;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016F6 RID: 5878
	internal class CrossGVGDuelHandler : GVGDuelHandlerBase
	{
		// Token: 0x17003765 RID: 14181
		// (get) Token: 0x0600F27F RID: 62079 RVA: 0x0035CA64 File Offset: 0x0035AC64
		protected override string FileName
		{
			get
			{
				return "Guild/CrossGVG/CrossGVGDuelFrame";
			}
		}

		// Token: 0x0600F280 RID: 62080 RVA: 0x0035CA7B File Offset: 0x0035AC7B
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			this.m_DuelHelp.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("CrossGVG_duel_message")));
		}

		// Token: 0x0600F281 RID: 62081 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600F282 RID: 62082 RVA: 0x0035CAB8 File Offset: 0x0035ACB8
		protected override int GetDuelInfoSize()
		{
			return this._doc.GVGDuels.Count;
		}

		// Token: 0x0600F283 RID: 62083 RVA: 0x0035CADA File Offset: 0x0035ACDA
		public override void RefreshData()
		{
			base.RefreshData();
			base.ShowOrHide(!this._doc.HasDuelCombat);
		}

		// Token: 0x0600F284 RID: 62084 RVA: 0x0035CAFC File Offset: 0x0035ACFC
		protected override GVGDuelCombatInfo GetDuelInfo(int index)
		{
			return this._doc.GVGDuels[index];
		}

		// Token: 0x0600F285 RID: 62085 RVA: 0x0035CB1F File Offset: 0x0035AD1F
		protected override void OnEnterScene(IXUISprite sprite)
		{
			this._doc.SendCrossGVGOper(CrossGvgOperType.CGOT_EnterPointRace, 0UL);
		}

		// Token: 0x040067EE RID: 26606
		private XCrossGVGDocument _doc;
	}
}
