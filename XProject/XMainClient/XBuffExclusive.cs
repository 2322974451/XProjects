using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DB0 RID: 3504
	internal struct XBuffExclusive
	{
		// Token: 0x0600BDE6 RID: 48614 RVA: 0x00277B24 File Offset: 0x00275D24
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

		// Token: 0x0600BDE7 RID: 48615 RVA: 0x00277C10 File Offset: 0x00275E10
		public bool CanAdd(byte clearType)
		{
			bool flag = this._ClearTypes == null;
			return flag || !this._ClearTypes.Contains(clearType);
		}

		// Token: 0x0600BDE8 RID: 48616 RVA: 0x00277C44 File Offset: 0x00275E44
		public bool IsSingleEffectConflict(XBuffExclusive other)
		{
			return XBuffExclusive._Overlaped(this._SingleEffects, other._SingleEffects);
		}

		// Token: 0x0600BDE9 RID: 48617 RVA: 0x00277C68 File Offset: 0x00275E68
		private static bool _Overlaped(HashSet<byte> left, HashSet<byte> right)
		{
			bool flag = left == null || right == null || left.Count == 0 || right.Count == 0;
			return !flag && left.Overlaps(right);
		}

		// Token: 0x0600BDEA RID: 48618 RVA: 0x00277CA4 File Offset: 0x00275EA4
		public bool ShouldClear(byte clearType)
		{
			return this.CanAdd(clearType);
		}

		// Token: 0x0600BDEB RID: 48619 RVA: 0x00277CC0 File Offset: 0x00275EC0
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

		// Token: 0x04004D84 RID: 19844
		private HashSet<byte> _ClearTypes;

		// Token: 0x04004D85 RID: 19845
		private HashSet<byte> _SingleEffects;
	}
}
