using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FrozenSealHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/CrushingSeal";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.curActid = XOperatingActivityDocument.Doc.CurSealActID;
			bool flag = this.curActid > 0U;
			if (flag)
			{
				this.InitUIPool();
				this.InitScrollView();
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			uint num = this.curActid;
			this.curActid = XOperatingActivityDocument.Doc.CurSealActID;
			bool flag = num > 0U && this.curActid != num;
			if (flag)
			{
				this.Clear();
				this.InitScrollView();
			}
			bool flag2 = this.curActid > 0U;
			if (flag2)
			{
				this.RefreshAllItem();
			}
		}

		protected bool OnFetch(IXUIButton btn)
		{
			RpcC2G_GetSpActivityReward rpcC2G_GetSpActivityReward = new RpcC2G_GetSpActivityReward();
			rpcC2G_GetSpActivityReward.oArg.actid = this.curActid;
			rpcC2G_GetSpActivityReward.oArg.taskid = (uint)btn.ID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetSpActivityReward);
			return true;
		}

		protected bool OnJump(IXUIButton btn)
		{
			uint num = (uint)btn.ID;
			List<SuperActivityTask.RowData> sealDatas = XOperatingActivityDocument.Doc.SealDatas;
			for (int i = 0; i < sealDatas.Count; i++)
			{
				bool flag = sealDatas[i].taskid == num;
				if (flag)
				{
					SuperActivityTask.RowData rowData = sealDatas[i];
					bool flag2 = rowData.arg != null && rowData.arg.Length != 0;
					if (flag2)
					{
						bool flag3 = rowData.arg[0] == 1;
						if (flag3)
						{
							DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.SelectChapter(rowData.arg[1], (uint)rowData.arg[2]);
						}
						else
						{
							bool flag4 = rowData.arg[0] == 2;
							if (flag4)
							{
								DlgBase<TheExpView, TheExpBehaviour>.singleton.ShowView(rowData.arg[1]);
							}
						}
					}
					else
					{
						XSingleton<XGameSysMgr>.singleton.OpenSystem((int)rowData.jump);
					}
					return true;
				}
			}
			return false;
		}

		protected void InitItemInfo(Transform item, SuperActivityTask.RowData data)
		{
			IXUILabel ixuilabel = item.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(data.title);
			Transform transform = item.FindChild("Fetch");
			IXUIButton ixuibutton = transform.GetComponent("XUIButton") as IXUIButton;
			ixuibutton.ID = (ulong)data.taskid;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFetch));
			Transform transform2 = item.FindChild("Go");
			IXUIButton ixuibutton2 = transform2.GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.ID = (ulong)data.taskid;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJump));
			IXUILabel ixuilabel2 = item.FindChild("Go/Tip").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = item.FindChild("Go/LinkTo").GetComponent("XUILabel") as IXUILabel;
			transform.gameObject.SetActive(false);
			bool flag = data.jump > 0U;
			if (flag)
			{
				this._sortList.Add(new FrozenSealHandler.FrozenSealSortData
				{
					id = (ulong)data.taskid,
					state = FrozenSealState.LeaveFor
				});
				ixuilabel2.gameObject.SetActive(true);
				ixuilabel3.gameObject.SetActive(false);
			}
			else
			{
				this._sortList.Add(new FrozenSealHandler.FrozenSealSortData
				{
					id = (ulong)data.taskid,
					state = FrozenSealState.UnFinish
				});
				ixuibutton2.SetEnable(false, false);
				ixuilabel3.gameObject.SetActive(true);
				ixuilabel2.gameObject.SetActive(false);
			}
			item.FindChild("Fetched").gameObject.SetActive(false);
			Transform parent = item.Find("ItemReward");
			for (int i = 0; i < data.items.Count; i++)
			{
				GameObject gameObject = this._rewardPool.FetchGameObject(false);
				gameObject.transform.parent = parent;
				gameObject.transform.localPosition = new Vector3((float)(this._rewardPool.TplWidth * i), 0f, 0f);
				uint num = data.items[i, 0];
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)num, (int)data.items[i, 1], false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)num;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
		}

		protected void RefreshItemState(uint taskid, ActivityTaskState state)
		{
			Transform parent = null;
			bool flag = this._itemsDic.TryGetValue((ulong)taskid, out parent);
			if (flag)
			{
				Transform childByName = this.GetChildByName(parent, "Fetch");
				Transform childByName2 = this.GetChildByName(parent, "Go");
				Transform childByName3 = this.GetChildByName(parent, "Fetched");
				bool flag2 = state == ActivityTaskState.Uncomplete;
				if (!flag2)
				{
					bool flag3 = state == ActivityTaskState.Complete;
					if (flag3)
					{
						childByName2.gameObject.SetActive(false);
						childByName.gameObject.SetActive(true);
					}
					else
					{
						bool flag4 = state == ActivityTaskState.Fetched;
						if (flag4)
						{
							childByName.gameObject.SetActive(false);
							childByName2.gameObject.SetActive(false);
							childByName3.gameObject.SetActive(true);
						}
					}
				}
			}
		}

		protected void UpdateItemState(uint taskid, ActivityTaskState state)
		{
			for (int i = 0; i < this._sortList.Count; i++)
			{
				bool flag = this._sortList[i].id == (ulong)taskid;
				if (flag)
				{
					bool flag2 = state == ActivityTaskState.Complete;
					if (flag2)
					{
						this._sortList[i].state = FrozenSealState.CanFetch;
					}
					else
					{
						bool flag3 = state == ActivityTaskState.Fetched;
						if (flag3)
						{
							this._sortList[i].state = FrozenSealState.Fetched;
						}
					}
				}
			}
		}

		protected FrozenSealState GetFrozenSealStateById(ulong id)
		{
			return FrozenSealState.CanFetch;
		}

		protected Transform GetChildByName(Transform parent, string name)
		{
			foreach (object obj in parent)
			{
				Transform transform = (Transform)obj;
				bool flag = transform.name.Equals(name);
				if (flag)
				{
					return transform;
				}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("wrong child name", null, null, null, null, null);
			return null;
		}

		protected void RefreshAllItem()
		{
			this.UpdateTime();
			this.RefreshAllStates();
			this.SortListItems();
			this._scrollview.SetPosition(0f);
		}

		public void UpdateTime()
		{
			int remainDays = XTempActivityDocument.Doc.GetRemainDays(this.curActid);
			bool flag = remainDays == 1;
			if (flag)
			{
				this._timeLabel.SetText(XStringDefineProxy.GetString("CarnivalLast"));
			}
			else
			{
				this._timeLabel.SetText(XStringDefineProxy.GetString("CarnivalEnd", new object[]
				{
					remainDays
				}));
			}
		}

		protected void UpdateStates()
		{
			for (int i = 0; i < XOperatingActivityDocument.Doc.SealDatas.Count; i++)
			{
				SuperActivityTask.RowData rowData = XOperatingActivityDocument.Doc.SealDatas[i];
				FrozenSealHandler.FrozenSealSortData frozenSealSortData = this._sortList[i];
				uint activityState = XTempActivityDocument.Doc.GetActivityState(this.curActid, rowData.taskid);
				bool flag = activityState == 1U;
				if (flag)
				{
					frozenSealSortData.state = FrozenSealState.CanFetch;
				}
				else
				{
					bool flag2 = activityState == 2U;
					if (flag2)
					{
						frozenSealSortData.state = FrozenSealState.Fetched;
					}
				}
			}
		}

		protected void RefreshAllStates()
		{
			List<SuperActivityTask.RowData> sealDatas = XOperatingActivityDocument.Doc.SealDatas;
			for (int i = 0; i < sealDatas.Count; i++)
			{
				uint activityState = XTempActivityDocument.Doc.GetActivityState(this.curActid, sealDatas[i].taskid);
				this.RefreshItemState(sealDatas[i].taskid, (ActivityTaskState)activityState);
				this.UpdateItemState(sealDatas[i].taskid, (ActivityTaskState)activityState);
			}
		}

		protected int SortItemList(FrozenSealHandler.FrozenSealSortData x1, FrozenSealHandler.FrozenSealSortData x2)
		{
			int num = (x1.state.CompareTo(x2.state) == 0) ? x1.id.CompareTo(x2.id) : x1.state.CompareTo(x2.state);
			return -num;
		}

		public void SortListItems()
		{
			this._sortList.Sort(new Comparison<FrozenSealHandler.FrozenSealSortData>(this.SortItemList));
			for (int i = 0; i < this._sortList.Count; i++)
			{
				this._itemsDic[this._sortList[i].id].name = i.ToString("D2");
				this._itemsDic[this._sortList[i].id].localPosition = new Vector3(this._frozenSealPool.TplPos.x, this._frozenSealPool.TplPos.y - (float)(this._frozenSealPool.TplHeight * i), 0f);
			}
		}

		public void InitScrollView()
		{
			this._scrollview = (base.transform.FindChild("Scrollview").GetComponent("XUIScrollView") as IXUIScrollView);
			this._timeLabel = (base.transform.FindChild("CountDown/Time").GetComponent("XUILabel") as IXUILabel);
			this._frozenSealPool.ReturnAll(false);
			this._rewardPool.ReturnAll(false);
			this._scrollview.SetPosition(0f);
			List<SuperActivityTask.RowData> sealDatas = XOperatingActivityDocument.Doc.SealDatas;
			for (int i = 0; i < sealDatas.Count; i++)
			{
				GameObject gameObject = this._frozenSealPool.FetchGameObject(false);
				this.InitItemInfo(gameObject.transform, sealDatas[i]);
				this._itemsDic.Add((ulong)sealDatas[i].taskid, gameObject.transform);
				gameObject.transform.localPosition = new Vector3(this._frozenSealPool.TplPos.x, this._frozenSealPool.TplPos.y - (float)(this._frozenSealPool.TplHeight * i), 0f);
			}
		}

		public void RefreshItemWithTaskidAndState(uint taskId, ActivityTaskState state)
		{
			this.UpdateItemState(taskId, state);
			this.RefreshItemState(taskId, state);
			this.SortListItems();
		}

		public void Clear()
		{
			this._itemsDic.Clear();
			this._sortList.Clear();
			this._rewardPool.ReturnAll(false);
			this._frozenSealPool.ReturnAll(false);
		}

		private void InitUIPool()
		{
			Transform transform = base.transform.FindChild("Scrollview/FirstPassFsItem");
			this._frozenSealPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			Transform transform2 = base.transform.FindChild("Scrollview/ItemTpl");
			this._rewardPool.SetupPool(base.transform.gameObject, transform2.gameObject, 2U, false);
		}

		protected XUIPool _frozenSealPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		protected XUIPool _rewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		protected Dictionary<ulong, Transform> _itemsDic = new Dictionary<ulong, Transform>();

		protected List<FrozenSealHandler.FrozenSealSortData> _sortList = new List<FrozenSealHandler.FrozenSealSortData>();

		protected uint curActid = 0U;

		protected IXUIScrollView _scrollview;

		protected IXUILabel _timeLabel;

		public class FrozenSealSortData
		{

			public ulong id = 0UL;

			public FrozenSealState state = FrozenSealState.None;
		}
	}
}
