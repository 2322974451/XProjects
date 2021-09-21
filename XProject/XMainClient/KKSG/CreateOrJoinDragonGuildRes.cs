using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004AC RID: 1196
	[ProtoContract(Name = "CreateOrJoinDragonGuildRes")]
	[Serializable]
	public class CreateOrJoinDragonGuildRes : IExtensible
	{
		// Token: 0x17001307 RID: 4871
		// (get) Token: 0x06003E22 RID: 15906 RVA: 0x00076838 File Offset: 0x00074A38
		// (set) Token: 0x06003E23 RID: 15907 RVA: 0x00076864 File Offset: 0x00074A64
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

		// Token: 0x17001308 RID: 4872
		// (get) Token: 0x06003E24 RID: 15908 RVA: 0x00076874 File Offset: 0x00074A74
		// (set) Token: 0x06003E25 RID: 15909 RVA: 0x00076894 File Offset: 0x00074A94
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

		// Token: 0x06003E26 RID: 15910 RVA: 0x000768D8 File Offset: 0x00074AD8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003E27 RID: 15911 RVA: 0x000768F0 File Offset: 0x00074AF0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001309 RID: 4873
		// (get) Token: 0x06003E28 RID: 15912 RVA: 0x000768FC File Offset: 0x00074AFC
		// (set) Token: 0x06003E29 RID: 15913 RVA: 0x00076929 File Offset: 0x00074B29
		[ProtoMember(2, IsRequired = false, Name = "dgid", DataFormat = DataFormat.TwosComplement)]
		public ulong dgid
		{
			get
			{
				return this._dgid ?? 0UL;
			}
			set
			{
				this._dgid = new ulong?(value);
			}
		}

		// Token: 0x1700130A RID: 4874
		// (get) Token: 0x06003E2A RID: 15914 RVA: 0x00076938 File Offset: 0x00074B38
		// (set) Token: 0x06003E2B RID: 15915 RVA: 0x00076958 File Offset: 0x00074B58
		[XmlIgnore]
		[Browsable(false)]
		public bool dgidSpecified
		{
			get
			{
				return this._dgid != null;
			}
			set
			{
				bool flag = value == (this._dgid == null);
				if (flag)
				{
					this._dgid = (value ? new ulong?(this.dgid) : null);
				}
			}
		}

		// Token: 0x06003E2C RID: 15916 RVA: 0x0007699C File Offset: 0x00074B9C
		private bool ShouldSerializedgid()
		{
			return this.dgidSpecified;
		}

		// Token: 0x06003E2D RID: 15917 RVA: 0x000769B4 File Offset: 0x00074BB4
		private void Resetdgid()
		{
			this.dgidSpecified = false;
		}

		// Token: 0x1700130B RID: 4875
		// (get) Token: 0x06003E2E RID: 15918 RVA: 0x000769C0 File Offset: 0x00074BC0
		// (set) Token: 0x06003E2F RID: 15919 RVA: 0x000769E1 File Offset: 0x00074BE1
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

		// Token: 0x1700130C RID: 4876
		// (get) Token: 0x06003E30 RID: 15920 RVA: 0x000769EC File Offset: 0x00074BEC
		// (set) Token: 0x06003E31 RID: 15921 RVA: 0x00076A08 File Offset: 0x00074C08
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

		// Token: 0x06003E32 RID: 15922 RVA: 0x00076A38 File Offset: 0x00074C38
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06003E33 RID: 15923 RVA: 0x00076A50 File Offset: 0x00074C50
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700130D RID: 4877
		// (get) Token: 0x06003E34 RID: 15924 RVA: 0x00076A5C File Offset: 0x00074C5C
		// (set) Token: 0x06003E35 RID: 15925 RVA: 0x00076A88 File Offset: 0x00074C88
		[ProtoMember(4, IsRequired = false, Name = "cdtime", DataFormat = DataFormat.TwosComplement)]
		public uint cdtime
		{
			get
			{
				return this._cdtime ?? 0U;
			}
			set
			{
				this._cdtime = new uint?(value);
			}
		}

		// Token: 0x1700130E RID: 4878
		// (get) Token: 0x06003E36 RID: 15926 RVA: 0x00076A98 File Offset: 0x00074C98
		// (set) Token: 0x06003E37 RID: 15927 RVA: 0x00076AB8 File Offset: 0x00074CB8
		[XmlIgnore]
		[Browsable(false)]
		public bool cdtimeSpecified
		{
			get
			{
				return this._cdtime != null;
			}
			set
			{
				bool flag = value == (this._cdtime == null);
				if (flag)
				{
					this._cdtime = (value ? new uint?(this.cdtime) : null);
				}
			}
		}

		// Token: 0x06003E38 RID: 15928 RVA: 0x00076AFC File Offset: 0x00074CFC
		private bool ShouldSerializecdtime()
		{
			return this.cdtimeSpecified;
		}

		// Token: 0x06003E39 RID: 15929 RVA: 0x00076B14 File Offset: 0x00074D14
		private void Resetcdtime()
		{
			this.cdtimeSpecified = false;
		}

		// Token: 0x06003E3A RID: 15930 RVA: 0x00076B20 File Offset: 0x00074D20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F79 RID: 3961
		private ErrorCode? _result;

		// Token: 0x04000F7A RID: 3962
		private ulong? _dgid;

		// Token: 0x04000F7B RID: 3963
		private string _name;

		// Token: 0x04000F7C RID: 3964
		private uint? _cdtime;

		// Token: 0x04000F7D RID: 3965
		private IExtension extensionObject;
	}
}
