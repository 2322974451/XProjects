using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000123 RID: 291
	[ProtoContract(Name = "GetAchievePointRewardRes")]
	[Serializable]
	public class GetAchievePointRewardRes : IExtensible
	{
		// Token: 0x170005C6 RID: 1478
		// (get) Token: 0x06001208 RID: 4616 RVA: 0x00024A98 File Offset: 0x00022C98
		// (set) Token: 0x06001209 RID: 4617 RVA: 0x00024AC4 File Offset: 0x00022CC4
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

		// Token: 0x170005C7 RID: 1479
		// (get) Token: 0x0600120A RID: 4618 RVA: 0x00024AD4 File Offset: 0x00022CD4
		// (set) Token: 0x0600120B RID: 4619 RVA: 0x00024AF4 File Offset: 0x00022CF4
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

		// Token: 0x0600120C RID: 4620 RVA: 0x00024B38 File Offset: 0x00022D38
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600120D RID: 4621 RVA: 0x00024B50 File Offset: 0x00022D50
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600120E RID: 4622 RVA: 0x00024B5C File Offset: 0x00022D5C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000484 RID: 1156
		private ErrorCode? _result;

		// Token: 0x04000485 RID: 1157
		private IExtension extensionObject;
	}
}
