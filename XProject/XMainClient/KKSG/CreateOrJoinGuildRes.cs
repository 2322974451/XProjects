using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200008B RID: 139
	[ProtoContract(Name = "CreateOrJoinGuildRes")]
	[Serializable]
	public class CreateOrJoinGuildRes : IExtensible
	{
		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x00013DFC File Offset: 0x00011FFC
		// (set) Token: 0x06000911 RID: 2321 RVA: 0x00013E28 File Offset: 0x00012028
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

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x00013E38 File Offset: 0x00012038
		// (set) Token: 0x06000913 RID: 2323 RVA: 0x00013E58 File Offset: 0x00012058
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

		// Token: 0x06000914 RID: 2324 RVA: 0x00013E9C File Offset: 0x0001209C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x00013EB4 File Offset: 0x000120B4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000916 RID: 2326 RVA: 0x00013EC0 File Offset: 0x000120C0
		// (set) Token: 0x06000917 RID: 2327 RVA: 0x00013EED File Offset: 0x000120ED
		[ProtoMember(2, IsRequired = false, Name = "gid", DataFormat = DataFormat.TwosComplement)]
		public ulong gid
		{
			get
			{
				return this._gid ?? 0UL;
			}
			set
			{
				this._gid = new ulong?(value);
			}
		}

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000918 RID: 2328 RVA: 0x00013EFC File Offset: 0x000120FC
		// (set) Token: 0x06000919 RID: 2329 RVA: 0x00013F1C File Offset: 0x0001211C
		[XmlIgnore]
		[Browsable(false)]
		public bool gidSpecified
		{
			get
			{
				return this._gid != null;
			}
			set
			{
				bool flag = value == (this._gid == null);
				if (flag)
				{
					this._gid = (value ? new ulong?(this.gid) : null);
				}
			}
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x00013F60 File Offset: 0x00012160
		private bool ShouldSerializegid()
		{
			return this.gidSpecified;
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x00013F78 File Offset: 0x00012178
		private void Resetgid()
		{
			this.gidSpecified = false;
		}

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x0600091C RID: 2332 RVA: 0x00013F84 File Offset: 0x00012184
		// (set) Token: 0x0600091D RID: 2333 RVA: 0x00013FA5 File Offset: 0x000121A5
		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x0600091E RID: 2334 RVA: 0x00013FB0 File Offset: 0x000121B0
		// (set) Token: 0x0600091F RID: 2335 RVA: 0x00013FCC File Offset: 0x000121CC
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00013FFC File Offset: 0x000121FC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x00014014 File Offset: 0x00012214
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x00014020 File Offset: 0x00012220
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400025A RID: 602
		private ErrorCode? _result;

		// Token: 0x0400025B RID: 603
		private ulong? _gid;

		// Token: 0x0400025C RID: 604
		private string _name;

		// Token: 0x0400025D RID: 605
		private IExtension extensionObject;
	}
}
