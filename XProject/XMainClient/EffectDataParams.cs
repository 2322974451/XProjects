using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EffectDataParams : XDataBase
	{

		public EffectDataParams.TypeDataCollection GetCollection(CombatEffectType type)
		{
			EffectDataParams.TypeDataCollection result;
			this.type2DataMap.TryGetValue(type, out result);
			return result;
		}

		public EffectDataParams.TypeDataCollection EnsureGetCollection(CombatEffectType type)
		{
			EffectDataParams.TypeDataCollection data;
			bool flag = !this.type2DataMap.TryGetValue(type, out data);
			if (flag)
			{
				data = XDataPool<EffectDataParams.TypeDataCollection>.GetData();
				data.type = type;
				this.type2DataMap[type] = data;
			}
			return data;
		}

		public override void Recycle()
		{
			base.Recycle();
			foreach (KeyValuePair<CombatEffectType, EffectDataParams.TypeDataCollection> keyValuePair in this.type2DataMap)
			{
				keyValuePair.Value.Recycle();
			}
			this.type2DataMap.Clear();
		}

		private Dictionary<CombatEffectType, EffectDataParams.TypeDataCollection> type2DataMap = new Dictionary<CombatEffectType, EffectDataParams.TypeDataCollection>(default(XFastEnumIntEqualityComparer<CombatEffectType>));

		public class TypeDataCollection : XDataBase
		{

			public override void Recycle()
			{
				base.Recycle();
				for (int i = 0; i < this.datas.Count; i++)
				{
					this.datas[i].Recycle();
				}
				this.datas.Clear();
				this.type = CombatEffectType.CET_INVALID;
			}

			public CombatEffectType type;

			public List<EffectDataParams.TypeData> datas = new List<EffectDataParams.TypeData>();
		}

		public class TypeData : XDataBase
		{

			public override void Recycle()
			{
				base.Recycle();
				this.randomParams.Clear();
				this.constantParams.Clear();
				this.effectID = 0U;
				this.templatebuffID = 0U;
			}

			public uint effectID;

			public uint templatebuffID;

			public List<int> randomParams = new List<int>();

			public List<string> constantParams = new List<string>();
		}
	}
}
