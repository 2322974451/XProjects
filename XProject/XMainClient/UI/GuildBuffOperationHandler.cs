using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001769 RID: 5993
	internal class GuildBuffOperationHandler : DlgHandlerBase
	{
		// Token: 0x1700380F RID: 14351
		// (get) Token: 0x0600F755 RID: 63317 RVA: 0x00384504 File Offset: 0x00382704
		protected override string FileName
		{
			get
			{
				return "Guild/GuildMine/PropsFrame";
			}
		}

		// Token: 0x0600F756 RID: 63318 RVA: 0x0038451B File Offset: 0x0038271B
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
			this.InitUIPool();
			this.InitUI();
		}

		// Token: 0x0600F757 RID: 63319 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600F758 RID: 63320 RVA: 0x0038453C File Offset: 0x0038273C
		protected override void OnShow()
		{
			base.OnShow();
			this._close = false;
			this.RefreshUI();
			this.sliding = true;
			this.StartToSlide();
			bool flag = !this._inited;
			if (flag)
			{
				this._inited = true;
				this.FoldChildren();
			}
		}

		// Token: 0x0600F759 RID: 63321 RVA: 0x0038458A File Offset: 0x0038278A
		protected override void OnHide()
		{
			this._close = false;
			base.OnHide();
		}

		// Token: 0x0600F75A RID: 63322 RVA: 0x0038459B File Offset: 0x0038279B
		public override void OnUnload()
		{
			this._tableChildren.Clear();
			this._slider = null;
			this._curTween = null;
			this._curTargetGuildID = 0UL;
			this._curBuffItemID = 0U;
			base.OnUnload();
		}

		// Token: 0x0600F75B RID: 63323 RVA: 0x003845D0 File Offset: 0x003827D0
		public void StartToSlide()
		{
			bool flag = this._slider != null;
			if (flag)
			{
				bool bPlayForward = this._slider.bPlayForward;
				if (bPlayForward)
				{
					bool flag2 = this._curTween != null;
					if (flag2)
					{
						this._curTween.PlayTween(false, -1f);
					}
					this._curTween = null;
					this._slider.PlayTween(false, -1f);
				}
				else
				{
					this._slider.PlayTween(true, -1f);
				}
			}
		}

		// Token: 0x0600F75C RID: 63324 RVA: 0x0038464C File Offset: 0x0038284C
		public void RefreshCardCd()
		{
			GuildBuffTable guildBuffData = XGuildResContentionBuffDocument.GuildBuffData;
			uint guildBuffCDTime = XGuildResContentionBuffDocument.Doc.GuildBuffCDTime;
			for (int i = 0; i < guildBuffData.Table.Length; i++)
			{
				Transform transform = null;
				uint itemid = guildBuffData.Table[i].itemid;
				bool flag = this._tableChildren.TryGetValue(itemid, out transform);
				if (flag)
				{
					Transform transform2 = transform.Find("CDTime");
					transform2.gameObject.SetActive(true);
					IXUILabel ixuilabel = transform2.GetComponent("XUILabel") as IXUILabel;
					bool flag2 = guildBuffCDTime > 0U;
					if (flag2)
					{
						ixuilabel.SetText(XGuildResContentionBuffDocument.Doc.GuildBuffCDTime.ToString());
					}
					else
					{
						transform2.gameObject.SetActive(false);
					}
				}
			}
		}

		// Token: 0x0600F75D RID: 63325 RVA: 0x0038471C File Offset: 0x0038291C
		public void RefreshOwnedBuffItem(uint itemID, uint cd)
		{
			this.UpdateBuffItemByItemID(itemID);
			bool flag = cd > 0U && this._curTween != null;
			if (flag)
			{
				this._curTween.PlayTween(false, -1f);
				this._curTween = null;
			}
			uint guildBuffCDTime = XGuildResContentionBuffDocument.Doc.GuildBuffCDTime;
			bool flag2 = guildBuffCDTime > 0U;
			if (flag2)
			{
				this.RefreshCardCd();
			}
		}

		// Token: 0x0600F75E RID: 63326 RVA: 0x0038477C File Offset: 0x0038297C
		public void FoldByHasGuildBuffCd()
		{
			uint guildBuffCDTime = XGuildResContentionBuffDocument.Doc.GuildBuffCDTime;
			bool flag = guildBuffCDTime > 0U && this._curTween != null;
			if (flag)
			{
				this._curTween.PlayTween(false, -1f);
				this._curTween = null;
			}
		}

		// Token: 0x0600F75F RID: 63327 RVA: 0x003847C4 File Offset: 0x003829C4
		public void ResetPostion()
		{
			bool flag = this._slider != null;
			if (flag)
			{
				this._slider.ResetTween(true);
			}
		}

		// Token: 0x0600F760 RID: 63328 RVA: 0x003847EC File Offset: 0x003829EC
		private void InitProperties()
		{
			this._buffTableTrans = base.transform.FindChild("ScrollPanel/UITable");
			this._buffTable = (this._buffTableTrans.GetComponent("XUITable") as IXUITable);
			this._slider = (base.transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			this._slider.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.SetVisible));
			IXUIButton ixuibutton = base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnclickCloseBtn));
			this._inited = false;
		}

		// Token: 0x0600F761 RID: 63329 RVA: 0x00384898 File Offset: 0x00382A98
		private void FoldChildren()
		{
			foreach (object obj in this._buffTableTrans)
			{
				Transform transform = (Transform)obj;
				bool activeSelf = transform.gameObject.activeSelf;
				if (activeSelf)
				{
					Transform transform2 = transform.gameObject.transform.Find("Child");
					IXUITweenTool ixuitweenTool = transform2.GetComponent("XUIPlayTween") as IXUITweenTool;
					ixuitweenTool.PlayTween(true, -1f);
				}
			}
		}

		// Token: 0x0600F762 RID: 63330 RVA: 0x0038493C File Offset: 0x00382B3C
		private bool OnclickCloseBtn(IXUIButton button)
		{
			bool flag = this.sliding;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.StartToSlide();
				this._close = true;
				result = true;
			}
			return result;
		}

		// Token: 0x0600F763 RID: 63331 RVA: 0x0038496C File Offset: 0x00382B6C
		private void SetVisible(IXUITweenTool tween)
		{
			bool close = this._close;
			if (close)
			{
				base.SetVisible(false);
			}
			else
			{
				this.sliding = false;
			}
		}

		// Token: 0x0600F764 RID: 63332 RVA: 0x00384998 File Offset: 0x00382B98
		private void InitUIPool()
		{
			this._buffDetailItemPool.SetupPool(this._buffTableTrans.gameObject, this._buffTableTrans.Find("ItemTpl").gameObject, 10U, false);
			this._guildUseItemPool.SetupPool(this._buffTableTrans.gameObject, this._buffTableTrans.Find("Other").gameObject, 7U, false);
			this._personalUseItemPool.SetupPool(this._buffTableTrans.gameObject, this._buffTableTrans.Find("Use").gameObject, 4U, false);
		}

		// Token: 0x0600F765 RID: 63333 RVA: 0x00384A34 File Offset: 0x00382C34
		private void InitUI()
		{
			this._tableChildren.Clear();
			this._buffDetailItemPool.ReturnAll(false);
			this._guildUseItemPool.ReturnAll(false);
			this._personalUseItemPool.ReturnAll(false);
			foreach (GuildMineralStorage.RowData rowData in XGuildResContentionBuffDocument.GuildMineralStorageTable.Table)
			{
				Transform transform = this._buffDetailItemPool.FetchGameObject(false).transform;
				Transform transform2 = transform.Find("Child");
				Transform transform3 = null;
				GuildBuffTargetType self = (GuildBuffTargetType)rowData.self;
				if (self > GuildBuffTargetType.SelfGuild)
				{
					if (self == GuildBuffTargetType.OtherGuild)
					{
						transform3 = this._guildUseItemPool.FetchGameObject(false).transform;
					}
				}
				else
				{
					transform3 = this._personalUseItemPool.FetchGameObject(false).transform;
				}
				Vector2 vector = transform2.localScale;
				transform.parent = this._buffTableTrans;
				transform2.localScale = Vector3.one;
				transform3.parent = transform2;
				transform2.localScale = vector;
				this._tableChildren.Add(rowData.itemid, transform);
			}
		}

		// Token: 0x0600F766 RID: 63334 RVA: 0x00384B58 File Offset: 0x00382D58
		private void RefreshUI()
		{
			this._curTween = null;
			foreach (GuildMineralStorage.RowData rowData in XGuildResContentionBuffDocument.GuildMineralStorageTable.Table)
			{
				Transform transform = null;
				bool flag = this._tableChildren.TryGetValue(rowData.itemid, out transform);
				if (flag)
				{
					Transform transform2 = transform.Find("Child");
					Transform child = transform2.GetChild(0);
					this.UpdateBuffItem(transform, child, rowData);
				}
			}
			uint guildBuffCDTime = XGuildResContentionBuffDocument.Doc.GuildBuffCDTime;
			bool flag2 = guildBuffCDTime > 0U;
			if (flag2)
			{
				this.RefreshCardCd();
			}
		}

		// Token: 0x0600F767 RID: 63335 RVA: 0x00384BF0 File Offset: 0x00382DF0
		private void UpdateBuffItem(Transform parent, Transform child, GuildMineralStorage.RowData info)
		{
			IXUICheckBox ixuicheckBox = parent.GetComponent("XUICheckBox") as IXUICheckBox;
			ixuicheckBox.ID = (ulong)info.itemid;
			ixuicheckBox.ForceSetFlag(true);
			ixuicheckBox.ForceSetFlag(false);
			IXUISprite ixuisprite = ixuicheckBox.gameObject.GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = parent.Find("BuffName").GetComponent("XUILabel") as IXUILabel;
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)info.itemid);
			ixuilabel.SetText(itemConf.ItemName[0]);
			IXUISprite ixuisprite2 = parent.Find("BuffIcon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.SetSprite(itemConf.ItemIcon[0]);
			IXUILabel ixuilabel2 = parent.Find("Des").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText(info.effect);
			IXUILabel ixuilabel3 = parent.Find("Count").GetComponent("XUILabel") as IXUILabel;
			ixuilabel3.SetText("");
			Transform transform = parent.Find("CDTime");
			transform.gameObject.SetActive(false);
			Transform transform2 = parent.Find("TargetPersonal");
			transform2.gameObject.SetActive(info.self == 0U);
			Transform transform3 = parent.Find("TargetOtherGuild");
			transform3.gameObject.SetActive(info.self == 2U);
			Transform transform4 = parent.Find("TargetMyGuild");
			transform4.gameObject.SetActive(info.self == 1U);
			GuildBuffInfo ownedBuffInfo = this.GetOwnedBuffInfo(info);
			bool flag = ownedBuffInfo == null;
			if (flag)
			{
				ixuisprite.SetColor(new Color(0f, 0f, 0f, 1f));
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnNoBuffCard));
			}
			else
			{
				ixuisprite.SetColor(Color.white);
				ixuilabel3.SetText("X" + ownedBuffInfo.count);
				ixuisprite.ID = (ulong)info.itemid;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnclickBuffSprite));
			}
			bool flag2 = info.self == 2U;
			if (flag2)
			{
				WarResGuildInfo pkguildInfos = XGuildResContentionBuffDocument.Doc.GetPKGuildInfos(1);
				bool flag3 = pkguildInfos != null;
				if (flag3)
				{
					Transform transform5 = child.Find("OneGuild");
					IXUIButton ixuibutton = transform5.GetComponent("XUIButton") as IXUIButton;
					ixuibutton.ID = pkguildInfos.guildID;
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.UseBuffOnGuild));
					IXUILabel ixuilabel4 = transform5.Find("Name").GetComponent("XUILabel") as IXUILabel;
					ixuilabel4.SetText(pkguildInfos.guildName);
				}
				pkguildInfos = XGuildResContentionBuffDocument.Doc.GetPKGuildInfos(2);
				bool flag4 = pkguildInfos != null;
				if (flag4)
				{
					Transform transform6 = child.Find("TwoGuild");
					IXUIButton ixuibutton2 = transform6.GetComponent("XUIButton") as IXUIButton;
					ixuibutton2.ID = pkguildInfos.guildID;
					ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.UseBuffOnGuild));
					IXUILabel ixuilabel5 = transform6.Find("Name").GetComponent("XUILabel") as IXUILabel;
					ixuilabel5.SetText(pkguildInfos.guildName);
				}
			}
			else
			{
				IXUIButton ixuibutton3 = child.GetComponent("XUIButton") as IXUIButton;
				ixuibutton3.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnUsePositiveBuff));
			}
		}

		// Token: 0x0600F768 RID: 63336 RVA: 0x00384F64 File Offset: 0x00383164
		private void OnNoBuffCard(IXUISprite uiSprite)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_GUILDBUFF_ITEM"), "fece00");
		}

		// Token: 0x0600F769 RID: 63337 RVA: 0x00384F88 File Offset: 0x00383188
		private GuildBuffInfo GetOwnedBuffInfo(GuildMineralStorage.RowData info)
		{
			bool flag = info.self > 0U;
			GuildBuffInfo result;
			if (flag)
			{
				result = XGuildResContentionBuffDocument.Doc.GetGuildOwnedSomeCardInfo(info.itemid);
			}
			else
			{
				result = XGuildResContentionBuffDocument.Doc.GetMyOwnedSomeCardInfo(info.itemid);
			}
			return result;
		}

		// Token: 0x0600F76A RID: 63338 RVA: 0x00384FD0 File Offset: 0x003831D0
		private void OnclickBuffSprite(IXUISprite uiSprite)
		{
			Transform transform = uiSprite.gameObject.transform.Find("Child");
			IXUITweenTool ixuitweenTool = transform.GetComponent("XUIPlayTween") as IXUITweenTool;
			bool bPlayForward = ixuitweenTool.bPlayForward;
			if (bPlayForward)
			{
				ixuitweenTool.PlayTween(false, -1f);
			}
			else
			{
				ixuitweenTool.PlayTween(true, -1f);
			}
			this._curBuffItemID = (uint)uiSprite.ID;
			bool flag = this._curTween == null;
			if (flag)
			{
				this._curTween = ixuitweenTool;
			}
			else
			{
				bool flag2 = this._curTween != ixuitweenTool;
				if (flag2)
				{
					this._curTween.PlayTween(false, -1f);
					this._curTween = ixuitweenTool;
				}
				else
				{
					this._curTween = null;
				}
			}
		}

		// Token: 0x0600F76B RID: 63339 RVA: 0x00385088 File Offset: 0x00383288
		private bool OnClickBuffItem(IXUICheckBox iXUICheckBox)
		{
			return false;
		}

		// Token: 0x0600F76C RID: 63340 RVA: 0x0038509C File Offset: 0x0038329C
		private void UpdateBuffItemByItemID(uint itemID)
		{
			Transform transform = null;
			bool flag = this._tableChildren.TryGetValue(itemID, out transform);
			if (flag)
			{
				GuildMineralStorage.RowData mineralStorageByID = XGuildResContentionBuffDocument.Doc.GetMineralStorageByID(itemID);
				bool flag2 = mineralStorageByID == null;
				if (!flag2)
				{
					Transform child = transform.Find("Child").GetChild(0);
					bool flag3 = this._curBuffItemID == itemID;
					if (flag3)
					{
						GuildBuffInfo ownedBuffInfo = this.GetOwnedBuffInfo(mineralStorageByID);
						bool flag4 = ownedBuffInfo == null;
						if (flag4)
						{
							bool flag5 = this._curTween != null;
							if (flag5)
							{
								this._curTween.PlayTween(false, -1f);
								this._curTween = null;
							}
						}
					}
					this.UpdateBuffItem(transform, child, mineralStorageByID);
				}
			}
		}

		// Token: 0x0600F76D RID: 63341 RVA: 0x00385148 File Offset: 0x00383348
		private bool UseBuffOnGuild(IXUIButton button)
		{
			bool flag = this.HasNoCardCD();
			if (flag)
			{
				this._curTargetGuildID = button.ID;
				XGuildResContentionBuffDocument.Doc.SendGuildBuffReq(this._curTargetGuildID, this._curBuffItemID);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("HasGuildBuffCD"), XGuildResContentionBuffDocument.Doc.GuildBuffCDTime), "fece00");
			}
			return true;
		}

		// Token: 0x0600F76E RID: 63342 RVA: 0x003851C4 File Offset: 0x003833C4
		private bool OnUsePositiveBuff(IXUIButton button)
		{
			GuildMineralStorage.RowData mineralStorageByID = XGuildResContentionBuffDocument.Doc.GetMineralStorageByID(this._curBuffItemID);
			bool flag = mineralStorageByID == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = mineralStorageByID.self == 0U;
				if (flag2)
				{
					XGuildResContentionBuffDocument.Doc.SendPersonalBuffOpReq(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, this._curBuffItemID, PersonalBuffOpType.UseBuff);
				}
				else
				{
					XGuildResContentionBuffDocument.Doc.SendGuildBuffReq(XGuildResContentionBuffDocument.Doc.GuildID, this._curBuffItemID);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600F76F RID: 63343 RVA: 0x00385244 File Offset: 0x00383444
		private bool HasNoCardCD()
		{
			return XGuildResContentionBuffDocument.Doc.GuildBuffCDTime <= 0U;
		}

		// Token: 0x0600F770 RID: 63344 RVA: 0x00385268 File Offset: 0x00383468
		private void ResetBuffItemSpriteState()
		{
			foreach (KeyValuePair<uint, Transform> keyValuePair in this._tableChildren)
			{
				IXUISprite ixuisprite = keyValuePair.Value.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetEnabled(true);
			}
		}

		// Token: 0x04006BAC RID: 27564
		private IXUITweenTool _slider;

		// Token: 0x04006BAD RID: 27565
		private IXUITweenTool _curTween = null;

		// Token: 0x04006BAE RID: 27566
		private ulong _curTargetGuildID = 0UL;

		// Token: 0x04006BAF RID: 27567
		private uint _curBuffItemID = 0U;

		// Token: 0x04006BB0 RID: 27568
		private Dictionary<uint, Transform> _tableChildren = new Dictionary<uint, Transform>();

		// Token: 0x04006BB1 RID: 27569
		protected XUIPool _buffDetailItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006BB2 RID: 27570
		protected XUIPool _personalUseItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006BB3 RID: 27571
		protected XUIPool _guildUseItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006BB4 RID: 27572
		protected IXUITable _buffTable;

		// Token: 0x04006BB5 RID: 27573
		protected Transform _buffTableTrans;

		// Token: 0x04006BB6 RID: 27574
		private bool _close;

		// Token: 0x04006BB7 RID: 27575
		private bool _inited;

		// Token: 0x04006BB8 RID: 27576
		private bool sliding = false;
	}
}
