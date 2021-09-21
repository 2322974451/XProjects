using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x02001747 RID: 5959
	internal class GuildArenadDuelFinalInfo
	{
		// Token: 0x0600F66E RID: 63086 RVA: 0x0037E698 File Offset: 0x0037C898
		public void Init(Transform t)
		{
			this.m_Portrait = (t.FindChild("Portrait").GetComponent("XUISprite") as IXUISprite);
			this.m_GuildName = (t.FindChild("GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_LoseTransform = t.FindChild("Result/Lose");
			this.m_WinTransform = t.FindChild("Result/Win");
			this.m_WinLabel = (t.FindChild("WinLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_LoseLabel = (t.FindChild("LoseLabel").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600F66F RID: 63087 RVA: 0x0037E748 File Offset: 0x0037C948
		public void Set(GVGDuelResult result)
		{
			this.m_GuildName.SetText(result.ToGuildNameString());
			this.m_Portrait.SetSprite(XGuildDocument.GetPortraitName((int)result.Guild.guildicon));
			this.m_LoseTransform.gameObject.SetActive(!result.isWinner);
			this.m_WinTransform.gameObject.SetActive(result.isWinner);
			this.m_WinLabel.SetText(result.Score.ToString());
			this.m_LoseLabel.SetText(string.Empty);
		}

		// Token: 0x04006AE8 RID: 27368
		private IXUISprite m_Portrait;

		// Token: 0x04006AE9 RID: 27369
		private IXUILabel m_GuildName;

		// Token: 0x04006AEA RID: 27370
		private Transform m_LoseTransform;

		// Token: 0x04006AEB RID: 27371
		private Transform m_WinTransform;

		// Token: 0x04006AEC RID: 27372
		private IXUILabel m_WinLabel;

		// Token: 0x04006AED RID: 27373
		private IXUILabel m_LoseLabel;
	}
}
