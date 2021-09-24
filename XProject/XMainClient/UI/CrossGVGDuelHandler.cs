using System;
using KKSG;
using UILib;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class CrossGVGDuelHandler : GVGDuelHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Guild/CrossGVG/CrossGVGDuelFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			this.m_DuelHelp.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("CrossGVG_duel_message")));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		protected override int GetDuelInfoSize()
		{
			return this._doc.GVGDuels.Count;
		}

		public override void RefreshData()
		{
			base.RefreshData();
			base.ShowOrHide(!this._doc.HasDuelCombat);
		}

		protected override GVGDuelCombatInfo GetDuelInfo(int index)
		{
			return this._doc.GVGDuels[index];
		}

		protected override void OnEnterScene(IXUISprite sprite)
		{
			this._doc.SendCrossGVGOper(CrossGvgOperType.CGOT_EnterPointRace, 0UL);
		}

		private XCrossGVGDocument _doc;
	}
}
