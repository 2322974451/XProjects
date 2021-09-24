using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ItemIconListDlg : DlgBase<ItemIconListDlg, ItemIconListDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/ItemIconListDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 100;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
		}

		public void SetTitle(string text)
		{
			base.uiBehaviour.m_Title.SetText(text);
		}

		private Rect _GetValidRect()
		{
			Rect result = default(Rect);
			result.Set((float)(-(float)(XSingleton<XGameUI>.singleton.Base_UI_Width - base.uiBehaviour.m_Bg.spriteWidth) / 2), (float)(-(float)(XSingleton<XGameUI>.singleton.Base_UI_Height - base.uiBehaviour.m_Bg.spriteHeight) / 2), (float)(XSingleton<XGameUI>.singleton.Base_UI_Width - base.uiBehaviour.m_Bg.spriteWidth), (float)(XSingleton<XGameUI>.singleton.Base_UI_Height - base.uiBehaviour.m_Bg.spriteHeight));
			return result;
		}

		public void SetGlobalPosition(Vector3 position)
		{
			base.uiBehaviour.m_Bg.gameObject.transform.position = position;
			Vector3 localPosition = base.uiBehaviour.m_Bg.gameObject.transform.localPosition;
			localPosition.y -= (float)(base.uiBehaviour.m_Bg.spriteHeight / 2 + 50);
			Rect rect = this._GetValidRect();
			base.uiBehaviour.m_Arrow.gameObject.SetActive(false);
			base.uiBehaviour.m_ArrowDown.gameObject.SetActive(false);
			Transform transform = base.uiBehaviour.m_Arrow;
			bool flag = localPosition.y < rect.yMin;
			if (flag)
			{
				localPosition.y = base.uiBehaviour.m_Bg.gameObject.transform.localPosition.y + (float)(base.uiBehaviour.m_Bg.spriteHeight / 2 + 50);
				transform = base.uiBehaviour.m_ArrowDown;
			}
			localPosition.x = Mathf.Max(rect.xMin, localPosition.x);
			localPosition.x = Mathf.Min(rect.xMax, localPosition.x);
			localPosition.y = Mathf.Max(rect.yMin, localPosition.y);
			localPosition.y = Mathf.Min(rect.yMax, localPosition.y);
			base.uiBehaviour.m_Bg.gameObject.transform.localPosition = localPosition;
			transform.position = new Vector3(position.x, transform.position.y, transform.position.z);
			float num = Mathf.Clamp(transform.localPosition.x, (float)(-(float)base.uiBehaviour.m_Bg.spriteWidth / 2 + 5), (float)(base.uiBehaviour.m_Bg.spriteWidth / 2 - 5));
			transform.localPosition = new Vector3(num, transform.localPosition.y, transform.localPosition.z);
			transform.gameObject.SetActive(true);
			this.SetVisible(true, true);
		}

		public void Show(List<uint> itemid, List<uint> itemCount, bool isCamp = false)
		{
			this.SetVisible(true, true);
			bool flag = itemid.Count != itemCount.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("itemid.Count != itemCount.Count", null, null, null, null, null);
			}
			else
			{
				bool flag2 = isCamp && itemid.Count < 2;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("itemid.Count <2", null, null, null, null, null);
				}
				else
				{
					float num = 0f;
					if (isCamp)
					{
						num = (float)(-(float)base.uiBehaviour.m_Split.spriteWidth) * 0.5f;
						base.uiBehaviour.m_Split.SetVisible(true);
					}
					else
					{
						base.uiBehaviour.m_Split.SetVisible(false);
					}
					base.uiBehaviour.m_ItemPool.FakeReturnAll();
					float num2 = (float)itemid.Count * 0.5f - 0.5f;
					Vector3 tplPos = base.uiBehaviour.m_ItemPool.TplPos;
					for (int i = 0; i < itemid.Count; i++)
					{
						GameObject gameObject = base.uiBehaviour.m_ItemPool.FetchGameObject(false);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)itemid[i], (int)itemCount[i], false);
						gameObject.transform.localPosition = new Vector3(((float)i - num2) * (float)base.uiBehaviour.m_ItemPool.TplWidth + num, tplPos.y);
						bool flag3 = isCamp && i == itemid.Count - 1;
						if (flag3)
						{
							gameObject.transform.localPosition += new Vector3((float)base.uiBehaviour.m_Split.spriteWidth, 0f, 0f);
							base.uiBehaviour.m_SplitPos.transform.localPosition = gameObject.transform.localPosition;
						}
						IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)itemid[i];
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					}
					base.uiBehaviour.m_ItemPool.ActualReturnAll(false);
					int num3 = base.uiBehaviour.m_ItemPool.ActiveCount * base.uiBehaviour.m_ItemPool.TplWidth;
					if (isCamp)
					{
						num3 += base.uiBehaviour.m_Split.spriteWidth;
					}
					num3 -= base.uiBehaviour.m_BorderWidth;
					num3 = Mathf.Max(num3, base.uiBehaviour.m_MinFrame.spriteWidth);
					base.uiBehaviour.m_Bg.spriteWidth = num3;
					base.uiBehaviour.m_Title.gameObject.transform.localPosition = new Vector3((float)(-(float)base.uiBehaviour.m_ItemPool.TplWidth) * 0.5f + num, base.uiBehaviour.m_Title.gameObject.transform.localPosition.y);
				}
			}
		}

		private void OnCloseClicked(IXUISprite iSp)
		{
			this.SetVisible(false, true);
		}
	}
}
