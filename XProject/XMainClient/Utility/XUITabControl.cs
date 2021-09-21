using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.Utility
{
	// Token: 0x020016BB RID: 5819
	internal class XUITabControl
	{
		// Token: 0x0600F048 RID: 61512 RVA: 0x0034C5F0 File Offset: 0x0034A7F0
		public IXUICheckBox GetByCheckBoxId(ulong id)
		{
			List<GameObject> list = ListPool<GameObject>.Get();
			this.tab_pool.GetActiveList(list);
			IXUICheckBox ixuicheckBox = null;
			for (int i = 0; i < list.Count; i++)
			{
				IXUICheckBox ixuicheckBox2 = list[i].transform.Find("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
				bool flag = ixuicheckBox2.ID == id;
				if (flag)
				{
					ixuicheckBox = ixuicheckBox2;
					break;
				}
			}
			ListPool<GameObject>.Release(list);
			bool flag2 = ixuicheckBox == null;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Have not this CheckBox of id.", null, null, null, null, null);
			}
			return ixuicheckBox;
		}

		// Token: 0x0600F049 RID: 61513 RVA: 0x0034C693 File Offset: 0x0034A893
		public void SetTabTpl(Transform tpl)
		{
			this.tab_pool.SetupPool(tpl.parent.gameObject, tpl.gameObject, 5U, false);
		}

		// Token: 0x0600F04A RID: 61514 RVA: 0x0034C6B8 File Offset: 0x0034A8B8
		public static XSysDefine GetTargetSys(XSysDefine sys, out List<XSysDefine> subSys)
		{
			XSysDefine parentSys = XSingleton<XGameSysMgr>.singleton.GetParentSys(sys);
			subSys = XSingleton<XGameSysMgr>.singleton.GetChildSys(parentSys);
			XSysDefine xsysDefine = sys;
			bool flag = sys == parentSys;
			if (flag)
			{
				for (int i = 0; i < subSys.Count; i++)
				{
					bool flag2 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(subSys[i], XSingleton<XAttributeMgr>.singleton.XPlayerData);
					if (!flag2)
					{
						bool flag3 = xsysDefine == parentSys;
						if (flag3)
						{
							xsysDefine = subSys[i];
						}
						bool sysRedPointState = XSingleton<XGameSysMgr>.singleton.GetSysRedPointState(subSys[i]);
						if (sysRedPointState)
						{
							xsysDefine = subSys[i];
							break;
						}
					}
				}
			}
			return xsysDefine;
		}

		// Token: 0x0600F04B RID: 61515 RVA: 0x0034C76C File Offset: 0x0034A96C
		public IXUICheckBox[] SetupTabs(XSysDefine sys, XUITabControl.UITabControlCallback func, bool bHorizontal = false, float fDisable = 1f)
		{
			this.tab_pool.ReturnAll(false);
			this.m_TabFrames.Clear();
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			XSysDefine parentSys = XSingleton<XGameSysMgr>.singleton.GetParentSys(sys);
			List<XSysDefine> childSys = XSingleton<XGameSysMgr>.singleton.GetChildSys(parentSys);
			Vector3 localPosition = this.tab_pool._tpl.transform.localPosition;
			float num = (float)this.tab_pool.TplWidth;
			float num2 = (float)this.tab_pool.TplHeight;
			IXUICheckBox[] array = new IXUICheckBox[childSys.Count];
			IXUICheckBox ixuicheckBox = null;
			XSysDefine xsysDefine = sys;
			bool flag = sys == parentSys;
			if (flag)
			{
				for (int i = 0; i < childSys.Count; i++)
				{
					bool flag2 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(childSys[i], xplayerData);
					if (!flag2)
					{
						bool flag3 = xsysDefine == parentSys;
						if (flag3)
						{
							xsysDefine = childSys[i];
						}
						bool sysRedPointState = XSingleton<XGameSysMgr>.singleton.GetSysRedPointState(childSys[i]);
						if (sysRedPointState)
						{
							xsysDefine = childSys[i];
							break;
						}
					}
				}
			}
			int j = 0;
			int num3 = 0;
			while (j < childSys.Count)
			{
				bool flag4 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(childSys[j], xplayerData);
				if (!flag4)
				{
					GameObject gameObject = this.tab_pool.FetchGameObject(false);
					gameObject.name = childSys[j].ToString();
					if (bHorizontal)
					{
						gameObject.transform.localPosition = localPosition + new Vector3(num * (float)num3, 0f, 0f);
					}
					else
					{
						gameObject.transform.localPosition = localPosition + new Vector3(0f, -num2 * (float)num3, 0f);
					}
					num3++;
					IXUICheckBox ixuicheckBox2 = gameObject.transform.FindChild("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
					ixuicheckBox2.ID = (ulong)((long)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(childSys[j]));
					ixuicheckBox2.ForceSetFlag(false);
					ixuicheckBox2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabControlStateChange));
					array[j] = ixuicheckBox2;
					this.m_TabFrames.Add((int)ixuicheckBox2.ID, func);
					Transform transform = gameObject.transform.FindChild("Bg/TextLabel");
					bool flag5 = transform != null;
					if (flag5)
					{
						IXUILabel ixuilabel = transform.GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel2 = gameObject.transform.FindChild("Bg/SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
						string @string = XStringDefineProxy.GetString(childSys[j].ToString());
						ixuilabel.SetText(@string);
						ixuilabel2.SetText(@string);
					}
					else
					{
						IXUISprite ixuisprite = gameObject.transform.FindChild("Bg/Text").GetComponent("XUISprite") as IXUISprite;
						IXUISprite ixuisprite2 = gameObject.transform.FindChild("Bg/SelectedText").GetComponent("XUISprite") as IXUISprite;
						string string2 = XStringDefineProxy.GetString(childSys[j].ToString());
						ixuisprite.SetSprite(string2 + "0");
						ixuisprite2.SetSprite(string2 + "1");
						ixuisprite.MakePixelPerfect();
						ixuisprite2.MakePixelPerfect();
					}
					bool flag6 = childSys[j] == xsysDefine;
					if (flag6)
					{
						ixuicheckBox = ixuicheckBox2;
					}
				}
				j++;
			}
			bool flag7 = ixuicheckBox != null;
			if (flag7)
			{
				ixuicheckBox.bChecked = true;
			}
			this.m_DisableAlpha = fDisable;
			return array;
		}

		// Token: 0x0600F04C RID: 61516 RVA: 0x0034CB28 File Offset: 0x0034AD28
		public IXUICheckBox[] SetupTabs(List<int> ids, List<string> prefix, XUITabControl.UITabControlCallback func, bool bHorizontal = false, float fDisable = 1f, int select = -1, bool bFromStringTable = true)
		{
			this.tab_pool.ReturnAll(false);
			this.m_TabFrames.Clear();
			Vector3 localPosition = this.tab_pool._tpl.transform.localPosition;
			float num = (float)this.tab_pool.TplWidth;
			float num2 = (float)this.tab_pool.TplHeight;
			IXUICheckBox[] array = new IXUICheckBox[ids.Count];
			IXUICheckBox ixuicheckBox = null;
			bool flag = select == -1;
			if (flag)
			{
				select = 0;
			}
			else
			{
				select = ids.IndexOf(select);
			}
			bool flag2 = select == -1;
			if (flag2)
			{
				select = 0;
			}
			for (int i = 0; i < ids.Count; i++)
			{
				GameObject gameObject = this.tab_pool.FetchGameObject(false);
				gameObject.name = ids[i].ToString();
				if (bHorizontal)
				{
					gameObject.transform.localPosition = localPosition + new Vector3(num * (float)i, 0f, 0f);
				}
				else
				{
					gameObject.transform.localPosition = localPosition + new Vector3(0f, -num2 * (float)i, 0f);
				}
				IXUICheckBox ixuicheckBox2 = gameObject.transform.FindChild("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox2.ID = (ulong)((long)ids[i]);
				ixuicheckBox2.ForceSetFlag(false);
				ixuicheckBox2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabControlStateChange));
				array[i] = ixuicheckBox2;
				this.m_TabFrames.Add((int)ixuicheckBox2.ID, func);
				Transform transform = gameObject.transform.FindChild("Bg/TextLabel");
				bool flag3 = transform != null;
				if (flag3)
				{
					IXUILabel ixuilabel = transform.GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = gameObject.transform.FindChild("Bg/SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
					string text = bFromStringTable ? XStringDefineProxy.GetString(prefix[i]) : prefix[i];
					ixuilabel.SetText(text);
					ixuilabel2.SetText(text);
				}
				else
				{
					IXUISprite ixuisprite = gameObject.transform.FindChild("Bg/Text").GetComponent("XUISprite") as IXUISprite;
					IXUISprite ixuisprite2 = gameObject.transform.FindChild("Bg/SelectedText").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetSprite(prefix[i] + "0");
					ixuisprite2.SetSprite(prefix[i] + "1");
					ixuisprite.MakePixelPerfect();
					ixuisprite2.MakePixelPerfect();
				}
				bool flag4 = i == select;
				if (flag4)
				{
					ixuicheckBox = ixuicheckBox2;
				}
			}
			bool flag5 = ixuicheckBox != null;
			if (flag5)
			{
				ixuicheckBox.bChecked = true;
			}
			this.m_DisableAlpha = fDisable;
			return array;
		}

		// Token: 0x0600F04D RID: 61517 RVA: 0x0034CE14 File Offset: 0x0034B014
		public void RegistrerNewTab(ulong id, XUITabControl.UITabControlCallback func)
		{
			List<GameObject> list = ListPool<GameObject>.Get();
			this.tab_pool.GetActiveList(list);
			for (int i = 0; i < list.Count; i++)
			{
				IXUICheckBox ixuicheckBox = list[i].transform.FindChild("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
				bool flag = ixuicheckBox.ID == id;
				if (flag)
				{
					ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabControlStateChange));
					this.m_TabFrames.Add((int)id, func);
				}
			}
			ListPool<GameObject>.Release(list);
		}

		// Token: 0x0600F04E RID: 61518 RVA: 0x0034CEAC File Offset: 0x0034B0AC
		public bool OnTabControlStateChange(IXUICheckBox chkBox)
		{
			bool bChecked = chkBox.bChecked;
			if (bChecked)
			{
				int key = (int)chkBox.ID;
				XUITabControl.UITabControlCallback uitabControlCallback = this.m_TabFrames[key];
				bool flag = uitabControlCallback != null;
				if (flag)
				{
					uitabControlCallback(chkBox.ID);
				}
				chkBox.SetAlpha(1f);
			}
			else
			{
				chkBox.SetAlpha(this.m_DisableAlpha);
			}
			return true;
		}

		// Token: 0x04006679 RID: 26233
		private XUIPool tab_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400667A RID: 26234
		protected float m_DisableAlpha;

		// Token: 0x0400667B RID: 26235
		private Dictionary<int, XUITabControl.UITabControlCallback> m_TabFrames = new Dictionary<int, XUITabControl.UITabControlCallback>();

		// Token: 0x02001A01 RID: 6657
		// (Invoke) Token: 0x060110F8 RID: 69880
		public delegate void UITabControlCallback(ulong id);
	}
}
