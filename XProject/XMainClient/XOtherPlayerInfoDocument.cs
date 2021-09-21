using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009B7 RID: 2487
	internal class XOtherPlayerInfoDocument : XDocComponent
	{
		// Token: 0x17002D6B RID: 11627
		// (get) Token: 0x060096D8 RID: 38616 RVA: 0x0016D73C File Offset: 0x0016B93C
		public override uint ID
		{
			get
			{
				return XOtherPlayerInfoDocument.uuID;
			}
		}

		// Token: 0x17002D6C RID: 11628
		// (get) Token: 0x060096D9 RID: 38617 RVA: 0x0016D754 File Offset: 0x0016B954
		// (set) Token: 0x060096DA RID: 38618 RVA: 0x0016D76C File Offset: 0x0016B96C
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

		// Token: 0x060096DC RID: 38620 RVA: 0x0016D790 File Offset: 0x0016B990
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

		// Token: 0x060096DD RID: 38621 RVA: 0x0016D7E4 File Offset: 0x0016B9E4
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

		// Token: 0x060096DE RID: 38622 RVA: 0x0016D814 File Offset: 0x0016BA14
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

		// Token: 0x060096DF RID: 38623 RVA: 0x0016D844 File Offset: 0x0016BA44
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

		// Token: 0x060096E0 RID: 38624 RVA: 0x0016D898 File Offset: 0x0016BA98
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

		// Token: 0x060096E1 RID: 38625 RVA: 0x0016D900 File Offset: 0x0016BB00
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

		// Token: 0x060096E2 RID: 38626 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04003362 RID: 13154
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XOtherPlayerInfoDocument");

		// Token: 0x04003363 RID: 13155
		public UnitAppearance m_Appearance = null;

		// Token: 0x04003364 RID: 13156
		private XOtherPlayerInfoView _XOtherPlayerInfoView = null;
	}
}
