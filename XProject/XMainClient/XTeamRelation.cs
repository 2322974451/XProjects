using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000D30 RID: 3376
	internal class XTeamRelation : IComparable<XTeamRelation>
	{
		// Token: 0x0600BB48 RID: 47944 RVA: 0x00267430 File Offset: 0x00265630
		public void Reset()
		{
			this.m_Relation = XTeamRelation.Relation.TR_NONE;
			this.m_FinalRelation = XTeamRelation.Relation.TR_NONE;
			this.m_FinalRelation2 = XTeamRelation.Relation.TR_NONE;
		}

		// Token: 0x0600BB49 RID: 47945 RVA: 0x00267448 File Offset: 0x00265648
		public void DirectSet(XTeamRelation.Relation relation)
		{
			this.m_Relation = relation;
			this.RefreshFinalRelation();
		}

		// Token: 0x0600BB4A RID: 47946 RVA: 0x0026745C File Offset: 0x0026565C
		public void Append(XTeamRelation.Relation relation, bool bRefreshFinalImm = true)
		{
			this.m_Relation |= relation;
			if (bRefreshFinalImm)
			{
				this.RefreshFinalRelation();
			}
		}

		// Token: 0x0600BB4B RID: 47947 RVA: 0x00267484 File Offset: 0x00265684
		public void UpdateRelation(ulong roleUID, ulong guildUID, ulong roledragonguildid)
		{
			this.Reset();
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			XPartnerDocument specificDocument2 = XDocuments.GetSpecificDocument<XPartnerDocument>(XPartnerDocument.uuID);
			bool flag = specificDocument.bInGuild && guildUID == specificDocument.UID;
			if (flag)
			{
				this.Append(XTeamRelation.Relation.TR_GUILD, false);
			}
			bool flag2 = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(roleUID);
			if (flag2)
			{
				this.Append(XTeamRelation.Relation.TR_FRIEND, false);
			}
			bool flag3 = XDragonGuildDocument.Doc.IsMyDragonGuildMember(roledragonguildid);
			if (flag3)
			{
				this.Append(XTeamRelation.Relation.TR_PARTNER, false);
			}
			this.RefreshFinalRelation();
		}

		// Token: 0x0600BB4C RID: 47948 RVA: 0x00267510 File Offset: 0x00265710
		public void RefreshFinalRelation()
		{
			bool flag = XTeamRelation.HasRelation(this.m_Relation, XTeamRelation.Relation.TR_PARTNER);
			if (flag)
			{
				this.m_FinalRelation = XTeamRelation.Relation.TR_PARTNER;
			}
			else
			{
				bool flag2 = XTeamRelation.HasRelation(this.m_Relation, XTeamRelation.Relation.TR_GUILD);
				if (flag2)
				{
					this.m_FinalRelation = XTeamRelation.Relation.TR_GUILD;
				}
				else
				{
					bool flag3 = XTeamRelation.HasRelation(this.m_Relation, XTeamRelation.Relation.TR_FRIEND);
					if (flag3)
					{
						this.m_FinalRelation = XTeamRelation.Relation.TR_FRIEND;
					}
					else
					{
						this.m_FinalRelation = XTeamRelation.Relation.TR_NONE;
					}
				}
			}
			this.m_FinalRelation2 = XTeamRelation.Relation.TR_NONE;
			bool flag4 = XTeamRelation.HasRelation(this.m_Relation, XTeamRelation.Relation.TR_GUILD);
			if (flag4)
			{
				this.m_FinalRelation2 = XTeamRelation.Relation.TR_GUILD;
			}
			bool flag5 = XTeamRelation.HasRelation(this.m_Relation, XTeamRelation.Relation.TR_PARTNER);
			if (flag5)
			{
				this.m_FinalRelation2 |= XTeamRelation.Relation.TR_PARTNER;
			}
			else
			{
				bool flag6 = XTeamRelation.HasRelation(this.m_Relation, XTeamRelation.Relation.TR_FRIEND);
				if (flag6)
				{
					this.m_FinalRelation2 |= XTeamRelation.Relation.TR_FRIEND;
				}
			}
		}

		// Token: 0x0600BB4D RID: 47949 RVA: 0x002675D0 File Offset: 0x002657D0
		public static bool HasRelation(XTeamRelation.Relation relation0, XTeamRelation.Relation relation1)
		{
			return (relation0 & relation1) > XTeamRelation.Relation.TR_NONE;
		}

		// Token: 0x0600BB4E RID: 47950 RVA: 0x002675E8 File Offset: 0x002657E8
		public bool HasRelation(XTeamRelation.Relation relation)
		{
			return XTeamRelation.HasRelation(this.m_Relation, relation);
		}

		// Token: 0x170032ED RID: 13037
		// (get) Token: 0x0600BB4F RID: 47951 RVA: 0x00267608 File Offset: 0x00265808
		public bool bIsFriend
		{
			get
			{
				return this.HasRelation(XTeamRelation.Relation.TR_FRIEND);
			}
		}

		// Token: 0x170032EE RID: 13038
		// (get) Token: 0x0600BB50 RID: 47952 RVA: 0x00267624 File Offset: 0x00265824
		public bool bIsGuild
		{
			get
			{
				return this.HasRelation(XTeamRelation.Relation.TR_GUILD);
			}
		}

		// Token: 0x170032EF RID: 13039
		// (get) Token: 0x0600BB51 RID: 47953 RVA: 0x00267640 File Offset: 0x00265840
		public XTeamRelation.Relation ActualRelation
		{
			get
			{
				return this.m_Relation;
			}
		}

		// Token: 0x170032F0 RID: 13040
		// (get) Token: 0x0600BB52 RID: 47954 RVA: 0x00267658 File Offset: 0x00265858
		public XTeamRelation.Relation FinalRelation
		{
			get
			{
				return this.m_FinalRelation;
			}
		}

		// Token: 0x170032F1 RID: 13041
		// (get) Token: 0x0600BB53 RID: 47955 RVA: 0x00267670 File Offset: 0x00265870
		public XTeamRelation.Relation FinalRelation2
		{
			get
			{
				return this.m_FinalRelation2;
			}
		}

		// Token: 0x0600BB54 RID: 47956 RVA: 0x00267688 File Offset: 0x00265888
		public int CompareTo(XTeamRelation other)
		{
			return -this.m_FinalRelation.CompareTo(other.m_FinalRelation);
		}

		// Token: 0x04004BC4 RID: 19396
		private XTeamRelation.Relation m_Relation = XTeamRelation.Relation.TR_NONE;

		// Token: 0x04004BC5 RID: 19397
		private XTeamRelation.Relation m_FinalRelation = XTeamRelation.Relation.TR_NONE;

		// Token: 0x04004BC6 RID: 19398
		private XTeamRelation.Relation m_FinalRelation2 = XTeamRelation.Relation.TR_NONE;

		// Token: 0x020019B8 RID: 6584
		public enum Relation
		{
			// Token: 0x04007FA9 RID: 32681
			TR_NONE,
			// Token: 0x04007FAA RID: 32682
			TR_FRIEND,
			// Token: 0x04007FAB RID: 32683
			TR_GUILD,
			// Token: 0x04007FAC RID: 32684
			TR_PARTNER = 4
		}
	}
}
