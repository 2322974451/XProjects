using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{

	public class GVGBattleInfo
	{

		public List<GmfRole> Group
		{
			get
			{
				return this._groups;
			}
		}

		public GmfGuildBrief Base
		{
			get
			{
				return this._groupBase;
			}
		}

		public uint Inspire
		{
			get
			{
				return this._inspire;
			}
		}

		public int Size
		{
			get
			{
				return this._groups.Count;
			}
		}

		public void Convert(GmfHalfRoles info)
		{
			this._groups.Clear();
			this._groups.AddRange(info.roles);
			this._groupBase = info.guildb;
			this._inspire = info.inspire;
		}

		public void Convert(List<GmfRoleCombat> combats)
		{
			this._roleCombat = combats;
		}

		public bool Empty
		{
			get
			{
				return this.Size == 0;
			}
		}

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

		private List<GmfRole> _groups = new List<GmfRole>();

		private GmfGuildBrief _groupBase;

		private uint _inspire;

		private List<GmfRoleCombat> _roleCombat;
	}
}
