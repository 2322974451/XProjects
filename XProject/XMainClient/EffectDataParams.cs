using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B07 RID: 2823
	internal class EffectDataParams : XDataBase
	{
		// Token: 0x0600A653 RID: 42579 RVA: 0x001D3798 File Offset: 0x001D1998
		public EffectDataParams.TypeDataCollection GetCollection(CombatEffectType type)
		{
			EffectDataParams.TypeDataCollection result;
			this.type2DataMap.TryGetValue(type, out result);
			return result;
		}

		// Token: 0x0600A654 RID: 42580 RVA: 0x001D37BC File Offset: 0x001D19BC
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

		// Token: 0x0600A655 RID: 42581 RVA: 0x001D3804 File Offset: 0x001D1A04
		public override void Recycle()
		{
			base.Recycle();
			foreach (KeyValuePair<CombatEffectType, EffectDataParams.TypeDataCollection> keyValuePair in this.type2DataMap)
			{
				keyValuePair.Value.Recycle();
			}
			this.type2DataMap.Clear();
		}

		// Token: 0x04003D31 RID: 15665
		private Dictionary<CombatEffectType, EffectDataParams.TypeDataCollection> type2DataMap = new Dictionary<CombatEffectType, EffectDataParams.TypeDataCollection>(default(XFastEnumIntEqualityComparer<CombatEffectType>));

		// Token: 0x02001991 RID: 6545
		public class TypeDataCollection : XDataBase
		{
			// Token: 0x06011020 RID: 69664 RVA: 0x00453688 File Offset: 0x00451888
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

			// Token: 0x04007EFE RID: 32510
			public CombatEffectType type;

			// Token: 0x04007EFF RID: 32511
			public List<EffectDataParams.TypeData> datas = new List<EffectDataParams.TypeData>();
		}

		// Token: 0x02001992 RID: 6546
		public class TypeData : XDataBase
		{
			// Token: 0x06011022 RID: 69666 RVA: 0x004536F2 File Offset: 0x004518F2
			public override void Recycle()
			{
				base.Recycle();
				this.randomParams.Clear();
				this.constantParams.Clear();
				this.effectID = 0U;
				this.templatebuffID = 0U;
			}

			// Token: 0x04007F00 RID: 32512
			public uint effectID;

			// Token: 0x04007F01 RID: 32513
			public uint templatebuffID;

			// Token: 0x04007F02 RID: 32514
			public List<int> randomParams = new List<int>();

			// Token: 0x04007F03 RID: 32515
			public List<string> constantParams = new List<string>();
		}
	}
}
