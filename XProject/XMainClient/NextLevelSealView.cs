using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class NextLevelSealView : DlgBase<NextLevelSealView, NextLevelSealBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "OperatingActivity/NextSeal";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshPage();
		}

		protected override void OnHide()
		{
			base.uiBehaviour.m_NextSealTexL.SetTexturePath("");
			base.uiBehaviour.m_NextSealTexR.SetTexturePath("");
			base.uiBehaviour.m_NextSealTexM.SetTexturePath("");
			base.OnHide();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		public void RefreshPage()
		{
			uint removeSealType = this.doc.GetRemoveSealType(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			Queue<LevelSealNewFunctionTable.RowData> levelSealNewFunction = this.doc.GetLevelSealNewFunction(removeSealType);
			base.uiBehaviour.m_NewFunctionPool.ReturnAll(false);
			int count = levelSealNewFunction.Count;
			for (int i = 0; i < count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_NewFunctionPool.FetchGameObject(false);
				LevelSealNewFunctionTable.RowData rowData = levelSealNewFunction.Dequeue();
				(gameObject.transform.Find("Function/Level").GetComponent("XUILabel") as IXUILabel).SetText(rowData.OpenLevel.ToString() + XStringDefineProxy.GetString("SEAL_OPEN_FUNCTION"));
				(gameObject.transform.Find("Function/Name").GetComponent("XUILabel") as IXUILabel).SetText(rowData.Tag);
				(gameObject.transform.Find("Function/P").GetComponent("XUISprite") as IXUISprite).SetSprite(rowData.IconName);
				gameObject.transform.localPosition = new Vector3((float)(base.uiBehaviour.m_NewFunctionPool.TplWidth * i), 0f, 0f);
			}
			bool flag = count == 0;
			if (flag)
			{
				base.uiBehaviour.m_NewFunction.gameObject.SetActive(false);
			}
			else
			{
				base.uiBehaviour.m_NewFunction.gameObject.SetActive(true);
				base.uiBehaviour.m_NewFunctionBg.spriteWidth = base.uiBehaviour.m_NewFunctionBgWidth + (count - 1) * base.uiBehaviour.m_NewFunctionPool.TplWidth;
			}
			LevelSealTypeTable.RowData levelSealType = XLevelSealDocument.GetLevelSealType(removeSealType);
			bool flag2 = !string.IsNullOrEmpty(levelSealType.NextSealImageL);
			if (flag2)
			{
				base.uiBehaviour.m_NextSealTexL.SetTexturePath(levelSealType.NextSealImageL);
			}
			bool flag3 = !string.IsNullOrEmpty(levelSealType.NextSealImageR);
			if (flag3)
			{
				base.uiBehaviour.m_NextSealTexR.SetTexturePath(levelSealType.NextSealImageR);
			}
			bool flag4 = levelSealType.NextSealImageBig != null && levelSealType.NextSealImageBig != "";
			if (flag4)
			{
				base.uiBehaviour.m_NextSealTexM.SetAlpha(1f);
				base.uiBehaviour.m_NextSealTexM.SetTexturePath(levelSealType.NextSealImageBig);
			}
			else
			{
				base.uiBehaviour.m_NextSealTexM.SetAlpha(0f);
			}
		}

		public void SetNextSealLabel(string str)
		{
			base.uiBehaviour.m_NextSealLabel.SetText(str);
		}

		public void SetPosition(Vector3 pos)
		{
			base.uiBehaviour.transform.position = pos;
		}

		private XLevelSealDocument doc = null;
	}
}
