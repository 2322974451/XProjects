using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	public class XMainSubstance
	{

		public void Setup(GameObject go)
		{
			this.gameObject = go;
		}

		public void SetupSubstance(XSysDefine define, int showCount, int index = 0)
		{
			this._systemID = define;
			this._count = showCount;
			this._index = index;
			this.Refresh();
		}

		public void Release()
		{
			this.DeleteXFX();
		}

		public void Recycle()
		{
			this._count = 0;
			this._index = 0;
			this.DeleteXFX();
			this.gameObject.SetActive(false);
		}

		private void Refresh()
		{
			this.gameObject.SetActive(true);
			OpenSystemTable.RowData systemOpen = XSingleton<XGameSysMgr>.singleton.GetSystemOpen(this._systemID);
			Transform transform = this.gameObject.transform.Find("Member");
			IXUILabel ixuilabel = this.gameObject.transform.Find("Member/Num").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = this.gameObject.transform.Find("Invatation").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = this.gameObject.transform.Find("Name").GetComponent("XUISprite") as IXUISprite;
			IXUIButton ixuibutton = this.gameObject.transform.GetComponent("XUIButton") as IXUIButton;
			Transform transform2 = this.gameObject.transform.Find("effect");
			bool flag = this._count > 0;
			if (flag)
			{
				transform.gameObject.SetActive(true);
				ixuilabel.SetText(this._count.ToString());
			}
			else
			{
				transform.gameObject.SetActive(false);
			}
			bool flag2 = this._index < systemOpen.NoticeText.Count;
			if (flag2)
			{
				ixuisprite2.SetSprite(systemOpen.NoticeText[this._index, 1], systemOpen.NoticeText[this._index, 0], false);
			}
			else
			{
				ixuisprite2.SetSprite("");
			}
			ixuisprite2.MakePixelPerfect();
			bool flag3 = this._index < systemOpen.NoticeIcon.Count;
			if (flag3)
			{
				ixuisprite.SetSprite(systemOpen.NoticeIcon[this._index, 1], systemOpen.NoticeIcon[this._index, 0], false);
			}
			else
			{
				ixuisprite.SetSprite("");
			}
			ixuisprite.MakePixelPerfect();
			ixuibutton.ID = (ulong)((long)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this._systemID));
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.OnSysIconClicked));
			bool flag4 = systemOpen.NoticeEffect != null && systemOpen.NoticeEffect.Length != 0;
			if (flag4)
			{
				this.CreateXFX(systemOpen.NoticeEffect[0]);
			}
			else
			{
				this.DeleteXFX();
			}
		}

		private void CreateXFX(string effectStr)
		{
			bool flag = this._xfx != null && this._xfx.FxName != effectStr;
			if (flag)
			{
				this.DeleteXFX();
			}
			bool flag2 = this._xfx == null && !string.IsNullOrEmpty(effectStr) && this.gameObject != null;
			if (flag2)
			{
				this._xfx = XSingleton<XFxMgr>.singleton.CreateUIFx(effectStr, this.gameObject.transform, false);
			}
		}

		private void DeleteXFX()
		{
			bool flag = this._xfx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._xfx, true);
				this._xfx = null;
			}
		}

		private XSysDefine _systemID = XSysDefine.XSys_None;

		private int _count = 0;

		private int _index;

		private XFx _xfx;

		public GameObject gameObject;
	}
}
