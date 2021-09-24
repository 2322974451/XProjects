using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMyApplyStudentInfoArg")]
	[Serializable]
	public class GetMyApplyStudentInfoArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isRefresh", DataFormat = DataFormat.Default)]
		public bool isRefresh
		{
			get
			{
				return this._isRefresh ?? false;
			}
			set
			{
				this._isRefresh = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isRefreshSpecified
		{
			get
			{
				return this._isRefresh != null;
			}
			set
			{
				bool flag = value == (this._isRefresh == null);
				if (flag)
				{
					this._isRefresh = (value ? new bool?(this.isRefresh) : null);
				}
			}
		}

		private bool ShouldSerializeisRefresh()
		{
			return this.isRefreshSpecified;
		}

		private void ResetisRefresh()
		{
			this.isRefreshSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isRefresh;

		private IExtension extensionObject;
	}
}
