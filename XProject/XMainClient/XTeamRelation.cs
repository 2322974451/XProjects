using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XTeamRelation : IComparable<XTeamRelation>
	{

		public void Reset()
		{
			this.m_Relation = XTeamRelation.Relation.TR_NONE;
			this.m_FinalRelation = XTeamRelation.Relation.TR_NONE;
			this.m_FinalRelation2 = XTeamRelation.Relation.TR_NONE;
		}

		public void DirectSet(XTeamRelation.Relation relation)
		{
			this.m_Relation = relation;
			this.RefreshFinalRelation();
		}

		public void Append(XTeamRelation.Relation relation, bool bRefreshFinalImm = true)
		{
			this.m_Relation |= relation;
			if (bRefreshFinalImm)
			{
				this.RefreshFinalRelation();
			}
		}

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

		public static bool HasRelation(XTeamRelation.Relation relation0, XTeamRelation.Relation relation1)
		{
			return (relation0 & relation1) > XTeamRelation.Relation.TR_NONE;
		}

		public bool HasRelation(XTeamRelation.Relation relation)
		{
			return XTeamRelation.HasRelation(this.m_Relation, relation);
		}

		public bool bIsFriend
		{
			get
			{
				return this.HasRelation(XTeamRelation.Relation.TR_FRIEND);
			}
		}

		public bool bIsGuild
		{
			get
			{
				return this.HasRelation(XTeamRelation.Relation.TR_GUILD);
			}
		}

		public XTeamRelation.Relation ActualRelation
		{
			get
			{
				return this.m_Relation;
			}
		}

		public XTeamRelation.Relation FinalRelation
		{
			get
			{
				return this.m_FinalRelation;
			}
		}

		public XTeamRelation.Relation FinalRelation2
		{
			get
			{
				return this.m_FinalRelation2;
			}
		}

		public int CompareTo(XTeamRelation other)
		{
			return -this.m_FinalRelation.CompareTo(other.m_FinalRelation);
		}

		private XTeamRelation.Relation m_Relation = XTeamRelation.Relation.TR_NONE;

		private XTeamRelation.Relation m_FinalRelation = XTeamRelation.Relation.TR_NONE;

		private XTeamRelation.Relation m_FinalRelation2 = XTeamRelation.Relation.TR_NONE;

		public enum Relation
		{

			TR_NONE,

			TR_FRIEND,

			TR_GUILD,

			TR_PARTNER = 4
		}
	}
}
