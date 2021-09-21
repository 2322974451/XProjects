using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C17 RID: 3095
	internal class GuildMinePVPBattleHandler : DlgHandlerBase
	{
		// Token: 0x0600AFBB RID: 44987 RVA: 0x00215F58 File Offset: 0x00214158
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

		// Token: 0x170030FD RID: 12541
		// (get) Token: 0x0600AFBC RID: 44988 RVA: 0x00216080 File Offset: 0x00214280
		protected override string FileName
		{
			get
			{
				return "Battle/SkyArenaBattle";
			}
		}

		// Token: 0x0600AFBD RID: 44989 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void RegisterEvent()
		{
		}

		// Token: 0x0600AFBE RID: 44990 RVA: 0x00216097 File Offset: 0x00214297
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshInfo();
		}

		// Token: 0x0600AFBF RID: 44991 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600AFC0 RID: 44992 RVA: 0x002160A8 File Offset: 0x002142A8
		public override void OnUnload()
		{
			this.doc.BattleHandler = null;
			base.OnUnload();
		}

		// Token: 0x0600AFC1 RID: 44993 RVA: 0x001E669E File Offset: 0x001E489E
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x0600AFC2 RID: 44994 RVA: 0x002160C0 File Offset: 0x002142C0
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

		// Token: 0x0600AFC3 RID: 44995 RVA: 0x00216144 File Offset: 0x00214344
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

		// Token: 0x0600AFC4 RID: 44996 RVA: 0x00216184 File Offset: 0x00214384
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

		// Token: 0x0600AFC5 RID: 44997 RVA: 0x002161C3 File Offset: 0x002143C3
		public void RefreshStatusTime(uint time)
		{
			DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime(time, -1);
		}

		// Token: 0x0400430C RID: 17164
		private XGuildMineBattleDocument doc = null;

		// Token: 0x0400430D RID: 17165
		private Transform m_Info;

		// Token: 0x0400430E RID: 17166
		private IXUILabel m_BlueScore;

		// Token: 0x0400430F RID: 17167
		private IXUILabel m_RedScore;

		// Token: 0x04004310 RID: 17168
		private IXUILabel m_BlueDamage;

		// Token: 0x04004311 RID: 17169
		private IXUILabel m_RedDamage;

		// Token: 0x04004312 RID: 17170
		private IXUILabel m_TimeLabel;

		// Token: 0x04004313 RID: 17171
		private IXUILabel m_RestTip;
	}
}
