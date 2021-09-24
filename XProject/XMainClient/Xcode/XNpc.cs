using System;
using System.Text;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XNpc : XEntity
	{

		public XNpc()
		{
			this._resetIdleCb = new XTimerMgr.ElapsedEventHandler(this.ResetIdle);
		}

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

		protected override void Move()
		{
		}

		public override void OnDestroy()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
			base.OnDestroy();
		}

		public uint NPCType
		{
			get
			{
				return this._npc_type;
			}
		}

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

		public override bool CastFakeShadow()
		{
			return XQualitySetting.GetQuality(EFun.ENpcShadow);
		}

		public static void DelayCreateNpc(uint npcId)
		{
			XNpc npc = XSingleton<XEntityMgr>.singleton.CreateNpc(npcId, true);
			XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			specificDocument.CreateFx(npc, npcId);
		}

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

		private uint _uGazing = 0U;

		private uint _token = 0U;

		private Transform _head = null;

		private Vector3 _head_rotate = Vector3.forward;

		private bool _onlyHead = true;

		private string[] _show_ups = null;

		public uint _npc_type = 0U;

		public int _linkSys = 0;

		private string _special_anim = string.Empty;

		private string[] _special_chat = new string[0];

		public static int NpcLayer = LayerMask.NameToLayer("Npc");

		private static CommandCallback _findHeadCb = new CommandCallback(XNpc._FindHead);

		private XTimerMgr.ElapsedEventHandler _resetIdleCb = null;

		private OverrideAnimCallback animLoadCb = null;
	}
}
