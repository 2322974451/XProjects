using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A84 RID: 2692
	internal class XSceneDamageRankDocument : XDocComponent
	{
		// Token: 0x17002FA8 RID: 12200
		// (get) Token: 0x0600A3CC RID: 41932 RVA: 0x001C2174 File Offset: 0x001C0374
		public override uint ID
		{
			get
			{
				return XSceneDamageRankDocument.uuID;
			}
		}

		// Token: 0x17002FA9 RID: 12201
		// (get) Token: 0x0600A3CD RID: 41933 RVA: 0x001C218C File Offset: 0x001C038C
		public List<XBaseRankInfo> RankList
		{
			get
			{
				return this.m_RankList;
			}
		}

		// Token: 0x0600A3CE RID: 41934 RVA: 0x001C21A4 File Offset: 0x001C03A4
		public override void OnEnterSceneFinally()
		{
			this.m_RankList.Clear();
		}

		// Token: 0x0600A3CF RID: 41935 RVA: 0x001C21B4 File Offset: 0x001C03B4
		public void ReqRank()
		{
			PtcC2G_SceneDamageRankReport proto = new PtcC2G_SceneDamageRankReport();
			XSingleton<XClientNetwork>.singleton.Send(proto);
		}

		// Token: 0x0600A3D0 RID: 41936 RVA: 0x001C21D4 File Offset: 0x001C03D4
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

		// Token: 0x0600A3D1 RID: 41937 RVA: 0x001C2328 File Offset: 0x001C0528
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

		// Token: 0x0600A3D2 RID: 41938 RVA: 0x001C2484 File Offset: 0x001C0684
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

		// Token: 0x0600A3D3 RID: 41939 RVA: 0x001C24D0 File Offset: 0x001C06D0
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

		// Token: 0x0600A3D4 RID: 41940 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04003B5E RID: 15198
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SceneDamageRankDocument");

		// Token: 0x04003B5F RID: 15199
		public IRankView RankHandler;

		// Token: 0x04003B60 RID: 15200
		private List<XBaseRankInfo> m_RankList = new List<XBaseRankInfo>();
	}
}
