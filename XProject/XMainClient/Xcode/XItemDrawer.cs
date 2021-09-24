using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XItemDrawer
	{

		protected virtual string LeftDownCornerName
		{
			get
			{
				return "Bind";
			}
		}

		protected virtual string LeftUpCornerName
		{
			get
			{
				return "Emblem_0";
			}
		}

		protected virtual string RightDownCornerName
		{
			get
			{
				return "sp_wenzhang";
			}
		}

		protected virtual string RightUpCornerName
		{
			get
			{
				return "sp_1";
			}
		}

		private Dictionary<int, string> ProfNameDic
		{
			get
			{
				bool flag = this.m_profNameDic == null;
				if (flag)
				{
					this.m_profNameDic = new Dictionary<int, string>();
					string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("profIconName", XGlobalConfig.AllSeparators);
					bool flag2 = andSeparateValue.Length % 2 != 0;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("profIconName in gb had error", null, null, null, null, null);
					}
					else
					{
						int key = 0;
						for (int i = 0; i < andSeparateValue.Length; i += 2)
						{
							bool flag3 = int.TryParse(andSeparateValue[i], out key);
							if (flag3)
							{
								this.m_profNameDic.Add(key, andSeparateValue[i + 1]);
							}
							else
							{
								XSingleton<XDebug>.singleton.AddErrorLog(string.Format("profIconName in gb had error,index = {0} not a num", i), null, null, null, null, null);
							}
						}
					}
				}
				return this.m_profNameDic;
			}
		}

		protected virtual void _GetUI(GameObject uiGo)
		{
			this.m_uiTransform = uiGo.transform;
			Transform transform = uiGo.transform.FindChild("Icon/Icon");
			bool flag = transform != null;
			if (flag)
			{
				this.m_icon = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			else
			{
				this.m_icon = null;
			}
			transform = uiGo.transform.FindChild("Icon/Attr");
			bool flag2 = transform != null;
			if (flag2)
			{
				this.m_attrType = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			else
			{
				this.m_attrType = null;
			}
			transform = uiGo.transform.FindChild("Icon");
			bool flag3 = transform != null;
			if (flag3)
			{
				this.m_iconBg = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			else
			{
				this.m_iconBg = null;
			}
			transform = uiGo.transform.FindChild("Name");
			bool flag4 = transform != null;
			if (flag4)
			{
				this.m_name = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			else
			{
				this.m_name = null;
			}
			transform = uiGo.transform.FindChild("Quality");
			bool flag5 = transform != null;
			if (flag5)
			{
				this.m_quality = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			else
			{
				this.m_quality = null;
			}
			transform = uiGo.transform.FindChild("Num");
			bool flag6 = transform != null;
			if (flag6)
			{
				this.m_num = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			else
			{
				this.m_num = null;
			}
			transform = uiGo.transform.FindChild("NumTop");
			bool flag7 = transform != null;
			if (flag7)
			{
				this.m_numTop = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			else
			{
				this.m_numTop = null;
			}
			transform = uiGo.transform.FindChild("LeftDownCorner/Icon");
			bool flag8 = transform != null;
			if (flag8)
			{
				this.m_leftDownCorner = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			else
			{
				this.m_leftDownCorner = null;
			}
			transform = uiGo.transform.FindChild("LeftUpCorner/Icon");
			bool flag9 = transform != null;
			if (flag9)
			{
				this.m_leftUpCorner = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			else
			{
				this.m_leftUpCorner = null;
			}
			transform = uiGo.transform.FindChild("RightDownCorner/Icon");
			bool flag10 = transform != null;
			if (flag10)
			{
				this.m_rightDownCorner = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			else
			{
				this.m_rightDownCorner = null;
			}
			transform = uiGo.transform.FindChild("RightUpCorner/Icon");
			bool flag11 = transform != null;
			if (flag11)
			{
				this.m_rightUpCorner = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			else
			{
				this.m_rightUpCorner = null;
			}
			transform = uiGo.transform.FindChild("Mask/Icon");
			bool flag12 = transform != null;
			if (flag12)
			{
				this.m_mask = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			else
			{
				this.m_mask = null;
			}
			transform = uiGo.transform.FindChild("RightUpProf/Icon");
			bool flag13 = transform != null;
			if (flag13)
			{
				this.m_prof = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			else
			{
				this.m_prof = null;
			}
		}

		public virtual void DrawItem(GameObject go, XItem realItem, bool bForceShowNum = false)
		{
			this._GetUI(go);
			bool flag = realItem == null;
			if (flag)
			{
				this.DrawEmpty();
				this._ClearVariables();
			}
			else
			{
				this._GetItemData(realItem.itemID);
				this._SetupIcon();
				this._SetupAttrIcon(realItem);
				this._SetupName(realItem);
				this._SetupNum(realItem);
				this._SetupNumTop(realItem);
				this._SetupLeftDownCorner(this._GetBindingState(realItem));
				this._SetupLeftUpCorner(false, "");
				this._SetupRightDownCorner(false);
				this._SetupRightUpCorner(realItem.Type == ItemType.FRAGMENT);
				this._SetupMask();
				this._SetUpProf(false);
				this._ClearVariables();
			}
		}

		protected virtual void _SetupName(XItem item)
		{
			this._SetNameUI();
		}

		protected virtual void _SetupNum(XItem item)
		{
			this._SetupNum(item.itemCount, false);
		}

		protected virtual void _SetupNumTop(XItem item)
		{
			this._SetNumTopUI(null);
		}

		protected void _SetupLeftDownCorner(bool flag)
		{
			bool flag2 = flag && this.m_leftDownCorner == null;
			if (flag2)
			{
				this.m_leftDownCorner = this.GetCornerSpr("LeftDownCorner", ItemCornerType.LeftDown);
			}
			bool flag3 = this.m_leftDownCorner != null;
			if (flag3)
			{
				bool flag4 = !flag;
				if (flag4)
				{
					this.m_leftDownCorner.SetVisible(false);
				}
				else
				{
					this.m_leftDownCorner.SetVisible(true);
					this.m_leftDownCorner.SetSprite(this.LeftDownCornerName);
				}
			}
		}

		protected void _SetupLeftUpCorner(bool flag, string cornerName = "")
		{
			bool flag2 = flag && this.m_leftUpCorner == null;
			if (flag2)
			{
				this.m_leftUpCorner = this.GetCornerSpr("LeftUpCorner", ItemCornerType.LeftUp);
			}
			bool flag3 = this.m_leftUpCorner != null;
			if (flag3)
			{
				bool flag4 = !flag;
				if (flag4)
				{
					this.m_leftUpCorner.SetVisible(false);
				}
				else
				{
					this.m_leftUpCorner.SetVisible(true);
					bool flag5 = cornerName == "";
					if (flag5)
					{
						this.m_leftUpCorner.SetSprite(this.LeftUpCornerName);
					}
					else
					{
						this.m_leftUpCorner.SetSprite(cornerName);
					}
				}
			}
		}

		protected void _SetupRightDownCorner(bool flag)
		{
			bool flag2 = flag && this.m_rightDownCorner == null;
			if (flag2)
			{
				this.m_rightDownCorner = this.GetCornerSpr("RightDownCorner", ItemCornerType.RightDown);
			}
			bool flag3 = this.m_rightDownCorner != null;
			if (flag3)
			{
				bool flag4 = !flag;
				if (flag4)
				{
					this.m_rightDownCorner.SetVisible(false);
				}
				else
				{
					this.m_rightDownCorner.SetVisible(true);
					this.m_rightDownCorner.SetSprite(this.RightDownCornerName);
				}
			}
		}

		protected void _SetupRightUpCorner(bool flag)
		{
			bool flag2 = flag && this.m_rightUpCorner == null;
			if (flag2)
			{
				this.m_rightUpCorner = this.GetCornerSpr("RightUpCorner", ItemCornerType.RightUp);
			}
			bool flag3 = this.m_rightUpCorner != null;
			if (flag3)
			{
				bool flag4 = !flag;
				if (flag4)
				{
					this.m_rightUpCorner.SetVisible(false);
				}
				else
				{
					this.m_rightUpCorner.SetVisible(true);
					this.m_rightUpCorner.SetSprite(this.RightDownCornerName);
				}
			}
		}

		protected void _SetUpProf(bool flag)
		{
			bool flag2 = flag && this.m_prof == null;
			if (flag2)
			{
				this.m_prof = this.GetCornerSpr("RightUpProf", ItemCornerType.Prof);
			}
			bool flag3 = this.m_prof != null;
			if (flag3)
			{
				bool flag4 = !flag;
				if (flag4)
				{
					this.m_prof.SetVisible(false);
				}
				else
				{
					this.m_prof.SetVisible(true);
					this.m_prof.SetSprite(this.GetProfIconName());
				}
			}
		}

		protected void _SetupMask()
		{
			bool bShowMask = XItemDrawerMgr.Param.bShowMask;
			if (bShowMask)
			{
				this.m_maskName = "kuang_35";
				this._SetupMaskUI(true);
			}
			else
			{
				bool flag = this.itemdata == null;
				if (flag)
				{
					this._SetupMaskUI(false);
				}
				else
				{
					ItemType itemType = (ItemType)this.itemdata.ItemType;
					if (itemType != ItemType.EQUIP)
					{
						if (itemType != ItemType.ARTIFACT)
						{
							this._SetupMaskUI(false);
						}
						else
						{
							this._SetupLevelMask();
						}
					}
					else
					{
						bool flag2 = this._SetupLevelMask();
						if (!flag2)
						{
							this._SetupProfMask();
						}
					}
				}
			}
		}

		private void _SetupMaskUI(bool flag)
		{
			bool flag2 = flag && this.m_mask == null;
			if (flag2)
			{
				this.m_mask = this.GetCornerSpr("Mask", ItemCornerType.Center);
			}
			bool flag3 = this.m_mask != null;
			if (flag3)
			{
				bool flag4 = !flag;
				if (flag4)
				{
					this.m_mask.SetVisible(false);
				}
				else
				{
					this.m_mask.SetVisible(true);
					this.m_mask.SetSprite(this.m_maskName);
					bool flag5 = this.m_icon != null;
					if (flag5)
					{
						this.m_mask.transform.localScale = this.m_quality.transform.localScale;
						this.m_mask.spriteWidth = this.m_quality.spriteWidth * 7 / 9;
						this.m_mask.spriteHeight = this.m_quality.spriteHeight * 7 / 9;
					}
				}
			}
		}

		private IXUISprite GetCornerSpr(string name, ItemCornerType type)
		{
			GameObject go = XSingleton<XItemDrawerMgr>.singleton.GetGo(type);
			bool flag = go == null;
			IXUISprite result;
			if (flag)
			{
				result = null;
			}
			else
			{
				GameObject gameObject = XCommon.Instantiate<GameObject>(go);
				gameObject.SetActive(true);
				gameObject.name = name;
				gameObject.transform.parent = this.m_uiTransform;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = Vector3.zero;
				result = (gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
			}
			return result;
		}

		protected bool _SetupLevelMask()
		{
			XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
			bool flag = player != null && XItemDrawerMgr.Param.bShowLevelReq;
			if (flag)
			{
				uint level = player.Attributes.Level;
				bool flag2 = (ulong)level < (ulong)((long)this.itemdata.ReqLevel);
				if (flag2)
				{
					this.m_maskName = "kuang_35";
					this._SetupMaskUI(true);
					return true;
				}
				this._SetupMaskUI(false);
			}
			else
			{
				this._SetupMaskUI(false);
			}
			return false;
		}

		protected bool _SetupProfMask()
		{
			bool bShowProfReq = XItemDrawerMgr.Param.bShowProfReq;
			if (bShowProfReq)
			{
				bool flag = XBagDocument.IsProfMatched((uint)this.itemdata.Profession);
				if (!flag)
				{
					this.m_maskName = "kuang_35";
					this._SetupMaskUI(true);
					return true;
				}
				this._SetupMaskUI(false);
			}
			else
			{
				this._SetupMaskUI(false);
			}
			return false;
		}

		private string GetProfIconName()
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player == null;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				string text = "";
				this.ProfNameDic.TryGetValue((int)XSingleton<XEntityMgr>.singleton.Player.BasicTypeID, out text);
				result = text;
			}
			return result;
		}

		protected void _GetItemData(int id)
		{
			this.itemdata = XBagDocument.GetItemConf(id);
		}

		protected bool _GetBindingState(XItem item)
		{
			bool flag = item == null;
			bool result;
			if (flag)
			{
				result = XItemDrawerMgr.Param.bBinding;
			}
			else
			{
				result = (item.bBinding && !XItemDrawerMgr.Param.bHideBinding);
			}
			return result;
		}

		protected virtual void _SetupIcon()
		{
			bool flag = this.itemdata == null;
			if (flag)
			{
				this._SetIconUI(null, null, 1, 1);
				this._SetIconBgUI(null, null);
			}
			else
			{
				bool flag2 = XItemDrawerMgr.Param.IconType == 0U;
				if (flag2)
				{
					this._SetIconUI(XSingleton<UiUtility>.singleton.ChooseProfString(this.itemdata.ItemIcon, XItemDrawerMgr.Param.Profession), XSingleton<UiUtility>.singleton.ChooseProfString(this.itemdata.ItemAtlas, XItemDrawerMgr.Param.Profession), (int)this.itemdata.ItemQuality, (int)this.itemdata.ItemType);
				}
				else
				{
					this._SetIconUI(XSingleton<UiUtility>.singleton.ChooseProfString(this.itemdata.ItemIcon1, XItemDrawerMgr.Param.Profession), XSingleton<UiUtility>.singleton.ChooseProfString(this.itemdata.ItemAtlas1, XItemDrawerMgr.Param.Profession), (int)this.itemdata.ItemQuality, (int)this.itemdata.ItemType);
				}
				bool flag3 = this.itemdata.ItemType == 28;
				if (flag3)
				{
					this._SetIconBgUI("29", "Item/Item");
				}
				else
				{
					this._SetIconBgUI(string.Empty, string.Empty);
				}
			}
		}

		protected virtual void _SetupAttrIcon(XItem item)
		{
			this._SetAttrIcon(null, null);
		}

		protected void _SetIconBgUI(string icon, string atlas)
		{
			bool flag = this.m_iconBg != null;
			if (flag)
			{
				bool flag2 = icon == null || atlas == null;
				if (flag2)
				{
					this.m_iconBg.SetVisible(false);
				}
				else
				{
					this.m_iconBg.SetVisible(true);
					bool flag3 = atlas == string.Empty;
					if (flag3)
					{
						this.m_iconBg.SetSprite(icon);
					}
					else
					{
						this.m_iconBg.SetSprite(icon, atlas, false);
					}
				}
			}
		}

		protected void _SetAttrIcon(string icon, string atlas)
		{
			bool flag = this.m_attrType != null;
			if (flag)
			{
				bool flag2 = string.IsNullOrEmpty(icon) || string.IsNullOrEmpty(atlas);
				if (flag2)
				{
					this.m_attrType.SetVisible(false);
				}
				else
				{
					this.m_attrType.SetVisible(true);
					this.m_attrType.SetSprite(icon, atlas, false);
				}
			}
		}

		protected void _SetIconUI(string icon, string atlas, int quality, int type)
		{
			bool flag = icon == null || atlas == null;
			if (flag)
			{
				bool flag2 = this.m_quality != null;
				if (flag2)
				{
					this.m_quality.SetVisible(false);
				}
				bool flag3 = this.m_icon != null;
				if (flag3)
				{
					this.m_icon.SetVisible(false);
				}
			}
			else
			{
				bool flag4 = this.m_quality != null;
				if (flag4)
				{
					this.m_quality.SetVisible(true);
					this.m_quality.SetSprite(XSingleton<UiUtility>.singleton.GetItemQualityFrame(quality, type));
				}
				bool flag5 = this.m_icon != null;
				if (flag5)
				{
					this.m_icon.SetVisible(true);
					this.m_icon.SetSprite(icon, atlas, false);
					this.m_icon.SetAudioClip("Audio/UI/UI_Button_ok");
					bool flag6 = this.itemdata == null || this.itemdata.IconTransform == null || this.itemdata.IconTransform.Length != 9;
					if (flag6)
					{
						this.m_icon.gameObject.transform.localPosition = Vector3.zero;
						this.m_icon.gameObject.transform.localRotation = Quaternion.identity;
						this.m_icon.gameObject.transform.localScale = Vector3.one;
					}
					else
					{
						this.m_icon.gameObject.transform.localPosition = new Vector3(this.itemdata.IconTransform[0], this.itemdata.IconTransform[1], this.itemdata.IconTransform[2]);
						this.m_icon.gameObject.transform.localRotation = Quaternion.Euler(this.itemdata.IconTransform[3], this.itemdata.IconTransform[4], this.itemdata.IconTransform[5]);
						this.m_icon.gameObject.transform.localScale = new Vector3(this.itemdata.IconTransform[6], this.itemdata.IconTransform[7], this.itemdata.IconTransform[8]);
					}
				}
			}
		}

		protected void _SetLargeMaskUI(string sprite, string atlas)
		{
			bool flag = this.m_largeMask == null && sprite != null;
			if (flag)
			{
				GameObject gameObject = XCommon.Instantiate<GameObject>(this.m_icon.gameObject);
				for (int i = gameObject.transform.childCount - 1; i >= 0; i--)
				{
					GameObject gameObject2 = gameObject.transform.GetChild(i).gameObject;
					UnityEngine.Object.Destroy(gameObject2);
				}
				gameObject.transform.parent = this.m_icon.gameObject.transform.parent;
				gameObject.transform.localPosition = this.m_icon.gameObject.transform.localPosition;
				gameObject.transform.localScale = this.m_icon.gameObject.transform.localScale;
				BoxCollider component = gameObject.GetComponent<BoxCollider>();
				bool flag2 = component != null;
				if (flag2)
				{
					UnityEngine.Object.Destroy(component);
				}
				gameObject.name = "LargeMask";
				this.m_largeMask = (gameObject.GetComponent("XUISprite") as IXUISprite);
				this.m_largeMask.spriteDepth++;
			}
			bool flag3 = this.m_largeMask != null;
			if (flag3)
			{
				bool flag4 = sprite == null || atlas == null;
				if (flag4)
				{
					this.m_largeMask.SetVisible(false);
				}
				else
				{
					this.m_largeMask.SetSprite(sprite, atlas, false);
					this.m_largeMask.SetVisible(true);
				}
			}
		}

		protected void _SetNameUI()
		{
			bool flag = this.itemdata == null;
			if (flag)
			{
				this._SetNameUI(null, 1);
			}
			else
			{
				this._SetNameUI(XSingleton<UiUtility>.singleton.ChooseProfString(this.itemdata.ItemName, 0U), (int)this.itemdata.ItemQuality);
			}
		}

		protected void _SetNameUI(string name, int quality)
		{
			bool flag = this.m_name != null;
			if (flag)
			{
				bool flag2 = name == null;
				if (flag2)
				{
					this.m_name.SetVisible(false);
				}
				else
				{
					this.m_name.SetText(name);
					this.m_name.SetVisible(true);
					this.m_name.SetColor(XSingleton<UiUtility>.singleton.GetItemQualityColor(quality));
				}
			}
		}

		protected void _SetNumUI(string num)
		{
			bool flag = this.m_num != null;
			if (flag)
			{
				bool flag2 = num == null;
				if (flag2)
				{
					this.m_num.SetVisible(false);
				}
				else
				{
					this.m_num.SetText(num);
					this.m_num.SetVisible(true);
					bool flag3 = XItemDrawerMgr.Param.NumColor != null;
					if (flag3)
					{
						this.m_num.SetColor(XItemDrawerMgr.Param.NumColor ?? Color.white);
					}
				}
			}
		}

		protected void _SetNumTopUI(string num)
		{
			bool flag = this.m_numTop != null;
			if (flag)
			{
				bool flag2 = num == null;
				if (flag2)
				{
					this.m_numTop.SetVisible(false);
				}
				else
				{
					this.m_numTop.SetText(num);
					this.m_numTop.SetVisible(true);
				}
			}
		}

		protected void _SetupNum(int count, bool bForceShowNum = false)
		{
			bool flag = XItemDrawerMgr.Param.MaxItemCount < 0;
			if (flag)
			{
				bool flag2 = count <= 1 && !bForceShowNum;
				if (flag2)
				{
					this._SetNumUI(null);
				}
				else
				{
					this._SetNumUI(count.ToString());
				}
			}
			else
			{
				bool flag3 = XItemDrawerMgr.Param.MaxShowNum >= 0 && count > XItemDrawerMgr.Param.MaxShowNum;
				if (flag3)
				{
					this._SetNumUI(XSingleton<XCommon>.singleton.StringCombine("...", "/", XItemDrawerMgr.Param.MaxItemCount.ToString()));
				}
				else
				{
					this._SetNumUI(XSingleton<XCommon>.singleton.StringCombine(count.ToString(), "/", XItemDrawerMgr.Param.MaxItemCount.ToString()));
				}
			}
		}

		protected void _SetupNum(int useCount, bool bForceShowNum, int itemCount)
		{
			bool flag = !bForceShowNum;
			if (flag)
			{
				this._SetNumUI(null);
			}
			else
			{
				bool flag2 = itemCount < useCount;
				if (flag2)
				{
					this._SetNumUI(string.Format("[ff0000]{0}[-]/{1}", itemCount.ToString(), useCount.ToString()));
				}
				else
				{
					this._SetNumUI(string.Format("{0}/{1}", itemCount.ToString(), useCount.ToString()));
				}
			}
		}

		protected virtual void DrawEmpty()
		{
			this.itemdata = null;
			this._SetIconUI(null, null, 0, 0);
			this._SetAttrIcon(null, null);
			this._SetIconBgUI(null, null);
			this._SetNameUI(null, 0);
			this._SetNumUI(null);
			this._SetNumTopUI(null);
			this._SetupLeftDownCorner(false);
			this._SetupLeftUpCorner(false, "");
			this._SetupRightDownCorner(false);
			this._SetupRightUpCorner(false);
			this._SetupMask();
			this._SetUpProf(false);
		}

		protected virtual void _ClearVariables()
		{
			this.m_icon = null;
			this.m_iconBg = null;
			this.m_name = null;
			this.m_num = null;
			this.m_numTop = null;
			this.m_quality = null;
			this.m_maskOld = null;
			this.m_largeMask = null;
			this.m_leftDownCorner = null;
			this.m_leftUpCorner = null;
			this.m_rightDownCorner = null;
			this.m_rightUpCorner = null;
			this.m_mask = null;
			this.itemdata = null;
			this.m_attrType = null;
			XItemDrawerMgr.Param.Reset();
		}

		protected Transform m_uiTransform;

		protected IXUISprite m_quality;

		protected IXUISprite m_icon;

		protected IXUISprite m_iconBg;

		protected IXUISprite m_maskOld;

		protected IXUISprite m_largeMask;

		protected IXUILabel m_name;

		protected IXUILabel m_num;

		protected IXUILabel m_numTop;

		protected ItemList.RowData itemdata;

		protected IXUISprite m_leftDownCorner;

		protected IXUISprite m_leftUpCorner;

		protected IXUISprite m_rightDownCorner;

		protected IXUISprite m_rightUpCorner;

		protected IXUISprite m_mask;

		protected IXUISprite m_prof;

		protected IXUISprite m_attrType;

		protected string m_maskName = "kuang_35";

		private Dictionary<int, string> m_profNameDic;
	}
}
