using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CF8 RID: 3320
	internal class FirstPassRewardView : DlgBase<FirstPassRewardView, FirstPassRewardBehaviour>
	{
		// Token: 0x1700329F RID: 12959
		// (get) Token: 0x0600B99C RID: 47516 RVA: 0x0025BE08 File Offset: 0x0025A008
		private FirstPassDocument m_doc
		{
			get
			{
				return FirstPassDocument.Doc;
			}
		}

		// Token: 0x170032A0 RID: 12960
		// (get) Token: 0x0600B99D RID: 47517 RVA: 0x0025BE20 File Offset: 0x0025A020
		public override string fileName
		{
			get
			{
				return "OperatingActivity/FirstPassReward";
			}
		}

		// Token: 0x170032A1 RID: 12961
		// (get) Token: 0x0600B99E RID: 47518 RVA: 0x0025BE38 File Offset: 0x0025A038
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170032A2 RID: 12962
		// (get) Token: 0x0600B99F RID: 47519 RVA: 0x0025BE4C File Offset: 0x0025A04C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170032A3 RID: 12963
		// (get) Token: 0x0600B9A0 RID: 47520 RVA: 0x0025BE60 File Offset: 0x0025A060
		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600B9A1 RID: 47521 RVA: 0x0025BE73 File Offset: 0x0025A073
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600B9A2 RID: 47522 RVA: 0x0025BE7D File Offset: 0x0025A07D
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600B9A3 RID: 47523 RVA: 0x0025BEA4 File Offset: 0x0025A0A4
		protected override void OnUnload()
		{
			base.uiBehaviour.m_ItemPool1.ReturnAll(false);
			base.uiBehaviour.m_ItemPool2.ReturnAll(false);
			base.OnUnload();
		}

		// Token: 0x0600B9A4 RID: 47524 RVA: 0x0025BED2 File Offset: 0x0025A0D2
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0600B9A5 RID: 47525 RVA: 0x0025BEDC File Offset: 0x0025A0DC
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B9A6 RID: 47526 RVA: 0x0025BEE6 File Offset: 0x0025A0E6
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600B9A7 RID: 47527 RVA: 0x0025BEF7 File Offset: 0x0025A0F7
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600B9A8 RID: 47528 RVA: 0x0025BF04 File Offset: 0x0025A104
		private void FillContent()
		{
			base.uiBehaviour.m_ItemPool1.ReturnAll(false);
			base.uiBehaviour.m_ItemPool2.ReturnAll(false);
			for (int i = 0; i < this.m_doc.CurData.PassRewardList.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_ItemPool1.FetchGameObject(false);
				gameObject.transform.parent = base.uiBehaviour.m_itemParentGo.transform;
				gameObject.name = i.ToString();
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)base.uiBehaviour.m_ItemPool1.TplHeight * i), 0f);
				IXUILabel ixuilabel = gameObject.transform.FindChild("T").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(this.GetStrByIndex(i));
				bool flag = i == 0;
				if (flag)
				{
					ixuilabel = (gameObject.transform.FindChild("ch").GetComponent("XUILabel") as IXUILabel);
					ixuilabel.gameObject.SetActive(true);
					ixuilabel.SetText(XStringDefineProxy.GetString("FirstPassPlayerTittle"));
				}
				else
				{
					gameObject.transform.FindChild("ch").gameObject.SetActive(false);
				}
				this.FillItem(this.m_doc.CurData.PassRewardList[i], gameObject);
			}
		}

		// Token: 0x0600B9A9 RID: 47529 RVA: 0x0025C094 File Offset: 0x0025A294
		private void FillItem(RewardAuxData data, GameObject parentGo)
		{
			for (int i = 0; i < data.RewardDataList.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_ItemPool2.FetchGameObject(false);
				gameObject.transform.parent = parentGo.transform;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3((float)(-170 + base.uiBehaviour.m_ItemPool2.TplWidth * i), -16f, 0f);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)data.RewardDataList[i].Id);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, data.RewardDataList[i].Id, data.RewardDataList[i].Count, false);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
		}

		// Token: 0x0600B9AA RID: 47530 RVA: 0x0025C1B4 File Offset: 0x0025A3B4
		private string GetStrByIndex(int index)
		{
			string @string;
			switch (index)
			{
			case 0:
				@string = XStringDefineProxy.GetString("FirstPassReward");
				break;
			case 1:
				@string = XStringDefineProxy.GetString("FirstPassReward1");
				break;
			case 2:
				@string = XStringDefineProxy.GetString("FirstPassReward2");
				break;
			case 3:
				@string = XStringDefineProxy.GetString("FirstPassReward3");
				break;
			case 4:
				@string = XStringDefineProxy.GetString("FirstPassReward4");
				break;
			default:
				@string = XStringDefineProxy.GetString("XSys_Flower_Rank_Award");
				break;
			}
			return @string;
		}

		// Token: 0x0600B9AB RID: 47531 RVA: 0x0025C230 File Offset: 0x0025A430
		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisible(false, true);
			return true;
		}
	}
}
