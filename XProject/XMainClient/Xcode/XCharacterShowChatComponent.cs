using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCharacterShowChatComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XCharacterShowChatComponent.uuID;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._inited = false;
		}

		public override void Attached()
		{
			base.Attached();
		}

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

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_HomeFeasting, new XComponent.XEventHandler(this.OnFeastTimeChange));
		}

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

		private void OnChatPlayFinish(IXUITweenTool tween)
		{
			this.UnAttachChatBubble();
		}

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

		public override void OnDetachFromHost()
		{
			this.UnAttachChatBubble();
			this.UnAttachFeastCdTime();
			this.DestroyGameObjects();
			base.OnDetachFromHost();
		}

		private void DestroyGameObjects()
		{
			XResourceLoaderMgr.SafeDestroy(ref this._chatBubbleObj, true);
			XResourceLoaderMgr.SafeDestroy(ref this._gardenFeastObj, true);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CharacterShowChatComponent");

		public static string FEAST_TEMPLATE = "UI/Billboard/FeastingBill";

		public static string CHAT_TEMPLATE = "UI/Billboard/ChatbubbleBill";

		private bool _inited = false;

		private IXUILabel _homeRemainTimeLabel;

		private GameObject _gardenFeastObj;

		private GameObject _chatBubbleObj;

		private IXUITweenTool _chatTween;

		private IXUISprite _chatBg;

		private IXUILabelSymbol _chatLabelSymbol;

		private IXUILabel _chatLabel;

		private XBillboardComponent bbComp;
	}
}
