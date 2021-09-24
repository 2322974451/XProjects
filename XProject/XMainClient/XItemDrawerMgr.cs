using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XItemDrawerMgr : XSingleton<XItemDrawerMgr>
	{

		public void DrawItem(GameObject go, XItem item)
		{
			bool flag = item == null;
			if (flag)
			{
				this.normalItemDrawer.DrawItem(go, null, 0, false);
			}
			else
			{
				item.Description.ItemDrawer.DrawItem(go, item, false);
			}
		}

		public void Init(uint profession)
		{
			XItemDrawerParam.DefaultProfession = profession % 10U;
			XItemDrawerMgr.Param.Reset();
		}

		public GameObject GetGo(ItemCornerType type)
		{
			GameObject result;
			switch (type)
			{
			case ItemCornerType.LeftDown:
			{
				bool flag = this.LeftDownCornerGo == null;
				if (flag)
				{
					this.LeftDownCornerGo = this.Load("LeftDownCorner");
				}
				result = this.LeftDownCornerGo;
				break;
			}
			case ItemCornerType.LeftUp:
			{
				bool flag2 = this.LeftUpCornerGo == null;
				if (flag2)
				{
					this.LeftUpCornerGo = this.Load("LeftUpCorner");
				}
				result = this.LeftUpCornerGo;
				break;
			}
			case ItemCornerType.RightDown:
			{
				bool flag3 = this.RightDownCornerGo == null;
				if (flag3)
				{
					this.RightDownCornerGo = this.Load("RightDownCorner");
				}
				result = this.RightDownCornerGo;
				break;
			}
			case ItemCornerType.RightUp:
			{
				bool flag4 = this.RightUpCornerGo == null;
				if (flag4)
				{
					this.RightUpCornerGo = this.Load("RightUpCorner");
				}
				result = this.RightUpCornerGo;
				break;
			}
			case ItemCornerType.Center:
			{
				bool flag5 = this.MaskGo == null;
				if (flag5)
				{
					this.MaskGo = this.Load("Mask");
				}
				result = this.MaskGo;
				break;
			}
			case ItemCornerType.Prof:
			{
				bool flag6 = this.ProfGo == null;
				if (flag6)
				{
					this.ProfGo = this.Load("RightUpProf");
				}
				result = this.ProfGo;
				break;
			}
			default:
				XSingleton<XDebug>.singleton.AddErrorLog("type error", null, null, null, null, null);
				result = null;
				break;
			}
			return result;
		}

		private GameObject Load(string perfabName)
		{
			string location = XSingleton<XCommon>.singleton.StringCombine("UI/Common/", perfabName);
			GameObject gameObject = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(location, true, false) as GameObject;
			bool flag = gameObject == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("type error,perfabName = " + perfabName, null, null, null, null, null);
			}
			return gameObject;
		}

		public void OnleaveScene()
		{
			XResourceLoaderMgr.SafeDestroy(ref this.LeftDownCornerGo, true);
			XResourceLoaderMgr.SafeDestroy(ref this.LeftUpCornerGo, true);
			XResourceLoaderMgr.SafeDestroy(ref this.RightDownCornerGo, true);
			XResourceLoaderMgr.SafeDestroy(ref this.RightUpCornerGo, true);
			XResourceLoaderMgr.SafeDestroy(ref this.MaskGo, true);
			XResourceLoaderMgr.SafeDestroy(ref this.ProfGo, true);
		}

		public GameObject LeftDownCornerGo;

		public GameObject LeftUpCornerGo;

		public GameObject RightDownCornerGo;

		public GameObject RightUpCornerGo;

		public GameObject MaskGo;

		public GameObject ProfGo;

		public XNormalItemDrawer normalItemDrawer = new XNormalItemDrawer();

		public XEquipItemDrawer equipItemDrawer = new XEquipItemDrawer();

		public XJadeSlotDrawer jadeSlotDrawer = new XJadeSlotDrawer();

		public XJadeItemDrawer jadeItemDrawer = new XJadeItemDrawer();

		public XEmblemItemDrawer emblemItemDrawer = new XEmblemItemDrawer();

		public XFashionDrawer fashionDrawer = new XFashionDrawer();

		public static XItemDrawerParam Param = new XItemDrawerParam();
	}
}
