using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI.GameSystem
{
	// Token: 0x02001928 RID: 6440
	internal class SkillDlgPromoteHandler : DlgHandlerBase
	{
		// Token: 0x06010E64 RID: 69220 RVA: 0x00447F0C File Offset: 0x0044610C
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

		// Token: 0x06010E65 RID: 69221 RVA: 0x004482FC File Offset: 0x004464FC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_PreviewClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnWindowCloseClicked));
			this.m_PreViewBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPreViewBtnClick));
			this.m_PlayBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnPlayBtnClick));
		}

		// Token: 0x06010E66 RID: 69222 RVA: 0x0044835C File Offset: 0x0044655C
		public bool OnWindowCloseClicked(IXUIButton go)
		{
			this.m_PreviewWindow.SetActive(false);
			return true;
		}

		// Token: 0x06010E67 RID: 69223 RVA: 0x0044837C File Offset: 0x0044657C
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

		// Token: 0x06010E68 RID: 69224 RVA: 0x004484C0 File Offset: 0x004466C0
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

		// Token: 0x06010E69 RID: 69225 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x06010E6A RID: 69226 RVA: 0x0044854C File Offset: 0x0044674C
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

		// Token: 0x06010E6B RID: 69227 RVA: 0x00448654 File Offset: 0x00446854
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

		// Token: 0x06010E6C RID: 69228 RVA: 0x00448818 File Offset: 0x00446A18
		private void SetInfo()
		{
			this.ChangeGo();
			this.SetProfBtnInfo();
		}

		// Token: 0x06010E6D RID: 69229 RVA: 0x0044882C File Offset: 0x00446A2C
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

		// Token: 0x06010E6E RID: 69230 RVA: 0x00448A48 File Offset: 0x00446C48
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

		// Token: 0x06010E6F RID: 69231 RVA: 0x00448CBC File Offset: 0x00446EBC
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

		// Token: 0x06010E70 RID: 69232 RVA: 0x00448FBC File Offset: 0x004471BC
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

		// Token: 0x06010E71 RID: 69233 RVA: 0x00449010 File Offset: 0x00447210
		private bool IsAvengr(int prof)
		{
			return prof > 10 && prof / 10 % 10 == 3;
		}

		// Token: 0x06010E72 RID: 69234 RVA: 0x00449040 File Offset: 0x00447240
		private bool OnPreViewBtnClick(IXUIButton btn)
		{
			this.ShowPreView();
			return true;
		}

		// Token: 0x06010E73 RID: 69235 RVA: 0x0044905A File Offset: 0x0044725A
		private void ShowPreView()
		{
			this.m_PreviewWindow.SetActive(true);
			this.SetupPreViewTab();
			this.SetupPreViewInfo();
		}

		// Token: 0x06010E74 RID: 69236 RVA: 0x00449078 File Offset: 0x00447278
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

		// Token: 0x06010E75 RID: 69237 RVA: 0x00449120 File Offset: 0x00447320
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

		// Token: 0x06010E76 RID: 69238 RVA: 0x00449438 File Offset: 0x00447638
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

		// Token: 0x06010E77 RID: 69239 RVA: 0x004495F0 File Offset: 0x004477F0
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

		// Token: 0x06010E78 RID: 69240 RVA: 0x00449628 File Offset: 0x00447828
		private void SetupSkillInfo()
		{
			SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig((uint)this._currSkill, 0U);
			this.m_SkillName.SetText(skillConfig.ScriptName);
			this.m_SkillDesc.SetText(skillConfig.CurrentLevelDescription);
			this.m_PlayBtn.SetVisible(true);
			XSingleton<XSkillPreViewMgr>.singleton.SkillShowEnd(this._doc.Dummy);
			XSingleton<XSkillPreViewMgr>.singleton.SkillShowBegin(this._doc.Dummy, this._doc.BlackHouseCamera);
		}

		// Token: 0x06010E79 RID: 69241 RVA: 0x004496B0 File Offset: 0x004478B0
		private void OnPlayBtnClick(IXUISprite iSp)
		{
			this.PlaySkill(this._currSkill);
		}

		// Token: 0x06010E7A RID: 69242 RVA: 0x004496C0 File Offset: 0x004478C0
		private void PlaySkill(int pro)
		{
			this.m_PlayBtn.SetVisible(false);
			XSingleton<XSkillPreViewMgr>.singleton.ShowSkill(this._doc.Dummy, (uint)this._currSkill, 0U);
		}

		// Token: 0x06010E7B RID: 69243 RVA: 0x004496F0 File Offset: 0x004478F0
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

		// Token: 0x06010E7C RID: 69244 RVA: 0x0044978C File Offset: 0x0044798C
		private bool OnPromoteConfirmed(IXUIButton go)
		{
			RpcC2G_ChooseProfession rpcC2G_ChooseProfession = new RpcC2G_ChooseProfession();
			rpcC2G_ChooseProfession.oArg.prof = (RoleType)this._currChoosePro;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChooseProfession);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x06010E7D RID: 69245 RVA: 0x004497D0 File Offset: 0x004479D0
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

		// Token: 0x06010E7E RID: 69246 RVA: 0x004498A0 File Offset: 0x00447AA0
		private bool OnCanNotGoToTaskClick(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TURNPROF_LEVELFAIL"), "fece00");
			return true;
		}

		// Token: 0x06010E7F RID: 69247 RVA: 0x004498D0 File Offset: 0x00447AD0
		public void SetUVRectangle()
		{
			Rect rect = this._doc.BlackHouseCamera.rect;
			rect.y = (rect.y * 357f + 1f) / 357f;
			rect.height = (rect.height * 357f - 2f) / 357f;
			this.m_Snapshot.SetUVRect(rect);
		}

		// Token: 0x06010E80 RID: 69248 RVA: 0x00449940 File Offset: 0x00447B40
		private bool OnAwakeComplete(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddLog("Awake Completed", null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2G_ChooseProfession rpcC2G_ChooseProfession = new RpcC2G_ChooseProfession();
			rpcC2G_ChooseProfession.oArg.prof = (RoleType)this._awakePro;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChooseProfession);
			return true;
		}

		// Token: 0x06010E81 RID: 69249 RVA: 0x00449990 File Offset: 0x00447B90
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

		// Token: 0x06010E82 RID: 69250 RVA: 0x00449A60 File Offset: 0x00447C60
		private bool OnCanNotGoToAwakeTaskClick(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TURNAWAKE_LEVELFAIL"), "fece00");
			return true;
		}

		// Token: 0x04007C35 RID: 31797
		private XSkillTreeDocument _doc = null;

		// Token: 0x04007C36 RID: 31798
		public int CurrStage;

		// Token: 0x04007C37 RID: 31799
		public bool IsShowAwake = false;

		// Token: 0x04007C38 RID: 31800
		private GameObject m_NormalTurnPro;

		// Token: 0x04007C39 RID: 31801
		private GameObject m_PreviewWindow;

		// Token: 0x04007C3A RID: 31802
		private GameObject m_AwakePage;

		// Token: 0x04007C3B RID: 31803
		private IXUILabel m_AwakePoint;

		// Token: 0x04007C3C RID: 31804
		private IXUILabel m_AwakeTips;

		// Token: 0x04007C3D RID: 31805
		private IXUITexture m_AwakeBgTex;

		// Token: 0x04007C3E RID: 31806
		private IXUIButton m_TurnAwakeBtn;

		// Token: 0x04007C3F RID: 31807
		private IXUILabel m_TurnAwakeBtnText;

		// Token: 0x04007C40 RID: 31808
		private IXUILabel m_AwakeDesc;

		// Token: 0x04007C41 RID: 31809
		private int _awakePro;

		// Token: 0x04007C42 RID: 31810
		private int _pro_L;

		// Token: 0x04007C43 RID: 31811
		private int _pro_R;

		// Token: 0x04007C44 RID: 31812
		private int _pro_V;

		// Token: 0x04007C45 RID: 31813
		private int _currChoosePro;

		// Token: 0x04007C46 RID: 31814
		private int _currSkill;

		// Token: 0x04007C47 RID: 31815
		private IXUIButton m_PreviewClose;

		// Token: 0x04007C48 RID: 31816
		private IXUITexture m_BgTex;

		// Token: 0x04007C49 RID: 31817
		private readonly string TEXPATH = "atlas/UI/common/ProfPic";

		// Token: 0x04007C4A RID: 31818
		private string _texPath;

		// Token: 0x04007C4B RID: 31819
		private GameObject m_BranchGo1;

		// Token: 0x04007C4C RID: 31820
		private GameObject m_BranchGo2;

		// Token: 0x04007C4D RID: 31821
		private GameObject m_BranchGo3;

		// Token: 0x04007C4E RID: 31822
		private IXUIButton m_PreViewBtn;

		// Token: 0x04007C4F RID: 31823
		private IXUIButton m_TurnProBtn;

		// Token: 0x04007C50 RID: 31824
		private IXUILabel m_CurrSelectPro;

		// Token: 0x04007C51 RID: 31825
		private IXUILabel m_TurnProTips;

		// Token: 0x04007C52 RID: 31826
		private IXUILabel m_TurnProBtnText;

		// Token: 0x04007C53 RID: 31827
		private IXUICheckBox m_ProChoose_L;

		// Token: 0x04007C54 RID: 31828
		private IXUICheckBox m_ProChoose_R;

		// Token: 0x04007C55 RID: 31829
		private IXUICheckBox m_ProChoose_V;

		// Token: 0x04007C56 RID: 31830
		private XUIPool m_PreViewSkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007C57 RID: 31831
		public IXUITexture m_Snapshot;

		// Token: 0x04007C58 RID: 31832
		private RenderTexture skillPreView;

		// Token: 0x04007C59 RID: 31833
		public IXUISprite m_PlayBtn;

		// Token: 0x04007C5A RID: 31834
		private IXUILabel m_SkillName;

		// Token: 0x04007C5B RID: 31835
		private IXUILabel m_SkillDesc;

		// Token: 0x04007C5C RID: 31836
		private XUIPool m_Star_L = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007C5D RID: 31837
		private XUIPool m_Star_R = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007C5E RID: 31838
		private XUIPool m_Star_V = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007C5F RID: 31839
		private int old_branch = 0;
	}
}
