using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001838 RID: 6200
	internal class GuildDragonChallengeResultView : DlgBase<GuildDragonChallengeResultView, GuildDragonChallengeResultBehaviour>
	{
		// Token: 0x17003940 RID: 14656
		// (get) Token: 0x060101B3 RID: 65971 RVA: 0x003D961C File Offset: 0x003D781C
		public override string fileName
		{
			get
			{
				return "Battle/Comcotinue";
			}
		}

		// Token: 0x17003941 RID: 14657
		// (get) Token: 0x060101B4 RID: 65972 RVA: 0x003D9634 File Offset: 0x003D7834
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003942 RID: 14658
		// (get) Token: 0x060101B5 RID: 65973 RVA: 0x003D9648 File Offset: 0x003D7848
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003943 RID: 14659
		// (get) Token: 0x060101B6 RID: 65974 RVA: 0x003D965C File Offset: 0x003D785C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060101B7 RID: 65975 RVA: 0x003D966F File Offset: 0x003D786F
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
			this._Doc._GuildDragonChallengeResultView = this;
		}

		// Token: 0x060101B8 RID: 65976 RVA: 0x003D9696 File Offset: 0x003D7896
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x060101B9 RID: 65977 RVA: 0x003D96A0 File Offset: 0x003D78A0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_ReturnBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReturn));
		}

		// Token: 0x060101BA RID: 65978 RVA: 0x003D96C7 File Offset: 0x003D78C7
		private void OnReturn(IXUISprite sp)
		{
			this._Doc.ReqQutiScene();
		}

		// Token: 0x040072D5 RID: 29397
		private XGuildDragonDocument _Doc;
	}
}
