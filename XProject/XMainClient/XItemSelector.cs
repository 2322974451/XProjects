using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XItemSelector
	{

		public GameObject Effects
		{
			get
			{
				return this.m_Selecter;
			}
		}

		public XItemSelector(uint defaltWidth = 0U)
		{
			this.m_DefaultWidth = defaltWidth;
		}

		public void Load(string prefabName)
		{
			this._Load("UI/Common/" + prefabName);
		}

		private void _Load(string prefab)
		{
			this._Destroy();
			this.m_Selecter = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(prefab, true, false) as GameObject);
			this.m_UIDummy = (this.m_Selecter.GetComponent("UIDummy") as IUIDummy);
			this.m_bLoadFromUI = false;
			this.m_Parent = XSingleton<XGameUI>.singleton.UIRoot;
		}

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

		public void Unload()
		{
			this._Destroy();
		}

		public void Select(GameObject bg)
		{
			bool flag = bg == null;
			if (!flag)
			{
				IXUISprite bg2 = bg.GetComponent("XUISprite") as IXUISprite;
				this.Select(bg2);
			}
		}

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

		public void Hide()
		{
			bool flag = this.m_Selecter == null;
			if (!flag)
			{
				this.m_Selecter.transform.parent = this.m_Parent;
				this.m_Selecter.SetActive(false);
			}
		}

		private GameObject m_Selecter = null;

		private IUIDummy m_UIDummy = null;

		public int DeltaDepth = 50;

		private bool m_bLoadFromUI;

		private Transform m_Parent = XSingleton<XGameUI>.singleton.UIRoot;

		private uint m_DefaultWidth = 0U;
	}
}
