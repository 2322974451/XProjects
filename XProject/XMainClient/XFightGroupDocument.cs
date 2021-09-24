using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFightGroupDocument : XComponent
	{

		public override uint ID
		{
			get
			{
				return XFightGroupDocument.uuID;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XFightGroupDocument.AsyncLoader.AddTask("Table/FightGroup", XFightGroupDocument._FightGroup, false);
			XFightGroupDocument.AsyncLoader.Execute(callback);
		}

		public static void OnTableLoaded()
		{
			int num = XFightGroupDocument._FightGroup.Table.Length - 1;
			int num2 = XFastEnumIntEqualityComparer<FightGroupType>.ToInt(FightGroupType.FightNeutral);
			XFightGroupDocument.FightGroup = new bool[num, num];
			Type typeFromHandle = typeof(FightGroupTable.RowData);
			FieldInfo[] fields = typeFromHandle.GetFields();
			for (int i = 0; i < num; i++)
			{
				FightGroupTable.RowData obj = XFightGroupDocument._FightGroup.Table[i + 1];
				for (int j = 0; j < num; j++)
				{
					bool flag = i == num2 || j == num2 || i == j;
					if (flag)
					{
						XFightGroupDocument.FightGroup[i, j] = false;
					}
					else
					{
						string a = fields[j + 1].GetValue(obj).ToString();
						XFightGroupDocument.FightGroup[i, j] = (a == "o");
					}
				}
			}
			XFightGroupDocument._fight_desc = new XFightGroupDocument.FightGroupDesc[num];
			for (int k = 0; k < XFightGroupDocument._fight_desc.Length; k++)
			{
				XFightGroupDocument._fight_desc[k].ally = new List<XEntity>();
				XFightGroupDocument._fight_desc[k].oppo = new List<XEntity>();
			}
		}

		public static void OnSceneLoaded()
		{
			for (int i = 0; i < XFightGroupDocument._fight_desc.Length; i++)
			{
				XFightGroupDocument._fight_desc[i].ally.Clear();
				XFightGroupDocument._fight_desc[i].oppo.Clear();
			}
			XFightGroupDocument._fight_desc_map.Clear();
			XFightGroupDocument._fight_groups.Clear();
			for (int j = 0; j < 10; j++)
			{
				XFightGroupDocument.FightGroupDesc value = default(XFightGroupDocument.FightGroupDesc);
				value.ally = new List<XEntity>();
				value.oppo = new List<XEntity>();
				XFightGroupDocument._fight_desc_map.Add((uint)(XFightGroupDocument._fight_desc.Length + j), value);
			}
		}

		public static void OnCalcFightGroup(XEntity e)
		{
			bool flag = XSingleton<XEntityMgr>.singleton.IsNeutral(e);
			if (flag)
			{
				XFightGroupDocument._fight_desc[(int)XFightGroupDocument._fightNeutral].ally.Add(e);
			}
			else
			{
				uint fightGroup = e.Attributes.FightGroup;
				uint num = 0U;
				while ((ulong)num < (ulong)((long)XFightGroupDocument._fight_desc.Length))
				{
					bool flag2 = XSingleton<XEntityMgr>.singleton.IsAlly(num, fightGroup);
					if (flag2)
					{
						XFightGroupDocument._fight_desc[(int)num].ally.Add(e);
					}
					bool flag3 = XSingleton<XEntityMgr>.singleton.IsOpponent(num, fightGroup);
					if (flag3)
					{
						XFightGroupDocument._fight_desc[(int)num].oppo.Add(e);
					}
					num += 1U;
				}
				foreach (KeyValuePair<uint, XFightGroupDocument.FightGroupDesc> keyValuePair in XFightGroupDocument._fight_desc_map)
				{
					bool flag4 = XSingleton<XEntityMgr>.singleton.IsAlly(keyValuePair.Key, fightGroup);
					if (flag4)
					{
						keyValuePair.Value.ally.Add(e);
					}
					bool flag5 = XSingleton<XEntityMgr>.singleton.IsOpponent(keyValuePair.Key, fightGroup);
					if (flag5)
					{
						keyValuePair.Value.oppo.Add(e);
					}
				}
			}
			uint key = XSingleton<XEntityMgr>.singleton.IsNeutral(e) ? XFightGroupDocument._fightNeutral : e.Attributes.FightGroup;
			bool flag6 = !XFightGroupDocument._fight_groups.ContainsKey(key);
			if (flag6)
			{
				XFightGroupDocument._fight_groups[key] = new List<XEntity>();
			}
			bool flag7 = !XFightGroupDocument._fight_groups[key].Contains(e);
			if (flag7)
			{
				XFightGroupDocument._fight_groups[key].Add(e);
			}
		}

		public static void OnDecalcFightGroup(XEntity e)
		{
			bool flag = XSingleton<XEntityMgr>.singleton.IsNeutral(e);
			if (flag)
			{
				XFightGroupDocument._fight_desc[(int)XFightGroupDocument._fightNeutral].ally.Remove(e);
			}
			else
			{
				uint num = 0U;
				while ((ulong)num < (ulong)((long)XFightGroupDocument._fight_desc.Length))
				{
					XFightGroupDocument._fight_desc[(int)num].ally.Remove(e);
					XFightGroupDocument._fight_desc[(int)num].oppo.Remove(e);
					num += 1U;
				}
				foreach (KeyValuePair<uint, XFightGroupDocument.FightGroupDesc> keyValuePair in XFightGroupDocument._fight_desc_map)
				{
					keyValuePair.Value.ally.Remove(e);
					keyValuePair.Value.oppo.Remove(e);
				}
			}
			foreach (KeyValuePair<uint, List<XEntity>> keyValuePair2 in XFightGroupDocument._fight_groups)
			{
				keyValuePair2.Value.Remove(e);
			}
		}

		public static bool IsNeutral(uint e)
		{
			return e == XFightGroupDocument._fightNeutral;
		}

		public static bool IsAlly(uint me, uint other)
		{
			return me != XFightGroupDocument._fightNeutral && other != XFightGroupDocument._fightNeutral && me == other && !XFightGroupDocument.LookUpTable(me, other);
		}

		public static bool IsOpponent(uint me, uint other)
		{
			return me != XFightGroupDocument._fightNeutral && other != XFightGroupDocument._fightNeutral && XFightGroupDocument.LookUpTable(me, other);
		}

		public static List<XEntity> GetOpponent(uint me)
		{
			return ((ulong)me < (ulong)((long)XFightGroupDocument._fight_desc.Length)) ? XFightGroupDocument._fight_desc[(int)me].oppo : (XFightGroupDocument._fight_desc_map.ContainsKey(me) ? XFightGroupDocument._fight_desc_map[me].oppo : XFightGroupDocument.EmptyEntityList);
		}

		public static List<XEntity> GetAlly(uint me)
		{
			return ((ulong)me < (ulong)((long)XFightGroupDocument._fight_desc.Length)) ? XFightGroupDocument._fight_desc[(int)me].ally : (XFightGroupDocument._fight_desc_map.ContainsKey(me) ? XFightGroupDocument._fight_desc_map[me].ally : XFightGroupDocument.EmptyEntityList);
		}

		public static List<XEntity> GetSpecificGroup(uint specific)
		{
			return XFightGroupDocument._fight_groups[specific];
		}

		public static List<XEntity> GetNeutral()
		{
			return XFightGroupDocument._fight_desc[(int)XFightGroupDocument._fightNeutral].ally;
		}

		private static bool LookUpTable(uint me, uint other)
		{
			bool flag = XFightGroupDocument._fight_desc.Length == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = (ulong)me >= (ulong)((long)XFightGroupDocument._fight_desc.Length) && (ulong)other >= (ulong)((long)XFightGroupDocument._fight_desc.Length);
				if (flag2)
				{
					result = (me != other);
				}
				else
				{
					bool flag3 = (ulong)me >= (ulong)((long)XFightGroupDocument._fight_desc.Length);
					if (flag3)
					{
						me = (uint)(XFightGroupDocument._fight_desc.Length - 1);
					}
					else
					{
						bool flag4 = (ulong)other >= (ulong)((long)XFightGroupDocument._fight_desc.Length);
						if (flag4)
						{
							other = (uint)(XFightGroupDocument._fight_desc.Length - 1);
						}
					}
					result = XFightGroupDocument.FightGroup[(int)me, (int)other];
				}
			}
			return result;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FightGroupDocument");

		public static readonly uint _fightNeutral = (uint)XFastEnumIntEqualityComparer<FightGroupType>.ToInt(FightGroupType.FightNeutral);

		public static readonly List<XEntity> EmptyEntityList = new List<XEntity>();

		public static bool[,] FightGroup = null;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static FightGroupTable _FightGroup = new FightGroupTable();

		private static XFightGroupDocument.FightGroupDesc[] _fight_desc = null;

		private static Dictionary<uint, XFightGroupDocument.FightGroupDesc> _fight_desc_map = new Dictionary<uint, XFightGroupDocument.FightGroupDesc>();

		private static Dictionary<uint, List<XEntity>> _fight_groups = new Dictionary<uint, List<XEntity>>();

		public struct FightGroupDesc
		{

			public List<XEntity> ally;

			public List<XEntity> oppo;
		}
	}
}
