using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class CareerHomepageHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			Transform transform = base.transform.Find("BaseInfo");
			this.m_Username = (transform.Find("Username").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_Server = (transform.Find("Server").GetComponent("XUILabel") as IXUILabel);
			this.m_UID = (transform.Find("UID/T").GetComponent("XUILabel") as IXUILabel);
			this.m_Level = (transform.Find("Level/T").GetComponent("XUILabel") as IXUILabel);
			this.m_Guild = (transform.Find("Guild/T").GetComponent("XUILabel") as IXUILabel);
			this.m_Profession = (transform.Find("Occupation/T").GetComponent("XUILabel") as IXUILabel);
			this.m_ContinuousLogin = (transform.Find("ContinuousLogin/T").GetComponent("XUILabel") as IXUILabel);
			this.m_OnlineTime = (transform.Find("OnlineTime/T").GetComponent("XUILabel") as IXUILabel);
			this.m_PPT = (transform.Find("PPT/T").GetComponent("XUILabel") as IXUILabel);
			this.m_Portrait = (transform.Find("Portrait").GetComponent("XUISprite") as IXUISprite);
			this.m_SignatureSelfShow = transform.Find("Signature/SelfShow");
			this.m_SignatureChange = (transform.Find("Signature/SelfShow/Change").GetComponent("XUIButton") as IXUIButton);
			this.m_SignatureLabel = (transform.Find("Signature/Tag/T").GetComponent("XUILabel") as IXUILabel);
			this.m_QQVipIcon = transform.FindChild("QQVIP");
			this.m_QQSVipIcon = transform.FindChild("QQSVIP");
			transform = base.transform.Find("Career/Career");
			Transform transform2 = transform.Find("CourseTpl");
			this.m_CoursePool.SetupPool(null, transform2.gameObject, 10U, false);
			Transform transform3 = transform.Find("TimeTpl");
			this.m_TimePool.SetupPool(null, transform3.gameObject, 10U, false);
			Transform transform4 = transform.Find("LineTpl");
			this.m_LinePool.SetupPool(null, transform4.gameObject, 10U, false);
			this.m_Push = (base.transform.Find("Push").GetComponent("XUIButton") as IXUIButton);
			this.m_Share = (base.transform.Find("Share").GetComponent("XUIButton") as IXUIButton);
			this.InitInfo();
		}

		protected override string FileName
		{
			get
			{
				return "GameSystem/PersonalCareer/CareerHomepage";
			}
		}

		public override void RegisterEvent()
		{
			this.m_SignatureChange.RegisterClickEventHandler(new ButtonClickEventHandler(this._InputBtnClick));
			this.m_Push.RegisterClickEventHandler(new ButtonClickEventHandler(this._PushBtnClick));
			this.m_Share.RegisterClickEventHandler(new ButtonClickEventHandler(this._ShareBtnClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		private void InitInfo()
		{
			this.m_Username.InputText = "";
			this.m_Server.SetText("");
			this.m_UID.SetText("");
			this.m_Level.SetText("");
			this.m_Guild.SetText("");
			this.m_Profession.SetText("");
			this.m_ContinuousLogin.SetText("");
			this.m_OnlineTime.SetText("");
			this.m_PPT.SetText("");
			this.m_SignatureSelfShow.gameObject.SetActive(false);
			this.m_SignatureLabel.SetText("");
			this.m_QQVipIcon.gameObject.SetActive(false);
			this.m_QQSVipIcon.gameObject.SetActive(false);
		}

		public void SetData(PersonalHomePage data)
		{
			this.m_Username.InputText = XSingleton<XCommon>.singleton.StringCombine(data.play_name, XWelfareDocument.GetMemberPrivilegeIconString(data.paymember_id));
			this.m_Server.SetText(data.server_name);
			this.m_UID.SetText(data.uid.ToString());
			this.m_Level.SetText(data.level.ToString());
			bool flag = "".Equals(data.guild_name);
			if (flag)
			{
				this.m_Guild.SetText(XSingleton<XStringTable>.singleton.GetString("NONE"));
			}
			else
			{
				this.m_Guild.SetText(data.guild_name);
			}
			this.m_Portrait.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon((int)data.profession_id));
			this.m_Profession.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName((int)data.profession_id));
			this.m_ContinuousLogin.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("CAREER_CONTINUOUS_LOGIN"), data.continue_login_time.ToString()));
			float num = data.online_time / 3600f;
			string arg = (num < 10f) ? num.ToString("f1") : num.ToString("f0");
			this.m_OnlineTime.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("CAREER_ONLINE_TIME"), arg));
			this.m_PPT.SetText(((int)data.power).ToString());
			this.m_SignatureSelfShow.gameObject.SetActive(DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.roleId == 0UL);
			this.m_SignatureLabel.SetText(data.declaration);
			this.SetQQVip(data.qq_vip);
			List<CareerData> list = new List<CareerData>();
			for (int i = 0; i < data.carrer_data.Count; i++)
			{
				list.Add(data.carrer_data[i]);
			}
			list.Sort(new Comparison<CareerData>(this._CompareGrowthProcess));
			this.SetGrowthProcess(list);
			this.m_Push.gameObject.SetActive(DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.roleId == 0UL);
			this.m_Share.gameObject.SetActive(DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.roleId == 0UL);
		}

		public void SetDeclaration(string declaration)
		{
			this.m_SignatureLabel.SetText(declaration);
		}

		private void SetQQVip(uint vip)
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_QQVIP);
			if (flag)
			{
				this.m_QQVipIcon.gameObject.SetActive(vip == 1U);
				this.m_QQSVipIcon.gameObject.SetActive(vip == 2U || vip == 3U);
			}
			else
			{
				this.m_QQVipIcon.gameObject.SetActive(false);
				this.m_QQSVipIcon.gameObject.SetActive(false);
			}
		}

		private int _CompareGrowthProcess(CareerData left, CareerData right)
		{
			bool flag = left.time == right.time;
			int result;
			if (flag)
			{
				bool flag2 = left.type == right.type;
				if (flag2)
				{
					result = -left.para1.CompareTo(right.para1);
				}
				else
				{
					result = -left.type.CompareTo(right.type);
				}
			}
			else
			{
				result = -left.time.CompareTo(right.time);
			}
			return result;
		}

		private void SetGrowthProcess(List<CareerData> data)
		{
			bool flag = data.Count == 0;
			if (!flag)
			{
				int num = 0;
				int num2 = 0;
				uint num3 = 0U;
				this.m_CoursePool.FakeReturnAll();
				this.m_TimePool.FakeReturnAll();
				this.m_LinePool.FakeReturnAll();
				for (int i = 0; i < data.Count; i++)
				{
					uint time = data[i].time;
					string text = this.GrowthText(data[i]);
					bool flag2 = text == null;
					if (!flag2)
					{
						bool flag3 = time != num3;
						if (flag3)
						{
							num3 = time;
							bool flag4 = num2 - num > 0;
							if (flag4)
							{
								GameObject gameObject = this.m_LinePool.FetchGameObject(false);
								gameObject.transform.localPosition = new Vector3(0f, (float)(num2 + this.m_TimePool.TplHeight), 0f) + this.m_LinePool.TplPos;
								IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
								ixuisprite.spriteWidth = num2 - num;
							}
							GameObject gameObject2 = this.m_TimePool.FetchGameObject(false);
							gameObject2.transform.localPosition = new Vector3(0f, (float)num, 0f) + this.m_TimePool.TplPos;
							IXUILabel ixuilabel = gameObject2.transform.Find("Time").GetComponent("XUILabel") as IXUILabel;
							num -= this.m_TimePool.TplHeight;
							num2 = num;
							ixuilabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("CAREER_GROWTH_PROCESS_TIME"), time / 10000U, (time / 100U % 100U).ToString().PadLeft(2, '0'), (time % 100U).ToString().PadLeft(2, '0')));
						}
						GameObject gameObject3 = this.m_CoursePool.FetchGameObject(false);
						gameObject3.transform.localPosition = new Vector3(0f, (float)(num + this.m_TimePool.TplHeight), 0f) + this.m_CoursePool.TplPos;
						IXUILabel ixuilabel2 = gameObject3.transform.Find("T").GetComponent("XUILabel") as IXUILabel;
						ixuilabel2.SetText(text);
						IXUISprite ixuisprite2 = gameObject3.transform.Find("p").GetComponent("XUISprite") as IXUISprite;
						ixuisprite2.UpdateAnchors();
						num -= ixuisprite2.spriteHeight;
					}
				}
				this.m_LinePool.ActualReturnAll(false);
				this.m_TimePool.ActualReturnAll(false);
				this.m_CoursePool.ActualReturnAll(false);
			}
		}

		private string GrowthText(CareerData data)
		{
			bool flag = data == null;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				string text;
				switch (data.type)
				{
				case CarrerDataType.CARRER_DATA_LEVEL:
					text = string.Format(XSingleton<XStringTable>.singleton.GetString("CAREER_GROWTH_PROCESS_LEVEL"), data.para1);
					break;
				case CarrerDataType.CARRER_DATA_NEST:
				{
					SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(data.para1);
					bool flag2 = sceneData == null;
					if (flag2)
					{
						return null;
					}
					text = string.Format(XSingleton<XStringTable>.singleton.GetString("CAREER_GROWTH_PROCESS_NEST"), sceneData.Comment);
					break;
				}
				case CarrerDataType.CARRER_DATA_DRAGON:
				{
					SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(data.para1);
					bool flag3 = sceneData == null;
					if (flag3)
					{
						return null;
					}
					text = string.Format(XSingleton<XStringTable>.singleton.GetString("CAREER_GROWTH_PROCESS_DRAGON"), sceneData.Comment);
					break;
				}
				case CarrerDataType.CARRER_DATA_CREATEROLE:
					text = XSingleton<XStringTable>.singleton.GetString("CAREER_GROWTH_PROCESS_BORN");
					break;
				default:
					return null;
				}
				result = text;
			}
			return result;
		}

		private bool _PushBtnClick(IXUIButton btn)
		{
			DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.PushClick(0UL);
			return true;
		}

		private bool _ShareBtnClick(IXUIButton btn)
		{
			DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.ShareClick();
			return true;
		}

		private void test()
		{
			this.SetGrowthProcess(new List<CareerData>
			{
				new CareerData
				{
					time = 1U,
					type = CarrerDataType.CARRER_DATA_LEVEL,
					para1 = 10U
				},
				new CareerData
				{
					time = 2U,
					type = CarrerDataType.CARRER_DATA_NEST,
					para1 = 1U
				},
				new CareerData
				{
					time = 2U,
					type = CarrerDataType.CARRER_DATA_DRAGON,
					para1 = 2U
				},
				new CareerData
				{
					time = 4U,
					type = CarrerDataType.CARRER_DATA_CREATEROLE,
					para1 = 2U
				}
			});
		}

		private bool _InputBtnClick(IXUIButton btn)
		{
			DlgBase<XChatInputView, XChatInputBehaviour>.singleton.ShowChatInput(new ChatInputStringBack(this.ReqSetDeclaration));
			DlgBase<XChatInputView, XChatInputBehaviour>.singleton.SetInputType(ChatInputType.TEXT);
			DlgBase<XChatInputView, XChatInputBehaviour>.singleton.SetCharacterLimit(40);
			return true;
		}

		public void ReqSetDeclaration(string str)
		{
			RpcC2G_ChangeDeclaration rpcC2G_ChangeDeclaration = new RpcC2G_ChangeDeclaration();
			rpcC2G_ChangeDeclaration.oArg.declaration = str;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChangeDeclaration);
		}

		private IXUILabelSymbol m_Username;

		private IXUILabel m_UID;

		private IXUILabel m_Level;

		private IXUILabel m_Server;

		private IXUILabel m_Guild;

		private IXUILabel m_Profession;

		private IXUILabel m_ContinuousLogin;

		private IXUILabel m_OnlineTime;

		private IXUILabel m_PPT;

		private IXUISprite m_Portrait;

		private Transform m_SignatureSelfShow;

		private IXUIButton m_SignatureChange;

		private IXUILabel m_SignatureLabel;

		private Transform m_QQVipIcon;

		private Transform m_QQSVipIcon;

		private IXUIButton m_Push;

		private IXUIButton m_Share;

		private XUIPool m_CoursePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_TimePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_LinePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public enum GrowthType
		{

			NONE,

			Level,

			Nest,

			Dragon
		}
	}
}
