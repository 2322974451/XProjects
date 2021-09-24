using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class GuildArenadDuelFinalInfo
	{

		public void Init(Transform t)
		{
			this.m_Portrait = (t.FindChild("Portrait").GetComponent("XUISprite") as IXUISprite);
			this.m_GuildName = (t.FindChild("GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_LoseTransform = t.FindChild("Result/Lose");
			this.m_WinTransform = t.FindChild("Result/Win");
			this.m_WinLabel = (t.FindChild("WinLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_LoseLabel = (t.FindChild("LoseLabel").GetComponent("XUILabel") as IXUILabel);
		}

		public void Set(GVGDuelResult result)
		{
			this.m_GuildName.SetText(result.ToGuildNameString());
			this.m_Portrait.SetSprite(XGuildDocument.GetPortraitName((int)result.Guild.guildicon));
			this.m_LoseTransform.gameObject.SetActive(!result.isWinner);
			this.m_WinTransform.gameObject.SetActive(result.isWinner);
			this.m_WinLabel.SetText(result.Score.ToString());
			this.m_LoseLabel.SetText(string.Empty);
		}

		private IXUISprite m_Portrait;

		private IXUILabel m_GuildName;

		private Transform m_LoseTransform;

		private Transform m_WinTransform;

		private IXUILabel m_WinLabel;

		private IXUILabel m_LoseLabel;
	}
}
