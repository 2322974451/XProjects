using System;
using KKSG;
using UILib;

namespace XMainClient.UI
{
	// Token: 0x020016F5 RID: 5877
	internal class CrossGVGCombatHandler : GVGCombatHandlerBase
	{
		// Token: 0x17003760 RID: 14176
		// (get) Token: 0x0600F275 RID: 62069 RVA: 0x0035C878 File Offset: 0x0035AA78
		protected override string FileName
		{
			get
			{
				return "Guild/CrossGVG/CrossGVGCombatFrame";
			}
		}

		// Token: 0x0600F276 RID: 62070 RVA: 0x0035C890 File Offset: 0x0035AA90
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			this.m_helpLabel.SetText(XStringDefineProxy.GetString("CrossGVG_combat_message"));
			this._SupportLabel = (base.transform.Find("Support").GetComponent("XUILabel") as IXUILabel);
			this._helpSprite = (base.transform.FindChild("Title/Help").GetComponent("XUIButton") as IXUIButton);
			this._helpSprite.SetVisible(false);
			this.m_showRank.SetVisible(false);
		}

		// Token: 0x0600F277 RID: 62071 RVA: 0x0035C930 File Offset: 0x0035AB30
		protected override void SetupOtherInfo()
		{
			this._SupportLabel.SetText(this._doc.ToSupportString());
			this.m_RegistrationCount.SetText(XStringDefineProxy.GetString("GUILD_ARENA_INDEX", new object[]
			{
				this._doc.RegisterationCount
			}));
		}

		// Token: 0x0600F278 RID: 62072 RVA: 0x0035C984 File Offset: 0x0035AB84
		protected override XGVGCombatGroupData GetCombatGroup(uint roomID)
		{
			XGVGCombatGroupData result = null;
			this._doc.TryGetCombatRoom(roomID, out result);
			return result;
		}

		// Token: 0x0600F279 RID: 62073 RVA: 0x0035C9A8 File Offset: 0x0035ABA8
		protected override void EnterScene()
		{
			this._doc.SendCrossGVGOper(CrossGvgOperType.CGOT_EnterKnockout, 0UL);
		}

		// Token: 0x17003761 RID: 14177
		// (get) Token: 0x0600F27A RID: 62074 RVA: 0x0035C9BC File Offset: 0x0035ABBC
		protected override bool InGVGTime
		{
			get
			{
				return this._doc.TimeStep == CrossGvgTimeState.CGVG_Guess || this._doc.TimeStep == CrossGvgTimeState.CGVG_Knockout || this._doc.TimeStep == CrossGvgTimeState.CGVG_SeasonEnd;
			}
		}

		// Token: 0x17003762 RID: 14178
		// (get) Token: 0x0600F27B RID: 62075 RVA: 0x0035C9FC File Offset: 0x0035ABFC
		protected override CrossGvgRoomState RoomState
		{
			get
			{
				return this._doc.RoomState;
			}
		}

		// Token: 0x17003763 RID: 14179
		// (get) Token: 0x0600F27C RID: 62076 RVA: 0x0035CA1C File Offset: 0x0035AC1C
		protected override bool VisibelEnterBattle
		{
			get
			{
				return this._doc.VisibleEnterBattle;
			}
		}

		// Token: 0x17003764 RID: 14180
		// (get) Token: 0x0600F27D RID: 62077 RVA: 0x0035CA3C File Offset: 0x0035AC3C
		protected override bool HasGVGJion
		{
			get
			{
				return this._doc.HasAvailableJoin;
			}
		}

		// Token: 0x040067EB RID: 26603
		private XCrossGVGDocument _doc;

		// Token: 0x040067EC RID: 26604
		private IXUILabel _SupportLabel;

		// Token: 0x040067ED RID: 26605
		private IXUIButton _helpSprite;
	}
}
