using System;
using System.Collections.Generic;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XProfessionSkillMgr : XSingleton<XProfessionSkillMgr>
	{

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

		public override void Uninit()
		{
			this._async_loader = null;
		}

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

		public bool GetProfIsInLeft(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			bool flag = byProfID != null;
			return !flag || byProfID.PromoteLR;
		}

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

		public string GetFootFx(uint profID)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<string>(XProfessionSkillMgr.m_FootFx, profID);
		}

		public string GetPortait(uint profID = 0U)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<string>(XProfessionSkillMgr.m_ProfPortrait, profID);
		}

		public string GetSuperRiskAvatar(uint profID = 0U)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<string>(XProfessionSkillMgr.m_SuperRiskAvatar, profID);
		}

		public string GetTeamIndicateAvatar(uint profID)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<string>(XProfessionSkillMgr.m_TeamIndicateAvatar, profID);
		}

		public float GetVisibleDistance(uint profID = 0U)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<float>(XProfessionSkillMgr.m_VisibleDistance, profID);
		}

		public float GetSelectCharDummyHeight(uint profID = 0U)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<float>(XProfessionSkillMgr.m_SelectCharDummyHeight, profID);
		}

		public string GetRoleMaterial(uint profID = 0U)
		{
			return XSingleton<UiUtility>.singleton.ChooseProfData<string>(XProfessionSkillMgr.m_RoleMat, profID);
		}

		public string GetHalfPic(uint profID)
		{
			return this.GetLowerCaseWord(profID);
		}

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

		public bool IsExistProf(int profID)
		{
			ProfSkillTable.RowData byProfID = this._reader.GetByProfID(profID);
			return byProfID != null;
		}

		private XTableAsyncLoader _async_loader = null;

		private ProfSkillTable _reader = new ProfSkillTable();

		private static List<string> m_FootFx;

		private static List<string> m_ProfPortrait;

		private static List<string> m_TeamIndicateAvatar;

		private static List<string> m_SuperRiskAvatar;

		private static List<string> m_RoleMat;

		private static List<float> m_VisibleDistance;

		private static List<float> m_SelectCharDummyHeight;
	}
}
