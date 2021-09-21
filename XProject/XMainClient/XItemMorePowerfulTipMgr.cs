using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E70 RID: 3696
	internal class XItemMorePowerfulTipMgr
	{
		// Token: 0x17003494 RID: 13460
		// (get) Token: 0x0600C5F2 RID: 50674 RVA: 0x002BD240 File Offset: 0x002BB440
		public bool bLoaded
		{
			get
			{
				return this.m_Tip != null;
			}
		}

		// Token: 0x0600C5F3 RID: 50675 RVA: 0x002BD25E File Offset: 0x002BB45E
		public void Load(string prefabName)
		{
			this._Load("UI/Common/" + prefabName);
		}

		// Token: 0x0600C5F4 RID: 50676 RVA: 0x002BD273 File Offset: 0x002BB473
		public void LoadFromUI(GameObject go)
		{
			this.m_Tip = go;
			this.m_bLoadFromUI = true;
		}

		// Token: 0x0600C5F5 RID: 50677 RVA: 0x002BD284 File Offset: 0x002BB484
		private void _Load(string prefab)
		{
			this._Destroy();
			this.m_Tip = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(prefab, true, false) as GameObject);
			this.m_bLoadFromUI = false;
		}

		// Token: 0x0600C5F6 RID: 50678 RVA: 0x002BD2B0 File Offset: 0x002BB4B0
		public void SetupPool(GameObject parent)
		{
			bool flag = this.m_Tip == null;
			if (flag)
			{
				this.Load("ItemMorePowerfulTip");
			}
			this.m_Pool.SetupPool(parent, this.m_Tip, 2U, false);
		}

		// Token: 0x0600C5F7 RID: 50679 RVA: 0x002BD2F0 File Offset: 0x002BB4F0
		private void _Destroy()
		{
			bool flag = !this.m_bLoadFromUI;
			if (flag)
			{
				XResourceLoaderMgr.SafeDestroy(ref this.m_Tip, true);
			}
			this.m_TipsDic.Clear();
		}

		// Token: 0x0600C5F8 RID: 50680 RVA: 0x002BD326 File Offset: 0x002BB526
		public void Unload()
		{
			this._Destroy();
		}

		// Token: 0x0600C5F9 RID: 50681 RVA: 0x002BD330 File Offset: 0x002BB530
		public void ReturnAll()
		{
			this.m_Pool.ReturnAll(false);
			this.m_TipsDic.Clear();
		}

		// Token: 0x0600C5FA RID: 50682 RVA: 0x002BD34C File Offset: 0x002BB54C
		public void ReturnInstance(IXUISprite bg)
		{
			GameObject go;
			bool flag = this.m_TipsDic.TryGetValue(bg, out go);
			if (flag)
			{
				this.m_Pool.ReturnInstance(go, false);
				this.m_TipsDic.Remove(bg);
			}
		}

		// Token: 0x0600C5FB RID: 50683 RVA: 0x002BD389 File Offset: 0x002BB589
		public void FakeReturnAll()
		{
			this.m_Pool.FakeReturnAll();
			this.m_TipsDic.Clear();
		}

		// Token: 0x0600C5FC RID: 50684 RVA: 0x002BD3A4 File Offset: 0x002BB5A4
		public void ActualReturnAll()
		{
			this.m_Pool.ActualReturnAll(false);
		}

		// Token: 0x0600C5FD RID: 50685 RVA: 0x002BD3B4 File Offset: 0x002BB5B4
		public GameObject SetTip(GameObject bg)
		{
			IXUISprite tip = bg.GetComponent("XUISprite") as IXUISprite;
			return this.SetTip(tip);
		}

		// Token: 0x0600C5FE RID: 50686 RVA: 0x002BD3E0 File Offset: 0x002BB5E0
		public GameObject SetTip(IXUISprite bg)
		{
			GameObject gameObject;
			bool flag = this.m_TipsDic.TryGetValue(bg, out gameObject);
			GameObject result;
			if (flag)
			{
				result = gameObject;
			}
			else
			{
				gameObject = this.m_Pool.FetchGameObject(false);
				gameObject.transform.parent = bg.gameObject.transform;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localScale = Vector3.one;
				gameObject.name = this.m_Tip.name;
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				bool flag2 = !this.m_bLoadFromUI;
				if (flag2)
				{
					ixuisprite.spriteDepth = bg.spriteDepth + this.DeltaDepth;
				}
				this.m_TipsDic.Add(bg, gameObject);
				result = gameObject;
			}
			return result;
		}

		// Token: 0x040056DA RID: 22234
		private XUIPool m_Pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040056DB RID: 22235
		private GameObject m_Tip = null;

		// Token: 0x040056DC RID: 22236
		private Dictionary<IXUISprite, GameObject> m_TipsDic = new Dictionary<IXUISprite, GameObject>();

		// Token: 0x040056DD RID: 22237
		private bool m_bLoadFromUI = false;

		// Token: 0x040056DE RID: 22238
		public int DeltaDepth = 60;
	}
}
