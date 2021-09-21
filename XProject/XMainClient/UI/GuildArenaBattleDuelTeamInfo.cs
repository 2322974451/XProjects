using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x0200174C RID: 5964
	public class GuildArenaBattleDuelTeamInfo
	{
		// Token: 0x0600F68C RID: 63116 RVA: 0x0037F180 File Offset: 0x0037D380
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

		// Token: 0x0600F68D RID: 63117 RVA: 0x0037F26F File Offset: 0x0037D46F
		public void Set(GVGCombatInfo info)
		{
			this.Set(info.DamageString, info.KillCountString, info.Score);
		}

		// Token: 0x0600F68E RID: 63118 RVA: 0x0037F28B File Offset: 0x0037D48B
		public void Reset()
		{
			this.Set("0", "0", 0);
		}

		// Token: 0x0600F68F RID: 63119 RVA: 0x0037F2A0 File Offset: 0x0037D4A0
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

		// Token: 0x04006B06 RID: 27398
		private Transform transform;

		// Token: 0x04006B07 RID: 27399
		private IXUILabel m_damageLabel;

		// Token: 0x04006B08 RID: 27400
		private IXUILabel m_killLabel;

		// Token: 0x04006B09 RID: 27401
		private List<IXUISprite> m_scoreSprites = new List<IXUISprite>();
	}
}
