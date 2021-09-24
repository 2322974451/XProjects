using System;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAffiliate : XEntity
	{

		public override string Prefab
		{
			get
			{
				return this._present.PresentLib.Prefab;
			}
		}

		public bool Initilize(XEntity mainbody, uint present_id)
		{
			this._eEntity_Type |= XEntity.EnitityType.Entity_Affiliate;
			this._id = ((mainbody.ID & 1152921504606846975UL) | XAttributes.GetTypePrefix(EntitySpecies.Species_Affiliate));
			this._mainbody = mainbody;
			string prefab = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(present_id).Prefab;
			this._xobject = XGameObject.CreateXGameObject("Prefabs/" + prefab, true, true);
			this._xobject.UID = this._id;
			this._xobject.Name = this._id.ToString();
			this._present_id = present_id;
			return this.Initilize(0);
		}

		public bool Initilize(XEntity mainbody, uint present_id, XGameObject go)
		{
			this._eEntity_Type |= XEntity.EnitityType.Entity_Affiliate;
			this._id = ((mainbody.ID & 1152921504606846975UL) | XAttributes.GetTypePrefix(EntitySpecies.Species_Affiliate));
			this._mainbody = mainbody;
			this._xobject = go;
			bool flag = this._xobject != null;
			if (flag)
			{
				this._xobject.UID = this._id;
				this._xobject.Name = this._id.ToString();
			}
			this._present_id = present_id;
			return this.Initilize(0);
		}

		public override bool Initilize(int flag)
		{
			this._present = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPresentComponent.uuID) as XPresentComponent);
			this.InitAnim();
			return true;
		}

		public void InitAnim()
		{
			base.Scale = base.Present.PresentLib.Scale;
			bool flag = base.Ator != null;
			if (flag)
			{
				bool flag2 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && !string.IsNullOrEmpty(base.Present.PresentLib.AttackIdle);
				if (flag2)
				{
					base.OverrideAnimClip("Idle", base.Present.PresentLib.AttackIdle, true, false);
				}
				else
				{
					base.OverrideAnimClip("Idle", base.Present.PresentLib.Idle, true, false);
				}
				bool flag3 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && !string.IsNullOrEmpty(base.Present.PresentLib.AttackIdle);
				if (flag3)
				{
					base.OverrideAnimClip("Walk", base.Present.PresentLib.AttackWalk, true, false);
					base.OverrideAnimClip("Run", base.Present.PresentLib.AttackRun, true, false);
				}
				else
				{
					base.OverrideAnimClip("Walk", base.Present.PresentLib.Walk, true, false);
					base.OverrideAnimClip("Run", base.Present.PresentLib.Run, true, false);
				}
				bool flag4 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World;
				if (flag4)
				{
					base.OverrideAnimClip("Death", base.Present.PresentLib.Death, true, false);
				}
			}
		}

		public override uint PresentID
		{
			get
			{
				return this._present_id;
			}
		}

		public bool MirrorState
		{
			get
			{
				return this._mirror_state;
			}
			set
			{
				this._mirror_state = value;
			}
		}

		public void Presentation(string animation, string fx = null, string audio = null)
		{
			bool mirrorState = this.MirrorState;
			if (!mirrorState)
			{
				base.OverrideAnimClip("Idle", animation, true, false);
			}
		}

		public void OnMount()
		{
			bool mirrorState = this.MirrorState;
			if (!mirrorState)
			{
				bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && !string.IsNullOrEmpty(base.Present.PresentLib.AttackIdle);
				if (flag)
				{
					base.OverrideAnimClip("Idle", base.Present.PresentLib.AttackIdle, true, false);
				}
				else
				{
					base.OverrideAnimClip("Idle", base.Present.PresentLib.Idle, true, false);
				}
			}
		}

		public override void OnCreated()
		{
			for (int i = 0; i < base.Components.Count; i++)
			{
				bool flag = base.Components[i] != null;
				if (flag)
				{
					base.Components[i].Attached();
				}
			}
			this._mainbody.Affiliates.Add(this);
		}

		public override void OnDestroy()
		{
			bool flag = this._xobject != null;
			if (flag)
			{
				XRenderComponent.RemoveObj(this._mainbody, this._xobject.Get());
			}
			this._mainbody = null;
			base.OnDestroy();
			this.Uninitilize();
		}

		public void Replace(uint present_id, XGameObject go)
		{
			bool flag = go == this._xobject;
			if (!flag)
			{
				bool flag2 = this._xobject != null;
				if (flag2)
				{
					XRenderComponent.RemoveObj(this._mainbody, this._xobject.Get());
					XGameObject.DestroyXGameObject(this._xobject);
				}
				this._xobject = go;
				bool flag3 = this._xobject != null;
				if (flag3)
				{
					this._xobject.UID = this._id;
					this._xobject.Name = this._id.ToString();
				}
				this._present_id = present_id;
				bool flag4 = this._present != null;
				if (flag4)
				{
					this._present.InitPresent(this._present_id);
				}
				else
				{
					this._present = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPresentComponent.uuID) as XPresentComponent);
				}
				this.InitAnim();
				this._present.Attached();
			}
		}

		private static void _ChangeSpriteMatColor(XGameObject gameObject, object o, int commandID)
		{
			SpriteTable.RowData rowData = o as SpriteTable.RowData;
			bool flag = rowData == null;
			if (!flag)
			{
				Color color = XSingleton<UiUtility>.singleton.StringToColor(rowData.Color);
				Transform transform = gameObject.Find("");
				bool flag2 = transform != null;
				if (flag2)
				{
					XCommon.tmpRender.Clear();
					transform.GetComponentsInChildren<Renderer>(XCommon.tmpRender);
					int count = XCommon.tmpRender.Count;
					for (int i = 0; i < count; i++)
					{
						Renderer renderer = XCommon.tmpRender[i];
						Material material = renderer.material;
						bool flag3 = material == null;
						if (!flag3)
						{
							material.SetColor("_Color", color);
						}
					}
					XCommon.tmpRender.Clear();
				}
			}
		}

		public void ChangeSpriteMatColor()
		{
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			SpriteTable.RowData byPresentID = specificDocument._SpriteTable.GetByPresentID(this._present_id);
			bool flag = byPresentID != null;
			if (flag)
			{
				this._xobject.CallCommand(XAffiliate._changeSpriteMatColorCb, byPresentID, -1, false);
			}
		}

		private ulong _id = 0UL;

		private uint _present_id;

		private bool _mirror_state = true;

		private XEntity _mainbody = null;

		public static CommandCallback _changeSpriteMatColorCb = new CommandCallback(XAffiliate._ChangeSpriteMatColor);
	}
}
