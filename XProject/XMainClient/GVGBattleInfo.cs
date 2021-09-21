using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200092F RID: 2351
	public class GVGBattleInfo
	{
		// Token: 0x17002BC8 RID: 11208
		// (get) Token: 0x06008DD0 RID: 36304 RVA: 0x00137B28 File Offset: 0x00135D28
		public List<GmfRole> Group
		{
			get
			{
				return this._groups;
			}
		}

		// Token: 0x17002BC9 RID: 11209
		// (get) Token: 0x06008DD1 RID: 36305 RVA: 0x00137B40 File Offset: 0x00135D40
		public GmfGuildBrief Base
		{
			get
			{
				return this._groupBase;
			}
		}

		// Token: 0x17002BCA RID: 11210
		// (get) Token: 0x06008DD2 RID: 36306 RVA: 0x00137B58 File Offset: 0x00135D58
		public uint Inspire
		{
			get
			{
				return this._inspire;
			}
		}

		// Token: 0x17002BCB RID: 11211
		// (get) Token: 0x06008DD3 RID: 36307 RVA: 0x00137B70 File Offset: 0x00135D70
		public int Size
		{
			get
			{
				return this._groups.Count;
			}
		}

		// Token: 0x06008DD4 RID: 36308 RVA: 0x00137B8D File Offset: 0x00135D8D
		public void Convert(GmfHalfRoles info)
		{
			this._groups.Clear();
			this._groups.AddRange(info.roles);
			this._groupBase = info.guildb;
			this._inspire = info.inspire;
		}

		// Token: 0x06008DD5 RID: 36309 RVA: 0x00137BC6 File Offset: 0x00135DC6
		public void Convert(List<GmfRoleCombat> combats)
		{
			this._roleCombat = combats;
		}

		// Token: 0x17002BCC RID: 11212
		// (get) Token: 0x06008DD6 RID: 36310 RVA: 0x00137BD0 File Offset: 0x00135DD0
		public bool Empty
		{
			get
			{
				return this.Size == 0;
			}
		}

		// Token: 0x06008DD7 RID: 36311 RVA: 0x00137BEC File Offset: 0x00135DEC
		public bool TryGetMember(ulong uid, out GmfRole member)
		{
			member = null;
			int i = 0;
			int count = this._groups.Count;
			while (i < count)
			{
				bool flag = uid == this._groups[i].roleID;
				if (flag)
				{
					member = this._groups[i];
					return true;
				}
				i++;
			}
			return false;
		}

		// Token: 0x06008DD8 RID: 36312 RVA: 0x00137C50 File Offset: 0x00135E50
		public bool TryGetCombat(ulong uid, out GmfCombat combat)
		{
			combat = null;
			bool flag = this._roleCombat == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int i = 0;
				int count = this._roleCombat.Count;
				while (i < count)
				{
					bool flag2 = this._roleCombat[i].gmfrole != null && this._roleCombat[i].gmfrole.roleid == uid;
					if (flag2)
					{
						combat = this._roleCombat[i].combat;
						return true;
					}
					i++;
				}
				result = false;
			}
			return result;
		}

		// Token: 0x04002E21 RID: 11809
		private List<GmfRole> _groups = new List<GmfRole>();

		// Token: 0x04002E22 RID: 11810
		private GmfGuildBrief _groupBase;

		// Token: 0x04002E23 RID: 11811
		private uint _inspire;

		// Token: 0x04002E24 RID: 11812
		private List<GmfRoleCombat> _roleCombat;
	}
}
