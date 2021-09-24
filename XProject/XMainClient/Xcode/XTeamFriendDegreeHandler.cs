using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamFriendDegreeHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_FriendLevel = (base.PanelObject.transform.FindChild("FriendLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_FriendTitle = (base.PanelObject.transform.FindChild("FriendTitle").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnAdd = (base.PanelObject.transform.FindChild("BtnAdd").GetComponent("XUISprite") as IXUISprite);
			this.m_BtnBuff = (base.PanelObject.transform.FindChild("BtnBuff").GetComponent("XUISprite") as IXUISprite);
			this.m_InfoPanel = base.PanelObject.transform.FindChild("InfoPanel").gameObject;
			this.m_InfoClose = (this.m_InfoPanel.transform.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_InfoMiddleFrame = (this.m_InfoPanel.transform.FindChild("MiddleFrame").GetComponent("XUISprite") as IXUISprite);
			Transform transform = this.m_InfoMiddleFrame.gameObject.transform.FindChild("Attr");
			this.m_AttrPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			transform = this.m_InfoPanel.transform.FindChild("TopFrame");
			this.m_InfoTopFrameFriendLevel = (transform.FindChild("FriendLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_InfoTopFrameMe = transform.FindChild("Me").gameObject;
			transform = this.m_InfoPanel.transform.FindChild("BottomFrame");
			this.m_InfoBottomFrameMe = transform.FindChild("Me").gameObject;
			this.m_InfoBottomFrameFriend = (transform.FindChild("Friend").GetComponent("XUILabel") as IXUILabel);
			this._FriendsView = DlgBase<XFriendsView, XFriendsBehaviour>.singleton;
			this._TeamDoc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this._FriendsDoc = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_InfoClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseClicked));
			this.m_BtnBuff.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnBuffClicked));
			this.m_BtnAdd.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnAddFriendClicked));
		}

		private void _OnCloseClicked(IXUISprite iSp)
		{
			this.m_InfoPanel.SetActive(false);
		}

		private void _OnBuffClicked(IXUISprite iSp)
		{
			this.m_InfoPanel.SetActive(true);
			XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
			bool flag = player.ID == this.m_CurrentUID;
			bool flag2 = flag;
			if (flag2)
			{
				this._RefreshMyInfoPanel(this.m_CurrentUID);
			}
			else
			{
				XFriendData friendDataById = this._FriendsView.GetFriendDataById(this.m_CurrentUID);
				bool flag3 = friendDataById == null;
				if (flag3)
				{
					this.m_InfoPanel.SetActive(false);
				}
				else
				{
					FriendTable.RowData friendLevelData = this._FriendsDoc.GetFriendLevelData(friendDataById.degreeAll);
					this._RefreshFriendInfoPanel(friendDataById, friendLevelData);
				}
			}
		}

		private void _OnAddFriendClicked(IXUISprite iSp)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(this.m_CurrentUID);
		}

		public void Refresh(XTeamMember data, bool bActive, int teamMemberIndex)
		{
			bool flag = data != null && bActive;
			if (flag)
			{
				base.SetVisible(true);
				this.m_TeamMemberIndex = teamMemberIndex;
				bool flag2 = this.m_CurrentUID != data.uid;
				if (flag2)
				{
					this.m_InfoPanel.SetActive(false);
					this.m_CurrentUID = data.uid;
				}
				XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
				bool flag3 = player.ID == data.uid;
				bool flag4 = flag3;
				if (flag4)
				{
					this.m_BtnAdd.SetVisible(false);
					this.m_BtnBuff.SetVisible(true);
					this.m_FriendLevel.SetVisible(false);
					this.m_FriendTitle.SetVisible(false);
					bool activeSelf = this.m_InfoPanel.activeSelf;
					if (activeSelf)
					{
						this._RefreshMyInfoPanel(data.uid);
					}
				}
				else
				{
					XFriendData friendDataById = this._FriendsView.GetFriendDataById(data.uid);
					bool flag5 = friendDataById != null;
					this.m_BtnAdd.SetVisible(!flag5 && !data.bIsRobot);
					this.m_BtnBuff.SetVisible(flag5);
					this.m_FriendLevel.SetVisible(flag5);
					this.m_FriendTitle.SetVisible(flag5);
					bool flag6 = !flag5;
					if (flag6)
					{
						this.m_InfoPanel.SetActive(false);
					}
					else
					{
						this.m_FriendLevel.SetText(friendDataById.degreeAll.ToString());
						FriendTable.RowData friendLevelData = this._FriendsDoc.GetFriendLevelData(friendDataById.degreeAll);
						bool flag7 = friendLevelData != null;
						if (flag7)
						{
							this.m_FriendTitle.SetText(friendLevelData.teamname);
						}
						else
						{
							this.m_FriendTitle.SetText("");
						}
						bool activeSelf2 = this.m_InfoPanel.activeSelf;
						if (activeSelf2)
						{
							this._RefreshFriendInfoPanel(friendDataById, friendLevelData);
						}
					}
				}
			}
			else
			{
				base.SetVisible(false);
			}
		}

		private void _AppendAttr(List<XTeamFriendDegreeHandler.XPercentAttr> attrs, XTeamFriendDegreeHandler.XPercentAttr newAttr)
		{
			int i;
			for (i = 0; i < attrs.Count; i++)
			{
				bool flag = attrs[i].AttrID == newAttr.AttrID;
				if (flag)
				{
					newAttr.Scale += attrs[i].Scale;
					attrs[i] = newAttr;
					break;
				}
			}
			bool flag2 = i == attrs.Count;
			if (flag2)
			{
				attrs.Add(newAttr);
			}
		}

		private void _SetAttr(XTeamFriendDegreeHandler.XPercentAttr attr, GameObject go)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
			bool flag = attr.AttrID == 0U;
			if (flag)
			{
				ixuilabel.SetText(XStringDefineProxy.GetString("NONE"));
				ixuilabel2.SetText("");
			}
			else
			{
				XAttributeDefine attrID = (XAttributeDefine)attr.AttrID;
				ixuilabel.SetText(XStringDefineProxy.GetString(attrID.ToString()));
				ixuilabel2.SetText(XAttributeCommon.GetAttrValueStr((int)attr.AttrID, (float)attr.Scale));
			}
		}

		private void _RefreshMyInfoPanel(ulong myUID)
		{
			this.m_InfoBottomFrameMe.SetActive(true);
			this.m_InfoBottomFrameFriend.SetVisible(false);
			this.m_InfoTopFrameMe.SetActive(true);
			this.m_InfoTopFrameFriendLevel.SetVisible(false);
			List<XTeamFriendDegreeHandler.XPercentAttr> list = new List<XTeamFriendDegreeHandler.XPercentAttr>();
			bool flag = this._TeamDoc.MyTeam != null;
			if (flag)
			{
				List<XTeamMember> members = this._TeamDoc.MyTeam.members;
				for (int i = 0; i < members.Count; i++)
				{
					bool flag2 = members[i].uid == myUID;
					if (!flag2)
					{
						XFriendData friendDataById = this._FriendsView.GetFriendDataById(members[i].uid);
						bool flag3 = friendDataById == null;
						if (!flag3)
						{
							FriendTable.RowData friendLevelData = this._FriendsDoc.GetFriendLevelData(friendDataById.degreeAll);
							bool flag4 = friendLevelData == null;
							if (!flag4)
							{
								BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)friendLevelData.buf[0], (int)friendLevelData.buf[1]);
								bool flag5 = buffData == null;
								if (flag5)
								{
									XSingleton<XDebug>.singleton.AddErrorLog("buffData == null", null, null, null, null, null);
								}
								else
								{
									for (int j = 0; j < buffData.BuffChangeAttribute.Count; j++)
									{
										XTeamFriendDegreeHandler.XPercentAttr newAttr = XTeamFriendDegreeHandler.XPercentAttr.CreateFromTableData(buffData.BuffChangeAttribute[j, 0], buffData.BuffChangeAttribute[j, 1]);
										this._AppendAttr(list, newAttr);
									}
								}
							}
						}
					}
				}
			}
			this.m_AttrPool.FakeReturnAll();
			bool flag6 = list.Count == 0;
			if (flag6)
			{
				XTeamFriendDegreeHandler.XPercentAttr attr = default(XTeamFriendDegreeHandler.XPercentAttr);
				GameObject gameObject = this.m_AttrPool.FetchGameObject(false);
				gameObject.transform.localPosition = this.m_AttrPool.TplPos;
				this._SetAttr(attr, gameObject);
				this.m_InfoMiddleFrame.spriteHeight = this.m_AttrPool.TplHeight;
			}
			else
			{
				for (int k = 0; k < list.Count; k++)
				{
					XTeamFriendDegreeHandler.XPercentAttr attr2 = list[list.Count - k - 1];
					GameObject gameObject2 = this.m_AttrPool.FetchGameObject(false);
					gameObject2.transform.localPosition = new Vector3(this.m_AttrPool.TplPos.x, this.m_AttrPool.TplPos.y + (float)(this.m_AttrPool.TplHeight * k), this.m_AttrPool.TplPos.z);
					this._SetAttr(attr2, gameObject2);
				}
				this.m_InfoMiddleFrame.spriteHeight = list.Count * this.m_AttrPool.TplHeight;
			}
			this.m_AttrPool.ActualReturnAll(false);
		}

		private void _RefreshFriendInfoPanel(XFriendData friendData, FriendTable.RowData rowData)
		{
			this.m_InfoBottomFrameMe.SetActive(false);
			this.m_InfoBottomFrameFriend.SetVisible(true);
			this.m_InfoTopFrameMe.SetActive(false);
			this.m_InfoTopFrameFriendLevel.SetVisible(true);
			bool flag = friendData == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("friendData == null", null, null, null, null, null);
			}
			else
			{
				uint degreeAll = friendData.degreeAll;
				this.m_AttrPool.FakeReturnAll();
				bool flag2 = rowData == null;
				if (flag2)
				{
					XTeamFriendDegreeHandler.XPercentAttr attr = default(XTeamFriendDegreeHandler.XPercentAttr);
					GameObject gameObject = this.m_AttrPool.FetchGameObject(false);
					gameObject.transform.localPosition = this.m_AttrPool.TplPos;
					this._SetAttr(attr, gameObject);
					this.m_InfoMiddleFrame.spriteHeight = this.m_AttrPool.TplHeight;
				}
				else
				{
					BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)rowData.buf[0], (int)rowData.buf[1]);
					bool flag3 = buffData == null;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("buffData == null", null, null, null, null, null);
						return;
					}
					int i = 0;
					int count = buffData.BuffChangeAttribute.Count;
					while (i < count)
					{
						int index = count - i - 1;
						XTeamFriendDegreeHandler.XPercentAttr attr2 = XTeamFriendDegreeHandler.XPercentAttr.CreateFromTableData(buffData.BuffChangeAttribute[index, 0], buffData.BuffChangeAttribute[index, 1]);
						GameObject gameObject2 = this.m_AttrPool.FetchGameObject(false);
						gameObject2.transform.localPosition = new Vector3(this.m_AttrPool.TplPos.x, this.m_AttrPool.TplPos.y + (float)(this.m_AttrPool.TplHeight * i), this.m_AttrPool.TplPos.z);
						this._SetAttr(attr2, gameObject2);
						i++;
					}
					this.m_InfoMiddleFrame.spriteHeight = buffData.BuffChangeAttribute.Count * this.m_AttrPool.TplHeight;
				}
				this.m_AttrPool.ActualReturnAll(false);
				this.m_InfoTopFrameFriendLevel.SetText(degreeAll.ToString());
				this.m_InfoBottomFrameFriend.SetText("");
				foreach (FriendTable.RowData rowData2 in this._FriendsDoc.GetFriendLevelDatas())
				{
					bool flag4 = rowData2.level > degreeAll && rowData2.dropid > 0U;
					if (flag4)
					{
						this.m_InfoBottomFrameFriend.SetText(XStringDefineProxy.GetString("FRIEND_DEGREE_GIFT_FORENOTICE", new object[]
						{
							(rowData2.level - degreeAll).ToString(),
							rowData2.level.ToString()
						}));
						break;
					}
				}
			}
		}

		private IXUILabel m_FriendLevel;

		private IXUILabel m_FriendTitle;

		private IXUISprite m_BtnAdd;

		private IXUISprite m_BtnBuff;

		private GameObject m_InfoPanel;

		private IXUISprite m_InfoClose;

		private IXUISprite m_InfoMiddleFrame;

		private IXUILabel m_InfoTopFrameFriendLevel;

		private GameObject m_InfoTopFrameMe;

		private IXUILabel m_InfoBottomFrameFriend;

		private GameObject m_InfoBottomFrameMe;

		private XUIPool m_AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XFriendsView _FriendsView;

		private XFriendsDocument _FriendsDoc;

		private XTeamDocument _TeamDoc;

		private int m_TeamMemberIndex = 0;

		private ulong m_CurrentUID = 0UL;

		private struct XPercentAttr
		{

			public static XTeamFriendDegreeHandler.XPercentAttr CreateFromTableData(float data0, float data1)
			{
				XTeamFriendDegreeHandler.XPercentAttr result;
				result.AttrID = (uint)data0;
				result.Scale = (double)data1;
				return result;
			}

			public uint AttrID;

			public double Scale;
		}
	}
}
