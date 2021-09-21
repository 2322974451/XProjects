using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E6F RID: 3695
	internal class XItemSelector
	{
		// Token: 0x17003493 RID: 13459
		// (get) Token: 0x0600C5E8 RID: 50664 RVA: 0x002BCF00 File Offset: 0x002BB100
		public GameObject Effects
		{
			get
			{
				return this.m_Selecter;
			}
		}

		// Token: 0x0600C5E9 RID: 50665 RVA: 0x002BCF18 File Offset: 0x002BB118
		public XItemSelector(uint defaltWidth = 0U)
		{
			this.m_DefaultWidth = defaltWidth;
		}

		// Token: 0x0600C5EA RID: 50666 RVA: 0x002BCF56 File Offset: 0x002BB156
		public void Load(string prefabName)
		{
			this._Load("UI/Common/" + prefabName);
		}

		// Token: 0x0600C5EB RID: 50667 RVA: 0x002BCF6C File Offset: 0x002BB16C
		private void _Load(string prefab)
		{
			this._Destroy();
			this.m_Selecter = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(prefab, true, false) as GameObject);
			this.m_UIDummy = (this.m_Selecter.GetComponent("UIDummy") as IUIDummy);
			this.m_bLoadFromUI = false;
			this.m_Parent = XSingleton<XGameUI>.singleton.UIRoot;
		}

		// Token: 0x0600C5EC RID: 50668 RVA: 0x002BCFCC File Offset: 0x002BB1CC
		public void LoadFromUI(GameObject go, Transform parent)
		{
			this._Destroy();
			this.m_Selecter = go;
			this.m_UIDummy = (this.m_Selecter.GetComponent("UIDummy") as IUIDummy);
			this.m_bLoadFromUI = true;
			bool flag = parent != null;
			if (flag)
			{
				this.m_Parent = parent;
			}
			this.Hide();
		}

		// Token: 0x0600C5ED RID: 50669 RVA: 0x002BD024 File Offset: 0x002BB224
		private void _Destroy()
		{
			bool flag = this.m_Selecter != null;
			if (flag)
			{
				bool flag2 = !this.m_bLoadFromUI;
				if (flag2)
				{
					XResourceLoaderMgr.SafeDestroy(ref this.m_Selecter, true);
				}
				else
				{
					this.m_Selecter.transform.parent = this.m_Parent;
				}
				this.m_Selecter = null;
				this.m_UIDummy = null;
			}
		}

		// Token: 0x0600C5EE RID: 50670 RVA: 0x002BD087 File Offset: 0x002BB287
		public void Unload()
		{
			this._Destroy();
		}

		// Token: 0x0600C5EF RID: 50671 RVA: 0x002BD094 File Offset: 0x002BB294
		public void Select(GameObject bg)
		{
			bool flag = bg == null;
			if (!flag)
			{
				IXUISprite bg2 = bg.GetComponent("XUISprite") as IXUISprite;
				this.Select(bg2);
			}
		}

		// Token: 0x0600C5F0 RID: 50672 RVA: 0x002BD0C8 File Offset: 0x002BB2C8
		public void Select(IXUISprite bg)
		{
			bool flag = bg == null;
			if (!flag)
			{
				bool flag2 = this.m_Selecter == null;
				if (flag2)
				{
					this.Load("ItemSelector");
				}
				bool flag3 = this.m_Selecter == null;
				if (!flag3)
				{
					this.m_Selecter.SetActive(true);
					this.m_Selecter.transform.parent = bg.gameObject.transform;
					this.m_Selecter.transform.localPosition = Vector3.zero;
					bool flag4 = this.m_DefaultWidth > 0U;
					if (flag4)
					{
						float num = (float)bg.spriteWidth / this.m_DefaultWidth;
						this.m_Selecter.transform.localScale = new Vector3(num, num, num);
					}
					else
					{
						this.m_Selecter.transform.localScale = Vector3.one;
					}
					XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(this.m_Selecter);
					bool flag5 = !this.m_bLoadFromUI;
					if (flag5)
					{
						bool flag6 = this.m_UIDummy != null;
						if (flag6)
						{
							this.m_UIDummy.depth = bg.spriteDepth + this.DeltaDepth;
						}
					}
				}
			}
		}

		// Token: 0x0600C5F1 RID: 50673 RVA: 0x002BD1FC File Offset: 0x002BB3FC
		public void Hide()
		{
			bool flag = this.m_Selecter == null;
			if (!flag)
			{
				this.m_Selecter.transform.parent = this.m_Parent;
				this.m_Selecter.SetActive(false);
			}
		}

		// Token: 0x040056D4 RID: 22228
		private GameObject m_Selecter = null;

		// Token: 0x040056D5 RID: 22229
		private IUIDummy m_UIDummy = null;

		// Token: 0x040056D6 RID: 22230
		public int DeltaDepth = 50;

		// Token: 0x040056D7 RID: 22231
		private bool m_bLoadFromUI;

		// Token: 0x040056D8 RID: 22232
		private Transform m_Parent = XSingleton<XGameUI>.singleton.UIRoot;

		// Token: 0x040056D9 RID: 22233
		private uint m_DefaultWidth = 0U;
	}
}
