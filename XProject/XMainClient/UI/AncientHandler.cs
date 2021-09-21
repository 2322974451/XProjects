using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017DA RID: 6106
	internal class AncientHandler : DlgHandlerBase
	{
		// Token: 0x170038AE RID: 14510
		// (get) Token: 0x0600FD0C RID: 64780 RVA: 0x003B3054 File Offset: 0x003B1254
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/AncientActivityMain";
			}
		}

		// Token: 0x0600FD0D RID: 64781 RVA: 0x003B306C File Offset: 0x003B126C
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

		// Token: 0x0600FD0E RID: 64782 RVA: 0x003B3318 File Offset: 0x003B1518
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

		// Token: 0x0600FD0F RID: 64783 RVA: 0x003B33E8 File Offset: 0x003B15E8
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

		// Token: 0x0600FD10 RID: 64784 RVA: 0x003B3480 File Offset: 0x003B1680
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

		// Token: 0x0600FD11 RID: 64785 RVA: 0x003B3540 File Offset: 0x003B1740
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshList();
			XAncientDocument specificDocument = XDocuments.GetSpecificDocument<XAncientDocument>(XAncientDocument.uuID);
			specificDocument.CheckRed();
			base.Alloc3DAvatarPool("CarnivalRwdHander", 1);
			this.m_Dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, this.present, this.m_Snapshot, this.m_Dummy, 1f);
		}

		// Token: 0x0600FD12 RID: 64786 RVA: 0x003B35A8 File Offset: 0x003B17A8
		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
			XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this.m_Dummy);
			this.m_Dummy = null;
		}

		// Token: 0x0600FD13 RID: 64787 RVA: 0x003B35D0 File Offset: 0x003B17D0
		protected override void OnHide()
		{
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			base.OnHide();
		}

		// Token: 0x0600FD14 RID: 64788 RVA: 0x003B35E8 File Offset: 0x003B17E8
		public override void OnUnload()
		{
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			base.OnUnload();
		}

		// Token: 0x0600FD15 RID: 64789 RVA: 0x003B3600 File Offset: 0x003B1800
		protected bool OnAvatarDrag(Vector2 delta)
		{
			bool flag = this.m_Dummy != null;
			if (flag)
			{
				this.m_Dummy.EngineObject.Rotate(Vector3.up, -delta.x / 2f);
			}
			return true;
		}

		// Token: 0x0600FD16 RID: 64790 RVA: 0x003B3648 File Offset: 0x003B1848
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

		// Token: 0x0600FD17 RID: 64791 RVA: 0x003B3728 File Offset: 0x003B1928
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

		// Token: 0x0600FD18 RID: 64792 RVA: 0x003B3788 File Offset: 0x003B1988
		private bool OnTaskBtnclick(IXUIButton btn)
		{
			bool flag = !DlgBase<AncientTaskView, AnicentTaskBhaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<AncientTaskView, AnicentTaskBhaviour>.singleton.SetVisible(true, true);
			}
			return true;
		}

		// Token: 0x0600FD19 RID: 64793 RVA: 0x003B37BC File Offset: 0x003B19BC
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

		// Token: 0x0600FD1A RID: 64794 RVA: 0x003B393C File Offset: 0x003B1B3C
		private void SetBtn(IXUIButton btn, ActivityTaskState state)
		{
			btn.SetVisible(state != ActivityTaskState.Fetched);
			IXUILabel ixuilabel = btn.gameObject.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = btn.gameObject.transform.Find("RedPoint").GetComponent("XUISprite") as IXUISprite;
			ixuilabel.SetText((state == ActivityTaskState.Uncomplete) ? XStringDefineProxy.GetString("PVPActivity_Go") : XStringDefineProxy.GetString("SRS_FETCH"));
			ixuisprite.SetVisible(state == ActivityTaskState.Complete);
			btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnItemBtnClick));
		}

		// Token: 0x0600FD1B RID: 64795 RVA: 0x003B39E0 File Offset: 0x003B1BE0
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

		// Token: 0x04006F59 RID: 28505
		private const int cnt = 4;

		// Token: 0x04006F5A RID: 28506
		private uint present;

		// Token: 0x04006F5B RID: 28507
		private IXUIProgress m_prograss;

		// Token: 0x04006F5C RID: 28508
		public IXUIButton m_btn;

		// Token: 0x04006F5D RID: 28509
		public IXUISprite m_sprRBg;

		// Token: 0x04006F5E RID: 28510
		public IXUILabel m_lblPoint;

		// Token: 0x04006F5F RID: 28511
		public IXUILabel m_bldesc;

		// Token: 0x04006F60 RID: 28512
		private XDummy m_Dummy;

		// Token: 0x04006F61 RID: 28513
		private IUIDummy m_Snapshot;

		// Token: 0x04006F62 RID: 28514
		public IXUILabel m_lblName;

		// Token: 0x04006F63 RID: 28515
		public IXUILabel m_lblTime;

		// Token: 0x04006F64 RID: 28516
		private IXUISprite m_sprEnd;

		// Token: 0x04006F65 RID: 28517
		private IXUISprite m_sprEndRed;

		// Token: 0x04006F66 RID: 28518
		private IXUISprite[] chests = new IXUISprite[4];

		// Token: 0x04006F67 RID: 28519
		private Transform[] reds = new Transform[4];

		// Token: 0x04006F68 RID: 28520
		private Transform[] chests2 = new Transform[4];

		// Token: 0x04006F69 RID: 28521
		private IXUIWrapContent m_wrap;

		// Token: 0x04006F6A RID: 28522
		private IXUIScrollView m_scroll;

		// Token: 0x04006F6B RID: 28523
		private List<BigPrizeNode> list;

		// Token: 0x04006F6C RID: 28524
		private int maxPoint = 0;

		// Token: 0x04006F6D RID: 28525
		private int itemid = 0;
	}
}
