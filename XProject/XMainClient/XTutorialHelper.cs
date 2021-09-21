using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E01 RID: 3585
	internal class XTutorialHelper : XSingleton<XTutorialHelper>
	{
		// Token: 0x0600C17C RID: 49532 RVA: 0x00295EA8 File Offset: 0x002940A8
		public override bool Init()
		{
			this._newOpenedSystem = new List<uint>();
			this.SkillLevelup = false;
			this.SkillBind = false;
			this.UseItem = false;
			this.GetReward = false;
			this.Moved = false;
			this.MeetEnemy = false;
			this.HasTarget = false;
			this.ArtSkillOver = false;
			this.HasBoss = false;
			this.FashionCompose = false;
			this.ReinforceItem = false;
			this.EnhanceItem = false;
			this.SwitchProf = false;
			this.HasTeam = false;
			this.Smelting = false;
			this.ActivityOpen = false;
			this.HitDownOnGround = false;
			this.DragonCrusadeOpen = false;
			this.BattleNPCTalkEnd = false;
			this.SelectView = false;
			this.SelectSkipTutorial = false;
			return true;
		}

		// Token: 0x0600C17D RID: 49533 RVA: 0x00295F59 File Offset: 0x00294159
		public void NextCmdClear()
		{
			XSingleton<XTutorialHelper>.singleton.BattleNPCTalkEnd = false;
		}

		// Token: 0x0600C17E RID: 49534 RVA: 0x00295F67 File Offset: 0x00294167
		public override void Uninit()
		{
			this._newOpenedSystem.Clear();
		}

		// Token: 0x0600C17F RID: 49535 RVA: 0x00295F76 File Offset: 0x00294176
		public void AddNewOpenSystem(uint sysID)
		{
			this._newOpenedSystem.Add(sysID);
		}

		// Token: 0x0600C180 RID: 49536 RVA: 0x00295F88 File Offset: 0x00294188
		public bool IsSysOpend(uint SysID)
		{
			for (int i = 0; i < this._newOpenedSystem.Count; i++)
			{
				bool flag = this._newOpenedSystem[i] == SysID;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600C181 RID: 49537 RVA: 0x00295FD0 File Offset: 0x002941D0
		public static Vector2 BaseScreenPos2Real(Vector2 basePos)
		{
			float num = basePos.x / (float)XSingleton<XGameUI>.singleton.Base_UI_Width * (float)Screen.width;
			float num2 = basePos.y / (float)XSingleton<XGameUI>.singleton.Base_UI_Height * (float)Screen.height;
			return new Vector2(num, num2);
		}

		// Token: 0x040051FF RID: 20991
		protected List<uint> _newOpenedSystem;

		// Token: 0x04005200 RID: 20992
		public bool SkillLevelup;

		// Token: 0x04005201 RID: 20993
		public bool SkillBind;

		// Token: 0x04005202 RID: 20994
		public bool UseItem;

		// Token: 0x04005203 RID: 20995
		public bool GetReward;

		// Token: 0x04005204 RID: 20996
		public bool Moved;

		// Token: 0x04005205 RID: 20997
		public bool ArtSkillOver;

		// Token: 0x04005206 RID: 20998
		public bool MeetEnemy;

		// Token: 0x04005207 RID: 20999
		public bool HasBoss;

		// Token: 0x04005208 RID: 21000
		public bool HasTarget;

		// Token: 0x04005209 RID: 21001
		public bool FashionCompose;

		// Token: 0x0400520A RID: 21002
		public bool ReinforceItem;

		// Token: 0x0400520B RID: 21003
		public bool EnhanceItem;

		// Token: 0x0400520C RID: 21004
		public bool SwitchProf;

		// Token: 0x0400520D RID: 21005
		public bool Smelting;

		// Token: 0x0400520E RID: 21006
		public bool DragonCrusadeOpen;

		// Token: 0x0400520F RID: 21007
		public bool HasTeam;

		// Token: 0x04005210 RID: 21008
		public bool HitDownOnGround;

		// Token: 0x04005211 RID: 21009
		public bool SelectView;

		// Token: 0x04005212 RID: 21010
		public bool SelectSkipTutorial;

		// Token: 0x04005213 RID: 21011
		public bool ActivityOpen;

		// Token: 0x04005214 RID: 21012
		public bool BattleNPCTalkEnd;
	}
}
