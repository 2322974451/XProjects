using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class TitleShareBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_snapshotTransfrom = (base.transform.FindChild("Bg/Snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_maskTexture = (base.transform.FindChild("Bg/Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_currentTitle.Init(base.transform.FindChild("Bg/Current"));
			this.m_closeTips = base.transform.FindChild("Bg/KeepOn");
			this.m_message = (base.transform.FindChild("Bg/Message").GetComponent("XUILabel") as IXUILabel);
			this.m_Close = (base.transform.FindChild("Bg/P").GetComponent("XUISprite") as IXUISprite);
		}

		public TitleDisplay m_currentTitle = new TitleDisplay();

		public IXUITexture m_maskTexture;

		public IUIDummy m_snapshotTransfrom;

		public Transform m_closeTips;

		public IXUILabel m_message;

		public IXUISprite m_Close;
	}
}
