using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F07 RID: 3847
	internal class XItemDrawerMgr : XSingleton<XItemDrawerMgr>
	{
		// Token: 0x0600CC3A RID: 52282 RVA: 0x002EF310 File Offset: 0x002ED510
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

		// Token: 0x0600CC3B RID: 52283 RVA: 0x002EF34D File Offset: 0x002ED54D
		public void Init(uint profession)
		{
			XItemDrawerParam.DefaultProfession = profession % 10U;
			XItemDrawerMgr.Param.Reset();
		}

		// Token: 0x0600CC3C RID: 52284 RVA: 0x002EF364 File Offset: 0x002ED564
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

		// Token: 0x0600CC3D RID: 52285 RVA: 0x002EF4C0 File Offset: 0x002ED6C0
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

		// Token: 0x0600CC3E RID: 52286 RVA: 0x002EF520 File Offset: 0x002ED720
		public void OnleaveScene()
		{
			XResourceLoaderMgr.SafeDestroy(ref this.LeftDownCornerGo, true);
			XResourceLoaderMgr.SafeDestroy(ref this.LeftUpCornerGo, true);
			XResourceLoaderMgr.SafeDestroy(ref this.RightDownCornerGo, true);
			XResourceLoaderMgr.SafeDestroy(ref this.RightUpCornerGo, true);
			XResourceLoaderMgr.SafeDestroy(ref this.MaskGo, true);
			XResourceLoaderMgr.SafeDestroy(ref this.ProfGo, true);
		}

		// Token: 0x04005ACB RID: 23243
		public GameObject LeftDownCornerGo;

		// Token: 0x04005ACC RID: 23244
		public GameObject LeftUpCornerGo;

		// Token: 0x04005ACD RID: 23245
		public GameObject RightDownCornerGo;

		// Token: 0x04005ACE RID: 23246
		public GameObject RightUpCornerGo;

		// Token: 0x04005ACF RID: 23247
		public GameObject MaskGo;

		// Token: 0x04005AD0 RID: 23248
		public GameObject ProfGo;

		// Token: 0x04005AD1 RID: 23249
		public XNormalItemDrawer normalItemDrawer = new XNormalItemDrawer();

		// Token: 0x04005AD2 RID: 23250
		public XEquipItemDrawer equipItemDrawer = new XEquipItemDrawer();

		// Token: 0x04005AD3 RID: 23251
		public XJadeSlotDrawer jadeSlotDrawer = new XJadeSlotDrawer();

		// Token: 0x04005AD4 RID: 23252
		public XJadeItemDrawer jadeItemDrawer = new XJadeItemDrawer();

		// Token: 0x04005AD5 RID: 23253
		public XEmblemItemDrawer emblemItemDrawer = new XEmblemItemDrawer();

		// Token: 0x04005AD6 RID: 23254
		public XFashionDrawer fashionDrawer = new XFashionDrawer();

		// Token: 0x04005AD7 RID: 23255
		public static XItemDrawerParam Param = new XItemDrawerParam();
	}
}
