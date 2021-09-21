using System;
using System.Text;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DC3 RID: 3523
	internal sealed class XNpc : XEntity
	{
		// Token: 0x0600BFBD RID: 49085 RVA: 0x002830C8 File Offset: 0x002812C8
		public XNpc()
		{
			this._resetIdleCb = new XTimerMgr.ElapsedEventHandler(this.ResetIdle);
		}

		// Token: 0x0600BFBE RID: 49086 RVA: 0x00283150 File Offset: 0x00281350
		private static void _FindHead(XGameObject gameObject, object o, int commandID)
		{
			XNpc xnpc = o as XNpc;
			bool flag = xnpc != null;
			if (flag)
			{
				StringBuilder stringBuilder = xnpc._onlyHead ? new StringBuilder("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 Head", 128) : new StringBuilder("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1", 128);
				string text = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(xnpc.Attributes.PresentID).BoneSuffix + "/";
				stringBuilder.Replace("/", text);
				stringBuilder.Append(text);
				xnpc._head = xnpc.EngineObject.Find(stringBuilder.ToString(0, stringBuilder.Length - 1));
				bool flag2 = xnpc._head == null;
				if (flag2)
				{
					stringBuilder.Replace("/Bip001 Spine1" + text, "/");
					xnpc._head = xnpc.EngineObject.Find(stringBuilder.ToString(0, stringBuilder.Length - 1));
				}
			}
		}

		// Token: 0x0600BFBF RID: 49087 RVA: 0x00283248 File Offset: 0x00281448
		public override bool Initilize(int flag)
		{
			this._eEntity_Type |= XEntity.EnitityType.Entity_Npc;
			this._layer = LayerMask.NameToLayer("Npc");
			this._using_cc_move = false;
			this._present = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPresentComponent.uuID) as XPresentComponent);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XIdleComponent.uuID);
			this._billboard = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBillboardComponent.uuID) as XBillboardComponent);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XCharacterShowChatComponent.uuID);
			this._audio = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XAudioComponent.uuID) as XAudioComponent);
			bool flag2 = this._transformee == null && this._present != null && this._present.PresentLib.Shadow;
			if (flag2)
			{
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XShadowComponent.uuID);
			}
			XNpcInfo.RowData byNPCID = XSingleton<XEntityMgr>.singleton.NpcInfo.GetByNPCID(this.Attributes.TypeID);
			this._uGazing = (XQualitySetting.GetQuality(EFun.ENpcShadow) ? byNPCID.Gazing : 0U);
			this._show_ups = byNPCID.ShowUp;
			this._linkSys = byNPCID.LinkSystem;
			this._special_anim = byNPCID.SpecialAnim;
			this._special_chat = byNPCID.SpecialChat.Split(new char[]
			{
				'|'
			});
			bool flag3 = this._uGazing > 0U;
			if (flag3)
			{
				this._onlyHead = byNPCID.OnlyHead;
				this._head_rotate = this.EngineObject.Forward;
				this.EngineObject.CallCommand(XNpc._findHeadCb, this, -1, false);
			}
			this._npc_type = XSingleton<XEntityMgr>.singleton.NpcInfo.GetByNPCID(this.TypeID).NPCType;
			base.Ator.cullingMode = (AnimatorCullingMode)1;
			return true;
		}

		// Token: 0x0600BFC0 RID: 49088 RVA: 0x00283410 File Offset: 0x00281610
		public override void PostUpdate(float fDeltaT)
		{
			bool flag = this._uGazing > 0U && this._head != null;
			if (flag)
			{
				Vector3 vector = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position - this.EngineObject.Position;
				float magnitude = vector.magnitude;
				XSingleton<XCommon>.singleton.Horizontal(ref vector);
				bool flag2 = magnitude < 10f;
				if (flag2)
				{
					Vector3 forward = this.EngineObject.Forward;
					bool flag3 = Vector3.Angle(vector, forward) > this._uGazing;
					if (flag3)
					{
						vector = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(forward, (float)(XSingleton<XCommon>.singleton.Clockwise(forward, vector) ? ((ulong)this._uGazing) : (-(float)((ulong)this._uGazing))), true);
					}
				}
				else
				{
					vector = this.EngineObject.Forward;
				}
				this._head_rotate += (vector - this._head_rotate) * Mathf.Min(1f, 3f * fDeltaT);
				float num = XSingleton<XCommon>.singleton.AngleToFloat(this._head_rotate);
				num -= this.EngineObject.Rotation.eulerAngles.y;
				Vector3 localEulerAngles = this._head.localEulerAngles;
				localEulerAngles.x += -num;
				localEulerAngles.x %= 360f;
				bool flag4 = localEulerAngles.x > 180f;
				if (flag4)
				{
					localEulerAngles.x -= 360f;
				}
				bool flag5 = localEulerAngles.x < -180f;
				if (flag5)
				{
					localEulerAngles.x += 360f;
				}
				bool flag6 = Mathf.Abs(localEulerAngles.x) > this._uGazing;
				if (flag6)
				{
					localEulerAngles.x = (float)((localEulerAngles.x > 0f) ? ((ulong)this._uGazing) : (-(float)((ulong)this._uGazing)));
				}
				this._head.localEulerAngles = localEulerAngles;
			}
			base.PostUpdate(fDeltaT);
		}

		// Token: 0x0600BFC1 RID: 49089 RVA: 0x0028361C File Offset: 0x0028181C
		private void AnimLoadCallback(XAnimationClip clip)
		{
			this._token = XSingleton<XTimerMgr>.singleton.SetTimer(clip.length - 0.034f, this._resetIdleCb, null);
			bool flag = this.animLoadCb != null;
			if (flag)
			{
				this.animLoadCb(clip);
				this.animLoadCb = null;
			}
		}

		// Token: 0x0600BFC2 RID: 49090 RVA: 0x00283670 File Offset: 0x00281870
		public bool ShowUp(OverrideAnimCallback animLoad = null)
		{
			bool flag = this._show_ups != null && this._show_ups.Length != 0;
			bool result;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
				int num = XSingleton<XCommon>.singleton.RandomInt(0, this._show_ups.Length);
				this.animLoadCb = animLoad;
				base.OverrideAnimClip("Idle", this._show_ups[num], false, new OverrideAnimCallback(this.AnimLoadCallback), false);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600BFC3 RID: 49091 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void Move()
		{
		}

		// Token: 0x0600BFC4 RID: 49092 RVA: 0x002836EF File Offset: 0x002818EF
		public override void OnDestroy()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
			base.OnDestroy();
		}

		// Token: 0x170033C1 RID: 13249
		// (get) Token: 0x0600BFC5 RID: 49093 RVA: 0x0028370C File Offset: 0x0028190C
		public uint NPCType
		{
			get
			{
				return this._npc_type;
			}
		}

		// Token: 0x0600BFC6 RID: 49094 RVA: 0x00283724 File Offset: 0x00281924
		private void ResetIdle(object o)
		{
			bool flag = base.Deprecated || base.Present == null || base.Present.PresentLib == null;
			if (!flag)
			{
				bool flag2 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && base.Present.PresentLib.AttackIdle.Length > 0;
				if (flag2)
				{
					base.OverrideAnimClip("Idle", base.Present.PresentLib.AttackIdle, true, false);
				}
				else
				{
					base.OverrideAnimClip("Idle", base.Present.PresentLib.Idle, true, false);
				}
			}
		}

		// Token: 0x0600BFC7 RID: 49095 RVA: 0x002837C8 File Offset: 0x002819C8
		public override bool CastFakeShadow()
		{
			return XQualitySetting.GetQuality(EFun.ENpcShadow);
		}

		// Token: 0x0600BFC8 RID: 49096 RVA: 0x002837E0 File Offset: 0x002819E0
		public static void DelayCreateNpc(uint npcId)
		{
			XNpc npc = XSingleton<XEntityMgr>.singleton.CreateNpc(npcId, true);
			XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			specificDocument.CreateFx(npc, npcId);
		}

		// Token: 0x0600BFC9 RID: 49097 RVA: 0x00283810 File Offset: 0x00281A10
		public void InteractRoleDance(XRole role, bool dancing)
		{
			bool flag = base.Deprecated || base.Present == null || base.Present.PresentLib == null;
			if (!flag)
			{
				float num = Vector3.Distance(role.MoveObj.Position, base.MoveObj.Position);
				float num2 = (float)XSingleton<XGlobalConfig>.singleton.GetInt("NPCSpecailAnim");
				bool flag2 = num < num2 && !string.IsNullOrEmpty(this._special_anim);
				if (flag2)
				{
					if (dancing)
					{
						base.OverrideAnimClip("Idle", this._special_anim, false, new OverrideAnimCallback(this.AnimLoadCallback), false);
						XCharacterShowChatComponent xcharacterShowChatComponent = base.GetXComponent(XCharacterShowChatComponent.uuID) as XCharacterShowChatComponent;
						bool flag3 = xcharacterShowChatComponent != null;
						if (flag3)
						{
							xcharacterShowChatComponent.AttachChatBubble();
							int num3 = UnityEngine.Random.Range(0, this._special_chat.Length);
							xcharacterShowChatComponent.DealWithChat(this._special_chat[num3]);
						}
					}
					else
					{
						this.ResetIdle(null);
					}
				}
			}
		}

		// Token: 0x04004E57 RID: 20055
		private uint _uGazing = 0U;

		// Token: 0x04004E58 RID: 20056
		private uint _token = 0U;

		// Token: 0x04004E59 RID: 20057
		private Transform _head = null;

		// Token: 0x04004E5A RID: 20058
		private Vector3 _head_rotate = Vector3.forward;

		// Token: 0x04004E5B RID: 20059
		private bool _onlyHead = true;

		// Token: 0x04004E5C RID: 20060
		private string[] _show_ups = null;

		// Token: 0x04004E5D RID: 20061
		public uint _npc_type = 0U;

		// Token: 0x04004E5E RID: 20062
		public int _linkSys = 0;

		// Token: 0x04004E5F RID: 20063
		private string _special_anim = string.Empty;

		// Token: 0x04004E60 RID: 20064
		private string[] _special_chat = new string[0];

		// Token: 0x04004E61 RID: 20065
		public static int NpcLayer = LayerMask.NameToLayer("Npc");

		// Token: 0x04004E62 RID: 20066
		private static CommandCallback _findHeadCb = new CommandCallback(XNpc._FindHead);

		// Token: 0x04004E63 RID: 20067
		private XTimerMgr.ElapsedEventHandler _resetIdleCb = null;

		// Token: 0x04004E64 RID: 20068
		private OverrideAnimCallback animLoadCb = null;
	}
}
