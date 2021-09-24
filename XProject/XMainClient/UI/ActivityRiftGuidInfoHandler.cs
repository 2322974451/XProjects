using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	[Hotfix]
	internal class ActivityRiftGuidInfoHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_lblName = (base.transform.FindChild("Bg/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_lblTime = (base.transform.FindChild("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_btnClose = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_lblRank = (base.transform.FindChild("Bg/Floor").GetComponent("XUILabel") as IXUILabel);
			GameObject gameObject = base.transform.FindChild("Bg/root/RewardTpl").gameObject;
			GameObject gameObject2 = base.transform.FindChild("Bg/root/ScrollView").gameObject;
			this.m_scroll = (gameObject2.GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_RankPool.SetupPool(gameObject2, gameObject, 2U, false);
			for (int i = 0; i < 5; i++)
			{
				this.m_goBuff[i] = base.transform.FindChild("Bg/Buff/BossBuff" + i).gameObject;
			}
			bool flag = this._doc == null;
			if (flag)
			{
				this._doc = XDocuments.GetSpecificDocument<XRiftDocument>(XRiftDocument.uuID);
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
		}

		public override void OnUnload()
		{
			this._doc = null;
			base.OnUnload();
		}

		protected override void OnShow()
		{
			base.OnShow();
			bool flag = this._doc == null;
			if (flag)
			{
				this._doc = XDocuments.GetSpecificDocument<XRiftDocument>(XRiftDocument.uuID);
			}
			bool flag2 = this._doc.guildInfos != null && this._doc.guildInfos.Count > 0;
			if (flag2)
			{
				this.m_lblName.SetText(this._doc.guildInfos[0].roleInfo.name);
				this.m_lblRank.SetText(this._doc.guildInfos[0].riftFloor.ToString());
				this.m_lblTime.SetText(this._doc.guildInfos[0].costTime.ToString());
				this._bestRift = this._doc.GetRiftData(this._doc.guildInfos[0].riftFloor, this._doc.currGuidRiftID);
			}
			else
			{
				this.m_lblRank.SetText("0");
				this.m_lblTime.SetText("0");
			}
			this.RefreshBuff();
			this.RefreshRank();
		}

		private bool OnClose(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		private void RefreshBuff()
		{
			List<int> guildBuffIDs = this._doc.guildBuffIDs;
			int num = guildBuffIDs.Count + 2;
			Rift.RowData bestRift = this._bestRift;
			bool flag = bestRift == null;
			if (flag)
			{
				int i = 0;
				int num2 = this.m_goBuff.Length;
				while (i < num2)
				{
					this.m_goBuff[i].SetActive(false);
					i++;
				}
			}
			else
			{
				this.m_goBuff[0].SetActive(true);
				this.m_goBuff[1].SetActive(true);
				this.RefreshBuff(this.m_goBuff[0], string.Empty, XSingleton<XGlobalConfig>.singleton.GetValue("RiftAttr"), bestRift.attack + "%");
				this.RefreshBuff(this.m_goBuff[1], string.Empty, XSingleton<XGlobalConfig>.singleton.GetValue("RiftHP"), bestRift.hp + "%");
				for (int j = 2; j < num; j++)
				{
					RiftBuffSuitMonsterType.RowData buffSuitRow = this._doc.GetBuffSuitRow((uint)guildBuffIDs[j - 2], 1);
					this.m_goBuff[j].SetActive(true);
					this.RefreshBuff(this.m_goBuff[j], buffSuitRow.atlas, buffSuitRow.icon, string.Empty);
				}
				for (int k = num; k < this.m_goBuff.Length; k++)
				{
					this.m_goBuff[k].SetActive(false);
				}
			}
		}

		private void RefreshBuff(GameObject go, string atlas, string sp, string text)
		{
			IXUILabel ixuilabel = go.transform.FindChild("value").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = go.transform.FindChild("P").GetComponent("XUISprite") as IXUISprite;
			ixuilabel.SetText(text);
			bool flag = string.IsNullOrEmpty(atlas);
			if (flag)
			{
				ixuisprite.SetSprite(sp);
			}
			else
			{
				ixuisprite.SetSprite(sp, atlas, false);
			}
		}

		private void RefreshRank()
		{
			bool flag = this._doc.guildInfos != null;
			if (flag)
			{
				this.m_RankPool.FakeReturnAll();
				for (int i = 0; i < this._doc.guildInfos.Count; i++)
				{
					RiftGuildRankInfo riftGuildRankInfo = this._doc.guildInfos[i];
					GameObject gameObject = this.m_RankPool.FetchGameObject(false);
					IXUILabel label = gameObject.transform.FindChild("Bg/RankNum").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel = gameObject.transform.FindChild("Bg/T").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = gameObject.transform.FindChild("Bg/Floor").GetComponent("XUILabel") as IXUILabel;
					IXUISprite sp = gameObject.transform.FindChild("Bg/RankImage").GetComponent("XUISprite") as IXUISprite;
					XSingleton<UiUtility>.singleton.ShowRank(sp, label, i + 1);
					gameObject.transform.localPosition = this.m_RankPool.TplPos - new Vector3(0f, (float)(this.m_RankPool.TplHeight * i));
					ixuilabel.SetText(riftGuildRankInfo.roleInfo.name);
					int num = 3 * (5 - i) + 1;
					ixuilabel2.SetText(riftGuildRankInfo.riftFloor.ToString());
				}
				this.m_RankPool.ActualReturnAll(false);
			}
		}

		public IXUILabel m_lblRank;

		public IXUILabel m_lblTime;

		public IXUILabel m_lblName;

		public IXUIButton m_btnClose;

		public IXUIScrollView m_scroll;

		public GameObject[] m_goBuff = new GameObject[5];

		public XUIPool m_RankPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private const int max_buff = 5;

		public XRiftDocument _doc;

		private Rift.RowData _bestRift;
	}
}
