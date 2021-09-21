using System;
using System.Collections.Generic;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DC6 RID: 3526
	internal class XProfessionSkillMgr : XSingleton<XProfessionSkillMgr>
	{
		// Token: 0x0600BFF3 RID: 49139 RVA: 0x00284AAC File Offset: 0x00282CAC
		public override bool Init()
		{
			bool flag = this._async_loader == null;
			if (flag)
			{
				this._async_loader = new XTableAsyncLoader();
				this._async_loader.AddTask("Table/ProfessionSkill", this._reader, false);
				this._async_loader.Execute(null);
			}
			bool flag2 = !this._async_loader.IsDone;
			return !flag2;
		}

		// Token: 0x0600BFF4 RID: 49140 RVA: 0x00284B14 File Offset: 0x00282D14
		public static void InitFromGlobalConfig()
		{
			XProfessionSkillMgr.m_FootFx = XSingleton<XGlobalConfig>.singleton.GetStringList("FootFx");
			XProfessionSkillMgr.m_ProfPortrait = XSingleton<XGlobalConfig>.singleton.GetStringList("ProfPortrait");
			XProfessionSkillMgr.m_TeamIndicateAvatar = XSingleton<XGlobalConfig>.singleton.GetStringList("TeamIndicateAvatar");
			XProfessionSkillMgr.m_SuperRiskAvatar = XSingleton<XGlobalConfig>.singleton.GetStringList("SuperRiskAvatar");
			XProfessionSkillMgr.m_RoleMat = XSingleton<XGlobalConfig>.singleton.GetStringList("ProfRoleMat");
			XProfessionSkillMgr.m_VisibleDistance = XSingleton<XGlobalConfig>.singleton.GetFloatList("VisibleDistance");
			XProfessionSkillMgr.m_SelectCharDummyHeight = XSingleton<XGlobalConfig>.singleton.GetFloatList("SelectCharDummyHeight");
			XProfessionSkillMgr.CheckProfessionCount<string>(XProfessionSkillMgr.m_FootFx, "FootFx");
			XProfessionSkillMgr.CheckProfessionCount<string>(XProfessionSkillMgr.m_ProfPortrait, "m_ProfPortrait");
			XProfessionSkillMgr.CheckProfessionCount<string>(XProfessionSkillMgr.m_TeamIndicateAvatar, "m_TeamIndicateAvatar");
			XProfessionSkillMgr.CheckProfessionCount<string>(XProfessionSkillMgr.m_SuperRiskAvatar, "m_SuperRiskAvatar");
			XProfessionSkillMgr.CheckProfessionCount<string>(XProfessionSkillMgr.m_RoleMat, "m_RoleMat");
			XProfessionSkillMgr.CheckProfessionCount<float>(XProfessionSkillMgr.m_VisibleDistance, "m_VisibleDistance");
			XProfessionSkillMgr.CheckProfessionCount<float>(XProfessionSkillMgr.m_SelectCharDummyHeight, "m_SelectCharDummyHeight");
		}

		// Token: 0x0600BFF5 RID: 49141 RVA: 0x00284C20 File Offset: 0x00282E20
		public static bool CheckProfessionCount<T>(List<T> list, string name)
		{
			bool flag = list.Count < XGame.RoleCount;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(name, " length (", list.Count.ToString(), ") < ProfCount ", XGame.RoleCount.ToString(), null);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600BFF6 RID: 49142 RVA: 0x00284C78 File Offset: 0x00282E78
		public override void Uninit()
		{
			this._async_loader = null;
		}

		// Token: 0x0600BFF7 RID: 49143 RVA: 0x00284C84 File Offset: 0x00282E84
		public void SetProfSkillIds(List<int> lst)
		{
			for (int i = 0; i < this._reader.Table.Length; i++)
			{
				bool flag = this._reader.Table[i] != null;
				if (flag)
				{
					lst.Add(this._reader.Table[i].ProfID);
				}
			}
		}

		// Token: 0x0600BFF8 RID: 49144 RVA: 0x00284CE0 File Offset: 0x00282EE0
		public List<ProfSkillTable.RowData> GetMainProfList()
		{
			List<ProfSkillTable.RowData> list = new List<ProfSkillTable.RowData>();
			for (int i = 1; i < 10; i++)
			{
				ProfSkillTable.RowData byProfID = this._reader.GetByProfID(i);
				bool flag = byProfID != null;
				if (flag)
				{
					list.Add(byProfID);
				}
			}
			return list;
		}

		// Token: 0x0600BFF9 RID: 49145 RVA: 0x00284D30 File Offset: 0x00282F30
		public string GetProfName(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			bool flag = byProfID != null;
			string result;
			if (flag)
			{
				result = byProfID.ProfName;
			}
			else
			{
				result = XStringDefineProxy.GetString("PROFESSION_NONE");
			}
			return result;
		}

		// Token: 0x0600BFFA RID: 49146 RVA: 0x00284D6C File Offset: 0x00282F6C
		public string GetProfHeadIcon(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID % 10);
			bool flag = byProfID != null;
			string result;
			if (flag)
			{
				result = byProfID.ProfHeadIcon;
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600BFFB RID: 49147 RVA: 0x00284DA8 File Offset: 0x00282FA8
		public string GetProfHeadIcon2(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID % 10);
			bool flag = byProfID != null;
			string result;
			if (flag)
			{
				result = byProfID.ProfHeadIcon2;
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600BFFC RID: 49148 RVA: 0x00284DE4 File Offset: 0x00282FE4
		public string GetProfIcon(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			bool flag = byProfID != null;
			string result;
			if (flag)
			{
				result = byProfID.ProfIcon;
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600BFFD RID: 49149 RVA: 0x00284E1C File Offset: 0x0028301C
		public string GetProfPic(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			bool flag = byProfID != null;
			string result;
			if (flag)
			{
				result = byProfID.ProfPic;
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600BFFE RID: 49150 RVA: 0x00284E54 File Offset: 0x00283054
		public List<uint> GetProfSkillID(int profID)
		{
			List<uint> list = new List<uint>();
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			bool flag = byProfID != null;
			if (flag)
			{
				bool flag2 = byProfID.Skill1 != "";
				if (flag2)
				{
					list.Add(XSingleton<XCommon>.singleton.XHash(byProfID.Skill1));
				}
				bool flag3 = byProfID.Skill2 != "";
				if (flag3)
				{
					list.Add(XSingleton<XCommon>.singleton.XHash(byProfID.Skill2));
				}
				bool flag4 = byProfID.Skill3 != "";
				if (flag4)
				{
					list.Add(XSingleton<XCommon>.singleton.XHash(byProfID.Skill3));
				}
				bool flag5 = byProfID.Skill4 != "";
				if (flag5)
				{
					list.Add(XSingleton<XCommon>.singleton.XHash(byProfID.Skill4));
				}
			}
			return list;
		}

		// Token: 0x0600BFFF RID: 49151 RVA: 0x00284F3C File Offset: 0x0028313C
		public float GetProfFixedEnmity(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			bool flag = byProfID != null;
			float result;
			if (flag)
			{
				result = byProfID.FixedEnmity;
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x0600C000 RID: 49152 RVA: 0x00284F74 File Offset: 0x00283174
		public string GetProfDesc(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			bool flag = byProfID != null;
			string result;
			if (flag)
			{
				result = byProfID.Description;
			}
			else
			{
				result = XStringDefineProxy.GetString("PROFESSION_NONE");
			}
			return result;
		}

		// Token: 0x0600C001 RID: 49153 RVA: 0x00284FB0 File Offset: 0x002831B0
		public uint GetProfOperateLevel(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			bool flag = byProfID != null;
			uint result;
			if (flag)
			{
				result = byProfID.OperateLevel;
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		// Token: 0x0600C002 RID: 49154 RVA: 0x00284FE4 File Offset: 0x002831E4
		public bool GetProfIsInLeft(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			bool flag = byProfID != null;
			return !flag || byProfID.PromoteLR;
		}

		// Token: 0x0600C003 RID: 49155 RVA: 0x00285018 File Offset: 0x00283218
		public uint GetPromoteExperienceID(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			bool flag = byProfID != null;
			uint result;
			if (flag)
			{
				result = byProfID.PromoteExperienceID;
			}
			else
			{
				XSingleton<XDebug>.singleton.AddLog("Can't find the PromoteExperienceID by profID, ID = ", profID.ToString(), null, null, null, null, XDebugColor.XDebug_None);
				result = 0U;
			}
			return result;
		}

		// Token: 0x0600C004 RID: 49156 RVA: 0x00285068 File Offset: 0x00283268
		public float GetEnmityCoefficient(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			bool flag = byProfID != null;
			float result;
			if (flag)
			{
				result = byProfID.EnmityCoefficient;
			}
			else
			{
				result = 1f;
			}
			return result;
		}

		// Token: 0x0600C005 RID: 49157 RVA: 0x002850A0 File Offset: 0x002832A0
		public string GetFootFx(uint profID)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<string>(XProfessionSkillMgr.m_FootFx, profID);
		}

		// Token: 0x0600C006 RID: 49158 RVA: 0x002850C4 File Offset: 0x002832C4
		public string GetPortait(uint profID = 0U)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<string>(XProfessionSkillMgr.m_ProfPortrait, profID);
		}

		// Token: 0x0600C007 RID: 49159 RVA: 0x002850E8 File Offset: 0x002832E8
		public string GetSuperRiskAvatar(uint profID = 0U)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<string>(XProfessionSkillMgr.m_SuperRiskAvatar, profID);
		}

		// Token: 0x0600C008 RID: 49160 RVA: 0x0028510C File Offset: 0x0028330C
		public string GetTeamIndicateAvatar(uint profID)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<string>(XProfessionSkillMgr.m_TeamIndicateAvatar, profID);
		}

		// Token: 0x0600C009 RID: 49161 RVA: 0x00285130 File Offset: 0x00283330
		public float GetVisibleDistance(uint profID = 0U)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<float>(XProfessionSkillMgr.m_VisibleDistance, profID);
		}

		// Token: 0x0600C00A RID: 49162 RVA: 0x00285154 File Offset: 0x00283354
		public float GetSelectCharDummyHeight(uint profID = 0U)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<float>(XProfessionSkillMgr.m_SelectCharDummyHeight, profID);
		}

		// Token: 0x0600C00B RID: 49163 RVA: 0x00285178 File Offset: 0x00283378
		public string GetRoleMaterial(uint profID = 0U)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<string>(XProfessionSkillMgr.m_RoleMat, profID);
		}

		// Token: 0x0600C00C RID: 49164 RVA: 0x0028519C File Offset: 0x0028339C
		public string GetHalfPic(uint profID)
		{
			return this.GetLowerCaseWord(profID);
		}

		// Token: 0x0600C00D RID: 49165 RVA: 0x002851B8 File Offset: 0x002833B8
		public string GetLowerCaseWord(uint profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID((int)(profID % 10U));
			bool flag = byProfID == null;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				result = byProfID.ProfWord2;
			}
			return result;
		}

		// Token: 0x0600C00E RID: 49166 RVA: 0x002851F0 File Offset: 0x002833F0
		public string GetUpperCaseWord(uint profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID((int)(profID % 10U));
			bool flag = byProfID == null;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				result = byProfID.ProfWord1;
			}
			return result;
		}

		// Token: 0x0600C00F RID: 49167 RVA: 0x00285228 File Offset: 0x00283428
		public string GetEquipPrefabModel(FashionList.RowData data, uint profID)
		{
			string result;
			switch (profID)
			{
			case 1U:
				result = data.ModelPrefabWarrior;
				break;
			case 2U:
				result = data.ModelPrefabArcher;
				break;
			case 3U:
				result = data.ModelPrefabSorcer;
				break;
			case 4U:
				result = data.ModelPrefabCleric;
				break;
			case 5U:
				result = data.ModelPrefab5;
				break;
			case 6U:
				result = data.ModelPrefab6;
				break;
			case 7U:
				result = data.ModelPrefab7;
				break;
			default:
				result = string.Empty;
				break;
			}
			return result;
		}

		// Token: 0x0600C010 RID: 49168 RVA: 0x002852A8 File Offset: 0x002834A8
		public string GetProfNameIcon(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			bool flag = byProfID != null;
			string result;
			if (flag)
			{
				result = byProfID.ProfNameIcon;
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600C011 RID: 49169 RVA: 0x002852E0 File Offset: 0x002834E0
		public string GetProfIntro(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			bool flag = byProfID != null;
			string result;
			if (flag)
			{
				result = XSingleton<UiUtility>.singleton.ReplaceReturn(byProfID.ProfIntro);
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600C012 RID: 49170 RVA: 0x00285320 File Offset: 0x00283520
		public string GetProfTypeIntro(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			bool flag = byProfID != null;
			string result;
			if (flag)
			{
				result = XSingleton<UiUtility>.singleton.ReplaceReturn(byProfID.ProfTypeIntro);
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600C013 RID: 49171 RVA: 0x00285360 File Offset: 0x00283560
		public bool IsExistProf(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			return byProfID != null;
		}

		// Token: 0x04004E6D RID: 20077
		private XTableAsyncLoader _async_loader = null;

		// Token: 0x04004E6E RID: 20078
		private ProfSkillTable _reader = new ProfSkillTable();

		// Token: 0x04004E6F RID: 20079
		private static List<string> m_FootFx;

		// Token: 0x04004E70 RID: 20080
		private static List<string> m_ProfPortrait;

		// Token: 0x04004E71 RID: 20081
		private static List<string> m_TeamIndicateAvatar;

		// Token: 0x04004E72 RID: 20082
		private static List<string> m_SuperRiskAvatar;

		// Token: 0x04004E73 RID: 20083
		private static List<string> m_RoleMat;

		// Token: 0x04004E74 RID: 20084
		private static List<float> m_VisibleDistance;

		// Token: 0x04004E75 RID: 20085
		private static List<float> m_SelectCharDummyHeight;
	}
}
