using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	public class GuildArenaBattleDuelTeamInfo
	{

		public void Init(Transform t)
		{
			this.transform = t;
			this.m_damageLabel = (this.transform.FindChild("Damage").GetComponent("XUILabel") as IXUILabel);
			this.m_killLabel = (this.transform.FindChild("Kill").GetComponent("XUILabel") as IXUILabel);
			string format = "Score/Score{0}/Win";
			string format2 = "Score/Score{0}/Lose";
			for (int i = 1; i < 4; i++)
			{
				IXUISprite item = this.transform.FindChild(string.Format(format, i)).GetComponent("XUISprite") as IXUISprite;
				this.m_scoreSprites.Add(item);
				IXUISprite ixuisprite = this.transform.FindChild(string.Format(format2, i)).GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetAlpha(0f);
			}
			this.Reset();
		}

		public void Set(GVGCombatInfo info)
		{
			this.Set(info.DamageString, info.KillCountString, info.Score);
		}

		public void Reset()
		{
			this.Set("0", "0", 0);
		}

		private void Set(string damage, string kill, int score)
		{
			this.m_damageLabel.SetText(damage);
			this.m_killLabel.SetText(kill);
			int i = 0;
			int count = this.m_scoreSprites.Count;
			while (i < count)
			{
				this.m_scoreSprites[i].SetAlpha((score > i) ? 1f : 0f);
				i++;
			}
		}

		private Transform transform;

		private IXUILabel m_damageLabel;

		private IXUILabel m_killLabel;

		private List<IXUISprite> m_scoreSprites = new List<IXUISprite>();
	}
}
