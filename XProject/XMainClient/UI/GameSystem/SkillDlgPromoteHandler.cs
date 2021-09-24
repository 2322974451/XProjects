using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI.GameSystem
{

	internal class SkillDlgPromoteHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
			this.m_PreviewWindow = base.PanelObject.transform.Find("PreviewWindow").gameObject;
			this.m_PreviewClose = (base.PanelObject.transform.Find("PreviewWindow/Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BgTex = (base.PanelObject.transform.Find("Bg/Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_BranchGo1 = base.PanelObject.transform.Find("Bg/TurnBranch1").gameObject;
			this.m_BranchGo2 = base.PanelObject.transform.Find("Bg/TurnBranch2").gameObject;
			this.m_BranchGo3 = base.PanelObject.transform.Find("Bg/TurnBranch3").gameObject;
			this.m_PreViewBtn = (base.PanelObject.transform.Find("Bg/PreviewBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_TurnProBtn = (base.PanelObject.transform.Find("Bg/TurnProBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_CurrSelectPro = (base.PanelObject.transform.Find("Bg/ProName").GetComponent("XUILabel") as IXUILabel);
			this.m_TurnProTips = (base.PanelObject.transform.Find("Bg/Tips").GetComponent("XUILabel") as IXUILabel);
			this.m_TurnProBtnText = (this.m_TurnProBtn.gameObject.transform.Find("Text").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.PanelObject.transform.Find("PreviewWindow/ShowFrame/ShowSkill/Tpl");
			this.m_PreViewSkillPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this.m_Snapshot = (base.PanelObject.transform.Find("PreviewWindow/ShowFrame/Snapshot").GetComponent("XUITexture") as IXUITexture);
			this.m_PlayBtn = (base.PanelObject.transform.Find("PreviewWindow/Play").GetComponent("XUISprite") as IXUISprite);
			this.m_SkillName = (base.PanelObject.transform.Find("PreviewWindow/ShowFrame/SkillDesc/SkillName").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillDesc = (base.PanelObject.transform.Find("PreviewWindow/ShowFrame/SkillDesc/SkillDesc").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalTurnPro = base.PanelObject.transform.Find("Bg").gameObject;
			this.m_AwakePage = base.PanelObject.transform.Find("Awake").gameObject;
			this.m_AwakePoint = (base.PanelObject.transform.Find("Awake/Point/value").GetComponent("XUILabel") as IXUILabel);
			this.m_AwakeTips = (base.PanelObject.transform.Find("Awake/Tips").GetComponent("XUILabel") as IXUILabel);
			this.m_AwakeBgTex = (base.PanelObject.transform.Find("Awake/Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_TurnAwakeBtn = (base.PanelObject.transform.Find("Awake/TurnAwakeBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_TurnAwakeBtnText = (this.m_TurnAwakeBtn.gameObject.transform.Find("Text").GetComponent("XUILabel") as IXUILabel);
			this.m_AwakeDesc = (base.PanelObject.transform.Find("Awake/Text").GetComponent("XUILabel") as IXUILabel);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_PreviewClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnWindowCloseClicked));
			this.m_PreViewBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPreViewBtnClick));
			this.m_PlayBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnPlayBtnClick));
		}

		public bool OnWindowCloseClicked(IXUIButton go)
		{
			this.m_PreviewWindow.SetActive(false);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			bool flag = this.skillPreView == null;
			if (flag)
			{
				this.skillPreView = new RenderTexture(634, 357, 1, 0, 0);
				this.skillPreView.name = "SkillPreview";
				this.skillPreView.autoGenerateMips = false;
				this.skillPreView.Create();
			}
			this.m_Snapshot.SetRuntimeTex(this.skillPreView, true);
			this._doc.SetSkillPreviewTexture(this.skillPreView);
			this.SetUVRectangle();
			this.m_PreviewWindow.SetActive(false);
			bool flag2 = !this.IsShowAwake;
			if (flag2)
			{
				bool flag3 = !this.m_NormalTurnPro.activeSelf;
				if (flag3)
				{
					this.m_NormalTurnPro.SetActive(true);
				}
				bool activeSelf = this.m_AwakePage.activeSelf;
				if (activeSelf)
				{
					this.m_AwakePage.SetActive(false);
				}
				this.CalPro();
				this.SetInfo();
			}
			else
			{
				bool activeSelf2 = this.m_NormalTurnPro.activeSelf;
				if (activeSelf2)
				{
					this.m_NormalTurnPro.SetActive(false);
				}
				bool flag4 = !this.m_AwakePage.activeSelf;
				if (flag4)
				{
					this.m_AwakePage.SetActive(true);
				}
				this.SetAwakeInfo();
			}
		}

		protected override void OnHide()
		{
			this.m_BgTex.SetTexturePath("");
			bool flag = DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this._doc.SetSkillPreviewTexture(DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.skillPreView);
				XSingleton<XSkillPreViewMgr>.singleton.SkillShowEnd(this._doc.Dummy);
			}
			bool flag2 = this.skillPreView != null;
			if (flag2)
			{
				this.m_Snapshot.SetRuntimeTex(null, true);
				this.skillPreView = null;
			}
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		private void CalPro()
		{
			int num = 1;
			for (int i = 0; i < this.CurrStage; i++)
			{
				num *= 10;
			}
			this._pro_L = num + (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID;
			this._pro_R = num * 2 + (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID;
			this._pro_V = num * 3 + (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID;
			bool flag = !XSingleton<XProfessionSkillMgr>.singleton.GetProfIsInLeft(this._pro_L);
			if (flag)
			{
				int pro_L = this._pro_L;
				this._pro_L = this._pro_R;
				this._pro_R = pro_L;
			}
			bool flag2 = this._currChoosePro != this._pro_L && this._currChoosePro != this._pro_R && this._currChoosePro != this._pro_V;
			if (flag2)
			{
				this._currChoosePro = this._pro_L;
				this.m_CurrSelectPro.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName(this._currChoosePro));
			}
		}

		private void ChangeGo()
		{
			bool flag = XSingleton<XProfessionSkillMgr>.singleton.IsExistProf(this._pro_L);
			bool flag2 = XSingleton<XProfessionSkillMgr>.singleton.IsExistProf(this._pro_R);
			bool flag3 = XSingleton<XProfessionSkillMgr>.singleton.IsExistProf(this._pro_V);
			bool flag4 = flag3;
			if (flag4)
			{
				flag3 = XSkillTreeDocument.IsAvengerTaskDone(this._pro_V);
			}
			int num = 0;
			bool flag5 = flag;
			if (flag5)
			{
				num++;
			}
			bool flag6 = flag2;
			if (flag6)
			{
				num++;
			}
			bool flag7 = flag3;
			if (flag7)
			{
				num++;
			}
			bool flag8 = num != this.old_branch;
			if (flag8)
			{
				this.m_BranchGo1.SetActive(1 == num);
				this.m_BranchGo2.SetActive(2 == num);
				this.m_BranchGo3.SetActive(3 == num);
			}
			Transform transform = base.PanelObject.transform.Find(string.Format("Bg/TurnBranch{0}", num));
			bool flag9 = transform != null;
			if (flag9)
			{
				bool flag10 = flag;
				if (flag10)
				{
					GameObject gameObject = transform.Find("ProDetail1").gameObject;
					this.SetProGo(gameObject, this._pro_L, num);
				}
				bool flag11 = flag2;
				if (flag11)
				{
					GameObject gameObject2 = transform.Find("ProDetail2").gameObject;
					this.SetProGo(gameObject2, this._pro_R, num);
				}
				bool flag12 = flag3;
				if (flag12)
				{
					GameObject gameObject3 = transform.Find("ProDetail3").gameObject;
					this.SetProGo(gameObject3, this._pro_V, num);
				}
			}
			string profPic = XSingleton<XProfessionSkillMgr>.singleton.GetProfPic((!flag3) ? this._pro_L : this._pro_V);
			this._texPath = string.Format("{0}/{1}", this.TEXPATH, profPic);
			this.m_BgTex.SetTexturePath(this._texPath);
			this.old_branch = num;
		}

		private void SetInfo()
		{
			this.ChangeGo();
			this.SetProfBtnInfo();
		}

		private void SetProfBtnInfo()
		{
			bool flag = this.IsAvengr(this._currChoosePro);
			if (flag)
			{
				bool flag2 = XSkillTreeDocument.IsAvengerTaskDone(this._currChoosePro);
				if (flag2)
				{
					this.m_TurnProTips.SetVisible(false);
					this.m_TurnProBtnText.SetText(XStringDefineProxy.GetString("TurnProfessionBtnTips2"));
					this.m_TurnProBtn.SetGrey(true);
					this.m_TurnProBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTurnProBtnClick));
				}
				else
				{
					this.m_TurnProTips.SetVisible(false);
					this.m_TurnProBtnText.SetText(XStringDefineProxy.GetString("TurnProfessionBtnTips2"));
					this.m_TurnProBtn.SetGrey(false);
					this.m_TurnProBtn.RegisterClickEventHandler(null);
				}
			}
			else
			{
				XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
				uint taskid = (uint)this._doc.TurnProTaskIDList[this.CurrStage - 1];
				bool flag3 = specificDocument.TaskRecord.IsTaskFinished(taskid);
				if (flag3)
				{
					this.m_TurnProTips.SetVisible(false);
					this.m_TurnProBtnText.SetText(XStringDefineProxy.GetString("TurnProfessionBtnTips2"));
					this.m_TurnProBtn.SetGrey(true);
					this.m_TurnProBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTurnProBtnClick));
				}
				else
				{
					this.m_TurnProTips.SetVisible(true);
					this.m_TurnProTips.SetText(this._doc.TransferLimit[this.CurrStage].ToString());
					this.m_TurnProBtnText.SetText(XStringDefineProxy.GetString("TurnProfessionBtnTips1"));
					bool flag4 = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= this._doc.TransferLimit[this.CurrStage];
					if (flag4)
					{
						this.m_TurnProBtn.SetGrey(true);
						this.m_TurnProBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoToTask));
					}
					else
					{
						this.m_TurnProBtn.SetGrey(false);
						this.m_TurnProBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCanNotGoToTaskClick));
					}
				}
			}
		}

		private void SetAwakeInfo()
		{
			int num = 1;
			for (int i = 0; i < this.CurrStage; i++)
			{
				num *= 10;
			}
			this._awakePro = num + (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID;
			string profPic = XSingleton<XProfessionSkillMgr>.singleton.GetProfPic(this._awakePro);
			this._texPath = string.Format("{0}/{1}", this.TEXPATH, profPic);
			this.m_AwakeBgTex.SetTexturePath(this._texPath);
			this.m_AwakeDesc.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfDesc(this._awakePro));
			XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			bool flag = false;
			bool flag2 = this.CurrStage - 1 < this._doc.TurnProTaskIDList.Count;
			if (flag2)
			{
				uint taskid = (uint)this._doc.TurnProTaskIDList[this.CurrStage - 1];
				flag = specificDocument.TaskRecord.IsTaskFinished(taskid);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddLog("GlobalConfig 觉醒任务ID未配置!", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			bool flag3 = flag;
			if (flag3)
			{
				this.m_AwakeTips.SetVisible(false);
				this.m_TurnAwakeBtnText.SetText(XStringDefineProxy.GetString("TurnAwakeBtnTips2"));
				this.m_TurnAwakeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAwakeComplete));
			}
			else
			{
				this.m_AwakeTips.SetVisible(true);
				this.m_AwakeTips.SetText(XStringDefineProxy.GetString("TurnAwakeTips"));
				this.m_TurnAwakeBtnText.SetText(XStringDefineProxy.GetString("TurnProfessionBtnTips1"));
				bool flag4 = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= this._doc.TransferLimit[this.CurrStage];
				if (flag4)
				{
					this.m_TurnAwakeBtn.SetGrey(true);
					this.m_TurnAwakeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoToAwakeTask));
				}
				else
				{
					this.m_TurnAwakeBtn.SetGrey(false);
					this.m_TurnAwakeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCanNotGoToAwakeTaskClick));
				}
			}
			int num2 = (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetVirtualItemCount(ItemEnum.AWAKE_POINT);
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("AwakeNeedPoint");
			this.m_AwakePoint.SetText(string.Format("{0}{1}/{2}", (num2 < @int) ? "[e60012]" : "", num2, @int));
		}

		private void SetProGo(GameObject go, int pro, int branch)
		{
			IXUILabel ixuilabel = go.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.Find("Desc").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = go.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(pro);
			ixuilabel.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName(pro));
			ixuilabel2.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfDesc(pro));
			IXUICheckBox ixuicheckBox = go.GetComponent("XUICheckBox") as IXUICheckBox;
			ixuicheckBox.ID = (ulong)((long)pro);
			ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnProClick));
			bool flag = pro == this._pro_L;
			XUIPool xuipool;
			if (flag)
			{
				this.m_ProChoose_L = ixuicheckBox;
				bool flag2 = branch != this.old_branch;
				if (flag2)
				{
					Transform transform = base.PanelObject.transform.Find(string.Format("Bg/TurnBranch{0}/ProDetail1/Star/Tpl", branch));
					this.m_Star_L.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
				}
				xuipool = this.m_Star_L;
			}
			else
			{
				bool flag3 = pro == this._pro_V;
				if (flag3)
				{
					this.m_ProChoose_V = ixuicheckBox;
					bool flag4 = branch != this.old_branch;
					if (flag4)
					{
						Transform transform2 = base.PanelObject.transform.Find(string.Format("Bg/TurnBranch{0}/ProDetail3/Star/Tpl", branch));
						this.m_Star_V.SetupPool(transform2.parent.gameObject, transform2.gameObject, 5U, false);
					}
					xuipool = this.m_Star_V;
				}
				else
				{
					this.m_ProChoose_R = ixuicheckBox;
					bool flag5 = branch != this.old_branch;
					if (flag5)
					{
						Transform transform3 = base.PanelObject.transform.Find(string.Format("Bg/TurnBranch{0}/ProDetail2/Star/Tpl", branch));
						this.m_Star_R.SetupPool(transform3.parent.gameObject, transform3.gameObject, 5U, false);
					}
					xuipool = this.m_Star_R;
				}
			}
			ixuicheckBox.bChecked = (pro == this._currChoosePro);
			xuipool.ReturnAll(false);
			Vector3 tplPos = xuipool.TplPos;
			uint profOperateLevel = XSingleton<XProfessionSkillMgr>.singleton.GetProfOperateLevel(pro);
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("ProfOperateLevelMax");
			for (int i = 0; i < @int; i++)
			{
				GameObject gameObject = xuipool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(tplPos.x + (float)(i * xuipool.TplWidth), tplPos.y);
				IXUISprite ixuisprite2 = gameObject.transform.Find("Star").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.spriteName = (((long)i < (long)((ulong)profOperateLevel)) ? "BossrushStar_1" : "BossrushStar_0");
			}
		}

		private bool OnProClick(IXUICheckBox icb)
		{
			bool flag = !icb.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._currChoosePro = (int)icb.ID;
				this.m_CurrSelectPro.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName(this._currChoosePro));
				this.SetProfBtnInfo();
				result = true;
			}
			return result;
		}

		private bool IsAvengr(int prof)
		{
			return prof > 10 && prof / 10 % 10 == 3;
		}

		private bool OnPreViewBtnClick(IXUIButton btn)
		{
			this.ShowPreView();
			return true;
		}

		private void ShowPreView()
		{
			this.m_PreviewWindow.SetActive(true);
			this.SetupPreViewTab();
			this.SetupPreViewInfo();
		}

		private bool OnPreViewCheckBoxClick(IXUICheckBox icb)
		{
			bool flag = !icb.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._currChoosePro = (int)icb.ID;
				this.m_CurrSelectPro.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName(this._currChoosePro));
				bool flag2 = this._currChoosePro == this._pro_L;
				if (flag2)
				{
					this.m_ProChoose_L.bChecked = true;
				}
				else
				{
					bool flag3 = this._currChoosePro == this._pro_V;
					if (flag3)
					{
						this.m_ProChoose_V.bChecked = true;
					}
					else
					{
						this.m_ProChoose_R.bChecked = true;
					}
				}
				this.SetupPreViewInfo();
				result = true;
			}
			return result;
		}

		private void SetupPreViewTab()
		{
			IXUICheckBox ixuicheckBox = base.PanelObject.transform.Find("PreviewWindow/ShowFrame/Tab1").GetComponent("XUICheckBox") as IXUICheckBox;
			IXUICheckBox ixuicheckBox2 = base.PanelObject.transform.Find("PreviewWindow/ShowFrame/Tab2").GetComponent("XUICheckBox") as IXUICheckBox;
			IXUICheckBox ixuicheckBox3 = base.PanelObject.transform.Find("PreviewWindow/ShowFrame/Tab3").GetComponent("XUICheckBox") as IXUICheckBox;
			ixuicheckBox.ID = (ulong)((long)this._pro_L);
			ixuicheckBox2.ID = (ulong)((long)this._pro_R);
			ixuicheckBox3.ID = (ulong)((long)this._pro_V);
			bool flag = this._currChoosePro == this._pro_L;
			if (flag)
			{
				ixuicheckBox.bChecked = true;
			}
			else
			{
				bool flag2 = this._currChoosePro == this._pro_R;
				if (flag2)
				{
					ixuicheckBox2.bChecked = true;
				}
				else
				{
					ixuicheckBox3.bChecked = true;
				}
			}
			bool flag3 = XSingleton<XProfessionSkillMgr>.singleton.IsExistProf(this._pro_L);
			bool flag4 = XSingleton<XProfessionSkillMgr>.singleton.IsExistProf(this._pro_R);
			bool flag5 = XSingleton<XProfessionSkillMgr>.singleton.IsExistProf(this._pro_V);
			bool flag6 = flag5;
			if (flag6)
			{
				flag5 = XSkillTreeDocument.IsAvengerTaskDone(this._pro_V);
			}
			ixuicheckBox.gameObject.SetActive(flag3);
			ixuicheckBox2.gameObject.SetActive(flag4);
			ixuicheckBox3.gameObject.SetActive(flag5);
			bool flag7 = flag3;
			if (flag7)
			{
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnPreViewCheckBoxClick));
				string profName = XSingleton<XProfessionSkillMgr>.singleton.GetProfName(this._pro_L);
				IXUILabel ixuilabel = ixuicheckBox.gameObject.transform.Find("TextLabel").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(profName);
				ixuilabel = (ixuicheckBox.gameObject.transform.Find("SelectedTextLabel").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(profName);
			}
			bool flag8 = flag4;
			if (flag8)
			{
				ixuicheckBox2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnPreViewCheckBoxClick));
				string profName2 = XSingleton<XProfessionSkillMgr>.singleton.GetProfName(this._pro_R);
				IXUILabel ixuilabel2 = ixuicheckBox2.gameObject.transform.Find("TextLabel").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(profName2);
				ixuilabel2 = (ixuicheckBox2.gameObject.transform.Find("SelectedTextLabel").GetComponent("XUILabel") as IXUILabel);
				ixuilabel2.SetText(profName2);
			}
			bool flag9 = flag5;
			if (flag9)
			{
				ixuicheckBox3.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnPreViewCheckBoxClick));
				string profName3 = XSingleton<XProfessionSkillMgr>.singleton.GetProfName(this._pro_V);
				IXUILabel ixuilabel3 = ixuicheckBox3.gameObject.transform.Find("TextLabel").GetComponent("XUILabel") as IXUILabel;
				ixuilabel3.SetText(profName3);
				ixuilabel3 = (ixuicheckBox3.gameObject.transform.Find("SelectedTextLabel").GetComponent("XUILabel") as IXUILabel);
				ixuilabel3.SetText(profName3);
			}
		}

		private void SetupPreViewInfo()
		{
			List<uint> profSkillID = XSingleton<XProfessionSkillMgr>.singleton.GetProfSkillID(this._currChoosePro);
			this.m_PreViewSkillPool.ReturnAll(false);
			Vector3 tplPos = this.m_PreViewSkillPool.TplPos;
			IXUICheckBox ixuicheckBox = null;
			for (int i = 0; i < profSkillID.Count; i++)
			{
				SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID[i], 0U);
				GameObject gameObject = this.m_PreViewSkillPool.FetchGameObject(false);
				gameObject.name = profSkillID[i].ToString();
				gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(i * this.m_PreViewSkillPool.TplHeight));
				IXUISprite ixuisprite = gameObject.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite;
				bool flag = skillConfig.SkillType == 2;
				if (flag)
				{
					ixuisprite.SetSprite("JN_dk_0");
				}
				else
				{
					ixuisprite.SetSprite("JN_dk");
				}
				IXUISprite ixuisprite2 = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.SetSprite(skillConfig.Icon, skillConfig.Atlas, false);
				IXUICheckBox ixuicheckBox2 = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox2.ID = (ulong)profSkillID[i];
				ixuicheckBox2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSkillPreViewClick));
				bool flag2 = i == 0;
				if (flag2)
				{
					this._currSkill = (int)profSkillID[i];
					ixuicheckBox = ixuicheckBox2;
					this.SetupSkillInfo();
				}
			}
			bool flag3 = ixuicheckBox != null;
			if (flag3)
			{
				ixuicheckBox.bChecked = true;
			}
		}

		private bool OnSkillPreViewClick(IXUICheckBox icb)
		{
			bool flag = !icb.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._currSkill = (int)icb.ID;
				this.SetupSkillInfo();
				result = true;
			}
			return result;
		}

		private void SetupSkillInfo()
		{
			SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig((uint)this._currSkill, 0U);
			this.m_SkillName.SetText(skillConfig.ScriptName);
			this.m_SkillDesc.SetText(skillConfig.CurrentLevelDescription);
			this.m_PlayBtn.SetVisible(true);
			XSingleton<XSkillPreViewMgr>.singleton.SkillShowEnd(this._doc.Dummy);
			XSingleton<XSkillPreViewMgr>.singleton.SkillShowBegin(this._doc.Dummy, this._doc.BlackHouseCamera);
		}

		private void OnPlayBtnClick(IXUISprite iSp)
		{
			this.PlaySkill(this._currSkill);
		}

		private void PlaySkill(int pro)
		{
			this.m_PlayBtn.SetVisible(false);
			XSingleton<XSkillPreViewMgr>.singleton.ShowSkill(this._doc.Dummy, (uint)this._currSkill, 0U);
		}

		protected bool OnTurnProBtnClick(IXUIButton go)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton._bHasGrey = false;
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabels(string.Format(XStringDefineProxy.GetString(XStringDefine.SKILL_WILL_PROMOTE), XSingleton<XProfessionSkillMgr>.singleton.GetProfName(this._currChoosePro)), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL));
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnPromoteConfirmed), null);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetTweenTargetAndPlay(DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.gameObject);
			return true;
		}

		private bool OnPromoteConfirmed(IXUIButton go)
		{
			RpcC2G_ChooseProfession rpcC2G_ChooseProfession = new RpcC2G_ChooseProfession();
			rpcC2G_ChooseProfession.oArg.prof = (RoleType)this._currChoosePro;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChooseProfession);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		private bool OnGoToTask(IXUIButton btn)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_HALL;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SKILL_HALL_REQUIRED"), "fece00");
				result = true;
			}
			else
			{
				DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.SetVisible(false, true);
				XSingleton<XDebug>.singleton.AddLog("Find Npc ", this._doc.NpcID[(int)(XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID % 10U - 1U)].ToString(), null, null, null, null, XDebugColor.XDebug_None);
				XSingleton<XInput>.singleton.LastNpc = XSingleton<XEntityMgr>.singleton.GetNpc((uint)this._doc.NpcID[(int)(XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID % 10U - 1U)]);
				result = true;
			}
			return result;
		}

		private bool OnCanNotGoToTaskClick(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TURNPROF_LEVELFAIL"), "fece00");
			return true;
		}

		public void SetUVRectangle()
		{
			Rect rect = this._doc.BlackHouseCamera.rect;
			rect.y = (rect.y * 357f + 1f) / 357f;
			rect.height = (rect.height * 357f - 2f) / 357f;
			this.m_Snapshot.SetUVRect(rect);
		}

		private bool OnAwakeComplete(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddLog("Awake Completed", null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2G_ChooseProfession rpcC2G_ChooseProfession = new RpcC2G_ChooseProfession();
			rpcC2G_ChooseProfession.oArg.prof = (RoleType)this._awakePro;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChooseProfession);
			return true;
		}

		private bool OnGoToAwakeTask(IXUIButton btn)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_HALL;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SKILL_HALL_REQUIRED"), "fece00");
				result = true;
			}
			else
			{
				DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.SetVisible(false, true);
				XSingleton<XDebug>.singleton.AddLog("Find Npc ", this._doc.NpcID[(int)(XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID % 10U - 1U)].ToString(), null, null, null, null, XDebugColor.XDebug_None);
				XSingleton<XInput>.singleton.LastNpc = XSingleton<XEntityMgr>.singleton.GetNpc((uint)this._doc.NpcID[(int)(XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID % 10U - 1U)]);
				result = true;
			}
			return result;
		}

		private bool OnCanNotGoToAwakeTaskClick(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TURNAWAKE_LEVELFAIL"), "fece00");
			return true;
		}

		private XSkillTreeDocument _doc = null;

		public int CurrStage;

		public bool IsShowAwake = false;

		private GameObject m_NormalTurnPro;

		private GameObject m_PreviewWindow;

		private GameObject m_AwakePage;

		private IXUILabel m_AwakePoint;

		private IXUILabel m_AwakeTips;

		private IXUITexture m_AwakeBgTex;

		private IXUIButton m_TurnAwakeBtn;

		private IXUILabel m_TurnAwakeBtnText;

		private IXUILabel m_AwakeDesc;

		private int _awakePro;

		private int _pro_L;

		private int _pro_R;

		private int _pro_V;

		private int _currChoosePro;

		private int _currSkill;

		private IXUIButton m_PreviewClose;

		private IXUITexture m_BgTex;

		private readonly string TEXPATH = "atlas/UI/common/ProfPic";

		private string _texPath;

		private GameObject m_BranchGo1;

		private GameObject m_BranchGo2;

		private GameObject m_BranchGo3;

		private IXUIButton m_PreViewBtn;

		private IXUIButton m_TurnProBtn;

		private IXUILabel m_CurrSelectPro;

		private IXUILabel m_TurnProTips;

		private IXUILabel m_TurnProBtnText;

		private IXUICheckBox m_ProChoose_L;

		private IXUICheckBox m_ProChoose_R;

		private IXUICheckBox m_ProChoose_V;

		private XUIPool m_PreViewSkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUITexture m_Snapshot;

		private RenderTexture skillPreView;

		public IXUISprite m_PlayBtn;

		private IXUILabel m_SkillName;

		private IXUILabel m_SkillDesc;

		private XUIPool m_Star_L = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_Star_R = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_Star_V = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private int old_branch = 0;
	}
}
