using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal struct XBuffExclusive
	{

		public void Set(BuffTable.RowData rowData)
		{
			bool flag = rowData == null;
			if (!flag)
			{
				bool flag2 = rowData.ClearTypes != null && rowData.ClearTypes.Length != 0;
				if (flag2)
				{
					this._ClearTypes = HashPool<byte>.Get();
					for (int i = 0; i < rowData.ClearTypes.Length; i++)
					{
						this._ClearTypes.Add(rowData.ClearTypes[i]);
					}
				}
				bool flag3 = rowData.BuffState != null && rowData.BuffState.Length != 0;
				if (flag3)
				{
					this._SingleEffects = HashPool<byte>.Get();
					for (int j = 0; j < rowData.BuffState.Length; j++)
					{
						XBuffType xbuffType = (XBuffType)rowData.BuffState[j];
						if (xbuffType == XBuffType.XBuffType_Transform || xbuffType == XBuffType.XBuffType_Scale)
						{
							this._SingleEffects.Add(rowData.BuffState[j]);
						}
					}
				}
			}
		}

		public bool CanAdd(byte clearType)
		{
			bool flag = this._ClearTypes == null;
			return flag || !this._ClearTypes.Contains(clearType);
		}

		public bool IsSingleEffectConflict(XBuffExclusive other)
		{
			return XBuffExclusive._Overlaped(this._SingleEffects, other._SingleEffects);
		}

		private static bool _Overlaped(HashSet<byte> left, HashSet<byte> right)
		{
			bool flag = left == null || right == null || left.Count == 0 || right.Count == 0;
			return !flag && left.Overlaps(right);
		}

		public bool ShouldClear(byte clearType)
		{
			return this.CanAdd(clearType);
		}

		public void Destroy()
		{
			bool flag = this._ClearTypes != null;
			if (flag)
			{
				HashPool<byte>.Release(this._ClearTypes);
				this._ClearTypes = null;
			}
			bool flag2 = this._SingleEffects != null;
			if (flag2)
			{
				HashPool<byte>.Release(this._SingleEffects);
				this._SingleEffects = null;
			}
		}

		private HashSet<byte> _ClearTypes;

		private HashSet<byte> _SingleEffects;
	}
}
