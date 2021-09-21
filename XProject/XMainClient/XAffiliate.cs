using System;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D44 RID: 3396
	internal class XAffiliate : XEntity
	{
		// Token: 0x17003313 RID: 13075
		// (get) Token: 0x0600BC0B RID: 48139 RVA: 0x0026BE7C File Offset: 0x0026A07C
		public override string Prefab
		{
			get
			{
				return this._present.PresentLib.Prefab;
			}
		}

		// Token: 0x0600BC0C RID: 48140 RVA: 0x0026BEA0 File Offset: 0x0026A0A0
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

		// Token: 0x0600BC0D RID: 48141 RVA: 0x0026BF50 File Offset: 0x0026A150
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

		// Token: 0x0600BC0E RID: 48142 RVA: 0x0026BFE8 File Offset: 0x0026A1E8
		public override bool Initilize(int flag)
		{
			this._present = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPresentComponent.uuID) as XPresentComponent);
			this.InitAnim();
			return true;
		}

		// Token: 0x0600BC0F RID: 48143 RVA: 0x0026C020 File Offset: 0x0026A220
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

		// Token: 0x17003314 RID: 13076
		// (get) Token: 0x0600BC10 RID: 48144 RVA: 0x0026C1AC File Offset: 0x0026A3AC
		public override uint PresentID
		{
			get
			{
				return this._present_id;
			}
		}

		// Token: 0x17003315 RID: 13077
		// (get) Token: 0x0600BC11 RID: 48145 RVA: 0x0026C1C4 File Offset: 0x0026A3C4
		// (set) Token: 0x0600BC12 RID: 48146 RVA: 0x0026C1DC File Offset: 0x0026A3DC
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

		// Token: 0x0600BC13 RID: 48147 RVA: 0x0026C1E8 File Offset: 0x0026A3E8
		public void Presentation(string animation, string fx = null, string audio = null)
		{
			bool mirrorState = this.MirrorState;
			if (!mirrorState)
			{
				base.OverrideAnimClip("Idle", animation, true, false);
			}
		}

		// Token: 0x0600BC14 RID: 48148 RVA: 0x0026C214 File Offset: 0x0026A414
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

		// Token: 0x0600BC15 RID: 48149 RVA: 0x0026C2A0 File Offset: 0x0026A4A0
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

		// Token: 0x0600BC16 RID: 48150 RVA: 0x0026C304 File Offset: 0x0026A504
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

		// Token: 0x0600BC17 RID: 48151 RVA: 0x0026C350 File Offset: 0x0026A550
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

		// Token: 0x0600BC18 RID: 48152 RVA: 0x0026C43C File Offset: 0x0026A63C
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

		// Token: 0x0600BC19 RID: 48153 RVA: 0x0026C508 File Offset: 0x0026A708
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

		// Token: 0x04004C4D RID: 19533
		private ulong _id = 0UL;

		// Token: 0x04004C4E RID: 19534
		private uint _present_id;

		// Token: 0x04004C4F RID: 19535
		private bool _mirror_state = true;

		// Token: 0x04004C50 RID: 19536
		private XEntity _mainbody = null;

		// Token: 0x04004C51 RID: 19537
		public static CommandCallback _changeSpriteMatColorCb = new CommandCallback(XAffiliate._ChangeSpriteMatColor);
	}
}
