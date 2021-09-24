using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildBuffOperationHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Guild/GuildMine/PropsFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.InitProperties();
			this.InitUIPool();
			this.InitUI();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

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

		protected override void OnHide()
		{
			this._close = false;
			base.OnHide();
		}

		public override void OnUnload()
		{
			this._tableChildren.Clear();
			this._slider = null;
			this._curTween = null;
			this._curTargetGuildID = 0UL;
			this._curBuffItemID = 0U;
			base.OnUnload();
		}

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

		public void ResetPostion()
		{
			bool flag = this._slider != null;
			if (flag)
			{
				this._slider.ResetTween(true);
			}
		}

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

		private void InitUIPool()
		{
			this._buffDetailItemPool.SetupPool(this._buffTableTrans.gameObject, this._buffTableTrans.Find("ItemTpl").gameObject, 10U, false);
			this._guildUseItemPool.SetupPool(this._buffTableTrans.gameObject, this._buffTableTrans.Find("Other").gameObject, 7U, false);
			this._personalUseItemPool.SetupPool(this._buffTableTrans.gameObject, this._buffTableTrans.Find("Use").gameObject, 4U, false);
		}

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

		private void OnNoBuffCard(IXUISprite uiSprite)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_GUILDBUFF_ITEM"), "fece00");
		}

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

		private bool OnClickBuffItem(IXUICheckBox iXUICheckBox)
		{
			return false;
		}

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

		private bool HasNoCardCD()
		{
			return XGuildResContentionBuffDocument.Doc.GuildBuffCDTime <= 0U;
		}

		private void ResetBuffItemSpriteState()
		{
			foreach (KeyValuePair<uint, Transform> keyValuePair in this._tableChildren)
			{
				IXUISprite ixuisprite = keyValuePair.Value.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetEnabled(true);
			}
		}

		private IXUITweenTool _slider;

		private IXUITweenTool _curTween = null;

		private ulong _curTargetGuildID = 0UL;

		private uint _curBuffItemID = 0U;

		private Dictionary<uint, Transform> _tableChildren = new Dictionary<uint, Transform>();

		protected XUIPool _buffDetailItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		protected XUIPool _personalUseItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		protected XUIPool _guildUseItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		protected IXUITable _buffTable;

		protected Transform _buffTableTrans;

		private bool _close;

		private bool _inited;

		private bool sliding = false;
	}
}
