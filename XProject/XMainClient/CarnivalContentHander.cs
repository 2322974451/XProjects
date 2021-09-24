using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class CarnivalContentHander : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.boxTpl = base.transform.Find("Tabs/TabTpl").gameObject;
			this.m_scroll = (base.transform.Find("detail").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_content = (base.transform.Find("detail/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_content.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateItem));
			this.m_tabpool.SetupPool(this.boxTpl.transform.parent.gameObject, this.boxTpl, 2U, true);
			this.itemTpl = this.m_content.gameObject.transform.Find("item_tpl/item").gameObject;
			this.width = (this.itemTpl.GetComponent("XUISprite") as IXUISprite).spriteWidth;
			this.itempos = this.itemTpl.transform.localPosition;
			this.itemTpl.SetActive(false);
		}

		public void Refresh()
		{
			XCarnivalDocument doc = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc;
			string[] childs = doc.GetSuperActivity(doc.currBelong).childs;
			this.m_tabpool.ReturnAll(false);
			this.m_boxs.Clear();
			bool flag = childs != null;
			if (flag)
			{
				int num = 0;
				for (int i = 0; i < childs.Length; i++)
				{
					List<SpActivityNode> tabList = doc.GetTabList(doc.currBelong, i + 1);
					bool flag2 = tabList.Count == 0;
					if (!flag2)
					{
						GameObject gameObject = this.m_tabpool.FetchGameObject(false);
						gameObject.transform.localPosition = new Vector3((float)(180 * num), 0f, 0f);
						IXUICheckBox ixuicheckBox = gameObject.transform.GetComponent("XUICheckBox") as IXUICheckBox;
						IXUILabel ixuilabel = ixuicheckBox.gameObject.transform.Find("TextLabel").GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel2 = ixuicheckBox.gameObject.transform.Find("SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
						GameObject gameObject2 = ixuicheckBox.gameObject.transform.Find("RedPoint").gameObject;
						gameObject2.SetActive(doc.HasRwdClaimed(doc.currBelong, i + 1) && !doc.IsActivityExpire());
						ixuilabel.SetText(childs[i]);
						ixuilabel2.SetText(childs[i]);
						ixuicheckBox.ID = (ulong)((long)(i + 1));
						ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClick));
						this.m_boxs.Add(ixuicheckBox);
						num++;
					}
				}
			}
			bool flag3 = this.m_boxs.Count > 0;
			if (flag3)
			{
				this.m_boxs[0].bChecked = true;
				doc.currType = (int)this.m_boxs[0].ID;
				this.RefreshList();
			}
		}

		private bool OnTabClick(IXUICheckBox box)
		{
			bool bChecked = box.bChecked;
			if (bChecked)
			{
				XCarnivalDocument doc = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc;
				doc.currType = (int)box.ID;
				this.RefreshList();
			}
			return true;
		}

		public void RefreshTab()
		{
			XCarnivalDocument doc = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc;
			for (int i = 0; i < this.m_boxs.Count; i++)
			{
				Transform transform = this.m_boxs[i].gameObject.transform.Find("RedPoint");
				bool flag = transform != null;
				if (flag)
				{
					transform.gameObject.SetActive(doc.HasRwdClaimed(doc.currBelong, i + 1) && !doc.IsActivityExpire());
				}
			}
		}

		public void RefreshList()
		{
			this.currList = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc.GetCurrList();
			this.currList.Sort(new Comparison<SpActivityNode>(this.SortList));
			this.m_content.SetContentCount(this.currList.Count, false);
			this.m_scroll.ResetPosition();
		}

		private int StateValue(SpActivityNode node)
		{
			bool flag = node.state == 1U;
			int result;
			if (flag)
			{
				result = 2;
			}
			else
			{
				bool flag2 = node.state == 0U;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}

		private int SortList(SpActivityNode x, SpActivityNode y)
		{
			bool flag = x.state != y.state;
			int result;
			if (flag)
			{
				result = this.StateValue(y) - this.StateValue(x);
			}
			else
			{
				result = (int)(x.row.taskid - y.row.taskid);
			}
			return result;
		}

		private void UpdateItem(Transform t, int index)
		{
			IXUIButton ixuibutton = t.Find("Get").GetComponent("XUIButton") as IXUIButton;
			IXUILabel ixuilabel = t.Find("TLabel").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.Find("PLabel").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = t.Find("Fini").GetComponent("XUISprite") as IXUISprite;
			Transform transform = t.Find("items");
			transform.transform.localPosition = this.itempos;
			SeqListRef<uint> items = this.currList[index].row.items;
			this.DestroyChilds(transform);
			for (int i = 0; i < items.Count; i++)
			{
				GameObject gameObject = this.FetchItem();
				gameObject.transform.parent = transform;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3((float)(this.width * i), 0f, 0f);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)items[i, 0], (int)items[i, 1], false);
				IXUISprite ixuisprite2 = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.ID = (ulong)items[i, 0];
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
			SuperActivityTask.RowData row = this.currList[index].row;
			ixuilabel.SetText(row.title);
			ixuibutton.ID = (ulong)row.taskid;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnClick));
			uint state = this.currList[index].state;
			ixuisprite.SetVisible(state == 2U);
			ixuibutton.SetVisible(state != 2U);
			XCarnivalDocument doc = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc;
			bool flag = doc.IsActivityExpire();
			CarnivalState carnivalState;
			if (flag)
			{
				carnivalState = CarnivalState.Lock;
			}
			else
			{
				bool flag2 = state == 1U;
				if (flag2)
				{
					carnivalState = CarnivalState.Rwd;
				}
				else
				{
					bool flag3 = state == 2U;
					if (flag3)
					{
						carnivalState = CarnivalState.Clamed;
					}
					else
					{
						bool flag4 = row.jump == 0U;
						if (flag4)
						{
							carnivalState = CarnivalState.Desc;
						}
						else
						{
							carnivalState = CarnivalState.Task;
						}
					}
				}
			}
			ixuilabel2.SetVisible(row.cnt > 0 && carnivalState != CarnivalState.Clamed);
			ixuilabel2.SetText(string.Format("{0}/{1}", this.currList[index].progress, row.cnt));
			this.SetBtn(ixuibutton, carnivalState);
		}

		private void SetBtn(IXUIButton btn, CarnivalState type)
		{
			btn.SetEnable(type != CarnivalState.Lock && type != CarnivalState.Desc, false);
			IXUILabel ixuilabel = btn.gameObject.transform.Find("MoneyCost").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = btn.gameObject.transform.Find("RedPoint").GetComponent("XUISprite") as IXUISprite;
			ixuilabel.SetText((type == CarnivalState.Task) ? XStringDefineProxy.GetString("PVPActivity_Go") : XStringDefineProxy.GetString("SRS_FETCH"));
			ixuisprite.SetVisible(type == CarnivalState.Rwd);
			bool flag = type == CarnivalState.Desc;
			if (flag)
			{
				ixuilabel.SetText(XStringDefineProxy.GetString("CarnivalNone"));
			}
		}

		private bool OnBtnClick(IXUIButton btn)
		{
			ulong id = btn.ID;
			this.currList = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc.GetCurrList();
			for (int i = 0; i < this.currList.Count; i++)
			{
				bool flag = (ulong)this.currList[i].row.taskid == id;
				if (flag)
				{
					bool flag2 = this.currList[i].state == 1U;
					if (flag2)
					{
						DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc.RequestClaim((uint)id);
					}
					else
					{
						SuperActivityTask.RowData row = this.currList[i].row;
						bool flag3 = row.arg != null && row.arg.Length != 0;
						if (flag3)
						{
							bool flag4 = row.arg[0] == 1;
							if (flag4)
							{
								DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.SelectChapter(row.arg[1], (uint)row.arg[2]);
							}
							else
							{
								bool flag5 = row.arg[0] == 2;
								if (flag5)
								{
									DlgBase<TheExpView, TheExpBehaviour>.singleton.ShowView(row.arg[1]);
								}
							}
						}
						else
						{
							XSingleton<XGameSysMgr>.singleton.OpenSystem((int)row.jump);
						}
					}
				}
			}
			return true;
		}

		private GameObject FetchItem()
		{
			return this.NewGameobject();
		}

		private void DestroyChilds(Transform pa)
		{
			for (int i = 0; i < pa.childCount; i++)
			{
				Transform child = pa.GetChild(i);
				UnityEngine.Object.Destroy(child.gameObject);
			}
		}

		private GameObject NewGameobject()
		{
			GameObject gameObject = XCommon.Instantiate<GameObject>(this.itemTpl);
			gameObject.SetActive(true);
			return gameObject;
		}

		public GameObject boxTpl;

		public GameObject itemTpl;

		public IXUIScrollView m_scroll;

		public IXUIWrapContent m_content;

		public XUIPool m_tabpool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public List<IXUICheckBox> m_boxs = new List<IXUICheckBox>();

		private List<SpActivityNode> currList = new List<SpActivityNode>();

		private List<GameObject> itemspool = new List<GameObject>();

		private int width = 90;

		private Vector3 itempos = Vector3.zero;
	}
}
