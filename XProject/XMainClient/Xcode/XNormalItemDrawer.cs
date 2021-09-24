using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XNormalItemDrawer : XItemDrawer, IXNormalItemDrawer, IXInterface
	{

		public void OpenClickShowTooltipEvent(GameObject go, int itemid)
		{
			this.OpenClickShowTooltipEvent(go, itemid, new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
		}

		public bool Deprecated { get; set; }

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

		private void _SetUp(GameObject go, int itemid, int itemCount = 0, bool bForceShowNum = false)
		{
			this._SetupIcon();
			this._SetupName(null);
			base._SetupNum(itemCount, bForceShowNum);
			this._SetupNumTop(null);
		}

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

		protected override void DrawEmpty()
		{
			base.DrawEmpty();
		}
	}
}
