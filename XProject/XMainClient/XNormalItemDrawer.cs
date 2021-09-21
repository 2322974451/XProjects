using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F09 RID: 3849
	internal class XNormalItemDrawer : XItemDrawer, IXNormalItemDrawer, IXInterface
	{
		// Token: 0x0600CC67 RID: 52327 RVA: 0x002F0AF2 File Offset: 0x002EECF2
		public void OpenClickShowTooltipEvent(GameObject go, int itemid)
		{
			this.OpenClickShowTooltipEvent(go, itemid, new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
		}

		// Token: 0x17003595 RID: 13717
		// (get) Token: 0x0600CC68 RID: 52328 RVA: 0x002F0B0E File Offset: 0x002EED0E
		// (set) Token: 0x0600CC69 RID: 52329 RVA: 0x002F0B16 File Offset: 0x002EED16
		public bool Deprecated { get; set; }

		// Token: 0x0600CC6A RID: 52330 RVA: 0x002F0B20 File Offset: 0x002EED20
		public void OpenClickShowTooltipEvent(GameObject go, int itemid, SpriteClickEventHandler eventHandler)
		{
			bool flag = null == go;
			if (!flag)
			{
				Transform transform = go.transform.FindChild("Icon");
				bool flag2 = transform != null;
				if (flag2)
				{
					IXUISprite ixuisprite = transform.GetComponent("XUISprite") as IXUISprite;
					bool flag3 = ixuisprite != null;
					if (flag3)
					{
						ixuisprite.ID = (ulong)((long)itemid);
						ixuisprite.RegisterSpriteClickEventHandler(eventHandler);
					}
				}
			}
		}

		// Token: 0x0600CC6B RID: 52331 RVA: 0x002F0B88 File Offset: 0x002EED88
		public void CloseClickShowTooltipEvent(GameObject go)
		{
			bool flag = null == go;
			if (!flag)
			{
				Transform transform = go.transform.FindChild("Icon");
				bool flag2 = transform != null;
				if (flag2)
				{
					IXUISprite ixuisprite = transform.GetComponent("XUISprite") as IXUISprite;
					bool flag3 = ixuisprite != null;
					if (flag3)
					{
						ixuisprite.RegisterSpriteClickEventHandler(null);
					}
				}
			}
		}

		// Token: 0x0600CC6C RID: 52332 RVA: 0x002F0BE8 File Offset: 0x002EEDE8
		public void DrawItem(GameObject go, ItemList.RowData data, int itemCount = 0, bool bForceShowNum = false)
		{
			this._GetUI(go);
			this.itemdata = data;
			bool flag = this.itemdata == null;
			if (flag)
			{
				this.DrawEmpty();
				this._ClearVariables();
			}
			else
			{
				this._SetupIcon();
				this._SetupAttrIcon(null);
				this._SetupName(null);
				base._SetupNum(itemCount, bForceShowNum);
				this._SetupNumTop(null);
				base._SetupLeftDownCorner(base._GetBindingState(null));
				base._SetupRightDownCorner(false);
				this.SetupLeftUpFragment(data.ItemID);
				base._SetupRightUpCorner(false);
				base._SetupMask();
				this.SetProf(null);
				this._ClearVariables();
			}
		}

		// Token: 0x0600CC6D RID: 52333 RVA: 0x002F0C90 File Offset: 0x002EEE90
		public void DrawItem(GameObject go, int itemid, int itemCount = 0, bool bForceShowNum = false)
		{
			this._GetUI(go);
			base._GetItemData(itemid);
			bool flag = this.itemdata == null;
			if (flag)
			{
				this.DrawEmpty();
				this._ClearVariables();
			}
			else
			{
				this._SetUp(go, itemid, itemCount, bForceShowNum);
				this._SetupAttrIcon(null);
				base._SetupLeftDownCorner(base._GetBindingState(null));
				base._SetupRightDownCorner(false);
				this.SetupLeftUpFragment(itemid);
				base._SetupRightUpCorner(false);
				base._SetupMask();
				this.SetProf(null);
				this._ClearVariables();
			}
		}

		// Token: 0x0600CC6E RID: 52334 RVA: 0x002F0D1C File Offset: 0x002EEF1C
		public override void DrawItem(GameObject go, XItem realItem, bool bForceShowNum = false)
		{
			bool flag = realItem == null;
			if (flag)
			{
				this.DrawItem(go, 0, 0, false);
			}
			else
			{
				this._GetUI(go);
				base._GetItemData(realItem.itemID);
				bool flag2 = this.itemdata == null;
				if (flag2)
				{
					this.DrawEmpty();
					this._ClearVariables();
				}
				else
				{
					this._SetUp(go, realItem.itemID, realItem.itemCount, bForceShowNum);
					this._SetupAttrIcon(null);
					base._SetupLeftDownCorner(base._GetBindingState(realItem));
					this.SetupLeftUpCorner(realItem);
					base._SetupRightDownCorner(false);
					base._SetupRightUpCorner(false);
					base._SetupMask();
					this.SetProf(realItem);
					this._ClearVariables();
				}
			}
		}

		// Token: 0x0600CC6F RID: 52335 RVA: 0x002F0DD0 File Offset: 0x002EEFD0
		private void _SetUp(GameObject go, int itemid, int itemCount = 0, bool bForceShowNum = false)
		{
			this._SetupIcon();
			this._SetupName(null);
			base._SetupNum(itemCount, bForceShowNum);
			this._SetupNumTop(null);
		}

		// Token: 0x0600CC70 RID: 52336 RVA: 0x002F0DF4 File Offset: 0x002EEFF4
		private void SetupLeftUpCorner(XItem realItem = null)
		{
			bool flag = realItem == null;
			if (flag)
			{
				base._SetupLeftUpCorner(false, "");
			}
			ItemType type = realItem.Type;
			if (type != ItemType.FRAGMENT)
			{
				if (type != ItemType.ARTIFACT)
				{
					base._SetupLeftUpCorner(false, "");
				}
				else
				{
					XArtifactItem xartifactItem = realItem as XArtifactItem;
					ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)realItem.itemID);
					bool flag2 = artifactListRowData == null || xartifactItem.EffectInfoList == null || (long)xartifactItem.EffectInfoList.Count <= (long)((ulong)artifactListRowData.EffectNum);
					if (flag2)
					{
						base._SetupLeftUpCorner(false, "");
					}
					else
					{
						base._SetupLeftUpCorner(true, "");
					}
				}
			}
			else
			{
				base._SetupLeftUpCorner(true, "sp_1");
			}
		}

		// Token: 0x0600CC71 RID: 52337 RVA: 0x002F0EA8 File Offset: 0x002EF0A8
		private void SetupLeftUpFragment(int itemid)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(itemid);
			bool flag = itemConf == null;
			if (flag)
			{
				base._SetupLeftUpCorner(false, "");
			}
			else
			{
				bool flag2 = itemConf.ItemType == 8;
				if (flag2)
				{
					base._SetupLeftUpCorner(true, "sp_1");
				}
				else
				{
					base._SetupLeftUpCorner(false, "");
				}
			}
		}

		// Token: 0x0600CC72 RID: 52338 RVA: 0x002F0F00 File Offset: 0x002EF100
		private void SetProf(XItem realItem = null)
		{
			bool flag = realItem == null || realItem.Type != ItemType.ARTIFACT;
			if (flag)
			{
				base._SetUpProf(false);
			}
			else
			{
				bool flag2 = XSingleton<XEntityMgr>.singleton.Player == null;
				if (flag2)
				{
					base._SetUpProf(false);
				}
				else
				{
					XArtifactItem xartifactItem = realItem as XArtifactItem;
					bool flag3 = xartifactItem.EffectInfoList != null;
					if (flag3)
					{
						for (int i = 0; i < xartifactItem.EffectInfoList.Count; i++)
						{
							bool flag4 = xartifactItem.EffectInfoList[i].BuffInfoList != null;
							if (flag4)
							{
								bool flag5 = xartifactItem.EffectInfoList[i].BaseProf == XSingleton<XEntityMgr>.singleton.Player.BasicTypeID;
								if (flag5)
								{
									base._SetUpProf(true);
									return;
								}
							}
						}
					}
					base._SetUpProf(false);
				}
			}
		}

		// Token: 0x0600CC73 RID: 52339 RVA: 0x002F0FED File Offset: 0x002EF1ED
		protected override void DrawEmpty()
		{
			base.DrawEmpty();
		}
	}
}
