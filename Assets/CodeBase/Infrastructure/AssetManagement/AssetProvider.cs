using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CodeBase.Infrastructure.AssetManagement
{
    public class AssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _completedCache = new Dictionary<string, AsyncOperationHandle>();
        private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new Dictionary<string, List<AsyncOperationHandle>>();

        public AssetProvider()
        {
            Addressables.InitializeAsync();
        }

        public async Task<T> Load<T>(AssetReference assetReference) where T : class
        {
            if (_completedCache.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle completedHandle))
                return completedHandle.Result as T;

            return await RunWithChacheOnComplete(Addressables.LoadAssetAsync<T>(assetReference), assetReference.AssetGUID);
        }

        public async Task<T> Load<T>(string address) where T : class
        {
            if (_completedCache.TryGetValue(address, out AsyncOperationHandle completedHandle))
                return completedHandle.Result as T;

            return await RunWithChacheOnComplete(Addressables.LoadAssetAsync<T>(address), address);
        }

        public Task<GameObject> Instantiate(string address, Vector3 at) => 
            Addressables.InstantiateAsync(address, at, Quaternion.identity).Task;

        public Task<GameObject> Instantiate(string address) => 
            Addressables.InstantiateAsync(address).Task;

        public void CleanUp()
        {
            foreach (List<AsyncOperationHandle> resourceHandles in _handles.Values)
            {
                foreach (AsyncOperationHandle handle in resourceHandles)
                {
                    Addressables.Release(handle);
                }
            }

            _completedCache.Clear();
            _handles.Clear();
        }

        private async Task<T> RunWithChacheOnComplete<T>(AsyncOperationHandle<T> handle, string key) where T : class
        {
            handle.Completed += completeHandler =>
            {
                _completedCache[key] = completeHandler;
            };

            AddHandle<T>(handle, key);

            return await handle.Task;
        }

        private void AddHandle<T>(AsyncOperationHandle handle, string key)
        {
            if(!_handles.TryGetValue(key, out List<AsyncOperationHandle> resourceHandles))
            {
                resourceHandles = new List<AsyncOperationHandle>();
                _handles[key] = resourceHandles;
            }

            resourceHandles.Add(handle);
        }
    }
}