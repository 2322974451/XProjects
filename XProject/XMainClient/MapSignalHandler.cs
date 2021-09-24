using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class MapSignalHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			this.m_SignalBtns.Clear();
			Transform transform = base.transform.FindChild("SignalFrame/OutBtn");
			for (int i = 0; i < transform.childCount; i++)
			{
				this.m_SignalBtns.Add(transform.FindChild(string.Format("SignalBtn{0}", i + 1)).GetComponent("XUISprite") as IXUISprite);
			}
			this.m_SwitchBtn = (base.transform.FindChild("SignalFrame/SwitchBtn").GetComponent("XUISprite") as IXUISprite);
			Transform tpl = base.transform.FindChild("SignalFrame/Select/Tpl");
			this.SetupSignalPool(tpl);
			this.m_SignalTextFrame = base.transform.FindChild("SignalFrame/Select").gameObject;
			this.m_SignalTextFrame.SetActive(false);
			this.m_SignalHeroIcon = (base.transform.FindChild("SignalBoard/HeroIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_SignalIcon = (base.transform.FindChild("SignalBoard/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_SignalMsg = (base.transform.FindChild("SignalBoard/Msg").GetComponent("XUILabel") as IXUILabel);
			this.m_SignalIconMsg = (base.transform.FindChild("SignalBoard/IconMsg").GetComponent("XUILabel") as IXUILabel);
			this.m_SignalBoard = base.transform.FindChild("SignalBoard").gameObject;
			this.m_SignalBoard.SetActive(false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_SwitchBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSignalSwitchClick));
		}

		public override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._signalShowToken);
			base.OnUnload();
		}

		public void ShowSignal(string heroIcon, string heroIconAtlas, string iconStr, string msg)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._signalShowToken);
			this._signalShowToken = XSingleton<XTimerMgr>.singleton.SetTimer(2f, new XTimerMgr.ElapsedEventHandler(this.OnSignalShowTimeOut), null);
			this.m_SignalBoard.SetActive(true);
			this.m_SignalHeroIcon.spriteName = heroIcon;
			bool flag = string.IsNullOrEmpty(iconStr);
			if (flag)
			{
				this.m_SignalIcon.SetVisible(false);
				this.m_SignalIconMsg.SetVisible(false);
				this.m_SignalMsg.SetVisible(true);
				this.m_SignalMsg.SetText(msg);
			}
			else
			{
				this.m_SignalIcon.SetVisible(true);
				this.m_SignalIconMsg.SetVisible(true);
				this.m_SignalMsg.SetVisible(false);
				this.m_SignalIcon.spriteName = iconStr;
				this.m_SignalIconMsg.SetText(msg);
			}
		}

		public void OnSignalShowTimeOut(object o = null)
		{
			this.m_SignalBoard.SetActive(false);
		}

		public void SetupSignalPool(Transform tpl)
		{
			this.m_SignalPool.SetupPool(tpl.parent.gameObject, tpl.gameObject, 10U, false);
			int num = 0;
			int num2 = XMobaBattleDocument.MobaSignalReader.Table.Length;
			Vector3 tplPos = this.m_SignalPool.TplPos;
			int num3 = 0;
			for (int i = 0; i < num2; i++)
			{
				MobaSignalTable.RowData rowData = XMobaBattleDocument.MobaSignalReader.Table[i];
				bool flag = !this.CheckSceneType(rowData);
				if (!flag)
				{
					bool flag2 = num3 < this.m_SignalBtns.Count;
					if (flag2)
					{
						this.m_SignalBtns[num3].ID = (ulong)rowData.ID;
						this.m_SignalBtns[num3].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSignalBtnClick));
						num3++;
					}
					else
					{
						GameObject gameObject = this.m_SignalPool.FetchGameObject(false);
						num++;
						gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)((num - 1) * this.m_SignalPool.TplHeight));
						IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)rowData.ID;
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSignalBtnClick));
						IXUILabel ixuilabel = gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
						ixuilabel.SetText(rowData.Text);
					}
				}
			}
			IXUISprite ixuisprite2 = tpl.parent.FindChild("Bg").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.spriteHeight = 46 + this.m_SignalPool.TplHeight * (num - 1);
		}

		public bool CheckSceneType(MobaSignalTable.RowData data)
		{
			bool flag = data.SceneType == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < data.SceneType.Length; i++)
				{
					bool flag2 = data.SceneType[i] == (int)XSingleton<XScene>.singleton.SceneType;
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		public void OnSignalBtnClick(IXUISprite iSp)
		{
			this._doc.SendSignal((uint)iSp.ID);
			this.m_SignalTextFrame.SetActive(false);
		}

		public void OnSignalSwitchClick(IXUISprite iSp)
		{
			this.m_SignalTextFrame.SetActive(!this.m_SignalTextFrame.activeSelf);
		}

		private XMobaBattleDocument _doc = null;

		private List<IXUISprite> m_SignalBtns = new List<IXUISprite>();

		private IXUISprite m_SwitchBtn;

		private XUIPool m_SignalPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private GameObject m_SignalTextFrame;

		private IXUISprite m_SignalHeroIcon;

		private IXUISprite m_SignalIcon;

		private IXUILabel m_SignalMsg;

		private IXUILabel m_SignalIconMsg;

		private GameObject m_SignalBoard;

		private uint _signalShowToken;
	}
}
