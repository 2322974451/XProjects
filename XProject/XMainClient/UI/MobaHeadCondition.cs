using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001731 RID: 5937
	internal class MobaHeadCondition : DlgHandlerBase
	{
		// Token: 0x0600F52F RID: 62767 RVA: 0x003752DC File Offset: 0x003734DC
		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			this.m_selfTemp = (base.transform.Find("blue").GetComponent("XUISprite") as IXUISprite);
			this.m_selfTemp.SetVisible(false);
			this.m_otherTemp = (base.transform.Find("red").GetComponent("XUISprite") as IXUISprite);
			this.m_otherTemp.SetVisible(false);
		}

		// Token: 0x170037B8 RID: 14264
		// (get) Token: 0x0600F530 RID: 62768 RVA: 0x00375368 File Offset: 0x00373568
		public List<MobaMemberData> SelfTeamDatas
		{
			get
			{
				bool flag = this.m_selfTeamDatas == null;
				if (flag)
				{
					this.m_selfTeamDatas = new List<MobaMemberData>();
				}
				return this.m_selfTeamDatas;
			}
		}

		// Token: 0x0600F531 RID: 62769 RVA: 0x00375398 File Offset: 0x00373598
		public override void OnUnload()
		{
			bool flag = this.m_selfTeamPlayers != null;
			if (flag)
			{
				this.m_selfTeamPlayers.Clear();
				this.m_selfTeamPlayers = null;
			}
			bool flag2 = this.m_otherTeamDatas != null;
			if (flag2)
			{
				this.m_otherTeamPlayers.Clear();
				this.m_otherTeamPlayers = null;
			}
			bool flag3 = this.m_selfTeamDatas != null;
			if (flag3)
			{
				this.m_selfTeamDatas.Clear();
				this.m_selfTeamDatas = null;
			}
			bool flag4 = this.m_otherTeamDatas != null;
			if (flag4)
			{
				this.m_otherTeamDatas.Clear();
				this.m_otherTeamDatas = null;
			}
			base.OnUnload();
		}

		// Token: 0x170037B9 RID: 14265
		// (get) Token: 0x0600F532 RID: 62770 RVA: 0x00375438 File Offset: 0x00373638
		public List<MobaMemberData> OtherTeamDatas
		{
			get
			{
				bool flag = this.m_otherTeamDatas == null;
				if (flag)
				{
					this.m_otherTeamDatas = new List<MobaMemberData>();
				}
				return this.m_otherTeamDatas;
			}
		}

		// Token: 0x0600F533 RID: 62771 RVA: 0x00375468 File Offset: 0x00373668
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = Time.realtimeSinceStartup - this._RefreshSignTime < 1f;
			if (!flag)
			{
				this._RefreshSignTime = Time.realtimeSinceStartup;
				this.SelfTeamDatas.Clear();
				this.OtherTeamDatas.Clear();
				int i = 0;
				int count = this.m_doc.MobaData.BufferValues.Count;
				while (i < count)
				{
					bool flag2 = this.FilterSelfTeamPlayer(this.m_doc.MobaData.BufferValues[i]);
					if (flag2)
					{
						this.SelfTeamDatas.Add(this.m_doc.MobaData.BufferValues[i]);
					}
					else
					{
						bool flag3 = this.FilterOtherTeamPlayer(this.m_doc.MobaData.BufferValues[i]);
						if (flag3)
						{
							this.OtherTeamDatas.Add(this.m_doc.MobaData.BufferValues[i]);
						}
					}
					i++;
				}
				this.ShowHeaders(ref this.m_selfTeamPlayers, this.SelfTeamDatas, this.m_selfTemp);
				this.ShowHeaders(ref this.m_otherTeamPlayers, this.OtherTeamDatas, this.m_otherTemp);
			}
		}

		// Token: 0x0600F534 RID: 62772 RVA: 0x003755AC File Offset: 0x003737AC
		private void ShowHeaders(ref List<Transform> headers, List<MobaMemberData> members, IXUISprite tempSprite)
		{
			bool flag = headers == null;
			if (flag)
			{
				headers = new List<Transform>();
			}
			int count = members.Count;
			int i = headers.Count;
			while (i < count)
			{
				GameObject gameObject = XCommon.Instantiate<GameObject>(tempSprite.gameObject);
				gameObject.transform.parent = tempSprite.transform.parent;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = tempSprite.transform.localPosition + new Vector3((float)(tempSprite.spriteWidth * i), 0f, 0f);
				gameObject.name = tempSprite.gameObject.name + i.ToString();
				i++;
				headers.Add(gameObject.transform);
			}
			for (int j = 0; j < i; j++)
			{
				bool flag2 = j < count;
				if (flag2)
				{
					headers[j].gameObject.SetActive(true);
					IXUISprite ixuisprite = headers[j].Find("HeroIcon").GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel = headers[j].Find("TIME").GetComponent("XUILabel") as IXUILabel;
					string strAtlas;
					string strSprite;
					XHeroBattleDocument.GetIconByHeroID(members[j].heroID, out strAtlas, out strSprite);
					ixuisprite.SetSprite(strSprite, strAtlas, false);
					bool flag3 = members[j].reviveTime > 0f;
					if (flag3)
					{
						ixuisprite.SetGrey(false);
						ixuilabel.SetText(((int)members[j].reviveTime).ToString());
					}
					else
					{
						ixuisprite.SetGrey(true);
						ixuilabel.SetText(string.Empty);
					}
				}
				else
				{
					headers[j].gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x0600F535 RID: 62773 RVA: 0x003757AC File Offset: 0x003739AC
		private bool FilterSelfTeamPlayer(MobaMemberData mobaMember)
		{
			return this.m_doc.isAlly((int)mobaMember.teamID) && !mobaMember.isMy;
		}

		// Token: 0x0600F536 RID: 62774 RVA: 0x003757E0 File Offset: 0x003739E0
		private bool FilterOtherTeamPlayer(MobaMemberData mobaMember)
		{
			return !this.m_doc.isAlly((int)mobaMember.teamID) && mobaMember.reviveTime > 0f;
		}

		// Token: 0x04006A2F RID: 27183
		private List<Transform> m_selfTeamPlayers;

		// Token: 0x04006A30 RID: 27184
		private List<Transform> m_otherTeamPlayers;

		// Token: 0x04006A31 RID: 27185
		private List<MobaMemberData> m_selfTeamDatas;

		// Token: 0x04006A32 RID: 27186
		private List<MobaMemberData> m_otherTeamDatas;

		// Token: 0x04006A33 RID: 27187
		private IXUISprite m_selfTemp;

		// Token: 0x04006A34 RID: 27188
		private IXUISprite m_otherTemp;

		// Token: 0x04006A35 RID: 27189
		private XMobaBattleDocument m_doc;

		// Token: 0x04006A36 RID: 27190
		private float _RefreshSignTime = 0f;
	}
}
