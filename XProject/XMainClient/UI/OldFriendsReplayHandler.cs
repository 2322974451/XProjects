using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017E5 RID: 6117
	internal class OldFriendsReplayHandler : DlgHandlerBase
	{
		// Token: 0x170038B9 RID: 14521
		// (get) Token: 0x0600FD93 RID: 64915 RVA: 0x003B77C4 File Offset: 0x003B59C4
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/OldFriendsBack";
			}
		}

		// Token: 0x0600FD94 RID: 64916 RVA: 0x003B77DC File Offset: 0x003B59DC
		protected override void Init()
		{
			base.Init();
			Transform transform = base.transform.Find("ThreeRoot/Item");
			Transform transform2 = base.transform.Find("ThreeRoot");
			Transform transform3 = base.transform.Find("FiveRoot");
			IXUILabel ixuilabel = transform2.Find("ThreeLabel").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = transform3.Find("FiveLabel").GetComponent("XUILabel") as IXUILabel;
			List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("BackThreeFriendsCount");
			string @string = XSingleton<XStringTable>.singleton.GetString("BackOldFriendsTip");
			ixuilabel.SetText(string.Format(@string, intList[0]));
			ixuilabel2.SetText(string.Format(@string, intList[1]));
			IXUISprite ixuisprite = base.transform.Find("DetailBtn").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OpenUrl));
			this._itemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 8U, false);
			this._itemPool.ReturnAll(false);
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("BackThreeFriendsRewards", true);
			for (int i = 0; i < (int)sequenceList.Count; i++)
			{
				GameObject gameObject = this._itemPool.FetchGameObject(false);
				gameObject.transform.parent = transform2;
				gameObject.transform.localPosition = new Vector3((float)(this._itemPool.TplWidth * i), 0f, 0f);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, sequenceList[i, 0], sequenceList[i, 1], false);
				IXUISprite ixuisprite2 = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.ID = (ulong)((long)sequenceList[i, 0]);
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
			SeqList<int> sequenceList2 = XSingleton<XGlobalConfig>.singleton.GetSequenceList("BackFiveFriendsRewards", true);
			for (int j = 0; j < (int)sequenceList2.Count; j++)
			{
				GameObject gameObject2 = this._itemPool.FetchGameObject(false);
				gameObject2.transform.parent = transform3;
				gameObject2.transform.localPosition = new Vector3((float)(this._itemPool.TplWidth * j), 0f, 0f);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, sequenceList2[j, 0], sequenceList2[j, 1], false);
				IXUISprite ixuisprite3 = gameObject2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite3.ID = (ulong)((long)sequenceList2[j, 0]);
				ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
		}

		// Token: 0x0600FD95 RID: 64917 RVA: 0x003B7AF7 File Offset: 0x003B5CF7
		private void OpenUrl(IXUISprite uiSprite)
		{
			XSingleton<UiUtility>.singleton.OpenHtmlUrl("BackThreeFriendsUrl");
		}

		// Token: 0x0600FD96 RID: 64918 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600FD97 RID: 64919 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600FD98 RID: 64920 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnHide()
		{
		}

		// Token: 0x04006FDB RID: 28635
		protected XUIPool _itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
