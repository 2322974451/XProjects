using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FE4 RID: 4068
	internal class XCharacterShowChatComponent : XComponent
	{
		// Token: 0x170036E8 RID: 14056
		// (get) Token: 0x0600D37D RID: 54141 RVA: 0x0031AE78 File Offset: 0x00319078
		public override uint ID
		{
			get
			{
				return XCharacterShowChatComponent.uuID;
			}
		}

		// Token: 0x0600D37E RID: 54142 RVA: 0x0031AE8F File Offset: 0x0031908F
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._inited = false;
		}

		// Token: 0x0600D37F RID: 54143 RVA: 0x0031AEA1 File Offset: 0x003190A1
		public override void Attached()
		{
			base.Attached();
		}

		// Token: 0x0600D380 RID: 54144 RVA: 0x0031AEAC File Offset: 0x003190AC
		private void Init()
		{
			this._gardenFeastObj = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(XCharacterShowChatComponent.FEAST_TEMPLATE, this._entity.EngineObject.Position, this._entity.EngineObject.Rotation, true, false);
			this._chatBubbleObj = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(XCharacterShowChatComponent.CHAT_TEMPLATE, this._entity.EngineObject.Position, this._entity.EngineObject.Rotation, true, false);
			this._homeRemainTimeLabel = (this._gardenFeastObj.GetComponent("XUILabel") as IXUILabel);
			this._homeRemainTimeLabel.gameObject.SetActive(false);
			this._chatLabelSymbol = (this._chatBubbleObj.transform.FindChild("Content/text").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this._chatLabel = (this._chatBubbleObj.transform.FindChild("Content/text").GetComponent("XUILabel") as IXUILabel);
			this._chatTween = (this._chatBubbleObj.GetComponent("XUIPlayTween") as IXUITweenTool);
			this._chatBg = (this._chatBubbleObj.transform.FindChild("Content/p").GetComponent("XUISprite") as IXUISprite);
			this._gardenFeastObj.gameObject.SetActive(false);
			this._chatBubbleObj.gameObject.SetActive(false);
			this._inited = true;
		}

		// Token: 0x0600D381 RID: 54145 RVA: 0x0031B019 File Offset: 0x00319219
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_HomeFeasting, new XComponent.XEventHandler(this.OnFeastTimeChange));
		}

		// Token: 0x0600D382 RID: 54146 RVA: 0x0031B034 File Offset: 0x00319234
		public override void PostUpdate(float fDeltaT)
		{
			bool flag = !this._inited;
			if (!flag)
			{
				bool flag2 = Time.frameCount % 15 == 0;
				if (flag2)
				{
					float dis = Vector3.Distance(XSingleton<XScene>.singleton.GameCamera.UnityCamera.transform.position, this._chatBubbleObj.transform.position);
					bool flag3 = this._entity != null;
					if (flag3)
					{
						this.SetBoardDepth(this._entity.IsPlayer, dis);
					}
				}
				XEntity xentity = this._host as XEntity;
				XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
				bool flag4 = xentity == null || player == null || this.bbComp == null;
				if (!flag4)
				{
					float num = Vector3.Distance(xentity.EngineObject.Position, player.EngineObject.Position);
					bool flag5 = num > this.bbComp.viewDistance;
					if (flag5)
					{
						bool flag6 = !this.bbComp.alwaysShow;
						if (flag6)
						{
							this._chatTween.ResetTween(false);
						}
					}
				}
			}
		}

		// Token: 0x0600D383 RID: 54147 RVA: 0x0031B144 File Offset: 0x00319344
		private bool OnFeastTimeChange(XEventArgs e)
		{
			bool flag = !this._inited;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XEvent_HomeFeastingArgs xevent_HomeFeastingArgs = e as XEvent_HomeFeastingArgs;
				SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
				bool flag2 = sceneType == SceneType.SCENE_FAMILYGARDEN;
				if (flag2)
				{
					bool flag3 = xevent_HomeFeastingArgs.time < 1U;
					if (flag3)
					{
						this.UnAttachFeastCdTime();
						this._homeRemainTimeLabel.gameObject.SetActive(false);
					}
					else
					{
						this._homeRemainTimeLabel.gameObject.SetActive(true);
						string @string = XSingleton<XStringTable>.singleton.GetString("HomeFeasting");
						uint num = xevent_HomeFeastingArgs.time / 60U;
						uint num2 = xevent_HomeFeastingArgs.time - 60U * num;
						this._homeRemainTimeLabel.SetText(string.Concat(new object[]
						{
							@string,
							"\n",
							num,
							":",
							num2
						}));
					}
				}
				else
				{
					this.UnAttachFeastCdTime();
					this._homeRemainTimeLabel.gameObject.SetActive(false);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600D384 RID: 54148 RVA: 0x0031B254 File Offset: 0x00319454
		public void AttachChatBubble()
		{
			bool flag = !this._inited;
			if (flag)
			{
				this.Init();
			}
			this.bbComp = this._entity.BillBoard;
			bool flag2 = this.bbComp != null;
			if (flag2)
			{
				bool flag3 = this.bbComp.AttachChild(this._chatBubbleObj.transform, false, 60f);
				if (flag3)
				{
					this._chatBubbleObj.SetActive(true);
				}
				bool flag4 = this._chatTween != null;
				if (flag4)
				{
					this._chatTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnChatPlayFinish));
				}
			}
		}

		// Token: 0x0600D385 RID: 54149 RVA: 0x0031B2E8 File Offset: 0x003194E8
		private void OnChatPlayFinish(IXUITweenTool tween)
		{
			this.UnAttachChatBubble();
		}

		// Token: 0x0600D386 RID: 54150 RVA: 0x0031B2F4 File Offset: 0x003194F4
		public void UnAttachChatBubble()
		{
			bool flag = !this._inited;
			if (!flag)
			{
				XBillboardComponent billBoard = this._entity.BillBoard;
				bool flag2 = billBoard != null;
				if (flag2)
				{
					bool flag3 = billBoard.UnAttachChild(this._chatBubbleObj.transform);
					if (flag3)
					{
						this._chatBubbleObj.SetActive(false);
					}
				}
			}
		}

		// Token: 0x0600D387 RID: 54151 RVA: 0x0031B34C File Offset: 0x0031954C
		public void DealWithChat(string content)
		{
			bool flag = !this._inited;
			if (!flag)
			{
				bool flag2 = !XEntity.ValideEntity(this._entity);
				if (!flag2)
				{
					bool flag3 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
					if (flag3)
					{
						bool flag4 = this._chatTween != null && this._chatLabelSymbol != null && this._chatBubbleObj != null;
						if (flag4)
						{
							this._chatTween.ResetTween(true);
							this._chatTween.PlayTween(true, -1f);
							string text = "";
							string text2 = "";
							bool isPlayer = this._entity.IsPlayer;
							if (isPlayer)
							{
								XPrerogativeDocument specificDocument = XDocuments.GetSpecificDocument<XPrerogativeDocument>(XPrerogativeDocument.uuID);
								text = specificDocument.GetPreContent(PrerogativeType.PreChatBubble);
							}
							else
							{
								bool isRole = this._entity.IsRole;
								if (isRole)
								{
									XRoleAttributes xroleAttributes = this._entity.Attributes as XRoleAttributes;
									text = XPrerogativeDocument.ConvertTypeToPreContent(PrerogativeType.PreChatBubble, xroleAttributes.PrerogativeSetID);
								}
							}
							bool flag5 = !string.IsNullOrEmpty(text);
							if (flag5)
							{
								string[] array = text.Split(new char[]
								{
									'='
								});
								bool flag6 = array.Length == 3;
								if (flag6)
								{
									this._chatBg.SetSprite(array[1], array[0], false);
									text2 = array[2];
								}
							}
							bool flag7 = string.IsNullOrEmpty(text2);
							if (flag7)
							{
								this._chatLabelSymbol.InputText = DlgBase<ChatEmotionView, ChatEmotionBehaviour>.singleton.OnParseEmotion(content);
							}
							else
							{
								this._chatLabelSymbol.InputText = string.Format("[c][{0}]{1}[/c]", text2, DlgBase<ChatEmotionView, ChatEmotionBehaviour>.singleton.OnParseEmotion(content));
							}
							this._chatBg.spriteHeight = this._chatLabel.spriteHeight + 30;
							int num = content.Length * (2 + this._chatLabel.fontSize);
							this._chatBg.spriteWidth = Mathf.Min(this._chatLabel.spriteWidth, num) + 48;
						}
					}
				}
			}
		}

		// Token: 0x0600D388 RID: 54152 RVA: 0x0031B53C File Offset: 0x0031973C
		public void AttachFeastCdTime()
		{
			bool flag = !this._inited;
			if (flag)
			{
				this.Init();
			}
			XBillboardComponent billBoard = this._entity.BillBoard;
			bool flag2 = billBoard != null;
			if (flag2)
			{
				this._gardenFeastObj.transform.parent = null;
				bool flag3 = billBoard.AttachChild(this._gardenFeastObj.transform, true, 45f);
				if (flag3)
				{
					this._gardenFeastObj.SetActive(true);
				}
			}
		}

		// Token: 0x0600D389 RID: 54153 RVA: 0x0031B5B0 File Offset: 0x003197B0
		public void UnAttachFeastCdTime()
		{
			bool flag = !this._inited;
			if (!flag)
			{
				XBillboardComponent billBoard = this._entity.BillBoard;
				bool flag2 = billBoard != null;
				if (flag2)
				{
					bool flag3 = billBoard.UnAttachChild(this._gardenFeastObj.transform);
					if (flag3)
					{
						this._gardenFeastObj.SetActive(false);
					}
				}
			}
		}

		// Token: 0x0600D38A RID: 54154 RVA: 0x0031B605 File Offset: 0x00319805
		public override void OnDetachFromHost()
		{
			this.UnAttachChatBubble();
			this.UnAttachFeastCdTime();
			this.DestroyGameObjects();
			base.OnDetachFromHost();
		}

		// Token: 0x0600D38B RID: 54155 RVA: 0x0031B624 File Offset: 0x00319824
		private void DestroyGameObjects()
		{
			XResourceLoaderMgr.SafeDestroy(ref this._chatBubbleObj, true);
			XResourceLoaderMgr.SafeDestroy(ref this._gardenFeastObj, true);
		}

		// Token: 0x0600D38C RID: 54156 RVA: 0x0031B644 File Offset: 0x00319844
		private void SetBoardDepth(bool isMy, float dis = 0f)
		{
			int num = isMy ? 10 : (-(int)(dis * 100f));
			bool flag = this._chatBg != null && this._chatLabel != null;
			if (flag)
			{
				this._chatBg.spriteDepth = num + 1;
				this._chatLabel.spriteDepth = num + 2;
				this._chatLabelSymbol.UpdateDepth(num + 2);
			}
		}

		// Token: 0x0400601C RID: 24604
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CharacterShowChatComponent");

		// Token: 0x0400601D RID: 24605
		public static string FEAST_TEMPLATE = "UI/Billboard/FeastingBill";

		// Token: 0x0400601E RID: 24606
		public static string CHAT_TEMPLATE = "UI/Billboard/ChatbubbleBill";

		// Token: 0x0400601F RID: 24607
		private bool _inited = false;

		// Token: 0x04006020 RID: 24608
		private IXUILabel _homeRemainTimeLabel;

		// Token: 0x04006021 RID: 24609
		private GameObject _gardenFeastObj;

		// Token: 0x04006022 RID: 24610
		private GameObject _chatBubbleObj;

		// Token: 0x04006023 RID: 24611
		private IXUITweenTool _chatTween;

		// Token: 0x04006024 RID: 24612
		private IXUISprite _chatBg;

		// Token: 0x04006025 RID: 24613
		private IXUILabelSymbol _chatLabelSymbol;

		// Token: 0x04006026 RID: 24614
		private IXUILabel _chatLabel;

		// Token: 0x04006027 RID: 24615
		private XBillboardComponent bbComp;
	}
}
