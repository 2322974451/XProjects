using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XTeamLeagueFinalResultBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.Details = base.transform.Find("Bg2/Details");
			this.EnterMatch = (base.transform.Find("Bg2/BeginMatch").GetComponent("XUIButton") as IXUIButton);
			this.CloseBtn = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.NoChampion = base.transform.Find("Bg2/ChampionFrame/NoChampion");
			this.ChampionMembers = base.transform.Find("Bg2/ChampionFrame/Members");
			this.GuildName = (base.transform.Find("Bg2/ChampionFrame/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.FinalTimeLabel = (base.transform.Find("Schedule").GetComponent("XUILabel") as IXUILabel);
		}

		public Transform Details;

		public IXUIButton EnterMatch;

		public IXUIButton CloseBtn;

		public Transform NoChampion;

		public Transform ChampionMembers;

		public IXUILabel GuildName;

		public IXUILabel FinalTimeLabel;
	}
}
