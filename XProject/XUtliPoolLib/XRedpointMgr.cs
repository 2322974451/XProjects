using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001B7 RID: 439
	public class XRedpointMgr : XRedpointForbidMgr, IXRedpointMgr, IXRedpointRelationMgr, IXRedpointForbidMgr
	{
		// Token: 0x060009DA RID: 2522 RVA: 0x00033870 File Offset: 0x00031A70
		public void AddSysRedpointUI(int sys, GameObject go, SetRedpointUIHandler callback = null)
		{
			bool flag = null == go;
			if (!flag)
			{
				XRedpointMgr.stRedpointGameObject[] array = null;
				bool flag2 = this.mSysGameObjectListDic.TryGetValue(sys, out array);
				if (flag2)
				{
					bool flag3 = this._InsertObject(ref array, go, callback);
					if (flag3)
					{
						this.mSysGameObjectListDic[sys] = array;
					}
				}
				else
				{
					array = new XRedpointMgr.stRedpointGameObject[4];
					array[0].go = go;
					array[0].callback = callback;
					this.mSysGameObjectListDic[sys] = array;
				}
				go.SetActive(base._GetSysRedpointState(sys));
			}
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x00033900 File Offset: 0x00031B00
		public void RemoveSysRedpointUI(int sys, GameObject go)
		{
			bool flag = null == go;
			if (!flag)
			{
				XRedpointMgr.stRedpointGameObject[] array = null;
				bool flag2 = this.mSysGameObjectListDic.TryGetValue(sys, out array);
				if (flag2)
				{
					this._DeleteObject(ref array, go);
				}
			}
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x0003393B File Offset: 0x00031B3B
		public void RemoveAllSysRedpointsUI(int sys)
		{
			this.mSysGameObjectListDic.Remove(sys);
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x0003394B File Offset: 0x00031B4B
		public void ClearAllSysRedpointsUI()
		{
			this.mSysGameObjectListDic.Clear();
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x0003395C File Offset: 0x00031B5C
		public void SetSysRedpointState(int sys, bool redpoint, bool immediately = false)
		{
			bool flag = true;
			bool flag3;
			bool flag2 = this.mSysRedpointStateDic.TryGetValue(sys, out flag3);
			if (flag2)
			{
				flag = (flag3 != redpoint);
			}
			this.mSysRedpointStateDic[sys] = redpoint;
			bool flag4 = flag;
			if (flag4)
			{
				if (immediately)
				{
					this._RefreshSysRedpointUI(sys, redpoint);
					this._RecalculateRedPointParentStates(sys, immediately);
				}
				else
				{
					this.mDirtySysList.Add(sys);
				}
			}
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x000339C8 File Offset: 0x00031BC8
		public override void RefreshAllSysRedpoints()
		{
			foreach (int sys in this.mDirtySysList)
			{
				this._RefreshSysRedpointUI(sys, base._GetSysRedpointState(sys));
			}
			this.mDirtySysList.Clear();
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x00033A34 File Offset: 0x00031C34
		public override void RecalculateRedPointSelfState(int sys, bool bImmUpdateUI = true)
		{
			bool flag = false;
			int[] array = null;
			bool flag2 = this.mParentChildRelationDic.TryGetValue(sys, out array);
			if (flag2)
			{
				int num = 0;
				while (num < array.Length && array[num] == 0 && !flag)
				{
					flag = (flag || base._GetSysRedpointState(array[num]));
					num++;
				}
			}
			bool flag3 = flag != base._GetSysRedpointState(sys);
			if (flag3)
			{
				this.mSysRedpointStateDic[sys] = flag;
				if (bImmUpdateUI)
				{
					this._RefreshSysRedpointUI(sys, flag);
				}
				else
				{
					this.mDirtySysList.Add(sys);
				}
			}
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x00033AD0 File Offset: 0x00031CD0
		protected void _RecalculateRedPointParentStates(int child, bool bImmUpdateUI = true)
		{
			bool flag = base._GetSysRedpointState(child);
			bool flag2 = flag;
			if (flag2)
			{
				int[] array = null;
				bool flag3 = this.mChildParentRelationDic.TryGetValue(child, out array);
				if (flag3)
				{
					int num = 0;
					while (num < array.Length && array[num] != 0)
					{
						this.SetSysRedpointState(array[num], true, bImmUpdateUI);
						num++;
					}
				}
			}
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x00033B34 File Offset: 0x00031D34
		protected override void _RefreshSysRedpointUI(int sys, bool redpoint)
		{
			bool flag = redpoint;
			if (flag)
			{
				bool flag2 = this.mForbidHashSet.Contains(sys);
				if (flag2)
				{
					redpoint = false;
				}
			}
			XRedpointMgr.stRedpointGameObject[] array = null;
			bool flag3 = this.mSysGameObjectListDic.TryGetValue(sys, out array);
			if (flag3)
			{
				int num = 0;
				while (num < array.Length && null != array[num].go)
				{
					bool flag4 = array[num].callback == null;
					if (flag4)
					{
						array[num].go.SetActive(redpoint);
					}
					else
					{
						array[num].callback(array[num].go);
					}
					num++;
				}
			}
			this.mDirtySysList.Remove(sys);
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x00033BFC File Offset: 0x00031DFC
		protected bool _InsertObject(ref XRedpointMgr.stRedpointGameObject[] array, GameObject go, SetRedpointUIHandler callback)
		{
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = null == array[i].go || array[i].go == go;
				if (flag)
				{
					array[i].go = go;
					array[i].callback = callback;
					return false;
				}
			}
			XRedpointMgr.stRedpointGameObject[] array2 = new XRedpointMgr.stRedpointGameObject[array.Length << 1];
			array.CopyTo(array2, 0);
			array2[array.Length].go = go;
			array2[array.Length].callback = callback;
			array = array2;
			return true;
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x00033CB0 File Offset: 0x00031EB0
		protected void _DeleteObject(ref XRedpointMgr.stRedpointGameObject[] array, GameObject parent)
		{
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = array[i].go == parent;
				if (flag)
				{
					XRedpointMgr.stRedpointGameObject stRedpointGameObject = default(XRedpointMgr.stRedpointGameObject);
					bool flag2 = i + 1 < array.Length;
					if (flag2)
					{
						for (int j = array.Length - 1; j > i; j--)
						{
							bool flag3 = null != array[j].go;
							if (flag3)
							{
								stRedpointGameObject = array[j];
								array[j] = default(XRedpointMgr.stRedpointGameObject);
								break;
							}
						}
					}
					array[i] = stRedpointGameObject;
				}
			}
		}

		// Token: 0x040004AC RID: 1196
		protected Dictionary<int, XRedpointMgr.stRedpointGameObject[]> mSysGameObjectListDic = new Dictionary<int, XRedpointMgr.stRedpointGameObject[]>();

		// Token: 0x02000396 RID: 918
		protected struct stRedpointGameObject
		{
			// Token: 0x04000FE1 RID: 4065
			public static readonly XRedpointMgr.stRedpointGameObject Empty;

			// Token: 0x04000FE2 RID: 4066
			public GameObject go;

			// Token: 0x04000FE3 RID: 4067
			public SetRedpointUIHandler callback;
		}
	}
}
