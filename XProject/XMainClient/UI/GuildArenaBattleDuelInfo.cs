using System;
using UnityEngine;

namespace XMainClient.UI
{

	public class GuildArenaBattleDuelInfo
	{

		public void Init(Transform t)
		{
			this.transfrom = t;
			this.BlueInfo = new GuildArenaBattleDuelTeamInfo();
			this.BlueInfo.Init(this.transfrom.FindChild("Blue"));
			this.RedInfo = new GuildArenaBattleDuelTeamInfo();
			this.RedInfo.Init(this.transfrom.FindChild("Red"));
		}

		public void SetVisible(bool active)
		{
			this.transfrom.gameObject.SetActive(active);
		}

		public void Reset()
		{
			this.BlueInfo.Reset();
			this.RedInfo.Reset();
		}

		public void Destroy()
		{
			this.BlueInfo = null;
			this.RedInfo = null;
		}

		private Transform transfrom;

		public GuildArenaBattleDuelTeamInfo BlueInfo;

		public GuildArenaBattleDuelTeamInfo RedInfo;
	}
}
