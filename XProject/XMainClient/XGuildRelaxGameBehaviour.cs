using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XGuildRelaxGameBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_GameTemp = base.transform.FindChild("Bg/GameList/GameTpl").gameObject;
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_GameScrollView = (base.transform.FindChild("Bg/GameList").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_GameTemp.gameObject.SetActive(false);
		}

		public IXUIButton m_Close;

		public GameObject m_GameTemp;

		public IXUIScrollView m_GameScrollView;
	}
}
