using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XOutlookHelper
	{

		public static void SetOutLookReplace(XAttributes attributes, XEntity entity, OutLook outlookData)
		{
			bool flag = outlookData == null;
			if (!flag)
			{
				XOutlookHelper.SetFashion(attributes, entity, outlookData);
				XOutlookHelper.SetDesignation(attributes, entity, outlookData);
				XOutlookHelper.SetPrerogative(attributes, entity, outlookData);
				XOutlookHelper.SetMilitaryRank(attributes, entity, outlookData);
				XOutlookHelper.SetTitle(attributes, entity, outlookData);
				XOutlookHelper.SetGuildInfo(attributes, entity, outlookData);
				XOutlookHelper.SetSprite(attributes, entity, outlookData);
				XOutlookHelper.SetStatusState(attributes, entity, outlookData.state, false);
			}
		}

		private static void SetFashion(XAttributes attributes, XEntity entity, OutLook outlookData)
		{
			bool flag = entity != null && outlookData.display_fashion != null;
			if (flag)
			{
				attributes.Outlook.SetData(outlookData, attributes.Outlook.GetProfType());
				XEquipComponent xequipComponent = entity.GetXComponent(XEquipComponent.uuID) as XEquipComponent;
				bool flag2 = xequipComponent != null;
				if (flag2)
				{
					xequipComponent.EquipFromAttr();
				}
			}
		}

		private static void SetGuildInfo(XAttributes attributes, XEntity entity, OutLook outLookData)
		{
			bool flag = entity != null && !entity.IsPlayer && outLookData.guild != null;
			if (flag)
			{
				XRoleAttributes xroleAttributes = attributes as XRoleAttributes;
				xroleAttributes.GuildID = outLookData.guild.id;
				xroleAttributes.GuildName = outLookData.guild.name;
				xroleAttributes.GuildPortrait = outLookData.guild.icon;
				XGuildInfoChange @event = XEventPool<XGuildInfoChange>.GetEvent();
				@event.Firer = entity;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		public static void SetOutLook(XAttributes attributes, OutLook outLook, bool bInit = false)
		{
			bool flag = outLook == null;
			if (!flag)
			{
				attributes.Outlook.SetData(outLook, attributes.TypeID);
				XOutlookHelper.SetSprite(attributes, null, outLook);
				XOutlookHelper.SetStatusState(attributes, null, outLook.state, bInit);
			}
		}

		private static void SetDesignation(XAttributes attributes, XEntity entity, OutLook outlookData)
		{
			bool flag = outlookData.designation != null;
			if (flag)
			{
				bool flag2 = entity != null && entity.BillBoard != null;
				if (flag2)
				{
					XRoleAttributes xroleAttributes = entity.Attributes as XRoleAttributes;
					xroleAttributes.DesignationID = outlookData.designation.id;
					xroleAttributes.SpecialDesignation = outlookData.designation.name;
					entity.BillBoard.OnDesignationInfoChange(null);
				}
			}
		}

		private static void SetPrerogative(XAttributes attributes, XEntity entity, OutLook outlookData)
		{
			bool flag = outlookData.pre != null;
			if (flag)
			{
				bool flag2 = entity != null && entity.BillBoard != null;
				if (flag2)
				{
					XRoleAttributes xroleAttributes = entity.Attributes as XRoleAttributes;
					xroleAttributes.PrerogativeSetID = outlookData.pre.setid;
					xroleAttributes.PrerogativeScore = outlookData.pre.score;
					entity.BillBoard.OnTitleNameChange(null);
				}
			}
		}

		private static void SetTitle(XAttributes attributes, XEntity entity, OutLook outlookData)
		{
			bool flag = outlookData.title != null;
			if (flag)
			{
				bool flag2 = entity != null && entity.BillBoard != null;
				if (flag2)
				{
					XRoleAttributes xroleAttributes = entity.Attributes as XRoleAttributes;
					xroleAttributes.TitleID = outlookData.title.titleID;
					entity.BillBoard.OnTitleNameChange(null);
				}
			}
		}

		private static void SetMilitaryRank(XAttributes attributes, XEntity entity, OutLook outlookData)
		{
			bool flag = outlookData.military != null;
			if (flag)
			{
				bool flag2 = entity != null && entity.BillBoard != null;
				if (flag2)
				{
					XRoleAttributes xroleAttributes = entity.Attributes as XRoleAttributes;
					xroleAttributes.MilitaryRank = outlookData.military.military_rank;
					entity.BillBoard.OnTitleNameChange(null);
				}
			}
		}

		private static void SetEnhancemaster(XAttributes attributes, XEntity entity, OutLook outlookData)
		{
			bool flag = attributes == null || entity == null || outlookData.equips == null;
			if (flag)
			{
			}
		}

		private static void SetSprite(XAttributes attributes, XEntity entity, OutLook outlookData)
		{
			bool flag = outlookData.sprite != null && attributes.Outlook.SetSpriteData(outlookData);
			if (flag)
			{
				bool flag2 = entity != null;
				if (flag2)
				{
					XEquipComponent xequipComponent = entity.GetXComponent(XEquipComponent.uuID) as XEquipComponent;
					bool flag3 = xequipComponent != null;
					if (flag3)
					{
						bool flag4 = attributes.Outlook.sprite.leaderid == 0U;
						if (flag4)
						{
							xequipComponent.AttachSprite(false, 0U);
						}
						else
						{
							XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
							SpriteTable.RowData bySpriteID = specificDocument._SpriteTable.GetBySpriteID(attributes.Outlook.sprite.leaderid);
							bool flag5 = bySpriteID == null;
							if (flag5)
							{
								XSingleton<XDebug>.singleton.AddErrorLog("Can't find sprite ID = ", attributes.Outlook.sprite.leaderid.ToString(), " from sprite table.", null, null, null);
							}
							else
							{
								xequipComponent.AttachSprite(true, bySpriteID.PresentID);
							}
						}
					}
				}
			}
		}

		public static void SetStatusState(XAttributes attributes, XEntity entity, OutLookState outlookStateData, bool bInit)
		{
			bool flag = outlookStateData == null;
			if (!flag)
			{
				bool flag2 = attributes.Outlook.state.type != outlookStateData.statetype || attributes.Outlook.state.param != outlookStateData.param || bInit;
				if (flag2)
				{
					bool flag3 = false;
					OutLookStateType type = attributes.Outlook.state.type;
					XRole xrole = entity as XRole;
					bool flag4 = xrole == null;
					if (flag4)
					{
						attributes.Outlook.state.type = outlookStateData.statetype;
						attributes.Outlook.state.param = outlookStateData.param;
						attributes.Outlook.state.paramother = outlookStateData.paramother;
					}
					else
					{
						switch (type)
						{
						case OutLookStateType.OutLook_Dance:
							XDanceDocument.OnDance(false, entity, attributes.Outlook.state.param);
							break;
						case OutLookStateType.OutLook_RidePet:
							flag3 = true;
							XPetDocument.TryMount(false, entity, 0U, false);
							break;
						case OutLookStateType.OutLook_Inherit:
							XGuildInheritDocument.TryOutInherit(entity);
							break;
						case OutLookStateType.OutLook_Fish:
							XHomeFishingDocument.OnFishingStateStop(outlookStateData.statetype, entity);
							break;
						case OutLookStateType.OutLook_RidePetCopilot:
							flag3 = true;
							XPetDocument.TryMountCopilot(false, entity, null, false);
							break;
						case OutLookStateType.OutLook_Trans:
							XTransformDocument.OnTransform(false, entity, bInit, outlookStateData.statetype == OutLookStateType.OutLook_Trans);
							break;
						}
						attributes.Outlook.state.type = outlookStateData.statetype;
						attributes.Outlook.state.param = outlookStateData.param;
						attributes.Outlook.state.paramother = outlookStateData.paramother;
						switch (outlookStateData.statetype)
						{
						case OutLookStateType.OutLook_Normal:
							xrole.PlayStateBack();
							break;
						case OutLookStateType.OutLook_Sit:
						{
							XHomeFishingDocument specificDocument = XDocuments.GetSpecificDocument<XHomeFishingDocument>(XHomeFishingDocument.uuID);
							bool isFishing = specificDocument.IsFishing;
							if (isFishing)
							{
								specificDocument.ServerStopFishing = true;
								specificDocument.FishList.Clear();
								specificDocument.ErrorLeaveFishing();
							}
							xrole.PlaySpecifiedAnimation(XHomeCookAndPartyDocument.Doc.GetHomeFeastAction(xrole.Attributes.BasicTypeID % 10U));
							break;
						}
						case OutLookStateType.OutLook_Dance:
							xrole.PlaySpecifiedAnimation(XDanceDocument.Doc.GetDanceAction(entity.PresentID, outlookStateData.param));
							XDanceDocument.OnDance(true, entity, outlookStateData.param);
							break;
						case OutLookStateType.OutLook_RidePet:
							flag3 = true;
							XPetDocument.TryMount(true, entity, outlookStateData.param, bInit);
							break;
						case OutLookStateType.OutLook_Inherit:
							XGuildInheritDocument.TryInInherit(entity);
							break;
						case OutLookStateType.OutLook_Fish:
						{
							bool flag5 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null && xrole.Attributes.RoleID != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
							if (flag5)
							{
								XSingleton<XDebug>.singleton.AddGreenLog("get fishing event.", null, null, null, null, null);
								XFishingComponent xfishingComponent = xrole.GetXComponent(XFishingComponent.uuID) as XFishingComponent;
								bool flag6 = xfishingComponent == null;
								if (flag6)
								{
									xfishingComponent = (XSingleton<XComponentMgr>.singleton.CreateComponent(xrole, XFishingComponent.uuID) as XFishingComponent);
									xfishingComponent.Attached();
								}
								xfishingComponent.PlayAnimationWithResult(outlookStateData.param % 2U == 1U);
							}
							break;
						}
						case OutLookStateType.OutLook_RidePetCopilot:
						{
							XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(outlookStateData.paramother);
							bool flag7 = entity2 != null;
							if (flag7)
							{
								flag3 = true;
								XPetDocument.TryMountCopilot(true, entity, entity2, bInit);
							}
							break;
						}
						case OutLookStateType.OutLook_Trans:
							XTransformDocument.OnTransform(true, entity, bInit, false);
							break;
						default:
							xrole.PlayStateBack();
							break;
						}
						bool flag8 = flag3;
						if (flag8)
						{
							XEquipComponent xequipComponent = entity.GetXComponent(XEquipComponent.uuID) as XEquipComponent;
							bool flag9 = xequipComponent != null;
							if (flag9)
							{
								xequipComponent.EquipFromAttr();
							}
						}
					}
				}
			}
		}

		public static bool CanPlaySpecifiedAnimation(XEntity entity)
		{
			bool flag = entity == null || entity.Attributes == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = entity.Attributes.Outlook.state.type == OutLookStateType.OutLook_Trans;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_STATE_CANTCHANGE, "fece00");
					result = false;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}
	}
}
