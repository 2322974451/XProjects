using System;
using KKSG;
using UILib;

namespace XMainClient.UI
{

	internal class CrossGVGCombatHandler : GVGCombatHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Guild/CrossGVG/CrossGVGCombatFrame";
			}
		}

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

		protected override void SetupOtherInfo()
		{
			this._SupportLabel.SetText(this._doc.ToSupportString());
			this.m_RegistrationCount.SetText(XStringDefineProxy.GetString("GUILD_ARENA_INDEX", new object[]
			{
				this._doc.RegisterationCount
			}));
		}

		protected override XGVGCombatGroupData GetCombatGroup(uint roomID)
		{
			XGVGCombatGroupData result = null;
			this._doc.TryGetCombatRoom(roomID, out result);
			return result;
		}

		protected override void EnterScene()
		{
			this._doc.SendCrossGVGOper(CrossGvgOperType.CGOT_EnterKnockout, 0UL);
		}

		protected override bool InGVGTime
		{
			get
			{
				return this._doc.TimeStep == CrossGvgTimeState.CGVG_Guess || this._doc.TimeStep == CrossGvgTimeState.CGVG_Knockout || this._doc.TimeStep == CrossGvgTimeState.CGVG_SeasonEnd;
			}
		}

		protected override CrossGvgRoomState RoomState
		{
			get
			{
				return this._doc.RoomState;
			}
		}

		protected override bool VisibelEnterBattle
		{
			get
			{
				return this._doc.VisibleEnterBattle;
			}
		}

		protected override bool HasGVGJion
		{
			get
			{
				return this._doc.HasAvailableJoin;
			}
		}

		private XCrossGVGDocument _doc;

		private IXUILabel _SupportLabel;

		private IXUIButton _helpSprite;
	}
}
