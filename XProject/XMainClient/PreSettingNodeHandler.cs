using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	public class PreSettingNodeHandler : DlgHandlerBase
	{

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

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void RefreshData()
		{
			this.SetupActivePreList();
			this.SetupPreDetailList();
		}

		private void SetupPreDetailList()
		{
			this._activePreID = this._doc.GetPreContentID(this._selectType);
			this._preDetailName.SetText(XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("PRE_TYPE_NAME", this._selectType.ToString())));
			this._doc.TryGetContentByType(ref this._tempList, this._selectType);
			this._preDetailWrapContent.SetContentCount(this._tempList.Count, false);
			this._preDetailList.ResetPosition();
			uint defaultPreID = XPrerogativeDocument.GetDefaultPreID(this._selectType);
		}

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

		private void SetupActivePreList()
		{
			bool flag = this._selectType == 0U && this._types.Count > 0;
			if (flag)
			{
				this._selectType = this._types[0];
			}
			this._preWrapContent.SetContentCount(this._types.Count, false);
		}

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

		private static void DrawEmptyItem(IXUISprite ts)
		{
			ts.SetSprite("", "", false);
		}

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

		private XPrerogativeDocument _doc;

		private IXUIScrollView _preList;

		private IXUIWrapContent _preWrapContent;

		private IXUIScrollView _preDetailList;

		private IXUIWrapContent _preDetailWrapContent;

		private IXUILabel _preDetailName;

		private List<uint> _types = new List<uint>();

		private uint _selectType = 0U;

		private uint _activePreID = 0U;

		private List<PrerogativeContent.RowData> _tempList;
	}
}
