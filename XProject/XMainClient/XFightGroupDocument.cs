using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000996 RID: 2454
	internal class XFightGroupDocument : XComponent
	{
		// Token: 0x17002CD1 RID: 11473
		// (get) Token: 0x060093E1 RID: 37857 RVA: 0x0015B158 File Offset: 0x00159358
		public override uint ID
		{
			get
			{
				return XFightGroupDocument.uuID;
			}
		}

		// Token: 0x060093E2 RID: 37858 RVA: 0x0015B16F File Offset: 0x0015936F
		public static void Execute(OnLoadedCallback callback = null)
		{
			XFightGroupDocument.AsyncLoader.AddTask("Table/FightGroup", XFightGroupDocument._FightGroup, false);
			XFightGroupDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060093E3 RID: 37859 RVA: 0x0015B194 File Offset: 0x00159394
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

		// Token: 0x060093E4 RID: 37860 RVA: 0x0015B2CC File Offset: 0x001594CC
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

		// Token: 0x060093E5 RID: 37861 RVA: 0x0015B380 File Offset: 0x00159580
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

		// Token: 0x060093E6 RID: 37862 RVA: 0x0015B548 File Offset: 0x00159748
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

		// Token: 0x060093E7 RID: 37863 RVA: 0x0015B688 File Offset: 0x00159888
		public static bool IsNeutral(uint e)
		{
			return e == XFightGroupDocument._fightNeutral;
		}

		// Token: 0x060093E8 RID: 37864 RVA: 0x0015B6A4 File Offset: 0x001598A4
		public static bool IsAlly(uint me, uint other)
		{
			return me != XFightGroupDocument._fightNeutral && other != XFightGroupDocument._fightNeutral && me == other && !XFightGroupDocument.LookUpTable(me, other);
		}

		// Token: 0x060093E9 RID: 37865 RVA: 0x0015B6DC File Offset: 0x001598DC
		public static bool IsOpponent(uint me, uint other)
		{
			return me != XFightGroupDocument._fightNeutral && other != XFightGroupDocument._fightNeutral && XFightGroupDocument.LookUpTable(me, other);
		}

		// Token: 0x060093EA RID: 37866 RVA: 0x0015B708 File Offset: 0x00159908
		public static List<XEntity> GetOpponent(uint me)
		{
			return ((ulong)me < (ulong)((long)XFightGroupDocument._fight_desc.Length)) ? XFightGroupDocument._fight_desc[(int)me].oppo : (XFightGroupDocument._fight_desc_map.ContainsKey(me) ? XFightGroupDocument._fight_desc_map[me].oppo : XFightGroupDocument.EmptyEntityList);
		}

		// Token: 0x060093EB RID: 37867 RVA: 0x0015B75C File Offset: 0x0015995C
		public static List<XEntity> GetAlly(uint me)
		{
			return ((ulong)me < (ulong)((long)XFightGroupDocument._fight_desc.Length)) ? XFightGroupDocument._fight_desc[(int)me].ally : (XFightGroupDocument._fight_desc_map.ContainsKey(me) ? XFightGroupDocument._fight_desc_map[me].ally : XFightGroupDocument.EmptyEntityList);
		}

		// Token: 0x060093EC RID: 37868 RVA: 0x0015B7B0 File Offset: 0x001599B0
		public static List<XEntity> GetSpecificGroup(uint specific)
		{
			return XFightGroupDocument._fight_groups[specific];
		}

		// Token: 0x060093ED RID: 37869 RVA: 0x0015B7D0 File Offset: 0x001599D0
		public static List<XEntity> GetNeutral()
		{
			return XFightGroupDocument._fight_desc[(int)XFightGroupDocument._fightNeutral].ally;
		}

		// Token: 0x060093EE RID: 37870 RVA: 0x0015B7F8 File Offset: 0x001599F8
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

		// Token: 0x040031B5 RID: 12725
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FightGroupDocument");

		// Token: 0x040031B6 RID: 12726
		public static readonly uint _fightNeutral = (uint)XFastEnumIntEqualityComparer<FightGroupType>.ToInt(FightGroupType.FightNeutral);

		// Token: 0x040031B7 RID: 12727
		public static readonly List<XEntity> EmptyEntityList = new List<XEntity>();

		// Token: 0x040031B8 RID: 12728
		public static bool[,] FightGroup = null;

		// Token: 0x040031B9 RID: 12729
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040031BA RID: 12730
		private static FightGroupTable _FightGroup = new FightGroupTable();

		// Token: 0x040031BB RID: 12731
		private static XFightGroupDocument.FightGroupDesc[] _fight_desc = null;

		// Token: 0x040031BC RID: 12732
		private static Dictionary<uint, XFightGroupDocument.FightGroupDesc> _fight_desc_map = new Dictionary<uint, XFightGroupDocument.FightGroupDesc>();

		// Token: 0x040031BD RID: 12733
		private static Dictionary<uint, List<XEntity>> _fight_groups = new Dictionary<uint, List<XEntity>>();

		// Token: 0x02001969 RID: 6505
		public struct FightGroupDesc
		{
			// Token: 0x04007E1C RID: 32284
			public List<XEntity> ally;

			// Token: 0x04007E1D RID: 32285
			public List<XEntity> oppo;
		}
	}
}
