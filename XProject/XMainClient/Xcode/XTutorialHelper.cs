using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTutorialHelper : XSingleton<XTutorialHelper>
	{

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

		public void NextCmdClear()
		{
			XSingleton<XTutorialHelper>.singleton.BattleNPCTalkEnd = false;
		}

		public override void Uninit()
		{
			this._newOpenedSystem.Clear();
		}

		public void AddNewOpenSystem(uint sysID)
		{
			this._newOpenedSystem.Add(sysID);
		}

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

		public static Vector2 BaseScreenPos2Real(Vector2 basePos)
		{
			float num = basePos.x / (float)XSingleton<XGameUI>.singleton.Base_UI_Width * (float)Screen.width;
			float num2 = basePos.y / (float)XSingleton<XGameUI>.singleton.Base_UI_Height * (float)Screen.height;
			return new Vector2(num, num2);
		}

		protected List<uint> _newOpenedSystem;

		public bool SkillLevelup;

		public bool SkillBind;

		public bool UseItem;

		public bool GetReward;

		public bool Moved;

		public bool ArtSkillOver;

		public bool MeetEnemy;

		public bool HasBoss;

		public bool HasTarget;

		public bool FashionCompose;

		public bool ReinforceItem;

		public bool EnhanceItem;

		public bool SwitchProf;

		public bool Smelting;

		public bool DragonCrusadeOpen;

		public bool HasTeam;

		public bool HitDownOnGround;

		public bool SelectView;

		public bool SelectSkipTutorial;

		public bool ActivityOpen;

		public bool BattleNPCTalkEnd;
	}
}
