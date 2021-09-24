using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{

	public abstract class XRedpointRelationMgr : XRedpointDirtyMgr, IXRedpointRelationMgr
	{

		public void AddRelation(int child, int parent, bool bImmUpdateUI = false)
		{
			bool flag = child == 0;
			if (!flag)
			{
				bool flag2 = parent == 0;
				if (!flag2)
				{
					int[] array = null;
					bool flag3 = this.mChildParentRelationDic.TryGetValue(child, out array);
					if (flag3)
					{
						bool flag4 = this._InsertValue(ref array, parent);
						if (flag4)
						{
							this.mChildParentRelationDic[child] = array;
						}
					}
					else
					{
						array = new int[4];
						array[0] = parent;
						this.mChildParentRelationDic[child] = array;
					}
					int[] array2 = null;
					bool flag5 = this.mParentChildRelationDic.TryGetValue(parent, out array2);
					if (flag5)
					{
						bool flag6 = this._InsertValue(ref array2, child);
						if (flag6)
						{
							this.mParentChildRelationDic[parent] = array2;
						}
					}
					else
					{
						array2 = new int[4];
						array2[0] = child;
						this.mParentChildRelationDic[parent] = array2;
					}
					this.RecalculateRedPointSelfState(parent, bImmUpdateUI);
				}
			}
		}

		public void AddRelations(int child, int[] parents, bool bImmUpdateUI = false)
		{
			bool flag = child == 0;
			if (!flag)
			{
				bool flag2 = parents == null || parents.Length == 0;
				if (!flag2)
				{
					int[] value = null;
					bool flag3 = this.mChildParentRelationDic.TryGetValue(child, out value);
					if (!flag3)
					{
						value = new int[4];
						this.mChildParentRelationDic[child] = value;
					}
					for (int i = 0; i < parents.Length; i++)
					{
						bool flag4 = parents[i] != 0;
						if (flag4)
						{
							bool flag5 = this._InsertValue(ref value, parents[i]);
							if (flag5)
							{
								this.mChildParentRelationDic[child] = value;
							}
							int[] array = null;
							bool flag6 = this.mParentChildRelationDic.TryGetValue(parents[i], out array);
							if (flag6)
							{
								bool flag7 = this._InsertValue(ref array, child);
								if (flag7)
								{
									this.mParentChildRelationDic[parents[i]] = array;
								}
							}
							else
							{
								array = new int[4];
								array[0] = child;
								this.mParentChildRelationDic[parents[i]] = array;
							}
							this.RecalculateRedPointSelfState(parents[i], bImmUpdateUI);
						}
					}
				}
			}
		}

		public void RemoveRelation(int child, int parent, bool bImmUpdateUI = false)
		{
			bool flag = child == 0;
			if (!flag)
			{
				bool flag2 = parent == 0;
				if (!flag2)
				{
					int[] array = null;
					bool flag3 = this.mChildParentRelationDic.TryGetValue(child, out array);
					if (flag3)
					{
						this._DeleteValue(ref array, parent);
						bool flag4 = array[0] == 0;
						if (flag4)
						{
							this.mChildParentRelationDic.Remove(child);
						}
					}
					int[] array2 = null;
					bool flag5 = this.mParentChildRelationDic.TryGetValue(parent, out array2);
					if (flag5)
					{
						this._DeleteValue(ref array2, child);
						bool flag6 = array2[0] == 0;
						if (flag6)
						{
							this.mParentChildRelationDic.Remove(parent);
						}
					}
					this.RecalculateRedPointSelfState(parent, bImmUpdateUI);
				}
			}
		}

		public void RemoveRelations(int child, int[] parents, bool bImmUpdateUI = false)
		{
			bool flag = child == 0;
			if (!flag)
			{
				bool flag2 = parents == null || parents.Length == 0;
				if (!flag2)
				{
					int[] array = null;
					bool flag3 = this.mChildParentRelationDic.TryGetValue(child, out array);
					if (flag3)
					{
						for (int i = 0; i < parents.Length; i++)
						{
							bool flag4 = parents[i] != 0;
							if (flag4)
							{
								this._DeleteValue(ref array, parents[i]);
								bool flag5 = array[0] == 0;
								if (flag5)
								{
									this.mChildParentRelationDic.Remove(child);
								}
								int[] array2 = null;
								bool flag6 = this.mParentChildRelationDic.TryGetValue(parents[i], out array2);
								if (flag6)
								{
									this._DeleteValue(ref array2, child);
									bool flag7 = array2[0] == 0;
									if (flag7)
									{
										this.mParentChildRelationDic.Remove(parents[i]);
									}
								}
								this.RecalculateRedPointSelfState(parents[i], bImmUpdateUI);
							}
						}
					}
				}
			}
		}

		public void RemoveAllRelations(int child, bool bImmUpdateUI = false)
		{
			bool flag = child == 0;
			if (!flag)
			{
				int[] array = null;
				bool flag2 = this.mChildParentRelationDic.TryGetValue(child, out array);
				if (flag2)
				{
					for (int i = 0; i < array.Length; i++)
					{
						int[] array2 = null;
						bool flag3 = this.mParentChildRelationDic.TryGetValue(array[i], out array2);
						if (flag3)
						{
							this._DeleteValue(ref array2, child);
							bool flag4 = array2[0] == 0;
							if (flag4)
							{
								this.mParentChildRelationDic.Remove(array[i]);
							}
						}
						this.RecalculateRedPointSelfState(array[i], bImmUpdateUI);
					}
					this.mChildParentRelationDic.Remove(child);
				}
			}
		}

		public void ClearAllRelations(bool bImmUpdateUI = false)
		{
			foreach (int item in this.mParentChildRelationDic.Keys)
			{
				this.mDirtySysList.Add(item);
			}
			foreach (int key in this.mParentChildRelationDic.Keys)
			{
				this.mSysRedpointStateDic[key] = false;
			}
			this.mChildParentRelationDic.Clear();
			this.mParentChildRelationDic.Clear();
			if (bImmUpdateUI)
			{
				this.RefreshAllSysRedpoints();
			}
		}

		protected bool _InsertValue(ref int[] array, int value)
		{
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = array[i] == 0 || value == array[i];
				if (flag)
				{
					array[i] = value;
					return false;
				}
			}
			int[] array2 = new int[array.Length << 1];
			array.CopyTo(array2, 0);
			array2[array.Length] = value;
			array = array2;
			return true;
		}

		protected void _DeleteValue(ref int[] array, int parent)
		{
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = array[i] == parent;
				if (flag)
				{
					int num = 0;
					bool flag2 = i + 1 < array.Length;
					if (flag2)
					{
						for (int j = array.Length - 1; j > i; j--)
						{
							bool flag3 = array[j] != 0;
							if (flag3)
							{
								num = array[j];
								array[j] = 0;
								break;
							}
						}
					}
					array[i] = num;
					break;
				}
			}
		}

		public const int BASE_ARRAY_LENGTH = 4;

		public const int NULL_ID = 0;

		protected Dictionary<int, int[]> mChildParentRelationDic = new Dictionary<int, int[]>();

		protected Dictionary<int, int[]> mParentChildRelationDic = new Dictionary<int, int[]>();
	}
}
