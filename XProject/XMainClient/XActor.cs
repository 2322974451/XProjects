using System;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DBD RID: 3517
	internal sealed class XActor : XObject
	{
		// Token: 0x1700335D RID: 13149
		// (get) Token: 0x0600BE92 RID: 48786 RVA: 0x0027D014 File Offset: 0x0027B214
		// (set) Token: 0x0600BE93 RID: 48787 RVA: 0x0027D02C File Offset: 0x0027B22C
		public uint Fashion
		{
			get
			{
				return this._fashion_id;
			}
			set
			{
				this._fashion_id = value;
			}
		}

		// Token: 0x1700335E RID: 13150
		// (get) Token: 0x0600BE94 RID: 48788 RVA: 0x0027D038 File Offset: 0x0027B238
		public XDummy Dummy
		{
			get
			{
				return this._dummy;
			}
		}

		// Token: 0x0600BE95 RID: 48789 RVA: 0x0027D050 File Offset: 0x0027B250
		public XActor(Vector3 pos, string clip)
		{
			XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
			bool flag = XSingleton<XGlobalConfig>.singleton.BlockFashionProfs.Contains(player.Attributes.TypeID % 10U);
			XOutlookData xoutlookData;
			if (flag)
			{
				xoutlookData = new XOutlookData();
				xoutlookData.SetProfType(player.Attributes.TypeID);
				xoutlookData.CalculateOutLookFashion();
			}
			else
			{
				xoutlookData = player.Attributes.Outlook;
			}
			xoutlookData.uiAvatar = false;
			this._dummy = XSingleton<XEntityMgr>.singleton.CreateDummy(player.PresentID, player.BasicTypeID, xoutlookData, false, false, false);
			this._dummy.EngineObject.Position = pos;
			this._actor = this._dummy.EngineObject;
			this._ator = this._dummy.Ator;
			this.OverrideAnim(clip);
			this.TurnOnSkinnedMesh(this._actor);
		}

		// Token: 0x0600BE96 RID: 48790 RVA: 0x0027D15C File Offset: 0x0027B35C
		public XActor(uint id, Vector3 pos, string clip)
		{
			XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(id);
			XOutlookData xoutlookData = new XOutlookData();
			xoutlookData.SetDefaultFashion(byID.FashionTemplate);
			xoutlookData.uiAvatar = false;
			this._dummy = XSingleton<XEntityMgr>.singleton.CreateDummy(byID.PresentID, (uint)byID.FashionTemplate, xoutlookData, false, false, false);
			this._dummy.EngineObject.Position = pos;
			this._actor = this._dummy.EngineObject;
			this._ator = this._dummy.Ator;
			this.OverrideAnim(clip);
			this.TurnOnSkinnedMesh(this._actor);
		}

		// Token: 0x0600BE97 RID: 48791 RVA: 0x0027D230 File Offset: 0x0027B430
		public XActor(string prefab, Vector3 pos, Quaternion face, string clip)
		{
			this._actor = XGameObject.CreateXGameObject(prefab, pos, face, false, true);
			this._ator = this._actor.InitAnim();
			this.OverrideAnim(clip);
		}

		// Token: 0x0600BE98 RID: 48792 RVA: 0x0027D29C File Offset: 0x0027B49C
		public void OverrideAnim(string clip)
		{
			this._clip = clip;
			bool flag = this._ator != null;
			if (flag)
			{
				this._ator.OverrideAnim("Idle", clip, null, false);
			}
		}

		// Token: 0x0600BE99 RID: 48793 RVA: 0x0027D2D4 File Offset: 0x0027B4D4
		public void ReplaceActor(XDummy dummy)
		{
			bool flag = dummy == this._dummy;
			if (!flag)
			{
				dummy.EngineObject.Position = this._dummy.EngineObject.Position;
				dummy.EngineObject.Tag = this._dummy.EngineObject.Tag;
				dummy.EngineObject.EnableCC = this._dummy.EngineObject.EnableCC;
				dummy.EngineObject.EnableBC = this._dummy.EngineObject.EnableBC;
				string clip = this._clip;
				this.OverrideAnim("");
				XSingleton<XEntityMgr>.singleton.DestroyEntity(this._dummy);
				this._dummy = dummy;
				this._actor = this._dummy.EngineObject;
				this._ator = this._dummy.Ator;
				this._ator.cullingMode = 0;
				this.OverrideAnim(clip);
				this.TurnOnSkinnedMesh(this._actor);
			}
		}

		// Token: 0x0600BE9A RID: 48794 RVA: 0x0027D3D3 File Offset: 0x0027B5D3
		public void PlayAnimation(string clip)
		{
			this._dummy.OverrideAnimClip("Idle", clip, false, false);
		}

		// Token: 0x0600BE9B RID: 48795 RVA: 0x0027D3EC File Offset: 0x0027B5EC
		public override bool Initilize(int flag)
		{
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XAudioComponent.uuID);
			bool flag2 = this._ator != null;
			if (flag2)
			{
				this._ator.cullingMode = 0;
			}
			this._actor.EnableCC = false;
			bool flag3 = XSingleton<XGame>.singleton.CurrentStage != null && XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.SelectChar && XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Login;
			if (flag3)
			{
				this._actor.EnableBC = false;
			}
			else
			{
				this._actor.EnableBC = true;
			}
			return true;
		}

		// Token: 0x0600BE9C RID: 48796 RVA: 0x0027D494 File Offset: 0x0027B694
		public override void Uninitilize()
		{
			this.TurnOffSkinnedMesh(this._actor);
			bool flag = this._dummy == null;
			if (flag)
			{
				bool flag2 = this._actor != null;
				if (flag2)
				{
					XGameObject.DestroyXGameObject(this._actor);
					this._actor = null;
				}
			}
			else
			{
				bool flag3 = !this._dummy.Deprecated;
				if (flag3)
				{
					XSingleton<XEntityMgr>.singleton.DestroyEntity(this._dummy);
				}
				this._dummy = null;
			}
			base.Uninitilize();
		}

		// Token: 0x1700335F RID: 13151
		// (get) Token: 0x0600BE9D RID: 48797 RVA: 0x0027D518 File Offset: 0x0027B718
		public override XGameObject EngineObject
		{
			get
			{
				return this._actor;
			}
		}

		// Token: 0x0600BE9E RID: 48798 RVA: 0x0027D530 File Offset: 0x0027B730
		private void TurnOnSkinnedMesh(XGameObject o)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_LOGIN;
			if (flag)
			{
				this._actor.UpdateWhenOffscreen = true;
			}
		}

		// Token: 0x0600BE9F RID: 48799 RVA: 0x0027D560 File Offset: 0x0027B760
		private void TurnOffSkinnedMesh(XGameObject o)
		{
			this._actor.UpdateWhenOffscreen = false;
		}

		// Token: 0x0600BEA0 RID: 48800 RVA: 0x0027D570 File Offset: 0x0027B770
		public void GetCurrentAnimLength(OverrideAnimCallback overrideAnimCb)
		{
			bool flag = this._ator != null;
			if (flag)
			{
				this._ator.SetAnimLoadCallback("Idle", overrideAnimCb);
			}
		}

		// Token: 0x04004DF1 RID: 19953
		private XGameObject _actor = null;

		// Token: 0x04004DF2 RID: 19954
		private XAnimator _ator = null;

		// Token: 0x04004DF3 RID: 19955
		private XDummy _dummy = null;

		// Token: 0x04004DF4 RID: 19956
		private uint _fashion_id = 0U;

		// Token: 0x04004DF5 RID: 19957
		private string _clip = null;

		// Token: 0x04004DF6 RID: 19958
		public bool Replaced = false;
	}
}
