using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GorillaNetworking;
using UnityEngine;

namespace GorillaStumpSignage.Tools
{
    internal class AssetLoader
    {
        private static bool _bundleLoaded;
        private static AssetBundle _storedBundle;

        private static Task _loadingTask = null;
        private static readonly Dictionary<string, Object> _assetCache = [];

        private static async Task LoadBundle()
        {
            var taskCompletionSource = new TaskCompletionSource<AssetBundle>();

            Stream stream = typeof(Plugin).Assembly.GetManifestResourceStream(Constants.BundlePath);
            var bundleLoadRequest = AssetBundle.LoadFromStreamAsync(stream);

            bundleLoadRequest.completed += operation =>
            {
                AssetBundleCreateRequest outRequest = operation as AssetBundleCreateRequest;
                taskCompletionSource.SetResult(outRequest.assetBundle);
            };

            _storedBundle = await taskCompletionSource.Task;
            _bundleLoaded = true;
        }

        public static async Task<T> LoadAsset<T>(string name) where T : Object
        {
            if (_assetCache.TryGetValue(name, out var _loadedObject)) return _loadedObject as T;

            if (!_bundleLoaded)
            {
                _loadingTask ??= LoadBundle();
                await _loadingTask;
            }

            var taskCompletionSource = new TaskCompletionSource<T>();
            var assetLoadRequest = _storedBundle.LoadAssetAsync<T>(name);

            assetLoadRequest.completed += operation =>
            {
                AssetBundleRequest outRequest = operation as AssetBundleRequest;
                if (outRequest.asset == null)
                {
                    taskCompletionSource.SetResult(null);
                    return;
                }

                taskCompletionSource.SetResult(outRequest.asset as T);
            };

            var asset = await taskCompletionSource.Task;
            _assetCache.AddOrUpdate(name, asset);
            return asset;
        }
    }
}
