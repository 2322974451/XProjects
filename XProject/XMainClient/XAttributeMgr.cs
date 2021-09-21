using System;
using System.Collections.Generic;
using System.IO;
using KKSG;
using ProtoBuf;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F3A RID: 3898
	internal class XAttributeMgr : XSingleton<XAttributeMgr>
	{
		// Token: 0x17003622 RID: 13858
		// (get) Token: 0x0600CEF6 RID: 52982 RVA: 0x00300A4C File Offset: 0x002FEC4C
		public XPlayerAttributes XPlayerData
		{
			get
			{
				return this._playerAttributes;
			}
		}

		// Token: 0x17003623 RID: 13859
		// (get) Token: 0x0600CEF7 RID: 52983 RVA: 0x00300A64 File Offset: 0x002FEC64
		public XAttributeMgr.XPlayerCharacterInfo XPlayerCharacters
		{
			get
			{
				return this._playerCharacterInfo;
			}
		}

		// Token: 0x17003624 RID: 13860
		// (get) Token: 0x0600CEF8 RID: 52984 RVA: 0x00300A7C File Offset: 0x002FEC7C
		// (set) Token: 0x0600CEF9 RID: 52985 RVA: 0x00300A84 File Offset: 0x002FEC84
		public LoginExtraData LoginExData { get; private set; }

		// Token: 0x0600CEFA RID: 52986 RVA: 0x00300A90 File Offset: 0x002FEC90
		public override bool Init()
		{
			this.m_AttrPool.Init(this.blockInit, 8);
			return true;
		}

		// Token: 0x0600CEFB RID: 52987 RVA: 0x00300AB8 File Offset: 0x002FECB8
		public int BackFlowLevel()
		{
			int result = 0;
			bool flag = this.LoginExData != null && this.LoginExData.is_backflow_server;
			if (flag)
			{
				result = (int)this.LoginExData.backflow_level;
			}
			return result;
		}

		// Token: 0x0600CEFC RID: 52988 RVA: 0x00300AF5 File Offset: 0x002FECF5
		public void GetBuffer(ref SmallBuffer<double> sb, int size, int initSize = 0)
		{
			this.m_AttrPool.GetBlock(ref sb, size, initSize);
		}

		// Token: 0x0600CEFD RID: 52989 RVA: 0x00300B07 File Offset: 0x002FED07
		public void ReturnBuffer(ref SmallBuffer<double> sb)
		{
			this.m_AttrPool.ReturnBlock(ref sb);
		}

		// Token: 0x0600CEFE RID: 52990 RVA: 0x00300B18 File Offset: 0x002FED18
		public void ResetPlayerData()
		{
			bool flag = this._playerAttributes != null;
			if (flag)
			{
				this._playerAttributes.HPMPReset();
				this._playerAttributes.IsDead = false;
			}
			XStaticSecurityStatistics.Reset();
		}

		// Token: 0x0600CEFF RID: 52991 RVA: 0x00300B54 File Offset: 0x002FED54
		public XPlayerAttributes InitPlayerAttr(RoleBrief brief, KKSG.Attribute attr, List<SkillInfo> skills, List<uint> skillSlot, uint skillPageIndex, RoleSystem system, MilitaryRecord militaryRank)
		{
			bool flag = this._playerAttributes != null;
			if (flag)
			{
				this._playerAttributes.UninitilizeBuffer();
			}
			this._playerAttributes = (this.InitAttrFromServer(brief.roleID, brief.nickID, (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(brief.type), brief.name, attr, 1U, true, skills, skillSlot, new XOutLookAttr(brief.titleID, militaryRank), brief.level, brief.paymemberid) as XPlayerAttributes);
			this._playerAttributes.Outlook.SetProfType(this._playerAttributes.TypeID);
			this._playerAttributes.Outlook.uiAvatar = false;
			this._playerAttributes.Exp = brief.exp;
			this._playerAttributes.MaxExp = brief.maxexp;
			this._playerAttributes.SkillPageIndex = skillPageIndex;
			bool flag2 = system != null;
			if (flag2)
			{
				this._playerAttributes.openedSystem = system.system;
			}
			this._playerAttributes.Profession = brief.type;
			return this._playerAttributes;
		}

		// Token: 0x0600CF00 RID: 52992 RVA: 0x00300C60 File Offset: 0x002FEE60
		public XAttributes InitAttrFromServer(ulong id, uint shortId, uint type_id, string name, KKSG.Attribute attr, uint fightgroup, bool isControlled, List<SkillInfo> skills, List<uint> bindskills, XOutLookAttr outlookAttr, uint level, uint payMemberID = 0U)
		{
			bool flag = XAttributes.GetCategory(id) == EntityCategory.Category_Role || XAttributes.GetCategory(id) == EntityCategory.Category_DummyRole;
			XAttributes xattributes;
			uint presentID;
			if (flag)
			{
				bool flag2 = XAttributes.IsPlayer(id);
				if (flag2)
				{
					xattributes = (XSingleton<XComponentMgr>.singleton.CreateComponent(null, XPlayerAttributes.uuID) as XPlayerAttributes);
				}
				else
				{
					xattributes = (XSingleton<XComponentMgr>.singleton.CreateComponent(null, XRoleAttributes.uuID) as XRoleAttributes);
				}
				presentID = XSingleton<XEntityMgr>.singleton.RoleInfo.GetByProfID(type_id % 10U).PresentID;
				XRoleAttributes xroleAttributes = xattributes as XRoleAttributes;
				xroleAttributes.Profession = (RoleType)type_id;
				xroleAttributes.GuildName = ((outlookAttr.guild == null) ? "" : outlookAttr.guild.name);
				xroleAttributes.GuildPortrait = ((outlookAttr.guild == null) ? 0U : outlookAttr.guild.icon);
				xroleAttributes.GuildID = ((outlookAttr.guild == null) ? 0UL : outlookAttr.guild.id);
				xroleAttributes.DesignationID = outlookAttr.designationID;
				xroleAttributes.SpecialDesignation = outlookAttr.specialDesignation;
				xroleAttributes.MilitaryRank = outlookAttr.militaryRank;
				xroleAttributes.PrerogativeScore = outlookAttr.prerogativeScore;
				xroleAttributes.PrerogativeSetID = outlookAttr.prerogativeSetID;
				bool flag3 = bindskills != null;
				if (flag3)
				{
					xroleAttributes.skillSlot = bindskills.ToArray();
				}
				xattributes.Type = EntitySpecies.Species_Role;
				xattributes.BeLocked = false;
			}
			else
			{
				XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(type_id);
				presentID = byID.PresentID;
				xattributes = (XSingleton<XComponentMgr>.singleton.CreateComponent(null, XOthersAttributes.uuID) as XOthersAttributes);
				xattributes.Type = (EntitySpecies)byID.Type;
				xattributes.InitAttribute(byID);
			}
			xattributes.Prefab = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(presentID).Prefab;
			xattributes.Name = name;
			xattributes.ShortId = shortId;
			xattributes.EntityID = id;
			xattributes.TypeID = type_id;
			xattributes.PresentID = presentID;
			bool flag4 = attr != null;
			if (flag4)
			{
				xattributes.InitAttribute(attr);
			}
			xattributes.FightGroup = fightgroup;
			xattributes.TitleID = outlookAttr.titleID;
			xattributes.PayMemberID = payMemberID;
			bool flag5 = skills != null;
			if (flag5)
			{
				xattributes.SkillLevelInfo.Init(skills);
			}
			xattributes.Level = level;
			return xattributes;
		}

		// Token: 0x0600CF01 RID: 52993 RVA: 0x00300EB4 File Offset: 0x002FF0B4
		public XOthersAttributes InitAttrFromClient(uint id, KKSG.Attribute attr, uint fightgroup)
		{
			XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(id);
			bool flag = byID == null;
			XOthersAttributes result;
			if (flag)
			{
				result = null;
			}
			else
			{
				uint presentID = byID.PresentID;
				XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(presentID);
				bool flag2 = byPresentID == null || string.IsNullOrEmpty(byPresentID.Prefab);
				if (flag2)
				{
					result = null;
				}
				else
				{
					XOthersAttributes xothersAttributes = XSingleton<XComponentMgr>.singleton.CreateComponent(null, XOthersAttributes.uuID) as XOthersAttributes;
					xothersAttributes.Prefab = byPresentID.Prefab;
					xothersAttributes.Name = byID.Name;
					xothersAttributes.EntityID = (ulong)(((long)XSingleton<XCommon>.singleton.New_id & 1152921504606846975L) | (long)XAttributes.GetTypePrefix((EntitySpecies)byID.Type));
					xothersAttributes.TypeID = id;
					xothersAttributes.PresentID = presentID;
					xothersAttributes.Type = (EntitySpecies)byID.Type;
					bool flag3 = fightgroup != uint.MaxValue && byID.Fightgroup == -1;
					if (flag3)
					{
						xothersAttributes.FightGroup = fightgroup;
					}
					else
					{
						xothersAttributes.FightGroup = (uint)byID.Fightgroup;
					}
					xothersAttributes.InitAttribute(byID);
					bool flag4 = attr != null;
					if (flag4)
					{
						xothersAttributes.InitAttribute(attr);
					}
					result = xothersAttributes;
				}
			}
			return result;
		}

		// Token: 0x0600CF02 RID: 52994 RVA: 0x00300FEC File Offset: 0x002FF1EC
		public bool HasNoRoleOnBackFlowServer()
		{
			bool flag = this.LoginExData != null && this.LoginExData.is_backflow_server;
			bool result;
			if (flag)
			{
				for (int i = 0; i < this._playerCharacterInfo.PlayerBriefInfo.Count; i++)
				{
					bool flag2 = this._playerCharacterInfo.PlayerBriefInfo[i] != null;
					if (flag2)
					{
						return false;
					}
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600CF03 RID: 52995 RVA: 0x00301060 File Offset: 0x002FF260
		public XNpcAttributes InitNpcAttr(uint id)
		{
			XNpcInfo.RowData byNPCID = XSingleton<XEntityMgr>.singleton.NpcInfo.GetByNPCID(id);
			bool flag = byNPCID == null;
			XNpcAttributes result;
			if (flag)
			{
				result = null;
			}
			else
			{
				uint presentID = byNPCID.PresentID;
				XNpcAttributes xnpcAttributes = XSingleton<XComponentMgr>.singleton.CreateComponent(null, XNpcAttributes.uuID) as XNpcAttributes;
				xnpcAttributes.Prefab = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(presentID).Prefab;
				xnpcAttributes.Name = byNPCID.Name;
				xnpcAttributes.EntityID = (XAttributes.GetTypePrefix(EntitySpecies.Species_Npc) | (ulong)XSingleton<XCommon>.singleton.XHash(byNPCID.Name) + (ulong)((long)XSingleton<XCommon>.singleton.New_id));
				xnpcAttributes.TypeID = id;
				xnpcAttributes.PresentID = presentID;
				xnpcAttributes.Type = EntitySpecies.Species_Npc;
				xnpcAttributes.FightGroup = (uint)XFastEnumIntEqualityComparer<FightGroupType>.ToInt(FightGroupType.FightNeutral);
				xnpcAttributes.InitAttribute(byNPCID);
				result = xnpcAttributes;
			}
			return result;
		}

		// Token: 0x0600CF04 RID: 52996 RVA: 0x00301134 File Offset: 0x002FF334
		public bool ProcessAccountData(LoadAccountData roAccountData)
		{
			bool flag = roAccountData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo.Clear();
				this.ParseRoleBriefInfo(XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo, roAccountData.role1);
				this.ParseRoleBriefInfo(XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo, roAccountData.role2);
				this.ParseRoleBriefInfo(XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo, roAccountData.role3);
				this.ParseRoleBriefInfo(XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo, roAccountData.role4);
				this.ParseRoleBriefInfo(XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo, roAccountData.role5);
				this.ParseRoleBriefInfo(XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo, roAccountData.role6);
				this.ParseRoleBriefInfo(XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo, roAccountData.role7);
				this.ParseRoleBriefInfo(XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo, roAccountData.role8);
				this.ParseRoleBriefInfo(XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo, roAccountData.role9);
				bool flag2 = roAccountData.selectSlot >= (uint)XGame.RoleCount;
				if (flag2)
				{
					XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.SelectedSlot = 0;
				}
				else
				{
					XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.SelectedSlot = (int)(roAccountData.selectSlot + 1U);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600CF05 RID: 52997 RVA: 0x003012A5 File Offset: 0x002FF4A5
		public void ProcessLoginExtraData(LoginExtraData data)
		{
			this.LoginExData = data;
		}

		// Token: 0x0600CF06 RID: 52998 RVA: 0x003012B0 File Offset: 0x002FF4B0
		public void OnLeaveStage()
		{
			this._playerAttributes = null;
		}

		// Token: 0x0600CF07 RID: 52999 RVA: 0x003012BC File Offset: 0x002FF4BC
		public void OnReconnect()
		{
			List<SkillInfo> skills = null;
			List<uint> skillSlot = null;
			uint skillPageIndex = 0U;
			bool flag = XSingleton<XReconnection>.singleton.PlayerInfo.skill != null;
			if (flag)
			{
				skills = ((XSingleton<XReconnection>.singleton.PlayerInfo.skill.index == 0U) ? XSingleton<XReconnection>.singleton.PlayerInfo.skill.Skills : XSingleton<XReconnection>.singleton.PlayerInfo.skill.SkillsTwo);
				skillSlot = ((XSingleton<XReconnection>.singleton.PlayerInfo.skill.index == 0U) ? XSingleton<XReconnection>.singleton.PlayerInfo.skill.SkillSlot : XSingleton<XReconnection>.singleton.PlayerInfo.skill.SkillSlotTwo);
				skillPageIndex = XSingleton<XReconnection>.singleton.PlayerInfo.skill.index;
			}
			this.InitPlayerAttrByReconncet(XSingleton<XReconnection>.singleton.PlayerInfo.Brief, XSingleton<XReconnection>.singleton.PlayerApperance.attributes, skills, skillSlot, skillPageIndex, XSingleton<XReconnection>.singleton.PlayerInfo.system, XSingleton<XReconnection>.singleton.PlayerInfo.military);
			bool flag2 = XSingleton<XEntityMgr>.singleton.Player != null;
			if (flag2)
			{
				XSecurityStatistics xsecurityStatistics = XSecurityStatistics.TryGetStatistics(XSingleton<XEntityMgr>.singleton.Player);
				XOutlookHelper.SetOutLook(this._playerAttributes, XSingleton<XReconnection>.singleton.PlayerApperance.outlook, true);
				this._playerAttributes.AutoPlayOn = XSingleton<XReconnection>.singleton.IsAutoFight;
				XSingleton<XEntityMgr>.singleton.Player.Attributes.OnFightGroupChange((XSingleton<XGame>.singleton.SyncModeValue != 0) ? XSingleton<XReconnection>.singleton.PlayerApperance.fightgroup : ((uint)XFastEnumIntEqualityComparer<FightGroupType>.ToInt(FightGroupType.FightRole)));
			}
		}

		// Token: 0x0600CF08 RID: 53000 RVA: 0x00301458 File Offset: 0x002FF658
		private void InitPlayerAttrByReconncet(RoleBrief brief, KKSG.Attribute attr, List<SkillInfo> skills, List<uint> skillSlot, uint skillPageIndex, RoleSystem system, MilitaryRecord militaryRank)
		{
			this.InitAttrFromServerByReconncet(brief.roleID, brief.nickID, (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(brief.type), brief.name, attr, (XSingleton<XGame>.singleton.SyncModeValue != 0) ? XSingleton<XReconnection>.singleton.PlayerApperance.fightgroup : ((uint)XFastEnumIntEqualityComparer<FightGroupType>.ToInt(FightGroupType.FightRole)), true, skills, skillSlot, brief.level, new XOutLookAttr(brief.titleID, militaryRank), brief.paymemberid);
			this._playerAttributes.Outlook.SetProfType(this._playerAttributes.TypeID);
			this._playerAttributes.Outlook.uiAvatar = false;
			this._playerAttributes.Exp = brief.exp;
			this._playerAttributes.MaxExp = brief.maxexp;
			this._playerAttributes.SkillPageIndex = skillPageIndex;
			bool flag = system != null;
			if (flag)
			{
				this._playerAttributes.openedSystem = system.system;
			}
			this._playerAttributes.Profession = brief.type;
		}

		// Token: 0x0600CF09 RID: 53001 RVA: 0x0030155C File Offset: 0x002FF75C
		private void InitAttrFromServerByReconncet(ulong id, uint shortId, uint type_id, string name, KKSG.Attribute attr, uint fightgroup, bool isControlled, List<SkillInfo> skills, List<uint> bindskills, uint level, XOutLookAttr outlookAttr, uint payMemberID = 0U)
		{
			XAttributes playerAttributes = this._playerAttributes;
			uint presentID = XSingleton<XEntityMgr>.singleton.RoleInfo.GetByProfID(type_id % 10U).PresentID;
			XRoleAttributes xroleAttributes = playerAttributes as XRoleAttributes;
			xroleAttributes.Profession = (RoleType)type_id;
			xroleAttributes.MilitaryRank = outlookAttr.militaryRank;
			bool flag = bindskills != null;
			if (flag)
			{
				xroleAttributes.skillSlot = bindskills.ToArray();
			}
			playerAttributes.Type = EntitySpecies.Species_Role;
			playerAttributes.BeLocked = false;
			playerAttributes.Prefab = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(presentID).Prefab;
			playerAttributes.Name = name;
			playerAttributes.ShortId = shortId;
			playerAttributes.EntityID = id;
			playerAttributes.TypeID = type_id;
			playerAttributes.PresentID = presentID;
			bool flag2 = attr != null;
			if (flag2)
			{
				playerAttributes.InitAttribute(attr);
			}
			playerAttributes.FightGroup = fightgroup;
			playerAttributes.TitleID = outlookAttr.titleID;
			playerAttributes.PayMemberID = payMemberID;
			bool flag3 = skills != null;
			if (flag3)
			{
				playerAttributes.SkillLevelInfo.Init(skills);
			}
			playerAttributes.Level = level;
		}

		// Token: 0x0600CF0A RID: 53002 RVA: 0x00301670 File Offset: 0x002FF870
		private void ParseRoleBriefInfo(List<RoleBriefInfo> list, byte[] data)
		{
			bool flag = list.Count >= XGame.RoleCount;
			if (!flag)
			{
				bool flag2 = data == null || data.Length == 0;
				if (flag2)
				{
					list.Add(null);
				}
				else
				{
					MemoryStream source = new MemoryStream(data);
					RoleBriefInfo item = Serializer.Deserialize<RoleBriefInfo>(source);
					list.Add(item);
				}
			}
		}

		// Token: 0x04005D0F RID: 23823
		private SmallBufferPool<double> m_AttrPool = new SmallBufferPool<double>();

		// Token: 0x04005D10 RID: 23824
		private BlockInfo[] blockInit = new BlockInfo[]
		{
			new BlockInfo(XAttributeCommon.AttrCount, 256)
		};

		// Token: 0x04005D11 RID: 23825
		private XPlayerAttributes _playerAttributes = null;

		// Token: 0x04005D12 RID: 23826
		private XAttributeMgr.XPlayerCharacterInfo _playerCharacterInfo = new XAttributeMgr.XPlayerCharacterInfo();

		// Token: 0x020019F3 RID: 6643
		public class XPlayerCharacterInfo
		{
			// Token: 0x040080B6 RID: 32950
			public List<RoleBriefInfo> PlayerBriefInfo = new List<RoleBriefInfo>();

			// Token: 0x040080B7 RID: 32951
			public int SelectedSlot = 0;
		}
	}
}
