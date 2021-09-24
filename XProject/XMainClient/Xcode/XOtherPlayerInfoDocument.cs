using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XOtherPlayerInfoDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XOtherPlayerInfoDocument.uuID;
			}
		}

		public XOtherPlayerInfoView OtherPlayerInfoView
		{
			get
			{
				return this._XOtherPlayerInfoView;
			}
			set
			{
				this._XOtherPlayerInfoView = value;
			}
		}

		public override void PostUpdate(float fDeltaT)
		{
			bool hasRole = XSingleton<XInput>.singleton.HasRole;
			if (hasRole)
			{
				XEntity lastRole = XSingleton<XInput>.singleton.LastRole;
				bool flag = lastRole != null && lastRole.Attributes != null;
				if (flag)
				{
					ulong roleID = lastRole.Attributes.RoleID;
					XCharacterCommonMenuDocument.ReqCharacterMenuInfo(roleID, true);
				}
			}
		}

		public List<Item> GetOtherEmblemInfoList()
		{
			bool flag = this.m_Appearance == null;
			List<Item> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.m_Appearance.emblem;
			}
			return result;
		}

		public List<Item> GetOtherArtifactInfoList()
		{
			bool flag = this.m_Appearance == null;
			List<Item> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.m_Appearance.artifact;
			}
			return result;
		}

		public void OnGetUnitAppearance(GetUnitAppearanceRes oRes)
		{
			bool flag = oRes.UnitAppearance == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("[XOtherPlayerInfo] unitInfo is null", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				this.m_Appearance = oRes.UnitAppearance;
				DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.RefreshPlayerInfo(oRes.UnitAppearance);
			}
		}

		public void OnGetSpriteInfoReturn(GetUnitAppearanceRes oRes)
		{
			bool flag = oRes.UnitAppearance == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("[XOtherPlayerInfo] unitInfo is null", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				this.m_Appearance = oRes.UnitAppearance;
				DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.RefreshSpriteInfo(oRes.UnitAppearance.level, oRes.UnitAppearance.sprites, oRes.UnitAppearance);
			}
		}

		public void OnGetPetInfoReturn(GetUnitAppearanceRes oRes)
		{
			bool flag = oRes.UnitAppearance == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("[XOtherPlayerInfo] unitInfo is null", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.RefreshPetInfo(oRes.UnitAppearance);
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XOtherPlayerInfoDocument");

		public UnitAppearance m_Appearance = null;

		private XOtherPlayerInfoView _XOtherPlayerInfoView = null;
	}
}
