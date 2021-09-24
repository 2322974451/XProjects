using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XItemMorePowerfulTipMgr
	{

		public bool bLoaded
		{
			get
			{
				return this.m_Tip != null;
			}
		}

		public void Load(string prefabName)
		{
			this._Load("UI/Common/" + prefabName);
		}

		public void LoadFromUI(GameObject go)
		{
			this.m_Tip = go;
			this.m_bLoadFromUI = true;
		}

		private void _Load(string prefab)
		{
			this._Destroy();
			this.m_Tip = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(prefab, true, false) as GameObject);
			this.m_bLoadFromUI = false;
		}

		public void SetupPool(GameObject parent)
		{
			bool flag = this.m_Tip == null;
			if (flag)
			{
				this.Load("ItemMorePowerfulTip");
			}
			this.m_Pool.SetupPool(parent, this.m_Tip, 2U, false);
		}

		private void _Destroy()
		{
			bool flag = !this.m_bLoadFromUI;
			if (flag)
			{
				XResourceLoaderMgr.SafeDestroy(ref this.m_Tip, true);
			}
			this.m_TipsDic.Clear();
		}

		public void Unload()
		{
			this._Destroy();
		}

		public void ReturnAll()
		{
			this.m_Pool.ReturnAll(false);
			this.m_TipsDic.Clear();
		}

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

		public void FakeReturnAll()
		{
			this.m_Pool.FakeReturnAll();
			this.m_TipsDic.Clear();
		}

		public void ActualReturnAll()
		{
			this.m_Pool.ActualReturnAll(false);
		}

		public GameObject SetTip(GameObject bg)
		{
			IXUISprite tip = bg.GetComponent("XUISprite") as IXUISprite;
			return this.SetTip(tip);
		}

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

		private XUIPool m_Pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private GameObject m_Tip = null;

		private Dictionary<IXUISprite, GameObject> m_TipsDic = new Dictionary<IXUISprite, GameObject>();

		private bool m_bLoadFromUI = false;

		public int DeltaDepth = 60;
	}
}
