using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSceneDamageRankDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XSceneDamageRankDocument.uuID;
			}
		}

		public List<XBaseRankInfo> RankList
		{
			get
			{
				return this.m_RankList;
			}
		}

		public override void OnEnterSceneFinally()
		{
			this.m_RankList.Clear();
		}

		public void ReqRank()
		{
			PtcC2G_SceneDamageRankReport proto = new PtcC2G_SceneDamageRankReport();
			XSingleton<XClientNetwork>.singleton.Send(proto);
		}

		public void OnGetRank(SceneDamageRankNtf data)
		{
			bool flag = data.damage.Count != data.name.Count;
			if (!flag)
			{
				int num = data.damage.Count - this.m_RankList.Count;
				for (int i = 0; i < num; i++)
				{
					this.m_RankList.Add(new XBaseRankInfo());
				}
				bool flag2 = num < 0;
				if (flag2)
				{
					this.m_RankList.RemoveRange(this.m_RankList.Count + num, -num);
				}
				for (int j = 0; j < this.m_RankList.Count; j++)
				{
					this.m_RankList[j].name = data.name[j];
					this.m_RankList[j].value = (ulong)data.damage[j];
					this.m_RankList[j].id = data.roleid[j];
				}
				this.m_RankList.Sort(new Comparison<XBaseRankInfo>(this._Compare));
				bool flag3 = this.RankHandler != null && this.RankHandler.IsVisible();
				if (flag3)
				{
					this.RankHandler.RefreshPage();
				}
			}
		}

		public void OnGetRank(List<XCaptainPVPInfo> data)
		{
			int num = data.Count - this.m_RankList.Count;
			for (int i = 0; i < num; i++)
			{
				this.m_RankList.Add(new XCaptainPVPRankInfo());
			}
			bool flag = num < 0;
			if (flag)
			{
				this.m_RankList.RemoveRange(this.m_RankList.Count + num, -num);
			}
			for (int j = 0; j < this.m_RankList.Count; j++)
			{
				XCaptainPVPRankInfo xcaptainPVPRankInfo = this.m_RankList[j] as XCaptainPVPRankInfo;
				xcaptainPVPRankInfo.name = data[j].name;
				xcaptainPVPRankInfo.kill = data[j].kill;
				xcaptainPVPRankInfo.dead = data[j].dead;
				xcaptainPVPRankInfo.assit = data[j].assit;
				bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
				if (bSpectator)
				{
					xcaptainPVPRankInfo.id = data[j].id;
				}
			}
			this.m_RankList.Sort(new Comparison<XBaseRankInfo>(this._ComparePVP));
			bool flag2 = this.RankHandler != null && this.RankHandler.IsVisible();
			if (flag2)
			{
				this.RankHandler.RefreshPage();
			}
		}

		private int _Compare(XBaseRankInfo left, XBaseRankInfo right)
		{
			bool flag = left.value == right.value;
			int result;
			if (flag)
			{
				result = left.id.CompareTo(right.id);
			}
			else
			{
				result = -left.value.CompareTo(right.value);
			}
			return result;
		}

		private int _ComparePVP(XBaseRankInfo left, XBaseRankInfo right)
		{
			XCaptainPVPRankInfo xcaptainPVPRankInfo = left as XCaptainPVPRankInfo;
			XCaptainPVPRankInfo xcaptainPVPRankInfo2 = right as XCaptainPVPRankInfo;
			bool flag = xcaptainPVPRankInfo.kill == xcaptainPVPRankInfo2.kill;
			int result;
			if (flag)
			{
				bool flag2 = xcaptainPVPRankInfo.dead == xcaptainPVPRankInfo2.dead;
				if (flag2)
				{
					result = xcaptainPVPRankInfo.id.CompareTo(xcaptainPVPRankInfo2.id);
				}
				else
				{
					result = xcaptainPVPRankInfo.dead.CompareTo(xcaptainPVPRankInfo2.dead);
				}
			}
			else
			{
				result = -xcaptainPVPRankInfo.kill.CompareTo(xcaptainPVPRankInfo2.kill);
			}
			return result;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SceneDamageRankDocument");

		public IRankView RankHandler;

		private List<XBaseRankInfo> m_RankList = new List<XBaseRankInfo>();
	}
}
