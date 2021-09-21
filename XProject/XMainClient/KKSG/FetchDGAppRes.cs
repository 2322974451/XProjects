using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004AF RID: 1199
	[ProtoContract(Name = "FetchDGAppRes")]
	[Serializable]
	public class FetchDGAppRes : IExtensible
	{
		// Token: 0x17001325 RID: 4901
		// (get) Token: 0x06003E82 RID: 16002 RVA: 0x0007741C File Offset: 0x0007561C
		// (set) Token: 0x06003E83 RID: 16003 RVA: 0x00077448 File Offset: 0x00075648
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17001326 RID: 4902
		// (get) Token: 0x06003E84 RID: 16004 RVA: 0x00077458 File Offset: 0x00075658
		// (set) Token: 0x06003E85 RID: 16005 RVA: 0x00077478 File Offset: 0x00075678
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06003E86 RID: 16006 RVA: 0x000774BC File Offset: 0x000756BC
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003E87 RID: 16007 RVA: 0x000774D4 File Offset: 0x000756D4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001327 RID: 4903
		// (get) Token: 0x06003E88 RID: 16008 RVA: 0x000774E0 File Offset: 0x000756E0
		[ProtoMember(2, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		// Token: 0x17001328 RID: 4904
		// (get) Token: 0x06003E89 RID: 16009 RVA: 0x000774F8 File Offset: 0x000756F8
		[ProtoMember(3, Name = "rolename", DataFormat = DataFormat.Default)]
		public List<string> rolename
		{
			get
			{
				return this._rolename;
			}
		}

		// Token: 0x17001329 RID: 4905
		// (get) Token: 0x06003E8A RID: 16010 RVA: 0x00077510 File Offset: 0x00075710
		[ProtoMember(4, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ppt
		{
			get
			{
				return this._ppt;
			}
		}

		// Token: 0x1700132A RID: 4906
		// (get) Token: 0x06003E8B RID: 16011 RVA: 0x00077528 File Offset: 0x00075728
		[ProtoMember(5, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public List<uint> time
		{
			get
			{
				return this._time;
			}
		}

		// Token: 0x1700132B RID: 4907
		// (get) Token: 0x06003E8C RID: 16012 RVA: 0x00077540 File Offset: 0x00075740
		[ProtoMember(6, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public List<uint> level
		{
			get
			{
				return this._level;
			}
		}

		// Token: 0x1700132C RID: 4908
		// (get) Token: 0x06003E8D RID: 16013 RVA: 0x00077558 File Offset: 0x00075758
		[ProtoMember(7, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public List<RoleType> profession
		{
			get
			{
				return this._profession;
			}
		}

		// Token: 0x06003E8E RID: 16014 RVA: 0x00077570 File Offset: 0x00075770
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F8B RID: 3979
		private ErrorCode? _result;

		// Token: 0x04000F8C RID: 3980
		private readonly List<ulong> _roleid = new List<ulong>();

		// Token: 0x04000F8D RID: 3981
		private readonly List<string> _rolename = new List<string>();

		// Token: 0x04000F8E RID: 3982
		private readonly List<uint> _ppt = new List<uint>();

		// Token: 0x04000F8F RID: 3983
		private readonly List<uint> _time = new List<uint>();

		// Token: 0x04000F90 RID: 3984
		private readonly List<uint> _level = new List<uint>();

		// Token: 0x04000F91 RID: 3985
		private readonly List<RoleType> _profession = new List<RoleType>();

		// Token: 0x04000F92 RID: 3986
		private IExtension extensionObject;
	}
}
