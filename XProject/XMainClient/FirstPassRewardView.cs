using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class FirstPassRewardView : DlgBase<FirstPassRewardView, FirstPassRewardBehaviour>
	{

		private FirstPassDocument m_doc
		{
			get
			{
				return FirstPassDocument.Doc;
			}
		}

		public override string fileName
		{
			get
			{
				return "OperatingActivity/FirstPassReward";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnUnload()
		{
			base.uiBehaviour.m_ItemPool1.ReturnAll(false);
			base.uiBehaviour.m_ItemPool2.ReturnAll(false);
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

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

		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisible(false, true);
			return true;
		}
	}
}
