using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C6C RID: 3180
	public class PreSettingNodeHandler : DlgHandlerBase
	{
		// Token: 0x0600B3F9 RID: 46073 RVA: 0x0023137C File Offset: 0x0022F57C
		protected override void Init()
		{
			base.Init();
			this._types.Clear();
			int num = XFastEnumIntEqualityComparer<PrerogativeType>.ToInt(PrerogativeType.PreMax) - 1;
			for (int i = 1; i <= num; i++)
			{
				string key = XSingleton<XCommon>.singleton.StringCombine("PRE_TYPE_NAME", i.ToString());
				string text = "";
				bool data = XSingleton<XStringTable>.singleton.GetData(key, out text);
				bool flag = data;
				if (flag)
				{
					this._types.Add((uint)i);
				}
			}
			this._doc = XDocuments.GetSpecificDocument<XPrerogativeDocument>(XPrerogativeDocument.uuID);
			this._preList = (base.transform.Find("PreList").GetComponent("XUIScrollView") as IXUIScrollView);
			this._preWrapContent = (base.transform.Find("PreList/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._preWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnPreWrapContentUpdate));
			this._preDetailList = (base.transform.Find("PreDetail/PreSelectList").GetComponent("XUIScrollView") as IXUIScrollView);
			this._preDetailWrapContent = (base.transform.Find("PreDetail/PreSelectList/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._preDetailWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnPreDetailContentUpdate));
			this._preDetailName = (base.transform.Find("PreDetail/TLabel").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600B3FA RID: 46074 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600B3FB RID: 46075 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B3FC RID: 46076 RVA: 0x002314F7 File Offset: 0x0022F6F7
		public override void RefreshData()
		{
			this.SetupActivePreList();
			this.SetupPreDetailList();
		}

		// Token: 0x0600B3FD RID: 46077 RVA: 0x00231508 File Offset: 0x0022F708
		private void SetupPreDetailList()
		{
			this._activePreID = this._doc.GetPreContentID(this._selectType);
			this._preDetailName.SetText(XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("PRE_TYPE_NAME", this._selectType.ToString())));
			this._doc.TryGetContentByType(ref this._tempList, this._selectType);
			this._preDetailWrapContent.SetContentCount(this._tempList.Count, false);
			this._preDetailList.ResetPosition();
			uint defaultPreID = XPrerogativeDocument.GetDefaultPreID(this._selectType);
		}

		// Token: 0x0600B3FE RID: 46078 RVA: 0x002315A0 File Offset: 0x0022F7A0
		private void _OnPreWrapContentUpdate(Transform t, int index)
		{
			bool flag = index >= this._types.Count;
			if (!flag)
			{
				uint num = this._types[index];
				IXUILabel ixuilabel = t.Find("Text").GetComponent("XUILabel") as IXUILabel;
				Transform transform = t.Find("Selection");
				IXUILabel ixuilabel2 = t.Find("Selection/Text").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
				string @string = XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("PRE_TYPE_NAME", num.ToString()));
				ixuilabel.SetText(@string);
				ixuilabel2.SetText(@string);
				transform.gameObject.SetActive(this._selectType == num);
				PrerogativeContent.RowData preContentData = this._doc.GetPreContentData(num);
				PreSettingNodeHandler.SetupPrerogativeTpl(t, preContentData);
				ixuisprite.ID = (ulong)num;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnBorderClick));
			}
		}

		// Token: 0x0600B3FF RID: 46079 RVA: 0x002316A4 File Offset: 0x0022F8A4
		private void _OnPreDetailContentUpdate(Transform t, int index)
		{
			Transform transform = t.Find("Normal");
			Transform transform2 = t.Find("Lock");
			IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
			bool flag = index >= this._tempList.Count;
			if (flag)
			{
				transform.gameObject.SetActive(false);
				transform2.gameObject.SetActive(false);
				ixuisprite.RegisterSpriteClickEventHandler(null);
			}
			else
			{
				PrerogativeContent.RowData rowData = this._tempList[index];
				uint id = rowData.ID;
				bool flag2 = this._doc.IsActived(id);
				if (flag2)
				{
					transform.gameObject.SetActive(true);
					transform2.gameObject.SetActive(false);
					Transform transform3 = transform.FindChild("Selection");
					IXUISprite ixuisprite2 = transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel = transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
					GameObject gameObject = transform.Find("WeddingTag").gameObject;
					gameObject.SetActive((ulong)rowData.Normal == (ulong)((long)XFastEnumIntEqualityComparer<PrerogativeNormalType>.ToInt(PrerogativeNormalType.PreWedding)));
					ixuilabel.SetText(rowData.Name);
					PreSettingNodeHandler.SetupPrerogativeTpl(transform, rowData);
					ixuisprite.ID = (ulong)rowData.ID;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnSelectClick));
					transform3.gameObject.SetActive(this._activePreID == rowData.ID);
				}
				else
				{
					transform.gameObject.SetActive(false);
					transform2.gameObject.SetActive(true);
					IXUISprite ixuisprite3 = transform2.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel2 = transform2.Find("Cost").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel3 = transform2.Find("Name").GetComponent("XUILabel") as IXUILabel;
					IXUISprite ixuisprite4 = transform2.Find("Cost/Item").GetComponent("XUISprite") as IXUISprite;
					GameObject gameObject2 = transform2.Find("WeddingTag").gameObject;
					gameObject2.SetActive((ulong)rowData.Normal == (ulong)((long)XFastEnumIntEqualityComparer<PrerogativeNormalType>.ToInt(PrerogativeNormalType.PreWedding)));
					ixuilabel3.SetText(rowData.Name);
					PreSettingNodeHandler.SetupPrerogativeTpl(transform2, rowData);
					ixuisprite.ID = (ulong)index;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnActiveClick));
					uint num = rowData.Item[0];
					uint num2 = rowData.Item[1];
					ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)num);
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)num);
					bool flag3 = itemConf != null && itemConf.ItemIcon1 != null && itemConf.ItemIcon1.Length != 0;
					if (flag3)
					{
						ixuisprite4.SetSprite(itemConf.ItemIcon1[0]);
					}
					string text = itemCount + "/" + num2;
					bool flag4 = itemCount < (ulong)num2;
					if (flag4)
					{
						text = string.Concat(new object[]
						{
							"[ff0000]",
							itemCount,
							"/",
							num2,
							"[-]"
						});
					}
					ixuilabel2.SetText(text);
				}
			}
		}

		// Token: 0x0600B400 RID: 46080 RVA: 0x002319F0 File Offset: 0x0022FBF0
		private void _OnBorderClick(IXUISprite sprite)
		{
			uint num = (uint)sprite.ID;
			bool flag = this._selectType != num;
			if (flag)
			{
				this._selectType = num;
				this.RefreshData();
			}
		}

		// Token: 0x0600B401 RID: 46081 RVA: 0x00231A28 File Offset: 0x0022FC28
		private void _OnSelectClick(IXUISprite sprite)
		{
			uint num = (uint)sprite.ID;
			bool flag = num == this._activePreID;
			if (flag)
			{
				this._doc.HidePreCache(this._selectType);
			}
			else
			{
				this._doc.TrySendPreCache(num);
			}
			XSingleton<XDebug>.singleton.AddGreenLog("_OnSelectClick" + num.ToString(), null, null, null, null, null);
		}

		// Token: 0x0600B402 RID: 46082 RVA: 0x00231A94 File Offset: 0x0022FC94
		private void _OnActiveClick(IXUISprite sprite)
		{
			int num = (int)sprite.ID;
			bool flag = num <= this._tempList.Count;
			if (flag)
			{
				PrerogativeContent.RowData rowData = this._tempList[num];
				uint id = rowData.ID;
				uint itemid = rowData.Item[0];
				uint num2 = rowData.Item[1];
				ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)itemid);
				bool flag2 = itemCount >= (ulong)num2;
				if (flag2)
				{
					this._doc.TrySendActivePre(id);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(string.Format("Prerogative_NotEnough_{0}", rowData.HintID)), "fece00");
				}
				XSingleton<XDebug>.singleton.AddGreenLog("_OnSelectClick" + id.ToString(), null, null, null, null, null);
			}
		}

		// Token: 0x0600B403 RID: 46083 RVA: 0x00231B70 File Offset: 0x0022FD70
		private void SetupActivePreList()
		{
			bool flag = this._selectType == 0U && this._types.Count > 0;
			if (flag)
			{
				this._selectType = this._types[0];
			}
			this._preWrapContent.SetContentCount(this._types.Count, false);
		}

		// Token: 0x0600B404 RID: 46084 RVA: 0x00231BC8 File Offset: 0x0022FDC8
		public static void SetupPrerogativeTpl(Transform tf, PrerogativeContent.RowData content = null)
		{
			IXUISprite ts = tf.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			bool flag = content == null;
			if (flag)
			{
				PreSettingNodeHandler.DrawEmptyItem(ts);
			}
			else
			{
				uint type = content.Type;
				if (type != 1U)
				{
					PreSettingNodeHandler.DrawSpriteItem(ts, content.Icon);
				}
				else
				{
					PreSettingNodeHandler.DrawColorItem(ts, content.Icon);
				}
			}
		}

		// Token: 0x0600B405 RID: 46085 RVA: 0x00231C2E File Offset: 0x0022FE2E
		private static void DrawEmptyItem(IXUISprite ts)
		{
			ts.SetSprite("", "", false);
		}

		// Token: 0x0600B406 RID: 46086 RVA: 0x00231C44 File Offset: 0x0022FE44
		private static void DrawSpriteItem(IXUISprite ts, string content)
		{
			ts.SetColor(Color.white);
			bool flag = content != null && !string.IsNullOrEmpty(content);
			if (flag)
			{
				string[] array = content.Split(XGlobalConfig.SequenceSeparator);
				bool flag2 = array.Length > 1;
				if (flag2)
				{
					ts.SetSprite(array[1], array[0], false);
				}
				else
				{
					ts.SetSprite(array[0]);
				}
			}
			else
			{
				ts.SetSprite("");
			}
		}

		// Token: 0x0600B407 RID: 46087 RVA: 0x00231CB4 File Offset: 0x0022FEB4
		private static void DrawColorItem(IXUISprite ts, string content)
		{
			ts.SetSprite("VIP_Color", "GameSystem/SysCommon1", false);
			bool flag = !string.IsNullOrEmpty(content);
			if (flag)
			{
				string[] array = content.Split(XGlobalConfig.SequenceSeparator);
				Color white = Color.white;
				white.r = float.Parse(array[0]) / 255f;
				white.g = float.Parse(array[1]) / 255f;
				white.b = float.Parse(array[2]) / 255f;
				ts.SetColor(white);
			}
		}

		// Token: 0x040045C3 RID: 17859
		private XPrerogativeDocument _doc;

		// Token: 0x040045C4 RID: 17860
		private IXUIScrollView _preList;

		// Token: 0x040045C5 RID: 17861
		private IXUIWrapContent _preWrapContent;

		// Token: 0x040045C6 RID: 17862
		private IXUIScrollView _preDetailList;

		// Token: 0x040045C7 RID: 17863
		private IXUIWrapContent _preDetailWrapContent;

		// Token: 0x040045C8 RID: 17864
		private IXUILabel _preDetailName;

		// Token: 0x040045C9 RID: 17865
		private List<uint> _types = new List<uint>();

		// Token: 0x040045CA RID: 17866
		private uint _selectType = 0U;

		// Token: 0x040045CB RID: 17867
		private uint _activePreID = 0U;

		// Token: 0x040045CC RID: 17868
		private List<PrerogativeContent.RowData> _tempList;
	}
}
