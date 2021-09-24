using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAIDataRelated : XSingleton<XAIDataRelated>
	{

		public int GetProfIndex(GameObject go)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			bool flag = entity == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				int num = (int)(entity.Attributes.TypeID % 10U - 1U);
				int num2 = (int)(entity.Attributes.TypeID / 10U - 1U);
				bool flag2 = entity.Attributes.TypeID >= 1000U || entity.Attributes.TypeID <= 10U;
				if (flag2)
				{
					result = num * 2 + XSingleton<XCommon>.singleton.RandomInt(0, 2);
				}
				else
				{
					result = num * 2 + num2;
				}
			}
			return result;
		}

		public List<uint> GetAssistSkillList(GameObject go, int profIndex)
		{
			List<uint> list = new List<uint>();
			List<string> list2 = new List<string>();
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			SkillCombo.RowData rowData = XArenaDocument.SkillComboTable.Table[profIndex + 6];
			bool flag = rowData.nextskill0 != "";
			if (flag)
			{
				list2.Add(rowData.nextskill0);
			}
			bool flag2 = rowData.nextskill1 != "";
			if (flag2)
			{
				list2.Add(rowData.nextskill1);
			}
			bool flag3 = rowData.nextskill2 != "";
			if (flag3)
			{
				list2.Add(rowData.nextskill2);
			}
			bool flag4 = rowData.nextskill3 != "";
			if (flag4)
			{
				list2.Add(rowData.nextskill3);
			}
			bool flag5 = rowData.nextskill4 != "";
			if (flag5)
			{
				list2.Add(rowData.nextskill4);
			}
			for (int i = 0; i < list2.Count; i++)
			{
				for (int j = 0; j < entity.SkillMgr.SkillOrder.Count; j++)
				{
					XSkillCore xskillCore = entity.SkillMgr.SkillOrder[j] as XSkillCore;
					bool flag6 = xskillCore != null && xskillCore.Soul.Name == list2[i];
					if (flag6)
					{
						list.Add(xskillCore.ID);
						break;
					}
				}
			}
			return list;
		}

		public List<uint> GetStartSkillList(GameObject go, int prof)
		{
			List<uint> list = new List<uint>();
			List<string> list2 = new List<string>();
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			SkillCombo.RowData rowData = XArenaDocument.SkillComboTable.Table[prof];
			bool flag = rowData.nextskill0 != "";
			if (flag)
			{
				list2.Add(rowData.nextskill0);
			}
			bool flag2 = rowData.nextskill1 != "";
			if (flag2)
			{
				list2.Add(rowData.nextskill1);
			}
			bool flag3 = rowData.nextskill2 != "";
			if (flag3)
			{
				list2.Add(rowData.nextskill2);
			}
			bool flag4 = rowData.nextskill3 != "";
			if (flag4)
			{
				list2.Add(rowData.nextskill3);
			}
			bool flag5 = rowData.nextskill4 != "";
			if (flag5)
			{
				list2.Add(rowData.nextskill4);
			}
			for (int i = 0; i < list2.Count; i++)
			{
				bool flag6 = entity.SkillMgr.GetPhysicalSkill().Soul.Name == list2[i];
				if (flag6)
				{
					list.Add(entity.SkillMgr.GetPhysicalSkill().ID);
					break;
				}
				for (int j = 0; j < entity.SkillMgr.SkillOrder.Count; j++)
				{
					XSkillCore xskillCore = entity.SkillMgr.SkillOrder[j] as XSkillCore;
					bool flag7 = xskillCore != null && xskillCore.Soul.Name == list2[i];
					if (flag7)
					{
						list.Add(xskillCore.ID);
						break;
					}
				}
			}
			return list;
		}

		public bool DetectEnimyInSight(XEntity entity)
		{
			List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(entity);
			for (int i = 0; i < opponent.Count; i++)
			{
				bool flag = !XEntity.ValideEntity(opponent[i]) || opponent[i].IsPuppet;
				if (!flag)
				{
					float sqrMagnitude = (opponent[i].EngineObject.Position - entity.EngineObject.Position).sqrMagnitude;
					bool flag2 = XSingleton<XCommon>.singleton.IsLess(sqrMagnitude, entity.AI.EnterFightRange * entity.AI.EnterFightRange);
					if (flag2)
					{
						entity.AI.NotifyAllyIntoFight(opponent[i]);
						return true;
					}
				}
			}
			return false;
		}
	}
}
