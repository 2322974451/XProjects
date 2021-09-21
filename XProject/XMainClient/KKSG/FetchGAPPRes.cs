using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200008D RID: 141
	[ProtoContract(Name = "FetchGAPPRes")]
	[Serializable]
	public class FetchGAPPRes : IExtensible
	{
		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000926 RID: 2342 RVA: 0x000140B8 File Offset: 0x000122B8
		// (set) Token: 0x06000927 RID: 2343 RVA: 0x000140E4 File Offset: 0x000122E4
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

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000928 RID: 2344 RVA: 0x000140F4 File Offset: 0x000122F4
		// (set) Token: 0x06000929 RID: 2345 RVA: 0x00014114 File Offset: 0x00012314
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

		// Token: 0x0600092A RID: 2346 RVA: 0x00014158 File Offset: 0x00012358
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x00014170 File Offset: 0x00012370
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x0600092C RID: 2348 RVA: 0x0001417C File Offset: 0x0001237C
		[ProtoMember(2, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x0600092D RID: 2349 RVA: 0x00014194 File Offset: 0x00012394
		[ProtoMember(3, Name = "rolename", DataFormat = DataFormat.Default)]
		public List<string> rolename
		{
			get
			{
				return this._rolename;
			}
		}

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x0600092E RID: 2350 RVA: 0x000141AC File Offset: 0x000123AC
		[ProtoMember(4, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ppt
		{
			get
			{
				return this._ppt;
			}
		}

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x0600092F RID: 2351 RVA: 0x000141C4 File Offset: 0x000123C4
		[ProtoMember(5, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public List<uint> time
		{
			get
			{
				return this._time;
			}
		}

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06000930 RID: 2352 RVA: 0x000141DC File Offset: 0x000123DC
		[ProtoMember(6, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public List<uint> level
		{
			get
			{
				return this._level;
			}
		}

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06000931 RID: 2353 RVA: 0x000141F4 File Offset: 0x000123F4
		[ProtoMember(7, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public List<RoleType> profession
		{
			get
			{
				return this._profession;
			}
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0001420C File Offset: 0x0001240C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400025F RID: 607
		private ErrorCode? _result;

		// Token: 0x04000260 RID: 608
		private readonly List<ulong> _roleid = new List<ulong>();

		// Token: 0x04000261 RID: 609
		private readonly List<string> _rolename = new List<string>();

		// Token: 0x04000262 RID: 610
		private readonly List<uint> _ppt = new List<uint>();

		// Token: 0x04000263 RID: 611
		private readonly List<uint> _time = new List<uint>();

		// Token: 0x04000264 RID: 612
		private readonly List<uint> _level = new List<uint>();

		// Token: 0x04000265 RID: 613
		private readonly List<RoleType> _profession = new List<RoleType>();

		// Token: 0x04000266 RID: 614
		private IExtension extensionObject;
	}
}
