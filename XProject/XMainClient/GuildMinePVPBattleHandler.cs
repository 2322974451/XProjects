using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class GuildMinePVPBattleHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XGuildMineBattleDocument>(XGuildMineBattleDocument.uuID);
			this.doc.BattleHandler = this;
			this.m_Info = base.transform.FindChild("Bg/Info");
			this.m_BlueScore = (base.transform.FindChild("Bg/Info/Blue/Score").GetComponent("XUILabel") as IXUILabel);
			this.m_RedScore = (base.transform.FindChild("Bg/Info/Red/Score").GetComponent("XUILabel") as IXUILabel);
			this.m_BlueDamage = (base.transform.FindChild("Bg/Info/Blue/Damage").GetComponent("XUILabel") as IXUILabel);
			this.m_RedDamage = (base.transform.FindChild("Bg/Info/Red/Damage").GetComponent("XUILabel") as IXUILabel);
			this.m_RestTip = (base.transform.FindChild("Bg/start").GetComponent("XUILabel") as IXUILabel);
			this.m_TimeLabel = (base.transform.FindChild("Bg/Time").GetComponent("XUILabel") as IXUILabel);
		}

		protected override string FileName
		{
			get
			{
				return "Battle/SkyArenaBattle";
			}
		}

		public override void RegisterEvent()
		{
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshInfo();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			this.doc.BattleHandler = null;
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		private void RefreshInfo()
		{
			this.m_BlueScore.SetText("0");
			this.m_RedScore.SetText("0");
			this.m_BlueDamage.SetText("0");
			this.m_RedDamage.SetText("0");
			DlgBase<BattleMain, BattleMainBehaviour>.singleton.HideLeftTime();
			this.m_RestTip.gameObject.SetActive(false);
			this.m_TimeLabel.gameObject.SetActive(false);
		}

		public void SetScore(uint score, bool isBlue)
		{
			if (isBlue)
			{
				this.m_BlueScore.SetText(score.ToString());
			}
			else
			{
				this.m_RedScore.SetText(score.ToString());
			}
		}

		public void SetDamage(ulong damage, bool isBlue)
		{
			if (isBlue)
			{
				this.m_BlueDamage.SetText(damage.ToString());
			}
			else
			{
				this.m_RedDamage.SetText(damage.ToString());
			}
		}

		public void RefreshStatusTime(uint time)
		{
			DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime(time, -1);
		}

		private XGuildMineBattleDocument doc = null;

		private Transform m_Info;

		private IXUILabel m_BlueScore;

		private IXUILabel m_RedScore;

		private IXUILabel m_BlueDamage;

		private IXUILabel m_RedDamage;

		private IXUILabel m_TimeLabel;

		private IXUILabel m_RestTip;
	}
}
