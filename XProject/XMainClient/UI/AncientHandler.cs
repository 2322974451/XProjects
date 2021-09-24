using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class AncientHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/AncientActivityMain";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.present = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("BigPrizeUid");
			this.maxPoint = XSingleton<XGlobalConfig>.singleton.GetInt("BigPrizeMax");
			this.itemid = XSingleton<XGlobalConfig>.singleton.GetInt("BigPrizeItemid");
			this.m_bldesc = (base.transform.Find("Main/UpView/t").GetComponent("XUILabel") as IXUILabel);
			this.m_sprEnd = (base.transform.Find("Main/UpView/Progress/end").GetComponent("XUISprite") as IXUISprite);
			this.m_sprEndRed = (this.m_sprEnd.transform.Find("RedPoint").GetComponent("XUISprite") as IXUISprite);
			this.m_Snapshot = (base.transform.Find("Main/snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_lblName = (base.transform.Find("Main/endreward").GetComponent("XUILabel") as IXUILabel);
			this.m_lblTime = (base.transform.Find("Main/t").GetComponent("XUILabel") as IXUILabel);
			this.m_prograss = (base.transform.Find("Main/UpView/Progress").GetComponent("XUIProgress") as IXUIProgress);
			this.m_sprRBg = (base.transform.Find("Main/snapshot/Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_btn = (base.transform.Find("Main/Btn").GetComponent("XUIButton") as IXUIButton);
			this.m_lblPoint = (base.transform.Find("Main/UpView/dian").GetComponent("XUILabel") as IXUILabel);
			this.m_scroll = (base.transform.Find("Main/RightView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_wrap = (base.transform.Find("Main/RightView/wrap").GetComponent("XUIWrapContent") as IXUIWrapContent);
			int i = 0;
			int num = this.chests.Length;
			while (i < num)
			{
				this.chests[i] = (base.transform.Find("Main/UpView/Progress/Chests/Chest" + i).GetComponent("XUISprite") as IXUISprite);
				this.chests2[i] = base.transform.Find("Main/UpView/Progress/Chests/Chest_" + i);
				this.reds[i] = this.chests[i].gameObject.transform.Find("RedPoint");
				i++;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_sprRBg.RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this.OnAvatarDrag));
			this.m_btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTaskBtnclick));
			this.m_wrap.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateItem));
			int i = 0;
			int num = this.chests.Length;
			while (i < num)
			{
				this.chests[i].ID = (ulong)((long)i);
				this.chests[i].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChestClick));
				i++;
			}
			this.m_sprEnd.ID = (ulong)((long)this.chests.Length);
			this.m_sprEnd.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChestClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_lblName.SetText(XStringDefineProxy.GetString("AncientName"));
			this.m_lblTime.SetText(XStringDefineProxy.GetString("AncientTime"));
			this.m_bldesc.SetText(XStringDefineProxy.GetString("AncientNamber"));
			this.RefreshList();
			base.Alloc3DAvatarPool("BigPrizeHandler", 1);
			this.m_Dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, this.present, this.m_Snapshot, this.m_Dummy, 1f);
		}

		public void RefreshList()
		{
			XAncientDocument specificDocument = XDocuments.GetSpecificDocument<XAncientDocument>(XAncientDocument.uuID);
			this.list = specificDocument.GetSortTask();
			this.m_scroll.ResetPosition();
			this.m_wrap.SetContentCount(this.list.Count, false);
			this.itemid = XSingleton<XGlobalConfig>.singleton.GetInt("BigPrizeItemid");
			XItem xitem = XBagDocument.MakeXItem(this.itemid, false);
			int num = 0;
			bool flag = xitem != null;
			if (flag)
			{
				num = xitem.itemCount;
			}
			this.m_lblPoint.SetText(num + "/" + this.maxPoint);
			this.m_prograss.value = (float)num / (float)this.maxPoint;
			this.RefreshChest();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshList();
			XAncientDocument specificDocument = XDocuments.GetSpecificDocument<XAncientDocument>(XAncientDocument.uuID);
			specificDocument.CheckRed();
			base.Alloc3DAvatarPool("CarnivalRwdHander", 1);
			this.m_Dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, this.present, this.m_Snapshot, this.m_Dummy, 1f);
		}

		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
			XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this.m_Dummy);
			this.m_Dummy = null;
		}

		protected override void OnHide()
		{
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			base.OnUnload();
		}

		protected bool OnAvatarDrag(Vector2 delta)
		{
			bool flag = this.m_Dummy != null;
			if (flag)
			{
				this.m_Dummy.EngineObject.Rotate(Vector3.up, -delta.x / 2f);
			}
			return true;
		}

		public void RefreshChest()
		{
			XAncientDocument specificDocument = XDocuments.GetSpecificDocument<XAncientDocument>(XAncientDocument.uuID);
			bool flag = specificDocument.state != null;
			if (flag)
			{
				int i = 0;
				int num = this.chests.Length;
				while (i < num)
				{
					bool flag2 = specificDocument.state[i];
					bool active = !flag2 && specificDocument.PointEnough(i);
					this.reds[i].gameObject.SetActive(active);
					this.chests2[i].gameObject.SetActive(flag2);
					this.chests[i].SetAlpha((float)(flag2 ? 0 : 1));
					i++;
				}
				int num2 = this.chests.Length;
				bool visible = !specificDocument.state[num2] && specificDocument.PointEnough(num2);
				this.m_sprEndRed.SetVisible(visible);
			}
		}

		private void OnChestClick(IXUISprite spr)
		{
			int i = 0;
			int num = XAncientDocument.ancientTable.Table.Length;
			while (i < num)
			{
				AncientTimesTable.RowData rowData = XAncientDocument.ancientTable.Table[i];
				bool flag = rowData.ID == (uint)spr.ID + 1U;
				if (flag)
				{
					DlgBase<AncientBox, AnicientBoxBahaviour>.singleton.Show(rowData);
					break;
				}
				i++;
			}
		}

		private bool OnTaskBtnclick(IXUIButton btn)
		{
			bool flag = !DlgBase<AncientTaskView, AnicentTaskBhaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<AncientTaskView, AnicentTaskBhaviour>.singleton.SetVisible(true, true);
			}
			return true;
		}

		private void UpdateItem(Transform t, int index)
		{
			bool flag = index < this.list.Count;
			if (flag)
			{
				IXUIButton ixuibutton = t.Find("Go").GetComponent("XUIButton") as IXUIButton;
				IXUILabel ixuilabel = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("Description").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.Find("Progress").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = t.Find("Finish").GetComponent("XUISprite") as IXUISprite;
				uint state = this.list[index].state;
				ixuilabel.SetText(this.list[index].row.title);
				ixuilabel3.SetText(string.Format("{0}/{1}", this.list[index].progress, this.list[index].row.cnt));
				ixuisprite.SetVisible(state == 2U);
				ixuibutton.ID = (ulong)((long)index);
				this.SetBtn(ixuibutton, (ActivityTaskState)state);
				ixuilabel2.SetText(XStringDefineProxy.GetString("AncientDes", new object[]
				{
					this.list[index].row.items[0, 1]
				}));
			}
		}

		private void SetBtn(IXUIButton btn, ActivityTaskState state)
		{
			btn.SetVisible(state != ActivityTaskState.Fetched);
			IXUILabel ixuilabel = btn.gameObject.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = btn.gameObject.transform.Find("RedPoint").GetComponent("XUISprite") as IXUISprite;
			ixuilabel.SetText((state == ActivityTaskState.Uncomplete) ? XStringDefineProxy.GetString("PVPActivity_Go") : XStringDefineProxy.GetString("SRS_FETCH"));
			ixuisprite.SetVisible(state == ActivityTaskState.Complete);
			btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnItemBtnClick));
		}

		private bool OnItemBtnClick(IXUIButton btn)
		{
			BigPrizeNode bigPrizeNode = this.list[(int)btn.ID];
			bool flag = bigPrizeNode.state == 0U;
			if (flag)
			{
				XSingleton<XGameSysMgr>.singleton.OpenSystem((int)bigPrizeNode.row.jump);
			}
			else
			{
				XAncientDocument specificDocument = XDocuments.GetSpecificDocument<XAncientDocument>(XAncientDocument.uuID);
				specificDocument.ReqClaim(bigPrizeNode.taskid);
			}
			return true;
		}

		private const int cnt = 4;

		private uint present;

		private IXUIProgress m_prograss;

		public IXUIButton m_btn;

		public IXUISprite m_sprRBg;

		public IXUILabel m_lblPoint;

		public IXUILabel m_bldesc;

		private XDummy m_Dummy;

		private IUIDummy m_Snapshot;

		public IXUILabel m_lblName;

		public IXUILabel m_lblTime;

		private IXUISprite m_sprEnd;

		private IXUISprite m_sprEndRed;

		private IXUISprite[] chests = new IXUISprite[4];

		private Transform[] reds = new Transform[4];

		private Transform[] chests2 = new Transform[4];

		private IXUIWrapContent m_wrap;

		private IXUIScrollView m_scroll;

		private List<BigPrizeNode> list;

		private int maxPoint = 0;

		private int itemid = 0;
	}
}
