using System;
using System.Collections.Generic;
using System.IO;
using KKSG;
using ProtoBuf;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAttributeMgr : XSingleton<XAttributeMgr>
	{

		public XPlayerAttributes XPlayerData
		{
			get
			{
				return this._playerAttributes;
			}
		}

		public XAttributeMgr.XPlayerCharacterInfo XPlayerCharacters
		{
			get
			{
				return this._playerCharacterInfo;
			}
		}

		public LoginExtraData LoginExData { get; private set; }

		public override bool Init()
		{
			this.m_AttrPool.Init(this.blockInit, 8);
			return true;
		}

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

		public void GetBuffer(ref SmallBuffer<double> sb, int size, int initSize = 0)
		{
			this.m_AttrPool.GetBlock(ref sb, size, initSize);
		}

		public void ReturnBuffer(ref SmallBuffer<double> sb)
		{
			this.m_AttrPool.ReturnBlock(ref sb);
		}

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

		public void ProcessLoginExtraData(LoginExtraData data)
		{
			this.LoginExData = data;
		}

		public void OnLeaveStage()
		{
			this._playerAttributes = null;
		}

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

		private SmallBufferPool<double> m_AttrPool = new SmallBufferPool<double>();

		private BlockInfo[] blockInit = new BlockInfo[]
		{
			new BlockInfo(XAttributeCommon.AttrCount, 256)
		};

		private XPlayerAttributes _playerAttributes = null;

		private XAttributeMgr.XPlayerCharacterInfo _playerCharacterInfo = new XAttributeMgr.XPlayerCharacterInfo();

		public class XPlayerCharacterInfo
		{

			public List<RoleBriefInfo> PlayerBriefInfo = new List<RoleBriefInfo>();

			public int SelectedSlot = 0;
		}
	}
}
