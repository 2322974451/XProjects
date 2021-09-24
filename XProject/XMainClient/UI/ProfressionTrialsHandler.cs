using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ProfressionTrialsHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/ProfTrialsDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.GetProfressional();
			this._FxList.Clear();
			this._ClickTips.Clear();
			Transform transform = base.PanelObject.transform.Find("Bg/Tabs/Tab1");
			bool flag = this._pro.Count > 0;
			if (flag)
			{
				this.SetProSelect(transform, 0);
			}
			transform = base.PanelObject.transform.Find("Bg/Tabs/Tab2");
			bool flag2 = this._pro.Count > 1;
			if (flag2)
			{
				transform.gameObject.SetActive(true);
				this.SetProSelect(transform, 1);
			}
			else
			{
				transform.gameObject.SetActive(false);
			}
			transform = base.PanelObject.transform.Find("Bg/Tabs/Tab3");
			bool flag3 = this._pro.Count > 2;
			if (flag3)
			{
				transform.gameObject.SetActive(true);
				this.SetProSelect(transform, 2);
			}
			else
			{
				transform.gameObject.SetActive(false);
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		private void GetProfressional()
		{
			XProfessionChangeDocument specificDocument = XDocuments.GetSpecificDocument<XProfessionChangeDocument>(XProfessionChangeDocument.uuID);
			bool flag = XSingleton<XScene>.singleton.SceneID != specificDocument.SceneID;
			if (flag)
			{
				List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("ChangeProTaskIds");
				int num = 0;
				XTaskDocument specificDocument2 = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
				for (int i = 0; i < intList.Count; i++)
				{
					bool flag2 = !specificDocument2.TaskRecord.IsTaskFinished((uint)intList[i]);
					if (flag2)
					{
						num = i + 1;
						break;
					}
				}
				bool flag3 = num == 0;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Profression trials task error. promote = 0", null, null, null, null, null);
				}
				int typeID = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID;
				int num2 = typeID + this.MI[num];
				int num3 = typeID + this.MI[num] * 2;
				int num4 = typeID + this.MI[num] * 3;
				this._pro.Clear();
				bool flag4 = XSingleton<XProfessionSkillMgr>.singleton.IsExistProf(num2);
				bool flag5 = XSingleton<XProfessionSkillMgr>.singleton.IsExistProf(num3);
				bool flag6 = XSingleton<XProfessionSkillMgr>.singleton.IsExistProf(num4) && ProfressionTrialsHandler.IsShowAvengerProf;
				bool profIsInLeft = XSingleton<XProfessionSkillMgr>.singleton.GetProfIsInLeft(num2);
				if (profIsInLeft)
				{
					bool flag7 = flag4;
					if (flag7)
					{
						this._pro.Add(num2);
					}
					bool flag8 = flag5;
					if (flag8)
					{
						this._pro.Add(num3);
					}
				}
				else
				{
					bool flag9 = flag5;
					if (flag9)
					{
						this._pro.Add(num3);
					}
					bool flag10 = flag4;
					if (flag10)
					{
						this._pro.Add(num2);
					}
				}
				bool flag11 = flag6;
				if (flag11)
				{
					flag6 = XSkillTreeDocument.IsAvengerTaskDone(num4);
					bool flag12 = flag6;
					if (flag12)
					{
						this._pro.Add(num4);
					}
				}
			}
			else
			{
				int selectProfession = specificDocument.SelectProfession;
				int num5 = selectProfession + 10;
				int item = selectProfession + 20;
				int num6 = selectProfession + 30;
				this._pro.Clear();
				bool profIsInLeft2 = XSingleton<XProfessionSkillMgr>.singleton.GetProfIsInLeft(num5);
				if (profIsInLeft2)
				{
					this._pro.Add(num5);
					this._pro.Add(item);
				}
				else
				{
					this._pro.Add(item);
					this._pro.Add(num5);
				}
				bool flag13 = XSingleton<XProfessionSkillMgr>.singleton.IsExistProf(num6) && ProfressionTrialsHandler.IsShowAvengerProf;
				bool flag14 = flag13;
				if (flag14)
				{
					flag13 = XSkillTreeDocument.IsAvengerTaskDone(num6);
					bool flag15 = flag13;
					if (flag15)
					{
						this._pro.Add(num6);
					}
				}
			}
		}

		private void SetProSelect(Transform ts, int i)
		{
			IXUICheckBox ixuicheckBox = ts.GetComponent("XUICheckBox") as IXUICheckBox;
			ixuicheckBox.ID = (ulong)((long)i);
			ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCheckBoxClick));
			bool flag = i == 0;
			if (flag)
			{
				this.m_GeneralTab = ixuicheckBox;
			}
			GameObject gameObject = ts.Find("Selected/FX").gameObject;
			this._FxList.Add(gameObject);
			GameObject gameObject2 = ts.Find("ClickText").gameObject;
			this._ClickTips.Add(gameObject2);
			IXUISprite ixuisprite = ts.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(this._pro[i]);
			IXUILabel ixuilabel = ts.Find("ProName").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName(this._pro[i]));
		}

		private bool OnCheckBoxClick(IXUICheckBox icb)
		{
			bool flag = !icb.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int num = (int)icb.ID;
				for (int i = 0; i < this._FxList.Count; i++)
				{
					this._FxList[i].SetActive(i == num);
				}
				for (int i = 0; i < this._ClickTips.Count; i++)
				{
					this._ClickTips[i].SetActive(i != num);
				}
				uint promoteExperienceID = XSingleton<XProfessionSkillMgr>.singleton.GetPromoteExperienceID(this._pro[num]);
				XSingleton<XDebug>.singleton.AddLog("Change PromoteExperienceID to ", promoteExperienceID.ToString(), null, null, null, null, XDebugColor.XDebug_None);
				XSingleton<XEntityMgr>.singleton.Player.OnTransform(promoteExperienceID);
				result = true;
			}
			return result;
		}

		public void SetGeneralTab()
		{
			bool flag = this.m_GeneralTab != null;
			if (flag)
			{
				this.m_GeneralTab.bChecked = true;
			}
		}

		private List<int> _pro = new List<int>();

		private int[] MI = new int[]
		{
			1,
			10,
			100,
			1000,
			10000
		};

		private static readonly bool IsShowAvengerProf = false;

		private List<GameObject> _FxList = new List<GameObject>();

		private List<GameObject> _ClickTips = new List<GameObject>();

		private IXUICheckBox m_GeneralTab;
	}
}
