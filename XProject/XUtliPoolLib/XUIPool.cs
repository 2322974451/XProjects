using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001D0 RID: 464
	public class XUIPool
	{
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000AB5 RID: 2741 RVA: 0x00039531 File Offset: 0x00037731
		// (set) Token: 0x06000AB6 RID: 2742 RVA: 0x00039539 File Offset: 0x00037739
		public int TplWidth { get; set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000AB7 RID: 2743 RVA: 0x00039542 File Offset: 0x00037742
		// (set) Token: 0x06000AB8 RID: 2744 RVA: 0x0003954A File Offset: 0x0003774A
		public int TplHeight { get; set; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000AB9 RID: 2745 RVA: 0x00039553 File Offset: 0x00037753
		// (set) Token: 0x06000ABA RID: 2746 RVA: 0x0003955B File Offset: 0x0003775B
		public Vector3 TplPos { get; set; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000ABB RID: 2747 RVA: 0x00039564 File Offset: 0x00037764
		public bool IsValid
		{
			get
			{
				return this._tpl != null;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000ABC RID: 2748 RVA: 0x00039584 File Offset: 0x00037784
		public int ActiveCount
		{
			get
			{
				return this._ActiveCount;
			}
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x0003959C File Offset: 0x0003779C
		public XUIPool(IXUITool uiTool)
		{
			this._uiTool = uiTool;
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x000395DC File Offset: 0x000377DC
		public void SetupPool(GameObject parent, GameObject tpl, uint Count, bool bEffectiveMode = true)
		{
			this._pool.Clear();
			this._used.Clear();
			this._ToBeRemoved.Clear();
			this._tpl = tpl;
			this._bEffectiveMode = bEffectiveMode;
			this._ActiveCount = 0;
			IXUISprite ixuisprite = this._tpl.GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = this._tpl.GetComponent("XUILabel") as IXUILabel;
			bool flag = ixuisprite != null;
			if (flag)
			{
				this.TplWidth = ixuisprite.spriteWidth;
				this.TplHeight = ixuisprite.spriteHeight;
			}
			else
			{
				bool flag2 = ixuilabel != null;
				if (flag2)
				{
					this.TplWidth = ixuilabel.spriteWidth;
					this.TplHeight = ixuilabel.spriteHeight;
				}
				else
				{
					this.TplWidth = 0;
					this.TplHeight = 0;
				}
			}
			bool flag3 = !bEffectiveMode;
			if (flag3)
			{
				this.ReturnAllDisable();
			}
			this.TplPos = this._tpl.transform.localPosition;
			Transform parent2 = (parent == null) ? this._tpl.transform.parent : parent.transform;
			int num = 0;
			while ((long)num < (long)((ulong)Count))
			{
				GameObject gameObject = XCommon.Instantiate<GameObject>(this._tpl);
				gameObject.transform.parent = parent2;
				gameObject.transform.localScale = Vector3.one;
				gameObject.name = "item" + num;
				bool bEffectiveMode2 = this._bEffectiveMode;
				if (bEffectiveMode2)
				{
					gameObject.transform.localPosition = Vector3.one * (float)XUIPool._far_far_away;
				}
				else
				{
					gameObject.transform.localPosition = this._tpl.transform.localPosition;
					this.MakeGameObjectEnabled(gameObject, false);
				}
				this._pool.Add(gameObject);
				this._used.Add(false);
				num++;
			}
			bool bEffectiveMode3 = this._bEffectiveMode;
			if (bEffectiveMode3)
			{
				this._tpl.transform.parent = parent2;
				this._tpl.transform.localPosition = Vector3.one * (float)XUIPool._far_far_away;
			}
			else
			{
				this._tpl.transform.parent = parent2;
				this.MakeGameObjectEnabled(this._tpl, false);
			}
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x00039838 File Offset: 0x00037A38
		public GameObject FetchGameObject(bool fadeIn = false)
		{
			this._ActiveCount++;
			bool flag = this._ToBeRemoved.Count > 0;
			GameObject result;
			if (flag)
			{
				int index = this._ToBeRemoved.Pop();
				this.CheckFadeIn(fadeIn, this._pool[index]);
				result = this._pool[index];
			}
			else
			{
				for (int i = 0; i < this._pool.Count; i++)
				{
					bool flag2 = !this._used[i];
					if (flag2)
					{
						bool flag3 = !this._bEffectiveMode;
						if (flag3)
						{
							this.MakeGameObjectEnabled(this._pool[i], true);
						}
						this._used[i] = true;
						this.CheckFadeIn(fadeIn, this._pool[i]);
						return this._pool[i];
					}
				}
				int count = this._pool.Count;
				bool flag4 = !this._bEffectiveMode;
				if (flag4)
				{
					this.MakeGameObjectEnabled(this._tpl, true);
				}
				for (int j = 0; j < (count + 1) / 2; j++)
				{
					GameObject gameObject = XCommon.Instantiate<GameObject>(this._tpl);
					gameObject.transform.parent = this._tpl.transform.parent;
					gameObject.transform.localScale = Vector3.one;
					gameObject.name = "item" + this._pool.Count;
					bool bEffectiveMode = this._bEffectiveMode;
					if (bEffectiveMode)
					{
						gameObject.transform.localPosition = Vector3.one * (float)XUIPool._far_far_away;
					}
					else
					{
						gameObject.transform.localPosition = this._tpl.transform.localPosition;
						this.MakeGameObjectEnabled(gameObject, false);
					}
					this._pool.Add(gameObject);
					this._used.Add(false);
				}
				bool flag5 = !this._bEffectiveMode;
				if (flag5)
				{
					this.MakeGameObjectEnabled(this._tpl, false);
				}
				this._used[count] = true;
				this.MakeGameObjectEnabled(this._pool[count], true);
				this.CheckFadeIn(fadeIn, this._pool[count]);
				result = this._pool[count];
			}
			return result;
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x00039AB0 File Offset: 0x00037CB0
		private void CheckFadeIn(bool fadeIn, GameObject go)
		{
			bool flag = !fadeIn;
			if (!flag)
			{
				IXTweenFadeIn ixtweenFadeIn = go.GetComponent("TweenFadeIn") as IXTweenFadeIn;
				bool flag2 = ixtweenFadeIn == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Tpl haven't FadeIn Component but Fetch try to get it.", null, null, null, null, null);
				}
				else
				{
					ixtweenFadeIn.PlayFadeIn();
				}
			}
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x00039B00 File Offset: 0x00037D00
		public void FakeReturnAll()
		{
			this._ToBeRemoved.Clear();
			for (int i = this._used.Count - 1; i >= 0; i--)
			{
				bool flag = this._used[i];
				if (flag)
				{
					this._ToBeRemoved.Push(i);
				}
			}
			this._ActiveCount = 0;
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x00039B60 File Offset: 0x00037D60
		public void ActualReturnAll(bool bChangeParent = false)
		{
			while (this._ToBeRemoved.Count > 0)
			{
				int index = this._ToBeRemoved.Pop();
				this._DisableGameObject(this._pool[index], bChangeParent);
				this._used[index] = false;
			}
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x00039BB4 File Offset: 0x00037DB4
		public void ReturnAll(bool bChangeParent = false)
		{
			for (int i = 0; i < this._pool.Count; i++)
			{
				GameObject go = this._pool[i];
				this._DisableGameObject(go, bChangeParent);
			}
			for (int j = 0; j < this._used.Count; j++)
			{
				this._used[j] = false;
			}
			this._ActiveCount = 0;
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00039C28 File Offset: 0x00037E28
		public void ReturnAllDisable()
		{
			for (int i = 0; i < this._pool.Count; i++)
			{
				bool flag = !this._pool[i].activeSelf;
				if (flag)
				{
					bool flag2 = i < this._used.Count;
					if (flag2)
					{
						this._used[i] = false;
					}
					this._ActiveCount--;
				}
			}
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x00039C9C File Offset: 0x00037E9C
		public void ReturnInstance(GameObject go, bool bChangeParent = false)
		{
			this._DisableGameObject(go, bChangeParent);
			int num = -1;
			for (int i = 0; i < this._pool.Count; i++)
			{
				bool flag = this._pool[i] == go;
				if (flag)
				{
					num = i;
					break;
				}
			}
			bool flag2 = num > -1 && num < this._used.Count;
			if (flag2)
			{
				this._used[num] = false;
			}
			this._ActiveCount--;
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x00039D24 File Offset: 0x00037F24
		public void ReturnAny(int count, bool bChangeParent = false)
		{
			int num = 0;
			while (num < this._pool.Count && count > 0)
			{
				bool flag = this._used[num];
				if (flag)
				{
					this._used[num] = false;
					this._DisableGameObject(this._pool[num], bChangeParent);
					this._ActiveCount--;
					count--;
				}
				num++;
			}
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x00039D9C File Offset: 0x00037F9C
		private void _DisableGameObject(GameObject go, bool bChangeParent)
		{
			if (bChangeParent)
			{
				go.transform.parent = this._tpl.transform.parent;
			}
			bool bEffectiveMode = this._bEffectiveMode;
			if (bEffectiveMode)
			{
				go.transform.localPosition = Vector3.one * (float)XUIPool._far_far_away;
			}
			else
			{
				this.MakeGameObjectEnabled(go, false);
			}
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x00039E00 File Offset: 0x00038000
		public void GetActiveList(List<GameObject> ret)
		{
			int i = 0;
			int count = this._pool.Count;
			while (i < count)
			{
				GameObject gameObject = this._pool[i];
				bool bEffectiveMode = this._bEffectiveMode;
				if (bEffectiveMode)
				{
					bool flag = gameObject.transform.localPosition.x < (float)XUIPool._far_far_away;
					if (flag)
					{
						ret.Add(gameObject);
					}
				}
				else
				{
					bool activeInHierarchy = gameObject.activeInHierarchy;
					if (activeInHierarchy)
					{
						ret.Add(gameObject);
					}
				}
				i++;
			}
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x00039E89 File Offset: 0x00038089
		protected void MakeGameObjectEnabled(GameObject go, bool enabled)
		{
			go.SetActive(enabled);
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x00039E94 File Offset: 0x00038094
		public void PlayFadeInWithActiveList()
		{
			List<GameObject> list = ListPool<GameObject>.Get();
			this.GetActiveList(list);
			bool flag = list.Count != 0;
			if (flag)
			{
				IXTweenFadeIn ixtweenFadeIn = list[0].GetComponent("TweenFadeIn") as IXTweenFadeIn;
				bool flag2 = ixtweenFadeIn == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Tpl ActiveList haven't FadeIn Component but Fetch try to get it.", null, null, null, null, null);
				}
				else
				{
					ixtweenFadeIn.ResetGroupDelay();
					for (int i = 0; i < list.Count; i++)
					{
						this.CheckFadeIn(true, list[i]);
					}
				}
			}
			ListPool<GameObject>.Release(list);
		}

		// Token: 0x04000518 RID: 1304
		public static int _far_far_away = 1000;

		// Token: 0x04000519 RID: 1305
		public GameObject _tpl;

		// Token: 0x0400051A RID: 1306
		protected List<GameObject> _pool = new List<GameObject>();

		// Token: 0x0400051B RID: 1307
		protected List<bool> _used = new List<bool>();

		// Token: 0x0400051C RID: 1308
		protected Stack<int> _ToBeRemoved = new Stack<int>();

		// Token: 0x0400051D RID: 1309
		protected bool _bEffectiveMode = true;

		// Token: 0x0400051E RID: 1310
		public IXUITool _uiTool = null;

		// Token: 0x04000522 RID: 1314
		private int _ActiveCount;
	}
}
