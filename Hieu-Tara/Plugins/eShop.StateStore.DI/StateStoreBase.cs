using BanHangHieuTerraum.UseCase.PluginInterface.StateStore;

namespace BanHangHieuTerraum.StateStore.DI
{
    public class StateStoreBase : IStateStore
    {
        protected Action _listeners;
        public void AddStateChangeListeners(Action listeners)=>this._listeners += listeners;
       
        public void RemoveSateChangeListeners(Action listeners) => this._listeners -= listeners;

        public void BroadCastStateChange()
        {
            //throw new NotImplementedException();
            if (this._listeners != null)
                this._listeners.Invoke();
        }
    }
}
