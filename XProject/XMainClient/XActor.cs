using System;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XActor : XObject
	{

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

		public XDummy Dummy
		{
			get
			{
				return this._dummy;
			}
		}

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

		public XActor(string prefab, Vector3 pos, Quaternion face, string clip)
		{
			this._actor = XGameObject.CreateXGameObject(prefab, pos, face, false, true);
			this._ator = this._actor.InitAnim();
			this.OverrideAnim(clip);
		}

		public void OverrideAnim(string clip)
		{
			this._clip = clip;
			bool flag = this._ator != null;
			if (flag)
			{
				this._ator.OverrideAnim("Idle", clip, null, false);
			}
		}

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

		public void PlayAnimation(string clip)
		{
			this._dummy.OverrideAnimClip("Idle", clip, false, false);
		}

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

		public override XGameObject EngineObject
		{
			get
			{
				return this._actor;
			}
		}

		private void TurnOnSkinnedMesh(XGameObject o)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_LOGIN;
			if (flag)
			{
				this._actor.UpdateWhenOffscreen = true;
			}
		}

		private void TurnOffSkinnedMesh(XGameObject o)
		{
			this._actor.UpdateWhenOffscreen = false;
		}

		public void GetCurrentAnimLength(OverrideAnimCallback overrideAnimCb)
		{
			bool flag = this._ator != null;
			if (flag)
			{
				this._ator.SetAnimLoadCallback("Idle", overrideAnimCb);
			}
		}

		private XGameObject _actor = null;

		private XAnimator _ator = null;

		private XDummy _dummy = null;

		private uint _fashion_id = 0U;

		private string _clip = null;

		public bool Replaced = false;
	}
}
