using System;
using System.Collections;
using UnityEngine;

namespace XUtliPoolLib
{

	public class IOSAssetBundleLoader : MobileAssetBundleLoader
	{

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
