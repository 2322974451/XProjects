using System;
using System.Collections;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000051 RID: 81
	public class IOSAssetBundleLoader : MobileAssetBundleLoader
	{
		// Token: 0x060002A1 RID: 673 RVA: 0x00014B06 File Offset: 0x00012D06
		protected override IEnumerator LoadFromPackage()
		{
			bool flag = this.state == LoadState.State_Complete;
			if (flag)
			{
				this.Complete();
			}
			else
			{
				bool flag2 = this.state != LoadState.State_Error;
				if (flag2)
				{
					AssetBundleCreateRequest req = AssetBundle.LoadFromFileAsync(this._assetBundleSourceFile);
					while (!req.isDone)
					{
						yield return null;
					}
					bool flag3 = this._bundle == null;
					if (flag3)
					{
						this._bundle = req.assetBundle;
					}
					bool flag4 = this.state != LoadState.State_Complete && base.UnloadNotLoadingBundle(this._bundle);
					if (flag4)
					{
						req = AssetBundle.LoadFromFileAsync(this._assetBundleSourceFile);
						while (!req.isDone)
						{
							yield return null;
						}
						bool flag5 = this._bundle == null;
						if (flag5)
						{
							this._bundle = req.assetBundle;
						}
					}
					this.Complete();
					req = null;
				}
			}
			yield break;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00014B18 File Offset: 0x00012D18
		protected override void LoadFromPackageImm()
		{
			bool flag = this.state == LoadState.State_Complete;
			if (flag)
			{
				this.Complete();
			}
			else
			{
				bool flag2 = this.state != LoadState.State_Error;
				if (flag2)
				{
					bool flag3 = this._bundle == null;
					if (flag3)
					{
						this._bundle = AssetBundle.LoadFromFile(this._assetBundleSourceFile);
					}
					bool flag4 = this.state != LoadState.State_Complete && base.UnloadNotLoadingBundle(this._bundle);
					if (flag4)
					{
						bool flag5 = this._bundle == null;
						if (flag5)
						{
							this._bundle = AssetBundle.LoadFromFile(this._assetBundleSourceFile);
						}
					}
					this.Complete();
				}
			}
		}
	}
}
